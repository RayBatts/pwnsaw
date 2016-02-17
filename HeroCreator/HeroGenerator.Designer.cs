namespace Pwnsaw
{
    partial class HeroGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.boxHeroType = new System.Windows.Forms.ComboBox();
			this.HeroNameLabel = new System.Windows.Forms.Label();
			this.btnGenerateHero = new System.Windows.Forms.Button();
			this.lblRole = new System.Windows.Forms.Label();
			this.boxHeroRole = new System.Windows.Forms.ListBox();
			this.boxBuild = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.boxAttackRange = new System.Windows.Forms.ComboBox();
			this.boxTier = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.combineHeroFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.heroPollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.boxTier)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// boxHeroType
			// 
			this.boxHeroType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.boxHeroType.FormattingEnabled = true;
			this.boxHeroType.Location = new System.Drawing.Point(99, 29);
			this.boxHeroType.Name = "boxHeroType";
			this.boxHeroType.Size = new System.Drawing.Size(121, 21);
			this.boxHeroType.TabIndex = 0;
			// 
			// HeroNameLabel
			// 
			this.HeroNameLabel.AutoSize = true;
			this.HeroNameLabel.Location = new System.Drawing.Point(12, 32);
			this.HeroNameLabel.Name = "HeroNameLabel";
			this.HeroNameLabel.Size = new System.Drawing.Size(57, 13);
			this.HeroNameLabel.TabIndex = 1;
			this.HeroNameLabel.Text = "HeroType:";
			// 
			// btnGenerateHero
			// 
			this.btnGenerateHero.Location = new System.Drawing.Point(198, 155);
			this.btnGenerateHero.Name = "btnGenerateHero";
			this.btnGenerateHero.Size = new System.Drawing.Size(75, 23);
			this.btnGenerateHero.TabIndex = 2;
			this.btnGenerateHero.Text = "Generate!";
			this.btnGenerateHero.UseVisualStyleBackColor = true;
			// 
			// lblRole
			// 
			this.lblRole.AutoSize = true;
			this.lblRole.Location = new System.Drawing.Point(12, 95);
			this.lblRole.Name = "lblRole";
			this.lblRole.Size = new System.Drawing.Size(32, 13);
			this.lblRole.TabIndex = 3;
			this.lblRole.Text = "Role:";
			// 
			// boxHeroRole
			// 
			this.boxHeroRole.FormattingEnabled = true;
			this.boxHeroRole.Location = new System.Drawing.Point(100, 83);
			this.boxHeroRole.Name = "boxHeroRole";
			this.boxHeroRole.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.boxHeroRole.Size = new System.Drawing.Size(120, 43);
			this.boxHeroRole.TabIndex = 4;
			// 
			// boxBuild
			// 
			this.boxBuild.FormattingEnabled = true;
			this.boxBuild.Location = new System.Drawing.Point(332, 34);
			this.boxBuild.Name = "boxBuild";
			this.boxBuild.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.boxBuild.Size = new System.Drawing.Size(120, 43);
			this.boxBuild.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(245, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Build:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Attack Range:";
			// 
			// boxAttackRange
			// 
			this.boxAttackRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.boxAttackRange.FormattingEnabled = true;
			this.boxAttackRange.Location = new System.Drawing.Point(98, 56);
			this.boxAttackRange.Name = "boxAttackRange";
			this.boxAttackRange.Size = new System.Drawing.Size(121, 21);
			this.boxAttackRange.TabIndex = 7;
			// 
			// boxTier
			// 
			this.boxTier.Location = new System.Drawing.Point(333, 85);
			this.boxTier.Name = "boxTier";
			this.boxTier.Size = new System.Drawing.Size(120, 20);
			this.boxTier.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(245, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Tier:";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(464, 24);
			this.menuStrip1.TabIndex = 11;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.combineHeroFilesToolStripMenuItem,
            this.heroPollToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// combineHeroFilesToolStripMenuItem
			// 
			this.combineHeroFilesToolStripMenuItem.Name = "combineHeroFilesToolStripMenuItem";
			this.combineHeroFilesToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.combineHeroFilesToolStripMenuItem.Text = "Combine Hero Files";
			// 
			// heroPollToolStripMenuItem
			// 
			this.heroPollToolStripMenuItem.Name = "heroPollToolStripMenuItem";
			this.heroPollToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.heroPollToolStripMenuItem.Text = "Hero Poll";
			this.heroPollToolStripMenuItem.Click += new System.EventHandler(this.heroPollToolStripMenuItem_Click);
			// 
			// HeroGenerator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(464, 204);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.boxTier);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.boxAttackRange);
			this.Controls.Add(this.boxBuild);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.boxHeroRole);
			this.Controls.Add(this.lblRole);
			this.Controls.Add(this.btnGenerateHero);
			this.Controls.Add(this.HeroNameLabel);
			this.Controls.Add(this.boxHeroType);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "HeroGenerator";
			this.Text = "Hero Generator";
			((System.ComponentModel.ISupportInitialize)(this.boxTier)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox boxHeroType;
        private System.Windows.Forms.Label HeroNameLabel;
        private System.Windows.Forms.Button btnGenerateHero;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ListBox boxHeroRole;
        private System.Windows.Forms.ListBox boxBuild;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox boxAttackRange;
        private System.Windows.Forms.NumericUpDown boxTier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combineHeroFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem heroPollToolStripMenuItem;
    }
}

