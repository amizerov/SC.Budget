namespace SC.Staff.Views
{
	partial class PageUsers
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.gcUsers = new DevExpress.XtraGrid.GridControl();
			this.cUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvUsers = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colLogin = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRoleName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPass = new DevExpress.XtraGrid.Columns.GridColumn();
			this.riPass = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.gcUsers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cUserBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvUsers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.riPass)).BeginInit();
			this.SuspendLayout();
			// 
			// gcUsers
			// 
			this.gcUsers.DataSource = this.cUserBindingSource;
			this.gcUsers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcUsers.Location = new System.Drawing.Point(0, 0);
			this.gcUsers.MainView = this.gvUsers;
			this.gcUsers.Name = "gcUsers";
			this.gcUsers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riPass});
			this.gcUsers.Size = new System.Drawing.Size(1091, 600);
			this.gcUsers.TabIndex = 0;
			this.gcUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUsers});
			// 
			// cUserBindingSource
			// 
			this.cUserBindingSource.DataSource = typeof(SC.Common.Model.CUser);
			// 
			// gvUsers
			// 
			this.gvUsers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLogin,
            this.colName,
            this.colRoleName,
            this.colPass,
            this.colEmail});
			this.gvUsers.GridControl = this.gcUsers;
			this.gvUsers.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "/ Пользователей: {0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", this.colLogin, "Пользователей: {0}")});
			this.gvUsers.Name = "gvUsers";
			this.gvUsers.OptionsSelection.MultiSelect = true;
			this.gvUsers.OptionsView.ShowFooter = true;
			// 
			// colLogin
			// 
			this.colLogin.FieldName = "Login";
			this.colLogin.MinWidth = 23;
			this.colLogin.Name = "colLogin";
			this.colLogin.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Login", "Пользователей: {0}")});
			this.colLogin.Visible = true;
			this.colLogin.VisibleIndex = 0;
			this.colLogin.Width = 85;
			// 
			// colName
			// 
			this.colName.FieldName = "Name";
			this.colName.MinWidth = 23;
			this.colName.Name = "colName";
			this.colName.Visible = true;
			this.colName.VisibleIndex = 1;
			this.colName.Width = 85;
			// 
			// colRoleName
			// 
			this.colRoleName.FieldName = "RoleName";
			this.colRoleName.MinWidth = 23;
			this.colRoleName.Name = "colRoleName";
			this.colRoleName.OptionsColumn.AllowEdit = false;
			this.colRoleName.Visible = true;
			this.colRoleName.VisibleIndex = 2;
			this.colRoleName.Width = 85;
			// 
			// colPass
			// 
			this.colPass.ColumnEdit = this.riPass;
			this.colPass.FieldName = "Pass";
			this.colPass.MinWidth = 23;
			this.colPass.Name = "colPass";
			this.colPass.OptionsColumn.AllowEdit = false;
			this.colPass.Visible = true;
			this.colPass.VisibleIndex = 3;
			this.colPass.Width = 85;
			// 
			// riPass
			// 
			this.riPass.AutoHeight = false;
			this.riPass.Name = "riPass";
			this.riPass.UseSystemPasswordChar = true;
			// 
			// colEmail
			// 
			this.colEmail.FieldName = "Email";
			this.colEmail.MinWidth = 23;
			this.colEmail.Name = "colEmail";
			this.colEmail.Visible = true;
			this.colEmail.VisibleIndex = 4;
			this.colEmail.Width = 85;
			// 
			// PageUsers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gcUsers);
			this.Name = "PageUsers";
			this.Size = new System.Drawing.Size(1091, 600);
			((System.ComponentModel.ISupportInitialize)(this.gcUsers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cUserBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvUsers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.riPass)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGrid.GridControl gcUsers;
		private System.Windows.Forms.BindingSource cUserBindingSource;
		private DevExpress.XtraGrid.Views.Grid.GridView gvUsers;
		private DevExpress.XtraGrid.Columns.GridColumn colRoleName;
		private DevExpress.XtraGrid.Columns.GridColumn colLogin;
		private DevExpress.XtraGrid.Columns.GridColumn colPass;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit riPass;
		private DevExpress.XtraGrid.Columns.GridColumn colName;
		private DevExpress.XtraGrid.Columns.GridColumn colEmail;
	}
}
