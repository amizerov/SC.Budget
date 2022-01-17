namespace SC.Zakup.Views
{
	partial class FrmNakladLineQuantity
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNakladLineQuantity));
			this.pnOk = new System.Windows.Forms.Panel();
			this.btSelectAll = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
			this.txtQuantity = new DevExpress.XtraEditors.TextEdit();
			this.lbMeasure = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.lbNomenkl = new DevExpress.XtraEditors.LabelControl();
			this.pnOk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
			this.tablePanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// pnOk
			// 
			this.pnOk.Controls.Add(this.btSelectAll);
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 68);
			this.pnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(404, 70);
			this.pnOk.TabIndex = 2;
			// 
			// btSelectAll
			// 
			this.btSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btSelectAll.Location = new System.Drawing.Point(240, 16);
			this.btSelectAll.Margin = new System.Windows.Forms.Padding(5);
			this.btSelectAll.Name = "btSelectAll";
			this.btSelectAll.Size = new System.Drawing.Size(150, 40);
			this.btSelectAll.TabIndex = 4;
			this.btSelectAll.Text = "Выбрать всё";
			this.btSelectAll.Click += new System.EventHandler(this.btSelectAll_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(9, 21);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 30);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Отмена";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(119, 16);
			this.btnOk.Margin = new System.Windows.Forms.Padding(5);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(111, 40);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "Ок";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// tablePanel1
			// 
			this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F)});
			this.tablePanel1.Controls.Add(this.txtQuantity);
			this.tablePanel1.Controls.Add(this.lbMeasure);
			this.tablePanel1.Controls.Add(this.labelControl2);
			this.tablePanel1.Controls.Add(this.lbNomenkl);
			this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tablePanel1.Location = new System.Drawing.Point(0, 0);
			this.tablePanel1.Name = "tablePanel1";
			this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
			this.tablePanel1.Size = new System.Drawing.Size(404, 68);
			this.tablePanel1.TabIndex = 3;
			// 
			// txtQuantity
			// 
			this.tablePanel1.SetColumn(this.txtQuantity, 1);
			this.txtQuantity.EditValue = "";
			this.txtQuantity.Location = new System.Drawing.Point(90, 29);
			this.txtQuantity.Name = "txtQuantity";
			this.txtQuantity.Properties.Appearance.Options.UseTextOptions = true;
			this.txtQuantity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.txtQuantity.Properties.Mask.EditMask = "n0";
			this.txtQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.tablePanel1.SetRow(this.txtQuantity, 1);
			this.txtQuantity.Size = new System.Drawing.Size(210, 26);
			this.txtQuantity.TabIndex = 4;
			// 
			// lbMeasure
			// 
			this.tablePanel1.SetColumn(this.lbMeasure, 2);
			this.lbMeasure.Location = new System.Drawing.Point(306, 29);
			this.lbMeasure.Name = "lbMeasure";
			this.lbMeasure.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.tablePanel1.SetRow(this.lbMeasure, 1);
			this.lbMeasure.Size = new System.Drawing.Size(95, 23);
			this.lbMeasure.TabIndex = 3;
			this.lbMeasure.Text = "Ед.изм: Штука";
			// 
			// labelControl2
			// 
			this.tablePanel1.SetColumn(this.labelControl2, 0);
			this.labelControl2.Location = new System.Drawing.Point(3, 29);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.tablePanel1.SetRow(this.labelControl2, 1);
			this.labelControl2.Size = new System.Drawing.Size(81, 23);
			this.labelControl2.TabIndex = 1;
			this.labelControl2.Text = "Количество";
			// 
			// lbNomenkl
			// 
			this.tablePanel1.SetColumn(this.lbNomenkl, 0);
			this.tablePanel1.SetColumnSpan(this.lbNomenkl, 5);
			this.lbNomenkl.Location = new System.Drawing.Point(3, 3);
			this.lbNomenkl.Name = "lbNomenkl";
			this.tablePanel1.SetRow(this.lbNomenkl, 0);
			this.lbNomenkl.Size = new System.Drawing.Size(107, 20);
			this.lbNomenkl.TabIndex = 0;
			this.lbNomenkl.Text = "Наименование";
			// 
			// FrmNakladLineQuantity
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(404, 138);
			this.Controls.Add(this.tablePanel1);
			this.Controls.Add(this.pnOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmNakladLineQuantity";
			this.Text = "Выберите количество";
			this.pnOk.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
			this.tablePanel1.ResumeLayout(false);
			this.tablePanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnOk;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.SimpleButton btnOk;
		private DevExpress.XtraEditors.SimpleButton btSelectAll;
		private DevExpress.Utils.Layout.TablePanel tablePanel1;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.LabelControl lbNomenkl;
		private DevExpress.XtraEditors.LabelControl lbMeasure;
		private DevExpress.XtraEditors.TextEdit txtQuantity;
	}
}