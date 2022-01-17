namespace SC.Cash.Views
{
	partial class FrmNewOperation
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewOperation));
			this.pnMain = new DevExpress.Utils.Layout.TablePanel();
			this.txtComment = new DevExpress.XtraEditors.MemoEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.txtAmount = new DevExpress.XtraEditors.TextEdit();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.cbToUser = new DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.pnOk = new DevExpress.XtraEditors.PanelControl();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.cbCategory = new DevExpress.XtraEditors.ComboBoxEdit();
			((System.ComponentModel.ISupportInitialize)(this.pnMain)).BeginInit();
			this.pnMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbToUser.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).BeginInit();
			this.pnOk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cbCategory.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// pnMain
			// 
			this.pnMain.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
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
			this.pnMain.Margin = new System.Windows.Forms.Padding(4);
			this.pnMain.Name = "pnMain";
			this.pnMain.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
			this.pnMain.Size = new System.Drawing.Size(436, 376);
			this.pnMain.TabIndex = 0;
			// 
			// txtComment
			// 
			this.pnMain.SetColumn(this.txtComment, 1);
			this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtComment.Location = new System.Drawing.Point(99, 105);
			this.txtComment.Name = "txtComment";
			this.pnMain.SetRow(this.txtComment, 3);
			this.txtComment.Size = new System.Drawing.Size(334, 268);
			this.txtComment.TabIndex = 9;
			// 
			// labelControl1
			// 
			this.pnMain.SetColumn(this.labelControl1, 0);
			this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelControl1.Location = new System.Drawing.Point(4, 106);
			this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
			this.labelControl1.Name = "labelControl1";
			this.pnMain.SetRow(this.labelControl1, 3);
			this.labelControl1.Size = new System.Drawing.Size(88, 19);
			this.labelControl1.TabIndex = 8;
			this.labelControl1.Text = "Комментарий";
			// 
			// txtAmount
			// 
			this.pnMain.SetColumn(this.txtAmount, 1);
			this.txtAmount.EditValue = "0";
			this.txtAmount.Location = new System.Drawing.Point(100, 38);
			this.txtAmount.Margin = new System.Windows.Forms.Padding(4);
			this.txtAmount.Name = "txtAmount";
			this.txtAmount.Properties.DisplayFormat.FormatString = "0.00";
			this.txtAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtAmount.Properties.Mask.EditMask = "n";
			this.txtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.pnMain.SetRow(this.txtAmount, 1);
			this.txtAmount.Size = new System.Drawing.Size(332, 26);
			this.txtAmount.TabIndex = 7;
			// 
			// labelControl4
			// 
			this.pnMain.SetColumn(this.labelControl4, 0);
			this.labelControl4.Location = new System.Drawing.Point(4, 38);
			this.labelControl4.Margin = new System.Windows.Forms.Padding(4);
			this.labelControl4.Name = "labelControl4";
			this.pnMain.SetRow(this.labelControl4, 1);
			this.labelControl4.Size = new System.Drawing.Size(43, 19);
			this.labelControl4.TabIndex = 5;
			this.labelControl4.Text = "Сумма";
			// 
			// cbToUser
			// 
			this.pnMain.SetColumn(this.cbToUser, 1);
			this.cbToUser.Location = new System.Drawing.Point(100, 4);
			this.cbToUser.Margin = new System.Windows.Forms.Padding(4);
			this.cbToUser.Name = "cbToUser";
			this.cbToUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbToUser.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.pnMain.SetRow(this.cbToUser, 0);
			this.cbToUser.Size = new System.Drawing.Size(332, 26);
			this.cbToUser.TabIndex = 3;
			// 
			// labelControl2
			// 
			this.pnMain.SetColumn(this.labelControl2, 0);
			this.labelControl2.Location = new System.Drawing.Point(4, 4);
			this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
			this.labelControl2.Name = "labelControl2";
			this.pnMain.SetRow(this.labelControl2, 0);
			this.labelControl2.Size = new System.Drawing.Size(33, 19);
			this.labelControl2.TabIndex = 1;
			this.labelControl2.Text = "Кому";
			// 
			// pnOk
			// 
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 376);
			this.pnOk.Margin = new System.Windows.Forms.Padding(4);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(436, 90);
			this.pnOk.TabIndex = 27;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.ImageOptions.Image = global::SC.Cash.Properties.Resources.save;
			this.btnOk.Location = new System.Drawing.Point(277, 21);
			this.btnOk.Margin = new System.Windows.Forms.Padding(11, 9, 11, 9);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(140, 50);
			this.btnOk.TabIndex = 22;
			this.btnOk.Text = "Сохранить";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(159, 21);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(11, 9, 11, 9);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 29);
			this.btnCancel.TabIndex = 23;
			this.btnCancel.Text = "Отмена";
			// 
			// labelControl3
			// 
			this.pnMain.SetColumn(this.labelControl3, 0);
			this.labelControl3.Location = new System.Drawing.Point(4, 72);
			this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
			this.labelControl3.Name = "labelControl3";
			this.pnMain.SetRow(this.labelControl3, 2);
			this.labelControl3.Size = new System.Drawing.Size(64, 19);
			this.labelControl3.TabIndex = 10;
			this.labelControl3.Text = "Категория";
			// 
			// cbCategory
			// 
			this.pnMain.SetColumn(this.cbCategory, 1);
			this.cbCategory.Location = new System.Drawing.Point(100, 72);
			this.cbCategory.Margin = new System.Windows.Forms.Padding(4);
			this.cbCategory.Name = "cbCategory";
			this.cbCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbCategory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.pnMain.SetRow(this.cbCategory, 2);
			this.cbCategory.Size = new System.Drawing.Size(332, 26);
			this.cbCategory.TabIndex = 11;
			// 
			// FrmNewOperation
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(436, 466);
			this.Controls.Add(this.pnMain);
			this.Controls.Add(this.pnOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FrmNewOperation";
			this.Text = "Новая операция";
			((System.ComponentModel.ISupportInitialize)(this.pnMain)).EndInit();
			this.pnMain.ResumeLayout(false);
			this.pnMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbToUser.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).EndInit();
			this.pnOk.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cbCategory.Properties)).EndInit();
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
	}
}