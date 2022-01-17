namespace SC.Zakup.Views
{
	partial class PageScheta
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
			DevExpress.XtraEditors.FormatConditionRuleIconSet formatConditionRuleIconSet1 = new DevExpress.XtraEditors.FormatConditionRuleIconSet();
			DevExpress.XtraEditors.FormatConditionIconSet formatConditionIconSet1 = new DevExpress.XtraEditors.FormatConditionIconSet();
			DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon1 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
			this.coldtu = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSumma = new DevExpress.XtraGrid.Columns.GridColumn();
			this.sccScheta = new DevExpress.XtraEditors.SplitContainerControl();
			this.gcScheta = new DevExpress.XtraGrid.GridControl();
			this.cSchetBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvScheta = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDetailName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colStRashName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNomer = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNomerInternal = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDataCreate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDataPayTo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colOplata = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colIsShipped = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colOplataDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRest = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colFirmaName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
			this.coldtc = new DevExpress.XtraGrid.Columns.GridColumn();
			this.lbSchetLines = new DevExpress.XtraEditors.LabelControl();
			this.gcSchetLines = new DevExpress.XtraGrid.GridControl();
			this.gvSchetLines = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.lbOplatas = new DevExpress.XtraEditors.LabelControl();
			this.gcOplatas = new DevExpress.XtraGrid.GridControl();
			this.gvOplatas = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.lbComment = new DevExpress.XtraEditors.LabelControl();
			this.txtComment = new DevExpress.XtraEditors.MemoEdit();
			this.cSchetLineBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.colNomenklatura = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
			this.cOplataBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.colSumma1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colData = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.sccScheta)).BeginInit();
			this.sccScheta.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcScheta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cSchetBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvScheta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gcSchetLines)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvSchetLines)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gcOplatas)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvOplatas)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cSchetLineBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cOplataBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// coldtu
			// 
			this.coldtu.FieldName = "dtu";
			this.coldtu.MinWidth = 26;
			this.coldtu.Name = "coldtu";
			this.coldtu.OptionsColumn.AllowEdit = false;
			this.coldtu.ToolTip = "Дата изменения записи в базе данных";
			this.coldtu.Visible = true;
			this.coldtu.VisibleIndex = 19;
			this.coldtu.Width = 113;
			// 
			// colID
			// 
			this.colID.FieldName = "ID";
			this.colID.MinWidth = 26;
			this.colID.Name = "colID";
			this.colID.OptionsColumn.AllowEdit = false;
			this.colID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", "{0} счетов")});
			this.colID.Visible = true;
			this.colID.VisibleIndex = 0;
			this.colID.Width = 113;
			// 
			// colSumma
			// 
			this.colSumma.FieldName = "Summa";
			this.colSumma.MinWidth = 26;
			this.colSumma.Name = "colSumma";
			this.colSumma.OptionsColumn.AllowEdit = false;
			this.colSumma.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Summa", "{0:c2}")});
			this.colSumma.Visible = true;
			this.colSumma.VisibleIndex = 10;
			this.colSumma.Width = 113;
			// 
			// sccScheta
			// 
			this.sccScheta.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sccScheta.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
			this.sccScheta.Location = new System.Drawing.Point(0, 0);
			this.sccScheta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.sccScheta.Name = "sccScheta";
			this.sccScheta.Panel1.Controls.Add(this.gcScheta);
			this.sccScheta.Panel1.Text = "Panel1";
			this.sccScheta.Panel2.Controls.Add(this.lbSchetLines);
			this.sccScheta.Panel2.Controls.Add(this.gcSchetLines);
			this.sccScheta.Panel2.Controls.Add(this.lbOplatas);
			this.sccScheta.Panel2.Controls.Add(this.gcOplatas);
			this.sccScheta.Panel2.Controls.Add(this.lbComment);
			this.sccScheta.Panel2.Controls.Add(this.txtComment);
			this.sccScheta.Panel2.Text = "Panel2";
			this.sccScheta.Size = new System.Drawing.Size(1400, 600);
			this.sccScheta.SplitterPosition = 407;
			this.sccScheta.TabIndex = 8;
			// 
			// gcScheta
			// 
			this.gcScheta.DataSource = this.cSchetBindingSource;
			this.gcScheta.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcScheta.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gcScheta.Location = new System.Drawing.Point(0, 0);
			this.gcScheta.MainView = this.gvScheta;
			this.gcScheta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gcScheta.Name = "gcScheta";
			this.gcScheta.Size = new System.Drawing.Size(981, 600);
			this.gcScheta.TabIndex = 4;
			this.gcScheta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvScheta});
			this.gcScheta.DoubleClick += new System.EventHandler(this.GcScheta_DoubleClick);
			this.gcScheta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GcScheta_KeyDown);
			// 
			// cSchetBindingSource
			// 
			this.cSchetBindingSource.DataSource = typeof(SC.Common.Model.CSchet);
			// 
			// gvScheta
			// 
			this.gvScheta.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.gvScheta.Appearance.FocusedRow.Options.UseBackColor = true;
			this.gvScheta.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.gvScheta.Appearance.SelectedRow.Options.UseBackColor = true;
			this.gvScheta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colSupplierName,
            this.colDetailName,
            this.colCategory,
            this.colStRashName,
            this.colProjectName,
            this.colNomer,
            this.colNomerInternal,
            this.colDataCreate,
            this.colDataPayTo,
            this.colSumma,
            this.colOplata,
            this.colIsShipped,
            this.colOplataDate,
            this.colRest,
            this.colFirmaName,
            this.colComment,
            this.colUser,
            this.coldtc,
            this.coldtu});
			this.gvScheta.DetailHeight = 539;
			this.gvScheta.FixedLineWidth = 4;
			this.gvScheta.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			gridFormatRule1.Column = this.coldtu;
			gridFormatRule1.ColumnApplyTo = this.colID;
			gridFormatRule1.Enabled = false;
			gridFormatRule1.Name = "Format0";
			formatConditionIconSet1.CategoryName = "Оценки";
			formatConditionIconSetIcon1.PredefinedName = "Stars3_1.png";
			formatConditionIconSetIcon1.Value = new decimal(new int[] {
            67,
            0,
            0,
            0});
			formatConditionIconSetIcon1.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
			formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon1);
			formatConditionIconSet1.Name = "Stars3";
			formatConditionIconSet1.ValueType = DevExpress.XtraEditors.FormatConditionValueType.Number;
			formatConditionRuleIconSet1.IconSet = formatConditionIconSet1;
			gridFormatRule1.Rule = formatConditionRuleIconSet1;
			this.gvScheta.FormatRules.Add(gridFormatRule1);
			this.gvScheta.GridControl = this.gcScheta;
			this.gvScheta.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, " / Счетов: {0}шт"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Summa", null, "/ На сумму {0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Oplata", null, " / Оплачено {0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Rest", null, " / Остаток: {0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", this.colID, "{0} счетов"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Summa", this.colSumma, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Oplata", this.colOplata, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Rest", this.colRest, "{0:c2}")});
			this.gvScheta.Name = "gvScheta";
			this.gvScheta.OptionsSelection.MultiSelect = true;
			this.gvScheta.OptionsView.ShowAutoFilterRow = true;
			this.gvScheta.OptionsView.ShowFooter = true;
			this.gvScheta.OptionsView.ShowGroupPanel = false;
			this.gvScheta.Tag = ((short)(2));
			this.gvScheta.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvScheta_CustomDrawCell);
			this.gvScheta.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.GvScheta_RowStyle);
			this.gvScheta.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvScheta_ShowingEditor);
			this.gvScheta.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GvScheta_FocusedRowChanged);
			this.gvScheta.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvScheta_CellValueChanged);
			// 
			// colSupplierName
			// 
			this.colSupplierName.FieldName = "SupplierName";
			this.colSupplierName.MinWidth = 26;
			this.colSupplierName.Name = "colSupplierName";
			this.colSupplierName.OptionsColumn.AllowEdit = false;
			this.colSupplierName.Visible = true;
			this.colSupplierName.VisibleIndex = 1;
			this.colSupplierName.Width = 113;
			// 
			// colDetailName
			// 
			this.colDetailName.FieldName = "DetailName";
			this.colDetailName.MinWidth = 26;
			this.colDetailName.Name = "colDetailName";
			this.colDetailName.OptionsColumn.AllowEdit = false;
			this.colDetailName.Visible = true;
			this.colDetailName.VisibleIndex = 2;
			this.colDetailName.Width = 113;
			// 
			// colCategory
			// 
			this.colCategory.FieldName = "Category";
			this.colCategory.Name = "colCategory";
			this.colCategory.Visible = true;
			this.colCategory.VisibleIndex = 3;
			// 
			// colStRashName
			// 
			this.colStRashName.FieldName = "StRashName";
			this.colStRashName.MinWidth = 26;
			this.colStRashName.Name = "colStRashName";
			this.colStRashName.OptionsColumn.AllowEdit = false;
			this.colStRashName.Visible = true;
			this.colStRashName.VisibleIndex = 4;
			this.colStRashName.Width = 113;
			// 
			// colProjectName
			// 
			this.colProjectName.FieldName = "ProjectName";
			this.colProjectName.MinWidth = 26;
			this.colProjectName.Name = "colProjectName";
			this.colProjectName.OptionsColumn.AllowEdit = false;
			this.colProjectName.Visible = true;
			this.colProjectName.VisibleIndex = 5;
			this.colProjectName.Width = 113;
			// 
			// colNomer
			// 
			this.colNomer.FieldName = "Nomer";
			this.colNomer.MinWidth = 26;
			this.colNomer.Name = "colNomer";
			this.colNomer.OptionsColumn.AllowEdit = false;
			this.colNomer.Visible = true;
			this.colNomer.VisibleIndex = 6;
			this.colNomer.Width = 113;
			// 
			// colNomerInternal
			// 
			this.colNomerInternal.FieldName = "NomerInternal";
			this.colNomerInternal.MinWidth = 26;
			this.colNomerInternal.Name = "colNomerInternal";
			this.colNomerInternal.OptionsColumn.AllowEdit = false;
			this.colNomerInternal.Visible = true;
			this.colNomerInternal.VisibleIndex = 7;
			this.colNomerInternal.Width = 113;
			// 
			// colDataCreate
			// 
			this.colDataCreate.FieldName = "DataCreate";
			this.colDataCreate.MinWidth = 26;
			this.colDataCreate.Name = "colDataCreate";
			this.colDataCreate.OptionsColumn.AllowEdit = false;
			this.colDataCreate.Visible = true;
			this.colDataCreate.VisibleIndex = 8;
			this.colDataCreate.Width = 113;
			// 
			// colDataPayTo
			// 
			this.colDataPayTo.FieldName = "DataPayTo";
			this.colDataPayTo.MinWidth = 26;
			this.colDataPayTo.Name = "colDataPayTo";
			this.colDataPayTo.OptionsColumn.AllowEdit = false;
			this.colDataPayTo.Visible = true;
			this.colDataPayTo.VisibleIndex = 9;
			this.colDataPayTo.Width = 113;
			// 
			// colOplata
			// 
			this.colOplata.FieldName = "Oplata";
			this.colOplata.MinWidth = 26;
			this.colOplata.Name = "colOplata";
			this.colOplata.OptionsColumn.AllowEdit = false;
			this.colOplata.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Oplata", "{0:c2}")});
			this.colOplata.Visible = true;
			this.colOplata.VisibleIndex = 11;
			this.colOplata.Width = 113;
			// 
			// colIsShipped
			// 
			this.colIsShipped.FieldName = "IsShipped";
			this.colIsShipped.Name = "colIsShipped";
			this.colIsShipped.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			this.colIsShipped.Visible = true;
			this.colIsShipped.VisibleIndex = 12;
			this.colIsShipped.Width = 55;
			// 
			// colOplataDate
			// 
			this.colOplataDate.FieldName = "OplataDate";
			this.colOplataDate.MinWidth = 26;
			this.colOplataDate.Name = "colOplataDate";
			this.colOplataDate.OptionsColumn.AllowEdit = false;
			this.colOplataDate.Visible = true;
			this.colOplataDate.VisibleIndex = 13;
			this.colOplataDate.Width = 113;
			// 
			// colRest
			// 
			this.colRest.FieldName = "Rest";
			this.colRest.MinWidth = 26;
			this.colRest.Name = "colRest";
			this.colRest.OptionsColumn.AllowEdit = false;
			this.colRest.OptionsColumn.ReadOnly = true;
			this.colRest.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Rest", "{0:c2}")});
			this.colRest.Visible = true;
			this.colRest.VisibleIndex = 14;
			this.colRest.Width = 113;
			// 
			// colFirmaName
			// 
			this.colFirmaName.FieldName = "FirmaName";
			this.colFirmaName.MinWidth = 26;
			this.colFirmaName.Name = "colFirmaName";
			this.colFirmaName.OptionsColumn.AllowEdit = false;
			this.colFirmaName.Visible = true;
			this.colFirmaName.VisibleIndex = 15;
			this.colFirmaName.Width = 113;
			// 
			// colComment
			// 
			this.colComment.FieldName = "Comment";
			this.colComment.MinWidth = 18;
			this.colComment.Name = "colComment";
			this.colComment.Visible = true;
			this.colComment.VisibleIndex = 16;
			this.colComment.Width = 94;
			// 
			// colUser
			// 
			this.colUser.FieldName = "User";
			this.colUser.MinWidth = 23;
			this.colUser.Name = "colUser";
			this.colUser.OptionsColumn.AllowEdit = false;
			this.colUser.Visible = true;
			this.colUser.VisibleIndex = 17;
			this.colUser.Width = 86;
			// 
			// coldtc
			// 
			this.coldtc.FieldName = "dtc";
			this.coldtc.MinWidth = 26;
			this.coldtc.Name = "coldtc";
			this.coldtc.OptionsColumn.AllowEdit = false;
			this.coldtc.ToolTip = "Дата создания записи в базе данных";
			this.coldtc.Visible = true;
			this.coldtc.VisibleIndex = 18;
			this.coldtc.Width = 113;
			// 
			// lbSchetLines
			// 
			this.lbSchetLines.Location = new System.Drawing.Point(3, 4);
			this.lbSchetLines.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.lbSchetLines.Name = "lbSchetLines";
			this.lbSchetLines.Size = new System.Drawing.Size(117, 20);
			this.lbSchetLines.TabIndex = 3;
			this.lbSchetLines.Text = "Товары и услуги:";
			// 
			// gcSchetLines
			// 
			this.gcSchetLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gcSchetLines.DataSource = this.cSchetLineBindingSource;
			this.gcSchetLines.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gcSchetLines.Location = new System.Drawing.Point(3, 36);
			this.gcSchetLines.MainView = this.gvSchetLines;
			this.gcSchetLines.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gcSchetLines.Name = "gcSchetLines";
			this.gcSchetLines.Size = new System.Drawing.Size(399, 276);
			this.gcSchetLines.TabIndex = 2;
			this.gcSchetLines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSchetLines});
			// 
			// gvSchetLines
			// 
			this.gvSchetLines.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNomenklatura,
            this.colQuantity,
            this.colPrice});
			this.gvSchetLines.DetailHeight = 539;
			this.gvSchetLines.FixedLineWidth = 4;
			this.gvSchetLines.GridControl = this.gcSchetLines;
			this.gvSchetLines.Name = "gvSchetLines";
			this.gvSchetLines.OptionsBehavior.Editable = false;
			this.gvSchetLines.OptionsView.ShowGroupPanel = false;
			// 
			// lbOplatas
			// 
			this.lbOplatas.Location = new System.Drawing.Point(3, 336);
			this.lbOplatas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.lbOplatas.Name = "lbOplatas";
			this.lbOplatas.Size = new System.Drawing.Size(56, 20);
			this.lbOplatas.TabIndex = 3;
			this.lbOplatas.Text = "Оплаты:";
			// 
			// gcOplatas
			// 
			this.gcOplatas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gcOplatas.DataSource = this.cOplataBindingSource;
			this.gcOplatas.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gcOplatas.Location = new System.Drawing.Point(3, 364);
			this.gcOplatas.MainView = this.gvOplatas;
			this.gcOplatas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gcOplatas.Name = "gcOplatas";
			this.gcOplatas.Size = new System.Drawing.Size(399, 216);
			this.gcOplatas.TabIndex = 0;
			this.gcOplatas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOplatas});
			// 
			// gvOplatas
			// 
			this.gvOplatas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSumma1,
            this.colData});
			this.gvOplatas.DetailHeight = 539;
			this.gvOplatas.FixedLineWidth = 4;
			this.gvOplatas.GridControl = this.gcOplatas;
			this.gvOplatas.Name = "gvOplatas";
			this.gvOplatas.OptionsBehavior.Editable = false;
			this.gvOplatas.OptionsView.ShowGroupPanel = false;
			this.gvOplatas.Tag = "1";
			// 
			// lbComment
			// 
			this.lbComment.Location = new System.Drawing.Point(3, 596);
			this.lbComment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.lbComment.Name = "lbComment";
			this.lbComment.Size = new System.Drawing.Size(101, 20);
			this.lbComment.TabIndex = 3;
			this.lbComment.Text = "Комментарий:";
			// 
			// txtComment
			// 
			this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtComment.Location = new System.Drawing.Point(3, 628);
			this.txtComment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(399, 144);
			this.txtComment.TabIndex = 1;
			// 
			// cSchetLineBindingSource
			// 
			this.cSchetLineBindingSource.DataSource = typeof(SC.Common.Model.CSchetLine);
			// 
			// colNomenklatura
			// 
			this.colNomenklatura.FieldName = "Nomenklatura";
			this.colNomenklatura.Name = "colNomenklatura";
			this.colNomenklatura.Visible = true;
			this.colNomenklatura.VisibleIndex = 0;
			// 
			// colQuantity
			// 
			this.colQuantity.FieldName = "Quantity";
			this.colQuantity.Name = "colQuantity";
			this.colQuantity.Visible = true;
			this.colQuantity.VisibleIndex = 1;
			// 
			// colPrice
			// 
			this.colPrice.FieldName = "Price";
			this.colPrice.Name = "colPrice";
			this.colPrice.Visible = true;
			this.colPrice.VisibleIndex = 2;
			// 
			// cOplataBindingSource
			// 
			this.cOplataBindingSource.DataSource = typeof(SC.Common.Model.COplata);
			// 
			// colSumma1
			// 
			this.colSumma1.FieldName = "Summa";
			this.colSumma1.Name = "colSumma1";
			this.colSumma1.Visible = true;
			this.colSumma1.VisibleIndex = 0;
			// 
			// colData
			// 
			this.colData.FieldName = "Data";
			this.colData.Name = "colData";
			this.colData.Visible = true;
			this.colData.VisibleIndex = 1;
			// 
			// PageScheta
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.sccScheta);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "PageScheta";
			this.Size = new System.Drawing.Size(1400, 600);
			((System.ComponentModel.ISupportInitialize)(this.sccScheta)).EndInit();
			this.sccScheta.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcScheta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cSchetBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvScheta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gcSchetLines)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvSchetLines)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gcOplatas)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvOplatas)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cSchetLineBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cOplataBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SplitContainerControl sccScheta;
		private DevExpress.XtraGrid.GridControl gcScheta;
		private DevExpress.XtraGrid.Views.Grid.GridView gvScheta;
		private DevExpress.XtraEditors.LabelControl lbOplatas;
		private DevExpress.XtraEditors.LabelControl lbComment;
		private DevExpress.XtraEditors.LabelControl lbSchetLines;
		private DevExpress.XtraGrid.GridControl gcSchetLines;
		private DevExpress.XtraGrid.Views.Grid.GridView gvSchetLines;
		private DevExpress.XtraEditors.MemoEdit txtComment;
		private DevExpress.XtraGrid.GridControl gcOplatas;
		private DevExpress.XtraGrid.Views.Grid.GridView gvOplatas;
		private System.Windows.Forms.BindingSource cSchetBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colID;
		private DevExpress.XtraGrid.Columns.GridColumn colSupplierName;
		private DevExpress.XtraGrid.Columns.GridColumn colDetailName;
		private DevExpress.XtraGrid.Columns.GridColumn colStRashName;
		private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
		private DevExpress.XtraGrid.Columns.GridColumn colNomer;
		private DevExpress.XtraGrid.Columns.GridColumn colNomerInternal;
		private DevExpress.XtraGrid.Columns.GridColumn colDataCreate;
		private DevExpress.XtraGrid.Columns.GridColumn colDataPayTo;
		private DevExpress.XtraGrid.Columns.GridColumn colSumma;
		private DevExpress.XtraGrid.Columns.GridColumn colOplata;
		private DevExpress.XtraGrid.Columns.GridColumn colOplataDate;
		private DevExpress.XtraGrid.Columns.GridColumn colRest;
		private DevExpress.XtraGrid.Columns.GridColumn colFirmaName;
		private DevExpress.XtraGrid.Columns.GridColumn coldtc;
		private DevExpress.XtraGrid.Columns.GridColumn coldtu;
		private DevExpress.XtraGrid.Columns.GridColumn colUser;
		private DevExpress.XtraGrid.Columns.GridColumn colCategory;
		private DevExpress.XtraGrid.Columns.GridColumn colComment;
		private DevExpress.XtraGrid.Columns.GridColumn colIsShipped;
		private System.Windows.Forms.BindingSource cSchetLineBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colNomenklatura;
		private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
		private DevExpress.XtraGrid.Columns.GridColumn colPrice;
		private System.Windows.Forms.BindingSource cOplataBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colSumma1;
		private DevExpress.XtraGrid.Columns.GridColumn colData;
	}
}
