using SC.Common.Model;

namespace SC.Zakup.Views
{
	partial class PageObjects
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageObjects));
			this.sccObjects = new DevExpress.XtraEditors.SplitContainerControl();
			this.treeObjects = new DevExpress.XtraTreeList.TreeList();
			this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.colAddress = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.colPositionCount = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.colRukovodName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.objectProjectTreeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.cNakLineBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
			this.gcObjSklad = new DevExpress.XtraGrid.GridControl();
			this.gvObjSklad = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colDocDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNomenkl = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNaklad = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
			this.riCategory = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInventoryNum1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPriceAdditional = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPriceTotal = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCost = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.sccObjects)).BeginInit();
			this.sccObjects.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.treeObjects)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objectProjectTreeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cNakLineBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gcObjSklad)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvObjSklad)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.riCategory)).BeginInit();
			this.SuspendLayout();
			// 
			// sccObjects
			// 
			this.sccObjects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sccObjects.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
			this.sccObjects.Location = new System.Drawing.Point(0, 0);
			this.sccObjects.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.sccObjects.Name = "sccObjects";
			this.sccObjects.Panel1.Controls.Add(this.treeObjects);
			this.sccObjects.Panel1.Text = "Panel1";
			this.sccObjects.Panel2.Controls.Add(this.gcObjSklad);
			this.sccObjects.Panel2.Text = "Panel2";
			this.sccObjects.Size = new System.Drawing.Size(1200, 500);
			this.sccObjects.SplitterPosition = 600;
			this.sccObjects.TabIndex = 14;
			// 
			// treeObjects
			// 
			this.treeObjects.Appearance.Empty.BorderColor = System.Drawing.Color.Black;
			this.treeObjects.Appearance.Empty.Options.UseBorderColor = true;
			this.treeObjects.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.treeObjects.Appearance.FocusedRow.Options.UseBackColor = true;
			this.treeObjects.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.treeObjects.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.treeObjects.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.treeObjects.Appearance.SelectedRow.Options.UseBackColor = true;
			this.treeObjects.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName,
            this.colAddress,
            this.colPositionCount,
            this.colRukovodName});
			this.treeObjects.DataSource = this.objectProjectTreeBindingSource;
			this.treeObjects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeObjects.ImageIndexFieldName = "Type";
			this.treeObjects.KeyFieldName = "ViewModelID";
			this.treeObjects.Location = new System.Drawing.Point(0, 0);
			this.treeObjects.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.treeObjects.MinWidth = 26;
			this.treeObjects.Name = "treeObjects";
			this.treeObjects.OptionsBehavior.Editable = false;
			this.treeObjects.OptionsBehavior.PopulateServiceColumns = true;
			this.treeObjects.SelectImageList = this.imageCollection;
			this.treeObjects.Size = new System.Drawing.Size(588, 500);
			this.treeObjects.StateImageList = this.imageCollection;
			this.treeObjects.TabIndex = 0;
			this.treeObjects.TreeLevelWidth = 12;
			this.treeObjects.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeObjects_NodeCellStyle);
			this.treeObjects.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.TreeObjects_FocusedNodeChanged);
			this.treeObjects.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeObjects_CustomDrawNodeCell);
			// 
			// colName
			// 
			this.colName.FieldName = "Name";
			this.colName.Name = "colName";
			this.colName.Visible = true;
			this.colName.VisibleIndex = 0;
			// 
			// colAddress
			// 
			this.colAddress.FieldName = "Address";
			this.colAddress.Name = "colAddress";
			this.colAddress.Visible = true;
			this.colAddress.VisibleIndex = 1;
			// 
			// colPositionCount
			// 
			this.colPositionCount.AppearanceCell.Options.UseTextOptions = true;
			this.colPositionCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colPositionCount.FieldName = "PositionCount";
			this.colPositionCount.Name = "colPositionCount";
			this.colPositionCount.Visible = true;
			this.colPositionCount.VisibleIndex = 2;
			// 
			// colRukovodName
			// 
			this.colRukovodName.FieldName = "RukovodName";
			this.colRukovodName.Name = "colRukovodName";
			this.colRukovodName.Visible = true;
			this.colRukovodName.VisibleIndex = 3;
			// 
			// objectProjectTreeBindingSource
			// 
			this.objectProjectTreeBindingSource.DataSource = typeof(SC.Common.Model.ObjectProjectTree);
			// 
			// cNakLineBindingSource
			// 
			this.cNakLineBindingSource.DataSource = typeof(SC.Common.Model.CNakladLine);
			// 
			// imageCollection
			// 
			this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
			this.imageCollection.Images.SetKeyName(0, "case1.png");
			this.imageCollection.Images.SetKeyName(1, "Object16_2.png");
			this.imageCollection.Images.SetKeyName(2, "staff.png");
			this.imageCollection.Images.SetKeyName(3, "sum.png");
			// 
			// gcObjSklad
			// 
			this.gcObjSklad.DataSource = this.cNakLineBindingSource;
			this.gcObjSklad.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcObjSklad.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.gcObjSklad.Location = new System.Drawing.Point(0, 0);
			this.gcObjSklad.MainView = this.gvObjSklad;
			this.gcObjSklad.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.gcObjSklad.Name = "gcObjSklad";
			this.gcObjSklad.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riCategory});
			this.gcObjSklad.Size = new System.Drawing.Size(600, 500);
			this.gcObjSklad.TabIndex = 1;
			this.gcObjSklad.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvObjSklad});
			// 
			// gvObjSklad
			// 
			this.gvObjSklad.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.gvObjSklad.Appearance.FocusedRow.Options.UseBackColor = true;
			this.gvObjSklad.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.gvObjSklad.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.gvObjSklad.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.gvObjSklad.Appearance.SelectedRow.Options.UseBackColor = true;
			this.gvObjSklad.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocDate,
            this.colNomenkl,
            this.colNaklad,
            this.colQuantity,
            this.colCategory,
            this.colMeasure,
            this.colInventoryNum1,
            this.colPrice,
            this.colPriceAdditional,
            this.colPriceTotal,
            this.colCost,
            this.colComment});
			this.gvObjSklad.DetailHeight = 539;
			this.gvObjSklad.FixedLineWidth = 4;
			this.gvObjSklad.GridControl = this.gcObjSklad;
			this.gvObjSklad.Name = "gvObjSklad";
			this.gvObjSklad.OptionsView.ShowFooter = true;
			this.gvObjSklad.OptionsView.ShowGroupPanel = false;
			this.gvObjSklad.Tag = "1";
			this.gvObjSklad.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvObjSklad_ShowingEditor);
			this.gvObjSklad.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvObjSklad_CellValueChanged);
			// 
			// colDocDate
			// 
			this.colDocDate.FieldName = "DocDate";
			this.colDocDate.MinWidth = 23;
			this.colDocDate.Name = "colDocDate";
			this.colDocDate.OptionsColumn.AllowEdit = false;
			this.colDocDate.Visible = true;
			this.colDocDate.VisibleIndex = 0;
			// 
			// colNomenkl
			// 
			this.colNomenkl.FieldName = "Nomenkl";
			this.colNomenkl.MinWidth = 23;
			this.colNomenkl.Name = "colNomenkl";
			this.colNomenkl.OptionsColumn.AllowEdit = false;
			this.colNomenkl.Visible = true;
			this.colNomenkl.VisibleIndex = 1;
			this.colNomenkl.Width = 86;
			// 
			// colNaklad
			// 
			this.colNaklad.FieldName = "Naklad";
			this.colNaklad.MinWidth = 18;
			this.colNaklad.Name = "colNaklad";
			this.colNaklad.Visible = true;
			this.colNaklad.VisibleIndex = 2;
			this.colNaklad.Width = 94;
			// 
			// colQuantity
			// 
			this.colQuantity.FieldName = "Quantity";
			this.colQuantity.MinWidth = 23;
			this.colQuantity.Name = "colQuantity";
			this.colQuantity.OptionsColumn.AllowEdit = false;
			this.colQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Quantity", "{0} позиций")});
			this.colQuantity.Visible = true;
			this.colQuantity.VisibleIndex = 6;
			this.colQuantity.Width = 86;
			// 
			// colCategory
			// 
			this.colCategory.ColumnEdit = this.riCategory;
			this.colCategory.FieldName = "Category";
			this.colCategory.MinWidth = 19;
			this.colCategory.Name = "colCategory";
			this.colCategory.Visible = true;
			this.colCategory.VisibleIndex = 3;
			// 
			// riCategory
			// 
			this.riCategory.AutoHeight = false;
			this.riCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.riCategory.Name = "riCategory";
			// 
			// colMeasure
			// 
			this.colMeasure.FieldName = "Measure";
			this.colMeasure.MinWidth = 23;
			this.colMeasure.Name = "colMeasure";
			this.colMeasure.OptionsColumn.AllowEdit = false;
			this.colMeasure.Visible = true;
			this.colMeasure.VisibleIndex = 4;
			this.colMeasure.Width = 86;
			// 
			// colInventoryNum1
			// 
			this.colInventoryNum1.FieldName = "InventoryNum";
			this.colInventoryNum1.MinWidth = 19;
			this.colInventoryNum1.Name = "colInventoryNum1";
			this.colInventoryNum1.Visible = true;
			this.colInventoryNum1.VisibleIndex = 5;
			// 
			// colPrice
			// 
			this.colPrice.FieldName = "Price";
			this.colPrice.MinWidth = 23;
			this.colPrice.Name = "colPrice";
			this.colPrice.OptionsColumn.AllowEdit = false;
			this.colPrice.Visible = true;
			this.colPrice.VisibleIndex = 7;
			this.colPrice.Width = 86;
			// 
			// colPriceAdditional
			// 
			this.colPriceAdditional.FieldName = "PriceAdditional";
			this.colPriceAdditional.Name = "colPriceAdditional";
			this.colPriceAdditional.OptionsColumn.AllowEdit = false;
			this.colPriceAdditional.Visible = true;
			this.colPriceAdditional.VisibleIndex = 8;
			this.colPriceAdditional.Width = 55;
			// 
			// colPriceTotal
			// 
			this.colPriceTotal.FieldName = "PriceTotal";
			this.colPriceTotal.Name = "colPriceTotal";
			this.colPriceTotal.OptionsColumn.AllowEdit = false;
			this.colPriceTotal.Visible = true;
			this.colPriceTotal.VisibleIndex = 9;
			this.colPriceTotal.Width = 55;
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
			this.colCost.VisibleIndex = 10;
			this.colCost.Width = 86;
			// 
			// colComment
			// 
			this.colComment.FieldName = "Comment";
			this.colComment.MinWidth = 18;
			this.colComment.Name = "colComment";
			this.colComment.OptionsColumn.AllowEdit = false;
			this.colComment.Visible = true;
			this.colComment.VisibleIndex = 11;
			this.colComment.Width = 94;
			// 
			// PageObjects
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.sccObjects);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "PageObjects";
			this.Size = new System.Drawing.Size(1200, 500);
			((System.ComponentModel.ISupportInitialize)(this.sccObjects)).EndInit();
			this.sccObjects.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.treeObjects)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objectProjectTreeBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cNakLineBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gcObjSklad)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvObjSklad)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.riCategory)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SplitContainerControl sccObjects;
		private DevExpress.XtraTreeList.TreeList treeObjects;
		private DevExpress.XtraGrid.GridControl gcObjSklad;
		private DevExpress.XtraGrid.Views.Grid.GridView gvObjSklad;
		private System.Windows.Forms.BindingSource cNakLineBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colNomenkl;
		private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
		private DevExpress.XtraGrid.Columns.GridColumn colPrice;
		private DevExpress.XtraGrid.Columns.GridColumn colCost;
		private DevExpress.XtraGrid.Columns.GridColumn colMeasure;
		private DevExpress.XtraGrid.Columns.GridColumn colCategory;
		private DevExpress.XtraGrid.Columns.GridColumn colInventoryNum1;
		private DevExpress.XtraGrid.Columns.GridColumn colDocDate;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colAddress;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colRukovodName;
		private System.Windows.Forms.BindingSource objectProjectTreeBindingSource;
		private DevExpress.Utils.ImageCollection imageCollection;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colPositionCount;
		private DevExpress.XtraGrid.Columns.GridColumn colComment;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox riCategory;
		private DevExpress.XtraGrid.Columns.GridColumn colNaklad;
		private DevExpress.XtraGrid.Columns.GridColumn colPriceAdditional;
		private DevExpress.XtraGrid.Columns.GridColumn colPriceTotal;
	}
}
