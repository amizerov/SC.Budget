namespace SC.Cash.Views
{
	partial class FrmEditOperation
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditOperation));
			this.pnMain = new DevExpress.Utils.Layout.TablePanel();
			this.cbFromUser = new DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
			this.deDate = new DevExpress.XtraEditors.DateEdit();
			this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
			this.cbCategory = new DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.txtComment = new DevExpress.XtraEditors.MemoEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.txtAmount = new DevExpress.XtraEditors.TextEdit();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.cbToUser = new DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.pnOk = new DevExpress.XtraEditors.PanelControl();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
			this.deMonth = new DevExpress.XtraEditors.DateEdit();
			this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
			this.cbProject = new DevExpress.XtraEditors.ComboBoxEdit();
			((System.ComponentModel.ISupportInitialize)(this.pnMain)).BeginInit();
			this.pnMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cbFromUser.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deDate.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbCategory.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbToUser.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).BeginInit();
			this.pnOk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.deMonth.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deMonth.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbProject.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// pnMain
			// 
			this.pnMain.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
			this.pnMain.Controls.Add(this.cbProject);
			this.pnMain.Controls.Add(this.labelControl8);
			this.pnMain.Controls.Add(this.deMonth);
			this.pnMain.Controls.Add(this.labelControl7);
			this.pnMain.Controls.Add(this.cbFromUser);
			this.pnMain.Controls.Add(this.labelControl6);
			this.pnMain.Controls.Add(this.deDate);
			this.pnMain.Controls.Add(this.labelControl5);
			this.pnMain.Controls.Add(this.cbCategory);
			this.pnMain.Controls.Add(this.labelControl3);
			this.pnMain.Controls.Add(this.txtComment);
			this.pnMain.Controls.Add(this.labelControl1);
			this.pnMain.Controls.Add(this.txtAmount);
			this.pnMain.Controls.Add(this.labelControl4);
			this.pnMain.Controls.Add(this.cbToUser);
			this.pnMain.Controls.Add(this.labelControl2);
			this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnMain.Location = new System.Drawing.Point(0, 0);
			this.pnMain.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.pnMain.Name = "pnMain";
			this.pnMain.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
			this.pnMain.Size = new System.Drawing.Size(604, 572);
			this.pnMain.TabIndex = 0;
			// 
			// cbFromUser
			// 
			this.pnMain.SetColumn(this.cbFromUser, 1);
			this.cbFromUser.Location = new System.Drawing.Point(141, 48);
			this.cbFromUser.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.cbFromUser.Name = "cbFromUser";
			this.cbFromUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbFromUser.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.pnMain.SetRow(this.cbFromUser, 1);
			this.cbFromUser.Size = new System.Drawing.Size(456, 32);
			this.cbFromUser.TabIndex = 15;
			// 
			// labelControl6
			// 
			this.pnMain.SetColumn(this.labelControl6, 0);
			this.labelControl6.Location = new System.Drawing.Point(7, 48);
			this.labelControl6.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.labelControl6.Name = "labelControl6";
			this.pnMain.SetRow(this.labelControl6, 1);
			this.labelControl6.Size = new System.Drawing.Size(65, 25);
			this.labelControl6.TabIndex = 14;
			this.labelControl6.Text = "От кого";
			// 
			// deDate
			// 
			this.pnMain.SetColumn(this.deDate, 1);
			this.deDate.EditValue = null;
			this.deDate.Location = new System.Drawing.Point(138, 5);
			this.deDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.deDate.Name = "deDate";
			this.deDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
			this.deDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.deDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.pnMain.SetRow(this.deDate, 0);
			this.deDate.Size = new System.Drawing.Size(462, 32);
			this.deDate.TabIndex = 13;
			// 
			// labelControl5
			// 
			this.pnMain.SetColumn(this.labelControl5, 0);
			this.labelControl5.Location = new System.Drawing.Point(7, 6);
			this.labelControl5.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.labelControl5.Name = "labelControl5";
			this.pnMain.SetRow(this.labelControl5, 0);
			this.labelControl5.Size = new System.Drawing.Size(41, 25);
			this.labelControl5.TabIndex = 12;
			this.labelControl5.Text = "Дата";
			// 
			// cbCategory
			// 
			this.pnMain.SetColumn(this.cbCategory, 1);
			this.cbCategory.Location = new System.Drawing.Point(141, 266);
			this.cbCategory.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.cbCategory.Name = "cbCategory";
			this.cbCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbCategory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.pnMain.SetRow(this.cbCategory, 6);
			this.cbCategory.Size = new System.Drawing.Size(456, 32);
			this.cbCategory.TabIndex = 11;
			// 
			// labelControl3
			// 
			this.pnMain.SetColumn(this.labelControl3, 0);
			this.labelControl3.Location = new System.Drawing.Point(7, 266);
			this.labelControl3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.labelControl3.Name = "labelControl3";
			this.pnMain.SetRow(this.labelControl3, 6);
			this.labelControl3.Size = new System.Drawing.Size(89, 25);
			this.labelControl3.TabIndex = 10;
			this.labelControl3.Text = "Категория";
			// 
			// txtComment
			// 
			this.pnMain.SetColumn(this.txtComment, 1);
			this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtComment.Location = new System.Drawing.Point(138, 309);
			this.txtComment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtComment.Name = "txtComment";
			this.pnMain.SetRow(this.txtComment, 7);
			this.txtComment.Size = new System.Drawing.Size(462, 258);
			this.txtComment.TabIndex = 9;
			// 
			// labelControl1
			// 
			this.pnMain.SetColumn(this.labelControl1, 0);
			this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelControl1.Location = new System.Drawing.Point(7, 310);
			this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.labelControl1.Name = "labelControl1";
			this.pnMain.SetRow(this.labelControl1, 7);
			this.labelControl1.Size = new System.Drawing.Size(120, 25);
			this.labelControl1.TabIndex = 8;
			this.labelControl1.Text = "Комментарий";
			// 
			// txtAmount
			// 
			this.pnMain.SetColumn(this.txtAmount, 1);
			this.txtAmount.EditValue = "0";
			this.txtAmount.Location = new System.Drawing.Point(141, 136);
			this.txtAmount.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.txtAmount.Name = "txtAmount";
			this.txtAmount.Properties.DisplayFormat.FormatString = "0.00";
			this.txtAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtAmount.Properties.Mask.EditMask = "n";
			this.txtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.pnMain.SetRow(this.txtAmount, 3);
			this.txtAmount.Size = new System.Drawing.Size(456, 32);
			this.txtAmount.TabIndex = 7;
			// 
			// labelControl4
			// 
			this.pnMain.SetColumn(this.labelControl4, 0);
			this.labelControl4.Location = new System.Drawing.Point(7, 136);
			this.labelControl4.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.labelControl4.Name = "labelControl4";
			this.pnMain.SetRow(this.labelControl4, 3);
			this.labelControl4.Size = new System.Drawing.Size(57, 25);
			this.labelControl4.TabIndex = 5;
			this.labelControl4.Text = "Сумма";
			// 
			// cbToUser
			// 
			this.pnMain.SetColumn(this.cbToUser, 1);
			this.cbToUser.Location = new System.Drawing.Point(141, 92);
			this.cbToUser.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.cbToUser.Name = "cbToUser";
			this.cbToUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbToUser.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.pnMain.SetRow(this.cbToUser, 2);
			this.cbToUser.Size = new System.Drawing.Size(456, 32);
			this.cbToUser.TabIndex = 3;
			// 
			// labelControl2
			// 
			this.pnMain.SetColumn(this.labelControl2, 0);
			this.labelControl2.Location = new System.Drawing.Point(7, 92);
			this.labelControl2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.labelControl2.Name = "labelControl2";
			this.pnMain.SetRow(this.labelControl2, 2);
			this.labelControl2.Size = new System.Drawing.Size(44, 25);
			this.labelControl2.TabIndex = 1;
			this.labelControl2.Text = "Кому";
			// 
			// pnOk
			// 
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 572);
			this.pnOk.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(604, 119);
			this.pnOk.TabIndex = 27;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.ImageOptions.Image = global::SC.Cash.Properties.Resources.save;
			this.btnOk.Location = new System.Drawing.Point(384, 28);
			this.btnOk.Margin = new System.Windows.Forms.Padding(15, 11, 15, 11);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(191, 66);
			this.btnOk.TabIndex = 22;
			this.btnOk.Text = "Сохранить";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(221, 28);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(15, 11, 15, 11);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(139, 39);
			this.btnCancel.TabIndex = 23;
			this.btnCancel.Text = "Отмена";
			// 
			// labelControl7
			// 
			this.pnMain.SetColumn(this.labelControl7, 0);
			this.labelControl7.Location = new System.Drawing.Point(7, 180);
			this.labelControl7.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.labelControl7.Name = "labelControl7";
			this.pnMain.SetRow(this.labelControl7, 4);
			this.labelControl7.Size = new System.Drawing.Size(57, 25);
			this.labelControl7.TabIndex = 16;
			this.labelControl7.Text = "Месяц";
			// 
			// deMonth
			// 
			this.pnMain.SetColumn(this.deMonth, 1);
			this.deMonth.EditValue = null;
			this.deMonth.Location = new System.Drawing.Point(138, 179);
			this.deMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
			this.deMonth.Properties.ShowToday = false;
			this.deMonth.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
			this.deMonth.Properties.VistaCalendarViewStyle = ((DevExpress.XtraEditors.VistaCalendarViewStyle)((DevExpress.XtraEditors.VistaCalendarViewStyle.YearView | DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView)));
			this.deMonth.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
			this.pnMain.SetRow(this.deMonth, 4);
			this.deMonth.Size = new System.Drawing.Size(462, 32);
			this.deMonth.TabIndex = 17;
			// 
			// labelControl8
			// 
			this.pnMain.SetColumn(this.labelControl8, 0);
			this.labelControl8.Location = new System.Drawing.Point(7, 222);
			this.labelControl8.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.labelControl8.Name = "labelControl8";
			this.pnMain.SetRow(this.labelControl8, 5);
			this.labelControl8.Size = new System.Drawing.Size(63, 25);
			this.labelControl8.TabIndex = 18;
			this.labelControl8.Text = "Проект";
			// 
			// cbProject
			// 
			this.pnMain.SetColumn(this.cbProject, 1);
			this.cbProject.Location = new System.Drawing.Point(141, 222);
			this.cbProject.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.cbProject.Name = "cbProject";
			this.cbProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbProject.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.pnMain.SetRow(this.cbProject, 5);
			this.cbProject.Size = new System.Drawing.Size(456, 32);
			this.cbProject.TabIndex = 19;
			// 
			// FrmEditOperation
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(604, 691);
			this.Controls.Add(this.pnMain);
			this.Controls.Add(this.pnOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.Name = "FrmEditOperation";
			this.Text = "Новая операция";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmEditOperation_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.pnMain)).EndInit();
			this.pnMain.ResumeLayout(false);
			this.pnMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cbFromUser.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deDate.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbCategory.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbToUser.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).EndInit();
			this.pnOk.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.deMonth.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deMonth.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbProject.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.Utils.Layout.TablePanel pnMain;
		private DevExpress.XtraEditors.PanelControl pnOk;
		private DevExpress.XtraEditors.SimpleButton btnOk;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraEditors.ComboBoxEdit cbToUser;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.TextEdit txtAmount;
		private DevExpress.XtraEditors.MemoEdit txtComment;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.ComboBoxEdit cbCategory;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.DateEdit deDate;
		private DevExpress.XtraEditors.LabelControl labelControl5;
		private DevExpress.XtraEditors.ComboBoxEdit cbFromUser;
		private DevExpress.XtraEditors.LabelControl labelControl6;
		private DevExpress.XtraEditors.ComboBoxEdit cbProject;
		private DevExpress.XtraEditors.LabelControl labelControl8;
		private DevExpress.XtraEditors.DateEdit deMonth;
		private DevExpress.XtraEditors.LabelControl labelControl7;
	}
}