namespace SC.Proda.Views
{
	partial class FrmStDohos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStDohos));
			this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.btNew = new DevExpress.XtraBars.BarButtonItem();
			this.btEdit = new DevExpress.XtraBars.BarButtonItem();
			this.btDelete = new DevExpress.XtraBars.BarButtonItem();
			this.btIsShowNoUsed = new DevExpress.XtraBars.BarButtonItem();
			this.btUpdate = new DevExpress.XtraBars.BarButtonItem();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.gcStDoho = new DevExpress.XtraGrid.GridControl();
			this.cStDohoDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvStDoho = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNoUsed = new DevExpress.XtraGrid.Columns.GridColumn();
			this.coldtc = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gcStDoho)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cStDohoDtoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvStDoho)).BeginInit();
			this.SuspendLayout();
			// 
			// ribbon
			// 
			this.ribbon.ExpandCollapseItem.Id = 0;
			this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btNew,
            this.btEdit,
            this.btDelete,
            this.btIsShowNoUsed,
            this.btUpdate});
			this.ribbon.Location = new System.Drawing.Point(0, 0);
			this.ribbon.MaxItemId = 6;
			this.ribbon.Name = "ribbon";
			this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
			this.ribbon.Size = new System.Drawing.Size(785, 175);
			// 
			// btNew
			// 
			this.btNew.Caption = "Добавить";
			this.btNew.Id = 1;
			this.btNew.ImageOptions.Image = global::SC.Proda.Properties.Resources.New;
			this.btNew.Name = "btNew";
			this.btNew.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
			this.btNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btNew_ItemClick);
			// 
			// btEdit
			// 
			this.btEdit.Caption = "Редактировать";
			this.btEdit.Id = 2;
			this.btEdit.ImageOptions.Image = global::SC.Proda.Properties.Resources.Edit;
			this.btEdit.Name = "btEdit";
			this.btEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
			this.btEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btEdit_ItemClick);
			// 
			// btDelete
			// 
			this.btDelete.Caption = "Удалить";
			this.btDelete.Id = 3;
			this.btDelete.ImageOptions.Image = global::SC.Proda.Properties.Resources.Delete;
			this.btDelete.Name = "btDelete";
			this.btDelete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
			this.btDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btDelete_ItemClick);
			// 
			// btIsShowNoUsed
			// 
			this.btIsShowNoUsed.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
			this.btIsShowNoUsed.Caption = "Показать архив";
			this.btIsShowNoUsed.Id = 4;
			this.btIsShowNoUsed.ImageOptions.Image = global::SC.Proda.Properties.Resources.archive;
			this.btIsShowNoUsed.Name = "btIsShowNoUsed";
			this.btIsShowNoUsed.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
			this.btIsShowNoUsed.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btUpdate_ItemClick);
			// 
			// btUpdate
			// 
			this.btUpdate.Caption = "Обновить";
			this.btUpdate.Id = 5;
			this.btUpdate.ImageOptions.Image = global::SC.Proda.Properties.Resources.Update;
			this.btUpdate.Name = "btUpdate";
			this.btUpdate.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
			this.btUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btUpdate_ItemClick);
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "Главная";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.ItemLinks.Add(this.btNew);
			this.ribbonPageGroup1.ItemLinks.Add(this.btEdit);
			this.ribbonPageGroup1.ItemLinks.Add(this.btDelete);
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.ShowCaptionButton = false;
			this.ribbonPageGroup1.Text = "Редактирование";
			// 
			// ribbonPageGroup2
			// 
			this.ribbonPageGroup2.ItemLinks.Add(this.btIsShowNoUsed);
			this.ribbonPageGroup2.ItemLinks.Add(this.btUpdate);
			this.ribbonPageGroup2.Name = "ribbonPageGroup2";
			this.ribbonPageGroup2.ShowCaptionButton = false;
			this.ribbonPageGroup2.Text = "Данные";
			// 
			// gcStDoho
			// 
			this.gcStDoho.DataSource = this.cStDohoDtoBindingSource;
			this.gcStDoho.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcStDoho.Location = new System.Drawing.Point(0, 175);
			this.gcStDoho.MainView = this.gvStDoho;
			this.gcStDoho.MenuManager = this.ribbon;
			this.gcStDoho.Name = "gcStDoho";
			this.gcStDoho.Size = new System.Drawing.Size(785, 274);
			this.gcStDoho.TabIndex = 2;
			this.gcStDoho.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStDoho});
			// 
			// cStDohoDtoBindingSource
			// 
			this.cStDohoDtoBindingSource.DataSource = typeof(SC.Common.Model.CStDoho);
			// 
			// gvStDoho
			// 
			this.gvStDoho.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colNoUsed,
            this.coldtc});
			this.gvStDoho.GridControl = this.gcStDoho;
			this.gvStDoho.Name = "gvStDoho";
			this.gvStDoho.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvStDoho_RowStyle);
			this.gvStDoho.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvStDoho_CellValueChanged);
			this.gvStDoho.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvStDoho_CellValueChanging);
			this.gvStDoho.DoubleClick += new System.EventHandler(this.gvStDoho_DoubleClick);
			// 
			// colName
			// 
			this.colName.FieldName = "Name";
			this.colName.Name = "colName";
			this.colName.Visible = true;
			this.colName.VisibleIndex = 0;
			// 
			// colNoUsed
			// 
			this.colNoUsed.FieldName = "NoUsed";
			this.colNoUsed.Name = "colNoUsed";
			this.colNoUsed.Visible = true;
			this.colNoUsed.VisibleIndex = 1;
			// 
			// coldtc
			// 
			this.coldtc.FieldName = "dtc";
			this.coldtc.Name = "coldtc";
			this.coldtc.OptionsColumn.AllowEdit = false;
			this.coldtc.Visible = true;
			this.coldtc.VisibleIndex = 2;
			// 
			// FrmStDohos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(785, 449);
			this.Controls.Add(this.gcStDoho);
			this.Controls.Add(this.ribbon);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmStDohos";
			this.Ribbon = this.ribbon;
			this.ShowInTaskbar = false;
			this.Text = "Статьи дохода";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmStDoho_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gcStDoho)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cStDohoDtoBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvStDoho)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
		private DevExpress.XtraBars.BarButtonItem btNew;
		private DevExpress.XtraBars.BarButtonItem btEdit;
		private DevExpress.XtraBars.BarButtonItem btDelete;
		private DevExpress.XtraGrid.GridControl gcStDoho;
		private DevExpress.XtraGrid.Views.Grid.GridView gvStDoho;
		private DevExpress.XtraBars.BarButtonItem btIsShowNoUsed;
		private DevExpress.XtraBars.BarButtonItem btUpdate;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
		private System.Windows.Forms.BindingSource cStDohoDtoBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colName;
		private DevExpress.XtraGrid.Columns.GridColumn colNoUsed;
		private DevExpress.XtraGrid.Columns.GridColumn coldtc;
	}
}