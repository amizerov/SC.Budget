using am.BL;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraSplashScreen;
using LinqToDB;
using LinqToDB.Data;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using SC.Common.Views;
using SC.Zakup.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NLog;
using SC.Zakup;
using SC.Zakup.Models;
using SC.Zakup.Tools;
using SC.Zakup.Views;
using CSchet = SC.Zakup.Models.CSchet;

namespace SC.Zakup.Views
{
	public partial class FrmMain : RibbonForm
	{
		private bool _updating;
		private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
		public FrmMain()
		{
			try
			{
#if !DEBUG
				SplashScreenManager.ShowForm(this, typeof(WaitForm0));
#endif
				_updating = true;

				InitializeComponent();

				COM1C.OnConnect += (message) => OnConnectTo1C(message);
#if DEBUG
				Text += $" [DEBUG] {DbContext.DataSource}";
				COM1C.ConnectTo1C("srvr='SWISSCLEAN'; ref='SwissAcc'; usr='Proger'; pwd='123'");
				//COM1C.ConnectTo1C("srvr='SWISSCLEAN'; ref='DB1C'; usr='Proger'; pwd='123'");
				btDeveloper.Visibility = BarItemVisibility.Always;
#else
				COM1C.ConnectTo1C("srvr='SWISSCLEAN'; ref='SwissAcc'; usr='Proger'; pwd='123'");
#endif
				G.OnError += OnDbError;
				am.DB.DBManager.Instance.Init(DbContext.GetConnectionString());
				G.CheckDB();

				pageNaklads.Updated += (s, args) => UpdateNaklads();
				pageScheta.EditingSchet += (s, args) => btnEditSchet_ItemClick(s, null);
				pageScheta.DeletingSchet += (s, args) => btnDelSchet_ItemClick(s, null);

				void LoadComboBox(RepositoryItemComboBox ri, BarEditItem cb, string[] names)
				{
					ri.Items.Add("Все");
					ri.Items.AddRange(names);
					cb.EditValue = "Все";
				}
				using (var db = new DbContext())
				{
					var skladIds = CObjectDto.GetIds(true, false, true, true);
					var sklads = db.GetWhere<CObjectDto>(o => skladIds.Contains(o.ID));
					var skladNames = sklads.Select(s => s.Name).OrderBy(s => s).ToArray();
					LoadComboBox(riSkladOnNaklads, cbSkladOnNaklads, skladNames);
					LoadComboBox(riSkladOnSklad, cbSkladOnSklad, skladNames);

					var firmas = db.AllNames<CFirmaDto>();
					LoadComboBox(riFirmaOnScheta, cbFirmaOnScheta, firmas);
					LoadComboBox(riFirmaOnUslugi, cbFirmaOnUslugi, firmas);
					LoadComboBox(riFirmaOnNaklads, cbFirmaOnNaklads, firmas);
					LoadComboBox(riFirmaOnObjects, cbFirmaOnObjects, firmas);

					var suppliers = db.AllNames<CSupplierDto>();
					LoadComboBox(riSupplier, cbSupplier, suppliers);
				}

				RestoreFormSettings();
				Reload();

				lbVersion.Caption = "Версия: " + Application.ProductVersion;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}

		private void Reload()
		{
			_updating = true;

			btIsNakladsFromUser.Down = true;
			btIsNakladsFrom1C.Down = true;

			_updating = false;

			UpdateLogin();
			UpdateSelectedPage(this, EventArgs.Empty);
		}
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
			rpScheta.Visible = user.Role == Role.Admin ||
								user.Role == Role.Director ||
								user.Role == Role.Rukovod ||
								user.Role == Role.Buh ||
								user.Role == Role.ManagerZakup;
			ribpgScheta.Visible =
			ribpgScheta1C.Visible = user.Role == Role.Admin ||
									user.Role == Role.Director ||
									user.Role == Role.Buh;
			btnNalogImportFromExcel.Visibility = BarItemVisibility.Never;
			btNewNakladByNakladOnNaklads.Visibility = BarItemVisibility.Always;

			btnEditNaklad.Visibility =
			btDeleteNaklads.Visibility = user.Role == Role.Admin
				? BarItemVisibility.Always
				: BarItemVisibility.Never;

			cbSkladOnNaklads.Visibility =
			cbFirmaOnNaklads.Visibility = user.Role == Role.Admin || user.Role == Role.Director
				? BarItemVisibility.Always
				: BarItemVisibility.Never;

			rpNaklads.Visible =
			rpSklad.Visible =
			rpObjects.Visible = user.Role == Role.Admin ||
								user.Role == Role.Director ||
								user.Role == Role.ManagerZakup ||
								user.Role == Role.Kladovshchik;

			rpUslugi.Visible = user.Role == Role.Admin ||
							   user.Role == Role.Director;
		}
		private void OnConnectTo1C(string res)
		{
			if (Disposing || IsDisposed || !IsHandleCreated) return;
			Invoke(new Action(() =>
			{
				btnLoadUslugi.Enabled =
				btnLoadPostup2.Enabled =
				btnLoadSchetaFrom1C.Enabled =
				btnLoadAvancesFrom1C.Enabled =
				btnLoadOplatasFrom1C.Enabled = COM1C.IsConnected;
				statusConnectedTo1C.Caption = res;
				TaskbarProgress.Finish(this);
			}));
		}
		private void OnDbError(string err)
		{
			MessageService.ShowError("Ошибка в базе данных!\n\n" + err);
		}

