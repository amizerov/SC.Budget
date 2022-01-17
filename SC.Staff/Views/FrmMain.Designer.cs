namespace SC.Staff.Views
{
	partial class FrmMain
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
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.btResetSettings = new DevExpress.XtraBars.BarButtonItem();
			this.btIsShowPass = new DevExpress.XtraBars.BarButtonItem();
			this.btGenPass = new DevExpress.XtraBars.BarButtonItem();
			this.btSendPassToEmail = new DevExpress.XtraBars.BarButtonItem();
			this.rpUsers = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribpgPass = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
			this.lbUserProfile = new DevExpress.XtraBars.BarStaticItem();
			this.btnLogin = new DevExpress.XtraBars.BarButtonItem();
			this.btnLogout = new DevExpress.XtraBars.BarButtonItem();
			this.lbVersion = new DevExpress.XtraBars.BarStaticItem();
			this.pageUsers = new SC.Staff.Views.PageUsers();
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			this.SuspendLayout();
			// 
			// ribbon
			// 
			this.ribbon.CaptionBarItemLinks.Add(this.btResetSettings);
			this.ribbon.ExpandCollapseItem.Id = 0;
			this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btResetSettings,
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btIsShowPass,
            this.btGenPass,
            this.btSendPassToEmail});
			this.ribbon.Location = new System.Drawing.Point(0, 0);
			this.ribbon.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.ribbon.MaxItemId = 5;
			this.ribbon.Name = "ribbon";
			this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpUsers});
			this.ribbon.Size = new System.Drawing.Size(1264, 215);
			this.ribbon.StatusBar = this.ribbonStatusBar;
			// 
			// btResetSettings
			// 
			this.btResetSettings.Caption = "Сбросить настройки экрана ";
			this.btResetSettings.Id = 4;
			this.btResetSettings.ImageOptions.Image = global::SC.Staff.Properties.Resources.ResetSettings;
			this.btResetSettings.Name = "btResetSettings";
			toolTipTitleItem1.Text = "Сбросить настройки экрана";
			toolTipItem1.ImageOptions.Image = global::SC.Staff.Properties.Resources.ResetSettings;
			toolTipItem1.LeftIndent = 6;
			toolTipItem1.Text = "Сбросить настройки экрана \r\n(ширину столбцов, видимость столбцов, группировки, по" +
    "ложение разделителей экранов и прочее)";
			superToolTip1.Items.Add(toolTipTitleItem1);
			superToolTip1.Items.Add(toolTipItem1);
			this.btResetSettings.SuperTip = superToolTip1;
			this.btResetSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btResetSettings_ItemClick);
			// 
			// btIsShowPass
			// 
			this.btIsShowPass.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
			this.btIsShowPass.Caption = "Показать пароли";
			this.btIsShowPass.Id = 1;
			this.btIsShowPass.ImageOptions.SvgImage = global::SC.Staff.Properties.Resources.security_visibility;
			this.btIsShowPass.Name = "btIsShowPass";
			this.btIsShowPass.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
			this.btIsShowPass.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.UpdateSelectedPage);
			// 
			// btGenPass
			// 
			this.btGenPass.Caption = "Сгенерировать пароли";
			this.btGenPass.Id = 2;
			this.btGenPass.ImageOptions.SvgImage = global::SC.Staff.Properties.Resources.security_key;
			this.btGenPass.Name = "btGenPass";
			this.btGenPass.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
			this.btGenPass.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btGenPass_ItemClick);
			// 
			// btSendPassToEmail
			// 
			this.btSendPassToEmail.Caption = "Выслать пароли почтой";
			this.btSendPassToEmail.Id = 3;
			this.btSendPassToEmail.ImageOptions.SvgImage = global::SC.Staff.Properties.Resources.forward;
			this.btSendPassToEmail.Name = "btSendPassToEmail";
			this.btSendPassToEmail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btSendPassToEmail_ItemClick);
			// 
			// rpUsers
			// 
			this.rpUsers.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribpgPass});
			this.rpUsers.Name = "rpUsers";
			this.rpUsers.Text = "Пользователи";
			// 
			// ribpgPass
			// 
			this.ribpgPass.ItemLinks.Add(this.btIsShowPass);
			this.ribpgPass.ItemLinks.Add(this.btGenPass);
			this.ribpgPass.ItemLinks.Add(this.btSendPassToEmail);
			this.ribpgPass.Name = "ribpgPass";
			this.ribpgPass.ShowCaptionButton = false;
			this.ribpgPass.Text = "Пароли";
			// 
			// ribbonStatusBar
			// 
			this.ribbonStatusBar.ItemLinks.Add(this.lbUserProfile);
			this.ribbonStatusBar.ItemLinks.Add(this.btnLogin);
			this.ribbonStatusBar.ItemLinks.Add(this.btnLogout);
			this.ribbonStatusBar.ItemLinks.Add(this.lbVersion);
			this.ribbonStatusBar.Location = new System.Drawing.Point(0, 658);
			this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
			this.ribbonStatusBar.Name = "ribbonStatusBar";
			this.ribbonStatusBar.Ribbon = this.ribbon;
			this.ribbonStatusBar.Size = new System.Drawing.Size(1264, 34);
			// 
			// lbUserProfile
			// 
			this.lbUserProfile.Caption = "Вход не выполнен";
			this.lbUserProfile.Id = 9;
			this.lbUserProfile.Name = "lbUserProfile";
			// 
			// btnLogin
			// 
			this.btnLogin.Caption = "Войти";
			this.btnLogin.Id = 10;
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogin_ItemClick);
			// 
			// btnLogout
			// 
			this.btnLogout.Caption = "Выйти";
			this.btnLogout.Id = 11;
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogout_ItemClick);
			// 
			// lbVersion
			// 
			this.lbVersion.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.lbVersion.Caption = "Версия 1.0.0.0";
			this.lbVersion.Id = 26;
			this.lbVersion.Name = "lbVersion";
			// 
			// pageUsers
			// 
			this.pageUsers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pageUsers.Location = new System.Drawing.Point(0, 215);
			this.pageUsers.Name = "pageUsers";
			this.pageUsers.Size = new System.Drawing.Size(1264, 443);
			this.pageUsers.TabIndex = 1;
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 692);
			this.Controls.Add(this.pageUsers);
			this.Controls.Add(this.ribbonStatusBar);
			this.Controls.Add(this.ribbon);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.Name = "FrmMain";
			this.Ribbon = this.ribbon;
			this.StatusBar = this.ribbonStatusBar;
			this.Text = "Отдел кадров";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
		private DevExpress.XtraBars.Ribbon.RibbonPage rpUsers;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribpgPass;
		private DevExpress.XtraBars.BarButtonItem btIsShowPass;
		private PageUsers pageUsers;
		private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
		private DevExpress.XtraBars.BarStaticItem lbUserProfile;
		private DevExpress.XtraBars.BarButtonItem btnLogin;
		private DevExpress.XtraBars.BarButtonItem btnLogout;
		private DevExpress.XtraBars.BarStaticItem lbVersion;
		private DevExpress.XtraBars.BarButtonItem btGenPass;
		private DevExpress.XtraBars.BarButtonItem btSendPassToEmail;
		private DevExpress.XtraBars.BarButtonItem btResetSettings;
	}
}

