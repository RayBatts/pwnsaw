using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Pwnsaw;

namespace HeroCreator
{
	public partial class TierRankings : Form
	{
		[System.Runtime.InteropServices.DllImport( "user32.dll" )]
		extern static bool DestroyIcon( IntPtr handle );

		private readonly Dictionary< PictureBox, HeroType > _pictureboxHeroTypeLookup = new Dictionary< PictureBox, HeroType >();

		private PictureBox _selectedPictureBox = null;

		public readonly List< HeroType > _heroRankings = new List< HeroType >(); 

		public TierRankings()
		{
			InitializeComponent();
			InitializeForm();

			this.heroTierListings.AllowDrop = true;

			this.FormClosing += SetTierRankings;
			this.btnFinish.Click += ( o, e ) => this.Close();
		}

		void SetTierRankings( object sender, FormClosingEventArgs e )
		{
			var numEntries = _pictureboxHeroTypeLookup.Values.Count;

			for( var x = 0; x < numEntries; x++)
			{
				_heroRankings.Add( HeroType.Adagio );
			}

			foreach( var ctrl in this.heroTierListings.Controls  )
			{
				var heroPicture = ctrl as PictureBox;
				if( heroPicture == null )
				{
					continue;
				}

				// insert it in the correct index.
				var index = heroTierListings.Controls.GetChildIndex( heroPicture );
				_heroRankings[ index ] = _pictureboxHeroTypeLookup[ heroPicture ];
			}
		}

		private void InitializeForm()
		{
			var heroes = Enum.GetValues( typeof( HeroType ) );

			foreach( var hType in heroes )
			{
				var heroType = (HeroType)hType;
				var curHeroImage = (Bitmap)Properties.Resources.ResourceManager.GetObject( heroType.ToString().ToLower() );

				var heroPictureBox = HeroCreatorUtils.CreatePictureBoxFromImage( curHeroImage, 75 );
				heroPictureBox.MouseDown += OnHeroMouseDown;

				this.heroTierListings.Controls.Add( heroPictureBox );

				_pictureboxHeroTypeLookup.Add( heroPictureBox, heroType );
			}

			heroTierListings.DragDrop += OnPictureBoxDragDrop;
			heroTierListings.GiveFeedback += OnGivePictureBoxFeedback;
			heroTierListings.DragEnter += OnPictureBoxDragEnter;
			heroTierListings.DragOver += OnHeroListingsDrag;
		}

		private void OnHeroListingsDrag( object sender, DragEventArgs e )
		{
			if( _selectedPictureBox == null )
			{
				return;
			}

			var clientPos = heroTierListings.PointToClient( new Point( e.X, e.Y ) );
			var ctrl = heroTierListings.GetChildAtPoint( clientPos );
			if( ctrl != null )
			{
				var childIndex = heroTierListings.Controls.GetChildIndex( ctrl );
				this.heroTierListings.Controls.SetChildIndex( _selectedPictureBox, childIndex );
			}
		}

		private void OnGivePictureBoxFeedback( object sender, GiveFeedbackEventArgs e )
		{
			e.UseDefaultCursors = false;
		}

		private void OnPictureBoxDragEnter( object sender, DragEventArgs e )
		{
			if( e.Data.GetDataPresent( typeof( Bitmap ) ) ) e.Effect = DragDropEffects.Scroll;
		}

		private void OnPictureBoxDragDrop( object sender, DragEventArgs e )
		{
			_selectedPictureBox = null;
		}

		private void OnHeroMouseDown( object sender, MouseEventArgs e )
		{
			if( e.Button != MouseButtons.Left )
			{
				return;
			}

			_selectedPictureBox = sender as PictureBox;
			if( _selectedPictureBox == null )
			{
				return;
			}

			var dragImage = (Bitmap)_selectedPictureBox.Image;
			
			var icon = dragImage.GetHicon();

			Cursor.Current = new Cursor( icon );
			heroTierListings.DoDragDrop( _selectedPictureBox.Image, DragDropEffects.Scroll );


			DestroyIcon( icon );
		}
	}
}
