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
        DataContractSerializer _serializer;
        List<HeroType> _heroTypes = new List<HeroType>();
        Random _rng = new Random();

        string lastDirectory = string.Empty;

        public HeroGenerator()
        {
            InitializeComponent();
            InitializeEvents();
            InitializeData();

            _serializer = new DataContractSerializer( typeof( Hero ) );
        }

        private void InitializeEvents()
        {
            this.btnGenerateHero.Click += new System.EventHandler( this.GenerateHero );
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
            fd.AddExtension = true;
            fd.Filter = "Xml files (*.xml)|*.xml|";

            if ( !string.IsNullOrEmpty( lastDirectory ) )
            {
                fd.InitialDirectory = lastDirectory;
            }

            lastDirectory = System.IO.Path.GetDirectoryName( fd.FileName );
            
            fd.ShowDialog();

            var fileStream = fd.OpenFile();

            _serializer.WriteObject( fileStream, hero );

            fileStream.Close();
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

    }
}
