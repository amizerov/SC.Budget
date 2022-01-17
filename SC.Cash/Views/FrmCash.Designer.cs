namespace SC.Cash.Views
{
	partial class FrmCash
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCash));
			this.pnOk = new DevExpress.XtraEditors.PanelControl();
			this.btnOk = new DevExpress.XtraEditors.SimpleButton();
			this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
			this.gcCash = new DevExpress.XtraGrid.GridControl();
			this.cOperationCashBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvCash = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colDataCreate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colFirmaName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colOutPercent = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAmountToAcc = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDateToCash = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
			this.riStatus = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
			this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
			this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
			this.riMonth = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
			this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.riProjects = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colToAccountName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.riToAccount = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).BeginInit();
			this.pnOk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcCash)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cOperationCashBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvCash)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.riStatus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.riMonth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.riMonth.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.riProjects)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.riToAccount)).BeginInit();
			this.SuspendLayout();
			// 
			// pnOk
			// 
			this.pnOk.Controls.Add(this.btnOk);
			this.pnOk.Controls.Add(this.btnCancel);
			this.pnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnOk.Location = new System.Drawing.Point(0, 559);
			this.pnOk.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
			this.pnOk.Name = "pnOk";
			this.pnOk.Size = new System.Drawing.Size(1026, 119);
			this.pnOk.TabIndex = 28;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.ImageOptions.Image = global::SC.Cash.Properties.Resources.save;
			this.btnOk.Location = new System.Drawing.Point(806, 28);
			this.btnOk.Margin = new System.Windows.Forms.Padding(15, 14, 15, 14);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(191, 66);
			this.btnOk.TabIndex = 22;
			this.btnOk.Text = "Сохранить";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(645, 28);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(15, 14, 15, 14);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(139, 39);
			this.btnCancel.TabIndex = 23;
			this.btnCancel.Text = "Отмена";
			// 
			// gcCash
			// 
			this.gcCash.DataSource = this.cOperationCashBindingSource;
			this.gcCash.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcCash.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gcCash.Location = new System.Drawing.Point(0, 0);
			this.gcCash.MainView = this.gvCash;
			this.gcCash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gcCash.Name = "gcCash";
			this.gcCash.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riStatus,
            this.riMonth,
            this.riProjects,
            this.riToAccount});
			this.gcCash.Size = new System.Drawing.Size(1026, 559);
			this.gcCash.TabIndex = 29;
			this.gcCash.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCash});
			// 
			// cOperationCashBindingSource
			// 
			this.cOperationCashBindingSource.DataSource = typeof(SC.Cash.Model.COperationCash);
			// 
			// gvCash
			// 
			this.gvCash.Appearance.Empty.BorderColor = System.Drawing.Color.Black;
			this.gvCash.Appearance.Empty.Options.UseBorderColor = true;
			this.gvCash.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.gvCash.Appearance.FocusedRow.Options.UseBackColor = true;
			this.gvCash.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.gvCash.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.gvCash.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.gvCash.Appearance.SelectedRow.Options.UseBackColor = true;
			this.gvCash.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDataCreate,
            this.colFirmaName,
            this.colAmount,
            this.colOutPercent,
            this.colAmountToAcc,
            this.colDateToCash,
            this.colToAccountName,
            this.colStatus,
            this.colComment,
            this.colMonth,
            this.colProjectName});
			this.gvCash.DetailHeight = 515;
			this.gvCash.GridControl = this.gcCash;
			this.gvCash.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", null, "{0} счетов"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", null, " / Общая сумма {0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountToAcc", null, " / в кассу {0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", this.colDataCreate, "{0} счетов"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", this.colAmount, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountToAcc", this.colAmountToAcc, "{0:c2}")});
			this.gvCash.Name = "gvCash";
			this.gvCash.OptionsView.ShowFooter = true;
			this.gvCash.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvCash_RowStyle);
			this.gvCash.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvCash_CellValueChanged);
			this.gvCash.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvCash_CellValueChanging);
			this.gvCash.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvCash_ValidatingEditor);
			// 
			// colDataCreate
			// 
			this.colDataCreate.FieldName = "DataCreate";
			this.colDataCreate.MinWidth = 27;
			this.colDataCreate.Name = "colDataCreate";
			this.colDataCreate.OptionsColumn.AllowEdit = false;
			this.colDataCreate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DataCreate", "{0}счетов")});
			this.colDataCreate.Visible = true;
			this.colDataCreate.VisibleIndex = 0;
			this.colDataCreate.Width = 103;
			// 
			// colFirmaName
			// 
			this.colFirmaName.FieldName = "FirmaName";
			this.colFirmaName.MinWidth = 27;
			this.colFirmaName.Name = "colFirmaName";
			this.colFirmaName.OptionsColumn.AllowEdit = false;
			this.colFirmaName.Visible = true;
			this.colFirmaName.VisibleIndex = 1;
			this.colFirmaName.Width = 103;
			// 
			// colAmount
			// 
			this.colAmount.FieldName = "Amount";
			this.colAmount.MinWidth = 32;
			this.colAmount.Name = "colAmount";
			this.colAmount.OptionsColumn.AllowEdit = false;
			this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:c2}")});
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 2;
			this.colAmount.Width = 118;
			// 
			// colOutPercent
			// 
			this.colOutPercent.FieldName = "OutPercent";
			this.colOutPercent.MinWidth = 32;
			this.colOutPercent.Name = "colOutPercent";
			this.colOutPercent.Visible = true;
			this.colOutPercent.VisibleIndex = 3;
			this.colOutPercent.Width = 118;
			// 
			// colAmountToAcc
			// 
			this.colAmountToAcc.FieldName = "AmountToAcc";
			this.colAmountToAcc.MinWidth = 32;
			this.colAmountToAcc.Name = "colAmountToAcc";
			this.colAmountToAcc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountToAcc", "{0:c2}")});
			this.colAmountToAcc.Visible = true;
			this.colAmountToAcc.VisibleIndex = 4;
			this.colAmountToAcc.Width = 118;
			// 
			// colDateToCash
			// 
			this.colDateToCash.FieldName = "DateToCash";
			this.colDateToCash.MinWidth = 27;
			this.colDateToCash.Name = "colDateToCash";
			this.colDateToCash.Visible = true;
			this.colDateToCash.VisibleIndex = 5;
			this.colDateToCash.Width = 103;
			// 
			// colStatus
			// 
			this.colStatus.ColumnEdit = this.riStatus;
			this.colStatus.FieldName = "Status";
			this.colStatus.MinWidth = 32;
			this.colStatus.Name = "colStatus";
			this.colStatus.Visible = true;
			this.colStatus.VisibleIndex = 7;
			this.colStatus.Width = 118;
			// 
			// riStatus
			// 
			this.riStatus.AutoHeight = false;
			this.riStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.riStatus.HtmlImages = this.imageCollection;
			this.riStatus.LargeImages = this.imageCollection;
			this.riStatus.Name = "riStatus";
			this.riStatus.SmallImages = this.imageCollection;
			// 
			// imageCollection
			// 
			this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
			this.imageCollection.Images.SetKeyName(0, "Clock.png");
			this.imageCollection.Images.SetKeyName(1, "Ok.png");
			this.imageCollection.Images.SetKeyName(2, "Rejected.png");
			// 
			// colComment
			// 
			this.colComment.FieldName = "Comment";
			this.colComment.MinWidth = 32;
			this.colComment.Name = "colComment";
			this.colComment.OptionsColumn.AllowEdit = false;
			this.colComment.Visible = true;
			this.colComment.VisibleIndex = 8;
			this.colComment.Width = 118;
			// 
			// colMonth
			// 
			this.colMonth.ColumnEdit = this.riMonth;
			this.colMonth.FieldName = "Month";
			this.colMonth.MinWidth = 25;
			this.colMonth.Name = "colMonth";
			this.colMonth.Visible = true;
			this.colMonth.VisibleIndex = 9;
			this.colMonth.Width = 94;
			// 
			// riMonth
			// 
			this.riMonth.AutoHeight = false;
			this.riMonth.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.riMonth.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.riMonth.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
			this.riMonth.DisplayFormat.FormatString = "MMMM yyyy";
			this.riMonth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.riMonth.EditFormat.FormatString = "MMMM yyyy";
			this.riMonth.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.riMonth.Mask.EditMask = "MMMM yyyy";
			this.riMonth.Name = "riMonth";
			this.riMonth.ShowToday = false;
			this.riMonth.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.riMonth.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
			this.riMonth.VistaCalendarViewStyle = ((DevExpress.XtraEditors.VistaCalendarViewStyle)((DevExpress.XtraEditors.VistaCalendarViewStyle.YearView | DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView)));
			this.riMonth.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
			// 
			// colProjectName
			// 
			this.colProjectName.ColumnEdit = this.riProjects;
			this.colProjectName.FieldName = "ProjectName";
			this.colProjectName.MinWidth = 25;
			this.colProjectName.Name = "colProjectName";
			this.colProjectName.Visible = true;
			this.colProjectName.VisibleIndex = 10;
			this.colProjectName.Width = 129;
			// 
			// riProjects
			// 
			this.riProjects.AutoHeight = false;
			this.riProjects.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.riProjects.Name = "riProjects";
			// 
			// colToAccountName
			// 
			this.colToAccountName.ColumnEdit = this.riToAccount;
			this.colToAccountName.FieldName = "ToAccountName";
			this.colToAccountName.MinWidth = 25;
			this.colToAccountName.Name = "colToAccountName";
			this.colToAccountName.Visible = true;
			this.colToAccountName.VisibleIndex = 6;
			this.colToAccountName.Width = 94;
			// 
			// riToAccount
			// 
			this.riToAccount.AutoHeight = false;
			this.riToAccount.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.riToAccount.Name = "riToAccount";
			this.riToAccount.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			// 
			// FrmCash
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(1026, 678);
			this.Controls.Add(this.gcCash);
			this.Controls.Add(this.pnOk);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "FrmCash";
			this.Text = "Кэш";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCash_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.pnOk)).EndInit();
			this.pnOk.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcCash)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cOperationCashBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvCash)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.riStatus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.riMonth.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.riMonth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.riProjects)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.riToAccount)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.PanelControl pnOk;
		private DevExpress.XtraEditors.SimpleButton btnOk;
		private DevExpress.XtraEditors.SimpleButton btnCancel;
		private DevExpress.XtraGrid.GridControl gcCash;
		private DevExpress.XtraGrid.Views.Grid.GridView gvCash;
		private System.Windows.Forms.BindingSource cOperationCashBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colOutPercent;
		private DevExpress.XtraGrid.Columns.GridColumn colAmount;
		private DevExpress.XtraGrid.Columns.GridColumn colAmountToAcc;
		private DevExpress.XtraGrid.Columns.GridColumn colComment;
		private DevExpress.XtraGrid.Columns.GridColumn colStatus;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riStatus;
		private DevExpress.Utils.ImageCollection imageCollection;
		private DevExpress.XtraGrid.Columns.GridColumn colDataCreate;
		private DevExpress.XtraGrid.Columns.GridColumn colDateToCash;
		private DevExpress.XtraGrid.Columns.GridColumn colFirmaName;
		private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
		private DevExpress.XtraGrid.Columns.GridColumn colMonth;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit riMonth;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox riProjects;
		private DevExpress.XtraGrid.Columns.GridColumn colToAccountName;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox riToAccount;
	}
}