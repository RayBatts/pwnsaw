namespace Pwnsaw
{
	partial class DraftOptions
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioBtnBlueTeam = new System.Windows.Forms.RadioButton();
			this.btnConfirmOptions = new System.Windows.Forms.Button();
			this.numRoundsControl = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnLocalCacheData = new System.Windows.Forms.RadioButton();
			this.btnOnlineData = new System.Windows.Forms.RadioButton();
			this.chkEnableAI = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRoundsControl)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioBtnBlueTeam);
			this.groupBox1.Location = new System.Drawing.Point(28, 11);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(145, 70);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Starting Team:";
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(6, 42);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(127, 17);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "Red Team (First Pick)";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioBtnBlueTeam
			// 
			this.radioBtnBlueTeam.AutoSize = true;
			this.radioBtnBlueTeam.Checked = true;
			this.radioBtnBlueTeam.Location = new System.Drawing.Point(6, 19);
			this.radioBtnBlueTeam.Name = "radioBtnBlueTeam";
			this.radioBtnBlueTeam.Size = new System.Drawing.Size(126, 17);
			this.radioBtnBlueTeam.TabIndex = 0;
			this.radioBtnBlueTeam.TabStop = true;
			this.radioBtnBlueTeam.Text = "Blue Team (First Ban)";
			this.radioBtnBlueTeam.UseVisualStyleBackColor = true;
			// 
			// btnConfirmOptions
			// 
			this.btnConfirmOptions.Location = new System.Drawing.Point(65, 261);
			this.btnConfirmOptions.Name = "btnConfirmOptions";
			this.btnConfirmOptions.Size = new System.Drawing.Size(59, 22);
			this.btnConfirmOptions.TabIndex = 1;
			this.btnConfirmOptions.Text = "OK";
			this.btnConfirmOptions.UseVisualStyleBackColor = true;
			// 
			// numRoundsControl
			// 
			this.numRoundsControl.Location = new System.Drawing.Point(49, 203);
			this.numRoundsControl.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numRoundsControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numRoundsControl.Name = "numRoundsControl";
			this.numRoundsControl.Size = new System.Drawing.Size(96, 20);
			this.numRoundsControl.TabIndex = 2;
			this.numRoundsControl.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(46, 187);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(99, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Number of Rounds:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnLocalCacheData);
			this.groupBox2.Controls.Add(this.btnOnlineData);
			this.groupBox2.Location = new System.Drawing.Point(33, 103);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(139, 69);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Data Type";
			// 
			// btnLocalCacheData
			// 
			this.btnLocalCacheData.AutoSize = true;
			this.btnLocalCacheData.Location = new System.Drawing.Point(6, 42);
			this.btnLocalCacheData.Name = "btnLocalCacheData";
			this.btnLocalCacheData.Size = new System.Drawing.Size(99, 17);
			this.btnLocalCacheData.TabIndex = 1;
			this.btnLocalCacheData.Text = "Use Local Data";
			this.btnLocalCacheData.UseVisualStyleBackColor = true;
			// 
			// btnOnlineData
			// 
			this.btnOnlineData.AutoSize = true;
			this.btnOnlineData.Checked = true;
			this.btnOnlineData.Location = new System.Drawing.Point(6, 19);
			this.btnOnlineData.Name = "btnOnlineData";
			this.btnOnlineData.Size = new System.Drawing.Size(103, 17);
			this.btnOnlineData.TabIndex = 0;
			this.btnOnlineData.TabStop = true;
			this.btnOnlineData.Text = "Use Online Data";
			this.btnOnlineData.UseVisualStyleBackColor = true;
			// 
			// chkEnableAI
			// 
			this.chkEnableAI.AutoSize = true;
			this.chkEnableAI.Checked = true;
			this.chkEnableAI.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEnableAI.Location = new System.Drawing.Point(65, 238);
			this.chkEnableAI.Name = "chkEnableAI";
			this.chkEnableAI.Size = new System.Drawing.Size(72, 17);
			this.chkEnableAI.TabIndex = 5;
			this.chkEnableAI.Text = "Enable AI";
			this.chkEnableAI.UseVisualStyleBackColor = true;
			// 
			// DraftOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(204, 293);
			this.Controls.Add(this.chkEnableAI);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numRoundsControl);
			this.Controls.Add(this.btnConfirmOptions);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "DraftOptions";
			this.Text = "DraftOptions";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRoundsControl)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioBtnBlueTeam;
		private System.Windows.Forms.Button btnConfirmOptions;
		private System.Windows.Forms.NumericUpDown numRoundsControl;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton btnLocalCacheData;
		private System.Windows.Forms.RadioButton btnOnlineData;
		private System.Windows.Forms.CheckBox chkEnableAI;
	}
}