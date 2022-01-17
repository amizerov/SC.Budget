namespace SC.Cash.Views
{
	partial class PageRequests
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageRequests));
			this.gcRequest = new DevExpress.XtraGrid.GridControl();
			this.cRequestOpViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvRequest = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPaid = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
			this.riStatus = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
			this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
			this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
			this.riMonth = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
			this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.riProject = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
			this.riComment = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.colRest = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.gcRequest)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cRequestOpViewModelBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvRequest)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.riStatus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.riMonth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.riMonth.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.riProject)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.riComment)).BeginInit();
			this.SuspendLayout();
			// 
			// gcRequest
			// 
			this.gcRequest.DataSource = this.cRequestOpViewModelBindingSource;
			this.gcRequest.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcRequest.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.gcRequest.Location = new System.Drawing.Point(0, 0);
			this.gcRequest.MainView = this.gvRequest;
			this.gcRequest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.gcRequest.Name = "gcRequest";
			this.gcRequest.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riStatus,
            this.riComment,
            this.riMonth,
            this.riProject});
			this.gcRequest.Size = new System.Drawing.Size(1572, 735);
			this.gcRequest.TabIndex = 0;
			this.gcRequest.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRequest});
			// 
			// cRequestOpViewModelBindingSource
			// 
			this.cRequestOpViewModelBindingSource.DataSource = typeof(SC.Common.Model.CRequestOp);
			// 
			// gvRequest
			// 
			this.gvRequest.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserName,
            this.colDateTime,
            this.colAmount,
            this.colPaid,
            this.colRest,
            this.colStatus,
            this.colMonth,
            this.colProjectName,
            this.colComment});
			this.gvRequest.DetailHeight = 416;
			this.gvRequest.FixedLineWidth = 1;
			this.gvRequest.GridControl = this.gcRequest;
			this.gvRequest.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Status", null, " {0}шт"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", null, "Итого: {0:c2}")});
			this.gvRequest.Name = "gvRequest";
			this.gvRequest.OptionsEditForm.EditFormColumnCount = 1;
			this.gvRequest.OptionsEditForm.FormCaptionFormat = "Редактирование запроса";
			this.gvRequest.OptionsEditForm.PopupEditFormWidth = 700;
			this.gvRequest.OptionsView.RowAutoHeight = true;
			this.gvRequest.OptionsView.ShowFooter = true;
			this.gvRequest.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDateTime, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gvRequest.Tag = "1";
			this.gvRequest.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvRequest_RowStyle);
			this.gvRequest.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvRequest_ShowingEditor);
			this.gvRequest.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvRequest_CellValueChanged);
			this.gvRequest.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvRequest_CellValueChanging);
			this.gvRequest.Click += new System.EventHandler(this.gvRequest_Click);
			this.gvRequest.DoubleClick += new System.EventHandler(this.gvRequest_DoubleClick);
			this.gvRequest.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvRequest_ValidatingEditor);
			// 
			// colUserName
			// 
			this.colUserName.FieldName = "UserName";
			this.colUserName.MinWidth = 32;
			this.colUserName.Name = "colUserName";
			this.colUserName.OptionsColumn.AllowEdit = false;
			this.colUserName.OptionsColumn.ReadOnly = true;
			this.colUserName.Visible = true;
			this.colUserName.VisibleIndex = 1;
			this.colUserName.Width = 118;
			// 
			// colDateTime
			// 
			this.colDateTime.FieldName = "DateTime";
			this.colDateTime.MinWidth = 32;
			this.colDateTime.Name = "colDateTime";
			this.colDateTime.OptionsColumn.AllowEdit = false;
			this.colDateTime.OptionsColumn.ReadOnly = true;
			this.colDateTime.Visible = true;
			this.colDateTime.VisibleIndex = 0;
			this.colDateTime.Width = 118;
			// 
			// colAmount
			// 
			this.colAmount.FieldName = "Amount";
			this.colAmount.MinWidth = 32;
			this.colAmount.Name = "colAmount";
			this.colAmount.OptionsColumn.AllowEdit = false;
			this.colAmount.OptionsColumn.ReadOnly = true;
			this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "Итого {0:c2}")});
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 2;
			this.colAmount.Width = 118;
			// 
			// colPaid
			// 
			this.colPaid.FieldName = "Paid";
			this.colPaid.MinWidth = 25;
			this.colPaid.Name = "colPaid";
			this.colPaid.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Paid", "Итого {0:c2}")});
			this.colPaid.Visible = true;
			this.colPaid.VisibleIndex = 3;
			this.colPaid.Width = 94;
			// 
			// colStatus
			// 
			this.colStatus.ColumnEdit = this.riStatus;
			this.colStatus.FieldName = "Status";
			this.colStatus.MinWidth = 32;
			this.colStatus.Name = "colStatus";
			this.colStatus.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			this.colStatus.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Status", "{0} шт.")});
			this.colStatus.Visible = true;
			this.colStatus.VisibleIndex = 5;
			this.colStatus.Width = 118;
			// 
			// riStatus
			// 
			this.riStatus.AutoHeight = false;
			this.riStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.riStatus.LargeImages = this.imageCollection;
			this.riStatus.Name = "riStatus";
			this.riStatus.SmallImages = this.imageCollection;
			// 
			// imageCollection
			// 
			this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
			this.imageCollection.Images.SetKeyName(0, "Clock.png");
			this.imageCollection.Images.SetKeyName(1, "Rejected.png");
			this.imageCollection.Images.SetKeyName(2, "Ok.png");
			this.imageCollection.Images.SetKeyName(3, "Money.png");
			// 
			// colMonth
			// 
			this.colMonth.ColumnEdit = this.riMonth;
			this.colMonth.FieldName = "Month";
			this.colMonth.MinWidth = 25;
			this.colMonth.Name = "colMonth";
			this.colMonth.Visible = true;
			this.colMonth.VisibleIndex = 6;
			this.colMonth.Width = 129;
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
			this.riMonth.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
			this.riMonth.VistaCalendarViewStyle = ((DevExpress.XtraEditors.VistaCalendarViewStyle)((DevExpress.XtraEditors.VistaCalendarViewStyle.YearView | DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView)));
			this.riMonth.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
			// 
			// colProjectName
			// 
			this.colProjectName.ColumnEdit = this.riProject;
			this.colProjectName.FieldName = "ProjectName";
			this.colProjectName.MinWidth = 25;
			this.colProjectName.Name = "colProjectName";
			this.colProjectName.Visible = true;
			this.colProjectName.VisibleIndex = 7;
			this.colProjectName.Width = 129;
			// 
			// riProject
			// 
			this.riProject.AutoHeight = false;
			this.riProject.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.riProject.Name = "riProject";
			// 
			// colComment
			// 
			this.colComment.ColumnEdit = this.riComment;
			this.colComment.FieldName = "Comment";
			this.colComment.MinWidth = 32;
			this.colComment.Name = "colComment";
			this.colComment.OptionsEditForm.RowSpan = 8;
			this.colComment.OptionsEditForm.UseEditorColRowSpan = false;
			this.colComment.Visible = true;
			this.colComment.VisibleIndex = 8;
			this.colComment.Width = 118;
			// 
			// riComment
			// 
			this.riComment.Name = "riComment";
			// 
			// colRest
			// 
			this.colRest.FieldName = "Rest";
			this.colRest.MinWidth = 25;
			this.colRest.Name = "colRest";
			this.colRest.OptionsColumn.AllowEdit = false;
			this.colRest.Visible = true;
			this.colRest.VisibleIndex = 4;
			this.colRest.Width = 94;
			// 
			// PageRequests
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gcRequest);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "PageRequests";
			this.Size = new System.Drawing.Size(1572, 735);
			((System.ComponentModel.ISupportInitialize)(this.gcRequest)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cRequestOpViewModelBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvRequest)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.riStatus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.riMonth.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.riMonth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.riProject)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.riComment)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private DevExpress.XtraGrid.GridControl gcRequest;
		private DevExpress.XtraGrid.Views.Grid.GridView gvRequest;
		private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riStatus;
		private DevExpress.Utils.ImageCollection imageCollection;
		private System.Windows.Forms.BindingSource cRequestOpViewModelBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colUserName;
		private DevExpress.XtraGrid.Columns.GridColumn colDateTime;
		private DevExpress.XtraGrid.Columns.GridColumn colAmount;
		private DevExpress.XtraGrid.Columns.GridColumn colStatus;
		private DevExpress.XtraGrid.Columns.GridColumn colComment;
		private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit riComment;
		private DevExpress.XtraGrid.Columns.GridColumn colMonth;
		private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit riMonth;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox riProject;
		private DevExpress.XtraGrid.Columns.GridColumn colPaid;
		private DevExpress.XtraGrid.Columns.GridColumn colRest;
	}
}
