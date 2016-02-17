using System.Windows.Forms;
using PwnsawLib.Draft;

namespace Pwnsaw
{
	public partial class DraftOptions : Form
	{
		private DraftBot _draftBot;
		public DraftOptions( DraftBot draftBot )
		{
			InitializeComponent();

			_draftBot = draftBot;

			this.Closed += OnOnFormClosed;
			this.btnConfirmOptions.Click += OnOkButtonClicked;
		}

		private void OnOkButtonClicked( object sender, System.EventArgs e )
		{
			this.Close();
		}

		void OnOnFormClosed( object sender, System.EventArgs e )
		{
			var teamColor = this.radioBtnBlueTeam.Checked ? TeamColor.Blue : TeamColor.Red;
			_draftBot.SetOptions( teamColor, (int)this.numRoundsControl.Value, this.chkEnableAI.Checked );
		}
	}
}
