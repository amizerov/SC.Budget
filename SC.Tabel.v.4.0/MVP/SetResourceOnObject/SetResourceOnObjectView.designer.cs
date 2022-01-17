namespace SwissClean.MVP.SetResourceOnObject
{
    partial class SetResourceOnObjectView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetResourceOnObjectView));
			this.groupLP = new DevExpress.XtraEditors.GroupControl();
			this.lblResourceCreate = new DevExpress.XtraEditors.LabelControl();
			this.checkFreeLance = new DevExpress.XtraEditors.CheckEdit();
			this.cbResource = new DevExpress.XtraEditors.ComboBoxEdit();
			this.txtPhone = new DevExpress.XtraEditors.TextEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.lblPositionCreate = new DevExpress.XtraEditors.LabelControl();
			this.txtOfficialSalary = new DevExpress.XtraEditors.TextEdit();
			this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.lblErrorCreate = new DevExpress.XtraEditors.LabelControl();
			this.lblObject = new System.Windows.Forms.Label();
			this.txtSalary = new DevExpress.XtraEditors.TextEdit();
			this.cbPosition = new DevExpress.XtraEditors.ComboBoxEdit();
			this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
			((System.ComponentModel.ISupportInitialize)(this.groupLP)).BeginInit();
			this.groupLP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.checkFreeLance.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbResource.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOfficialSalary.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSalary.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbPosition.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
			this.tablePanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupLP
			// 
			this.groupLP.Controls.Add(this.tablePanel1);
			this.groupLP.Controls.Add(this.btnCancel);
			this.groupLP.Controls.Add(this.btnOk);
			this.groupLP.Controls.Add(this.lblErrorCreate);
			this.groupLP.Controls.Add(this.lblObject);
			this.groupLP.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupLP.Location = new System.Drawing.Point(0, 0);
			this.groupLP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupLP.Name = "groupLP";
			this.groupLP.ShowCaption = false;
			this.groupLP.Size = new System.Drawing.Size(688, 321);
			this.groupLP.TabIndex = 3;
			// 
			// lblResourceCreate
			// 
			this.tablePanel1.SetColumn(this.lblResourceCreate, 0);
			this.lblResourceCreate.Location = new System.Drawing.Point(3, 4);
			this.lblResourceCreate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.lblResourceCreate.Name = "lblResourceCreate";
			this.tablePanel1.SetRow(this.lblResourceCreate, 0);
			this.lblResourceCreate.Size = new System.Drawing.Size(103, 17);
			this.lblResourceCreate.TabIndex = 5;
			this.lblResourceCreate.Text = "Сотрудник (ФИО)";
			// 
			// checkFreeLance
			// 
			this.tablePanel1.SetColumn(this.checkFreeLance, 0);
			this.checkFreeLance.Location = new System.Drawing.Point(3, 118);
			this.checkFreeLance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.checkFreeLance.Name = "checkFreeLance";
			this.checkFreeLance.Properties.Caption = "Мобильный сотрудник";
			this.tablePanel1.SetRow(this.checkFreeLance, 4);
			this.checkFreeLance.Size = new System.Drawing.Size(314, 21);
			this.checkFreeLance.TabIndex = 13;
			this.checkFreeLance.CheckedChanged += new System.EventHandler(this.CheckFreelance_CheckedChanged);
			// 
			// cbResource
			// 
			this.tablePanel1.SetColumn(this.cbResource, 0);
			this.cbResource.Location = new System.Drawing.Point(3, 29);
			this.cbResource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cbResource.Name = "cbResource";
			this.cbResource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbResource.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.tablePanel1.SetRow(this.cbResource, 1);
			this.cbResource.Size = new System.Drawing.Size(314, 24);
			this.cbResource.TabIndex = 2;
			this.cbResource.SelectedIndexChanged += new System.EventHandler(this.CbResource_SelectedIndexChanged);
			// 
			// txtPhone
			// 
			this.tablePanel1.SetColumn(this.txtPhone, 3);
			this.txtPhone.Location = new System.Drawing.Point(509, 29);
			this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Properties.ReadOnly = true;
			this.tablePanel1.SetRow(this.txtPhone, 1);
			this.txtPhone.Size = new System.Drawing.Size(172, 24);
			this.txtPhone.TabIndex = 10;
			// 
			// labelControl1
			// 
			this.tablePanel1.SetColumn(this.labelControl1, 3);
			this.labelControl1.Location = new System.Drawing.Point(509, 4);
			this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.labelControl1.Name = "labelControl1";
			this.tablePanel1.SetRow(this.labelControl1, 0);
			this.labelControl1.Size = new System.Drawing.Size(52, 17);
			this.labelControl1.TabIndex = 9;
			this.labelControl1.Text = "Телефон";
			// 
			// lblPositionCreate
			// 
			this.tablePanel1.SetColumn(this.lblPositionCreate, 0);
			this.lblPositionCreate.Location = new System.Drawing.Point(3, 61);
			this.lblPositionCreate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.lblPositionCreate.Name = "lblPositionCreate";
			this.tablePanel1.SetRow(this.lblPositionCreate, 2);
			this.lblPositionCreate.Size = new System.Drawing.Size(66, 17);
			this.lblPositionCreate.TabIndex = 4;
			this.lblPositionCreate.Text = "Должность";
			// 
			// txtOfficialSalary
			// 
			this.tablePanel1.SetColumn(this.txtOfficialSalary, 1);
			this.txtOfficialSalary.Location = new System.Drawing.Point(323, 29);
			this.txtOfficialSalary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtOfficialSalary.Name = "txtOfficialSalary";
			this.txtOfficialSalary.Properties.ReadOnly = true;
			this.tablePanel1.SetRow(this.txtOfficialSalary, 1);
			this.txtOfficialSalary.Size = new System.Drawing.Size(150, 24);
			this.txtOfficialSalary.TabIndex = 10;
			// 
			// labelControl6
			// 
			this.tablePanel1.SetColumn(this.labelControl6, 2);
			this.labelControl6.Location = new System.Drawing.Point(479, 29);
			this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.labelControl6.Name = "labelControl6";
			this.tablePanel1.SetRow(this.labelControl6, 1);
			this.labelControl6.Size = new System.Drawing.Size(24, 17);
			this.labelControl6.TabIndex = 9;
			this.labelControl6.Text = "Руб.";
			// 
			// labelControl5
			// 
			this.tablePanel1.SetColumn(this.labelControl5, 1);
			this.labelControl5.Location = new System.Drawing.Point(323, 4);
			this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.labelControl5.Name = "labelControl5";
			this.tablePanel1.SetRow(this.labelControl5, 0);
			this.labelControl5.Size = new System.Drawing.Size(123, 17);
			this.labelControl5.TabIndex = 9;
			this.labelControl5.Text = "Оклад официальный";
			// 
			// labelControl3
			// 
			this.tablePanel1.SetColumn(this.labelControl3, 1);
			this.labelControl3.Location = new System.Drawing.Point(323, 61);
			this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.labelControl3.Name = "labelControl3";
			this.tablePanel1.SetRow(this.labelControl3, 2);
			this.labelControl3.Size = new System.Drawing.Size(37, 17);
			this.labelControl3.TabIndex = 9;
			this.labelControl3.Text = "Оклад";
			// 
			// labelControl4
			// 
			this.tablePanel1.SetColumn(this.labelControl4, 2);
			this.labelControl4.Location = new System.Drawing.Point(479, 86);
			this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.labelControl4.Name = "labelControl4";
			this.tablePanel1.SetRow(this.labelControl4, 3);
			this.labelControl4.Size = new System.Drawing.Size(24, 17);
			this.labelControl4.TabIndex = 9;
			this.labelControl4.Text = "Руб.";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(419, 244);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(12, 13, 12, 13);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(87, 39);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Отмена";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.ImageOptions.Image = global::SwissClean.Properties.Resources.save;
			this.btnOk.Location = new System.Drawing.Point(530, 244);
			this.btnOk.Margin = new System.Windows.Forms.Padding(12, 13, 12, 13);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(136, 52);
			this.btnOk.TabIndex = 7;
			this.btnOk.Text = "Сохранить";
			this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// lblErrorCreate
			// 
			this.lblErrorCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblErrorCreate.Appearance.ForeColor = System.Drawing.Color.Red;
			this.lblErrorCreate.Appearance.Options.UseForeColor = true;
			this.lblErrorCreate.Location = new System.Drawing.Point(419, 210);
			this.lblErrorCreate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.lblErrorCreate.Name = "lblErrorCreate";
			this.lblErrorCreate.Size = new System.Drawing.Size(209, 17);
			this.lblErrorCreate.TabIndex = 11;
			this.lblErrorCreate.Text = "Не все поля заполнены корректно";
			this.lblErrorCreate.Visible = false;
			// 
			// lblObject
			// 
			this.lblObject.AutoSize = true;
			this.lblObject.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblObject.Location = new System.Drawing.Point(2, 2);
			this.lblObject.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
			this.lblObject.Name = "lblObject";
			this.lblObject.Padding = new System.Windows.Forms.Padding(12, 13, 12, 13);
			this.lblObject.Size = new System.Drawing.Size(83, 43);
			this.lblObject.TabIndex = 29;
			this.lblObject.Text = "Объект: ";
			// 
			// txtSalary
			// 
			this.tablePanel1.SetColumn(this.txtSalary, 1);
			this.txtSalary.EditValue = "0";
			this.txtSalary.Location = new System.Drawing.Point(323, 85);
			this.txtSalary.Name = "txtSalary";
			this.txtSalary.Properties.DisplayFormat.FormatString = "0.00";
			this.txtSalary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.txtSalary.Properties.Mask.EditMask = "n";
			this.txtSalary.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.tablePanel1.SetRow(this.txtSalary, 3);
			this.txtSalary.Size = new System.Drawing.Size(150, 24);
			this.txtSalary.TabIndex = 26;
			// 
			// cbPosition
			// 
			this.tablePanel1.SetColumn(this.cbPosition, 0);
			this.cbPosition.Location = new System.Drawing.Point(3, 86);
			this.cbPosition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cbPosition.Name = "cbPosition";
			this.cbPosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.tablePanel1.SetRow(this.cbPosition, 3);
			this.cbPosition.Size = new System.Drawing.Size(314, 24);
			this.cbPosition.TabIndex = 27;
			this.cbPosition.SelectedIndexChanged += new System.EventHandler(this.cbPosition_SelectedIndexChanged);
			// 
			// tablePanel1
			// 
			this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 55F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F)});
			this.tablePanel1.Controls.Add(this.checkFreeLance);
			this.tablePanel1.Controls.Add(this.lblResourceCreate);
			this.tablePanel1.Controls.Add(this.labelControl4);
			this.tablePanel1.Controls.Add(this.labelControl3);
			this.tablePanel1.Controls.Add(this.lblPositionCreate);
			this.tablePanel1.Controls.Add(this.cbResource);
			this.tablePanel1.Controls.Add(this.txtSalary);
			this.tablePanel1.Controls.Add(this.labelControl5);
			this.tablePanel1.Controls.Add(this.cbPosition);
			this.tablePanel1.Controls.Add(this.txtOfficialSalary);
			this.tablePanel1.Controls.Add(this.labelControl6);
			this.tablePanel1.Controls.Add(this.txtPhone);
			this.tablePanel1.Controls.Add(this.labelControl1);
			this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tablePanel1.Location = new System.Drawing.Point(2, 45);
			this.tablePanel1.Name = "tablePanel1";
			this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F)});
			this.tablePanel1.Size = new System.Drawing.Size(684, 150);
			this.tablePanel1.TabIndex = 30;
			// 
			// SetResourceOnObjectView
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(688, 321);
			this.Controls.Add(this.groupLP);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SetResourceOnObjectView";
			this.ShowInTaskbar = false;
			this.Text = "Назначение сотрудника";
			((System.ComponentModel.ISupportInitialize)(this.groupLP)).EndInit();
			this.groupLP.ResumeLayout(false);
			this.groupLP.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.checkFreeLance.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbResource.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtOfficialSalary.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSalary.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbPosition.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
			this.tablePanel1.ResumeLayout(false);
			this.tablePanel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupLP;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.LabelControl lblResourceCreate;
        private DevExpress.XtraEditors.LabelControl lblPositionCreate;
        private DevExpress.XtraEditors.ComboBoxEdit cbResource;
        private DevExpress.XtraEditors.LabelControl lblErrorCreate;
        private DevExpress.XtraEditors.CheckEdit checkFreeLance;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtOfficialSalary;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
		private System.Windows.Forms.Label lblObject;
		private DevExpress.XtraEditors.TextEdit txtSalary;
		private DevExpress.Utils.Layout.TablePanel tablePanel1;
		private DevExpress.XtraEditors.ComboBoxEdit cbPosition;
	}
}