		private void UpdateSelectedPage(object sender, EventArgs e)
		{
			if (_updating) return;
			try
			{
				if (ribbon.SelectedPage == rpScheta)
				{
					ShowPage(pageScheta);
					UpdateScheta();
				}
				if (ribbon.SelectedPage == rpOplatas)
				{
					ShowPage(pageOplatas);
					UpdateOplatas();
				}
				if (ribbon.SelectedPage == rpUslugi)
				{
					ShowPage(pageNaklads);
					UpdateUslugi();
				}
				if (ribbon.SelectedPage == rpObjects)
				{
					ShowPage(pageObjects);
					UpdateObjects();
				}
				if (ribbon.SelectedPage == rpNaklads)
				{
					ShowPage(pageNaklads);
					UpdateNaklads();
				}
				if (ribbon.SelectedPage == rpSklad)
				{
					ShowPage(pageSklad);
					UpdateSklad();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}
		private void UpdateSelectedPage(object sender, ItemClickEventArgs e) => UpdateSelectedPage(sender, EventArgs.Empty);
		private void UpdateScheta()
		{
			var (start, end) = DateService.UpdateStartEnd(btnsIntervalModeScheta, deMonthScheta, deStartScheta, deEndScheta);
			var (oplataStart, oplataEnd) = UpdateOplataStartEnd(start);
			var filter = btnRed.Down ? PageScheta.Filter.Red
				: btnYelow.Down ? PageScheta.Filter.Yellow
				: btnGreen.Down ? PageScheta.Filter.Green
				: btnWhite.Down ? PageScheta.Filter.White
				: btnYelowOrWhite.Down ? PageScheta.Filter.YellowOrWhite
				: PageScheta.Filter.None;
			var firma = cbFirmaOnScheta.EditValue as string;
			var supplier = cbSupplier.EditValue as string;
			var isAvance = btSchetaOrAvance.EditValue as string;

			pageScheta.UpdateData(start, end, oplataStart, oplataEnd, filter, btIsSnippedOnly.Down, firma, supplier, isAvance);
		}

		private (DateTime? start, DateTime? end) UpdateOplataStartEnd(DateTime startScheta)
		{
			var start = (DateTime?)deOplataStart.EditValue;
			var end = ((DateTime?)deOplataEnd.EditValue)?.AddDays(1);

			riOplataStart.MinValue = startScheta;
			riOplataStart.MaxValue = end?.AddDays(-1) ?? DateTime.MaxValue;
			riOplataEnd.MinValue = start ?? DateTime.MinValue;

			return (start, end);
		}
		private void UpdateOplatas()
		{
			var (start, end) = DateService.UpdateStartEnd(btnsIntervalModeOplatas, deMonthOplatas, deStartOplatas, deEndOplatas);
			pageOplatas.UpdateData(start, end);
		}
		private void UpdateUslugi()
		{
			var (start, end) = DateService.UpdateStartEnd(btnsIntervalModeUslugi, deMonthUslugi, deStartUslugi, deEndUslugi);
			var firma = cbFirmaOnUslugi.EditValue as string;
			var from1C = btIsUslugiFrom1C.Down;
			var fromUser = btIsUslugiFromUser.Down;
			var categories = new[] { PostupCategory.Услуга, PostupCategory.Аренда };

			btNewNakladByNakladOnUslugi.Enabled =
			btNakladToNullOnUslugi.Enabled = !from1C;

			pageNaklads.UpdateData(start, end, from1C, fromUser, firma, "Все", categories);
		}
		private void UpdateNaklads()
		{
			var (start, end) = DateService.UpdateStartEnd(btnsIntervalModeNaklad, deMonthNaklad, deStartNaklad, deEndNaklad);
			var firma = cbFirmaOnNaklads.EditValue as string;
			var sklad = cbSkladOnNaklads.EditValue as string;
			var from1C = btIsNakladsFrom1C.Down;
			var fromUser = btIsNakladsFromUser.Down;
			var categories = new[] { PostupCategory.Расходники, PostupCategory.ОС, PostupCategory.Инвентарь };

			btNewNakladByNakladOnNaklads.Enabled =
			btNakladToNullOnNaklads.Enabled = !from1C;

			pageNaklads.UpdateData(start, end, from1C, fromUser, firma, sklad, categories);
		}
		private void UpdateObjects()
		{
			var (start, end) = DateService.UpdateStartEnd(btnsIntervalModeObjects, deMonthObjects, deStartObjects, deEndObjects);
			var firma = cbFirmaOnObjects.EditValue as string;
			pageObjects.UpdateData(start, end, firma);
		}
		private void UpdateSklad()
		{
			var (start, end) = DateService.UpdateStartEnd(btnsIntervalModeSklad, deMonthSklad, deStartSklad, deEndSklad);
			var sklad = cbSkladOnSklad.EditValue as string;
			pageSklad.UpdateData(start, end, sklad);
		}

		#region Настройка экрана
		private void ShowPage(Control page)
		{
			Control[] pages = { pageScheta, pageOplatas, pagePostup, pageObjects, pageNaklads };
			EnumerableExtensions.ForEach(pages, p => p.Visible = p == page);
			if (page != null)
			{
				page.Dock = DockStyle.Fill;
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

		private void RestoreFormSettings()
		{
			try
			{
				LayoutSaver.Restore(this);
				RestoreDate(btnsIntervalModeScheta, deMonthScheta, deStartScheta, deEndScheta);
				RestoreDate(btnsIntervalModeUslugi, deMonthUslugi, deStartUslugi, deEndUslugi);
				RestoreDate(btnsIntervalModeNaklad, deMonthNaklad, deStartNaklad, deEndNaklad);
				RestoreDate(btnsIntervalModeObjects, deMonthObjects, deStartObjects, deEndObjects);
				RestoreDate(btnsIntervalModeSklad, deMonthSklad, deStartSklad, deEndSklad);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}

		private void RestoreDate(BarEditItem btnsIntervalMode, BarEditItem deMonth, BarEditItem deStart, BarEditItem deEnd)
		{
			var settings = LayoutSaver.LoadDate(deStart.Name.Replace("deStart", ""));

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
		}

		private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				LayoutSaver.Save(this);
				SaveDate(btnsIntervalModeScheta, deMonthScheta, deStartScheta, deEndScheta);
				SaveDate(btnsIntervalModeUslugi, deMonthUslugi, deStartUslugi, deEndUslugi);
				SaveDate(btnsIntervalModeNaklad, deMonthNaklad, deStartNaklad, deEndNaklad);
				SaveDate(btnsIntervalModeObjects, deMonthObjects, deStartObjects, deEndObjects);
				SaveDate(btnsIntervalModeSklad, deMonthSklad, deStartSklad, deEndSklad);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}

		private void SaveDate(BarEditItem btnsIntervalMode, BarEditItem deMonth, BarEditItem deStart, BarEditItem deEnd)
		{
			var isMonth = (bool)(btnsIntervalMode?.EditValue ?? false);
			var month = deMonth.EditValue as DateTime?;
			var start = deStart.EditValue as DateTime?;
			var end = deEnd.EditValue as DateTime?;
			LayoutSaver.SaveDate(isMonth, month, start, end, deStart.Name.Replace("deStart", ""));
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
				Logger.Error(ex);
			}
		}
		#endregion

		#region Кнопки на вкладке Счета
		private void btnNewSchet_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (pageScheta.IsErrorAccess()) return;
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
				Logger.Error(ex);
			}
		}
		private void btnEditSchet_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (pageScheta.IsErrorAccess()) return;
				int id = pageScheta.FocusedSchet?.ID ?? -1;
				if (id <= 0) return;

				using (var form = new FrmEditSchet(id))
				{
					form.ShowDialog(this);
					UpdateScheta();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}
		private void SchetaFilter_ItemClick(object sender, ItemClickEventArgs e)
		{
			EnumerableExtensions.ForEach(new[]
			{
				btNoFilterScheta,
				btnRed,
				btnYelow,
				btnGreen,
				btnWhite,
				btnYelowOrWhite,
			}, button => button.Down = button.Equals(e.Item));
			UpdateScheta();
		}
		private void btnSchetaExportToExcel_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var excel = new ExcelService(this))
				{
					excel.GridToExcel(pageScheta.ExportToXlsx)
						.SetAutoFit();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}
		private void btnDelSchet_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (pageScheta.IsErrorAccess()) return;
				int id = pageScheta.FocusedSchet?.ID ?? -1;
				if (id <= 0) return;
				CSchet Schet = new CSchet(id);

