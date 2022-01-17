namespace SC.Zakup
{
    partial class FrmEditSchet
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditSchet));
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
			this.txtNomer = new DevExpress.XtraEditors.TextEdit();
			this.deDateCr = new DevExpress.XtraEditors.DateEdit();
			this.txtSumma = new DevExpress.XtraEditors.TextEdit();
			this.cbSupplier = new DevExpress.XtraEditors.ComboBoxEdit();
			this.cbProject = new DevExpress.XtraEditors.ComboBoxEdit();
			this.memComment = new DevExpress.XtraEditors.MemoEdit();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnSave = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
			this.cbDetail = new DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
			this.deDateOp = new DevExpress.XtraEditors.DateEdit();
			this.gcOplatas = new DevExpress.XtraGrid.GridControl();
			this.cOplataDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvOplatas = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colSumma = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colData = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
			this.coldtc = new DevExpress.XtraGrid.Columns.GridColumn();
			this.coldtu = new DevExpress.XtraGrid.Columns.GridColumn();
			this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
			this.btnDeleteSchet = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
			this.cbSCFirma = new DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
			this.cbStRash = new DevExpress.XtraEditors.ComboBoxEdit();
			this.btnUpdateSchetFrom1C = new DevExpress.XtraEditors.SimpleButton();
			this.btDeleteOplata = new DevExpress.XtraEditors.SimpleButton();
			this.pnMain = new DevExpress.Utils.Layout.TablePanel();
			this.btAddOplata = new DevExpress.XtraEditors.SimpleButton();
			this.pnOk = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.txtNomer.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deDateCr.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deDateCr.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSumma.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbSupplier.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbProject.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memComment.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbDetail.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deDateOp.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deDateOp.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gcOplatas)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cOplataDtoBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvOplatas)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbSCFirma.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbStRash.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnMain)).BeginInit();
			this.pnMain.SuspendLayout();
			this.pnOk.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelControl1
			// 
			this.pnMain.SetColumn(this.labelControl1, 0);
			this.labelControl1.Location = new System.Drawing.Point(4, 108);
			this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.labelControl1.Name = "labelControl1";
			this.pnMain.SetRow(this.labelControl1, 2);
			this.labelControl1.Size = new System.Drawing.Size(99, 25);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "Поставщик";
			// 
			// labelControl2
			// 
			this.pnMain.SetColumn(this.labelControl2, 0);
			this.labelControl2.Location = new System.Drawing.Point(4, 164);
			this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.labelControl2.Name = "labelControl2";
			this.pnMain.SetRow(this.labelControl2, 3);
			this.labelControl2.Size = new System.Drawing.Size(63, 25);
			this.labelControl2.TabIndex = 1;
			this.labelControl2.Text = "Проект";
			// 
			// labelControl3
			// 
			this.pnMain.SetColumn(this.labelControl3, 0);
			this.labelControl3.Location = new System.Drawing.Point(4, 6);
			this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.labelControl3.Name = "labelControl3";
			this.pnMain.SetRow(this.labelControl3, 0);
			this.labelControl3.Size = new System.Drawing.Size(74, 25);
			this.labelControl3.TabIndex = 1;
			this.labelControl3.Text = "№ счета";
			// 
			// labelControl4
			// 
			this.pnMain.SetColumn(this.labelControl4, 2);
			this.labelControl4.Location = new System.Drawing.Point(496, 6);
			this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.labelControl4.Name = "labelControl4";
			this.pnMain.SetRow(this.labelControl4, 0);
			this.labelControl4.Size = new System.Drawing.Size(158, 25);
			this.labelControl4.TabIndex = 1;
			this.labelControl4.Text = "Дата выставления";
			// 
			// labelControl5
			// 
			this.pnMain.SetColumn(this.labelControl5, 1);
			this.labelControl5.Location = new System.Drawing.Point(250, 6);
			this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.labelControl5.Name = "labelControl5";
			this.pnMain.SetRow(this.labelControl5, 0);
			this.labelControl5.Size = new System.Drawing.Size(57, 25);
			this.labelControl5.TabIndex = 1;
			this.labelControl5.Text = "Сумма";
			// 
			// labelControl6
			// 
			this.pnMain.SetColumn(this.labelControl6, 0);
			this.labelControl6.Location = new System.Drawing.Point(4, 681);
			this.labelControl6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.labelControl6.Name = "labelControl6";
			this.pnMain.SetRow(this.labelControl6, 10);
			this.labelControl6.Size = new System.Drawing.Size(120, 25);
			this.labelControl6.TabIndex = 1;
			this.labelControl6.Text = "Комментарий";
			// 
			// txtNomer
			// 
			this.pnMain.SetColumn(this.txtNomer, 0);
			this.txtNomer.Location = new System.Drawing.Point(4, 49);
			this.txtNomer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.txtNomer.Name = "txtNomer";
			this.pnMain.SetRow(this.txtNomer, 1);
			this.txtNomer.Size = new System.Drawing.Size(238, 32);
			this.txtNomer.TabIndex = 1;
			// 
			// deDateCr
			// 
			this.pnMain.SetColumn(this.deDateCr, 2);
			this.deDateCr.EditValue = null;
			this.deDateCr.Location = new System.Drawing.Point(496, 49);
			this.deDateCr.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.deDateCr.Name = "deDateCr";
			this.deDateCr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.deDateCr.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.pnMain.SetRow(this.deDateCr, 1);
			this.deDateCr.Size = new System.Drawing.Size(238, 32);
			this.deDateCr.TabIndex = 3;
			// 
			// txtSumma
			// 
			this.pnMain.SetColumn(this.txtSumma, 1);
			this.txtSumma.Location = new System.Drawing.Point(250, 49);
			this.txtSumma.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.txtSumma.Name = "txtSumma";
			this.txtSumma.Properties.Mask.BeepOnError = true;
			this.txtSumma.Properties.Mask.EditMask = "c";
			this.txtSumma.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.txtSumma.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.pnMain.SetRow(this.txtSumma, 1);
			this.txtSumma.Size = new System.Drawing.Size(238, 32);
			this.txtSumma.TabIndex = 2;
			// 
			// cbSupplier
			// 
			this.pnMain.SetColumn(this.cbSupplier, 1);
			this.pnMain.SetColumnSpan(this.cbSupplier, 3);
			this.cbSupplier.Location = new System.Drawing.Point(250, 105);
			this.cbSupplier.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.cbSupplier.Name = "cbSupplier";
			this.cbSupplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.pnMain.SetRow(this.cbSupplier, 2);
			this.cbSupplier.Size = new System.Drawing.Size(730, 32);
			this.cbSupplier.TabIndex = 5;
			// 
			// cbProject
			// 
			this.pnMain.SetColumn(this.cbProject, 1);
			this.pnMain.SetColumnSpan(this.cbProject, 3);
			this.cbProject.Location = new System.Drawing.Point(250, 161);
			this.cbProject.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.cbProject.Name = "cbProject";
			this.cbProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbProject.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.pnMain.SetRow(this.cbProject, 3);
			this.cbProject.Size = new System.Drawing.Size(730, 32);
			this.cbProject.TabIndex = 6;
			// 
			// memComment
			// 
			this.pnMain.SetColumn(this.memComment, 0);
			this.pnMain.SetColumnSpan(this.memComment, 4);
			this.memComment.Dock = System.Windows.Forms.DockStyle.Fill;
			this.memComment.Location = new System.Drawing.Point(4, 718);
			this.memComment.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.memComment.Name = "memComment";
			this.pnMain.SetRow(this.memComment, 11);
			this.memComment.Size = new System.Drawing.Size(976, 102);
			this.memComment.TabIndex = 9;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(670, 41);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 30);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Отмена";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.ImageOptions.Image = global::SC.Zakup.Properties.Resources.save1;
			this.btnSave.Location = new System.Drawing.Point(791, 31);
			this.btnSave.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(175, 50);
			this.btnSave.TabIndex = 10;
			this.btnSave.Text = "Сохранить";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// labelControl7
			// 
			this.pnMain.SetColumn(this.labelControl7, 0);
			this.labelControl7.Location = new System.Drawing.Point(4, 332);
			this.labelControl7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.labelControl7.Name = "labelControl7";
			this.pnMain.SetRow(this.labelControl7, 6);
			this.labelControl7.Size = new System.Drawing.Size(112, 25);
			this.labelControl7.TabIndex = 1;
			this.labelControl7.Text = "Детализация";
			// 
			// cbDetail
			// 
			this.pnMain.SetColumn(this.cbDetail, 1);
			this.pnMain.SetColumnSpan(this.cbDetail, 3);
			this.cbDetail.Location = new System.Drawing.Point(250, 329);
			this.cbDetail.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.cbDetail.Name = "cbDetail";
			this.cbDetail.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbDetail.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.pnMain.SetRow(this.cbDetail, 6);
			this.cbDetail.Size = new System.Drawing.Size(730, 32);
			this.cbDetail.TabIndex = 9;
			// 
			// labelControl8
			// 
			this.pnMain.SetColumn(this.labelControl8, 3);
			this.labelControl8.Location = new System.Drawing.Point(742, 6);
			this.labelControl8.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.labelControl8.Name = "labelControl8";
			this.pnMain.SetRow(this.labelControl8, 0);
			this.labelControl8.Size = new System.Drawing.Size(108, 25);
			this.labelControl8.TabIndex = 1;
			this.labelControl8.Text = "Оплатить до";
			// 
			// deDateOp
			// 
			this.pnMain.SetColumn(this.deDateOp, 3);
			this.deDateOp.EditValue = null;
			this.deDateOp.Location = new System.Drawing.Point(742, 49);
			this.deDateOp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.deDateOp.Name = "deDateOp";
			this.deDateOp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.deDateOp.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.pnMain.SetRow(this.deDateOp, 1);
			this.deDateOp.Size = new System.Drawing.Size(238, 32);
			this.deDateOp.TabIndex = 4;
			// 
			// gcOplatas
			// 
			this.pnMain.SetColumn(this.gcOplatas, 1);
			this.pnMain.SetColumnSpan(this.gcOplatas, 3);
			this.gcOplatas.DataSource = this.cOplataDtoBindingSource;
			this.gcOplatas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcOplatas.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.gcOplatas.Location = new System.Drawing.Point(250, 379);
			this.gcOplatas.MainView = this.gvOplatas;
			this.gcOplatas.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.gcOplatas.Name = "gcOplatas";
			this.pnMain.SetRow(this.gcOplatas, 7);
			this.pnMain.SetRowSpan(this.gcOplatas, 3);
			this.gcOplatas.Size = new System.Drawing.Size(730, 290);
			this.gcOplatas.TabIndex = 0;
			this.gcOplatas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOplatas});
			this.gcOplatas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gcOplatas_KeyDown);
			// 
			// cOplataDtoBindingSource
			// 
			this.cOplataDtoBindingSource.DataSource = typeof(SC.Common.Model.COplataDto);
			// 
			// gvOplatas
			// 
			this.gvOplatas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSumma,
            this.colData,
            this.colUser,
            this.coldtc,
            this.coldtu});
			this.gvOplatas.DetailHeight = 674;
			this.gvOplatas.FixedLineWidth = 5;
			this.gvOplatas.GridControl = this.gcOplatas;
			this.gvOplatas.Name = "gvOplatas";
			this.gvOplatas.OptionsView.ShowFooter = true;
			this.gvOplatas.OptionsView.ShowGroupPanel = false;
			this.gvOplatas.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvOplatas_CellValueChanged);
			// 
			// colSumma
			// 
			this.colSumma.FieldName = "Summa";
			this.colSumma.MinWidth = 25;
			this.colSumma.Name = "colSumma";
			this.colSumma.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Summa", "{0:c2}")});
			this.colSumma.Visible = true;
			this.colSumma.VisibleIndex = 0;
			this.colSumma.Width = 129;
			// 
			// colData
			// 
			this.colData.FieldName = "Data";
			this.colData.MinWidth = 25;
			this.colData.Name = "colData";
			this.colData.Visible = true;
			this.colData.VisibleIndex = 1;
			this.colData.Width = 129;
			// 
			// colUser
			// 
			this.colUser.FieldName = "User";
			this.colUser.MinWidth = 25;
			this.colUser.Name = "colUser";
			this.colUser.OptionsColumn.AllowEdit = false;
			this.colUser.Visible = true;
			this.colUser.VisibleIndex = 2;
			this.colUser.Width = 129;
			// 
			// coldtc
			// 
			this.coldtc.FieldName = "dtc";
			this.coldtc.MinWidth = 25;
			this.coldtc.Name = "coldtc";
			this.coldtc.OptionsColumn.AllowEdit = false;
			this.coldtc.Visible = true;
			this.coldtc.VisibleIndex = 3;
			this.coldtc.Width = 129;
			// 
			// coldtu
			// 
			this.coldtu.FieldName = "dtu";
			this.coldtu.MinWidth = 25;
			this.coldtu.Name = "coldtu";
			this.coldtu.OptionsColumn.AllowEdit = false;
			this.coldtu.Visible = true;
			this.coldtu.VisibleIndex = 4;
			this.coldtu.Width = 129;
			// 
			// labelControl9
			// 
			this.pnMain.SetColumn(this.labelControl9, 0);
			this.labelControl9.Location = new System.Drawing.Point(4, 379);
			this.labelControl9.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.labelControl9.Name = "labelControl9";
			this.pnMain.SetRow(this.labelControl9, 7);
			this.labelControl9.Size = new System.Drawing.Size(66, 25);
			this.labelControl9.TabIndex = 1;
			this.labelControl9.Text = "Оплаты";
			// 
			// btnDeleteSchet
			// 
			this.btnDeleteSchet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDeleteSchet.ImageOptions.Image = global::SC.Zakup.Properties.Resources.Delete;
			this.btnDeleteSchet.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
			this.btnDeleteSchet.Location = new System.Drawing.Point(19, 31);
			this.btnDeleteSchet.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
			this.btnDeleteSchet.Name = "btnDeleteSchet";
			this.btnDeleteSchet.Size = new System.Drawing.Size(50, 50);
			this.btnDeleteSchet.TabIndex = 12;
			this.btnDeleteSchet.ToolTip = "Удалить";
			this.btnDeleteSchet.Click += new System.EventHandler(this.btnDeleteSchet_Click);
			// 
			// labelControl10
			// 
			this.pnMain.SetColumn(this.labelControl10, 0);
			this.labelControl10.Location = new System.Drawing.Point(4, 220);
			this.labelControl10.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.labelControl10.Name = "labelControl10";
			this.pnMain.SetRow(this.labelControl10, 4);
			this.labelControl10.Size = new System.Drawing.Size(114, 25);
			this.labelControl10.TabIndex = 1;
			this.labelControl10.Text = "Организация";
			// 
			// cbSCFirma
			// 
			this.pnMain.SetColumn(this.cbSCFirma, 1);
			this.pnMain.SetColumnSpan(this.cbSCFirma, 3);
			this.cbSCFirma.Location = new System.Drawing.Point(250, 217);
			this.cbSCFirma.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.cbSCFirma.Name = "cbSCFirma";
			this.cbSCFirma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.pnMain.SetRow(this.cbSCFirma, 4);
			this.cbSCFirma.Size = new System.Drawing.Size(730, 32);
			this.cbSCFirma.TabIndex = 7;
			// 
			// labelControl11
			// 
			this.pnMain.SetColumn(this.labelControl11, 0);
			this.labelControl11.Location = new System.Drawing.Point(4, 276);
			this.labelControl11.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.labelControl11.Name = "labelControl11";
			this.pnMain.SetRow(this.labelControl11, 5);
			this.labelControl11.Size = new System.Drawing.Size(144, 25);
			this.labelControl11.TabIndex = 1;
			this.labelControl11.Text = "Статья расходов";
			// 
			// cbStRash
			// 
			this.pnMain.SetColumn(this.cbStRash, 1);
			this.pnMain.SetColumnSpan(this.cbStRash, 3);
			this.cbStRash.Location = new System.Drawing.Point(250, 273);
			this.cbStRash.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.cbStRash.Name = "cbStRash";
			this.cbStRash.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.pnMain.SetRow(this.cbStRash, 5);
			this.cbStRash.Size = new System.Drawing.Size(730, 32);
			this.cbStRash.TabIndex = 8;
			// 
			// btnUpdateSchetFrom1C
			// 
			this.btnUpdateSchetFrom1C.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnUpdateSchetFrom1C.ImageOptions.Image = global::SC.Zakup.Properties.Resources._1С1;
			this.btnUpdateSchetFrom1C.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
			this.btnUpdateSchetFrom1C.Location = new System.Drawing.Point(89, 31);
			this.btnUpdateSchetFrom1C.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
			this.btnUpdateSchetFrom1C.Name = "btnUpdateSchetFrom1C";
			this.btnUpdateSchetFrom1C.Size = new System.Drawing.Size(50, 50);
			this.btnUpdateSchetFrom1C.TabIndex = 13;
			this.btnUpdateSchetFrom1C.ToolTip = "Загрузить детали из 1С";
			this.btnUpdateSchetFrom1C.Click += new System.EventHandler(this.btnUpdateSchetFrom1C_Click);
			// 
			// btDeleteOplata
			// 
			this.btDeleteOplata.AutoSize = true;
			this.pnMain.SetColumn(this.btDeleteOplata, 0);
			this.btDeleteOplata.Dock = System.Windows.Forms.DockStyle.Top;
			this.btDeleteOplata.ImageOptions.Image = global::SC.Zakup.Properties.Resources.Delete;
			this.btDeleteOplata.Location = new System.Drawing.Point(3, 452);
			this.btDeleteOplata.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btDeleteOplata.Name = "btDeleteOplata";
			this.pnMain.SetRow(this.btDeleteOplata, 9);
			this.btDeleteOplata.Size = new System.Drawing.Size(240, 36);
			this.btDeleteOplata.TabIndex = 14;
			this.btDeleteOplata.Text = "Удалить";
			this.btDeleteOplata.Click += new System.EventHandler(this.btDeleteOplata_Click);
			// 
			// pnMain
			// 
			this.pnMain.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
			this.pnMain.Controls.Add(this.btAddOplata);
			this.pnMain.Controls.Add(this.labelControl3);
			this.pnMain.Controls.Add(this.btDeleteOplata);
			this.pnMain.Controls.Add(this.txtNomer);
			this.pnMain.Controls.Add(this.labelControl5);
			this.pnMain.Controls.Add(this.gcOplatas);
			this.pnMain.Controls.Add(this.memComment);
			this.pnMain.Controls.Add(this.txtSumma);
			this.pnMain.Controls.Add(this.deDateCr);
			this.pnMain.Controls.Add(this.labelControl6);
			this.pnMain.Controls.Add(this.labelControl4);
			this.pnMain.Controls.Add(this.labelControl8);
			this.pnMain.Controls.Add(this.deDateOp);
			this.pnMain.Controls.Add(this.labelControl9);
			this.pnMain.Controls.Add(this.cbDetail);
			this.pnMain.Controls.Add(this.cbStRash);
			this.pnMain.Controls.Add(this.labelControl1);
			this.pnMain.Controls.Add(this.cbSCFirma);
			this.pnMain.Controls.Add(this.cbSupplier);
			this.pnMain.Controls.Add(this.labelControl7);
			this.pnMain.Controls.Add(this.labelControl2);
			this.pnMain.Controls.Add(this.labelControl11);
			this.pnMain.Controls.Add(this.cbProject);
			this.pnMain.Controls.Add(this.labelControl10);
			this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnMain.Location = new System.Drawing.Point(0, 0);
			this.pnMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnMain.Name = "pnMain";
			this.pnMain.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 200F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
			this.pnMain.Size = new System.Drawing.Size(984, 826);
			this.pnMain.TabIndex = 15;
			// 
			// btAddOplata
			// 
			this.btAddOplata.AutoSize = true;
			this.pnMain.SetColumn(this.btAddOplata, 0);
			this.btAddOplata.Dock = System.Windows.Forms.DockStyle.Top;
			this.btAddOplata.ImageOptions.Image = global::SC.Zakup.Properties.Resources.New;
			this.btAddOplata.Location = new System.Drawing.Point(3, 412);
			this.btAddOplata.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btAddOplata.Name = "btAddOplata";
			this.pnMain.SetRow(this.btAddOplata, 8);
			this.btAddOplata.Size = new System.Drawing.Size(240, 36);
			this.btAddOplata.TabIndex = 15;
			this.btAddOplata.Text = "Добавить";
			this.btAddOplata.Click += new System.EventHandler(this.btAddOplata_Click);
			// 
			// pnOk
			// 
			this.pnOk.Controls.Add(this.btnSave);
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Controls.Add(this.btnUpdateSchetFrom1C);
			this.pnOk.Controls.Add(this.btnDeleteSchet);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 826);
			this.pnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(984, 100);
			this.pnOk.TabIndex = 16;
			// 
			// FrmEditSchet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(984, 926);
			this.Controls.Add(this.pnMain);
			this.Controls.Add(this.pnOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.Name = "FrmEditSchet";
			this.ShowInTaskbar = false;
			this.Text = "Новый счет";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmEditSchet_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.txtNomer.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deDateCr.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deDateCr.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSumma.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbSupplier.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbProject.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memComment.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbDetail.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deDateOp.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deDateOp.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gcOplatas)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cOplataDtoBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvOplatas)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbSCFirma.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbStRash.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnMain)).EndInit();
			this.pnMain.ResumeLayout(false);
			this.pnMain.PerformLayout();
			this.pnOk.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtNomer;
        private DevExpress.XtraEditors.DateEdit deDateCr;
        private DevExpress.XtraEditors.TextEdit txtSumma;
        private DevExpress.XtraEditors.ComboBoxEdit cbSupplier;
        private DevExpress.XtraEditors.ComboBoxEdit cbProject;
        private DevExpress.XtraEditors.MemoEdit memComment;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ComboBoxEdit cbDetail;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.DateEdit deDateOp;
        private DevExpress.XtraGrid.GridControl gcOplatas;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOplatas;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SimpleButton btnDeleteSchet;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.ComboBoxEdit cbSCFirma;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.ComboBoxEdit cbStRash;
		private DevExpress.XtraEditors.SimpleButton btnUpdateSchetFrom1C;
		private DevExpress.XtraEditors.SimpleButton btDeleteOplata;
		private System.Windows.Forms.BindingSource cOplataDtoBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colSumma;
		private DevExpress.XtraGrid.Columns.GridColumn colData;
		private DevExpress.XtraGrid.Columns.GridColumn colUser;
		private DevExpress.XtraGrid.Columns.GridColumn coldtc;
		private DevExpress.XtraGrid.Columns.GridColumn coldtu;
		private DevExpress.Utils.Layout.TablePanel pnMain;
		private System.Windows.Forms.Panel pnOk;
		private DevExpress.XtraEditors.SimpleButton btAddOplata;
	}
}