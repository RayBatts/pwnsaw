using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;
using Pwnsaw;

namespace HeroCreator
{
	public partial class HeroPoll : Form
	{
		private readonly string _heroDataFilename = "Data/CombinedHeroFile.xml";

		private HeroType _curHero = HeroType.Adagio;
		private readonly Dictionary<HeroType, Hero> _allheroData = new Dictionary< HeroType, Hero >();
		private readonly Dictionary<HeroType, FlowLayoutPanel> _heroThreatMatrices = new Dictionary<HeroType, FlowLayoutPanel>(); 

		public HeroPoll()
		{
			InitializeComponent();
			InitializeHeroes();
			InitializeForm();
			InitializeButtons();

			
			SetHero( _curHero );
		}

		private void SetHero( HeroType newHero )
		{
			ResetForm();

			_curHero = newHero;

			var hero = _allheroData[ _curHero ];
			this.imgCurHero.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject( hero.DisplayName.ToLower() );

			lblCurHeroName.Text = hero.DisplayName;

			// Initialize our threat matrix.
			foreach( var kvp in _heroThreatMatrices )
			{
				var buttonIdx = 0;

				var heroThreat = hero.ThreatMatrix[ kvp.Key ];

				foreach( var ctrl in kvp.Value.Controls )
				{
					var rb = ctrl as RadioButton;

					if( rb == null )
					{
						continue;
					}

					buttonIdx++;

					if( heroThreat != 0 )
					{
						rb.Checked = ( heroThreat == buttonIdx );
						continue;
					}

					rb.Checked = false;
				}
			}
		}

		private void InitializeForm()
		{
			var heroes = Enum.GetValues( typeof( HeroType ) );
			var numheroes = heroes.Length;

			this.threatMatrixPanel.MaximumSize = new Size(0, 285);

			var radioButtongroupSize = new Size( 80 * 5, 25 );
			var rbHSpacing = 25;
			var rbMargin = new Padding( rbHSpacing, 0, rbHSpacing, 0 ); ;

			for( var x = 0; x < numheroes; x++ )
			{
				var curHero = (HeroType) x;

				var curHeroImage = (Bitmap)Properties.Resources.ResourceManager.GetObject( curHero.ToString().ToLower() );

				this.threatMatrixPanel.Controls.Add( CreatePictureBoxFromImage( curHeroImage ), 0, x );

				var radioButtonsGroup = new FlowLayoutPanel()
				{
					FlowDirection = FlowDirection.LeftToRight,
					Size = radioButtongroupSize,
					WrapContents = false,
				};

				_heroThreatMatrices.Add( curHero, radioButtonsGroup );

				for( var y = 0; y < 5; y++ )
				{
					var rb = new RadioButton();
					rb.Margin = rbMargin;
					rb.AutoSize = true;
					radioButtonsGroup.Controls.Add( rb );		
				}

				this.threatMatrixPanel.Controls.Add( radioButtonsGroup, 1, x );
			}
		}

		private void InitializeButtons()
		{
			this.btnNextHero.Click += OnNextHeroBtnClicked;
			this.btnPrevHero.Click += OnPrevHeroBtnClicked;
		}

		private void OnPrevHeroBtnClicked( object sender, EventArgs eventArgs )
		{
			if( _curHero == HeroType.Adagio )
			{
				return;
			}

			StoreCurHeroData();
			ResetForm();
			SetHero( _curHero - 1 );
		}

		private void OnNextHeroBtnClicked( object sender, EventArgs eventArgs )
		{
			if( _curHero == HeroType.Vox )
			{
				return;
			}

			StoreCurHeroData();
			ResetForm();
			SetHero( _curHero + 1 );
		}

		private void ResetForm()
		{
			foreach( var kvp in _heroThreatMatrices )
			{
				foreach( var ctrl in kvp.Value.Controls )
				{
					var rb = ctrl as RadioButton;

					if( rb == null )
					{
						continue;
					}

					rb.Checked = false;
				}
			}
		}

		private void InitializeHeroes()
		{
			var heroSerializer = new DataContractSerializer( typeof( List<Hero> ) );

			using( var dataFileStream = new FileStream( this._heroDataFilename, FileMode.Open )  )
			{
				var dictReader = XmlDictionaryReader.CreateTextReader( dataFileStream, new XmlDictionaryReaderQuotas() );

				while( dictReader.Read() )
				{

					switch( dictReader.NodeType )
					{
						case XmlNodeType.Element:
							if( heroSerializer.IsStartObject( dictReader ) )
							{
								var herosList = (List<Hero>)heroSerializer.ReadObject( dictReader );
								foreach( var hero in herosList )
								{
									_allheroData[hero.HType] = hero;
								}
							}
							break;
					}
				}
			}

			// reinitialize all values for this local copy.
			foreach( var kvp in _allheroData )
			{
				kvp.Value.ResetCompatibilityMatrix();
				kvp.Value.ResetThreatMatrix();
				
			}
		}

		private void StoreCurHeroData()
		{
			var curHero = _allheroData[ _curHero ];

			var heroMatrix = curHero.ThreatMatrix;

			// Store their threat matrix
			foreach( var kvp in _heroThreatMatrices )
			{
				var threateningHero = kvp.Key;
				var threatValue = 0;
				var maxThreatValue = 0;

				foreach( var ctrl in kvp.Value.Controls )
				{
					var rButton = ctrl as RadioButton;

					if( rButton == null )
					{
						continue;
					}

					maxThreatValue++;

					if( rButton.Checked )
					{
						threatValue = maxThreatValue;
						heroMatrix[ threateningHero ] = threatValue;
					}
				}

				// Update that hero's value with the inverse threat value

				if( _curHero == kvp.Key )
				{
					continue;
				}

				var invHero = _allheroData[ kvp.Key ];

				if( threatValue != 0 && invHero.ThreatMatrix[ _curHero ] == 0 )
				{
					invHero.ThreatMatrix[ _curHero ] = ++maxThreatValue - threatValue;
				}
			}

			//TODO: Store their compatibility matrix.
		}

		private PictureBox CreatePictureBoxFromImage( Image heroImage )
		{
			var pictureSize = 25;
			return new PictureBox()
			{
				Image = heroImage,
				Size = new Size( pictureSize, pictureSize ),
				SizeMode = PictureBoxSizeMode.StretchImage
			};
		}
	}
}
