namespace SC.Zakup.Views
{
	partial class FrmAddNakladLines
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddNakladLines));
			this.pnMenu = new System.Windows.Forms.FlowLayoutPanel();
			this.btAdd = new DevExpress.XtraEditors.SimpleButton();
			this.btDelete = new DevExpress.XtraEditors.SimpleButton();
			this.gcNakladLines = new DevExpress.XtraGrid.GridControl();
			this.cNakladLineBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvNakladlines = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colNomenkl = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPriceTotal = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPriceAdditional = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCost = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInventoryNum = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
			this.pnOk = new System.Windows.Forms.Panel();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.riNomekl = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.pnMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcNakladLines)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cNakladLineBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvNakladlines)).BeginInit();
			this.pnOk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.riNomekl)).BeginInit();
			this.SuspendLayout();
			// 
			// pnMenu
			// 
			this.pnMenu.AutoSize = true;
			this.pnMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pnMenu.BackColor = System.Drawing.SystemColors.Control;
			this.pnMenu.Controls.Add(this.btAdd);
			this.pnMenu.Controls.Add(this.btDelete);
			this.pnMenu.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnMenu.Location = new System.Drawing.Point(0, 0);
			this.pnMenu.Name = "pnMenu";
			this.pnMenu.Size = new System.Drawing.Size(819, 52);
			this.pnMenu.TabIndex = 0;
			// 
			// btAdd
			// 
			this.btAdd.AutoSize = true;
			this.btAdd.ImageOptions.Image = global::SC.Zakup.Properties.Resources.New;
			this.btAdd.Location = new System.Drawing.Point(3, 3);
			this.btAdd.Name = "btAdd";
			this.btAdd.Padding = new System.Windows.Forms.Padding(5);
			this.btAdd.Size = new System.Drawing.Size(119, 46);
			this.btAdd.TabIndex = 0;
			this.btAdd.Text = "Добавить";
			this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
			// 
			// btDelete
			// 
			this.btDelete.AutoSize = true;
			this.btDelete.ImageOptions.Image = global::SC.Zakup.Properties.Resources.Delete;
			this.btDelete.Location = new System.Drawing.Point(128, 3);
			this.btDelete.Name = "btDelete";
			this.btDelete.Padding = new System.Windows.Forms.Padding(5);
			this.btDelete.Size = new System.Drawing.Size(108, 46);
			this.btDelete.TabIndex = 1;
			this.btDelete.Text = "Удалить";
			this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
			// 
			// gcNakladLines
			// 
			this.gcNakladLines.DataSource = this.cNakladLineBindingSource;
			this.gcNakladLines.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcNakladLines.Location = new System.Drawing.Point(0, 52);
			this.gcNakladLines.MainView = this.gvNakladlines;
			this.gcNakladLines.Name = "gcNakladLines";
			this.gcNakladLines.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riNomekl});
			this.gcNakladLines.Size = new System.Drawing.Size(819, 282);
			this.gcNakladLines.TabIndex = 1;
			this.gcNakladLines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNakladlines});
			// 
			// cNakladLineBindingSource
			// 
			this.cNakladLineBindingSource.DataSource = typeof(SC.Common.Model.CNakladLine);
			// 
			// gvNakladlines
			// 
			this.gvNakladlines.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNomenkl,
            this.colCategory,
            this.colMeasure,
            this.colPriceTotal,
            this.colPrice,
            this.colPriceAdditional,
            this.colCost,
            this.colComment,
            this.colInventoryNum,
            this.colQuantity});
			this.gvNakladlines.GridControl = this.gcNakladLines;
			this.gvNakladlines.Name = "gvNakladlines";
			this.gvNakladlines.OptionsView.ShowGroupPanel = false;
			this.gvNakladlines.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvNakladlines_ShowingEditor);
			this.gvNakladlines.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvNakladlines_ValidatingEditor);
			// 
			// colNomenkl
			// 
			this.colNomenkl.ColumnEdit = this.riNomekl;
			this.colNomenkl.FieldName = "Nomenkl";
			this.colNomenkl.Name = "colNomenkl";
			this.colNomenkl.Visible = true;
			this.colNomenkl.VisibleIndex = 0;
			// 
			// colCategory
			// 
			this.colCategory.FieldName = "Category";
			this.colCategory.Name = "colCategory";
			this.colCategory.Visible = true;
			this.colCategory.VisibleIndex = 2;
			// 
			// colMeasure
			// 
			this.colMeasure.FieldName = "Measure";
			this.colMeasure.Name = "colMeasure";
			this.colMeasure.Visible = true;
			this.colMeasure.VisibleIndex = 3;
			// 
			// colPriceTotal
			// 
			this.colPriceTotal.FieldName = "PriceTotal";
			this.colPriceTotal.Name = "colPriceTotal";
			this.colPriceTotal.OptionsColumn.AllowEdit = false;
			this.colPriceTotal.OptionsColumn.ReadOnly = true;
			this.colPriceTotal.Visible = true;
			this.colPriceTotal.VisibleIndex = 7;
			// 
			// colPrice
			// 
			this.colPrice.FieldName = "Price";
			this.colPrice.Name = "colPrice";
			this.colPrice.Visible = true;
			this.colPrice.VisibleIndex = 5;
			// 
			// colPriceAdditional
			// 
			this.colPriceAdditional.FieldName = "PriceAdditional";
			this.colPriceAdditional.Name = "colPriceAdditional";
			this.colPriceAdditional.Visible = true;
			this.colPriceAdditional.VisibleIndex = 6;
			// 
			// colCost
			// 
			this.colCost.FieldName = "Cost";
			this.colCost.Name = "colCost";
			this.colCost.OptionsColumn.AllowEdit = false;
			this.colCost.OptionsColumn.ReadOnly = true;
			this.colCost.Visible = true;
			this.colCost.VisibleIndex = 8;
			// 
			// colComment
			// 
			this.colComment.FieldName = "Comment";
			this.colComment.Name = "colComment";
			this.colComment.Visible = true;
			this.colComment.VisibleIndex = 9;
			// 
			// colInventoryNum
			// 
			this.colInventoryNum.FieldName = "InventoryNum";
			this.colInventoryNum.Name = "colInventoryNum";
			this.colInventoryNum.Visible = true;
			this.colInventoryNum.VisibleIndex = 1;
			// 
			// colQuantity
			// 
			this.colQuantity.FieldName = "Quantity";
			this.colQuantity.Name = "colQuantity";
			this.colQuantity.Visible = true;
			this.colQuantity.VisibleIndex = 4;
			// 
			// pnOk
			// 
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 334);
			this.pnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(819, 80);
			this.pnOk.TabIndex = 2;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(569, 26);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 30);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Отмена";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(689, 21);
			this.btnOk.Margin = new System.Windows.Forms.Padding(10);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(111, 40);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "Ок";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// riNomekl
			// 
			this.riNomekl.AutoHeight = false;
			this.riNomekl.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.riNomekl.Name = "riNomekl";
			// 
			// FrmAddNakladLines
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(819, 414);
			this.Controls.Add(this.gcNakladLines);
			this.Controls.Add(this.pnOk);
			this.Controls.Add(this.pnMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmAddNakladLines";
			this.Text = "Добавить товары";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAddNakladLines_FormClosed);
			this.pnMenu.ResumeLayout(false);
			this.pnMenu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcNakladLines)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cNakladLineBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvNakladlines)).EndInit();
			this.pnOk.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.riNomekl)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel pnMenu;
		private DevExpress.XtraEditors.SimpleButton btAdd;
		private DevExpress.XtraEditors.SimpleButton btDelete;
		private DevExpress.XtraGrid.GridControl gcNakladLines;
		private DevExpress.XtraGrid.Views.Grid.GridView gvNakladlines;
		private System.Windows.Forms.Panel pnOk;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.SimpleButton btnOk;
		private System.Windows.Forms.BindingSource cNakladLineBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colNomenkl;
		private DevExpress.XtraGrid.Columns.GridColumn colCategory;
		private DevExpress.XtraGrid.Columns.GridColumn colMeasure;
		private DevExpress.XtraGrid.Columns.GridColumn colPriceTotal;
		private DevExpress.XtraGrid.Columns.GridColumn colPrice;
		private DevExpress.XtraGrid.Columns.GridColumn colPriceAdditional;
		private DevExpress.XtraGrid.Columns.GridColumn colCost;
		private DevExpress.XtraGrid.Columns.GridColumn colComment;
		private DevExpress.XtraGrid.Columns.GridColumn colInventoryNum;
		private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox riNomekl;
	}
}