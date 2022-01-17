namespace SwissClean.MVP.AddResource
{
    partial class CreateResourceView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateResourceView));
			this.grUserCreate = new DevExpress.XtraEditors.GroupControl();
			this.tbOfficialSalary = new DevExpress.XtraEditors.TextEdit();
			this.lbRub = new DevExpress.XtraEditors.LabelControl();
			this.lbOfficialSalary = new DevExpress.XtraEditors.LabelControl();
			this.tbCard = new System.Windows.Forms.MaskedTextBox();
			this.tbPhone = new System.Windows.Forms.MaskedTextBox();
			this.tbName = new DevExpress.XtraEditors.TextEdit();
			this.lblErrorCreate = new DevExpress.XtraEditors.LabelControl();
			this.lbCard = new DevExpress.XtraEditors.LabelControl();
			this.lbPhone = new DevExpress.XtraEditors.LabelControl();
			this.btcancel = new DevExpress.XtraEditors.SimpleButton();
			this.btOk = new DevExpress.XtraEditors.SimpleButton();
			this.lbName = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.grUserCreate)).BeginInit();
			this.grUserCreate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbOfficialSalary.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// grUserCreate
			// 
			this.grUserCreate.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.grUserCreate.Appearance.Options.UseBackColor = true;
			this.grUserCreate.Controls.Add(this.tbOfficialSalary);
			this.grUserCreate.Controls.Add(this.lbRub);
			this.grUserCreate.Controls.Add(this.lbOfficialSalary);
			this.grUserCreate.Controls.Add(this.tbCard);
			this.grUserCreate.Controls.Add(this.tbPhone);
			this.grUserCreate.Controls.Add(this.tbName);
			this.grUserCreate.Controls.Add(this.lblErrorCreate);
			this.grUserCreate.Controls.Add(this.lbCard);
			this.grUserCreate.Controls.Add(this.lbPhone);
			this.grUserCreate.Controls.Add(this.btcancel);
			this.grUserCreate.Controls.Add(this.btOk);
			this.grUserCreate.Controls.Add(this.lbName);
			this.grUserCreate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grUserCreate.Location = new System.Drawing.Point(0, 0);
			this.grUserCreate.Name = "grUserCreate";
			this.grUserCreate.ShowCaption = false;
			this.grUserCreate.Size = new System.Drawing.Size(326, 280);
			this.grUserCreate.TabIndex = 0;
			this.grUserCreate.Text = "CreateUser";
			// 
			// tbOfficialSalary
			// 
			this.tbOfficialSalary.EditValue = "0";
			this.tbOfficialSalary.Location = new System.Drawing.Point(185, 157);
			this.tbOfficialSalary.Name = "tbOfficialSalary";
			this.tbOfficialSalary.Properties.DisplayFormat.FormatString = "0.00";
			this.tbOfficialSalary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.tbOfficialSalary.Properties.Mask.EditMask = "n";
			this.tbOfficialSalary.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.tbOfficialSalary.Size = new System.Drawing.Size(71, 20);
			this.tbOfficialSalary.TabIndex = 25;
			this.tbOfficialSalary.EditValueChanged += new System.EventHandler(this.TbOfficialSalary_EditValueChanged);
			// 
			// lbRub
			// 
			this.lbRub.Location = new System.Drawing.Point(273, 160);
			this.lbRub.Name = "lbRub";
			this.lbRub.Size = new System.Drawing.Size(18, 13);
			this.lbRub.TabIndex = 24;
			this.lbRub.Text = "руб";
			// 
			// lbOfficialSalary
			// 
			this.lbOfficialSalary.Location = new System.Drawing.Point(185, 138);
			this.lbOfficialSalary.Name = "lbOfficialSalary";
			this.lbOfficialSalary.Size = new System.Drawing.Size(106, 13);
			this.lbOfficialSalary.TabIndex = 23;
			this.lbOfficialSalary.Text = "Оклад официальный";
			// 
			// tbCard
			// 
			this.tbCard.Location = new System.Drawing.Point(29, 157);
			this.tbCard.Mask = "0000-0000-0000-0000";
			this.tbCard.Name = "tbCard";
			this.tbCard.Size = new System.Drawing.Size(116, 21);
			this.tbCard.TabIndex = 22;
			this.tbCard.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.TbCard_MaskInputRejected);
			// 
			// tbPhone
			// 
			this.tbPhone.Location = new System.Drawing.Point(29, 106);
			this.tbPhone.Mask = "+7(999) 000-0000";
			this.tbPhone.Name = "tbPhone";
			this.tbPhone.Size = new System.Drawing.Size(116, 21);
			this.tbPhone.TabIndex = 21;
			this.tbPhone.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.TbPhone_MaskInputRejected);
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(30, 53);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(261, 20);
			this.tbName.TabIndex = 20;
			this.tbName.EditValueChanged += new System.EventHandler(this.TbName_EditValueChanged);
			// 
			// lblErrorCreate
			// 
			this.lblErrorCreate.Appearance.ForeColor = System.Drawing.Color.Red;
			this.lblErrorCreate.Appearance.Options.UseForeColor = true;
			this.lblErrorCreate.Location = new System.Drawing.Point(30, 192);
			this.lblErrorCreate.Name = "lblErrorCreate";
			this.lblErrorCreate.Size = new System.Drawing.Size(175, 13);
			this.lblErrorCreate.TabIndex = 19;
			this.lblErrorCreate.Text = "Не все поля заполнены корректно";
			this.lblErrorCreate.Visible = false;
			// 
			// lbCard
			// 
			this.lbCard.Location = new System.Drawing.Point(29, 138);
			this.lbCard.Name = "lbCard";
			this.lbCard.Size = new System.Drawing.Size(31, 13);
			this.lbCard.TabIndex = 15;
			this.lbCard.Text = "Карта";
			// 
			// lbPhone
			// 
			this.lbPhone.Location = new System.Drawing.Point(30, 87);
			this.lbPhone.Name = "lbPhone";
			this.lbPhone.Size = new System.Drawing.Size(44, 13);
			this.lbPhone.TabIndex = 16;
			this.lbPhone.Text = "Телефон";
			// 
			// btcancel
			// 
			this.btcancel.Location = new System.Drawing.Point(70, 211);
			this.btcancel.Name = "btcancel";
			this.btcancel.Size = new System.Drawing.Size(75, 30);
			this.btcancel.TabIndex = 14;
			this.btcancel.Text = "Отмена";
			this.btcancel.Click += new System.EventHandler(this.Btcancel_Click);
			// 
			// btOk
			// 
			this.btOk.ImageOptions.Image = global::SwissClean.Properties.Resources.save;
			this.btOk.Location = new System.Drawing.Point(174, 211);
			this.btOk.Name = "btOk";
			this.btOk.Size = new System.Drawing.Size(117, 40);
			this.btOk.TabIndex = 13;
			this.btOk.Text = "Сохранить";
			this.btOk.Click += new System.EventHandler(this.BtOk_Click);
			// 
			// lbName
			// 
			this.lbName.Location = new System.Drawing.Point(30, 34);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(90, 13);
			this.lbName.TabIndex = 12;
			this.lbName.Text = "Сотрудник (ФИО)";
			// 
			// CreateResourceView
			// 
			this.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(326, 280);
			this.Controls.Add(this.grUserCreate);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreateResourceView";
			this.ShowInTaskbar = false;
			this.Text = "Добавление сотрудника";
			((System.ComponentModel.ISupportInitialize)(this.grUserCreate)).EndInit();
			this.grUserCreate.ResumeLayout(false);
			this.grUserCreate.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbOfficialSalary.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbName.Properties)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grUserCreate;
        private DevExpress.XtraEditors.LabelControl lblErrorCreate;
        private DevExpress.XtraEditors.LabelControl lbCard;
        private DevExpress.XtraEditors.LabelControl lbPhone;
        private DevExpress.XtraEditors.SimpleButton btcancel;
        private DevExpress.XtraEditors.SimpleButton btOk;
        private DevExpress.XtraEditors.LabelControl lbName;
        private DevExpress.XtraEditors.TextEdit tbName;
        private System.Windows.Forms.MaskedTextBox tbPhone;
        private System.Windows.Forms.MaskedTextBox tbCard;
        private DevExpress.XtraEditors.TextEdit tbOfficialSalary;
        private DevExpress.XtraEditors.LabelControl lbRub;
        private DevExpress.XtraEditors.LabelControl lbOfficialSalary;
    }
}