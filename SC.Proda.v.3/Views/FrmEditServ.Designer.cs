using DevExpress.XtraEditors;

namespace SC.Proda.Views
{
    partial class FrmEditServ
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditServ));
			this.txtService = new DevExpress.XtraEditors.TextEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.btnDel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.txtService.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// txtService
			// 
			this.txtService.Location = new System.Drawing.Point(86, 35);
			this.txtService.Name = "txtService";
			this.txtService.Size = new System.Drawing.Size(510, 26);
			this.txtService.TabIndex = 0;
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(34, 41);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(48, 20);
			this.labelControl1.TabIndex = 1;
			this.labelControl1.Text = "Услуга:";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(395, 94);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(87, 31);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(509, 94);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(87, 31);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDel
			// 
			this.btnDel.Location = new System.Drawing.Point(34, 94);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(87, 31);
			this.btnDel.TabIndex = 2;
			this.btnDel.Text = "Delete";
			// 
			// FrmEditServ
			// 
			this.Appearance.Options.UseFont = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(635, 161);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnDel);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.txtService);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmEditServ";
			this.Text = "Edit Service";
			this.Load += new System.EventHandler(this.FrmEditServ_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtService.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtService;
        private LabelControl labelControl1;
        private SimpleButton btnCancel;
        private SimpleButton btnSave;
        private SimpleButton btnDel;
    }
}