namespace SC.Budget.Views
{
	partial class FrmTasks
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
			this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
			this.tlTasks = new DevExpress.XtraTreeList.TreeList();
			this.trelloCardBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.colList = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.colCard = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.colDesc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tlTasks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trelloCardBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// ribbon
			// 
			this.ribbon.ExpandCollapseItem.Id = 0;
			this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem});
			this.ribbon.Location = new System.Drawing.Point(0, 0);
			this.ribbon.MaxItemId = 1;
			this.ribbon.Name = "ribbon";
			this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
			this.ribbon.Size = new System.Drawing.Size(1159, 175);
			this.ribbon.StatusBar = this.ribbonStatusBar;
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "ribbonPage1";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.Text = "ribbonPageGroup1";
			// 
			// ribbonStatusBar
			// 
			this.ribbonStatusBar.Location = new System.Drawing.Point(0, 561);
			this.ribbonStatusBar.Name = "ribbonStatusBar";
			this.ribbonStatusBar.Ribbon = this.ribbon;
			this.ribbonStatusBar.Size = new System.Drawing.Size(1159, 27);
			// 
			// tlTasks
			// 
			this.tlTasks.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colList,
            this.colCard,
            this.colDesc});
			this.tlTasks.DataSource = this.trelloCardBindingSource;
			this.tlTasks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlTasks.Location = new System.Drawing.Point(0, 175);
			this.tlTasks.Name = "tlTasks";
			this.tlTasks.Size = new System.Drawing.Size(1159, 386);
			this.tlTasks.TabIndex = 2;
			// 
			// trelloCardBindingSource
			// 
			this.trelloCardBindingSource.DataSource = typeof(SC.Common.Model.TrelloCard);
			// 
			// colList
			// 
			this.colList.FieldName = "List";
			this.colList.Name = "colList";
			this.colList.Visible = true;
			this.colList.VisibleIndex = 0;
			// 
			// colCard
			// 
			this.colCard.FieldName = "Card";
			this.colCard.Name = "colCard";
			this.colCard.Visible = true;
			this.colCard.VisibleIndex = 1;
			// 
			// colDesc
			// 
			this.colDesc.FieldName = "Desc";
			this.colDesc.Name = "colDesc";
			this.colDesc.Visible = true;
			this.colDesc.VisibleIndex = 2;
			// 
			// FrmTasks
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1159, 588);
			this.Controls.Add(this.tlTasks);
			this.Controls.Add(this.ribbonStatusBar);
			this.Controls.Add(this.ribbon);
			this.Name = "FrmTasks";
			this.Ribbon = this.ribbon;
			this.StatusBar = this.ribbonStatusBar;
			this.Text = "FrmTasks";
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tlTasks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trelloCardBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
		private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
		private DevExpress.XtraTreeList.TreeList tlTasks;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colList;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colCard;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colDesc;
		private System.Windows.Forms.BindingSource trelloCardBindingSource;
	}
}