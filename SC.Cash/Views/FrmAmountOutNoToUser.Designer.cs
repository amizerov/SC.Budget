namespace SC.Cash.Views
{
	partial class FrmAmountOutNoToUser
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAmountOutNoToUser));
			this.gcOperations = new DevExpress.XtraGrid.GridControl();
			this.cOperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvOperations = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colOutAmount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.gcOperations)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cOperationBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvOperations)).BeginInit();
			this.SuspendLayout();
			// 
			// gcOperations
			// 
			this.gcOperations.DataSource = this.cOperationBindingSource;
			this.gcOperations.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcOperations.Location = new System.Drawing.Point(0, 0);
			this.gcOperations.MainView = this.gvOperations;
			this.gcOperations.Name = "gcOperations";
			this.gcOperations.Size = new System.Drawing.Size(784, 453);
			this.gcOperations.TabIndex = 0;
			this.gcOperations.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOperations});
			// 
			// cOperationBindingSource
			// 
			this.cOperationBindingSource.DataSource = typeof(SC.Common.Model.COperation);
			// 
			// gvOperations
			// 
			this.gvOperations.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDateTime,
            this.colOutAmount,
            this.colCategory,
            this.colComment});
			this.gvOperations.GridControl = this.gcOperations;
			this.gvOperations.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutAmount", null, "(Расход: {0:c2})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutAmount", this.colOutAmount, "{0:c2}")});
			this.gvOperations.Name = "gvOperations";
			this.gvOperations.OptionsBehavior.Editable = false;
			this.gvOperations.OptionsView.ShowFooter = true;
			// 
			// colDateTime
			// 
			this.colDateTime.FieldName = "DateTime";
			this.colDateTime.Name = "colDateTime";
			this.colDateTime.Visible = true;
			this.colDateTime.VisibleIndex = 0;
			// 
			// colOutAmount
			// 
			this.colOutAmount.FieldName = "OutAmount";
			this.colOutAmount.Name = "colOutAmount";
			this.colOutAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutAmount", "{0:c2}")});
			this.colOutAmount.Visible = true;
			this.colOutAmount.VisibleIndex = 1;
			// 
			// colCategory
			// 
			this.colCategory.FieldName = "Category";
			this.colCategory.Name = "colCategory";
			this.colCategory.Visible = true;
			this.colCategory.VisibleIndex = 2;
			// 
			// colComment
			// 
			this.colComment.FieldName = "Comment";
			this.colComment.Name = "colComment";
			this.colComment.Visible = true;
			this.colComment.VisibleIndex = 3;
			// 
			// FrmAmountOutNoToUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 453);
			this.Controls.Add(this.gcOperations);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmAmountOutNoToUser";
			this.Text = "Операции без получателя";
			((System.ComponentModel.ISupportInitialize)(this.gcOperations)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cOperationBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvOperations)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGrid.GridControl gcOperations;
		private DevExpress.XtraGrid.Views.Grid.GridView gvOperations;
		private System.Windows.Forms.BindingSource cOperationBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colOutAmount;
		private DevExpress.XtraGrid.Columns.GridColumn colDateTime;
		private DevExpress.XtraGrid.Columns.GridColumn colCategory;
		private DevExpress.XtraGrid.Columns.GridColumn colComment;
	}
}