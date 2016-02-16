using System.Windows.Forms;
using Pwnsaw.Draft;

namespace HeroCreator
{
	public partial class DraftOptions : Form
	{
		private DraftBot _draftBot;
		public DraftOptions( DraftBot draftBot )
		{
			_draftBot = draftBot;

			this.Closed += OnOnFormClosed;
			InitializeComponent();
		}

		void OnOnFormClosed( object sender, System.EventArgs e )
		{
			var teamColor = this.radioBtnBlueTeam.Checked ? TeamColor.Blue : TeamColor.Red;
			_draftBot.SetOptions( teamColor, (int)this.numRoundsControl.Value );
		}
	}
}
