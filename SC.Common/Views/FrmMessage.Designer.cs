namespace SC.Common.Views
{
	partial class FrmMessage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessage));
			this.stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
			this.btCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btOk = new DevExpress.XtraEditors.SimpleButton();
			this.btNo = new DevExpress.XtraEditors.SimpleButton();
			this.btYes = new DevExpress.XtraEditors.SimpleButton();
			this.txtMessage = new DevExpress.XtraEditors.MemoEdit();
			this.pbIcon = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).BeginInit();
			this.stackPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// stackPanel1
			// 
			this.stackPanel1.Controls.Add(this.btCancel);
			this.stackPanel1.Controls.Add(this.btOk);
			this.stackPanel1.Controls.Add(this.btNo);
			this.stackPanel1.Controls.Add(this.btYes);
			this.stackPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.stackPanel1.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.RightToLeft;
			this.stackPanel1.Location = new System.Drawing.Point(0, 357);
			this.stackPanel1.Name = "stackPanel1";
			this.stackPanel1.Size = new System.Drawing.Size(684, 50);
			this.stackPanel1.TabIndex = 0;
			// 
			// btCancel
			// 
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.Location = new System.Drawing.Point(606, 13);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(75, 23);
			this.btCancel.TabIndex = 3;
			this.btCancel.Text = "Отмена";
			this.btCancel.Visible = false;
			// 
			// btOk
			// 
			this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btOk.Location = new System.Drawing.Point(525, 13);
			this.btOk.Name = "btOk";
			this.btOk.Size = new System.Drawing.Size(75, 23);
			this.btOk.TabIndex = 0;
			this.btOk.Text = "Ok";
			this.btOk.Visible = false;
			// 
			// btNo
			// 
			this.btNo.DialogResult = System.Windows.Forms.DialogResult.No;
			this.btNo.Location = new System.Drawing.Point(444, 13);
			this.btNo.Name = "btNo";
			this.btNo.Size = new System.Drawing.Size(75, 23);
			this.btNo.TabIndex = 1;
			this.btNo.Text = "Нет";
			this.btNo.Visible = false;
			// 
			// btYes
			// 
			this.btYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.btYes.Location = new System.Drawing.Point(363, 13);
			this.btYes.Name = "btYes";
			this.btYes.Size = new System.Drawing.Size(75, 23);
			this.btYes.TabIndex = 2;
			this.btYes.Text = "Да";
			this.btYes.Visible = false;
			// 
			// txtMessage
			// 
			this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtMessage.EditValue = "";
			this.txtMessage.Location = new System.Drawing.Point(50, 0);
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.txtMessage.Properties.ReadOnly = true;
			this.txtMessage.Properties.UseReadOnlyAppearance = false;
			this.txtMessage.Size = new System.Drawing.Size(634, 357);
			this.txtMessage.TabIndex = 1;
			// 
			// pbIcon
			// 
			this.pbIcon.BackColor = System.Drawing.Color.White;
			this.pbIcon.Dock = System.Windows.Forms.DockStyle.Left;
			this.pbIcon.Image = global::SC.Common.Properties.Resources.about_32x32;
			this.pbIcon.Location = new System.Drawing.Point(0, 0);
			this.pbIcon.Name = "pbIcon";
			this.pbIcon.Size = new System.Drawing.Size(50, 357);
			this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pbIcon.TabIndex = 3;
			this.pbIcon.TabStop = false;
			// 
			// FrmMessage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 407);
			this.Controls.Add(this.txtMessage);
			this.Controls.Add(this.pbIcon);
			this.Controls.Add(this.stackPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmMessage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Сообщение";
			((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).EndInit();
			this.stackPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.Utils.Layout.StackPanel stackPanel1;
		private DevExpress.XtraEditors.SimpleButton btCancel;
		private DevExpress.XtraEditors.SimpleButton btOk;
		private DevExpress.XtraEditors.SimpleButton btNo;
		private DevExpress.XtraEditors.SimpleButton btYes;
		private DevExpress.XtraEditors.MemoEdit txtMessage;
		private System.Windows.Forms.PictureBox pbIcon;
	}
}