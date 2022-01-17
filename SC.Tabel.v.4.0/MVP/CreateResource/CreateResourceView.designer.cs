namespace SwissClean.MVP.CreateResource
{
    partial class ResourceView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourceView));
			this.grUserCreate = new DevExpress.XtraEditors.GroupControl();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lbName = new DevExpress.XtraEditors.LabelControl();
			this.checkFreeLance = new DevExpress.XtraEditors.CheckEdit();
			this.tbName = new DevExpress.XtraEditors.TextEdit();
			this.lbRub = new DevExpress.XtraEditors.LabelControl();
			this.tbOfficialSalary = new DevExpress.XtraEditors.TextEdit();
			this.tbPhone = new System.Windows.Forms.MaskedTextBox();
			this.lbPhone = new DevExpress.XtraEditors.LabelControl();
			this.lbOfficialSalary = new DevExpress.XtraEditors.LabelControl();
			this.tbCard = new System.Windows.Forms.MaskedTextBox();
			this.lbCard = new DevExpress.XtraEditors.LabelControl();
			this.lblErrorCreate = new DevExpress.XtraEditors.LabelControl();
			this.btCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btOk = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.grUserCreate)).BeginInit();
			this.grUserCreate.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.checkFreeLance.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbOfficialSalary.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// grUserCreate
			// 
			this.grUserCreate.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.grUserCreate.Appearance.Options.UseBackColor = true;
			this.grUserCreate.Controls.Add(this.tableLayoutPanel1);
			this.grUserCreate.Controls.Add(this.lblErrorCreate);
			this.grUserCreate.Controls.Add(this.btCancel);
			this.grUserCreate.Controls.Add(this.btOk);
			this.grUserCreate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grUserCreate.Location = new System.Drawing.Point(0, 0);
			this.grUserCreate.Name = "grUserCreate";
			this.grUserCreate.ShowCaption = false;
			this.grUserCreate.Size = new System.Drawing.Size(513, 310);
			this.grUserCreate.TabIndex = 0;
			this.grUserCreate.Text = "CreateUser";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.25253F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.080808F));
			this.tableLayoutPanel1.Controls.Add(this.lbName, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.checkFreeLance, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.tbName, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.lbRub, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.tbOfficialSalary, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.tbPhone, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.lbPhone, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.lbOfficialSalary, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.tbCard, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.lbCard, 1, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(12);
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(509, 205);
			this.tableLayoutPanel1.TabIndex = 27;
			// 
			// lbName
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.lbName, 4);
			this.lbName.Location = new System.Drawing.Point(15, 15);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(97, 15);
			this.lbName.TabIndex = 12;
			this.lbName.Text = "Сотрудник (ФИО)";
			// 
			// checkFreeLance
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.checkFreeLance, 4);
			this.checkFreeLance.Location = new System.Drawing.Point(15, 159);
			this.checkFreeLance.Name = "checkFreeLance";
			this.checkFreeLance.Properties.Caption = "Мобильный сотрудник";
			this.checkFreeLance.Size = new System.Drawing.Size(171, 19);
			this.checkFreeLance.TabIndex = 26;
			this.checkFreeLance.CheckedChanged += new System.EventHandler(this.CheckFreeLance_CheckedChanged);
			// 
			// tbName
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.tbName, 4);
			this.tbName.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbName.Location = new System.Drawing.Point(15, 51);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(479, 22);
			this.tbName.TabIndex = 20;
			this.tbName.EditValueChanged += new System.EventHandler(this.TbName_EditValueChanged);
			this.tbName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbName_KeyPress);
			this.tbName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbName_KeyUp);
			// 
			// lbRub
			// 
			this.lbRub.Location = new System.Drawing.Point(459, 123);
			this.lbRub.Name = "lbRub";
			this.lbRub.Size = new System.Drawing.Size(20, 15);
			this.lbRub.TabIndex = 24;
			this.lbRub.Text = "руб";
			// 
			// tbOfficialSalary
			// 
			this.tbOfficialSalary.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbOfficialSalary.EditValue = "0";
			this.tbOfficialSalary.Location = new System.Drawing.Point(337, 123);
			this.tbOfficialSalary.Name = "tbOfficialSalary";
			this.tbOfficialSalary.Properties.DisplayFormat.FormatString = "0.00";
			this.tbOfficialSalary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.tbOfficialSalary.Properties.Mask.EditMask = "n";
			this.tbOfficialSalary.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.tbOfficialSalary.Size = new System.Drawing.Size(116, 22);
			this.tbOfficialSalary.TabIndex = 25;
			this.tbOfficialSalary.EditValueChanged += new System.EventHandler(this.TbOfficialSalary_EditValueChanged);
			// 
			// tbPhone
			// 
			this.tbPhone.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbPhone.Location = new System.Drawing.Point(15, 123);
			this.tbPhone.Mask = "+7(999) 000-0000";
			this.tbPhone.Name = "tbPhone";
			this.tbPhone.Size = new System.Drawing.Size(155, 23);
			this.tbPhone.TabIndex = 21;
			this.tbPhone.TextChanged += new System.EventHandler(this.TbPhone_TextChanged);
			// 
			// lbPhone
			// 
			this.lbPhone.Location = new System.Drawing.Point(15, 87);
			this.lbPhone.Name = "lbPhone";
			this.lbPhone.Size = new System.Drawing.Size(49, 15);
			this.lbPhone.TabIndex = 16;
			this.lbPhone.Text = "Телефон";
			// 
			// lbOfficialSalary
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.lbOfficialSalary, 2);
			this.lbOfficialSalary.Location = new System.Drawing.Point(337, 87);
			this.lbOfficialSalary.Name = "lbOfficialSalary";
			this.lbOfficialSalary.Size = new System.Drawing.Size(116, 15);
			this.lbOfficialSalary.TabIndex = 23;
			this.lbOfficialSalary.Text = "Оклад официальный";
			// 
			// tbCard
			// 
			this.tbCard.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbCard.Location = new System.Drawing.Point(176, 123);
			this.tbCard.Mask = "0000-0000-0000-0000";
			this.tbCard.Name = "tbCard";
			this.tbCard.Size = new System.Drawing.Size(155, 23);
			this.tbCard.TabIndex = 22;
			this.tbCard.TextChanged += new System.EventHandler(this.TbCard_TextChanged);
			// 
			// lbCard
			// 
			this.lbCard.Location = new System.Drawing.Point(176, 87);
			this.lbCard.Name = "lbCard";
			this.lbCard.Size = new System.Drawing.Size(31, 15);
			this.lbCard.TabIndex = 15;
			this.lbCard.Text = "Карта";
			// 
			// lblErrorCreate
			// 
			this.lblErrorCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblErrorCreate.Appearance.ForeColor = System.Drawing.Color.Red;
			this.lblErrorCreate.Appearance.Options.UseForeColor = true;
			this.lblErrorCreate.Location = new System.Drawing.Point(244, 212);
			this.lblErrorCreate.Name = "lblErrorCreate";
			this.lblErrorCreate.Size = new System.Drawing.Size(191, 15);
			this.lblErrorCreate.TabIndex = 19;
			this.lblErrorCreate.Text = "Не все поля заполнены корректно";
			this.lblErrorCreate.Visible = false;
			// 
			// btCancel
			// 
			this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.Location = new System.Drawing.Point(244, 242);
			this.btCancel.Margin = new System.Windows.Forms.Padding(12);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(87, 35);
			this.btCancel.TabIndex = 14;
			this.btCancel.Text = "Отмена";
			// 
			// btOk
			// 
			this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btOk.ImageOptions.Image = global::SwissClean.Properties.Resources.save;
			this.btOk.Location = new System.Drawing.Point(355, 242);
			this.btOk.Margin = new System.Windows.Forms.Padding(12);
			this.btOk.Name = "btOk";
			this.btOk.Size = new System.Drawing.Size(136, 46);
			this.btOk.TabIndex = 13;
			this.btOk.Text = "Сохранить";
			this.btOk.Click += new System.EventHandler(this.BtOk_Click);
			// 
			// ResourceView
			// 
			this.AcceptButton = this.btOk;
			this.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btCancel;
			this.ClientSize = new System.Drawing.Size(513, 310);
			this.Controls.Add(this.grUserCreate);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ResourceView";
			this.ShowInTaskbar = false;
			this.Text = "Добавление сотрудника";
			((System.ComponentModel.ISupportInitialize)(this.grUserCreate)).EndInit();
			this.grUserCreate.ResumeLayout(false);
			this.grUserCreate.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.checkFreeLance.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbOfficialSalary.Properties)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grUserCreate;
        private DevExpress.XtraEditors.LabelControl lblErrorCreate;
        private DevExpress.XtraEditors.LabelControl lbCard;
        private DevExpress.XtraEditors.LabelControl lbPhone;
        private DevExpress.XtraEditors.SimpleButton btCancel;
        private DevExpress.XtraEditors.SimpleButton btOk;
        private DevExpress.XtraEditors.LabelControl lbName;
        private DevExpress.XtraEditors.TextEdit tbName;
        private System.Windows.Forms.MaskedTextBox tbPhone;
        private System.Windows.Forms.MaskedTextBox tbCard;
        private DevExpress.XtraEditors.TextEdit tbOfficialSalary;
        private DevExpress.XtraEditors.LabelControl lbRub;
        private DevExpress.XtraEditors.LabelControl lbOfficialSalary;
		private DevExpress.XtraEditors.CheckEdit checkFreeLance;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}