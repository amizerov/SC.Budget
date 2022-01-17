namespace SC.Zakup.Views
{
	partial class PageNaklads
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
			this.sccNaklads = new DevExpress.XtraEditors.SplitContainerControl();
			this.gcNaklads = new DevExpress.XtraGrid.GridControl();
			this.cNakladnayaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvNaklads = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colDocDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDocNumber = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colKontragent = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colFirmaName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colFromProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colFromObjectName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colObjectName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCost1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCostAdditional = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCostTotal = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gcNakladLines = new DevExpress.XtraGrid.GridControl();
			this.cNakLineBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvNakladLines = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colNomenkl = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInventoryNum = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colQuantityOnSklad = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPriceAdditional = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPriceTotal = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCost = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.sccNaklads)).BeginInit();
			this.sccNaklads.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcNaklads)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cNakladnayaBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvNaklads)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gcNakladLines)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cNakLineBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvNakladLines)).BeginInit();
			this.SuspendLayout();
			// 
			// sccNaklads
			// 
			this.sccNaklads.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sccNaklads.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
			this.sccNaklads.Location = new System.Drawing.Point(0, 0);
			this.sccNaklads.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.sccNaklads.Name = "sccNaklads";
			this.sccNaklads.Panel1.Controls.Add(this.gcNaklads);
			this.sccNaklads.Panel1.Text = "Panel1";
			this.sccNaklads.Panel2.Controls.Add(this.gcNakladLines);
			this.sccNaklads.Panel2.Text = "Panel2";
			this.sccNaklads.Size = new System.Drawing.Size(1400, 500);
			this.sccNaklads.SplitterPosition = 600;
			this.sccNaklads.TabIndex = 17;
			// 
			// gcNaklads
			// 
			this.gcNaklads.DataSource = this.cNakladnayaBindingSource;
			this.gcNaklads.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcNaklads.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.gcNaklads.Location = new System.Drawing.Point(0, 0);
			this.gcNaklads.MainView = this.gvNaklads;
			this.gcNaklads.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.gcNaklads.Name = "gcNaklads";
			this.gcNaklads.Size = new System.Drawing.Size(788, 500);
			this.gcNaklads.TabIndex = 0;
			this.gcNaklads.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNaklads});
			this.gcNaklads.DoubleClick += new System.EventHandler(this.GvNaklads_DoubleClick);
			// 
			// cNakladnayaBindingSource
			// 
			this.cNakladnayaBindingSource.DataSource = typeof(SC.Common.Model.CNakladnaya);
			// 
			// gvNaklads
			// 
			this.gvNaklads.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocDate,
            this.colDocNumber,
            this.colKontragent,
            this.colFirmaName,
            this.colFromProjectName,
            this.colFromObjectName,
            this.colProjectName,
            this.colObjectName,
            this.colCost1,
            this.colCostAdditional,
            this.colCostTotal,
            this.colUser});
			this.gvNaklads.DetailHeight = 539;
			this.gvNaklads.FixedLineWidth = 4;
			this.gvNaklads.GridControl = this.gcNaklads;
			this.gvNaklads.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, " / Накладных: {0}шт"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cost", null, " / Стоимость: {0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CostAdditional", null, "/ Доп.расходы: {0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CostTotal", null, "/ Итоговая стоимость: {0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", this.colDocNumber, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cost", this.colCost1, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CostAdditional", this.colCostAdditional, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CostTotal", this.colCostTotal, "{0:c2}")});
			this.gvNaklads.Name = "gvNaklads";
			this.gvNaklads.OptionsBehavior.Editable = false;
			this.gvNaklads.OptionsSelection.MultiSelect = true;
			this.gvNaklads.OptionsView.ShowFooter = true;
			this.gvNaklads.Tag = "3";
			this.gvNaklads.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvNaklads_RowStyle);
			this.gvNaklads.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GvNaklads_FocusedRowChanged);
			// 
			// colDocDate
			// 
			this.colDocDate.FieldName = "DocDate";
			this.colDocDate.MinWidth = 23;
			this.colDocDate.Name = "colDocDate";
			this.colDocDate.Visible = true;
			this.colDocDate.VisibleIndex = 0;
			this.colDocDate.Width = 86;
			// 
			// colDocNumber
			// 
			this.colDocNumber.FieldName = "DocNumber";
			this.colDocNumber.MinWidth = 23;
			this.colDocNumber.Name = "colDocNumber";
			this.colDocNumber.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DocNumber", "{0}")});
			this.colDocNumber.Visible = true;
			this.colDocNumber.VisibleIndex = 1;
			this.colDocNumber.Width = 86;
			// 
			// colKontragent
			// 
			this.colKontragent.FieldName = "Kontragent";
			this.colKontragent.Name = "colKontragent";
			this.colKontragent.Visible = true;
			this.colKontragent.VisibleIndex = 2;
			// 
			// colFirmaName
			// 
			this.colFirmaName.FieldName = "FirmaName";
			this.colFirmaName.Name = "colFirmaName";
			this.colFirmaName.Visible = true;
			this.colFirmaName.VisibleIndex = 3;
			// 
			// colFromProjectName
			// 
			this.colFromProjectName.FieldName = "FromProjectName";
			this.colFromProjectName.Name = "colFromProjectName";
			this.colFromProjectName.Visible = true;
			this.colFromProjectName.VisibleIndex = 4;
			// 
			// colFromObjectName
			// 
			this.colFromObjectName.FieldName = "FromObjectName";
			this.colFromObjectName.Name = "colFromObjectName";
			this.colFromObjectName.Visible = true;
			this.colFromObjectName.VisibleIndex = 5;
			// 
			// colProjectName
			// 
			this.colProjectName.FieldName = "ProjectName";
			this.colProjectName.MinWidth = 23;
			this.colProjectName.Name = "colProjectName";
			this.colProjectName.Visible = true;
			this.colProjectName.VisibleIndex = 6;
			this.colProjectName.Width = 86;
			// 
			// colObjectName
			// 
			this.colObjectName.FieldName = "ObjectName";
			this.colObjectName.MinWidth = 23;
			this.colObjectName.Name = "colObjectName";
			this.colObjectName.Visible = true;
			this.colObjectName.VisibleIndex = 7;
			this.colObjectName.Width = 86;
			// 
			// colCost1
			// 
			this.colCost1.FieldName = "Cost";
			this.colCost1.Name = "colCost1";
			this.colCost1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cost", "{0:c2}")});
			this.colCost1.Visible = true;
			this.colCost1.VisibleIndex = 8;
			// 
			// colCostAdditional
			// 
			this.colCostAdditional.FieldName = "CostAdditional";
			this.colCostAdditional.Name = "colCostAdditional";
			this.colCostAdditional.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CostAdditional", "{0:c2}")});
			this.colCostAdditional.Visible = true;
			this.colCostAdditional.VisibleIndex = 9;
			// 
			// colCostTotal
			// 
			this.colCostTotal.FieldName = "CostTotal";
			this.colCostTotal.Name = "colCostTotal";
			this.colCostTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CostTotal", "{0:c2}")});
			this.colCostTotal.Visible = true;
			this.colCostTotal.VisibleIndex = 10;
			// 
			// colUser
			// 
			this.colUser.FieldName = "User";
			this.colUser.MinWidth = 23;
			this.colUser.Name = "colUser";
			this.colUser.Visible = true;
			this.colUser.VisibleIndex = 11;
			this.colUser.Width = 86;
			// 
			// gcNakladLines
			// 
			this.gcNakladLines.DataSource = this.cNakLineBindingSource;
			this.gcNakladLines.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcNakladLines.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.gcNakladLines.Location = new System.Drawing.Point(0, 0);
			this.gcNakladLines.MainView = this.gvNakladLines;
			this.gcNakladLines.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.gcNakladLines.Name = "gcNakladLines";
			this.gcNakladLines.Size = new System.Drawing.Size(600, 500);
			this.gcNakladLines.TabIndex = 0;
			this.gcNakladLines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNakladLines});
			// 
			// cNakLineBindingSource
			// 
			this.cNakLineBindingSource.DataSource = typeof(SC.Common.Model.CNakladLine);
			// 
			// gvNakladLines
			// 
			this.gvNakladLines.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.gvNakladLines.Appearance.FocusedRow.Options.UseBackColor = true;
			this.gvNakladLines.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.gvNakladLines.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.gvNakladLines.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.gvNakladLines.Appearance.SelectedRow.Options.UseBackColor = true;
			this.gvNakladLines.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNomenkl,
            this.colCategory,
            this.colMeasure,
            this.colInventoryNum,
            this.colQuantity,
            this.colQuantityOnSklad,
            this.colPrice,
            this.colPriceAdditional,
            this.colPriceTotal,
            this.colCost});
			this.gvNakladLines.DetailHeight = 539;
			this.gvNakladLines.FixedLineWidth = 4;
			this.gvNakladLines.GridControl = this.gcNakladLines;
			this.gvNakladLines.Name = "gvNakladLines";
			this.gvNakladLines.OptionsView.ShowFooter = true;
			this.gvNakladLines.OptionsView.ShowGroupPanel = false;
			this.gvNakladLines.Tag = "3";
			this.gvNakladLines.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvNakladLines_CustomDrawCell);
			this.gvNakladLines.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvNakladLines_ShowingEditor);
			this.gvNakladLines.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.GvNakladLines_CellValueChanged);
			this.gvNakladLines.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.GvNakladLines_ValidatingEditor);
			// 
			// colNomenkl
			// 
			this.colNomenkl.FieldName = "Nomenkl";
			this.colNomenkl.MinWidth = 23;
			this.colNomenkl.Name = "colNomenkl";
			this.colNomenkl.OptionsColumn.AllowEdit = false;
			this.colNomenkl.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Nomenkl", "{0} поз.")});
			this.colNomenkl.Visible = true;
			this.colNomenkl.VisibleIndex = 0;
			this.colNomenkl.Width = 86;
			// 
			// colCategory
			// 
			this.colCategory.FieldName = "Category";
			this.colCategory.MinWidth = 23;
			this.colCategory.Name = "colCategory";
			this.colCategory.Visible = true;
			this.colCategory.VisibleIndex = 1;
			this.colCategory.Width = 86;
			// 
			// colMeasure
			// 
			this.colMeasure.FieldName = "Measure";
			this.colMeasure.MinWidth = 23;
			this.colMeasure.Name = "colMeasure";
			this.colMeasure.OptionsColumn.AllowEdit = false;
			this.colMeasure.Visible = true;
			this.colMeasure.VisibleIndex = 2;
			this.colMeasure.Width = 86;
			// 
			// colInventoryNum
			// 
			this.colInventoryNum.FieldName = "InventoryNum";
			this.colInventoryNum.MinWidth = 23;
			this.colInventoryNum.Name = "colInventoryNum";
			this.colInventoryNum.Visible = true;
			this.colInventoryNum.VisibleIndex = 3;
			this.colInventoryNum.Width = 86;
			// 
			// colQuantity
			// 
			this.colQuantity.FieldName = "Quantity";
			this.colQuantity.MinWidth = 23;
			this.colQuantity.Name = "colQuantity";
			this.colQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:N0}")});
			this.colQuantity.Visible = true;
			this.colQuantity.VisibleIndex = 4;
			this.colQuantity.Width = 86;
			// 
			// colQuantityOnSklad
			// 
			this.colQuantityOnSklad.FieldName = "QuantityOnSklad";
			this.colQuantityOnSklad.MinWidth = 23;
			this.colQuantityOnSklad.Name = "colQuantityOnSklad";
			this.colQuantityOnSklad.OptionsColumn.AllowEdit = false;
			this.colQuantityOnSklad.Visible = true;
			this.colQuantityOnSklad.VisibleIndex = 5;
			this.colQuantityOnSklad.Width = 86;
			// 
			// colPrice
			// 
			this.colPrice.FieldName = "Price";
			this.colPrice.MinWidth = 23;
			this.colPrice.Name = "colPrice";
			this.colPrice.OptionsColumn.AllowEdit = false;
			this.colPrice.Visible = true;
			this.colPrice.VisibleIndex = 6;
			this.colPrice.Width = 86;
			// 
			// colPriceAdditional
			// 
			this.colPriceAdditional.FieldName = "PriceAdditional";
			this.colPriceAdditional.Name = "colPriceAdditional";
			this.colPriceAdditional.OptionsColumn.AllowEdit = false;
			this.colPriceAdditional.Visible = true;
			this.colPriceAdditional.VisibleIndex = 7;
			// 
			// colPriceTotal
			// 
			this.colPriceTotal.FieldName = "PriceTotal";
			this.colPriceTotal.Name = "colPriceTotal";
			this.colPriceTotal.OptionsColumn.AllowEdit = false;
			this.colPriceTotal.Visible = true;
			this.colPriceTotal.VisibleIndex = 8;
			// 
			// colCost
			// 
			this.colCost.FieldName = "Cost";
			this.colCost.MinWidth = 23;
			this.colCost.Name = "colCost";
			this.colCost.OptionsColumn.AllowEdit = false;
			this.colCost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cost", "{0:#.##}")});
			this.colCost.Visible = true;
			this.colCost.VisibleIndex = 9;
			this.colCost.Width = 86;
			// 
			// PageNaklads
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.sccNaklads);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "PageNaklads";
			this.Size = new System.Drawing.Size(1400, 500);
			((System.ComponentModel.ISupportInitialize)(this.sccNaklads)).EndInit();
			this.sccNaklads.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcNaklads)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cNakladnayaBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvNaklads)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gcNakladLines)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cNakLineBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvNakladLines)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SplitContainerControl sccNaklads;
		private DevExpress.XtraGrid.GridControl gcNaklads;
		private DevExpress.XtraGrid.Views.Grid.GridView gvNaklads;
		private DevExpress.XtraGrid.GridControl gcNakladLines;
		private DevExpress.XtraGrid.Views.Grid.GridView gvNakladLines;
		private DevExpress.XtraGrid.Columns.GridColumn colNomenkl;
		private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
		private DevExpress.XtraGrid.Columns.GridColumn colQuantityOnSklad;
		private DevExpress.XtraGrid.Columns.GridColumn colPrice;
		private System.Windows.Forms.BindingSource cNakLineBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colCost;
		private DevExpress.XtraGrid.Columns.GridColumn colMeasure;
		private DevExpress.XtraGrid.Columns.GridColumn colCategory;
		private DevExpress.XtraGrid.Columns.GridColumn colInventoryNum;
		private System.Windows.Forms.BindingSource cNakladnayaBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colDocDate;
		private DevExpress.XtraGrid.Columns.GridColumn colDocNumber;
		private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
		private DevExpress.XtraGrid.Columns.GridColumn colObjectName;
		private DevExpress.XtraGrid.Columns.GridColumn colUser;
		private DevExpress.XtraGrid.Columns.GridColumn colPriceAdditional;
		private DevExpress.XtraGrid.Columns.GridColumn colPriceTotal;
		private DevExpress.XtraGrid.Columns.GridColumn colFromProjectName;
		private DevExpress.XtraGrid.Columns.GridColumn colFromObjectName;
		private DevExpress.XtraGrid.Columns.GridColumn colCost1;
		private DevExpress.XtraGrid.Columns.GridColumn colCostAdditional;
		private DevExpress.XtraGrid.Columns.GridColumn colCostTotal;
		private DevExpress.XtraGrid.Columns.GridColumn colKontragent;
		private DevExpress.XtraGrid.Columns.GridColumn colFirmaName;
	}
}
