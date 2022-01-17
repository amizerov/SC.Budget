using am.BL;
using DevExpress.Data;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using LinqToDB.Data;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using SC.Common.Views;
using SC.Proda.Models;
using SC.Proda.Properties;
using SC.Proda.Tools;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Action = System.Action;
using Application = System.Windows.Forms.Application;
using COplata = SC.Proda.Models.COplata;
using CSchet = SC.Proda.Models.CSchet;

namespace SC.Proda.Views
{
	public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		#region Fields
		private enum Filter { None, Purple, Red, Green, Yellow, White }

		private CSchet _schet;
		private Filter _filter;
		private bool _isShowLoadToday;
		private bool _isShowUpdateValues;
		private decimal _summaryOstatok = 0; //Кастомная саммари остатка без учета Судебных

		private readonly bool _updating;
		private WhatUpdateService<CSchetProdaDto> _whatUpdateService;
		#endregion

		public FrmMain()
		{
			try
			{
				_updating = true;

				SplashScreenManager.ShowForm(this, typeof(WaitForm0));
				InitializeComponent();

				COM1C.Error += (message) => Invoke(new Action(() => On1CError(message)));
				COM1C.Connected += (message) => Invoke(new Action(() => OnConnectTo1C(message)));
				COM1C.ConnectTo1C("srvr='SWISSCLEAN'; ref='SwissAcc'; usr='Proger'; pwd='123'");

				G.OnError += OnDbError;
#if DEBUG
				Text += $" [DEBUG] {DbContext.DataSource}";
#endif
				am.DB.DBManager.Instance.Init(DbContext.GetConnectionString());

				G.CheckDB();

				RestoreFormSettings();

				deMonth.EditValue = DateTime.Now;

				statusVersion.Caption = "Версия: " + Application.ProductVersion;

				_updating = false;

				Reload();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void FrmMain_Shown(object sender, EventArgs e)
		{
			SplashScreenManager.CloseForm(false, 100, this);
			if (COM1C.Connecting)
			{
				TaskbarProgress.SetState(TaskbarProgress.TaskbarStates.Indeterminate, this);
			}
		}

		private void OnConnectTo1C(string res)
		{
			if (!IsHandleCreated || IsDisposed || Disposing) return;

			btnLoadSchetDets.Enabled =
			btnLoadOplatas.Enabled =
			btnUploadServicesTo1C.Enabled =
			btnStDohoTo1C.Enabled = COM1C.IsConnected;

			statusConnectedTo1C.Caption = res;
			TaskbarProgress.Finish(this);
		}

		private void OnDbError(string err)
		{
			if (!IsHandleCreated || IsDisposed || Disposing) return;
			Invoke(new Action(() =>
			{
				MessageBox.Show(this, err, "Ошибка в базе данных!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}));
		}
		private void On1CError(string err)
		{
			if (!IsHandleCreated || IsDisposed || Disposing) return;
			MessageService.ShowError("Ошибка в 1C!\n" + err);
		}

		#region Вкладка Счета
		private void btnNewSchet_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (IsErrorAccess()) return;
				using (var form = new FrmEditSchet())
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						UpdateScheta();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btnEditSchet_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (IsErrorAccess()) return;
				if (!(gvScheta.GetFocusedRow() is CSchetProdaViewModel vm)) return;

				using (var form = new FrmEditSchet(new CSchet(vm.ID)))
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						UpdateScheta();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void BtnSchetPaied_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (IsErrorAccess()) return;
				foreach (int h in gvScheta.GetSelectedRows())
				{
					if (!(gvScheta.GetFocusedRow() is CSchetProdaViewModel vm)) continue;
					var schet = new CSchet(vm.ID);
					if (schet.Summa == schet.Oplatas.Summa)
					{
						MessageBox.Show("Счет № " + schet.Nomer + " уже оплачен!", "Быстрая оплата",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					if (DialogResult.Yes == MessageBox.Show(
							"Счет № " + schet.Nomer + " будет оплачен одной суммой\n\r датой " +
							DateTime.Now.AddDays(-1).Date.ToString("dd/MM/yyyy") + "\n\r согласны?",
							"Быстрая оплата", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
					{
						schet.Pay();
						UpdateScheta();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btnDelSchet_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (IsErrorAccess()) return;
				if (!(gvScheta.GetFocusedRow() is CSchetProdaViewModel vm)) return;

				if (MessageBox.Show(this,
						"Хотите удалить этот счет №" + vm.Nomer +
						"?\nЕсли вы удалите счет, оплаты тоже будут удалены.",
						"Удаление счета",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					var schet = new CSchet(vm.ID);
					schet.Delete();
					UpdateScheta();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btnUpdateScheta_ItemClick(object sender, ItemClickEventArgs e)
		{
			UpdateScheta();
		}
		private void Reload()
		{
			UpdateLogin();
			UpdateScheta();
		}
		private void UpdateScheta()
		{
			try
			{
				if (_updating) return;
				var user = ApplicationUser.User;
				if (user == null)
				{
					gcScheta.DataSource = new CSchetProdaViewModel[0];
					return;
				}
				using (var db = new DbContext())
				{
					var (start, end) = DateService.UpdateStartEnd(btnsIntervalMode, deMonth, deStart, deEnd);
					var projIds = user.Role == Role.Rukovod ? CProjectDto.GetIds() : new int[0];
					var scheta = db.Query<CSchetProdaViewModel>(Resources.Scheta,
							new DataParameter("@start", start),
							new DataParameter("@end", end))
						.Where(s => user.Role != Role.Rukovod || projIds.Contains(s.Project_ID))
						.ToArray();

					switch (_filter)
					{
						case Filter.Purple: scheta = scheta.Where(s => s.Purple).ToArray(); break;
						case Filter.Red: scheta = scheta.Where(s => s.Red).ToArray(); break;
						case Filter.Yellow: scheta = scheta.Where(s => s.Yellow).ToArray(); break;
						case Filter.Green: scheta = scheta.Where(s => s.Green).ToArray(); break;
						case Filter.White: scheta = scheta.Where(s => s.White).ToArray(); break;
					}

					using (new GridViewStateSaver(gvScheta))
					{
						gcScheta.DataSource = scheta;
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void BtnToExcel_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var excel = new ExcelService(this))
				{
					excel.GridToExcel(gvScheta.ExportToXlsx)
						.SetAutoFit();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void BtnLoadFromXls_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (dlgOpenXlsToLoadFrom.ShowDialog() == DialogResult.OK)
				{
					SplashScreenManager.ShowForm(this, typeof(FrmLoadingFrom1C));
					TaskbarProgress.SetState(TaskbarProgress.TaskbarStates.Indeterminate, this);

					string f = dlgOpenXlsToLoadFrom.FileName;
					Excel exl = new Excel(f);
					SplashScreenManager.CloseForm(false, 0, this);
					if (!exl.LoadScheta())
					{
						TaskbarProgress.Error(this);
						MessageBox.Show(
							$"Загружено {exl.Count - 2} счетов, но возникла ошибка:\r\n" + exl.Error,
							"Ошибка загрузки из Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						MessageBox.Show(
							$"Загружено {exl.Count - 2} счетов, ошибок не возникло.",
							"Загрузка из Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					UpdateScheta();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
			finally
			{
				TaskbarProgress.Finish(this);
			}
		}

		private void btNoFilterScheta_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				_filter = Filter.None;
				UpdateSchetaFilter(e.Item);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void BtnPurple_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				_filter = Filter.Purple;
				UpdateSchetaFilter(e.Item);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btnRed_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				_filter = Filter.Red;
				UpdateSchetaFilter(e.Item);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btnGreen_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				_filter = Filter.Green;
				UpdateSchetaFilter(e.Item);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btnYelow_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				_filter = Filter.Yellow;
				UpdateSchetaFilter(e.Item);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void BtnWhite_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				_filter = Filter.White;
				UpdateSchetaFilter(e.Item);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void UpdateSchetaFilter(BarItem checkedButton)
		{
			try
			{
				new[]
				{
					btNoFilterScheta,
					btnPurple,
					btnRed,
					btnYelow,
					btnGreen,
					btnWhite,
				}.ForEach(button => button.Down = button.Equals(checkedButton));
				UpdateScheta();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btnShowSchetLoadToday_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				_isShowLoadToday = btnShowSchetLoadToday.Down;
				gvScheta.LayoutChanged();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}

		}
		private void btnShowSchetUpdateValues_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				_isShowUpdateValues = btnShowSchetUpdateValues.Down;
				_whatUpdateService = new WhatUpdateService<CSchetProdaDto>();
				gvScheta.LayoutChanged();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}

		}
		#endregion

		#region Вкладка Оплаты
		private void btnUpdateOplata_ItemClick(object sender, ItemClickEventArgs e)
		{
			UpdateOplata();
		}
		private void UpdateOplata()
		{
			try
			{
				gcOplata.DataSource = null;
				if (_schet != null)
				{
					gcOplata.DataSource = _schet.Oplatas.dt;
					gvOplata.Columns[0].Visible = false;
					gvOplata.BestFitColumns();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		#endregion

		#region Вкладка Обмен 1С
		private void BtnLoadSchetDets_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (IsNullInterval()) return;
				var (start, end) = DateService.UpdateStartEnd(btnsIntervalMode, deMonth, deStart, deEnd);

				SplashScreenManager.ShowForm(this, typeof(FrmLoadingFrom1C));
				TaskbarProgress.SetState(TaskbarProgress.TaskbarStates.Indeterminate, this);

				COM1C.LoadManySchets(start, end);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
			finally
			{
				UpdateScheta();
				SplashScreenManager.CloseForm(false, 0, this);
				TaskbarProgress.Finish(this);

				var question = COM1C.Otchet + "\n\nСкопировать текст в буфер обмена?";
				if (MessageService.ShowQuestion(question) == DialogResult.Yes)
				{
					Clipboard.SetDataObject(COM1C.Otchet);
				}
			}
		}
		private void btnLoadOplatas_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (IsNullInterval()) return;

				SplashScreenManager.ShowForm(this, typeof(FrmLoadingFrom1C));
				TaskbarProgress.SetState(TaskbarProgress.TaskbarStates.Indeterminate, this);

				var (start, end) = DateService.UpdateStartEnd(btnsIntervalMode, deMonth, deStart, deEnd);
				COM1C.LoadOplatas(start, end);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
			finally
			{
				UpdateScheta();
				SplashScreenManager.CloseForm(false, 0, this);
				TaskbarProgress.Finish(this);

				var question = COM1C.Otchet + "\n\nСкопировать текст в буфер обмена?";
				if (MessageService.ShowQuestion(question) == DialogResult.Yes)
				{
					Clipboard.SetDataObject(COM1C.Otchet);
				}
			}
		}

		private bool IsNullInterval()
		{
			if ((bool)btnsIntervalMode.EditValue && deMonth.EditValue == null)
			{
				MessageService.ShowError("Не выбран период, в течении которого требуется загрузить счета.");
				return true;
			}
			return false;
		}
		private void BtnUploadServicesTo1C_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var form = new FrmEditServices())
				{
					form.ShowDialog(this);
				}

				//Tools.COM1C.UploadServicesTo1C();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void BtnStDohoTo1C_ItemClick(object sender, ItemClickEventArgs e)
		{

		}
		#endregion

		private void GcScheta_DoubleClick(object sender, EventArgs e)
		{
			btnEditSchet_ItemClick(null, null);
		}
		private void GcScheta_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					btnEditSchet_ItemClick(null, null);
				}

				if (e.KeyCode == Keys.Delete)
				{
					btnDelSchet_ItemClick(null, null);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void GvScheta_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
		{
			try
			{
				if (_updating) return;
				if (gvScheta.GetFocusedRow() is CSchetProdaViewModel vm)
				{
					_schet = new CSchet(vm.ID);
				}
				else _schet = null;

				UpdateSchetLines();
				UpdateOplata();

				txtComment.Text = _schet?.Comment;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void UpdateSchetLines()
		{
			try
			{
				gcObjets.DataSource = null;

				if (_schet != null)
				{
					gcObjets.DataSource = _schet.Lines?.dt;
					gvObjects.Columns[0].Visible = false;
					gvObjects.BestFitColumns();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void GvScheta_RowStyle(object sender, RowStyleEventArgs e)
		{
			try
			{
				if (!(gvScheta.GetRow(e.RowHandle) is CSchetProdaViewModel schet)) return;
				var opacity = _isShowLoadToday ? 0.5 : 1;
				if (schet.Purple)
				{
					e.Appearance.BackColor = Color.FromArgb((int)(opacity * 150), Color.Purple);
					e.Appearance.ForeColor = Color.White;
				}
				else
				{
					e.Appearance.BackColor = schet.Red ? Color.FromArgb((int)(opacity * 150), Color.Red)
						: schet.Yellow ? Color.FromArgb((int)(opacity * 50), Color.Yellow)
						: schet.Green ? Color.FromArgb((int)(opacity * 100), Color.Lime)
						: Color.White;
				}

				if (_isShowLoadToday &&
					schet.dtc.Date == DateTime.Today)
				{
					e.Appearance.BackColor = Color.FromArgb(255, 128, 0);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void gvScheta_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
		{
			try
			{
				if (!(gvScheta.GetRow(e.RowHandle) is CSchetProdaViewModel schet)) return;

				if (_isShowUpdateValues)
				{
					var fieldName = e.Column.FieldName.Replace("Name", "_ID");
					if (_whatUpdateService.IsUpdated(schet.ID, fieldName))
					{
						e.Appearance.BackColor = Color.FromArgb(0, 100, 200);
						e.Appearance.ForeColor = Color.White;
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void GvScheta_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
		{
			try
			{
				if (!(e.Item is GridSummaryItem item)) return;
				if (!e.IsTotalSummary || item.FieldName != nameof(CSchetProdaViewModel.Rest)) return;

				switch (e.SummaryProcess)
				{
					case CustomSummaryProcess.Start:
						_summaryOstatok = 0;
						break;
					case CustomSummaryProcess.Calculate:
						if (!(gvScheta.GetRow(e.RowHandle) is CSchetProdaViewModel vm)) return;
						if (!vm.Purple || _filter == Filter.Purple) //Если включен фильтр по сереневым, то считаем все
						{
							_summaryOstatok += vm.Rest;
						}
						break;
					case CustomSummaryProcess.Finalize:
						e.TotalValue = _summaryOstatok;
						break;
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void GvOplata_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (IsErrorAccess()) return;
				int id = G._I(((DataRowView)gvOplata.GetRow(e.RowHandle))[0]);
				string n = e.Column.Name.Replace("col", "");
				string v = e.Value.ToString();

				COplata o = null;
				if (id > 0)
				{
					o = new COplata(_schet.ID, id);

					if (n == "Сумма") o.Сумма = double.Parse(v);
					if (n == "Дата") o.Дата = G._D(v);
				}
				else if (n == "Сумма")
					o = new COplata(_schet.ID) { Сумма = double.Parse(v), Дата = DateTime.Now };
				else if (n == "Дата")
					o = new COplata(_schet.ID) { Сумма = 0, Дата = G._D(v) };

				if (o != null) o.Save();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void StartEnd_ValueChanged(object sender, EventArgs e) => UpdateScheta();

		#region Настройки формы
		private void RestoreFormSettings()
		{
			try
			{
				var settings = LayoutSaver.LoadDate();

				btnsIntervalMode.EditValue = settings.IsMonth;
				deMonth.EditValue = settings.Month;

				if (settings.Start > DateTime.MinValue)
				{
					deStart.EditValue = settings.Start;
					deEnd.EditValue = settings.End;
				}
				else
				{
					deStart.EditValue = DateTime.Today.AddMonths(-1);
					deEnd.EditValue = DateTime.Today;
				}

				LayoutSaver.Restore(this);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				var isMonth = (bool)(btnsIntervalMode?.EditValue ?? false);
				var month = deMonth.EditValue as DateTime?;
				var start = deStart.EditValue as DateTime?;
				var end = deEnd.EditValue as DateTime?;

				LayoutSaver.Save(this);
				LayoutSaver.SaveDate(isMonth, month, start, end);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btResetSettings_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				var question = "Настройки экрана будут сброшены.\nПродолжить?";
				if (MessageService.ShowQuestion(question) == DialogResult.Yes)
				{
					LayoutSaver.Reset();
					MessageService.ShowMessage("Настройки экрана сброшены.\nИзменения вступят после перезапуска приложения.");
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		#endregion

		#region Авторизация
		private void UpdateLogin()
		{
			var user = ApplicationUser.User;

			btnLogin.Visibility = user != null ? BarItemVisibility.Never : BarItemVisibility.Always;
			btnLogout.Visibility = user == null ? BarItemVisibility.Never : BarItemVisibility.Always;
			ribbon.Enabled = user != null;

			if (user == null)
			{
				lbUserProfile.Caption = "Вход не выполнен";
				return;
			}

			lbUserProfile.Caption = $"Пользователь: {user.Login.Trim()} / {user.Name.Trim()} / {user.RoleName.Trim()}";
			ribpgScheta.Visible =
			rpLoadFrom1С.Visible = user.Role != Role.Rukovod;
			rpOplatas.Visible = false;
		}
		private void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				var user = CUser.GetAutoLoginPass();
				using (var form = new FrmLogin(user))
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						Reload();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				var question = "Вы действительно хотите выйти из профиля?";
				if (MessageService.ShowQuestion(question) == DialogResult.Yes)
				{
					ApplicationUser.User = null;
					Reload();
					btnLogin_ItemClick(this, e);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		public bool IsErrorAccess()
		{
			var user = ApplicationUser.User;
			if (user?.Role == Role.Rukovod)
			{
				MessageService.ShowError("У Вас нет доступа к редактированию счетов.");
				return true;
			}
			return false;
		}
		#endregion

		private void btDetails_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var form = new FrmDetails())
				{
					form.ShowDialog(this);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btStDohos_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var form = new FrmStDohos())
				{
					form.ShowDialog(this);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}
