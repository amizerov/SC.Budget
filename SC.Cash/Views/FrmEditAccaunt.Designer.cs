namespace SC.Cash.Views
{
	partial class FrmEditAccaunt
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditAccaunt));
			this.pnOk = new DevExpress.XtraEditors.PanelControl();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.txtName = new DevExpress.XtraEditors.TextEdit();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).BeginInit();
			this.pnOk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnOk
			// 
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 45);
			this.pnOk.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(384, 68);
			this.pnOk.TabIndex = 29;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.ImageOptions.Image = global::SC.Cash.Properties.Resources.save;
			this.btnOk.Location = new System.Drawing.Point(238, 8);
			this.btnOk.Margin = new System.Windows.Forms.Padding(5);
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
			this.btnCancel.Location = new System.Drawing.Point(127, 19);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(101, 31);
			this.btnCancel.TabIndex = 23;
			this.btnCancel.Text = "Отмена";
			// 
			// txtName
			// 
			this.txtName.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtName.Location = new System.Drawing.Point(10, 10);
			this.txtName.Margin = new System.Windows.Forms.Padding(5);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(364, 26);
			this.txtName.TabIndex = 30;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txtName);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(10);
			this.panel1.Size = new System.Drawing.Size(384, 45);
			this.panel1.TabIndex = 31;
			// 
			// FrmEditAccaunt
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(384, 113);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmEditAccaunt";
			this.Text = "Редактировать имя счёта";
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).EndInit();
			this.pnOk.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.PanelControl pnOk;
		private DevExpress.XtraEditors.SimpleButton btnOk;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.TextEdit txtName;
		private System.Windows.Forms.Panel panel1;
	}
}