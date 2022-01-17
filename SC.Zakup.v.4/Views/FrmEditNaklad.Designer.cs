namespace SC.Zakup.Views
{
	partial class FrmEditNaklad
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditNaklad));
			this.pnOk = new System.Windows.Forms.Panel();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.gcNakladLines = new DevExpress.XtraGrid.GridControl();
			this.cNakladLineBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvNakladLines = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colNomenkl = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
			this.riCategory = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colQuantityOnSklad = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInventoryNum = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPriceAdditional = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPriceTotal = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCost = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
			this.pnNakladProperties = new DevExpress.Utils.Layout.TablePanel();
			this.lbKonragent = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.lbObject = new DevExpress.XtraEditors.LabelControl();
			this.lbNumber = new DevExpress.XtraEditors.LabelControl();
			this.btnSelectObject = new DevExpress.XtraEditors.SimpleButton();
			this.deDate = new DevExpress.XtraEditors.DateEdit();
			this.lbDate = new DevExpress.XtraEditors.LabelControl();
			this.txtNumber = new DevExpress.XtraEditors.TextEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.lbFirma = new DevExpress.XtraEditors.LabelControl();
			this.pnOk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcNakladLines)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cNakladLineBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvNakladLines)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.riCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnNakladProperties)).BeginInit();
			this.pnNakladProperties.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.deDate.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// pnOk
			// 
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 403);
			this.pnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(861, 89);
			this.pnOk.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(620, 27);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(99, 33);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Отмена";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(737, 27);
			this.btnOk.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(111, 48);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "Ок";
			this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// gcNakladLines
			// 
			this.gcNakladLines.DataSource = this.cNakladLineBindingSource;
			this.gcNakladLines.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcNakladLines.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.gcNakladLines.Location = new System.Drawing.Point(0, 166);
			this.gcNakladLines.MainView = this.gvNakladLines;
			this.gcNakladLines.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.gcNakladLines.Name = "gcNakladLines";
			this.gcNakladLines.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riCategory});
			this.gcNakladLines.Size = new System.Drawing.Size(861, 237);
			this.gcNakladLines.TabIndex = 2;
			this.gcNakladLines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNakladLines});
			// 
			// cNakladLineBindingSource
			// 
			this.cNakladLineBindingSource.DataSource = typeof(SC.Common.Model.CNakladLine);
			// 
			// gvNakladLines
			// 
			this.gvNakladLines.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.gvNakladLines.Appearance.FocusedRow.Options.UseBackColor = true;
			this.gvNakladLines.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.gvNakladLines.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.gvNakladLines.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.gvNakladLines.Appearance.SelectedRow.Options.UseBackColor = true;
			this.gvNakladLines.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNomenkl,
            this.colCategory,
            this.colMeasure,
            this.colQuantity,
            this.colQuantityOnSklad,
            this.colInventoryNum,
            this.colPrice,
            this.colPriceAdditional,
            this.colPriceTotal,
            this.colCost,
            this.colComment});
			this.gvNakladLines.DetailHeight = 512;
			this.gvNakladLines.FixedLineWidth = 4;
			this.gvNakladLines.GridControl = this.gcNakladLines;
			this.gvNakladLines.Name = "gvNakladLines";
			this.gvNakladLines.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			this.gvNakladLines.OptionsView.ShowFooter = true;
			this.gvNakladLines.OptionsView.ShowGroupPanel = false;
			this.gvNakladLines.Tag = "2";
			this.gvNakladLines.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvNakladLines_ShowingEditor);
			this.gvNakladLines.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvNakladLines_CellValueChanged);
			// 
			// colNomenkl
			// 
			this.colNomenkl.FieldName = "Nomenkl";
			this.colNomenkl.Name = "colNomenkl";
			this.colNomenkl.OptionsColumn.AllowEdit = false;
			this.colNomenkl.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Nomenkl", "{0}позиций")});
			this.colNomenkl.Visible = true;
			this.colNomenkl.VisibleIndex = 0;
			// 
			// colCategory
			// 
			this.colCategory.ColumnEdit = this.riCategory;
			this.colCategory.FieldName = "Category";
			this.colCategory.Name = "colCategory";
			this.colCategory.Visible = true;
			this.colCategory.VisibleIndex = 1;
			// 
			// riCategory
			// 
			this.riCategory.AutoHeight = false;
			this.riCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.riCategory.Name = "riCategory";
			// 
			// colMeasure
			// 
			this.colMeasure.FieldName = "Measure";
			this.colMeasure.Name = "colMeasure";
			this.colMeasure.OptionsColumn.AllowEdit = false;
			this.colMeasure.Visible = true;
			this.colMeasure.VisibleIndex = 2;
			// 
			// colQuantity
			// 
			this.colQuantity.FieldName = "Quantity";
			this.colQuantity.Name = "colQuantity";
			this.colQuantity.Visible = true;
			this.colQuantity.VisibleIndex = 3;
			// 
			// colQuantityOnSklad
			// 
			this.colQuantityOnSklad.FieldName = "QuantityOnSklad";
			this.colQuantityOnSklad.Name = "colQuantityOnSklad";
			this.colQuantityOnSklad.OptionsColumn.AllowEdit = false;
			this.colQuantityOnSklad.Visible = true;
			this.colQuantityOnSklad.VisibleIndex = 4;
			// 
			// colInventoryNum
			// 
			this.colInventoryNum.FieldName = "InventoryNum";
			this.colInventoryNum.Name = "colInventoryNum";
			this.colInventoryNum.Visible = true;
			this.colInventoryNum.VisibleIndex = 5;
			// 
			// colPrice
			// 
			this.colPrice.FieldName = "Price";
			this.colPrice.Name = "colPrice";
			this.colPrice.OptionsColumn.AllowEdit = false;
			this.colPrice.Visible = true;
			this.colPrice.VisibleIndex = 6;
			// 
			// colPriceAdditional
			// 
			this.colPriceAdditional.FieldName = "PriceAdditional";
			this.colPriceAdditional.Name = "colPriceAdditional";
			this.colPriceAdditional.OptionsColumn.AllowEdit = false;
			this.colPriceAdditional.Visible = true;
			this.colPriceAdditional.VisibleIndex = 7;
			// 
			// colPriceTotal
			// 
			this.colPriceTotal.FieldName = "PriceTotal";
			this.colPriceTotal.Name = "colPriceTotal";
			this.colPriceTotal.OptionsColumn.AllowEdit = false;
			this.colPriceTotal.Visible = true;
			this.colPriceTotal.VisibleIndex = 8;
			// 
			// colCost
			// 
			this.colCost.FieldName = "Cost";
			this.colCost.Name = "colCost";
			this.colCost.OptionsColumn.AllowEdit = false;
			this.colCost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cost", "{0:c2}")});
			this.colCost.Visible = true;
			this.colCost.VisibleIndex = 9;
			// 
			// colComment
			// 
			this.colComment.FieldName = "Comment";
			this.colComment.Name = "colComment";
			this.colComment.Visible = true;
			this.colComment.VisibleIndex = 10;
			// 
			// pnNakladProperties
			// 
			this.pnNakladProperties.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 5F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
			this.pnNakladProperties.Controls.Add(this.lbFirma);
			this.pnNakladProperties.Controls.Add(this.labelControl1);
			this.pnNakladProperties.Controls.Add(this.lbKonragent);
			this.pnNakladProperties.Controls.Add(this.labelControl2);
			this.pnNakladProperties.Controls.Add(this.lbObject);
			this.pnNakladProperties.Controls.Add(this.lbNumber);
			this.pnNakladProperties.Controls.Add(this.btnSelectObject);
			this.pnNakladProperties.Controls.Add(this.deDate);
			this.pnNakladProperties.Controls.Add(this.lbDate);
			this.pnNakladProperties.Controls.Add(this.txtNumber);
			this.pnNakladProperties.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnNakladProperties.Location = new System.Drawing.Point(0, 0);
			this.pnNakladProperties.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pnNakladProperties.Name = "pnNakladProperties";
			this.pnNakladProperties.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
			this.pnNakladProperties.Size = new System.Drawing.Size(861, 166);
			this.pnNakladProperties.TabIndex = 11;
			// 
			// lbKonragent
			// 
			this.pnNakladProperties.SetColumn(this.lbKonragent, 1);
			this.lbKonragent.Location = new System.Drawing.Point(144, 116);
			this.lbKonragent.Margin = new System.Windows.Forms.Padding(6, 9, 6, 6);
			this.lbKonragent.Name = "lbKonragent";
			this.pnNakladProperties.SetRow(this.lbKonragent, 3);
			this.lbKonragent.Size = new System.Drawing.Size(74, 19);
			this.lbKonragent.TabIndex = 9;
			this.lbKonragent.Text = "Контрагент:";
			// 
			// labelControl2
			// 
			this.pnNakladProperties.SetColumn(this.labelControl2, 0);
			this.labelControl2.Location = new System.Drawing.Point(6, 116);
			this.labelControl2.Margin = new System.Windows.Forms.Padding(6, 9, 6, 6);
			this.labelControl2.Name = "labelControl2";
			this.pnNakladProperties.SetRow(this.labelControl2, 3);
			this.labelControl2.Size = new System.Drawing.Size(74, 19);
			this.labelControl2.TabIndex = 8;
			this.labelControl2.Text = "Контрагент:";
			// 
			// lbObject
			// 
			this.pnNakladProperties.SetColumn(this.lbObject, 0);
			this.lbObject.Location = new System.Drawing.Point(6, 14);
			this.lbObject.Margin = new System.Windows.Forms.Padding(6, 14, 6, 6);
			this.lbObject.Name = "lbObject";
			this.pnNakladProperties.SetRow(this.lbObject, 0);
			this.lbObject.Size = new System.Drawing.Size(50, 19);
			this.lbObject.TabIndex = 7;
			this.lbObject.Text = "Объект:";
			// 
			// lbNumber
			// 
			this.pnNakladProperties.SetColumn(this.lbNumber, 0);
			this.lbNumber.Location = new System.Drawing.Point(6, 56);
			this.lbNumber.Margin = new System.Windows.Forms.Padding(6, 9, 6, 6);
			this.lbNumber.Name = "lbNumber";
			this.pnNakladProperties.SetRow(this.lbNumber, 1);
			this.lbNumber.Size = new System.Drawing.Size(118, 19);
			this.lbNumber.TabIndex = 0;
			this.lbNumber.Text = "Номер накладной:";
			// 
			// btnSelectObject
			// 
			this.btnSelectObject.Appearance.Options.UseTextOptions = true;
			this.btnSelectObject.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.btnSelectObject.AutoSize = true;
			this.pnNakladProperties.SetColumn(this.btnSelectObject, 1);
			this.btnSelectObject.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnSelectObject.Location = new System.Drawing.Point(144, 3);
			this.btnSelectObject.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
			this.btnSelectObject.MinimumSize = new System.Drawing.Size(0, 38);
			this.btnSelectObject.Name = "btnSelectObject";
			this.btnSelectObject.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pnNakladProperties.SetRow(this.btnSelectObject, 0);
			this.btnSelectObject.Size = new System.Drawing.Size(711, 38);
			this.btnSelectObject.TabIndex = 6;
			this.btnSelectObject.Text = "Выбрать объект";
			this.btnSelectObject.Click += new System.EventHandler(this.BtSelectObject_Click);
			// 
			// deDate
			// 
			this.pnNakladProperties.SetColumn(this.deDate, 1);
			this.pnNakladProperties.SetColumnSpan(this.deDate, 2);
			this.deDate.EditValue = null;
			this.deDate.Location = new System.Drawing.Point(144, 83);
			this.deDate.Margin = new System.Windows.Forms.Padding(6);
			this.deDate.Name = "deDate";
			this.deDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.deDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.deDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.pnNakladProperties.SetRow(this.deDate, 2);
			this.deDate.Size = new System.Drawing.Size(711, 18);
			this.deDate.TabIndex = 5;
			this.deDate.EditValueChanged += new System.EventHandler(this.EditDate_EditValueChanged);
			// 
			// lbDate
			// 
			this.pnNakladProperties.SetColumn(this.lbDate, 0);
			this.lbDate.Location = new System.Drawing.Point(6, 86);
			this.lbDate.Margin = new System.Windows.Forms.Padding(6, 9, 6, 6);
			this.lbDate.Name = "lbDate";
			this.pnNakladProperties.SetRow(this.lbDate, 2);
			this.lbDate.Size = new System.Drawing.Size(126, 19);
			this.lbDate.TabIndex = 2;
			this.lbDate.Text = "Дата перемещения:";
			// 
			// txtNumber
			// 
			this.pnNakladProperties.SetColumn(this.txtNumber, 1);
			this.pnNakladProperties.SetColumnSpan(this.txtNumber, 2);
			this.txtNumber.Location = new System.Drawing.Point(144, 53);
			this.txtNumber.Margin = new System.Windows.Forms.Padding(6);
			this.txtNumber.Name = "txtNumber";
			this.pnNakladProperties.SetRow(this.txtNumber, 1);
			this.txtNumber.Size = new System.Drawing.Size(711, 18);
			this.txtNumber.TabIndex = 3;
			this.txtNumber.EditValueChanged += new System.EventHandler(this.TbNumber_EditValueChanged);
			// 
			// labelControl1
			// 
			this.pnNakladProperties.SetColumn(this.labelControl1, 0);
			this.labelControl1.Location = new System.Drawing.Point(6, 146);
			this.labelControl1.Margin = new System.Windows.Forms.Padding(6, 9, 6, 6);
			this.labelControl1.Name = "labelControl1";
			this.pnNakladProperties.SetRow(this.labelControl1, 4);
			this.labelControl1.Size = new System.Drawing.Size(86, 19);
			this.labelControl1.TabIndex = 10;
			this.labelControl1.Text = "Организация:";
			// 
			// lbFirma
			// 
			this.pnNakladProperties.SetColumn(this.lbFirma, 1);
			this.lbFirma.Location = new System.Drawing.Point(144, 146);
			this.lbFirma.Margin = new System.Windows.Forms.Padding(6, 9, 6, 6);
			this.lbFirma.Name = "lbFirma";
			this.pnNakladProperties.SetRow(this.lbFirma, 4);
			this.lbFirma.Size = new System.Drawing.Size(86, 19);
			this.lbFirma.TabIndex = 11;
			this.lbFirma.Text = "Организация:";
			// 
			// FrmEditNaklad
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(861, 492);
			this.Controls.Add(this.gcNakladLines);
			this.Controls.Add(this.pnNakladProperties);
			this.Controls.Add(this.pnOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.Name = "FrmEditNaklad";
			this.Text = "Редактирование накладной";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmEditNaklad_FormClosed);
			this.pnOk.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcNakladLines)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cNakladLineBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvNakladLines)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.riCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pnNakladProperties)).EndInit();
			this.pnNakladProperties.ResumeLayout(false);
			this.pnNakladProperties.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.deDate.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel pnOk;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraEditors.SimpleButton btnOk;
		private DevExpress.XtraGrid.GridControl gcNakladLines;
		private DevExpress.XtraGrid.Views.Grid.GridView gvNakladLines;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox riCategory;
		private DevExpress.Utils.Layout.TablePanel pnNakladProperties;
		private DevExpress.XtraEditors.LabelControl lbNumber;
		private DevExpress.XtraEditors.SimpleButton btnSelectObject;
		private DevExpress.XtraEditors.DateEdit deDate;
		private DevExpress.XtraEditors.LabelControl lbDate;
		private DevExpress.XtraEditors.TextEdit txtNumber;
		private DevExpress.XtraEditors.LabelControl lbObject;
		private DevExpress.XtraEditors.LabelControl lbKonragent;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private System.Windows.Forms.BindingSource cNakladLineBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colNomenkl;
		private DevExpress.XtraGrid.Columns.GridColumn colCategory;
		private DevExpress.XtraGrid.Columns.GridColumn colMeasure;
		private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
		private DevExpress.XtraGrid.Columns.GridColumn colQuantityOnSklad;
		private DevExpress.XtraGrid.Columns.GridColumn colInventoryNum;
		private DevExpress.XtraGrid.Columns.GridColumn colPrice;
		private DevExpress.XtraGrid.Columns.GridColumn colPriceAdditional;
		private DevExpress.XtraGrid.Columns.GridColumn colPriceTotal;
		private DevExpress.XtraGrid.Columns.GridColumn colCost;
		private DevExpress.XtraGrid.Columns.GridColumn colComment;
		private DevExpress.XtraEditors.LabelControl lbFirma;
		private DevExpress.XtraEditors.LabelControl labelControl1;
	}
}