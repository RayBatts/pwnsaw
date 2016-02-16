namespace HeroCreator
{
	partial class DraftBot
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DraftBot));
			this.panelHeroGrid = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetDraftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.draftOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.utilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.heroPollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.heroGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lblCurrentPhase = new System.Windows.Forms.Label();
			this.lblRoundCount = new System.Windows.Forms.Label();
			this.imgRedTeamBanOverlay = new System.Windows.Forms.PictureBox();
			this.imgBlueTeamBanOverlay = new System.Windows.Forms.PictureBox();
			this.imgRedPick1 = new System.Windows.Forms.PictureBox();
			this.imgRedPick2 = new System.Windows.Forms.PictureBox();
			this.imgRedPick3 = new System.Windows.Forms.PictureBox();
			this.imgBluePick2 = new System.Windows.Forms.PictureBox();
			this.imgBluePick3 = new System.Windows.Forms.PictureBox();
			this.imgBluePick1 = new System.Windows.Forms.PictureBox();
			this.imgRedBan = new System.Windows.Forms.PictureBox();
			this.imgBlueBan = new System.Windows.Forms.PictureBox();
			this.btnNextDraft = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgRedTeamBanOverlay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgBlueTeamBanOverlay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgRedPick1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgRedPick2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgRedPick3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgBluePick2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgBluePick3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgBluePick1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgRedBan)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgBlueBan)).BeginInit();
			this.SuspendLayout();
			// 
			// panelHeroGrid
			// 
			this.panelHeroGrid.Location = new System.Drawing.Point(137, 186);
			this.panelHeroGrid.Name = "panelHeroGrid";
			this.panelHeroGrid.Size = new System.Drawing.Size(500, 500);
			this.panelHeroGrid.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(33, 85);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Blue Team";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(678, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Red Team";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(333, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Current Phase:";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.utilToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(772, 24);
			this.menuStrip1.TabIndex = 12;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetDraftToolStripMenuItem,
            this.draftOptionsToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// resetDraftToolStripMenuItem
			// 
			this.resetDraftToolStripMenuItem.Name = "resetDraftToolStripMenuItem";
			this.resetDraftToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
			this.resetDraftToolStripMenuItem.Text = "Restart Draft";
			// 
			// draftOptionsToolStripMenuItem
			// 
			this.draftOptionsToolStripMenuItem.Name = "draftOptionsToolStripMenuItem";
			this.draftOptionsToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
			this.draftOptionsToolStripMenuItem.Text = "Draft Options";
			// 
			// utilToolStripMenuItem
			// 
			this.utilToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heroPollToolStripMenuItem,
            this.heroGeneratorToolStripMenuItem});
			this.utilToolStripMenuItem.Name = "utilToolStripMenuItem";
			this.utilToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.utilToolStripMenuItem.Text = "Util";
			// 
			// heroPollToolStripMenuItem
			// 
			this.heroPollToolStripMenuItem.Name = "heroPollToolStripMenuItem";
			this.heroPollToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.heroPollToolStripMenuItem.Text = "Hero Poll";
			// 
			// heroGeneratorToolStripMenuItem
			// 
			this.heroGeneratorToolStripMenuItem.Name = "heroGeneratorToolStripMenuItem";
			this.heroGeneratorToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.heroGeneratorToolStripMenuItem.Text = "Hero Generator";
			// 
			// lblCurrentPhase
			// 
			this.lblCurrentPhase.AutoSize = true;
			this.lblCurrentPhase.Location = new System.Drawing.Point(416, 67);
			this.lblCurrentPhase.Name = "lblCurrentPhase";
			this.lblCurrentPhase.Size = new System.Drawing.Size(35, 13);
			this.lblCurrentPhase.TabIndex = 15;
			this.lblCurrentPhase.Text = "label4";
			// 
			// lblRoundCount
			// 
			this.lblRoundCount.AutoSize = true;
			this.lblRoundCount.Location = new System.Drawing.Point(359, 85);
			this.lblRoundCount.Name = "lblRoundCount";
			this.lblRoundCount.Size = new System.Drawing.Size(68, 13);
			this.lblRoundCount.TabIndex = 16;
			this.lblRoundCount.Text = "Round: 1 / 5";
			// 
			// imgRedTeamBanOverlay
			// 
			this.imgRedTeamBanOverlay.BackColor = System.Drawing.Color.Transparent;
			this.imgRedTeamBanOverlay.Image = global::HeroCreator.Properties.Resources.redTeamban;
			this.imgRedTeamBanOverlay.Location = new System.Drawing.Point(671, 141);
			this.imgRedTeamBanOverlay.Name = "imgRedTeamBanOverlay";
			this.imgRedTeamBanOverlay.Size = new System.Drawing.Size(75, 75);
			this.imgRedTeamBanOverlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgRedTeamBanOverlay.TabIndex = 14;
			this.imgRedTeamBanOverlay.TabStop = false;
			// 
			// imgBlueTeamBanOverlay
			// 
			this.imgBlueTeamBanOverlay.BackColor = System.Drawing.Color.Transparent;
			this.imgBlueTeamBanOverlay.Image = global::HeroCreator.Properties.Resources.blueTeamBan;
			this.imgBlueTeamBanOverlay.Location = new System.Drawing.Point(26, 132);
			this.imgBlueTeamBanOverlay.Name = "imgBlueTeamBanOverlay";
			this.imgBlueTeamBanOverlay.Size = new System.Drawing.Size(75, 75);
			this.imgBlueTeamBanOverlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgBlueTeamBanOverlay.TabIndex = 13;
			this.imgBlueTeamBanOverlay.TabStop = false;
			// 
			// imgRedPick1
			// 
			this.imgRedPick1.Image = ((System.Drawing.Image)(resources.GetObject("imgRedPick1.Image")));
			this.imgRedPick1.Location = new System.Drawing.Point(660, 222);
			this.imgRedPick1.Name = "imgRedPick1";
			this.imgRedPick1.Size = new System.Drawing.Size(100, 100);
			this.imgRedPick1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgRedPick1.TabIndex = 10;
			this.imgRedPick1.TabStop = false;
			// 
			// imgRedPick2
			// 
			this.imgRedPick2.Image = ((System.Drawing.Image)(resources.GetObject("imgRedPick2.Image")));
			this.imgRedPick2.Location = new System.Drawing.Point(660, 328);
			this.imgRedPick2.Name = "imgRedPick2";
			this.imgRedPick2.Size = new System.Drawing.Size(100, 100);
			this.imgRedPick2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgRedPick2.TabIndex = 9;
			this.imgRedPick2.TabStop = false;
			// 
			// imgRedPick3
			// 
			this.imgRedPick3.Image = ((System.Drawing.Image)(resources.GetObject("imgRedPick3.Image")));
			this.imgRedPick3.Location = new System.Drawing.Point(660, 434);
			this.imgRedPick3.Name = "imgRedPick3";
			this.imgRedPick3.Size = new System.Drawing.Size(100, 100);
			this.imgRedPick3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgRedPick3.TabIndex = 8;
			this.imgRedPick3.TabStop = false;
			// 
			// imgBluePick2
			// 
			this.imgBluePick2.Image = ((System.Drawing.Image)(resources.GetObject("imgBluePick2.Image")));
			this.imgBluePick2.Location = new System.Drawing.Point(12, 328);
			this.imgBluePick2.Name = "imgBluePick2";
			this.imgBluePick2.Size = new System.Drawing.Size(100, 100);
			this.imgBluePick2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgBluePick2.TabIndex = 7;
			this.imgBluePick2.TabStop = false;
			// 
			// imgBluePick3
			// 
			this.imgBluePick3.Image = ((System.Drawing.Image)(resources.GetObject("imgBluePick3.Image")));
			this.imgBluePick3.Location = new System.Drawing.Point(12, 434);
			this.imgBluePick3.Name = "imgBluePick3";
			this.imgBluePick3.Size = new System.Drawing.Size(100, 100);
			this.imgBluePick3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgBluePick3.TabIndex = 6;
			this.imgBluePick3.TabStop = false;
			// 
			// imgBluePick1
			// 
			this.imgBluePick1.Image = ((System.Drawing.Image)(resources.GetObject("imgBluePick1.Image")));
			this.imgBluePick1.Location = new System.Drawing.Point(12, 222);
			this.imgBluePick1.Name = "imgBluePick1";
			this.imgBluePick1.Size = new System.Drawing.Size(100, 100);
			this.imgBluePick1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgBluePick1.TabIndex = 5;
			this.imgBluePick1.TabStop = false;
			// 
			// imgRedBan
			// 
			this.imgRedBan.Image = ((System.Drawing.Image)(resources.GetObject("imgRedBan.Image")));
			this.imgRedBan.Location = new System.Drawing.Point(671, 141);
			this.imgRedBan.Name = "imgRedBan";
			this.imgRedBan.Size = new System.Drawing.Size(75, 75);
			this.imgRedBan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgRedBan.TabIndex = 2;
			this.imgRedBan.TabStop = false;
			// 
			// imgBlueBan
			// 
			this.imgBlueBan.Image = global::HeroCreator.Properties.Resources.BlankHero;
			this.imgBlueBan.Location = new System.Drawing.Point(26, 132);
			this.imgBlueBan.Name = "imgBlueBan";
			this.imgBlueBan.Size = new System.Drawing.Size(75, 75);
			this.imgBlueBan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgBlueBan.TabIndex = 1;
			this.imgBlueBan.TabStop = false;
			// 
			// btnNextDraft
			// 
			this.btnNextDraft.Location = new System.Drawing.Point(671, 663);
			this.btnNextDraft.Name = "btnNextDraft";
			this.btnNextDraft.Size = new System.Drawing.Size(75, 23);
			this.btnNextDraft.TabIndex = 17;
			this.btnNextDraft.Text = "Next Draft";
			this.btnNextDraft.UseVisualStyleBackColor = true;
			this.btnNextDraft.Visible = false;
			// 
			// DraftBot
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(772, 713);
			this.Controls.Add(this.btnNextDraft);
			this.Controls.Add(this.lblRoundCount);
			this.Controls.Add(this.lblCurrentPhase);
			this.Controls.Add(this.imgRedTeamBanOverlay);
			this.Controls.Add(this.imgBlueTeamBanOverlay);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.imgRedPick1);
			this.Controls.Add(this.imgRedPick2);
			this.Controls.Add(this.imgRedPick3);
			this.Controls.Add(this.imgBluePick2);
			this.Controls.Add(this.imgBluePick3);
			this.Controls.Add(this.imgBluePick1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.imgRedBan);
			this.Controls.Add(this.imgBlueBan);
			this.Controls.Add(this.panelHeroGrid);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "DraftBot";
			this.Text = "Pwnsaw - v 0.5";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgRedTeamBanOverlay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgBlueTeamBanOverlay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgRedPick1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgRedPick2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgRedPick3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgBluePick2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgBluePick3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgBluePick1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgRedBan)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgBlueBan)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel panelHeroGrid;
		private System.Windows.Forms.PictureBox imgBlueBan;
		private System.Windows.Forms.PictureBox imgRedBan;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox imgBluePick1;
		private System.Windows.Forms.PictureBox imgBluePick3;
		private System.Windows.Forms.PictureBox imgBluePick2;
		private System.Windows.Forms.PictureBox imgRedPick3;
		private System.Windows.Forms.PictureBox imgRedPick2;
		private System.Windows.Forms.PictureBox imgRedPick1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetDraftToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem draftOptionsToolStripMenuItem;
		private System.Windows.Forms.PictureBox imgBlueTeamBanOverlay;
		private System.Windows.Forms.PictureBox imgRedTeamBanOverlay;
		private System.Windows.Forms.Label lblCurrentPhase;
		private System.Windows.Forms.Label lblRoundCount;
		private System.Windows.Forms.Button btnNextDraft;
		private System.Windows.Forms.ToolStripMenuItem utilToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem heroPollToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem heroGeneratorToolStripMenuItem;
	}
}