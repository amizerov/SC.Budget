namespace SC.Common.Views
{
    partial class WaitForm0
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitForm0));
			this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// progressPanel1
			// 
			this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.progressPanel1.Appearance.Options.UseBackColor = true;
			this.progressPanel1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.progressPanel1.AppearanceCaption.Options.UseFont = true;
			this.progressPanel1.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.progressPanel1.AppearanceDescription.Options.UseFont = true;
			this.progressPanel1.BarAnimationElementThickness = 2;
			this.progressPanel1.Caption = "Идёт загрузка";
			this.progressPanel1.ImageHorzOffset = 20;
			this.progressPanel1.Location = new System.Drawing.Point(166, 532);
			this.progressPanel1.LookAndFeel.SkinName = "The Bezier";
			this.progressPanel1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.progressPanel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.progressPanel1.Name = "progressPanel1";
			this.progressPanel1.ShowDescription = false;
			this.progressPanel1.Size = new System.Drawing.Size(181, 52);
			this.progressPanel1.TabIndex = 1;
			this.progressPanel1.Text = "Пожа";
			this.progressPanel1.UseWaitCursor = true;
			// 
			// panel1
			// 
			this.panel1.BackgroundImage = global::SC.Common.Properties.Resources.SCAS_DemoCover1;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.progressPanel1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(693, 578);
			this.panel1.TabIndex = 3;
			this.panel1.UseWaitCursor = true;
			// 
			// WaitForm0
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(693, 578);
			this.Controls.Add(this.panel1);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "WaitForm0";
			this.ShowIcon = false;
			this.ShowOnTopMode = DevExpress.XtraWaitForm.ShowFormOnTopMode.AboveParent;
			this.Text = "Form1";
			this.UseWaitCursor = true;
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
		private System.Windows.Forms.Panel panel1;
	}
}
