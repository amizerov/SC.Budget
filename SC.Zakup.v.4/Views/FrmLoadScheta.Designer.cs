namespace SC.Zakup.Views
{
	partial class FrmLoadScheta
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoadScheta));
			this.pnOk = new System.Windows.Forms.Panel();
			this.btSelectAllNew = new DevExpress.XtraEditors.SimpleButton();
			this.btCancelAll = new DevExpress.XtraEditors.SimpleButton();
			this.btSelectAll = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.gcScheta = new DevExpress.XtraGrid.GridControl();
			this.cSchetLoadBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvScheta = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colNeedLoad = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDetailName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colStRashName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colFirmaName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNomer = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNomerInternal = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSumma = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDataCreate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDataPayTo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colIsShipped = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colIsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.gcOldScheta = new DevExpress.XtraGrid.GridControl();
			this.gvOldScheta = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colNeedLoad1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSupplierName1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDetailName1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colStRashName1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colProjectName1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colFirmaName1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNomer1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNomerInternal1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSumma1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDataCreate1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDataPayTo1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colIsShipped1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCategory1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colComment1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colIsDeleted1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.cSchetViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.pnOk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcScheta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cSchetLoadBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvScheta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gcOldScheta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvOldScheta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cSchetViewModelBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// pnOk
			// 
			this.pnOk.Controls.Add(this.btSelectAllNew);
			this.pnOk.Controls.Add(this.btCancelAll);
			this.pnOk.Controls.Add(this.btSelectAll);
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 528);
			this.pnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(1136, 80);
			this.pnOk.TabIndex = 2;
			// 
			// btSelectAllNew
			// 
			this.btSelectAllNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btSelectAllNew.Location = new System.Drawing.Point(150, 26);
			this.btSelectAllNew.Margin = new System.Windows.Forms.Padding(10);
			this.btSelectAllNew.Name = "btSelectAllNew";
			this.btSelectAllNew.Size = new System.Drawing.Size(150, 30);
			this.btSelectAllNew.TabIndex = 6;
			this.btSelectAllNew.Text = "Выбрать все новые";
			this.btSelectAllNew.Click += new System.EventHandler(this.btSelectAllNew_Click);
			// 
			// btCancelAll
			// 
			this.btCancelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btCancelAll.Location = new System.Drawing.Point(320, 26);
			this.btCancelAll.Margin = new System.Windows.Forms.Padding(10);
			this.btCancelAll.Name = "btCancelAll";
			this.btCancelAll.Size = new System.Drawing.Size(120, 30);
			this.btCancelAll.TabIndex = 5;
			this.btCancelAll.Text = "Отменить всё";
			this.btCancelAll.Click += new System.EventHandler(this.btCancelAll_Click);
			// 
			// btSelectAll
			// 
			this.btSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btSelectAll.Location = new System.Drawing.Point(10, 26);
			this.btSelectAll.Margin = new System.Windows.Forms.Padding(10);
			this.btSelectAll.Name = "btSelectAll";
			this.btSelectAll.Size = new System.Drawing.Size(120, 30);
			this.btSelectAll.TabIndex = 4;
			this.btSelectAll.Text = "Выбрать всё";
			this.btSelectAll.Click += new System.EventHandler(this.btSelectAll_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(886, 26);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 30);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Отмена";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(1006, 21);
			this.btnOk.Margin = new System.Windows.Forms.Padding(10);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(111, 40);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "Ок";
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Horizontal = false;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.gcScheta);
			this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.gcOldScheta);
			this.splitContainerControl1.Panel2.Controls.Add(this.labelControl2);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(1136, 528);
			this.splitContainerControl1.SplitterPosition = 273;
			this.splitContainerControl1.TabIndex = 3;
			this.splitContainerControl1.Tag = "1";
			// 
			// gcScheta
			// 
			this.gcScheta.DataSource = this.cSchetLoadBindingSource;
			this.gcScheta.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcScheta.Location = new System.Drawing.Point(0, 30);
			this.gcScheta.MainView = this.gvScheta;
			this.gcScheta.Name = "gcScheta";
			this.gcScheta.Size = new System.Drawing.Size(1136, 243);
			this.gcScheta.TabIndex = 0;
			this.gcScheta.Tag = "";
			this.gcScheta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvScheta});
			// 
			// cSchetLoadBindingSource
			// 
			this.cSchetLoadBindingSource.DataSource = typeof(SC.Common.Model.CSchetLoad);
			// 
			// gvScheta
			// 
			this.gvScheta.Appearance.FocusedCell.BackColor = System.Drawing.Color.Yellow;
			this.gvScheta.Appearance.FocusedCell.Options.UseBackColor = true;
			this.gvScheta.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.gvScheta.Appearance.FocusedRow.Options.UseBackColor = true;
			this.gvScheta.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.gvScheta.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.gvScheta.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.gvScheta.Appearance.SelectedRow.Options.UseBackColor = true;
			this.gvScheta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNeedLoad,
            this.colSupplierName,
            this.colDetailName,
            this.colStRashName,
            this.colProjectName,
            this.colFirmaName,
            this.colNomer,
            this.colNomerInternal,
            this.colSumma,
            this.colDataCreate,
            this.colDataPayTo,
            this.colIsShipped,
            this.colCategory,
            this.colComment,
            this.colIsDeleted});
			this.gvScheta.GridControl = this.gcScheta;
			this.gvScheta.Name = "gvScheta";
			this.gvScheta.OptionsView.ShowGroupPanel = false;
			this.gvScheta.Tag = "1";
			this.gvScheta.CustomDrawScroll += new System.EventHandler<DevExpress.XtraEditors.ScrollBarCustomDrawEventArgs>(this.gvScheta_CustomDrawScroll);
			this.gvScheta.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvScheta_CustomDrawCell);
			this.gvScheta.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvScheta_RowStyle);
			this.gvScheta.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvScheta_FocusedRowChanged);
			this.gvScheta.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gvScheta_FocusedColumnChanged);
			this.gvScheta.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvScheta_CellValueChanged);
			this.gvScheta.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvScheta_CellValueChanging);
			this.gvScheta.Layout += new System.EventHandler(this.gvScheta_Layout);
			// 
			// colNeedLoad
			// 
			this.colNeedLoad.FieldName = "NeedLoad";
			this.colNeedLoad.Name = "colNeedLoad";
			this.colNeedLoad.Visible = true;
			this.colNeedLoad.VisibleIndex = 0;
			// 
			// colSupplierName
			// 
			this.colSupplierName.FieldName = "SupplierName";
			this.colSupplierName.Name = "colSupplierName";
			this.colSupplierName.OptionsColumn.AllowEdit = false;
			this.colSupplierName.Visible = true;
			this.colSupplierName.VisibleIndex = 1;
			// 
			// colDetailName
			// 
			this.colDetailName.FieldName = "DetailName";
			this.colDetailName.Name = "colDetailName";
			this.colDetailName.OptionsColumn.AllowEdit = false;
			this.colDetailName.Visible = true;
			this.colDetailName.VisibleIndex = 2;
			// 
			// colStRashName
			// 
			this.colStRashName.FieldName = "StRashName";
			this.colStRashName.Name = "colStRashName";
			this.colStRashName.OptionsColumn.AllowEdit = false;
			this.colStRashName.Visible = true;
			this.colStRashName.VisibleIndex = 3;
			// 
			// colProjectName
			// 
			this.colProjectName.FieldName = "ProjectName";
			this.colProjectName.Name = "colProjectName";
			this.colProjectName.OptionsColumn.AllowEdit = false;
			this.colProjectName.Visible = true;
			this.colProjectName.VisibleIndex = 4;
			// 
			// colFirmaName
			// 
			this.colFirmaName.FieldName = "FirmaName";
			this.colFirmaName.Name = "colFirmaName";
			this.colFirmaName.OptionsColumn.AllowEdit = false;
			this.colFirmaName.Visible = true;
			this.colFirmaName.VisibleIndex = 5;
			// 
			// colNomer
			// 
			this.colNomer.FieldName = "Nomer";
			this.colNomer.Name = "colNomer";
			this.colNomer.OptionsColumn.AllowEdit = false;
			this.colNomer.Visible = true;
			this.colNomer.VisibleIndex = 6;
			// 
			// colNomerInternal
			// 
			this.colNomerInternal.FieldName = "NomerInternal";
			this.colNomerInternal.Name = "colNomerInternal";
			this.colNomerInternal.OptionsColumn.AllowEdit = false;
			this.colNomerInternal.Visible = true;
			this.colNomerInternal.VisibleIndex = 7;
			// 
			// colSumma
			// 
			this.colSumma.FieldName = "Summa";
			this.colSumma.Name = "colSumma";
			this.colSumma.OptionsColumn.AllowEdit = false;
			this.colSumma.Visible = true;
			this.colSumma.VisibleIndex = 8;
			// 
			// colDataCreate
			// 
			this.colDataCreate.FieldName = "DataCreate";
			this.colDataCreate.Name = "colDataCreate";
			this.colDataCreate.OptionsColumn.AllowEdit = false;
			this.colDataCreate.Visible = true;
			this.colDataCreate.VisibleIndex = 9;
			// 
			// colDataPayTo
			// 
			this.colDataPayTo.FieldName = "DataPayTo";
			this.colDataPayTo.Name = "colDataPayTo";
			this.colDataPayTo.OptionsColumn.AllowEdit = false;
			this.colDataPayTo.Visible = true;
			this.colDataPayTo.VisibleIndex = 10;
			// 
			// colIsShipped
			// 
			this.colIsShipped.FieldName = "IsShipped";
			this.colIsShipped.Name = "colIsShipped";
			this.colIsShipped.OptionsColumn.AllowEdit = false;
			this.colIsShipped.Visible = true;
			this.colIsShipped.VisibleIndex = 11;
			// 
			// colCategory
			// 
			this.colCategory.FieldName = "Category";
			this.colCategory.Name = "colCategory";
			this.colCategory.OptionsColumn.AllowEdit = false;
			this.colCategory.Visible = true;
			this.colCategory.VisibleIndex = 12;
			// 
			// colComment
			// 
			this.colComment.FieldName = "Comment";
			this.colComment.Name = "colComment";
			this.colComment.OptionsColumn.AllowEdit = false;
			this.colComment.Visible = true;
			this.colComment.VisibleIndex = 13;
			// 
			// colIsDeleted
			// 
			this.colIsDeleted.FieldName = "IsDeleted";
			this.colIsDeleted.Name = "colIsDeleted";
			this.colIsDeleted.OptionsColumn.AllowEdit = false;
			this.colIsDeleted.Visible = true;
			this.colIsDeleted.VisibleIndex = 14;
			// 
			// labelControl1
			// 
			this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelControl1.Location = new System.Drawing.Point(0, 0);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Padding = new System.Windows.Forms.Padding(5);
			this.labelControl1.Size = new System.Drawing.Size(127, 30);
			this.labelControl1.TabIndex = 1;
			this.labelControl1.Text = "Новые значения";
			// 
			// gcOldScheta
			// 
			this.gcOldScheta.DataSource = this.cSchetLoadBindingSource;
			this.gcOldScheta.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcOldScheta.Location = new System.Drawing.Point(0, 25);
			this.gcOldScheta.MainView = this.gvOldScheta;
			this.gcOldScheta.Name = "gcOldScheta";
			this.gcOldScheta.Size = new System.Drawing.Size(1136, 218);
			this.gcOldScheta.TabIndex = 1;
			this.gcOldScheta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOldScheta});
			// 
			// gvOldScheta
			// 
			this.gvOldScheta.ActiveFilterEnabled = false;
			this.gvOldScheta.Appearance.FocusedCell.BackColor = System.Drawing.Color.Yellow;
			this.gvOldScheta.Appearance.FocusedCell.Options.UseBackColor = true;
			this.gvOldScheta.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.gvOldScheta.Appearance.FocusedRow.Options.UseBackColor = true;
			this.gvOldScheta.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.gvOldScheta.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.gvOldScheta.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.gvOldScheta.Appearance.SelectedRow.Options.UseBackColor = true;
			this.gvOldScheta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNeedLoad1,
            this.colSupplierName1,
            this.colDetailName1,
            this.colStRashName1,
            this.colProjectName1,
            this.colFirmaName1,
            this.colNomer1,
            this.colNomerInternal1,
            this.colSumma1,
            this.colDataCreate1,
            this.colDataPayTo1,
            this.colIsShipped1,
            this.colCategory1,
            this.colComment1,
            this.colIsDeleted1});
			this.gvOldScheta.GridControl = this.gcOldScheta;
			this.gvOldScheta.Name = "gvOldScheta";
			this.gvOldScheta.OptionsView.ShowGroupPanel = false;
			this.gvOldScheta.Tag = "1";
			this.gvOldScheta.CustomDrawScroll += new System.EventHandler<DevExpress.XtraEditors.ScrollBarCustomDrawEventArgs>(this.gvScheta_CustomDrawScroll);
			this.gvOldScheta.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvScheta_CustomDrawCell);
			this.gvOldScheta.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvScheta_RowStyle);
			this.gvOldScheta.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvScheta_FocusedRowChanged);
			this.gvOldScheta.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gvScheta_FocusedColumnChanged);
			this.gvOldScheta.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvScheta_CellValueChanged);
			this.gvOldScheta.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvScheta_CellValueChanging);
			this.gvOldScheta.Layout += new System.EventHandler(this.gvScheta_Layout);
			// 
			// colNeedLoad1
			// 
			this.colNeedLoad1.FieldName = "NeedLoad";
			this.colNeedLoad1.Name = "colNeedLoad1";
			this.colNeedLoad1.Visible = true;
			this.colNeedLoad1.VisibleIndex = 0;
			// 
			// colSupplierName1
			// 
			this.colSupplierName1.FieldName = "SupplierName";
			this.colSupplierName1.Name = "colSupplierName1";
			this.colSupplierName1.OptionsColumn.AllowEdit = false;
			this.colSupplierName1.OptionsFilter.AllowAutoFilter = false;
			this.colSupplierName1.OptionsFilter.AllowFilter = false;
			this.colSupplierName1.Visible = true;
			this.colSupplierName1.VisibleIndex = 1;
			// 
			// colDetailName1
			// 
			this.colDetailName1.FieldName = "DetailName";
			this.colDetailName1.Name = "colDetailName1";
			this.colDetailName1.OptionsColumn.AllowEdit = false;
			this.colDetailName1.Visible = true;
			this.colDetailName1.VisibleIndex = 2;
			// 
			// colStRashName1
			// 
			this.colStRashName1.FieldName = "StRashName";
			this.colStRashName1.Name = "colStRashName1";
			this.colStRashName1.OptionsColumn.AllowEdit = false;
			this.colStRashName1.Visible = true;
			this.colStRashName1.VisibleIndex = 3;
			// 
			// colProjectName1
			// 
			this.colProjectName1.FieldName = "ProjectName";
			this.colProjectName1.Name = "colProjectName1";
			this.colProjectName1.OptionsColumn.AllowEdit = false;
			this.colProjectName1.Visible = true;
			this.colProjectName1.VisibleIndex = 4;
			// 
			// colFirmaName1
			// 
			this.colFirmaName1.FieldName = "FirmaName";
			this.colFirmaName1.Name = "colFirmaName1";
			this.colFirmaName1.OptionsColumn.AllowEdit = false;
			this.colFirmaName1.Visible = true;
			this.colFirmaName1.VisibleIndex = 5;
			// 
			// colNomer1
			// 
			this.colNomer1.FieldName = "Nomer";
			this.colNomer1.Name = "colNomer1";
			this.colNomer1.OptionsColumn.AllowEdit = false;
			this.colNomer1.Visible = true;
			this.colNomer1.VisibleIndex = 6;
			// 
			// colNomerInternal1
			// 
			this.colNomerInternal1.FieldName = "NomerInternal";
			this.colNomerInternal1.Name = "colNomerInternal1";
			this.colNomerInternal1.OptionsColumn.AllowEdit = false;
			this.colNomerInternal1.Visible = true;
			this.colNomerInternal1.VisibleIndex = 7;
			// 
			// colSumma1
			// 
			this.colSumma1.FieldName = "Summa";
			this.colSumma1.Name = "colSumma1";
			this.colSumma1.OptionsColumn.AllowEdit = false;
			this.colSumma1.Visible = true;
			this.colSumma1.VisibleIndex = 8;
			// 
			// colDataCreate1
			// 
			this.colDataCreate1.FieldName = "DataCreate";
			this.colDataCreate1.Name = "colDataCreate1";
			this.colDataCreate1.OptionsColumn.AllowEdit = false;
			this.colDataCreate1.Visible = true;
			this.colDataCreate1.VisibleIndex = 9;
			// 
			// colDataPayTo1
			// 
			this.colDataPayTo1.FieldName = "DataPayTo";
			this.colDataPayTo1.Name = "colDataPayTo1";
			this.colDataPayTo1.OptionsColumn.AllowEdit = false;
			this.colDataPayTo1.Visible = true;
			this.colDataPayTo1.VisibleIndex = 10;
			// 
			// colIsShipped1
			// 
			this.colIsShipped1.FieldName = "IsShipped";
			this.colIsShipped1.Name = "colIsShipped1";
			this.colIsShipped1.OptionsColumn.AllowEdit = false;
			this.colIsShipped1.Visible = true;
			this.colIsShipped1.VisibleIndex = 11;
			// 
			// colCategory1
			// 
			this.colCategory1.FieldName = "Category";
			this.colCategory1.Name = "colCategory1";
			this.colCategory1.OptionsColumn.AllowEdit = false;
			this.colCategory1.Visible = true;
			this.colCategory1.VisibleIndex = 12;
			// 
			// colComment1
			// 
			this.colComment1.FieldName = "Comment";
			this.colComment1.Name = "colComment1";
			this.colComment1.OptionsColumn.AllowEdit = false;
			this.colComment1.Visible = true;
			this.colComment1.VisibleIndex = 13;
			// 
			// colIsDeleted1
			// 
			this.colIsDeleted1.FieldName = "IsDeleted";
			this.colIsDeleted1.Name = "colIsDeleted1";
			this.colIsDeleted1.OptionsColumn.AllowEdit = false;
			this.colIsDeleted1.Visible = true;
			this.colIsDeleted1.VisibleIndex = 14;
			// 
			// labelControl2
			// 
			this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelControl2.Location = new System.Drawing.Point(0, 0);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
			this.labelControl2.Size = new System.Drawing.Size(131, 25);
			this.labelControl2.TabIndex = 2;
			this.labelControl2.Text = "Старые значения";
			// 
			// cSchetViewModelBindingSource
			// 
			this.cSchetViewModelBindingSource.DataSource = typeof(SC.Common.Model.CSchet);
			// 
			// FrmLoadScheta
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1136, 608);
			this.Controls.Add(this.splitContainerControl1);
			this.Controls.Add(this.pnOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmLoadScheta";
			this.Text = "Загрузка счетов";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLoadScheta_FormClosed);
			this.pnOk.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcScheta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cSchetLoadBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvScheta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gcOldScheta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvOldScheta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cSchetViewModelBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnOk;
		private DevExpress.XtraEditors.SimpleButton btCancelAll;
		private DevExpress.XtraEditors.SimpleButton btSelectAll;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.SimpleButton btnOk;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DevExpress.XtraGrid.GridControl gcScheta;
		private DevExpress.XtraGrid.Views.Grid.GridView gvScheta;
		private DevExpress.XtraGrid.GridControl gcOldScheta;
		private DevExpress.XtraGrid.Views.Grid.GridView gvOldScheta;
		private System.Windows.Forms.BindingSource cSchetLoadBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colNeedLoad;
		private DevExpress.XtraGrid.Columns.GridColumn colSupplierName;
		private DevExpress.XtraGrid.Columns.GridColumn colDetailName;
		private DevExpress.XtraGrid.Columns.GridColumn colStRashName;
		private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
		private DevExpress.XtraGrid.Columns.GridColumn colFirmaName;
		private DevExpress.XtraGrid.Columns.GridColumn colNomer;
		private DevExpress.XtraGrid.Columns.GridColumn colNomerInternal;
		private DevExpress.XtraGrid.Columns.GridColumn colSumma;
		private DevExpress.XtraGrid.Columns.GridColumn colDataCreate;
		private DevExpress.XtraGrid.Columns.GridColumn colDataPayTo;
		private DevExpress.XtraGrid.Columns.GridColumn colIsShipped;
		private DevExpress.XtraGrid.Columns.GridColumn colCategory;
		private DevExpress.XtraGrid.Columns.GridColumn colComment;
		private DevExpress.XtraGrid.Columns.GridColumn colIsDeleted;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private System.Windows.Forms.BindingSource cSchetViewModelBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colSupplierName1;
		private DevExpress.XtraGrid.Columns.GridColumn colDetailName1;
		private DevExpress.XtraGrid.Columns.GridColumn colStRashName1;
		private DevExpress.XtraGrid.Columns.GridColumn colProjectName1;
		private DevExpress.XtraGrid.Columns.GridColumn colFirmaName1;
		private DevExpress.XtraGrid.Columns.GridColumn colNomer1;
		private DevExpress.XtraGrid.Columns.GridColumn colNomerInternal1;
		private DevExpress.XtraGrid.Columns.GridColumn colSumma1;
		private DevExpress.XtraGrid.Columns.GridColumn colDataCreate1;
		private DevExpress.XtraGrid.Columns.GridColumn colDataPayTo1;
		private DevExpress.XtraGrid.Columns.GridColumn colIsShipped1;
		private DevExpress.XtraGrid.Columns.GridColumn colCategory1;
		private DevExpress.XtraGrid.Columns.GridColumn colComment1;
		private DevExpress.XtraGrid.Columns.GridColumn colIsDeleted1;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraGrid.Columns.GridColumn colNeedLoad1;
		private DevExpress.XtraEditors.SimpleButton btSelectAllNew;
	}
}