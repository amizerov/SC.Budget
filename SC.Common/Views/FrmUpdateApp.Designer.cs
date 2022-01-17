namespace SC.Common.Views
{
	partial class FrmUpdateApp
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpdateApp));
			this.lbTitle = new System.Windows.Forms.Label();
			this.pnOk = new DevExpress.Utils.Layout.TablePanel();
			this.btUpdateLater = new System.Windows.Forms.Button();
			this.btUpdateNow = new System.Windows.Forms.Button();
			this.lbInfo = new System.Windows.Forms.Label();
			this.pnVersions = new System.Windows.Forms.Panel();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.picLogo = new DevExpress.XtraEditors.PictureEdit();
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).BeginInit();
			this.pnOk.SuspendLayout();
			this.pnVersions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
			this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
			this.lbTitle.Location = new System.Drawing.Point(1, 126);
			this.lbTitle.Margin = new System.Windows.Forms.Padding(0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
			this.lbTitle.Size = new System.Drawing.Size(698, 60);
			this.lbTitle.TabIndex = 18;
			this.lbTitle.Text = "Обновление программы";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnOk
			// 
			this.pnOk.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
			this.pnOk.Controls.Add(this.btUpdateLater);
			this.pnOk.Controls.Add(this.btUpdateNow);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(1, 460);
			this.pnOk.Name = "pnOk";
			this.pnOk.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
			this.pnOk.Size = new System.Drawing.Size(698, 125);
			this.pnOk.TabIndex = 22;
			// 
			// btUpdateLater
			// 
			this.btUpdateLater.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.pnOk.SetColumn(this.btUpdateLater, 1);
			this.btUpdateLater.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btUpdateLater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btUpdateLater.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btUpdateLater.ForeColor = System.Drawing.Color.White;
			this.btUpdateLater.Location = new System.Drawing.Point(149, 66);
			this.btUpdateLater.Name = "btUpdateLater";
			this.pnOk.SetRow(this.btUpdateLater, 1);
			this.btUpdateLater.Size = new System.Drawing.Size(400, 56);
			this.btUpdateLater.TabIndex = 24;
			this.btUpdateLater.Text = "Обновить через 20 минут \r\n(одна попытка)";
			this.btUpdateLater.UseVisualStyleBackColor = false;
			// 
			// btUpdateNow
			// 
			this.btUpdateNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
			this.pnOk.SetColumn(this.btUpdateNow, 1);
			this.btUpdateNow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btUpdateNow.FlatAppearance.BorderSize = 0;
			this.btUpdateNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btUpdateNow.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btUpdateNow.ForeColor = System.Drawing.Color.White;
			this.btUpdateNow.Location = new System.Drawing.Point(149, 3);
			this.btUpdateNow.Name = "btUpdateNow";
			this.pnOk.SetRow(this.btUpdateNow, 0);
			this.btUpdateNow.Size = new System.Drawing.Size(400, 57);
			this.btUpdateNow.TabIndex = 23;
			this.btUpdateNow.Text = "Обновить сейчас \r\n(будет выполнен перезапуск приложения)";
			this.btUpdateNow.UseVisualStyleBackColor = false;
			// 
			// lbInfo
			// 
			this.lbInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbInfo.ForeColor = System.Drawing.Color.DimGray;
			this.lbInfo.Location = new System.Drawing.Point(1, 186);
			this.lbInfo.Margin = new System.Windows.Forms.Padding(0);
			this.lbInfo.Name = "lbInfo";
			this.lbInfo.Padding = new System.Windows.Forms.Padding(25, 0, 25, 10);
			this.lbInfo.Size = new System.Drawing.Size(698, 30);
			this.lbInfo.TabIndex = 17;
			this.lbInfo.Text = "Вышло одно или несколько обновлений:";
			this.lbInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pnVersions
			// 
			this.pnVersions.AutoScroll = true;
			this.pnVersions.AutoSize = true;
			this.pnVersions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pnVersions.Controls.Add(this.label15);
			this.pnVersions.Controls.Add(this.label16);
			this.pnVersions.Controls.Add(this.label13);
			this.pnVersions.Controls.Add(this.label14);
			this.pnVersions.Controls.Add(this.label11);
			this.pnVersions.Controls.Add(this.label12);
			this.pnVersions.Controls.Add(this.label8);
			this.pnVersions.Controls.Add(this.label6);
			this.pnVersions.Controls.Add(this.label9);
			this.pnVersions.Controls.Add(this.label5);
			this.pnVersions.Controls.Add(this.label10);
			this.pnVersions.Controls.Add(this.label4);
			this.pnVersions.Controls.Add(this.label7);
			this.pnVersions.Controls.Add(this.label3);
			this.pnVersions.Controls.Add(this.label2);
			this.pnVersions.Controls.Add(this.label1);
			this.pnVersions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnVersions.Location = new System.Drawing.Point(1, 216);
			this.pnVersions.MaximumSize = new System.Drawing.Size(0, 500);
			this.pnVersions.Name = "pnVersions";
			this.pnVersions.Size = new System.Drawing.Size(698, 244);
			this.pnVersions.TabIndex = 23;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Dock = System.Windows.Forms.DockStyle.Top;
			this.label15.Location = new System.Drawing.Point(0, 515);
			this.label15.MinimumSize = new System.Drawing.Size(700, 0);
			this.label15.Name = "label15";
			this.label15.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.label15.Size = new System.Drawing.Size(700, 45);
			this.label15.TabIndex = 39;
			this.label15.Text = "Откорректирован алгоритм загрузки из 1С\r\nУлучшено всё";
			this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Dock = System.Windows.Forms.DockStyle.Top;
			this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label16.ForeColor = System.Drawing.Color.DarkOrange;
			this.label16.Location = new System.Drawing.Point(0, 490);
			this.label16.MinimumSize = new System.Drawing.Size(700, 0);
			this.label16.Name = "label16";
			this.label16.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.label16.Size = new System.Drawing.Size(700, 25);
			this.label16.TabIndex = 38;
			this.label16.Text = "Версия 3.0.1.3 от 20.02.2020 (важное обновление)";
			this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Dock = System.Windows.Forms.DockStyle.Top;
			this.label13.Location = new System.Drawing.Point(0, 445);
			this.label13.MinimumSize = new System.Drawing.Size(700, 0);
			this.label13.Name = "label13";
			this.label13.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.label13.Size = new System.Drawing.Size(700, 45);
			this.label13.TabIndex = 37;
			this.label13.Text = "Откорректирован алгоритм загрузки из 1С\r\nУлучшено всё";
			this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Dock = System.Windows.Forms.DockStyle.Top;
			this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label14.ForeColor = System.Drawing.Color.DarkOrange;
			this.label14.Location = new System.Drawing.Point(0, 420);
			this.label14.MinimumSize = new System.Drawing.Size(700, 0);
			this.label14.Name = "label14";
			this.label14.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.label14.Size = new System.Drawing.Size(700, 25);
			this.label14.TabIndex = 36;
			this.label14.Text = "Версия 3.0.1.3 от 20.02.2020 (важное обновление)";
			this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Dock = System.Windows.Forms.DockStyle.Top;
			this.label11.Location = new System.Drawing.Point(0, 375);
			this.label11.MinimumSize = new System.Drawing.Size(700, 0);
			this.label11.Name = "label11";
			this.label11.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.label11.Size = new System.Drawing.Size(700, 45);
			this.label11.TabIndex = 35;
			this.label11.Text = "Откорректирован алгоритм загрузки из 1С\r\nУлучшено всё";
			this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Dock = System.Windows.Forms.DockStyle.Top;
			this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
			this.label12.Location = new System.Drawing.Point(0, 350);
			this.label12.MinimumSize = new System.Drawing.Size(700, 0);
			this.label12.Name = "label12";
			this.label12.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.label12.Size = new System.Drawing.Size(700, 25);
			this.label12.TabIndex = 34;
			this.label12.Text = "Версия 3.0.1.3 от 20.02.2020 (критичное обновление)";
			this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Dock = System.Windows.Forms.DockStyle.Top;
			this.label8.Location = new System.Drawing.Point(0, 305);
			this.label8.MinimumSize = new System.Drawing.Size(700, 0);
			this.label8.Name = "label8";
			this.label8.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.label8.Size = new System.Drawing.Size(700, 45);
			this.label8.TabIndex = 31;
			this.label8.Text = "Откорректирован алгоритм загрузки из 1С\r\nУлучшено всё";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Dock = System.Windows.Forms.DockStyle.Top;
			this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(0, 280);
			this.label6.MinimumSize = new System.Drawing.Size(700, 0);
			this.label6.Name = "label6";
			this.label6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.label6.Size = new System.Drawing.Size(700, 25);
			this.label6.TabIndex = 29;
			this.label6.Text = "Версия 3.0.1.3 от 20.02.2020";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Dock = System.Windows.Forms.DockStyle.Top;
			this.label9.Location = new System.Drawing.Point(0, 235);
			this.label9.MinimumSize = new System.Drawing.Size(700, 0);
			this.label9.Name = "label9";
			this.label9.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.label9.Size = new System.Drawing.Size(700, 45);
			this.label9.TabIndex = 32;
			this.label9.Text = "Откорректирован алгоритм загрузки из 1С\r\nУлучшено всё";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Dock = System.Windows.Forms.DockStyle.Top;
			this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(0, 210);
			this.label5.MinimumSize = new System.Drawing.Size(700, 0);
			this.label5.Name = "label5";
			this.label5.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.label5.Size = new System.Drawing.Size(700, 25);
			this.label5.TabIndex = 28;
			this.label5.Text = "Версия 3.0.1.3 от 20.02.2020";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Dock = System.Windows.Forms.DockStyle.Top;
			this.label10.Location = new System.Drawing.Point(0, 165);
			this.label10.MinimumSize = new System.Drawing.Size(700, 0);
			this.label10.Name = "label10";
			this.label10.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.label10.Size = new System.Drawing.Size(700, 45);
			this.label10.TabIndex = 33;
			this.label10.Text = "Откорректирован алгоритм загрузки из 1С\r\nУлучшено всё";
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
			this.label4.Location = new System.Drawing.Point(0, 140);
			this.label4.MinimumSize = new System.Drawing.Size(700, 0);
			this.label4.Name = "label4";
			this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.label4.Size = new System.Drawing.Size(700, 25);
			this.label4.TabIndex = 27;
			this.label4.Text = "Версия 3.0.1.3 от 20.02.2020 (критичное обновление)";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Dock = System.Windows.Forms.DockStyle.Top;
			this.label7.Location = new System.Drawing.Point(0, 95);
			this.label7.MinimumSize = new System.Drawing.Size(700, 0);
			this.label7.Name = "label7";
			this.label7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.label7.Size = new System.Drawing.Size(700, 45);
			this.label7.TabIndex = 30;
			this.label7.Text = "Откорректирован алгоритм загрузки из 1С\r\nУлучшено всё";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.DarkOrange;
			this.label3.Location = new System.Drawing.Point(0, 70);
			this.label3.MinimumSize = new System.Drawing.Size(700, 0);
			this.label3.Name = "label3";
			this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.label3.Size = new System.Drawing.Size(700, 25);
			this.label3.TabIndex = 26;
			this.label3.Text = "Версия 3.0.1.3 от 20.02.2020 (важное обновление)";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(0, 25);
			this.label2.MinimumSize = new System.Drawing.Size(700, 0);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.label2.Size = new System.Drawing.Size(700, 45);
			this.label2.TabIndex = 25;
			this.label2.Text = "Откорректирован алгоритм загрузки из 1С\r\nУлучшено всё";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.MinimumSize = new System.Drawing.Size(700, 0);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.label1.Size = new System.Drawing.Size(700, 25);
			this.label1.TabIndex = 24;
			this.label1.Text = "Версия 3.0.1.3 от 20.02.2020";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// picLogo
			// 
			this.picLogo.Dock = System.Windows.Forms.DockStyle.Top;
			this.picLogo.EditValue = global::SC.Common.Properties.Resources.SCAS;
			this.picLogo.Location = new System.Drawing.Point(1, 30);
			this.picLogo.Name = "picLogo";
			this.picLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.picLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
			this.picLogo.Size = new System.Drawing.Size(698, 96);
			this.picLogo.TabIndex = 24;
			// 
			// FrmUpdateApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(700, 600);
			this.Controls.Add(this.pnVersions);
			this.Controls.Add(this.pnOk);
			this.Controls.Add(this.lbInfo);
			this.Controls.Add(this.lbTitle);
			this.Controls.Add(this.picLogo);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(700, 600);
			this.MinimumSize = new System.Drawing.Size(700, 600);
			this.Name = "FrmUpdateApp";
			this.Padding = new System.Windows.Forms.Padding(1, 30, 1, 15);
			this.Text = "Обновление программы";
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).EndInit();
			this.pnOk.ResumeLayout(false);
			this.pnVersions.ResumeLayout(false);
			this.pnVersions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lbTitle;
		private DevExpress.Utils.Layout.TablePanel pnOk;
		private System.Windows.Forms.Label lbInfo;
		private System.Windows.Forms.Button btUpdateNow;
		private System.Windows.Forms.Button btUpdateLater;
		private System.Windows.Forms.Panel pnVersions;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private DevExpress.XtraEditors.PictureEdit picLogo;
	}
}