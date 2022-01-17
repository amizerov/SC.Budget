namespace SC.Zakup.Views
{
	partial class FrmNewOrEditDetail
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewOrEditDetail));
			this.pnOk = new System.Windows.Forms.Panel();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
			this.chbNoUsed = new DevExpress.XtraEditors.CheckEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.cbCategory = new DevExpress.XtraEditors.ComboBoxEdit();
			this.txtName = new DevExpress.XtraEditors.TextEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.cbClass = new DevExpress.XtraEditors.ComboBoxEdit();
			this.pnOk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
			this.tablePanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chbNoUsed.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbCategory.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbClass.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// pnOk
			// 
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 180);
			this.pnOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(684, 118);
			this.pnOk.TabIndex = 2;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(352, 35);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(136, 44);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Отмена";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(513, 35);
			this.btnOk.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(153, 64);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "Ок";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// tablePanel1
			// 
			this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
			this.tablePanel1.Controls.Add(this.cbClass);
			this.tablePanel1.Controls.Add(this.labelControl3);
			this.tablePanel1.Controls.Add(this.chbNoUsed);
			this.tablePanel1.Controls.Add(this.labelControl2);
			this.tablePanel1.Controls.Add(this.cbCategory);
			this.tablePanel1.Controls.Add(this.txtName);
			this.tablePanel1.Controls.Add(this.labelControl1);
			this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tablePanel1.Location = new System.Drawing.Point(0, 0);
			this.tablePanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tablePanel1.Name = "tablePanel1";
			this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
			this.tablePanel1.Size = new System.Drawing.Size(684, 180);
			this.tablePanel1.TabIndex = 3;
			// 
			// chbNoUsed
			// 
			this.tablePanel1.SetColumn(this.chbNoUsed, 0);
			this.tablePanel1.SetColumnSpan(this.chbNoUsed, 2);
			this.chbNoUsed.Location = new System.Drawing.Point(4, 124);
			this.chbNoUsed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.chbNoUsed.Name = "chbNoUsed";
			this.chbNoUsed.Properties.Caption = "Архивная детализация";
			this.tablePanel1.SetRow(this.chbNoUsed, 3);
			this.chbNoUsed.Size = new System.Drawing.Size(657, 29);
			this.chbNoUsed.TabIndex = 5;
			// 
			// labelControl2
			// 
			this.tablePanel1.SetColumn(this.labelControl2, 0);
			this.labelControl2.Location = new System.Drawing.Point(4, 44);
			this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.labelControl2.Name = "labelControl2";
			this.tablePanel1.SetRow(this.labelControl2, 1);
			this.labelControl2.Size = new System.Drawing.Size(222, 25);
			this.labelControl2.TabIndex = 3;
			this.labelControl2.Text = "Категория по умолчанию";
			// 
			// cbCategory
			// 
			this.tablePanel1.SetColumn(this.cbCategory, 1);
			this.cbCategory.Location = new System.Drawing.Point(234, 44);
			this.cbCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cbCategory.Name = "cbCategory";
			this.cbCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbCategory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.tablePanel1.SetRow(this.cbCategory, 1);
			this.cbCategory.Size = new System.Drawing.Size(446, 32);
			this.cbCategory.TabIndex = 2;
			// 
			// txtName
			// 
			this.tablePanel1.SetColumn(this.txtName, 1);
			this.txtName.Location = new System.Drawing.Point(234, 4);
			this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtName.Name = "txtName";
			this.tablePanel1.SetRow(this.txtName, 0);
			this.txtName.Size = new System.Drawing.Size(446, 32);
			this.txtName.TabIndex = 1;
			// 
			// labelControl1
			// 
			this.tablePanel1.SetColumn(this.labelControl1, 0);
			this.labelControl1.Location = new System.Drawing.Point(4, 4);
			this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.labelControl1.Name = "labelControl1";
			this.tablePanel1.SetRow(this.labelControl1, 0);
			this.labelControl1.Size = new System.Drawing.Size(131, 25);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "Наименование";
			// 
			// labelControl3
			// 
			this.tablePanel1.SetColumn(this.labelControl3, 0);
			this.labelControl3.Location = new System.Drawing.Point(4, 84);
			this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
			this.labelControl3.Name = "labelControl3";
			this.tablePanel1.SetRow(this.labelControl3, 2);
			this.labelControl3.Size = new System.Drawing.Size(49, 25);
			this.labelControl3.TabIndex = 6;
			this.labelControl3.Text = "Класс";
			// 
			// cbClass
			// 
			this.tablePanel1.SetColumn(this.cbClass, 1);
			this.cbClass.Location = new System.Drawing.Point(234, 84);
			this.cbClass.Margin = new System.Windows.Forms.Padding(4);
			this.cbClass.Name = "cbClass";
			this.cbClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.tablePanel1.SetRow(this.cbClass, 2);
			this.cbClass.Size = new System.Drawing.Size(446, 32);
			this.cbClass.TabIndex = 7;
			// 
			// FrmNewOrEditDetail
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(684, 298);
			this.Controls.Add(this.tablePanel1);
			this.Controls.Add(this.pnOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "FrmNewOrEditDetail";
			this.Text = "Новая детализация";
			this.pnOk.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
			this.tablePanel1.ResumeLayout(false);
			this.tablePanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.chbNoUsed.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbCategory.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbClass.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnOk;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.SimpleButton btnOk;
		private DevExpress.Utils.Layout.TablePanel tablePanel1;
		private DevExpress.XtraEditors.CheckEdit chbNoUsed;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.ComboBoxEdit cbCategory;
		private DevExpress.XtraEditors.TextEdit txtName;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.ComboBoxEdit cbClass;
		private DevExpress.XtraEditors.LabelControl labelControl3;
	}
}