				if (MessageBox.Show(this,
					"Вы хотите удалить счет № " + Schet.Nomer + "?\nСчет будет помечен как удаленный.",
					"Удаление счета",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Schet.MarkAsDeleted();
					UpdateScheta();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}

		private void BtnSchetaImportFromExcel_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (dlgOpenXlsToLoadFrom.ShowDialog() == DialogResult.OK)
				{
					string f = dlgOpenXlsToLoadFrom.FileName;
					if (!Excel.LoadScheta(f, out var cnt))
					{
						MessageService.ShowError("Ошибка загрузки из Excel\n\n" + Excel.Error);
					}
					else
					{
						MessageService.ShowMessage("Успешно загружено " + cnt + " строк!");
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}
		private void btnNalogImportFromExcel_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (dlgOpenXlsToLoadFrom.ShowDialog() == DialogResult.OK)
				{
					TaskbarProgress.SetState(TaskbarProgress.TaskbarStates.Indeterminate, this);
					var fileName = dlgOpenXlsToLoadFrom.FileName;
					Excel.LoadNalog(fileName, this);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
			finally
			{
				UpdateScheta();
				TaskbarProgress.Finish(this);

				var question = Excel.Otchet + "\n\nСкопировать текст в буфер обмена?";
				if (MessageService.ShowQuestion(question) == DialogResult.Yes)
				{
					Clipboard.SetDataObject(Excel.Otchet);
				}
			}
		}
		private void BtnSchetPaied_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (pageScheta.IsErrorAccess()) return;
				pageScheta.PaySelectedSchets();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}
		private void BtnLoadSchetaFrom1C_ItemClick(object sender, ItemClickEventArgs e)
		{
			var firma = cbFirmaOnScheta.EditValue as string;
			var supplier = cbSupplier.EditValue as string;
			var (start, end) = DateService.UpdateStartEnd(btnsIntervalModeScheta, deMonthScheta, deStartScheta, deEndScheta);
			LoadFrom1C(() => COM1C.LoadManySchets(start, end, firma, supplier),
				() => LoadSchetaFinish(start, end));
			UpdateScheta();
		}

		private void LoadSchetaFinish(DateTime start, DateTime end)
		{
			SplashScreenManager.CloseForm(false, 0, this);
			TaskbarProgress.Finish(this);
			if (COM1C.Scheta.Any())
			{
				using (var form = new FrmLoadScheta(COM1C.Scheta))
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						Excel.SaveSchetaBeforeLoadDetails(start, end);
						COM1C.LoadSchetaFinish();
					}
					else
					{
						COM1C.Otchet = "Загрузка отменена пользователем";
					}
				}
			}
		}

