namespace SC.Zakup.Views
{
	partial class PageSklad
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
			this.gvSklad = new DevExpress.XtraPivotGrid.PivotGridControl();
			this.cSkladPositionBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.fieldSklad = new DevExpress.XtraPivotGrid.PivotGridField();
			this.fieldNomenkl = new DevExpress.XtraPivotGrid.PivotGridField();
			this.fieldMeasure = new DevExpress.XtraPivotGrid.PivotGridField();
			this.fieldIndicator = new DevExpress.XtraPivotGrid.PivotGridField();
			this.fieldParameter = new DevExpress.XtraPivotGrid.PivotGridField();
			this.fieldValue = new DevExpress.XtraPivotGrid.PivotGridField();
			((System.ComponentModel.ISupportInitialize)(this.gvSklad)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cSkladPositionBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// gvSklad
			// 
			this.gvSklad.DataSource = this.cSkladPositionBindingSource;
			this.gvSklad.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gvSklad.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldSklad,
            this.fieldNomenkl,
            this.fieldMeasure,
            this.fieldIndicator,
            this.fieldParameter,
            this.fieldValue});
			this.gvSklad.Location = new System.Drawing.Point(0, 0);
			this.gvSklad.Name = "gvSklad";
			this.gvSklad.OptionsView.ShowColumnGrandTotalHeader = false;
			this.gvSklad.OptionsView.ShowColumnGrandTotals = false;
			this.gvSklad.OptionsView.ShowColumnHeaders = false;
			this.gvSklad.OptionsView.ShowColumnTotals = false;
			this.gvSklad.OptionsView.ShowDataHeaders = false;
			this.gvSklad.OptionsView.ShowFilterHeaders = false;
			this.gvSklad.OptionsView.ShowFilterSeparatorBar = false;
			this.gvSklad.OptionsView.ShowRowGrandTotalHeader = false;
			this.gvSklad.OptionsView.ShowRowGrandTotals = false;
			this.gvSklad.OptionsView.ShowRowTotals = false;
			this.gvSklad.Size = new System.Drawing.Size(1000, 500);
			this.gvSklad.TabIndex = 0;
			this.gvSklad.Tag = "1";
			this.gvSklad.CellDoubleClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.gvSklad_CellDoubleClick);
			this.gvSklad.PopupMenuShowing += new DevExpress.XtraPivotGrid.PopupMenuShowingEventHandler(this.gvSklad_PopupMenuShowing);
			// 
			// fieldSklad
			// 
			this.fieldSklad.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.fieldSklad.AreaIndex = 0;
			this.fieldSklad.FieldName = "Sklad";
			this.fieldSklad.Name = "fieldSklad";
			this.fieldSklad.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
			// 
			// fieldNomenkl
			// 
			this.fieldNomenkl.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.fieldNomenkl.AreaIndex = 1;
			this.fieldNomenkl.FieldName = "Nomenkl";
			this.fieldNomenkl.Name = "fieldNomenkl";
			this.fieldNomenkl.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
			// 
			// fieldMeasure
			// 
			this.fieldMeasure.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.fieldMeasure.AreaIndex = 2;
			this.fieldMeasure.FieldName = "Measure";
			this.fieldMeasure.Name = "fieldMeasure";
			this.fieldMeasure.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
			// 
			// fieldIndicator
			// 
			this.fieldIndicator.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.fieldIndicator.AreaIndex = 3;
			this.fieldIndicator.FieldName = "Indicator";
			this.fieldIndicator.Name = "fieldIndicator";
			this.fieldIndicator.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
			// 
			// fieldParameter
			// 
			this.fieldParameter.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.fieldParameter.AreaIndex = 0;
			this.fieldParameter.FieldName = "Parameter";
			this.fieldParameter.Name = "fieldParameter";
			this.fieldParameter.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
			// 
			// fieldValue
			// 
			this.fieldValue.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.fieldValue.AreaIndex = 0;
			this.fieldValue.CellFormat.FormatString = "{0:N0}";
			this.fieldValue.FieldName = "Value";
			this.fieldValue.Name = "fieldValue";
			this.fieldValue.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
			// 
			// PageSklad
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gvSklad);
			this.Name = "PageSklad";
			this.Size = new System.Drawing.Size(1000, 500);
			((System.ComponentModel.ISupportInitialize)(this.gvSklad)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cSkladPositionBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraPivotGrid.PivotGridControl gvSklad;
		private System.Windows.Forms.BindingSource cSkladPositionBindingSource;
		private DevExpress.XtraPivotGrid.PivotGridField fieldSklad;
		private DevExpress.XtraPivotGrid.PivotGridField fieldNomenkl;
		private DevExpress.XtraPivotGrid.PivotGridField fieldIndicator;
		private DevExpress.XtraPivotGrid.PivotGridField fieldMeasure;
		private DevExpress.XtraPivotGrid.PivotGridField fieldParameter;
		private DevExpress.XtraPivotGrid.PivotGridField fieldValue;
	}
}
