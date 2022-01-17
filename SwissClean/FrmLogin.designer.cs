namespace SwissClean
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
            this.cbAutoLoginOnStart = new DevExpress.XtraEditors.CheckEdit();
            this.cbSaveLoginAndPass = new DevExpress.XtraEditors.CheckEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tbLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAutoLoginOnStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSaveLoginAndPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(141, 134);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(175, 30);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Вход";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(143, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Логин:";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(216, 38);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(100, 20);
            this.tbLogin.TabIndex = 0;
            this.tbLogin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbLogin_KeyUp);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(143, 67);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Пароль:";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(216, 64);
            this.tbPass.Name = "tbPass";
            this.tbPass.Properties.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(100, 20);
            this.tbPass.TabIndex = 1;
            this.tbPass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbPass_KeyUp);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(36, 141);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbAutoLoginOnStart
            // 
            this.cbAutoLoginOnStart.Location = new System.Drawing.Point(235, 94);
            this.cbAutoLoginOnStart.Name = "cbAutoLoginOnStart";
            this.cbAutoLoginOnStart.Properties.Caption = "Автовход";
            this.cbAutoLoginOnStart.Size = new System.Drawing.Size(88, 19);
            this.cbAutoLoginOnStart.TabIndex = 22;
            // 
            // cbSaveLoginAndPass
            // 
            this.cbSaveLoginAndPass.Location = new System.Drawing.Point(141, 94);
            this.cbSaveLoginAndPass.Name = "cbSaveLoginAndPass";
            this.cbSaveLoginAndPass.Properties.Caption = "Запомнить";
            this.cbSaveLoginAndPass.Size = new System.Drawing.Size(88, 19);
            this.cbSaveLoginAndPass.TabIndex = 23;
            this.cbSaveLoginAndPass.CheckedChanged += new System.EventHandler(this.cbSaveLoginAndPass_CheckedChanged);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::SwissClean.Properties.Resources.login2;
            this.pictureEdit1.Location = new System.Drawing.Point(12, 12);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(100, 96);
            this.pictureEdit1.TabIndex = 24;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(145, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(149, 13);
            this.labelControl3.TabIndex = 25;
            this.labelControl3.Text = "Неверные данные для входа";
            this.labelControl3.Visible = false;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 188);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.cbAutoLoginOnStart);
            this.Controls.Add(this.cbSaveLoginAndPass);
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
            this.Name = "FrmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAutoLoginOnStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSaveLoginAndPass.Properties)).EndInit();
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
        private DevExpress.XtraEditors.CheckEdit cbAutoLoginOnStart;
        private DevExpress.XtraEditors.CheckEdit cbSaveLoginAndPass;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}