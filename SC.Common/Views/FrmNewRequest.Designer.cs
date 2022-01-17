namespace SC.Common.Views
{
	partial class FrmNewRequest
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewRequest));
			this.pnMain = new DevExpress.Utils.Layout.TablePanel();
			this.deMonth = new DevExpress.XtraEditors.DateEdit();
			this.cbProject = new DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.chbSendEmail = new DevExpress.XtraEditors.CheckEdit();
			this.txtComment = new DevExpress.XtraEditors.MemoEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.txtAmount = new DevExpress.XtraEditors.TextEdit();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.pnOk = new DevExpress.XtraEditors.PanelControl();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.pnMain)).BeginInit();
			this.pnMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.deMonth.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deMonth.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbProject.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chbSendEmail.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).BeginInit();
			this.pnOk.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnMain
			// 
			this.pnMain.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
			this.pnMain.Controls.Add(this.deMonth);
			this.pnMain.Controls.Add(this.cbProject);
			this.pnMain.Controls.Add(this.labelControl3);
			this.pnMain.Controls.Add(this.labelControl2);
			this.pnMain.Controls.Add(this.chbSendEmail);
			this.pnMain.Controls.Add(this.txtComment);
			this.pnMain.Controls.Add(this.labelControl1);
			this.pnMain.Controls.Add(this.txtAmount);
			this.pnMain.Controls.Add(this.labelControl4);
			this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnMain.Location = new System.Drawing.Point(0, 0);
			this.pnMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnMain.Name = "pnMain";
			this.pnMain.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F)});
			this.pnMain.Size = new System.Drawing.Size(432, 323);
			this.pnMain.TabIndex = 28;
			// 
			// deMonth
			// 
			this.pnMain.SetColumn(this.deMonth, 1);
			this.deMonth.EditValue = null;
			this.deMonth.Location = new System.Drawing.Point(107, 39);
			this.deMonth.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.deMonth.Name = "deMonth";
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
			this.pnMain.SetRow(this.deMonth, 1);
			this.deMonth.Size = new System.Drawing.Size(323, 28);
			this.deMonth.TabIndex = 14;
			// 
			// cbProject
			// 
			this.pnMain.SetColumn(this.cbProject, 1);
			this.cbProject.Location = new System.Drawing.Point(107, 73);
			this.cbProject.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.cbProject.Name = "cbProject";
			this.cbProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.pnMain.SetRow(this.cbProject, 2);
			this.cbProject.Size = new System.Drawing.Size(323, 28);
			this.cbProject.TabIndex = 13;
			// 
			// labelControl3
			// 
			this.pnMain.SetColumn(this.labelControl3, 0);
			this.labelControl3.Location = new System.Drawing.Point(3, 74);
			this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.labelControl3.Name = "labelControl3";
			this.pnMain.SetRow(this.labelControl3, 2);
			this.labelControl3.Size = new System.Drawing.Size(52, 21);
			this.labelControl3.TabIndex = 12;
			this.labelControl3.Text = "Проект";
			// 
			// labelControl2
			// 
			this.pnMain.SetColumn(this.labelControl2, 0);
			this.labelControl2.Location = new System.Drawing.Point(3, 40);
			this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.labelControl2.Name = "labelControl2";
			this.pnMain.SetRow(this.labelControl2, 1);
			this.labelControl2.Size = new System.Drawing.Size(47, 21);
			this.labelControl2.TabIndex = 11;
			this.labelControl2.Text = "Месяц";
			// 
			// chbSendEmail
			// 
			this.pnMain.SetColumn(this.chbSendEmail, 0);
			this.pnMain.SetColumnSpan(this.chbSendEmail, 2);
			this.chbSendEmail.Dock = System.Windows.Forms.DockStyle.Top;
			this.chbSendEmail.EditValue = true;
			this.chbSendEmail.Location = new System.Drawing.Point(3, 295);
			this.chbSendEmail.Name = "chbSendEmail";
			this.chbSendEmail.Properties.Caption = "Отправить оповещение на почту";
			this.pnMain.SetRow(this.chbSendEmail, 4);
			this.chbSendEmail.Size = new System.Drawing.Size(426, 25);
			this.chbSendEmail.TabIndex = 10;
			// 
			// txtComment
			// 
			this.pnMain.SetColumn(this.txtComment, 1);
			this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtComment.Location = new System.Drawing.Point(108, 108);
			this.txtComment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtComment.Name = "txtComment";
			this.pnMain.SetRow(this.txtComment, 3);
			this.txtComment.Size = new System.Drawing.Size(321, 180);
			this.txtComment.TabIndex = 9;
			// 
			// labelControl1
			// 
			this.pnMain.SetColumn(this.labelControl1, 0);
			this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelControl1.Location = new System.Drawing.Point(3, 108);
			this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.labelControl1.Name = "labelControl1";
			this.pnMain.SetRow(this.labelControl1, 3);
			this.labelControl1.Size = new System.Drawing.Size(99, 21);
			this.labelControl1.TabIndex = 8;
			this.labelControl1.Text = "Комментарий";
			// 
			// txtAmount
			// 
			this.pnMain.SetColumn(this.txtAmount, 1);
			this.txtAmount.EditValue = "0";
			this.txtAmount.Location = new System.Drawing.Point(108, 4);
			this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtAmount.Name = "txtAmount";
			this.txtAmount.Properties.DisplayFormat.FormatString = "0.00";
			this.txtAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtAmount.Properties.Mask.EditMask = "n";
			this.txtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.pnMain.SetRow(this.txtAmount, 0);
			this.txtAmount.Size = new System.Drawing.Size(321, 28);
			this.txtAmount.TabIndex = 7;
			// 
			// labelControl4
			// 
			this.pnMain.SetColumn(this.labelControl4, 0);
			this.labelControl4.Location = new System.Drawing.Point(3, 4);
			this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.labelControl4.Name = "labelControl4";
			this.pnMain.SetRow(this.labelControl4, 0);
			this.labelControl4.Size = new System.Drawing.Size(48, 21);
			this.labelControl4.TabIndex = 5;
			this.labelControl4.Text = "Сумма";
			// 
			// pnOk
			// 
			this.pnOk.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 323);
			this.pnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(432, 100);
			this.pnOk.TabIndex = 29;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.ImageOptions.Image = global::SC.Common.Properties.Resources.save;
			this.btnOk.Location = new System.Drawing.Point(254, 24);
			this.btnOk.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(156, 55);
			this.btnOk.TabIndex = 22;
			this.btnOk.Text = "Отправить";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(120, 24);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(111, 42);
			this.btnCancel.TabIndex = 23;
			this.btnCancel.Text = "Отмена";
			// 
			// FrmNewRequest
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(432, 423);
			this.Controls.Add(this.pnMain);
			this.Controls.Add(this.pnOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FrmNewRequest";
			this.Text = "Создать запрос на получение денег";
			((System.ComponentModel.ISupportInitialize)(this.pnMain)).EndInit();
			this.pnMain.ResumeLayout(false);
			this.pnMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.deMonth.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deMonth.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbProject.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chbSendEmail.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).EndInit();
			this.pnOk.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.Utils.Layout.TablePanel pnMain;
		private DevExpress.XtraEditors.TextEdit txtAmount;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraEditors.PanelControl pnOk;
		private DevExpress.XtraEditors.SimpleButton btnOk;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.MemoEdit txtComment;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.CheckEdit chbSendEmail;
		private DevExpress.XtraEditors.DateEdit deMonth;
		private DevExpress.XtraEditors.ComboBoxEdit cbProject;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.LabelControl labelControl2;
	}
}