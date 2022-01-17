namespace SC.Zakup.Views
{
	partial class PageOplatas
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
			this.gcOplatas = new DevExpress.XtraGrid.GridControl();
			this.cOplataBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvOplatas = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colSchet_Nomer = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSchet_NomerInternal = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDetailName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colFirmaName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSchet_ID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSumma = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colData = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
			this.coldtc = new DevExpress.XtraGrid.Columns.GridColumn();
			this.coldtu = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.gcOplatas)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cOplataBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvOplatas)).BeginInit();
			this.SuspendLayout();
			// 
			// gcOplatas
			// 
			this.gcOplatas.DataSource = this.cOplataBindingSource;
			this.gcOplatas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcOplatas.Location = new System.Drawing.Point(0, 0);
			this.gcOplatas.MainView = this.gvOplatas;
			this.gcOplatas.Name = "gcOplatas";
			this.gcOplatas.Size = new System.Drawing.Size(1000, 300);
			this.gcOplatas.TabIndex = 0;
			this.gcOplatas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOplatas});
			// 
			// cOplataBindingSource
			// 
			this.cOplataBindingSource.DataSource = typeof(SC.Common.Model.COplata);
			// 
			// gvOplatas
			// 
			this.gvOplatas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSchet_Nomer,
            this.colSchet_NomerInternal,
            this.colDetailName,
            this.colFirmaName,
            this.colSupplierName,
            this.colSchet_ID,
            this.colID,
            this.colSumma,
            this.colData,
            this.colUser,
            this.coldtc,
            this.coldtu});
			this.gvOplatas.GridControl = this.gcOplatas;
			this.gvOplatas.Name = "gvOplatas";
			this.gvOplatas.OptionsView.ShowFooter = true;
			this.gvOplatas.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colData, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gvOplatas.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvOplatas_CellValueChanged);
			// 
			// colSchet_Nomer
			// 
			this.colSchet_Nomer.FieldName = "Schet_Nomer";
			this.colSchet_Nomer.Name = "colSchet_Nomer";
			this.colSchet_Nomer.OptionsColumn.AllowEdit = false;
			this.colSchet_Nomer.Visible = true;
			this.colSchet_Nomer.VisibleIndex = 4;
			// 
			// colSchet_NomerInternal
			// 
			this.colSchet_NomerInternal.FieldName = "Schet_NomerInternal";
			this.colSchet_NomerInternal.Name = "colSchet_NomerInternal";
			this.colSchet_NomerInternal.OptionsColumn.AllowEdit = false;
			this.colSchet_NomerInternal.Visible = true;
			this.colSchet_NomerInternal.VisibleIndex = 5;
			// 
			// colDetailName
			// 
			this.colDetailName.FieldName = "DetailName";
			this.colDetailName.Name = "colDetailName";
			this.colDetailName.OptionsColumn.AllowEdit = false;
			this.colDetailName.Visible = true;
			this.colDetailName.VisibleIndex = 6;
			// 
			// colFirmaName
			// 
			this.colFirmaName.FieldName = "FirmaName";
			this.colFirmaName.Name = "colFirmaName";
			this.colFirmaName.OptionsColumn.AllowEdit = false;
			this.colFirmaName.Visible = true;
			this.colFirmaName.VisibleIndex = 7;
			// 
			// colSupplierName
			// 
			this.colSupplierName.FieldName = "SupplierName";
			this.colSupplierName.Name = "colSupplierName";
			this.colSupplierName.OptionsColumn.AllowEdit = false;
			this.colSupplierName.Visible = true;
			this.colSupplierName.VisibleIndex = 8;
			// 
			// colSchet_ID
			// 
			this.colSchet_ID.FieldName = "Schet_ID";
			this.colSchet_ID.Name = "colSchet_ID";
			this.colSchet_ID.Visible = true;
			this.colSchet_ID.VisibleIndex = 3;
			// 
			// colID
			// 
			this.colID.FieldName = "ID";
			this.colID.Name = "colID";
			this.colID.OptionsColumn.AllowEdit = false;
			this.colID.Visible = true;
			this.colID.VisibleIndex = 2;
			// 
			// colSumma
			// 
			this.colSumma.FieldName = "Summa";
			this.colSumma.Name = "colSumma";
			this.colSumma.OptionsColumn.AllowEdit = false;
			this.colSumma.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Summa", "{0:c2}")});
			this.colSumma.Visible = true;
			this.colSumma.VisibleIndex = 1;
			// 
			// colData
			// 
			this.colData.FieldName = "Data";
			this.colData.Name = "colData";
			this.colData.OptionsColumn.AllowEdit = false;
			this.colData.Visible = true;
			this.colData.VisibleIndex = 0;
			// 
			// colUser
			// 
			this.colUser.FieldName = "User";
			this.colUser.Name = "colUser";
			this.colUser.OptionsColumn.AllowEdit = false;
			this.colUser.Visible = true;
			this.colUser.VisibleIndex = 9;
			// 
			// coldtc
			// 
			this.coldtc.FieldName = "dtc";
			this.coldtc.Name = "coldtc";
			this.coldtc.OptionsColumn.AllowEdit = false;
			this.coldtc.Visible = true;
			this.coldtc.VisibleIndex = 10;
			// 
			// coldtu
			// 
			this.coldtu.FieldName = "dtu";
			this.coldtu.Name = "coldtu";
			this.coldtu.OptionsColumn.AllowEdit = false;
			this.coldtu.Visible = true;
			this.coldtu.VisibleIndex = 11;
			// 
			// PageOplatas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gcOplatas);
			this.Name = "PageOplatas";
			this.Size = new System.Drawing.Size(1000, 300);
			((System.ComponentModel.ISupportInitialize)(this.gcOplatas)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cOplataBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvOplatas)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGrid.GridControl gcOplatas;
		private DevExpress.XtraGrid.Views.Grid.GridView gvOplatas;
		private System.Windows.Forms.BindingSource cOplataBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colSchet_Nomer;
		private DevExpress.XtraGrid.Columns.GridColumn colSchet_NomerInternal;
		private DevExpress.XtraGrid.Columns.GridColumn colDetailName;
		private DevExpress.XtraGrid.Columns.GridColumn colFirmaName;
		private DevExpress.XtraGrid.Columns.GridColumn colSupplierName;
		private DevExpress.XtraGrid.Columns.GridColumn colSchet_ID;
		private DevExpress.XtraGrid.Columns.GridColumn colID;
		private DevExpress.XtraGrid.Columns.GridColumn colSumma;
		private DevExpress.XtraGrid.Columns.GridColumn colData;
		private DevExpress.XtraGrid.Columns.GridColumn colUser;
		private DevExpress.XtraGrid.Columns.GridColumn coldtc;
		private DevExpress.XtraGrid.Columns.GridColumn coldtu;
	}
}
