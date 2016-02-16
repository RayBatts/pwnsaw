namespace HeroCreator
{
	partial class TierRankings
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
			this.btnFinish = new System.Windows.Forms.Button();
			this.heroTierListings = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// btnFinish
			// 
			this.btnFinish.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnFinish.Location = new System.Drawing.Point(358, 425);
			this.btnFinish.Name = "btnFinish";
			this.btnFinish.Size = new System.Drawing.Size(75, 23);
			this.btnFinish.TabIndex = 0;
			this.btnFinish.Text = "OK";
			this.btnFinish.UseVisualStyleBackColor = true;
			// 
			// heroTierListings
			// 
			this.heroTierListings.Location = new System.Drawing.Point(12, 69);
			this.heroTierListings.Name = "heroTierListings";
			this.heroTierListings.Size = new System.Drawing.Size(784, 350);
			this.heroTierListings.TabIndex = 1;
			// 
			// TierRankings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(808, 460);
			this.Controls.Add(this.heroTierListings);
			this.Controls.Add(this.btnFinish);
			this.Name = "TierRankings";
			this.Text = "TierRankings";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnFinish;
		private System.Windows.Forms.FlowLayoutPanel heroTierListings;
	}
}