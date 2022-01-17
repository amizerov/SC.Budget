namespace SC.Zakup.Views
{
	partial class FrmNewNakladInvented
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewNakladInvented));
			this.pnOk = new System.Windows.Forms.Panel();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.gcLines = new DevExpress.XtraGrid.GridControl();
			this.gvLines = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.cNakladLineInventedBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.colQuantityAccount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colQuantityFact = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colQuantityDiff = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCostAccount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCostFact = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNomenkl = new DevExpress.XtraGrid.Columns.GridColumn();
			this.pnOk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcLines)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvLines)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cNakladLineInventedBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// pnOk
			// 
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 287);
			this.pnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(506, 80);
			this.pnOk.TabIndex = 2;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(256, 26);
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
			this.btnOk.Location = new System.Drawing.Point(376, 21);
			this.btnOk.Margin = new System.Windows.Forms.Padding(10);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(111, 40);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "Ок";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// gcLines
			// 
			this.gcLines.DataSource = this.cNakladLineInventedBindingSource;
			this.gcLines.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcLines.Location = new System.Drawing.Point(0, 0);
			this.gcLines.MainView = this.gvLines;
			this.gcLines.Name = "gcLines";
			this.gcLines.Size = new System.Drawing.Size(506, 287);
			this.gcLines.TabIndex = 3;
			this.gcLines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLines});
			// 
			// gvLines
			// 
			this.gvLines.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colQuantityAccount,
            this.colQuantityFact,
            this.colQuantityDiff,
            this.colCostAccount,
            this.colCostFact,
            this.colNomenkl});
			this.gvLines.GridControl = this.gcLines;
			this.gvLines.Name = "gvLines";
			this.gvLines.OptionsView.ShowGroupPanel = false;
			// 
			// cNakladLineInventedBindingSource
			// 
			this.cNakladLineInventedBindingSource.DataSource = typeof(SC.Common.Model.CNakladLineInvented);
			// 
			// colQuantityAccount
			// 
			this.colQuantityAccount.FieldName = "QuantityAccount";
			this.colQuantityAccount.Name = "colQuantityAccount";
			this.colQuantityAccount.OptionsColumn.AllowEdit = false;
			this.colQuantityAccount.Visible = true;
			this.colQuantityAccount.VisibleIndex = 2;
			// 
			// colQuantityFact
			// 
			this.colQuantityFact.FieldName = "QuantityFact";
			this.colQuantityFact.Name = "colQuantityFact";
			this.colQuantityFact.Visible = true;
			this.colQuantityFact.VisibleIndex = 1;
			// 
			// colQuantityDiff
			// 
			this.colQuantityDiff.FieldName = "QuantityDiff";
			this.colQuantityDiff.Name = "colQuantityDiff";
			this.colQuantityDiff.OptionsColumn.AllowEdit = false;
			this.colQuantityDiff.OptionsColumn.ReadOnly = true;
			this.colQuantityDiff.Visible = true;
			this.colQuantityDiff.VisibleIndex = 3;
			// 
			// colCostAccount
			// 
			this.colCostAccount.FieldName = "CostAccount";
			this.colCostAccount.Name = "colCostAccount";
			this.colCostAccount.OptionsColumn.AllowEdit = false;
			this.colCostAccount.OptionsColumn.ReadOnly = true;
			this.colCostAccount.Visible = true;
			this.colCostAccount.VisibleIndex = 5;
			// 
			// colCostFact
			// 
			this.colCostFact.FieldName = "CostFact";
			this.colCostFact.Name = "colCostFact";
			this.colCostFact.OptionsColumn.AllowEdit = false;
			this.colCostFact.OptionsColumn.ReadOnly = true;
			this.colCostFact.Visible = true;
			this.colCostFact.VisibleIndex = 4;
			// 
			// colNomenkl
			// 
			this.colNomenkl.FieldName = "Nomenkl";
			this.colNomenkl.Name = "colNomenkl";
			this.colNomenkl.OptionsColumn.AllowEdit = false;
			this.colNomenkl.Visible = true;
			this.colNomenkl.VisibleIndex = 0;
			// 
			// FrmNewNakladInvented
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(506, 367);
			this.Controls.Add(this.gcLines);
			this.Controls.Add(this.pnOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmNewNakladInvented";
			this.Text = "Инвентаризация";
			this.pnOk.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcLines)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvLines)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cNakladLineInventedBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnOk;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.SimpleButton btnOk;
		private DevExpress.XtraGrid.GridControl gcLines;
		private DevExpress.XtraGrid.Views.Grid.GridView gvLines;
		private System.Windows.Forms.BindingSource cNakladLineInventedBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colQuantityAccount;
		private DevExpress.XtraGrid.Columns.GridColumn colQuantityFact;
		private DevExpress.XtraGrid.Columns.GridColumn colQuantityDiff;
		private DevExpress.XtraGrid.Columns.GridColumn colCostAccount;
		private DevExpress.XtraGrid.Columns.GridColumn colCostFact;
		private DevExpress.XtraGrid.Columns.GridColumn colNomenkl;
	}
}