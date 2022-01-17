using System;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using SC.Common.Model;
using SC.Common.Services;

namespace SC.Common.Views
{
	public class DateFilter : RibbonPageGroup
	{
		private readonly BarEditItem _btnsIntervalMode;
		private readonly RepositoryItemRadioGroup _riIntervalMode;
		private readonly BarEditItem _deMonth;
		private readonly RepositoryItemDateEdit _riMonth;
		private readonly BarEditItem _deStart;
		private readonly BarEditItem _deEnd;
		private readonly RepositoryItemDateEdit _riEnd;
		private readonly RepositoryItemDateEdit _riStart;

		public DateFilter(RibbonControl ribbon)
		{
			_btnsIntervalMode = new BarEditItem();
			_riIntervalMode = new RepositoryItemRadioGroup();
			_deMonth = new BarEditItem();
			_riMonth = new RepositoryItemDateEdit();
			_deStart = new BarEditItem();
			_riStart = new RepositoryItemDateEdit();
			_deEnd = new BarEditItem();
			_riEnd = new RepositoryItemDateEdit();

			ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[]
			{
				_btnsIntervalMode,
				_deMonth,
				_deStart,
				_deEnd
			});

			// 
			// btnsIntervalMode
			// 
			_btnsIntervalMode.Caption = "Выбор даты";
			_btnsIntervalMode.Edit = _riIntervalMode;
			_btnsIntervalMode.EditValue = true;
			_btnsIntervalMode.EditWidth = 220;
			_btnsIntervalMode.Id = 47;
			_btnsIntervalMode.Name = "btnsIntervalMode";
			_btnsIntervalMode.EditValueChanged += OnUpdate;
			// 
			// riIntervalMode
			// 
			_riIntervalMode.Items.AddRange(new[] {
			new RadioGroupItem(true, "По месяцам"),
			new RadioGroupItem(false, "По датам")});
			_riIntervalMode.ItemsLayout = DevExpress.XtraEditors.RadioGroupItemsLayout.Flow;
			_riIntervalMode.Name = "riIntervalMode";
			// 
			// deMonth
			// 
			_deMonth.Caption = "Месяц ";
			_deMonth.Edit = _riMonth;
			_deMonth.EditWidth = 140;
			_deMonth.Id = 28;
			_deMonth.Name = "deMonth";
			_deMonth.EditValueChanged += OnUpdate;
			// 
			// riMonth
			// 
			_riMonth.Appearance.Options.UseTextOptions = true;
			_riMonth.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			_riMonth.AutoHeight = false;
			_riMonth.Buttons.AddRange(new EditorButton[] {
				new EditorButton(ButtonPredefines.Combo)});
			_riMonth.CalendarTimeProperties.Buttons.AddRange(new EditorButton[] {
				new EditorButton(ButtonPredefines.Combo)});
			_riMonth.CalendarView = CalendarView.Vista;
			_riMonth.DisplayFormat.FormatString = "MMMM yyyy";
			_riMonth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			_riMonth.EditFormat.FormatString = "MMMM yyyy";
			_riMonth.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			_riMonth.Mask.EditMask = "MMMM yyyy";
			_riMonth.Name = "riMonth";
			_riMonth.ShowToday = false;
			_riMonth.TextEditStyle = TextEditStyles.DisableTextEditor;
			_riMonth.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
			_riMonth.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView |
											 DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
			_riMonth.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;

			// 
			// deStart
			// 
			_deStart.Caption = "с";
			_deStart.Edit = _riStart;
			_deStart.EditWidth = 100;
			_deStart.Id = 48;
			_deStart.Name = "deStart";
			_deStart.Visibility = BarItemVisibility.Never;
			_deStart.EditValueChanged += OnUpdate;
			// 
			// riStart
			// 
			_riStart.AutoHeight = false;
			_riStart.Buttons.AddRange(new[] {
			new EditorButton(ButtonPredefines.Combo)});
			_riStart.CalendarTimeProperties.Buttons.AddRange(new[] {
			new EditorButton(ButtonPredefines.Combo)});
			_riStart.Name = "riStart";
			// 
			// deEnd
			// 
			_deEnd.Caption = " по";
			_deEnd.Edit = _riEnd;
			_deEnd.EditWidth = 100;
			_deEnd.Id = 49;
			_deEnd.Name = "deEnd";
			_deEnd.Visibility = BarItemVisibility.Never;
			_deEnd.EditValueChanged += OnUpdate;
			// 
			// riEnd
			// 
			_riEnd.AutoHeight = false;
			_riEnd.Buttons.AddRange(new[] {
			new EditorButton(ButtonPredefines.Combo)});
			_riEnd.CalendarTimeProperties.Buttons.AddRange(new[] {
			new EditorButton(ButtonPredefines.Combo)});
			_riEnd.Name = "riEnd";

			ItemLinks.Add(_btnsIntervalMode, false, "", "", true);
			ItemLinks.Add(_deMonth, false, "", "", true);
			ItemLinks.Add(_deStart, false, "", "", true);
			ItemLinks.Add(_deEnd, false, "", "", true);
			Name = "ribpgDateFilter";
			ShowCaptionButton = false;
			Text = "Фильтр по датам";
		}

		public event EventHandler Updated;
		public void OnUpdate(object sender, EventArgs e)
		{
			Updated?.Invoke(sender, e);
		}
		public void RestoreFormSettings()
		{
			var settings = LayoutSaver.LoadDate();

			_btnsIntervalMode.EditValue = settings.IsMonth;
			_deMonth.EditValue = settings.Month;

			if (settings.Start > DateTime.MinValue)
			{
				_deStart.EditValue = settings.Start;
				_deEnd.EditValue = settings.End;
			}
			else
			{
				_deStart.EditValue = DateTime.Today.AddMonths(-1);
				_deEnd.EditValue = DateTime.Today;
			}
		}
	}
}
