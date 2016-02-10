using System;
using System.Windows.Forms;
using Pwnsaw;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace HeroCreator
{
    public partial class HeroGenerator : Form
    {
        private readonly string xmlFilterString = "Xml files (*.xml)|*.xml";

        DataContractSerializer _serializer;
        DataContractSerializer _listSerializer;
        List<HeroType> _heroTypes = new List<HeroType>();
        Random _rng = new Random();

        string lastDirectory = string.Empty;

        public HeroGenerator()
        {
            InitializeComponent();
            InitializeEvents();
            InitializeData();

            _serializer = new DataContractSerializer( typeof( Hero ) );
            _listSerializer = new DataContractSerializer( typeof( List<Hero> ) );
        }

        private void InitializeEvents()
        {
            this.btnGenerateHero.Click += this.GenerateHero;
            this.combineHeroFilesToolStripMenuItem.Click += this.CombineHeroFiles;
        }

        private List<T> GetEnumList<T>( bool pruneFirstEntry = false ) where T : IComparable
        {
            var allTypes = Enum.GetValues(typeof(T));

            var returnList = new List<T>();

            foreach (var enumVal in allTypes )
            {
                if (pruneFirstEntry)
                {
                    var testVal = allTypes.GetValue(0);
                    if ( ((T)testVal).CompareTo(((T)enumVal)) == 0 )
                    {
                        continue;
                    }
                }

                returnList.Add( (T)enumVal );
            }

            return returnList;
        }

        private void InitializeData()
        {
            _heroTypes = GetEnumList<HeroType>();
            boxHeroType.DataSource = _heroTypes;
            boxAttackRange.DataSource = GetEnumList<AttackRange>( true );
            boxHeroRole.DataSource = GetEnumList<HeroRole>(true);
            boxBuild.DataSource = GetEnumList<HeroBuild>(true);

            boxTier.Minimum = 1;
            boxTier.Maximum = _heroTypes.Count;
        }

        private void GenerateHero(object sender, EventArgs e)
        {
            HeroType heroType;
            var result = Enum.TryParse<HeroType>(boxHeroType.SelectedValue.ToString(), out heroType);
            if ( !result )
            {
                throw new ArgumentException("Error parsing HeroType");
            }

            AttackRange attackRange;
            result = Enum.TryParse<AttackRange>(boxAttackRange.SelectedValue.ToString(), out attackRange);
            if (!result)
            {
                throw new ArgumentException("Error parsing AttackRange");
            }

            var role = (HeroRole)GetSelectedItems(boxHeroRole);

            var build = (HeroBuild)GetSelectedItems(boxBuild);

            var tier = (int)boxTier.Value;

            var hero = new Hero()
            {
                HType = heroType,
                Build = build,
                Range = attackRange,
                Role = role,
                Ranking = tier
            };

            // For just generate bullshit compatibility matrices.
            foreach( HeroType type in _heroTypes )
            {
                hero.ThreatMatrix[type] = _rng.Next(11);
                hero.CompatibilityMatrix[type] = _rng.Next(11);
            }

            SaveFileDialog fd = new SaveFileDialog();
            fd.FileName = hero.DisplayName;
            fd.Filter = xmlFilterString;

            if ( !string.IsNullOrEmpty( lastDirectory ) )
            {
                fd.InitialDirectory = lastDirectory;
            }

            lastDirectory = System.IO.Path.GetDirectoryName( fd.FileName );
            
            var dialogResult = fd.ShowDialog();

            if (dialogResult != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            using ( var fileStream = fd.OpenFile() )
            {
                _serializer.WriteObject(fileStream, hero);
            }
        }

        private int GetSelectedItems( ListBox listBox )
        {
            var result = 0;

            foreach (var item in listBox.SelectedItems)
            {
                result |= (int)item;
            }

            return result;
        }

        private void CombineHeroFiles( object sender, EventArgs e )
        {
            var openFiles = new OpenFileDialog();
            openFiles.Multiselect = true;
            openFiles.Filter = xmlFilterString;

            var dialogResult = openFiles.ShowDialog();

            if (dialogResult != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            var heroesToSerialize = new List<Hero>();
            foreach( var file in openFiles.FileNames )
            {
                using ( var fs = System.IO.File.OpenRead( file ) )
                {
                    var hero = _serializer.ReadObject( fs ) as Hero;
                    if ( hero != null )
                    {
                        heroesToSerialize.Add( hero );
                    }
                }
            }

            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = xmlFilterString;
            fd.InitialDirectory = lastDirectory;
            fd.FileName = "CombinedHeroFile";

            if (!string.IsNullOrEmpty(lastDirectory))
            {
                fd.InitialDirectory = lastDirectory;
            }

            lastDirectory = System.IO.Path.GetDirectoryName(fd.FileName);

            dialogResult = fd.ShowDialog();

            if (dialogResult != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            using ( var fs = fd.OpenFile() )
            {
                _listSerializer.WriteObject( fs, heroesToSerialize );
            }
        }

		private void heroPollToolStripMenuItem_Click( object sender, EventArgs e )
		{
			var heroPollForm = new HeroPoll();

			heroPollForm.Show();
		}
    }
}
