using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Pwnsaw;

namespace HeroCreator
{
	public partial class HeroPoll : Form
	{
		private readonly string _heroDataFilename = "Data/CombinedHeroFile.xml";

		enum MatrixType
		{
			ThreatMatrix,
			CompatibilityMatrix
		}

		private HeroType _curHero = HeroType.Adagio;
		private readonly Dictionary<HeroType, Hero> _allheroData = new Dictionary< HeroType, Hero >();
		private readonly Dictionary<HeroType, FlowLayoutPanel> _heroThreatMatrices = new Dictionary<HeroType, FlowLayoutPanel>();
		private readonly Dictionary<HeroType, FlowLayoutPanel> _heroCompatibilityMatrices = new Dictionary<HeroType, FlowLayoutPanel>(); 

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

			ReinitializeMatrix(_heroThreatMatrices, hero.ThreatMatrix  );
			ReinitializeMatrix( _heroCompatibilityMatrices, hero.CompatibilityMatrix );
		}

		private void ReinitializeMatrix( Dictionary<HeroType, FlowLayoutPanel> matrixControls,  Dictionary<HeroType, float> heroMatrix )
		{
			foreach( var kvp in matrixControls )
			{
				var buttonIdx = 0;

				var heroValue = heroMatrix[ kvp.Key ];

				foreach( var ctrl in kvp.Value.Controls )
				{
					var rb = ctrl as RadioButton;

					if( rb == null )
					{
						continue;
					}

					buttonIdx++;

					if( heroValue != 0 )
					{
						rb.Checked = ( heroValue == buttonIdx );
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

			this.threatMatrixPanel.MaximumSize = new Size( 0, 285 );
			this.compatibilityMatrixPanel.MaximumSize = new Size( 0, 285 );

			var radioButtongroupSize = new Size( 80 * 5, 25 );
			var rbHSpacing = 25;
			var rbMargin = new Padding( rbHSpacing, 0, rbHSpacing, 0 ); ;

			for( var x = 0; x < numheroes; x++ )
			{
				var curHero = (HeroType) x;

				var curHeroImage = (Bitmap)Properties.Resources.ResourceManager.GetObject( curHero.ToString().ToLower() );

				this.threatMatrixPanel.Controls.Add( HeroCreatorUtils.CreatePictureBoxFromImage( curHeroImage ), 0, x );
				this.compatibilityMatrixPanel.Controls.Add( HeroCreatorUtils.CreatePictureBoxFromImage( curHeroImage ), 0, x );

				var threatRadioButtonsGroup = new FlowLayoutPanel()
				{
					FlowDirection = FlowDirection.LeftToRight,
					Size = radioButtongroupSize,
					WrapContents = false,
				};

				_heroThreatMatrices.Add( curHero, threatRadioButtonsGroup );

				for( var y = 0; y < 5; y++ )
				{
					var rb = new RadioButton();
					rb.Margin = rbMargin;
					rb.AutoSize = true;
					threatRadioButtonsGroup.Controls.Add( rb );		
				}

				this.threatMatrixPanel.Controls.Add( threatRadioButtonsGroup, 1, x );
				

				var compatibilityRdioBtnGroup = new FlowLayoutPanel()
				{
					FlowDirection = FlowDirection.LeftToRight,
					Size = radioButtongroupSize,
					WrapContents = false,
				};

				_heroCompatibilityMatrices.Add( curHero, compatibilityRdioBtnGroup );

				for( var y = 0; y < 3; y++ )
				{
					var rb = new RadioButton();
					rb.Margin = rbMargin;
					rb.AutoSize = true;
					compatibilityRdioBtnGroup.Controls.Add( rb );
				}

				this.compatibilityMatrixPanel.Controls.Add( compatibilityRdioBtnGroup, 1, x );
			}
		}

		private void InitializeButtons()
		{
			this.btnNextHero.Click += OnNextHeroBtnClicked;
			this.btnPrevHero.Click += OnPrevHeroBtnClicked;
		}

		public bool IsMatrixComplete( Dictionary<HeroType, FlowLayoutPanel> matrixPanel )
		{
			var valueSelected = false;
			foreach( var kvp in matrixPanel )
			{
				valueSelected = false;

				foreach( var ctrl in kvp.Value.Controls )
				{
					var rb = ctrl as RadioButton;

					if( rb == null )
					{
						continue;
					}

					if( rb.Checked )
					{
						valueSelected = true;
						break;
					}
				}

				if( !valueSelected )
				{
					MessageBox.Show( string.Format( "Please finish filling out matrix for hero {0}", kvp.Key) );
					return false;
				}
			}

			return true;
		}

		private void OnPrevHeroBtnClicked( object sender, EventArgs eventArgs )
		{
			if( _curHero == HeroType.Adagio )
			{
				return;
			}

#if !DEBUG
			if( !( IsMatrixComplete( _heroThreatMatrices ) && IsMatrixComplete( _heroCompatibilityMatrices ) ) )
			{
				return;
			}
#endif

			StoreCurHeroData();
			ResetForm();
			SetHero( _curHero - 1 );

			this.btnNextHero.Visible = true;

			if( _curHero == HeroType.Adagio )
			{
				this.btnPrevHero.Visible = false;
			}

			this.btnNextHero.Text = "Next Hero";
		}

		private void HeroTierRankingsComplete( object sender, EventArgs e )
		{
			var rankingsForm = sender as TierRankings;
			if( rankingsForm == null )
			{
				return;
			}

			foreach( var kvp in _allheroData )
			{
				kvp.Value.Ranking = rankingsForm.HeroRankings.IndexOf( kvp.Key ) + 1;
			}

			// At this point we have all of the data we need. Ship it off into the google doc.
		}

		private void OnNextHeroBtnClicked( object sender, EventArgs eventArgs )
		{
#if !DEBUG
			if( !( IsMatrixComplete( _heroThreatMatrices ) && IsMatrixComplete( _heroCompatibilityMatrices ) ) )
			{
				return;
			}
#endif

			// TODO: Check that everything is valid and then open the tier ranker.
			if( _curHero == HeroType.Vox )
			{
				var heroPollForm = new TierRankings();

				heroPollForm.Closed += HeroTierRankingsComplete;

				heroPollForm.ShowDialog();

				return;
			}

			StoreCurHeroData();
			ResetForm();
			SetHero( _curHero + 1 );

			if( _curHero == HeroType.Vox )
			{
				this.btnNextHero.Text = "Finish";
			}

			this.btnPrevHero.Visible = true;
		}

		private void ResetForm()
		{
			ResetMatrix( _heroThreatMatrices );
			ResetMatrix( _heroCompatibilityMatrices );
		}

		private void ResetMatrix( Dictionary<HeroType, FlowLayoutPanel> matrixToReset )
		{
			foreach( var kvp in matrixToReset )
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
			var heroesList = Util.DeserializeHeroList( this._heroDataFilename );

			foreach( var hero in heroesList )
			{
				_allheroData[ hero.HType ] = hero;
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
			StoreMatrixValues( MatrixType.ThreatMatrix, _heroThreatMatrices );
			StoreMatrixValues( MatrixType.CompatibilityMatrix, _heroCompatibilityMatrices );
		}

		private void StoreMatrixValues( MatrixType matrixType, Dictionary<HeroType, FlowLayoutPanel> heroMasdatrix )
		{
			var curHero = _allheroData[ _curHero ];

			var matrix = matrixType == MatrixType.ThreatMatrix ? curHero.ThreatMatrix : curHero.CompatibilityMatrix;

			var heroMatrices = matrixType == MatrixType.ThreatMatrix ? _heroThreatMatrices : _heroCompatibilityMatrices;
			foreach( var kvp in heroMatrices )
			{
				var threateningHero = kvp.Key;
				var value = 0;
				var maxValue = 0;

				foreach( var ctrl in kvp.Value.Controls )
				{
					var rButton = ctrl as RadioButton;

					if( rButton == null )
					{
						continue;
					}

					maxValue++;

					if( rButton.Checked )
					{
						value = maxValue;
						matrix[ threateningHero ] = value;
					}
				}

				// Update that hero's value with the inverse value
				if( _curHero == kvp.Key )
				{
					continue;
				}

				var invHero = _allheroData[ kvp.Key ];

				var otherHeroMatrix = matrixType == MatrixType.ThreatMatrix ? invHero.ThreatMatrix : invHero.CompatibilityMatrix;

				if( value != 0 && otherHeroMatrix[ _curHero ] == 0 )
				{
					// Compatibility matrices should match up, while threats should use the inverse.
					otherHeroMatrix[ _curHero ] = matrixType == MatrixType.ThreatMatrix ? ++maxValue - value : value;
				}
			}
		}


	}
}
