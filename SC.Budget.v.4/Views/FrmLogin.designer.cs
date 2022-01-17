namespace SC.Budget.Views
{
    partial class FrmLogin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.tbLogin = new DevExpress.XtraEditors.TextEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.tbPass = new DevExpress.XtraEditors.TextEdit();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.checkAutoLoginOnStart = new DevExpress.XtraEditors.CheckEdit();
			this.checkRememberLogin = new DevExpress.XtraEditors.CheckEdit();
			this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
			((System.ComponentModel.ISupportInitialize)(this.tbLogin.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbPass.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkAutoLoginOnStart.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkRememberLogin.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(240, 174);
			this.btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(162, 35);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "Вход";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(168, 40);
			this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(46, 20);
			this.labelControl1.TabIndex = 1;
			this.labelControl1.Text = "Логин:";
			// 
			// tbLogin
			// 
			this.tbLogin.Location = new System.Drawing.Point(240, 35);
			this.tbLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tbLogin.Name = "tbLogin";
			this.tbLogin.Size = new System.Drawing.Size(158, 26);
			this.tbLogin.TabIndex = 0;
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(168, 80);
			this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(56, 20);
			this.labelControl2.TabIndex = 1;
			this.labelControl2.Text = "Пароль:";
			// 
			// tbPass
			// 
			this.tbPass.Location = new System.Drawing.Point(240, 75);
			this.tbPass.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tbPass.Name = "tbPass";
			this.tbPass.Properties.PasswordChar = '*';
			this.tbPass.Size = new System.Drawing.Size(158, 26);
			this.tbPass.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(144, 174);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 25);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Отмена";
			// 
			// checkAutoLoginOnStart
			// 
			this.checkAutoLoginOnStart.Enabled = false;
			this.checkAutoLoginOnStart.Location = new System.Drawing.Point(290, 120);
			this.checkAutoLoginOnStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.checkAutoLoginOnStart.Name = "checkAutoLoginOnStart";
			this.checkAutoLoginOnStart.Properties.Caption = "Автовход";
			this.checkAutoLoginOnStart.Size = new System.Drawing.Size(118, 24);
			this.checkAutoLoginOnStart.TabIndex = 22;
			// 
			// checkRememberLogin
			// 
			this.checkRememberLogin.Location = new System.Drawing.Point(166, 120);
			this.checkRememberLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.checkRememberLogin.Name = "checkRememberLogin";
			this.checkRememberLogin.Properties.Caption = "Запомнить";
			this.checkRememberLogin.Size = new System.Drawing.Size(118, 24);
			this.checkRememberLogin.TabIndex = 23;
			this.checkRememberLogin.CheckedChanged += new System.EventHandler(this.checkRememberLogin_CheckedChanged);
			// 
			// pictureEdit1
			// 
			this.pictureEdit1.EditValue = global::SC.Budget.Properties.Resources.login;
			this.pictureEdit1.Location = new System.Drawing.Point(13, 12);
			this.pictureEdit1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pictureEdit1.Name = "pictureEdit1";
			this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
			this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
			this.pictureEdit1.Size = new System.Drawing.Size(120, 120);
			this.pictureEdit1.TabIndex = 24;
			// 
			// FrmLogin
			// 
			this.AcceptButton = this.btnOk;
			this.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(424, 231);
			this.Controls.Add(this.pictureEdit1);
			this.Controls.Add(this.checkAutoLoginOnStart);
			this.Controls.Add(this.checkRememberLogin);
			this.Controls.Add(this.tbPass);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.tbLogin);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Вход";
			((System.ComponentModel.ISupportInitialize)(this.tbLogin.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbPass.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkAutoLoginOnStart.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkRememberLogin.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit tbLogin;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit tbPass;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.CheckEdit checkAutoLoginOnStart;
        private DevExpress.XtraEditors.CheckEdit checkRememberLogin;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}