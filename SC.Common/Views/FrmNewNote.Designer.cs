namespace SC.Common.Views
{
	partial class FrmNewNote
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewNote));
			this.pnMain = new DevExpress.Utils.Layout.TablePanel();
			this.deDate = new DevExpress.XtraEditors.DateEdit();
			this.txtContent = new DevExpress.XtraEditors.MemoEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.pnOk = new DevExpress.XtraEditors.PanelControl();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.pnMain)).BeginInit();
			this.pnMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.deDate.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).BeginInit();
			this.pnOk.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnMain
			// 
			this.pnMain.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
			this.pnMain.Controls.Add(this.deDate);
			this.pnMain.Controls.Add(this.txtContent);
			this.pnMain.Controls.Add(this.labelControl1);
			this.pnMain.Controls.Add(this.labelControl4);
			this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnMain.Location = new System.Drawing.Point(0, 0);
			this.pnMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnMain.Name = "pnMain";
			this.pnMain.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
			this.pnMain.Size = new System.Drawing.Size(384, 308);
			this.pnMain.TabIndex = 28;
			// 
			// deDate
			// 
			this.pnMain.SetColumn(this.deDate, 1);
			this.deDate.EditValue = null;
			this.deDate.Location = new System.Drawing.Point(65, 3);
			this.deDate.Name = "deDate";
			this.deDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
			this.deDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.deDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.pnMain.SetRow(this.deDate, 0);
			this.deDate.Size = new System.Drawing.Size(316, 26);
			this.deDate.TabIndex = 11;
			// 
			// txtContent
			// 
			this.pnMain.SetColumn(this.txtContent, 1);
			this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtContent.Location = new System.Drawing.Point(65, 36);
			this.txtContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtContent.Name = "txtContent";
			this.pnMain.SetRow(this.txtContent, 1);
			this.txtContent.Size = new System.Drawing.Size(316, 268);
			this.txtContent.TabIndex = 9;
			// 
			// labelControl1
			// 
			this.pnMain.SetColumn(this.labelControl1, 0);
			this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelControl1.Location = new System.Drawing.Point(3, 36);
			this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.labelControl1.Name = "labelControl1";
			this.pnMain.SetRow(this.labelControl1, 1);
			this.labelControl1.Size = new System.Drawing.Size(56, 20);
			this.labelControl1.TabIndex = 8;
			this.labelControl1.Text = "Заметка";
			// 
			// labelControl4
			// 
			this.pnMain.SetColumn(this.labelControl4, 0);
			this.labelControl4.Location = new System.Drawing.Point(3, 4);
			this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.labelControl4.Name = "labelControl4";
			this.pnMain.SetRow(this.labelControl4, 0);
			this.labelControl4.Size = new System.Drawing.Size(32, 20);
			this.labelControl4.TabIndex = 5;
			this.labelControl4.Text = "Дата";
			// 
			// pnOk
			// 
			this.pnOk.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 308);
			this.pnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(384, 95);
			this.pnOk.TabIndex = 29;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.ImageOptions.Image = global::SC.Common.Properties.Resources.save;
			this.btnOk.Location = new System.Drawing.Point(226, 23);
			this.btnOk.Margin = new System.Windows.Forms.Padding(10, 11, 10, 11);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(139, 53);
			this.btnOk.TabIndex = 22;
			this.btnOk.Text = "Сохранить";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(107, 23);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(10, 11, 10, 11);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(99, 40);
			this.btnCancel.TabIndex = 23;
			this.btnCancel.Text = "Отмена";
			// 
			// FrmNewNote
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(384, 403);
			this.Controls.Add(this.pnMain);
			this.Controls.Add(this.pnOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FrmNewNote";
			this.Text = "Создать заметку";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmNewNote_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.pnMain)).EndInit();
			this.pnMain.ResumeLayout(false);
			this.pnMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.deDate.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).EndInit();
			this.pnOk.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.Utils.Layout.TablePanel pnMain;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraEditors.PanelControl pnOk;
		private DevExpress.XtraEditors.SimpleButton btnOk;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.MemoEdit txtContent;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.DateEdit deDate;
	}
}