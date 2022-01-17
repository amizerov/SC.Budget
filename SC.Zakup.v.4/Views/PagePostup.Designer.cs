namespace SC.Zakup.Views
{
	partial class PagePostup
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
			this.sccPostup = new DevExpress.XtraEditors.SplitContainerControl();
			this.gcPostup = new DevExpress.XtraGrid.GridControl();
			this.cPostupleniyaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvPostup = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colDocDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colKontrgent = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSchet = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNomenkl1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCategory1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMeasure1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colQuantity1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPrice1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCost1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
			this.coldtc = new DevExpress.XtraGrid.Columns.GridColumn();
			this.coldtu = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnSelectObject = new DevExpress.XtraEditors.SimpleButton();
			this.gcNaklad = new DevExpress.XtraGrid.GridControl();
			this.cNakLineBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvNaklad = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colNomenkl = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInventoryNum1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCost = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnClearNakl = new DevExpress.XtraEditors.SimpleButton();
			this.btnNaklCreate = new DevExpress.XtraEditors.SimpleButton();
			this.colOrganization = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.sccPostup)).BeginInit();
			this.sccPostup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcPostup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cPostupleniyaBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPostup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gcNaklad)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cNakLineBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvNaklad)).BeginInit();
			this.SuspendLayout();
			// 
			// sccPostup
			// 
			this.sccPostup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sccPostup.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
			this.sccPostup.Location = new System.Drawing.Point(0, 0);
			this.sccPostup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.sccPostup.Name = "sccPostup";
			this.sccPostup.Panel1.Controls.Add(this.gcPostup);
			this.sccPostup.Panel1.Text = "Panel1";
			this.sccPostup.Panel2.Controls.Add(this.btnSelectObject);
			this.sccPostup.Panel2.Controls.Add(this.gcNaklad);
			this.sccPostup.Panel2.Controls.Add(this.btnClearNakl);
			this.sccPostup.Panel2.Controls.Add(this.btnNaklCreate);
			this.sccPostup.Panel2.Text = "Panel2";
			this.sccPostup.Size = new System.Drawing.Size(1925, 625);
			this.sccPostup.SplitterPosition = 825;
			this.sccPostup.TabIndex = 11;
			// 
			// gcPostup
			// 
			this.gcPostup.DataSource = this.cPostupleniyaBindingSource;
			this.gcPostup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcPostup.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gcPostup.Location = new System.Drawing.Point(0, 0);
			this.gcPostup.MainView = this.gvPostup;
			this.gcPostup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gcPostup.Name = "gcPostup";
			this.gcPostup.Size = new System.Drawing.Size(1085, 625);
			this.gcPostup.TabIndex = 0;
			this.gcPostup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPostup});
			this.gcPostup.DoubleClick += new System.EventHandler(this.GvPostup_DoubleClick);
			// 
			// cPostupleniyaBindingSource
			// 
			this.cPostupleniyaBindingSource.DataSource = typeof(SC.Common.Model.CPostupleniya);
			// 
			// gvPostup
			// 
			this.gvPostup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocDate,
            this.colKontrgent,
            this.colOrganization,
            this.colSchet,
            this.colNomenkl1,
            this.colCategory1,
            this.colMeasure1,
            this.colQuantity1,
            this.colPrice1,
            this.colCost1,
            this.colComment,
            this.colUser,
            this.coldtc,
            this.coldtu});
			this.gvPostup.DetailHeight = 674;
			this.gvPostup.FixedLineWidth = 4;
			this.gvPostup.GridControl = this.gcPostup;
			this.gvPostup.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "/ позиций: {0}шт"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cost", null, "/ На сумму {0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", this.colNomenkl1, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cost", this.colCost1, "{0:c2}")});
			this.gvPostup.Name = "gvPostup";
			this.gvPostup.OptionsBehavior.Editable = false;
			this.gvPostup.OptionsSelection.MultiSelect = true;
			this.gvPostup.OptionsView.ShowAutoFilterRow = true;
			this.gvPostup.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			this.gvPostup.OptionsView.ShowFooter = true;
			this.gvPostup.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDocDate, DevExpress.Data.ColumnSortOrder.Descending)});
			// 
			// colDocDate
			// 
			this.colDocDate.FieldName = "DocDate";
			this.colDocDate.MinWidth = 32;
			this.colDocDate.Name = "colDocDate";
			this.colDocDate.OptionsColumn.AllowEdit = false;
			this.colDocDate.Visible = true;
			this.colDocDate.VisibleIndex = 0;
			this.colDocDate.Width = 118;
			// 
			// colKontrgent
			// 
			this.colKontrgent.Caption = "Контрагент";
			this.colKontrgent.FieldName = "Kontragent";
			this.colKontrgent.MinWidth = 36;
			this.colKontrgent.Name = "colKontrgent";
			this.colKontrgent.OptionsColumn.AllowEdit = false;
			this.colKontrgent.Visible = true;
			this.colKontrgent.VisibleIndex = 1;
			this.colKontrgent.Width = 136;
			// 
			// colSchet
			// 
			this.colSchet.FieldName = "Schet";
			this.colSchet.MinWidth = 32;
			this.colSchet.Name = "colSchet";
			this.colSchet.OptionsColumn.AllowEdit = false;
			this.colSchet.Visible = true;
			this.colSchet.VisibleIndex = 4;
			this.colSchet.Width = 118;
			// 
			// colNomenkl1
			// 
			this.colNomenkl1.FieldName = "Nomenkl";
			this.colNomenkl1.MinWidth = 32;
			this.colNomenkl1.Name = "colNomenkl1";
			this.colNomenkl1.OptionsColumn.AllowEdit = false;
			this.colNomenkl1.Visible = true;
			this.colNomenkl1.VisibleIndex = 3;
			this.colNomenkl1.Width = 118;
			// 
			// colCategory1
			// 
			this.colCategory1.FieldName = "Category";
			this.colCategory1.MinWidth = 32;
			this.colCategory1.Name = "colCategory1";
			this.colCategory1.Visible = true;
			this.colCategory1.VisibleIndex = 5;
			this.colCategory1.Width = 118;
			// 
			// colMeasure1
			// 
			this.colMeasure1.FieldName = "Measure";
			this.colMeasure1.MinWidth = 32;
			this.colMeasure1.Name = "colMeasure1";
			this.colMeasure1.OptionsColumn.AllowEdit = false;
			this.colMeasure1.Visible = true;
			this.colMeasure1.VisibleIndex = 6;
			this.colMeasure1.Width = 118;
			// 
			// colQuantity1
			// 
			this.colQuantity1.FieldName = "Quantity";
			this.colQuantity1.MinWidth = 32;
			this.colQuantity1.Name = "colQuantity1";
			this.colQuantity1.OptionsColumn.AllowEdit = false;
			this.colQuantity1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Quantity", "{0} позиций")});
			this.colQuantity1.Visible = true;
			this.colQuantity1.VisibleIndex = 7;
			this.colQuantity1.Width = 118;
			// 
			// colPrice1
			// 
			this.colPrice1.FieldName = "Price";
			this.colPrice1.MinWidth = 32;
			this.colPrice1.Name = "colPrice1";
			this.colPrice1.OptionsColumn.AllowEdit = false;
			this.colPrice1.Visible = true;
			this.colPrice1.VisibleIndex = 8;
			this.colPrice1.Width = 118;
			// 
			// colCost1
			// 
			this.colCost1.FieldName = "Cost";
			this.colCost1.MinWidth = 32;
			this.colCost1.Name = "colCost1";
			this.colCost1.OptionsColumn.AllowEdit = false;
			this.colCost1.OptionsColumn.ReadOnly = true;
			this.colCost1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cost", "{0:c2}")});
			this.colCost1.Visible = true;
			this.colCost1.VisibleIndex = 9;
			this.colCost1.Width = 118;
			// 
			// colComment
			// 
			this.colComment.FieldName = "Comment";
			this.colComment.MinWidth = 25;
			this.colComment.Name = "colComment";
			this.colComment.Visible = true;
			this.colComment.VisibleIndex = 10;
			this.colComment.Width = 129;
			// 
			// colUser
			// 
			this.colUser.FieldName = "User";
			this.colUser.MinWidth = 27;
			this.colUser.Name = "colUser";
			this.colUser.Width = 103;
			// 
			// coldtc
			// 
			this.coldtc.FieldName = "dtc";
			this.coldtc.MinWidth = 27;
			this.coldtc.Name = "coldtc";
			this.coldtc.Width = 103;
			// 
			// coldtu
			// 
			this.coldtu.FieldName = "dtu";
			this.coldtu.MinWidth = 27;
			this.coldtu.Name = "coldtu";
			this.coldtu.Width = 103;
			// 
			// btnSelectObject
			// 
			this.btnSelectObject.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnSelectObject.Location = new System.Drawing.Point(0, 0);
			this.btnSelectObject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnSelectObject.Name = "btnSelectObject";
			this.btnSelectObject.Padding = new System.Windows.Forms.Padding(14, 12, 14, 12);
			this.btnSelectObject.Size = new System.Drawing.Size(825, 71);
			this.btnSelectObject.TabIndex = 1;
			this.btnSelectObject.Tag = "0";
			this.btnSelectObject.Text = "Выбрать объект";
			this.btnSelectObject.Click += new System.EventHandler(this.BtnSelectObject_Click);
			// 
			// gcNaklad
			// 
			this.gcNaklad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gcNaklad.DataSource = this.cNakLineBindingSource;
			this.gcNaklad.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gcNaklad.Location = new System.Drawing.Point(1, 82);
			this.gcNaklad.MainView = this.gvNaklad;
			this.gcNaklad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gcNaklad.Name = "gcNaklad";
			this.gcNaklad.Size = new System.Drawing.Size(821, 464);
			this.gcNaklad.TabIndex = 0;
			this.gcNaklad.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNaklad});
			// 
			// cNakLineBindingSource
			// 
			this.cNakLineBindingSource.DataSource = typeof(SC.Zakup.Models.CNakLine);
			// 
			// gvNaklad
			// 
			this.gvNaklad.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.gvNaklad.Appearance.FocusedRow.Options.UseBackColor = true;
			this.gvNaklad.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.gvNaklad.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.gvNaklad.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.gvNaklad.Appearance.SelectedRow.Options.UseBackColor = true;
			this.gvNaklad.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNomenkl,
            this.colCategory,
            this.colMeasure,
            this.colInventoryNum1,
            this.colQuantity,
            this.colPrice,
            this.colCost});
			this.gvNaklad.DetailHeight = 674;
			this.gvNaklad.FixedLineWidth = 4;
			this.gvNaklad.GridControl = this.gcNaklad;
			this.gvNaklad.Name = "gvNaklad";
			this.gvNaklad.OptionsView.ShowFooter = true;
			this.gvNaklad.OptionsView.ShowGroupPanel = false;
			this.gvNaklad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GvNaklad_KeyUp);
			this.gvNaklad.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.GvNakladLines_ValidatingEditor);
			// 
			// colNomenkl
			// 
			this.colNomenkl.FieldName = "Nomenkl";
			this.colNomenkl.MinWidth = 32;
			this.colNomenkl.Name = "colNomenkl";
			this.colNomenkl.OptionsColumn.AllowEdit = false;
			this.colNomenkl.Visible = true;
			this.colNomenkl.VisibleIndex = 0;
			this.colNomenkl.Width = 118;
			// 
			// colCategory
			// 
			this.colCategory.FieldName = "Category";
			this.colCategory.MinWidth = 32;
			this.colCategory.Name = "colCategory";
			this.colCategory.OptionsColumn.AllowEdit = false;
			this.colCategory.Visible = true;
			this.colCategory.VisibleIndex = 1;
			this.colCategory.Width = 136;
			// 
			// colMeasure
			// 
			this.colMeasure.FieldName = "Measure";
			this.colMeasure.MinWidth = 32;
			this.colMeasure.Name = "colMeasure";
			this.colMeasure.OptionsColumn.AllowEdit = false;
			this.colMeasure.Visible = true;
			this.colMeasure.VisibleIndex = 2;
			this.colMeasure.Width = 118;
			// 
			// colInventoryNum1
			// 
			this.colInventoryNum1.FieldName = "InventoryNum";
			this.colInventoryNum1.MinWidth = 27;
			this.colInventoryNum1.Name = "colInventoryNum1";
			this.colInventoryNum1.Visible = true;
			this.colInventoryNum1.VisibleIndex = 3;
			this.colInventoryNum1.Width = 103;
			// 
			// colQuantity
			// 
			this.colQuantity.FieldName = "Quantity";
			this.colQuantity.MinWidth = 32;
			this.colQuantity.Name = "colQuantity";
			this.colQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Quantity", "{0} позиций")});
			this.colQuantity.Visible = true;
			this.colQuantity.VisibleIndex = 4;
			this.colQuantity.Width = 118;
			// 
			// colPrice
			// 
			this.colPrice.FieldName = "Price";
			this.colPrice.MinWidth = 32;
			this.colPrice.Name = "colPrice";
			this.colPrice.OptionsColumn.AllowEdit = false;
			this.colPrice.Visible = true;
			this.colPrice.VisibleIndex = 5;
			this.colPrice.Width = 118;
			// 
			// colCost
			// 
			this.colCost.FieldName = "Cost";
			this.colCost.MinWidth = 32;
			this.colCost.Name = "colCost";
			this.colCost.OptionsColumn.AllowEdit = false;
			this.colCost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cost", "{0:c2}")});
			this.colCost.Visible = true;
			this.colCost.VisibleIndex = 6;
			this.colCost.Width = 118;
			// 
			// btnClearNakl
			// 
			this.btnClearNakl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClearNakl.Location = new System.Drawing.Point(520, 558);
			this.btnClearNakl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnClearNakl.Name = "btnClearNakl";
			this.btnClearNakl.Size = new System.Drawing.Size(136, 45);
			this.btnClearNakl.TabIndex = 2;
			this.btnClearNakl.Text = "Очистить";
			this.btnClearNakl.Click += new System.EventHandler(this.BtnClearNakl_Click);
			// 
			// btnNaklCreate
			// 
			this.btnNaklCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNaklCreate.Location = new System.Drawing.Point(667, 558);
			this.btnNaklCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnNaklCreate.Name = "btnNaklCreate";
			this.btnNaklCreate.Size = new System.Drawing.Size(153, 60);
			this.btnNaklCreate.TabIndex = 2;
			this.btnNaklCreate.Text = "Отгрузка";
			this.btnNaklCreate.Click += new System.EventHandler(this.BtnNaklCreate_Click);
			// 
			// colOrganization
			// 
			this.colOrganization.FieldName = "Organization";
			this.colOrganization.MinWidth = 25;
			this.colOrganization.Name = "colOrganization";
			this.colOrganization.Visible = true;
			this.colOrganization.VisibleIndex = 2;
			this.colOrganization.Width = 129;
			// 
			// PagePostup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.sccPostup);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "PagePostup";
			this.Size = new System.Drawing.Size(1925, 625);
			((System.ComponentModel.ISupportInitialize)(this.sccPostup)).EndInit();
			this.sccPostup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcPostup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cPostupleniyaBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvPostup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gcNaklad)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cNakLineBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvNaklad)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SplitContainerControl sccPostup;
		private DevExpress.XtraGrid.GridControl gcPostup;
		private DevExpress.XtraGrid.Views.Grid.GridView gvPostup;
		private DevExpress.XtraEditors.SimpleButton btnSelectObject;
		private DevExpress.XtraGrid.GridControl gcNaklad;
		private System.Windows.Forms.BindingSource cNakLineBindingSource;
		private DevExpress.XtraGrid.Views.Grid.GridView gvNaklad;
		private DevExpress.XtraGrid.Columns.GridColumn colNomenkl;
		private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
		private DevExpress.XtraGrid.Columns.GridColumn colPrice;
		private DevExpress.XtraEditors.SimpleButton btnClearNakl;
		private DevExpress.XtraEditors.SimpleButton btnNaklCreate;
		private DevExpress.XtraGrid.Columns.GridColumn colCost;
		private DevExpress.XtraGrid.Columns.GridColumn colMeasure;
		private System.Windows.Forms.BindingSource cPostupleniyaBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colSchet;
		private DevExpress.XtraGrid.Columns.GridColumn colNomenkl1;
		private DevExpress.XtraGrid.Columns.GridColumn colMeasure1;
		private DevExpress.XtraGrid.Columns.GridColumn colQuantity1;
		private DevExpress.XtraGrid.Columns.GridColumn colPrice1;
		private DevExpress.XtraGrid.Columns.GridColumn colCost1;
		private DevExpress.XtraGrid.Columns.GridColumn colDocDate;
        private DevExpress.XtraGrid.Columns.GridColumn colKontrgent;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory1;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn coldtc;
        private DevExpress.XtraGrid.Columns.GridColumn coldtu;
		private DevExpress.XtraGrid.Columns.GridColumn colComment;
		private DevExpress.XtraGrid.Columns.GridColumn colInventoryNum1;
		private DevExpress.XtraGrid.Columns.GridColumn colOrganization;
	}
}
