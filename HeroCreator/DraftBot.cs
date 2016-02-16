using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using HeroCreator.Properties;
using Pwnsaw;
using Pwnsaw.Draft;

namespace HeroCreator
{
	public partial class DraftBot : Form
	{
		private DraftManager _draftManager = new DraftManager();

		readonly private Dictionary<PictureBox, HeroType> _buttonToHeroLookup = new Dictionary<PictureBox, HeroType>();
		readonly private Dictionary<HeroType, PictureBox> _heroToButtonLoookup = new Dictionary<HeroType, PictureBox>();

		public TeamColor _playerTeamColor;

		public DraftBot()
		{
			InitializeComponent();
			InitializeForm();

			_draftManager.OnHeroChosen += OnHeroChosen;
			_draftManager.Reset( _playerTeamColor );
		}

		public void SetOptions( TeamColor playerTeam, int roundNum )
		{
			if( roundNum < 1 || roundNum > 5 )
			{
				return;
			}

			_playerTeamColor = playerTeam;

			_draftManager.RoundCount = roundNum;
			_draftManager.Reset( _playerTeamColor );
		}

		private void InitializeForm()
		{
			this.resetDraftToolStripMenuItem.Click += (s, e) => ResetDraft();
			this.draftOptionsToolStripMenuItem.Click += (s, e) =>
			{
				var optionsForm = new DraftOptions( this );

			};
			this.btnNextDraft.Click += (s, e) => ResetDraft();

			imgBlueTeamBanOverlay.Parent = imgBlueBan;
			imgBlueTeamBanOverlay.Location = new Point( 0, 0 );
			imgBlueTeamBanOverlay.Visible = false;

			imgRedTeamBanOverlay.Parent = imgRedBan;
			imgRedTeamBanOverlay.Location = new Point( 0, 0 );
			imgRedTeamBanOverlay.Visible = false;

			lblCurrentPhase.Text = DraftData.DraftPhase.FirstBan.ToString();

			// Initialize the hero panel.
			var allHeroTypes = Enum.GetValues( typeof(HeroType) );
			foreach( var hero in allHeroTypes )
			{
				var heroPicture = (Bitmap)Properties.Resources.ResourceManager.GetObject( hero.ToString().ToLower() );
				var pictureBox = new PictureBox()
				{
					BackgroundImage = heroPicture,
					BackgroundImageLayout = ImageLayout.Stretch,
					Size = new Size(100, 100),
					SizeMode = PictureBoxSizeMode.StretchImage,
					Margin = new Padding(0),
				};

				pictureBox.Click += PictureBoxOnClick;

				this.panelHeroGrid.Controls.Add( pictureBox );

				_buttonToHeroLookup.Add( pictureBox, (HeroType)hero );
				_heroToButtonLoookup.Add( (HeroType)hero, pictureBox );
			}
		}

		private void PictureBoxOnClick( object sender, EventArgs eventArgs )
		{
			var imgBox = sender as PictureBox;

			if( imgBox == null )
			{
				return;
			}

			// Don't allow for hero reselection
			if( imgBox.Image != null )
			{
				return;
			}

			SubmitAction( _buttonToHeroLookup[ imgBox ] );
		}

		private void OnHeroChosen( HeroType heroType )
		{
			PictureBox selectedImage = null;
			switch( _draftManager.CurrentDraftPhase )
			{
				case DraftData.DraftPhase.FirstBan:
					selectedImage = imgBlueBan;
					imgBlueTeamBanOverlay.Visible = true;
					break;

				case DraftData.DraftPhase.SecondBan:
					selectedImage = imgRedBan;
					imgRedTeamBanOverlay.Visible = true;
					break;

				case DraftData.DraftPhase.BluePick1:
					selectedImage = imgBluePick1;
					break;

				case DraftData.DraftPhase.BluePick2:
					selectedImage = imgBluePick2;
					break;

				case DraftData.DraftPhase.BluePick3:
					selectedImage = imgBluePick3;
					break;

				case DraftData.DraftPhase.RedPick1:
					selectedImage = imgRedPick1;
					break;

				case DraftData.DraftPhase.RedPick2:
					selectedImage = imgRedPick2;
					break;

				case DraftData.DraftPhase.RedPick3:
					selectedImage = imgRedPick3;
					this.btnNextDraft.Visible = true;
					break;

				default:
					return;
			}

			var imgBox = _heroToButtonLoookup[ heroType ];
			imgBox.Image = Properties.Resources.GrayOutOverlay;
			selectedImage.Image = imgBox.BackgroundImage;

			this.lblCurrentPhase.Text = (_draftManager.CurrentDraftPhase + 1).ToString();
		}

		private void SubmitAction( HeroType heroType )
		{
			_draftManager.SubmitDraftAction( heroType );
		}

		private void ResetDraft()
		{
			_draftManager.Reset( _playerTeamColor );

			this.imgBlueBan.Image = Resources.BlankHero;
			this.imgRedBan.Image = Resources.BlankHero;
			
			this.imgBluePick1.Image = Resources.BlankHero;
			this.imgBluePick2.Image = Resources.BlankHero;
			this.imgBluePick3.Image = Resources.BlankHero;
			
			this.imgRedPick1.Image = Resources.BlankHero;
			this.imgRedPick2.Image = Resources.BlankHero;
			this.imgRedPick3.Image = Resources.BlankHero;

			imgBlueTeamBanOverlay.Visible = false;
			imgRedTeamBanOverlay.Visible = false;

			this.lblCurrentPhase.Text = _draftManager.CurrentDraftPhase.ToString();
			this.lblRoundCount.Text = string.Format( "Current Round: {0} / {1}", _draftManager.CurrentRound, _draftManager.RoundCount );

			foreach( var kvp in _heroToButtonLoookup )
			{
				kvp.Value.Image = null;
			}

			this.btnNextDraft.Visible = false;
		}

		private void draftOptionsToolStripMenuItem_Click( object sender, EventArgs e )
		{

		}
	}
}
