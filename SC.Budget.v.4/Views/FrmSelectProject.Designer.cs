namespace SC.Budget.Views
{
	partial class FrmSelectProject
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectProject));
			this.gcProjects = new DevExpress.XtraGrid.GridControl();
			this.cProjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvProjects = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.pnOk = new DevExpress.XtraEditors.PanelControl();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.gcProjects)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cProjectBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvProjects)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).BeginInit();
			this.pnOk.SuspendLayout();
			this.SuspendLayout();
			// 
			// gcProjects
			// 
			this.gcProjects.DataSource = this.cProjectBindingSource;
			this.gcProjects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcProjects.Location = new System.Drawing.Point(0, 0);
			this.gcProjects.MainView = this.gvProjects;
			this.gcProjects.Name = "gcProjects";
			this.gcProjects.Size = new System.Drawing.Size(484, 553);
			this.gcProjects.TabIndex = 0;
			this.gcProjects.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProjects});
			// 
			// cProjectBindingSource
			// 
			this.cProjectBindingSource.DataSource = typeof(SC.Budget.Model.CProject);
			// 
			// gvProjects
			// 
			this.gvProjects.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName});
			this.gvProjects.GridControl = this.gcProjects;
			this.gvProjects.Name = "gvProjects";
			this.gvProjects.OptionsBehavior.Editable = false;
			this.gvProjects.OptionsView.ShowGroupPanel = false;
			this.gvProjects.DoubleClick += new System.EventHandler(this.gvProjects_DoubleClick);
			// 
			// colName
			// 
			this.colName.FieldName = "Name";
			this.colName.Name = "colName";
			this.colName.Visible = true;
			this.colName.VisibleIndex = 0;
			// 
			// pnOk
			// 
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 458);
			this.pnOk.Margin = new System.Windows.Forms.Padding(4);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(484, 95);
			this.pnOk.TabIndex = 28;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(325, 22);
			this.btnOk.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(140, 53);
			this.btnOk.TabIndex = 22;
			this.btnOk.Text = "Выбрать";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(207, 22);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 31);
			this.btnCancel.TabIndex = 23;
			this.btnCancel.Text = "Отмена";
			// 
			// FrmSelectProject
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(484, 553);
			this.Controls.Add(this.pnOk);
			this.Controls.Add(this.gcProjects);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmSelectProject";
			this.Text = "Выберите проект";
			((System.ComponentModel.ISupportInitialize)(this.gcProjects)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cProjectBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvProjects)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).EndInit();
			this.pnOk.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGrid.GridControl gcProjects;
		private DevExpress.XtraGrid.Views.Grid.GridView gvProjects;
		private DevExpress.XtraEditors.PanelControl pnOk;
		private DevExpress.XtraEditors.SimpleButton btnOk;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private System.Windows.Forms.BindingSource cProjectBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colName;
	}
}