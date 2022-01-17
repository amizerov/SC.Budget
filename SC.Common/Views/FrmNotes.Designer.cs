namespace SC.Common.Views
{
	partial class FrmNotes
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotes));
			this.gcNotes = new DevExpress.XtraGrid.GridControl();
			this.cNoteDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvNotes = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDecryptedContent = new DevExpress.XtraGrid.Columns.GridColumn();
			this.riContent = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.btAdd = new DevExpress.XtraBars.BarButtonItem();
			this.btEdit = new DevExpress.XtraBars.BarButtonItem();
			this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
			this.btInputPassword = new DevExpress.XtraBars.BarButtonItem();
			this.btChangePassword = new DevExpress.XtraBars.BarButtonItem();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribpgCrypt = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			((System.ComponentModel.ISupportInitialize)(this.gcNotes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cNoteDtoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvNotes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.riContent)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
			this.SuspendLayout();
			// 
			// gcNotes
			// 
			this.gcNotes.DataSource = this.cNoteDtoBindingSource;
			this.gcNotes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcNotes.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.gcNotes.Location = new System.Drawing.Point(0, 198);
			this.gcNotes.MainView = this.gvNotes;
			this.gcNotes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.gcNotes.Name = "gcNotes";
			this.gcNotes.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riContent});
			this.gcNotes.Size = new System.Drawing.Size(898, 301);
			this.gcNotes.TabIndex = 2;
			this.gcNotes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNotes});
			// 
			// cNoteDtoBindingSource
			// 
			this.cNoteDtoBindingSource.DataSource = typeof(SC.Common.Model.CNote);
			// 
			// gvNotes
			// 
			this.gvNotes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colDecryptedContent});
			this.gvNotes.DetailHeight = 367;
			this.gvNotes.FixedLineWidth = 3;
			this.gvNotes.GridControl = this.gcNotes;
			this.gvNotes.Name = "gvNotes";
			this.gvNotes.OptionsView.RowAutoHeight = true;
			this.gvNotes.OptionsView.ShowGroupPanel = false;
			this.gvNotes.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvNotes_CellValueChanged);
			// 
			// colDate
			// 
			this.colDate.FieldName = "Date";
			this.colDate.MinWidth = 22;
			this.colDate.Name = "colDate";
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 0;
			this.colDate.Width = 149;
			// 
			// colDecryptedContent
			// 
			this.colDecryptedContent.ColumnEdit = this.riContent;
			this.colDecryptedContent.FieldName = "DecryptedContent";
			this.colDecryptedContent.Name = "colDecryptedContent";
			this.colDecryptedContent.Visible = true;
			this.colDecryptedContent.VisibleIndex = 1;
			this.colDecryptedContent.Width = 1010;
			// 
			// riContent
			// 
			this.riContent.Appearance.Options.UseTextOptions = true;
			this.riContent.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.riContent.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
			this.riContent.Name = "riContent";
			// 
			// ribbonControl1
			// 
			this.ribbonControl1.ExpandCollapseItem.Id = 0;
			this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btAdd,
            this.btEdit,
            this.btnDelete,
            this.btInputPassword,
            this.btChangePassword});
			this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
			this.ribbonControl1.MaxItemId = 6;
			this.ribbonControl1.Name = "ribbonControl1";
			this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
			this.ribbonControl1.Size = new System.Drawing.Size(898, 198);
			// 
			// btAdd
			// 
			this.btAdd.Caption = "Добавить";
			this.btAdd.Id = 1;
			this.btAdd.ImageOptions.Image = global::SC.Common.Properties.Resources.New;
			this.btAdd.Name = "btAdd";
			this.btAdd.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
			this.btAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btAdd_ItemClick);
			// 
			// btEdit
			// 
			this.btEdit.Caption = "Редактировать";
			this.btEdit.Id = 2;
			this.btEdit.ImageOptions.Image = global::SC.Common.Properties.Resources.Edit;
			this.btEdit.Name = "btEdit";
			this.btEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
			this.btEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btEdit_ItemClick);
			// 
			// btnDelete
			// 
			this.btnDelete.Caption = "Удалить";
			this.btnDelete.Id = 3;
			this.btnDelete.ImageOptions.Image = global::SC.Common.Properties.Resources.Delete;
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
			this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
			// 
			// btInputPassword
			// 
			this.btInputPassword.Caption = "Ввести пароль";
			this.btInputPassword.Id = 4;
			this.btInputPassword.ImageOptions.SvgImage = global::SC.Common.Properties.Resources.security_unlock;
			this.btInputPassword.Name = "btInputPassword";
			this.btInputPassword.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
			this.btInputPassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btInputPassword_ItemClick);
			// 
			// btChangePassword
			// 
			this.btChangePassword.Caption = "Сменить пароль";
			this.btChangePassword.Id = 5;
			this.btChangePassword.ImageOptions.SvgImage = global::SC.Common.Properties.Resources.bo_security_permission;
			this.btChangePassword.Name = "btChangePassword";
			this.btChangePassword.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
			this.btChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btChangePassword_ItemClick);
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribpgCrypt});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "Главная";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.ItemLinks.Add(this.btAdd);
			this.ribbonPageGroup1.ItemLinks.Add(this.btEdit);
			this.ribbonPageGroup1.ItemLinks.Add(this.btnDelete);
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.ShowCaptionButton = false;
			this.ribbonPageGroup1.Text = "Заметки";
			// 
			// ribpgCrypt
			// 
			this.ribpgCrypt.ItemLinks.Add(this.btInputPassword);
			this.ribpgCrypt.ItemLinks.Add(this.btChangePassword);
			this.ribpgCrypt.Name = "ribpgCrypt";
			this.ribpgCrypt.ShowCaptionButton = false;
			this.ribpgCrypt.Text = "Шифрование";
			// 
			// ribbonPage2
			// 
			this.ribbonPage2.Name = "ribbonPage2";
			this.ribbonPage2.Text = "ribbonPage2";
			// 
			// FrmNotes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(898, 499);
			this.Controls.Add(this.gcNotes);
			this.Controls.Add(this.ribbonControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "FrmNotes";
			this.Ribbon = this.ribbonControl1;
			this.ShowInTaskbar = false;
			this.Text = "Заметки";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmNotes_FormClosed);
			this.Shown += new System.EventHandler(this.FrmNotes_Shown);
			((System.ComponentModel.ISupportInitialize)(this.gcNotes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cNoteDtoBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvNotes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.riContent)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraGrid.GridControl gcNotes;
		private DevExpress.XtraGrid.Views.Grid.GridView gvNotes;
		private System.Windows.Forms.BindingSource cNoteDtoBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colDate;
		private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit riContent;
		private DevExpress.XtraGrid.Columns.GridColumn colDecryptedContent;
		private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribpgCrypt;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
		private DevExpress.XtraBars.BarButtonItem btAdd;
		private DevExpress.XtraBars.BarButtonItem btEdit;
		private DevExpress.XtraBars.BarButtonItem btnDelete;
		private DevExpress.XtraBars.BarButtonItem btInputPassword;
		private DevExpress.XtraBars.BarButtonItem btChangePassword;
	}
}