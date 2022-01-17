namespace SC.Zakup.Views
{
	partial class FrmSelectExcelSheetForNalog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectExcelSheetForNalog));
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.pnOk = new System.Windows.Forms.Panel();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
			this.deMonth = new DevExpress.XtraEditors.DateEdit();
			this.cbExcelSheet = new DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.pnOk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
			this.tablePanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.deMonth.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deMonth.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbExcelSheet.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelControl1.Appearance.Options.UseFont = true;
			this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
			this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelControl1.Location = new System.Drawing.Point(0, 0);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 25);
			this.labelControl1.Size = new System.Drawing.Size(549, 67);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "Выберите лист Excel из которого будут выгружаться данные и месяц, за который буду" +
    "т внесены налоги";
			// 
			// pnOk
			// 
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 173);
			this.pnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(549, 80);
			this.pnOk.TabIndex = 2;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(299, 26);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 30);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Отмена";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(419, 21);
			this.btnOk.Margin = new System.Windows.Forms.Padding(10);
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
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
			this.tablePanel1.Controls.Add(this.deMonth);
			this.tablePanel1.Controls.Add(this.cbExcelSheet);
			this.tablePanel1.Controls.Add(this.labelControl3);
			this.tablePanel1.Controls.Add(this.labelControl2);
			this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tablePanel1.Location = new System.Drawing.Point(0, 67);
			this.tablePanel1.Name = "tablePanel1";
			this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 26F)});
			this.tablePanel1.Size = new System.Drawing.Size(549, 106);
			this.tablePanel1.TabIndex = 3;
			// 
			// deMonth
			// 
			this.tablePanel1.SetColumn(this.deMonth, 1);
			this.deMonth.EditValue = null;
			this.deMonth.Location = new System.Drawing.Point(79, 35);
			this.deMonth.Name = "deMonth";
			this.deMonth.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
			this.deMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.deMonth.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.deMonth.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
			this.deMonth.Properties.DisplayFormat.FormatString = "MMMM yyyy";
			this.deMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.deMonth.Properties.EditFormat.FormatString = "MMMM yyyy";
			this.deMonth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.deMonth.Properties.Mask.EditMask = "MMMM yyyy";
			this.deMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.deMonth.Properties.VistaCalendarViewStyle = ((DevExpress.XtraEditors.VistaCalendarViewStyle)((DevExpress.XtraEditors.VistaCalendarViewStyle.YearView | DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView)));
			this.deMonth.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
			this.tablePanel1.SetRow(this.deMonth, 1);
			this.deMonth.Size = new System.Drawing.Size(467, 26);
			this.deMonth.TabIndex = 3;
			// 
			// cbExcelSheet
			// 
			this.tablePanel1.SetColumn(this.cbExcelSheet, 1);
			this.cbExcelSheet.Location = new System.Drawing.Point(79, 3);
			this.cbExcelSheet.Name = "cbExcelSheet";
			this.cbExcelSheet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbExcelSheet.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.tablePanel1.SetRow(this.cbExcelSheet, 0);
			this.cbExcelSheet.Size = new System.Drawing.Size(467, 26);
			this.cbExcelSheet.TabIndex = 2;
			this.cbExcelSheet.SelectedIndexChanged += new System.EventHandler(this.cbExcelSheet_SelectedIndexChanged);
			// 
			// labelControl3
			// 
			this.tablePanel1.SetColumn(this.labelControl3, 0);
			this.labelControl3.Location = new System.Drawing.Point(3, 35);
			this.labelControl3.Name = "labelControl3";
			this.tablePanel1.SetRow(this.labelControl3, 1);
			this.labelControl3.Size = new System.Drawing.Size(45, 20);
			this.labelControl3.TabIndex = 1;
			this.labelControl3.Text = "Месяц";
			// 
			// labelControl2
			// 
			this.tablePanel1.SetColumn(this.labelControl2, 0);
			this.labelControl2.Location = new System.Drawing.Point(3, 3);
			this.labelControl2.Name = "labelControl2";
			this.tablePanel1.SetRow(this.labelControl2, 0);
			this.labelControl2.Size = new System.Drawing.Size(70, 20);
			this.labelControl2.TabIndex = 0;
			this.labelControl2.Text = "Лист Excel";
			// 
			// FrmSelectExcelSheetForNalog
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(549, 253);
			this.Controls.Add(this.tablePanel1);
			this.Controls.Add(this.pnOk);
			this.Controls.Add(this.labelControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmSelectExcelSheetForNalog";
			this.Text = "Выберите лист и месяц";
			this.pnOk.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
			this.tablePanel1.ResumeLayout(false);
			this.tablePanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.deMonth.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deMonth.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbExcelSheet.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl labelControl1;
		private System.Windows.Forms.Panel pnOk;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.SimpleButton btnOk;
		private DevExpress.Utils.Layout.TablePanel tablePanel1;
		private DevExpress.XtraEditors.DateEdit deMonth;
		private DevExpress.XtraEditors.ComboBoxEdit cbExcelSheet;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.LabelControl labelControl2;
	}
}