
using System.Drawing;
using System.Windows.Forms;

namespace Pwnsaw
{
	public static class HeroCreatorUtils
	{
		public static PictureBox CreatePictureBoxFromImage( Image heroImage, int pictureSize = 25 )
		{
			return new PictureBox()
			{
				Image = heroImage,
				Size = new Size( pictureSize, pictureSize ),
				SizeMode = PictureBoxSizeMode.StretchImage
			};
		}
	}
}
