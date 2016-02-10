using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Pwnsaw;

namespace HeroCreator
{
	public partial class HeroPoll : Form
	{
		public HeroPoll()
		{
			InitializeComponent();
			InitializeForm();
		}

		private void InitializeForm()
		{
			var heroes = Enum.GetValues( typeof( HeroType ) );
			var numheroes = heroes.Length;

			var assembly = Assembly.GetExecutingAssembly();
			var blankHeroImage = Properties.Resources.BlankHero;

			var numCols =  this.threatMatrixPanel.ColumnCount;

			for( var x = 1; x < numheroes; x++ )
			{
				var curHero = (HeroType) x - 1;
				var curHeroImage = (Bitmap)Properties.Resources.ResourceManager.GetObject( curHero.ToString().ToLower() );

				this.threatMatrixPanel.Controls.Add( CreatePictureBoxFromImage( curHeroImage ), 0, x );

				var radioButtonsGroup = new FlowLayoutPanel()
				{
					FlowDirection = FlowDirection.LeftToRight,
					Size = new Size( 105 * 5, 25 ),
					WrapContents = false
				};

				for( var y = 0; y < 5; y++ )
				{
					var rb = new RadioButton();
					radioButtonsGroup.Controls.Add( rb );		
				}

				this.threatMatrixPanel.Controls.Add( radioButtonsGroup, 1, x );
			}
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
