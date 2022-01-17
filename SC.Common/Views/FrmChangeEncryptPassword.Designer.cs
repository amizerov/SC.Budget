namespace SC.Common.Views
{
	partial class FrmChangeEncryptPassword
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChangeEncryptPassword));
			this.pnOk = new DevExpress.XtraEditors.PanelControl();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
			this.txtNewPassConfirm = new DevExpress.XtraEditors.TextEdit();
			this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
			this.txtNewPass = new DevExpress.XtraEditors.TextEdit();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.lbPrevViewValue = new DevExpress.XtraEditors.LabelControl();
			this.lbPrevViewTitle = new DevExpress.XtraEditors.LabelControl();
			this.txtOldPass = new DevExpress.XtraEditors.TextEdit();
			this.lbOldPass = new DevExpress.XtraEditors.LabelControl();
			this.lbInfo = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).BeginInit();
			this.pnOk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
			this.tablePanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtNewPassConfirm.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNewPass.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOldPass.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// pnOk
			// 
			this.pnOk.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 448);
			this.pnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(1077, 100);
			this.pnOk.TabIndex = 30;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.ImageOptions.Image = global::SC.Common.Properties.Resources.save;
			this.btnOk.Location = new System.Drawing.Point(899, 24);
			this.btnOk.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(156, 55);
			this.btnOk.TabIndex = 22;
			this.btnOk.Text = "Сохранить";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(765, 24);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(111, 42);
			this.btnCancel.TabIndex = 23;
			this.btnCancel.Text = "Отмена";
			// 
			// tablePanel1
			// 
			this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
			this.tablePanel1.Controls.Add(this.txtNewPassConfirm);
			this.tablePanel1.Controls.Add(this.labelControl5);
			this.tablePanel1.Controls.Add(this.txtNewPass);
			this.tablePanel1.Controls.Add(this.labelControl4);
			this.tablePanel1.Controls.Add(this.lbPrevViewValue);
			this.tablePanel1.Controls.Add(this.lbPrevViewTitle);
			this.tablePanel1.Controls.Add(this.txtOldPass);
			this.tablePanel1.Controls.Add(this.lbOldPass);
			this.tablePanel1.Controls.Add(this.lbInfo);
			this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tablePanel1.Location = new System.Drawing.Point(0, 0);
			this.tablePanel1.Name = "tablePanel1";
			this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F)});
			this.tablePanel1.Size = new System.Drawing.Size(1077, 448);
			this.tablePanel1.TabIndex = 31;
			// 
			// txtNewPassConfirm
			// 
			this.tablePanel1.SetColumn(this.txtNewPassConfirm, 1);
			this.txtNewPassConfirm.Location = new System.Drawing.Point(208, 417);
			this.txtNewPassConfirm.Name = "txtNewPassConfirm";
			this.txtNewPassConfirm.Properties.UseSystemPasswordChar = true;
			this.tablePanel1.SetRow(this.txtNewPassConfirm, 5);
			this.txtNewPassConfirm.Size = new System.Drawing.Size(866, 28);
			this.txtNewPassConfirm.TabIndex = 9;
			// 
			// labelControl5
			// 
			this.tablePanel1.SetColumn(this.labelControl5, 0);
			this.labelControl5.Location = new System.Drawing.Point(3, 417);
			this.labelControl5.Name = "labelControl5";
			this.tablePanel1.SetRow(this.labelControl5, 5);
			this.labelControl5.Size = new System.Drawing.Size(199, 21);
			this.labelControl5.TabIndex = 8;
			this.labelControl5.Text = "Подтвердите новый пароль";
			// 
			// txtNewPass
			// 
			this.tablePanel1.SetColumn(this.txtNewPass, 1);
			this.txtNewPass.Location = new System.Drawing.Point(208, 383);
			this.txtNewPass.Name = "txtNewPass";
			this.txtNewPass.Properties.UseSystemPasswordChar = true;
			this.tablePanel1.SetRow(this.txtNewPass, 4);
			this.txtNewPass.Size = new System.Drawing.Size(866, 28);
			this.txtNewPass.TabIndex = 7;
			// 
			// labelControl4
			// 
			this.tablePanel1.SetColumn(this.labelControl4, 0);
			this.labelControl4.Location = new System.Drawing.Point(3, 383);
			this.labelControl4.Name = "labelControl4";
			this.tablePanel1.SetRow(this.labelControl4, 4);
			this.labelControl4.Size = new System.Drawing.Size(163, 21);
			this.labelControl4.TabIndex = 6;
			this.labelControl4.Text = "Введите новый пароль";
			// 
			// lbPrevViewValue
			// 
			this.lbPrevViewValue.Appearance.Options.UseTextOptions = true;
			this.lbPrevViewValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.lbPrevViewValue.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.lbPrevViewValue.AutoEllipsis = true;
			this.lbPrevViewValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
			this.lbPrevViewValue.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
			this.tablePanel1.SetColumn(this.lbPrevViewValue, 0);
			this.tablePanel1.SetColumnSpan(this.lbPrevViewValue, 2);
			this.lbPrevViewValue.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbPrevViewValue.Location = new System.Drawing.Point(3, 300);
			this.lbPrevViewValue.Name = "lbPrevViewValue";
			this.lbPrevViewValue.Padding = new System.Windows.Forms.Padding(10);
			this.tablePanel1.SetRow(this.lbPrevViewValue, 3);
			this.lbPrevViewValue.Size = new System.Drawing.Size(1071, 43);
			this.lbPrevViewValue.TabIndex = 5;
			this.lbPrevViewValue.Text = "Предпросмотр расшифровки текущим паролем";
			// 
			// lbPrevViewTitle
			// 
			this.tablePanel1.SetColumn(this.lbPrevViewTitle, 0);
			this.tablePanel1.SetColumnSpan(this.lbPrevViewTitle, 2);
			this.lbPrevViewTitle.Location = new System.Drawing.Point(3, 273);
			this.lbPrevViewTitle.Name = "lbPrevViewTitle";
			this.tablePanel1.SetRow(this.lbPrevViewTitle, 2);
			this.lbPrevViewTitle.Size = new System.Drawing.Size(348, 21);
			this.lbPrevViewTitle.TabIndex = 4;
			this.lbPrevViewTitle.Text = "Предпросмотр расшифровки текущим паролем:";
			// 
			// txtOldPass
			// 
			this.tablePanel1.SetColumn(this.txtOldPass, 1);
			this.txtOldPass.EditValue = "";
			this.txtOldPass.Location = new System.Drawing.Point(208, 239);
			this.txtOldPass.Name = "txtOldPass";
			this.txtOldPass.Properties.UseSystemPasswordChar = true;
			this.tablePanel1.SetRow(this.txtOldPass, 1);
			this.txtOldPass.Size = new System.Drawing.Size(866, 28);
			this.txtOldPass.TabIndex = 3;
			this.txtOldPass.EditValueChanged += new System.EventHandler(this.txtOldPass_EditValueChanged);
			// 
			// lbOldPass
			// 
			this.tablePanel1.SetColumn(this.lbOldPass, 0);
			this.lbOldPass.Location = new System.Drawing.Point(3, 239);
			this.lbOldPass.Name = "lbOldPass";
			this.tablePanel1.SetRow(this.lbOldPass, 1);
			this.lbOldPass.Size = new System.Drawing.Size(179, 21);
			this.lbOldPass.TabIndex = 1;
			this.lbOldPass.Text = "Введите текущий пароль";
			// 
			// lbInfo
			// 
			this.lbInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
			this.tablePanel1.SetColumn(this.lbInfo, 0);
			this.tablePanel1.SetColumnSpan(this.lbInfo, 2);
			this.lbInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbInfo.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftTop;
			this.lbInfo.ImageOptions.Image = global::SC.Common.Properties.Resources.about_32x32;
			this.lbInfo.Location = new System.Drawing.Point(3, 3);
			this.lbInfo.Name = "lbInfo";
			this.lbInfo.Padding = new System.Windows.Forms.Padding(10);
			this.tablePanel1.SetRow(this.lbInfo, 0);
			this.lbInfo.Size = new System.Drawing.Size(1071, 230);
			this.lbInfo.TabIndex = 0;
			this.lbInfo.Text = resources.GetString("lbInfo.Text");
			// 
			// FrmChangeEncryptPassword
			// 
			this.AcceptButton = this.btnCancel;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1077, 548);
			this.Controls.Add(this.tablePanel1);
			this.Controls.Add(this.pnOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmChangeEncryptPassword";
			this.Text = "Сменить пароль";
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).EndInit();
			this.pnOk.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
			this.tablePanel1.ResumeLayout(false);
			this.tablePanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtNewPassConfirm.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNewPass.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOldPass.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.PanelControl pnOk;
		private DevExpress.XtraEditors.SimpleButton btnOk;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.Utils.Layout.TablePanel tablePanel1;
		private DevExpress.XtraEditors.TextEdit txtOldPass;
		private DevExpress.XtraEditors.LabelControl lbOldPass;
		private DevExpress.XtraEditors.LabelControl lbInfo;
		private DevExpress.XtraEditors.TextEdit txtNewPassConfirm;
		private DevExpress.XtraEditors.LabelControl labelControl5;
		private DevExpress.XtraEditors.TextEdit txtNewPass;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraEditors.LabelControl lbPrevViewValue;
		private DevExpress.XtraEditors.LabelControl lbPrevViewTitle;
	}
}