		private void btnLoadAvancesFrom1C_ItemClick(object sender, ItemClickEventArgs e)
		{
			var firma = cbFirmaOnScheta.EditValue as string;
			var (start, end) = DateService.UpdateStartEnd(btnsIntervalModeScheta, deMonthScheta, deStartScheta, deEndScheta);
			LoadFrom1C(() => COM1C.LoadManyAvances(start, end, firma),
				() => LoadSchetaFinish(start, end));
			UpdateScheta();
		}
		private void btnLoadOplatasFrom1C_ItemClick(object sender, ItemClickEventArgs e)
		{
			var (start, end) = DateService.UpdateStartEnd(btnsIntervalModeScheta, deMonthScheta, deStartScheta, deEndScheta);
			LoadFrom1C(() => COM1C.LoadOplatas(start, end),
				() => COM1C.CreateOplatasForPaidScheta(start, end));
			UpdateScheta();
		}
		private void btLoadOplatasFrom1C_ItemClick(object sender, ItemClickEventArgs e)
		{
			var (start, end) = DateService.UpdateStartEnd(btnsIntervalModeOplatas, deMonthOplatas, deStartOplatas, deEndOplatas);
			LoadFrom1C(() => COM1C.LoadOplatas2(start, end),
				() => COM1C.CreateOplatasForPaidScheta(start, end));
			UpdateOplatas();
		}

