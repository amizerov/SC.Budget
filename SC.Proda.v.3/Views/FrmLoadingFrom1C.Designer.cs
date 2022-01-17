namespace SC.Proda.Views
{
    partial class FrmLoadingFrom1C
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoadingFrom1C));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lbProgress = new DevExpress.XtraEditors.LabelControl();
			this.progressBarControl = new DevExpress.XtraEditors.MarqueeProgressBarControl();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Image = global::SC.Proda.Properties.Resources.giphy_3;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(500, 185);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// lbProgress
			// 
			this.lbProgress.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.lbProgress.Appearance.Options.UseBackColor = true;
			this.lbProgress.AppearanceHovered.BackColor = System.Drawing.Color.Transparent;
			this.lbProgress.AppearanceHovered.Options.UseBackColor = true;
			this.lbProgress.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lbProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lbProgress.Location = new System.Drawing.Point(0, 200);
			this.lbProgress.Name = "lbProgress";
			this.lbProgress.Padding = new System.Windows.Forms.Padding(5);
			this.lbProgress.Size = new System.Drawing.Size(500, 50);
			this.lbProgress.TabIndex = 1;
			this.lbProgress.Text = "Идет загрузка";
			// 
			// progressBarControl
			// 
			this.progressBarControl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.progressBarControl.EditValue = 50;
			this.progressBarControl.Location = new System.Drawing.Point(0, 185);
			this.progressBarControl.Name = "progressBarControl";
			this.progressBarControl.Properties.LookAndFeel.SkinName = "Office 2016 Colorful";
			this.progressBarControl.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.progressBarControl.Size = new System.Drawing.Size(500, 15);
			this.progressBarControl.TabIndex = 2;
			// 
			// FrmLoadingFrom1C
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(500, 250);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.progressBarControl);
			this.Controls.Add(this.lbProgress);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmLoadingFrom1C";
			this.Text = "FrmLoadingFrom1C";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
		private DevExpress.XtraEditors.LabelControl lbProgress;
		private DevExpress.XtraEditors.MarqueeProgressBarControl progressBarControl;
	}
}