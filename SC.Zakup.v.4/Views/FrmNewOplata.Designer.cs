namespace SC.Zakup.Views
{
	partial class FrmNewOplata
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewOplata));
			this.pnOk = new System.Windows.Forms.Panel();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
			this.txtSumma = new DevExpress.XtraEditors.TextEdit();
			this.deDate = new DevExpress.XtraEditors.DateEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.pnOk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
			this.tablePanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSumma.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deDate.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// pnOk
			// 
			this.pnOk.Controls.Add(this.btnSave);
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 62);
			this.pnOk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(284, 80);
			this.pnOk.TabIndex = 17;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.ImageOptions.Image = global::SC.Zakup.Properties.Resources.save1;
			this.btnSave.Location = new System.Drawing.Point(138, 23);
			this.btnSave.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(130, 40);
			this.btnSave.TabIndex = 10;
			this.btnSave.Text = "Сохранить";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(51, 31);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(73, 24);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Отмена";
			// 
			// tablePanel1
			// 
			this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
			this.tablePanel1.Controls.Add(this.txtSumma);
			this.tablePanel1.Controls.Add(this.deDate);
			this.tablePanel1.Controls.Add(this.labelControl2);
			this.tablePanel1.Controls.Add(this.labelControl1);
			this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tablePanel1.Location = new System.Drawing.Point(0, 0);
			this.tablePanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tablePanel1.Name = "tablePanel1";
			this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 26F)});
			this.tablePanel1.Size = new System.Drawing.Size(284, 62);
			this.tablePanel1.TabIndex = 18;
			// 
			// txtSumma
			// 
			this.tablePanel1.SetColumn(this.txtSumma, 1);
			this.txtSumma.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtSumma.Location = new System.Drawing.Point(52, 32);
			this.txtSumma.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtSumma.Name = "txtSumma";
			this.txtSumma.Properties.DisplayFormat.FormatString = "c2";
			this.txtSumma.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtSumma.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.tablePanel1.SetRow(this.txtSumma, 1);
			this.txtSumma.Size = new System.Drawing.Size(230, 26);
			this.txtSumma.TabIndex = 3;
			// 
			// deDate
			// 
			this.tablePanel1.SetColumn(this.deDate, 1);
			this.deDate.EditValue = null;
			this.deDate.Location = new System.Drawing.Point(52, 2);
			this.deDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.deDate.Name = "deDate";
			this.deDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.deDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.tablePanel1.SetRow(this.deDate, 0);
			this.deDate.Size = new System.Drawing.Size(230, 26);
			this.deDate.TabIndex = 2;
			// 
			// labelControl2
			// 
			this.tablePanel1.SetColumn(this.labelControl2, 0);
			this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelControl2.Location = new System.Drawing.Point(2, 32);
			this.labelControl2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.labelControl2.Name = "labelControl2";
			this.tablePanel1.SetRow(this.labelControl2, 1);
			this.labelControl2.Size = new System.Drawing.Size(46, 20);
			this.labelControl2.TabIndex = 1;
			this.labelControl2.Text = "Сумма";
			// 
			// labelControl1
			// 
			this.tablePanel1.SetColumn(this.labelControl1, 0);
			this.labelControl1.Location = new System.Drawing.Point(2, 2);
			this.labelControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.labelControl1.Name = "labelControl1";
			this.tablePanel1.SetRow(this.labelControl1, 0);
			this.labelControl1.Size = new System.Drawing.Size(32, 20);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "Дата";
			// 
			// FrmNewOplata
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(284, 142);
			this.Controls.Add(this.tablePanel1);
			this.Controls.Add(this.pnOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "FrmNewOplata";
			this.Text = "Новая оплата";
			this.pnOk.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
			this.tablePanel1.ResumeLayout(false);
			this.tablePanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSumma.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deDate.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnOk;
		private DevExpress.XtraEditors.SimpleButton btnSave;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.Utils.Layout.TablePanel tablePanel1;
		private DevExpress.XtraEditors.TextEdit txtSumma;
		private DevExpress.XtraEditors.DateEdit deDate;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.LabelControl labelControl1;
	}
}