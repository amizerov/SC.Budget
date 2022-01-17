namespace SwissClean.MVP.Login
{
    partial class LoginView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.tbLogin = new DevExpress.XtraEditors.TextEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.tbPass = new DevExpress.XtraEditors.TextEdit();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.checkAutoLoginOnStart = new DevExpress.XtraEditors.CheckEdit();
			this.checkRemember = new DevExpress.XtraEditors.CheckEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
			((System.ComponentModel.ISupportInitialize)(this.tbLogin.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbPass.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkAutoLoginOnStart.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkRemember.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(164, 176);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(204, 40);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "Вход";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(167, 53);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(39, 17);
			this.labelControl1.TabIndex = 1;
			this.labelControl1.Text = "Логин:";
			// 
			// tbLogin
			// 
			this.tbLogin.Location = new System.Drawing.Point(252, 50);
			this.tbLogin.Name = "tbLogin";
			this.tbLogin.Size = new System.Drawing.Size(117, 24);
			this.tbLogin.TabIndex = 0;
			this.tbLogin.EditValueChanged += new System.EventHandler(this.TbLogin_EditValueChanged);
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(167, 87);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(49, 17);
			this.labelControl2.TabIndex = 1;
			this.labelControl2.Text = "Пароль:";
			// 
			// tbPass
			// 
			this.tbPass.Location = new System.Drawing.Point(252, 84);
			this.tbPass.Name = "tbPass";
			this.tbPass.Properties.PasswordChar = '*';
			this.tbPass.Size = new System.Drawing.Size(117, 24);
			this.tbPass.TabIndex = 1;
			this.tbPass.EditValueChanged += new System.EventHandler(this.TbPass_EditValueChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(42, 185);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(89, 31);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Отмена";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// checkAutoLoginOnStart
			// 
			this.checkAutoLoginOnStart.Enabled = false;
			this.checkAutoLoginOnStart.Location = new System.Drawing.Point(274, 122);
			this.checkAutoLoginOnStart.Name = "checkAutoLoginOnStart";
			this.checkAutoLoginOnStart.Properties.Caption = "Автовход";
			this.checkAutoLoginOnStart.Size = new System.Drawing.Size(103, 21);
			this.checkAutoLoginOnStart.TabIndex = 22;
			this.checkAutoLoginOnStart.CheckedChanged += new System.EventHandler(this.CheckAutoLoginOnStart_CheckedChanged);
			// 
			// checkRemember
			// 
			this.checkRemember.Location = new System.Drawing.Point(164, 122);
			this.checkRemember.Name = "checkRemember";
			this.checkRemember.Properties.Caption = "Запомнить";
			this.checkRemember.Size = new System.Drawing.Size(103, 21);
			this.checkRemember.TabIndex = 23;
			this.checkRemember.CheckedChanged += new System.EventHandler(this.checkRemember_CheckedChanged);
			// 
			// labelControl3
			// 
			this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
			this.labelControl3.Appearance.Options.UseForeColor = true;
			this.labelControl3.Location = new System.Drawing.Point(169, 19);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(173, 17);
			this.labelControl3.TabIndex = 25;
			this.labelControl3.Text = "Неверные данные для входа";
			this.labelControl3.Visible = false;
			// 
			// pictureEdit1
			// 
			this.pictureEdit1.EditValue = global::SwissClean.Properties.Resources.login;
			this.pictureEdit1.Location = new System.Drawing.Point(14, 16);
			this.pictureEdit1.Name = "pictureEdit1";
			this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
			this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
			this.pictureEdit1.Size = new System.Drawing.Size(117, 130);
			this.pictureEdit1.TabIndex = 24;
			// 
			// LoginView
			// 
			this.AcceptButton = this.btnOk;
			this.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(398, 246);
			this.Controls.Add(this.labelControl3);
			this.Controls.Add(this.pictureEdit1);
			this.Controls.Add(this.checkAutoLoginOnStart);
			this.Controls.Add(this.checkRemember);
			this.Controls.Add(this.tbPass);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.tbLogin);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LoginView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Вход";
			((System.ComponentModel.ISupportInitialize)(this.tbLogin.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbPass.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkAutoLoginOnStart.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkRemember.Properties)).EndInit();
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
        private DevExpress.XtraEditors.CheckEdit checkRemember;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}