		private void LoadFrom1C(params Action[] actions)
		{
			var isError = false;
			try
			{
				if (IsNullInterval())
				{
					isError = true;
					return;
				}

				TaskbarProgress.SetState(TaskbarProgress.TaskbarStates.Indeterminate, this);
				SplashScreenManager.ShowForm(this, typeof(FrmLoadingFrom1C));

				foreach (var action in actions) action?.Invoke();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
				isError = true;
			}
			finally
			{
				UpdateScheta();
				SplashScreenManager.CloseForm(false, 0, this);
				TaskbarProgress.Finish(this);

				if (!isError)
				{
					using (var msgBox = new FrmMessage(COM1C.Otchet))
					{
						msgBox.ShowDialog(this);
					}
				}
			}
		}
		private bool IsNullInterval()
		{
			bool IsError()
			{
				if ((bool)btnsIntervalModeScheta.EditValue)
				{
					if (deMonthScheta.EditValue == null) return true;
				}
				else
				{
					if (deStartScheta.EditValue == null) return true;
					if (deEndScheta.EditValue == null) return true;
				}
				return false;
			}

			var isError = IsError();
			if (isError) MessageService.ShowError("Не выбран период, в течении которого требуется загрузить счета.");
			return isError;
		}
		private void BtnShowSchetLoadTodayItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				pageScheta.IsShowLoadToday = btnShowSchetLoadToday.Down;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}

		private void btnShowSchetUpdateValues_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				pageScheta.IsShowUpdateValues = btnShowSchetUpdateValues.Down;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}
		private void btBackUpScheta_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				var appFolder = Path.Combine("C:\\SCAS", "Закупки");
				var dir = new DirectoryInfo(appFolder);
				if (!dir.Exists) dir.Create();
				Process.Start(appFolder);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}

		private void btStRash_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var form = new FrmStRashs())
				{
					form.ShowDialog(this);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}

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
				Logger.Error(ex);
			}
		}
		#endregion

		#region Поступления и накладная
		private void BtnLoadUslugi_ItemClick(object sender, ItemClickEventArgs e)
		{
			var (start, end) = DateService.UpdateStartEnd(btnsIntervalModeUslugi, deMonthUslugi, deStartUslugi, deEndUslugi);
			LoadFrom1C(() => COM1C.LoadUslugi(start, end));
			UpdateUslugi();
		}
		private void BtnLoadPostup_ItemClick(object sender, ItemClickEventArgs e)
		{
			var (start, end) = DateService.UpdateStartEnd(btnsIntervalModeNaklad, deMonthNaklad, deStartNaklad, deEndNaklad);
			LoadFrom1C(() => COM1C.LoadPostup(start, end));
			UpdateNaklads();
		}
		private void BtnNakladToExcel_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				int id = pageNaklads.FocusedNaklad?.ID ?? 0;
				var n = new Models.CNakladnaya(id);
				var obj = new CObject(n.Object_ID.Value);
				Excel.CreateNaklad(n, obj);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}
		private void btnActToExcel_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				int id = pageNaklads.FocusedNaklad?.ID ?? 0;
				var n = new Models.CNakladnaya(id);
				Excel.CreateAct(n);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}
		private void BtnEditNaklad_ItemClick(object sender, ItemClickEventArgs e)
		{
			pageNaklads.EditSlelectedNaklad();
		}

		private void ChangePostupCategoryFilterOnObj(object sender, ItemClickEventArgs e)
		{
			if (!(sender is RibbonBarManager mng)) return;
			var bt = mng.PressedLink.Item;
			var filter = new List<PostupCategory>();
			var categories = new Dictionary<BarItem, PostupCategory>
			{
				[btnRashFilterPostupOnObj] = PostupCategory.Расходники,
				[btnInventoryFilterPostupOnObj] = PostupCategory.Инвентарь,
				[btnOsFilterPostupOnObj] = PostupCategory.ОС
			};
			if (categories.ContainsKey(bt)) filter.Add(categories[bt]);
			pageObjects.CategoryFilter = filter;
			pageObjects.TreeObjects_FocusedNodeChanged(this, null);

			EnumerableExtensions.ForEach(new[]
			{
				btNoFilterPostupOnObj,
				btnInventoryFilterPostupOnObj,
				btnOsFilterPostupOnObj,
				btnRashFilterPostupOnObj,
			}, button => button.Down = button.Equals(bt));
		}
		private void ChangePostupCategoryFilterOnSklad(object sender, ItemClickEventArgs e)
		{
			if (!(sender is RibbonBarManager mng)) return;
			var bt = mng.PressedLink.Item;
			var filter = new List<PostupCategory>();
			var categories = new Dictionary<BarItem, PostupCategory>
			{
				[btnRashFilterPostupOnSklad] = PostupCategory.Расходники,
				[btnInventoryFilterPostupOnSklad] = PostupCategory.Инвентарь,
				[btnOsFilterPostupOnSklad] = PostupCategory.ОС
			};
			if (categories.ContainsKey(bt)) filter.Add(categories[bt]);
			pageSklad.CategoryFilter = filter;
			pageSklad.UpdateData();

			EnumerableExtensions.ForEach(new[]
			{
				btNoFilterPostupOnSklad,
				btnInventoryFilterPostupOnSklad,
				btnOsFilterPostupOnSklad,
				btnRashFilterPostupOnSklad,
			}, button => button.Down = button.Equals(bt));
		}
		private void btNewNaklad_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				pageObjects.NewNaklad(false);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}

		private void btnSendNakllinesToNull_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				pageObjects.NewNaklad(true);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}
		private void BtnDeletePostuplenie_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				pagePostup.DeleteSelectedPostup();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}

		private void btnNaklineInProjectToExcel_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				Excel.CreateNaklineInProjects();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}
		private void btDeleteNaklads_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				pageNaklads.DeleteSelectedNaklads();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}
		private void btAddNakladLines_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				pageSklad.AddNakladLines();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}
		private void btNewNakladByNaklad_ItemClick(object sender, ItemClickEventArgs e)
		{
			NewNakladByNaklad(false);
		}
		private void btNakladToNull_ItemClick(object sender, ItemClickEventArgs e)
		{
			NewNakladByNaklad(true);
		}
		private void NewNakladByNaklad(bool isToNull)
		{
			try
			{
				var naklad = pageNaklads.FocusedNaklad;
				var accessService = new NakladAccessService();
				if (!accessService.IsAccess(naklad))
				{
					MessageService.ShowError(accessService.Message);
					return;
				}
				if (isToNull && naklad.Object_ID == 0)
				{
					MessageService.ShowError("Поступления уже списаны.");
					return;
				}
				using (var db = new DbContext())
				{
					var lines = db.Query<CNakladLine>(Properties.Resources.NakladLines,
							new DataParameter("@nakladId", naklad?.ID))
						.ToArray();
					using (var form = new FrmNewNaklad(lines, naklad?.Object_ID, isToNull))
					{
						if (form.ShowDialog(this) == DialogResult.OK)
						{
							UpdateSelectedPage(this, null);
						}
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}

		#endregion //Поступления и накладная

		#region Склад
		private void btUpdateSklads_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				UpdateSklad();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}


		private void btNewNakladOnSklad_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				pageSklad.NewNaklad(false, false);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}

		private void btNakladToNullOnSklad_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				pageSklad.NewNaklad(true, false);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}
		private void btNakladByLine_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				pageSklad.NewNaklad(false, true);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}
		private void btLineToNull_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				pageSklad.NewNaklad(true, true);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}
		#endregion

		#region Авторизация
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
				Logger.Error(ex);
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
				Logger.Error(ex);
			}
		}
		#endregion

		private void btDeveloper_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				var txt = @"//using (var db = new DbContext())
				//{
				//	var postups = db.GetTable<CPostupleniyaDto>().ToArray();
				//	foreach (var postup in postups)
				//	{
				//		if(postup.Nomenkl_ID > 0) continue;
				//		postup.Nomenkl_ID = db.GetOrNew<CNomenklaturaDto>(postup.Nomenkl)?.ID ?? 0;
				//		db.Update(postup);
				//	}

				//	var schetLines = db.GetTable<CSchetLineDto>().ToArray();
				//	foreach (var line in schetLines)
				//	{
				//		if(line.Nomenkl_ID > 0) continue;
				//		line.Nomenkl_ID = db.GetOrNew<CNomenklaturaDto>(line.Nomenklatura)?.ID ?? 0;
				//		db.Update(line);
				//	}
				//}";

				using (var msgBox = new FrmMessage(txt))
				{
					msgBox.ShowDialog(this);
				}



				//using (var db = new DbContext())
				//{
				//	var postups = db.GetTable<CPostupleniyaDto>().ToArray();
				//	foreach (var postup in postups)
				//	{
				//		if(postup.Nomenkl_ID > 0) continue;
				//		postup.Nomenkl_ID = db.GetOrNew<CNomenklaturaDto>(postup.Nomenkl)?.ID ?? 0;
				//		db.Update(postup);
				//	}

				//	var schetLines = db.GetTable<CSchetLineDto>().ToArray();
				//	foreach (var line in schetLines)
				//	{
				//		if(line.Nomenkl_ID > 0) continue;
				//		line.Nomenkl_ID = db.GetOrNew<CNomenklaturaDto>(line.Nomenklatura)?.ID ?? 0;
				//		db.Update(line);
				//	}
				//}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				Logger.Error(ex);
			}
		}
	}
}
