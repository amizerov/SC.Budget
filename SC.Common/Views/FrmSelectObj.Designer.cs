namespace SC.Common.Views
{
    partial class FrmSelectObj
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectObj));
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.PnFilter = new DevExpress.Utils.Layout.TablePanel();
			this.btIsSklad = new DevExpress.XtraEditors.CheckButton();
			this.btIsNoMyOnly = new DevExpress.XtraEditors.CheckButton();
			this.btIsAll = new DevExpress.XtraEditors.CheckButton();
			this.btIsMyOnly = new DevExpress.XtraEditors.CheckButton();
			this.pnOk = new DevExpress.XtraEditors.PanelControl();
			this.objectProjectTreeBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.treeMain = new DevExpress.XtraTreeList.TreeList();
			this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.colAddress = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.colRukovodName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
			this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
			((System.ComponentModel.ISupportInitialize)(this.PnFilter)).BeginInit();
			this.PnFilter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).BeginInit();
			this.pnOk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.objectProjectTreeBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.treeMain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(754, 20);
			this.btnOk.Margin = new System.Windows.Forms.Padding(10);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(111, 50);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Ок";
			this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(634, 28);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 35);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Отмена";
			this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// PnFilter
			// 
			this.PnFilter.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
			this.PnFilter.Controls.Add(this.btIsSklad);
			this.PnFilter.Controls.Add(this.btIsNoMyOnly);
			this.PnFilter.Controls.Add(this.btIsAll);
			this.PnFilter.Controls.Add(this.btIsMyOnly);
			this.PnFilter.Dock = System.Windows.Forms.DockStyle.Top;
			this.PnFilter.Location = new System.Drawing.Point(0, 0);
			this.PnFilter.Name = "PnFilter";
			this.PnFilter.Padding = new System.Windows.Forms.Padding(5);
			this.PnFilter.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F)});
			this.PnFilter.Size = new System.Drawing.Size(884, 60);
			this.PnFilter.TabIndex = 3;
			// 
			// btIsSklad
			// 
			this.PnFilter.SetColumn(this.btIsSklad, 0);
			this.btIsSklad.ImageOptions.Image = global::SC.Common.Properties.Resources.sklad_icon;
			this.btIsSklad.Location = new System.Drawing.Point(8, 8);
			this.btIsSklad.Name = "btIsSklad";
			this.btIsSklad.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
			this.PnFilter.SetRow(this.btIsSklad, 0);
			this.btIsSklad.Size = new System.Drawing.Size(213, 44);
			this.btIsSklad.TabIndex = 7;
			this.btIsSklad.Text = "Склады";
			this.btIsSklad.CheckedChanged += new System.EventHandler(this.Reload);
			// 
			// btIsNoMyOnly
			// 
			this.PnFilter.SetColumn(this.btIsNoMyOnly, 2);
			this.btIsNoMyOnly.ImageOptions.Image = global::SC.Common.Properties.Resources.noMy;
			this.btIsNoMyOnly.Location = new System.Drawing.Point(445, 8);
			this.btIsNoMyOnly.Name = "btIsNoMyOnly";
			this.btIsNoMyOnly.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
			this.PnFilter.SetRow(this.btIsNoMyOnly, 0);
			this.btIsNoMyOnly.Size = new System.Drawing.Size(213, 44);
			this.btIsNoMyOnly.TabIndex = 5;
			this.btIsNoMyOnly.Text = "Только не мои объекты";
			this.btIsNoMyOnly.CheckedChanged += new System.EventHandler(this.MyNoMy_CheckedChanged);
			// 
			// btIsAll
			// 
			this.PnFilter.SetColumn(this.btIsAll, 3);
			this.btIsAll.ImageOptions.Image = global::SC.Common.Properties.Resources.НетФильтра;
			this.btIsAll.Location = new System.Drawing.Point(664, 8);
			this.btIsAll.Name = "btIsAll";
			this.btIsAll.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
			this.PnFilter.SetRow(this.btIsAll, 0);
			this.btIsAll.Size = new System.Drawing.Size(213, 44);
			this.btIsAll.TabIndex = 6;
			this.btIsAll.Text = "Все объекты";
			this.btIsAll.CheckedChanged += new System.EventHandler(this.MyNoMy_CheckedChanged);
			// 
			// btIsMyOnly
			// 
			this.btIsMyOnly.Checked = true;
			this.PnFilter.SetColumn(this.btIsMyOnly, 1);
			this.btIsMyOnly.ImageOptions.Image = global::SC.Common.Properties.Resources.my;
			this.btIsMyOnly.Location = new System.Drawing.Point(227, 8);
			this.btIsMyOnly.Name = "btIsMyOnly";
			this.btIsMyOnly.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
			this.PnFilter.SetRow(this.btIsMyOnly, 0);
			this.btIsMyOnly.Size = new System.Drawing.Size(213, 44);
			this.btIsMyOnly.TabIndex = 5;
			this.btIsMyOnly.Text = "Только мои объекты";
			this.btIsMyOnly.CheckedChanged += new System.EventHandler(this.MyNoMy_CheckedChanged);
			// 
			// pnOk
			// 
			this.pnOk.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 651);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(884, 90);
			this.pnOk.TabIndex = 4;
			// 
			// objectProjectTreeBindingSource
			// 
			this.objectProjectTreeBindingSource.DataSource = typeof(SC.Common.Model.ObjectProjectTree);
			// 
			// treeMain
			// 
			this.treeMain.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName,
            this.colAddress,
            this.colRukovodName});
			this.treeMain.DataSource = this.objectProjectTreeBindingSource;
			this.treeMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeMain.ImageIndexFieldName = "Type";
			this.treeMain.KeyFieldName = "ViewModelID";
			this.treeMain.Location = new System.Drawing.Point(0, 60);
			this.treeMain.Name = "treeMain";
			this.treeMain.OptionsBehavior.Editable = false;
			this.treeMain.OptionsBehavior.PopulateServiceColumns = true;
			this.treeMain.OptionsFind.AlwaysVisible = true;
			this.treeMain.SelectImageList = this.imageCollection;
			this.treeMain.Size = new System.Drawing.Size(884, 591);
			this.treeMain.StateImageList = this.imageCollection;
			this.treeMain.TabIndex = 5;
			this.treeMain.Tag = "1";
			this.treeMain.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeObjects_NodeCellStyle);
			this.treeMain.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeObjects_CustomDrawNodeCell);
			this.treeMain.DoubleClick += new System.EventHandler(this.treeMain_DoubleClick);
			// 
			// colName
			// 
			this.colName.FieldName = "Name";
			this.colName.Name = "colName";
			this.colName.OptionsColumn.AllowEdit = false;
			this.colName.Visible = true;
			this.colName.VisibleIndex = 0;
			// 
			// colAddress
			// 
			this.colAddress.FieldName = "Address";
			this.colAddress.Name = "colAddress";
			this.colAddress.OptionsColumn.AllowEdit = false;
			this.colAddress.Visible = true;
			this.colAddress.VisibleIndex = 1;
			// 
			// colRukovodName
			// 
			this.colRukovodName.FieldName = "RukovodName";
			this.colRukovodName.Name = "colRukovodName";
			this.colRukovodName.OptionsColumn.AllowEdit = false;
			this.colRukovodName.Visible = true;
			this.colRukovodName.VisibleIndex = 2;
			// 
			// imageCollection
			// 
			this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
			this.imageCollection.Images.SetKeyName(0, "case1.png");
			this.imageCollection.Images.SetKeyName(1, "Object16_2.png");
			this.imageCollection.Images.SetKeyName(2, "staff.png");
			this.imageCollection.Images.SetKeyName(3, "sum.png");
			// 
			// FrmSelectObj
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(884, 741);
			this.Controls.Add(this.treeMain);
			this.Controls.Add(this.PnFilter);
			this.Controls.Add(this.pnOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "FrmSelectObj";
			this.ShowIcon = false;
			this.Text = "Выбор объекта";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSelectObj_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.PnFilter)).EndInit();
			this.PnFilter.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).EndInit();
			this.pnOk.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.objectProjectTreeBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.treeMain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.CheckButton btIsNoMyOnly;
		private DevExpress.XtraEditors.CheckButton btIsAll;
		private DevExpress.XtraEditors.CheckButton btIsMyOnly;
		private DevExpress.XtraEditors.PanelControl pnOk;
		private System.Windows.Forms.BindingSource objectProjectTreeBindingSource;
		private DevExpress.XtraTreeList.TreeList treeMain;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colAddress;
		private DevExpress.XtraTreeList.Columns.TreeListColumn colRukovodName;
		private DevExpress.Utils.ImageCollection imageCollection;
		private DevExpress.XtraEditors.CheckButton btIsSklad;
		public DevExpress.Utils.Layout.TablePanel PnFilter;
	}
}