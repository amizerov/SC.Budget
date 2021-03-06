namespace SwissClean.MVP.CreateRequest
{
	partial class CreateRequestView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateRequestView));
			this.pnMain = new DevExpress.Utils.Layout.TablePanel();
			this.txtComment = new DevExpress.XtraEditors.MemoEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.txtAmount = new DevExpress.XtraEditors.TextEdit();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.pnOk = new DevExpress.XtraEditors.PanelControl();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.pnMain)).BeginInit();
			this.pnMain.SuspendLayout();
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
			this.pnMain.Controls.Add(this.txtComment);
			this.pnMain.Controls.Add(this.labelControl1);
			this.pnMain.Controls.Add(this.txtAmount);
			this.pnMain.Controls.Add(this.labelControl4);
			this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnMain.Location = new System.Drawing.Point(0, 0);
			this.pnMain.Name = "pnMain";
			this.pnMain.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
			this.pnMain.Size = new System.Drawing.Size(334, 187);
			this.pnMain.TabIndex = 28;
			// 
			// txtComment
			// 
			this.pnMain.SetColumn(this.txtComment, 1);
			this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtComment.Location = new System.Drawing.Point(86, 31);
			this.txtComment.Name = "txtComment";
			this.pnMain.SetRow(this.txtComment, 1);
			this.txtComment.Size = new System.Drawing.Size(245, 153);
			this.txtComment.TabIndex = 9;
			// 
			// labelControl1
			// 
			this.pnMain.SetColumn(this.labelControl1, 0);
			this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelControl1.Location = new System.Drawing.Point(3, 31);
			this.labelControl1.Name = "labelControl1";
			this.pnMain.SetRow(this.labelControl1, 1);
			this.labelControl1.Size = new System.Drawing.Size(77, 15);
			this.labelControl1.TabIndex = 8;
			this.labelControl1.Text = "Комментарий";
			// 
			// txtAmount
			// 
			this.pnMain.SetColumn(this.txtAmount, 1);
			this.txtAmount.EditValue = "0";
			this.txtAmount.Location = new System.Drawing.Point(86, 3);
			this.txtAmount.Name = "txtAmount";
			this.txtAmount.Properties.DisplayFormat.FormatString = "0.00";
			this.txtAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtAmount.Properties.Mask.EditMask = "n";
			this.txtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.pnMain.SetRow(this.txtAmount, 0);
			this.txtAmount.Size = new System.Drawing.Size(245, 22);
			this.txtAmount.TabIndex = 7;
			// 
			// labelControl4
			// 
			this.pnMain.SetColumn(this.labelControl4, 0);
			this.labelControl4.Location = new System.Drawing.Point(3, 3);
			this.labelControl4.Name = "labelControl4";
			this.pnMain.SetRow(this.labelControl4, 0);
			this.labelControl4.Size = new System.Drawing.Size(38, 15);
			this.labelControl4.TabIndex = 5;
			this.labelControl4.Text = "Сумма";
			// 
			// pnOk
			// 
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 187);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(334, 71);
			this.pnOk.TabIndex = 29;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.ImageOptions.Image = global::SwissClean.Properties.Resources.save;
			this.btnOk.Location = new System.Drawing.Point(196, 17);
			this.btnOk.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(122, 40);
			this.btnOk.TabIndex = 22;
			this.btnOk.Text = "Сохранить";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(92, 17);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(87, 30);
			this.btnCancel.TabIndex = 23;
			this.btnCancel.Text = "Отмена";
			// 
			// CreateRequestView
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(334, 258);
			this.Controls.Add(this.pnMain);
			this.Controls.Add(this.pnOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CreateRequestView";
			this.Text = "Создать запрос на получение денег";
			((System.ComponentModel.ISupportInitialize)(this.pnMain)).EndInit();
			this.pnMain.ResumeLayout(false);
			this.pnMain.PerformLayout();
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
	}
}