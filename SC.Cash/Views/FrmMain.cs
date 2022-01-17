using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using LinqToDB;
using LinqToDB.Data;
using SC.Cash.Model;
using SC.Cash.Properties;
using SC.Cash.Tools;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using SC.Common.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SC.Cash.Views
{
	public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		private bool _updating;
		private Control _selectedPage;

		public FrmMain()
		{
			try
			{
				_updating = true;

				InitializeComponent();

				pageOperations.Updated += (s, e) => UpdateOperations();
				pageRequests.Updated += (s, e) => UpdateLogin();
#if DEBUG
				Text += $" [DEBUG] {DbContext.DataSource}";
#endif
				lblVersion.Caption = "Версия: " + Application.ProductVersion;
				am.DB.DBManager.Instance.Init(DbContext.GetConnectionString());

				RestoreFormSettings();
				Reload();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void Reload()
		{
			try
			{
				_updating = true;

				ribbon.SelectedPage = ribpOperations;
				ShowPage(pageOperations);
				UpdateLogin();

				_updating = false;

				UpdateOperations();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void UpdateSelectedPage(object sender, EventArgs e)
		{
			try
			{
				if (ribbon.SelectedPage == ribpOperations)
				{
					ShowPage(pageOperations);
					UpdateOperations();
				}
				else if (ribbon.SelectedPage == ribpRequest)
				{
					ShowPage(pageRequests);
					UpdateRequests(sender, null);
				}

				ribpgDateFilter.GetType().GetProperty("Page")? //костыль чтобы вкладка не переключалась при использовании фильтров
					.SetValue(ribpgDateFilter, ribbon.SelectedPage);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void ShowPage(Control page)
		{
			try
			{
				Control[] pages = { pageOperations, pageRequests };
				pages.ForEach(p => p.Visible = p == page);
				if (page != null)
				{
					_selectedPage = page;
					page.Dock = DockStyle.Fill;
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void UpdateOperations()
		{
			if (_updating) return;
			try
			{
				var (start, end) = DateService.UpdateStartEnd(btnsIntervalMode, deMonth, deStart, deEnd);
				var isMonth = (bool)(btnsIntervalMode?.EditValue ?? false);
				btIsDebtMonth.Enabled = isMonth;
				var isDebtTotal = btIsDebtTotal.Down;
				var isDebtCalculated = btIsDebtCalculated.Down;
				pageOperations.UpdateData(start, end, isMonth, isDebtTotal, isDebtCalculated);

				UpdateOperationsCash();
				UpdateLogin();

				riDateEditStart.MaxValue = end.AddDays(-1);
				riDateEditEnd.MinValue = start;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void UpdateOperationsCash()
		{
			try
			{
				var user = ApplicationUser.User;
				if (user?.Role == Role.Director)
				{
					ribpgOperationsCash.Visible = true;
					using (var db = new DbContext())
					{
						var ops = db.GetWhere<COperationCashDto>(o => o.Status == OperationCashStatus.Wait);
						lbOperationCashCount.Caption = $"Операций: {ops.Length}";
						lbOperationCashSum.Caption = $"На сумму: {ops.Sum(o => o.Amount):c2}";
						btOperationsCash.Enabled = ops.Any();
					}
				}
				else
				{
					ribpgOperationsCash.Visible =
					btOperationsCash.Enabled = false;
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btnUpdateOperations_ItemClick(object sender, ItemClickEventArgs e)
		{
			UpdateOperations();
		}

		private void btnCreateRequest_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var form = new FrmNewRequest())
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						UpdateRequests(this, e);
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void UpdateRequests(object sender, ItemClickEventArgs e)
		{
			if (_updating) return;
			try
			{
				var user = ApplicationUser.User;

				var statuses = new List<RequestStatus> { RequestStatus.Wait };
				if (chbInRequestAgreed.Checked) statuses.Add(RequestStatus.Agreed);
				if (chbInRequestRejected.Checked) statuses.Add(RequestStatus.Rejected);
				if (chbInRequestPaid.Checked) statuses.Add(RequestStatus.Paid);

				var (start, end) = DateService.UpdateStartEnd(btnsIntervalMode, deMonth, deStart, deEnd);

				pageRequests.UpdateData(start, end, statuses);
				UpdateLogin();

				using (var db = new DbContext())
				{
					var rest = CAccountDto.GetOrCreate(user?.ID)?.Rest;
					lbRest.Caption = $"Ваш баланс: {rest ?? 0:c2}";

					var userId = user?.ID ?? -1;
					var request = db.GetTable<CRequestOpDto>()
						.Where(r => r.User_ID == userId)
						.OrderBy(r => r.DateTime)
						.FirstOrDefault();

					if (request != null)
					{
						lbLastRequestAmount.Caption = $"Сумма: {request.Amount:c2}";
						lbLastRequestDate.Caption = $"Дата: {request.DateTime:d}";
						lbLastRequestStatus.Caption = $"Статус: {request.Status.DisplayName()}";
					}
					else
					{
						request = new CRequestOp();
					}

					lbLastRequestStatus.ImageOptions.Image =
						request.Status == RequestStatus.Rejected ? Resources.Rejected
						: request.Status == RequestStatus.Agreed ? Resources.Ok
						: request.Status == RequestStatus.Paid ? Resources.Money
						: Resources.Clock;
					ribpgOutRequest.Visible = request.Status > 0;
					btnCreateRequest.Enabled = request.Status != RequestStatus.Wait;
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void UpdateLogin()
		{
			try
			{
				var user = ApplicationUser.User;
				Modules activeModules = new AccessModules(user);
				var isLogin = activeModules.HasFlag(Modules.Cash);

				btnLogin.Visibility = isLogin ? BarItemVisibility.Never : BarItemVisibility.Always;
				btnLogout.Visibility = !isLogin ? BarItemVisibility.Never : BarItemVisibility.Always;
				ribbon.Enabled = isLogin;

				if (!isLogin)
				{
					ShowPage(null);
					lbUserProfile.Caption = "Вход не выполнен";
					if (user != null)
					{
						MessageService.ShowError("Нарушение прав доступа");
						ApplicationUser.User = null;
					}
					return;
				}

				using (var db = new DbContext())
				{
					lbUserProfile.Caption = $"Пользователь: {user.Login.Trim()} / {user.Name.Trim()} / {user.RoleName.Trim()}";

					var waitRequestCount = db.Query<CRequestOp>(
							Resources.Requests_In,
							new DataParameter("@userId", user.ID))
						.Count(r => r.Status == RequestStatus.Wait);

					ribpRequest.Text = $"Запросы ({waitRequestCount})";
				}
				ShowPage(_selectedPage);

				btnCreateRequest.Visibility = user.Role == Role.Rukovod ? BarItemVisibility.Always : BarItemVisibility.Never;

				ribpgOperations.Visible =
				ribpgAccaunts.Visible = user.Role == Role.Admin ||
										user.Role == Role.Director ||
										user.Role == Role.Rukovod;
				btRecalculateAllRest.Visibility =
				btRecalculateAllResOps.Visibility = user.Role == Role.Admin ? BarItemVisibility.Always : BarItemVisibility.Never;

				ribpgOutRequest.Visible = user.Role == Role.Rukovod;
				btAddPassiveAccaunt.Visibility = user.Role == Role.Director ? BarItemVisibility.Always : BarItemVisibility.Never;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				var user = CUser.GetAutoLoginPass();
				using (var form = new FrmLogin(user))
				{
					if (form.ShowDialog() == DialogResult.OK)
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
		private void btnLogOut_ItemClick(object sender, ItemClickEventArgs e)
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

		private void btnRequestsToExcel_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var excel = new ExcelService(this))
				{
					excel.GridToExcel(pageRequests.ToExcel)
						.SetAutoFit();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btOperationsCash_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var form = new FrmCash())
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						UpdateOperations();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btCashToExcel_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				var (start, end) = DateService.UpdateStartEnd(btnsIntervalMode,
					deMonth, deStart, deEnd);
				using (var db = new DbContext())
				{
					var ops = db.Query<COperationCash>(
							Resources.OperationsCash)
							.Where(op => op.Status == OperationCashStatus.Completed)
							.Where(op => op.DataCreate.Date >= start)
							.Where(op => op.DataCreate.Date <= end)
							.ToArray();
					if (ops.Any())
					{
						new Excel().Cash(ops);
					}
					else
					{
						MessageService.ShowMessage("За выбранный период нет ни одного рассмотренного кэша");
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btSpecOperation_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (!(pageOperations.FocusedAccount is CAccount acc)) return;
				var (start, end) = DateService.UpdateStartEnd(btnsIntervalMode,
					deMonth, deStart, deEnd);
				var ops = COperation.Factory(acc.ID, start, end)
						.Where(o => o.From_ID == acc.ID)
						.Where(o => o.To_ID == null)
						.Where(o => o.ToResOP_ID == null)
						.ToArray();
				if (ops.Any())
				{
					using (var form = new FrmAmountOutNoToUser(acc.UserName, start, end, ops))
					{
						form.ShowDialog(this);
					}
				}
				else
				{
					MessageService.ShowMessage("Для выбранного счёта в выбранный период операций без получателя нет.");
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
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

		private void btnNotes_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var form = new FrmNotes(Modules.Cash))
				{
					form.ShowDialog(this);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btDebts_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var form = new FrmDebt())
				{
					form.ShowDialog(this);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btSalary_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var form = new FrmSalary())
				{
					form.ShowDialog(this);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btAddPassiveAccaunt_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var form = new FrmEditAccaunt())
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						UpdateOperations();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btCloseAccaunt_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (!(pageOperations.FocusedAccount is CAccount acc)) return;
				var question = $"Счёт {acc.UserName} будет закрыт.\nПродолжить?";
				if (MessageService.ShowQuestion(question) != DialogResult.Yes) return;
				using (var db = new DbContext())
				{
					db.GetTable<CAccountDto>()
						.Where(a => a.ID == acc.ID)
						.Set(a => a.Status, CAccountDto.AccStatus.Close)
						.Update();
					UpdateOperations();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btRecalculateAllRest_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var db = new DbContext())
				{
					var accs = db.GetTable<CAccountDto>().ToArray();
					var error = "";
					for (int i = 0; i < accs.Length; i++)
					{
						CRestDayDto.Recalculate(new DateTime(2019, 01, 01), accs[i].ID, ref error);
						TaskbarProgress.SetValue(i, accs.Length);
					}
					if (error.NoEmpty()) MessageService.ShowError(error);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
			finally
			{
				TaskbarProgress.Finish();
			}
		}

		private void DebtFilterChange(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (e.Item == btIsDebtTotal || e.Item == btIsDebtMonth)
				{
					btIsDebtTotal.Down = e.Item == btIsDebtTotal;
					btIsDebtMonth.Down = e.Item == btIsDebtMonth;
				}
				if (e.Item == btIsDebtCalculated || e.Item == btIsDebtFact)
				{
					btIsDebtCalculated.Down = e.Item == btIsDebtCalculated;
					btIsDebtFact.Down = e.Item == btIsDebtFact;
				}
				UpdateOperations();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btRecalculateAllResOps_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				var changedCount = COperationDto.UpdateAllResOp();
				MessageService.ShowMessage($"Внесено изменений: {changedCount}");
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btVipiska_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				pageOperations.ExportVipiska();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}