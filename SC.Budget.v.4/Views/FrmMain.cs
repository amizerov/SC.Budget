using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using LinqToDB.Data;
using SC.Budget.Model;
using SC.Budget.Properties;
using SC.Budget.Tools;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using SC.Common.Views;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSchet = SC.Budget.Model.CSchet;

namespace SC.Budget.Views
{
	public partial class FrmMain : RibbonForm
	{
		private readonly bool _loading;
		public FrmMain()
		{
			try
			{
				InitializeComponent();

				LayoutSaver.Restore(this);

				lblVersion.Caption = "Версия: " + Application.ProductVersion;
#if DEBUG
				Text += $" [DEBUG] {DbContext.DataSource}";
#endif
				_loading = true;
				deMonth.EditValue = DateTime.Now;
				deEditableDate.EditValue = AppSettings.EditableDate;
				deReportYear.EditValue = DateTime.Now;
				_loading = false;

				UpdateLogin();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
		{
			var user = CUser.GetAutoLoginPass();
			using (var form = new FrmLogin(user))
			{
				if (form.ShowDialog() == DialogResult.OK)
				{
					UpdateLogin();
				}
			}
		}
		private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
		{
			var question = "Вы действительно хотите выйти из профиля?";
			if (MessageService.ShowQuestion(question) == DialogResult.Yes)
			{
				ApplicationUser.User = null;
				UpdateLogin();
				btnLogin_ItemClick(this, e);
			}
		}
		private void UpdateLogin()
		{
			var user = ApplicationUser.User;
			lbUserProfile.Caption = user == null ? "Вход не выполнен"
				: $"Пользователь: {user.Login?.Trim()} / {user.Name?.Trim()} / {user.RoleName?.Trim()}";

			btnLogin.Visibility = user == null ? BarItemVisibility.Always : BarItemVisibility.Never;
			btnLogout.Visibility = user != null ? BarItemVisibility.Always : BarItemVisibility.Never;

			Modules activeModules = new AccessModules(user);
			ribpgReports.Visible = activeModules.HasFlag(Modules.Cash);
			rpgAdmin.Visible = user?.Role == Role.Admin;

			UpdateModules();
		}

		private void editMonth_EditValueChanged(object sender, EventArgs e)
		{
			if (_loading) return;
			UpdateModules();
		}

		private void deEditableDate_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (!(deEditableDate.EditValue is DateTime date)) return;
				AppSettings.EditableDate = date;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private async void btMarginalityAllProjects_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				await Task.Factory.StartNew(
					() => new Excel().CreateMarginalityAllProjects(((DateTime)deReportYear.EditValue).Year));
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private async void btMarginalityObject_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var dialog = new FrmSelectObj( ))
				{
					dialog.PnFilter.Visible = false;
					if (dialog.ShowDialog(this) != DialogResult.OK) return;

					await Task.Factory.StartNew(
						() => new Excel().CreateMarginalityObject(((DateTime)deReportYear.EditValue).Year, dialog.Object_ID));
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private async void btKPI_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var dialog = new FrmSelectProject())
				{
					if (dialog.ShowDialog(this) != DialogResult.OK) return;

					await Task.Factory.StartNew(
						() => new Excel().CreateKPI(dialog.Project, ((DateTime)deReportYear.EditValue).Year));
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void UpdateModules()
		{
			try
			{
				var page = tcDescr.SelectedTabPage;

				UpdateObjects();
				UpdateCash();
				UpdateProda();
				UpdateZakup();
				UpdateTabel();

				tcDescr.SelectedTabPage = page != null && page.PageVisible ? page
					: tcDescr.TabPages.FirstOrDefault(p => p.PageVisible);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void UpdateObjects()
		{
			var user = ApplicationUser.User;
			Modules activeModules = new AccessModules(user);

			btObjects.Visible =
			btnGotoObjects.Visible =
			tpObjects.PageVisible = activeModules.HasFlag(Modules.Objects);
			if (activeModules.HasFlag(Modules.Objects))
			{
				using (var db = new DbContext())
				{
					var userId = user.Role == Role.Rukovod ? user.ID : 0;

					var postup = db.Query<CSchet>(Resources.Scheta,
							new DataParameter("@userId", userId),
							new DataParameter("@month", deMonth.EditValue))
						.ToArray();

					var sсhets = db.Query<CSchet>(Resources.SchetaProda,
							new DataParameter("@userId", userId),
							new DataParameter("@month", deMonth.EditValue))
						.ToArray();

					var resOps = db.Query<CResOP>(Resources.ResOPsForRukovod,
							new DataParameter("@userId", userId),
							new DataParameter("@month", deMonth.EditValue))
						.ToArray();

					var projects = db.Query<CProject>(Resources.Projects,
							new DataParameter("@userId", userId))
						.ToArray();

					var projectsVm = projects.Select(p => new CObject
					{
						Name = p.Name,
						Income = sсhets.Where(s => s.ProjectName == p.Name).Sum(s => s.Oplata),
						Salary = resOps.Where(r => r.ObjectName == p.Name).Sum(r => r.TotalCalculated),
						Postup = postup.Where(r => r.ProjectName == p.Name).Sum(r => r.Oplata),
					}).ToArray();

					cObjectBindingSource.DataSource = projectsVm;

					lbObjectDescr1.Text = $"Количество проектов: {projects.Length}";

					var projectsId = projects.Select(p => p.ID);
					var objects = db.GetTable<CObjectDto>()
						.Where(o => projectsId.Contains(o.Project_ID))
						.Where(o => o.Status == 0 && !o.IsDeleted)
						.ToArray();
					lbObjectDescr1.Text += $"\nКоличество объектов: {objects.Length}";

					if (user.Role == Role.Admin || user.Role == Role.Director)
					{
						var rukCount = projects
							.Select(p => p.Rukovod_ID)
							.Distinct()
							.Count();
						lbObjectDescr1.Text += $"\nКоличество руководителей проекта: {rukCount}";
					}
					var managerCount = objects
						.Select(p => p.Manager_ID)
						.Distinct()
						.Count();
					lbObjectDescr1.Text += $"\nКоличество менеджеров: {managerCount}";

					var scheta = db.GetTable<CSchetDto>()
						.Where(s => projectsId.Contains(s.Project_ID ?? -1))
						.Where(s => !s.IsDeleted)
						.Where(s => s.Oplata < s.Summa)
						.ToArray();
					lbObjectDescr2.Text = $"Количество неоплаченных счетов: {scheta.Length}\n" +
										  $"На общую сумму: {scheta.Sum(s => s.Summa - s.Oplata):c2}";
				}
			}
			else
			{
				cObjectBindingSource.DataSource = Array.Empty<CObject>();
			}
		}
		private void UpdateCash()
		{
			var user = ApplicationUser.User;
			Modules activeModules = new AccessModules(user);

			btCash.Visible =
			btnGotoCash.Visible =
			tpCash.PageVisible = activeModules.HasFlag(Modules.Cash);
			if (activeModules.HasFlag(Modules.Cash))
			{
				using (var db = new DbContext())
				{
					var acc = CAccountDto.GetOrCreate(user.ID);
					if (acc == null) return;

					var startWeek = DateTime.Now.AddDays(-7);
					var opsWeek = COperation.Factory(acc.ID, startWeek, DateTime.Now);

					var lastRestDay = CRestDayDto.LastRestDay(startWeek, acc.ID);

					lbCashDescr.Text = "За последнюю неделю:\n" +
									   $"Входящий остаток {lastRestDay?.Rest_In ?? 0:c2}\n" +
									   $"Приход {opsWeek.Sum(o => o.InAmount):c2}\n" +
									   $"Расход {opsWeek.Sum(o => o.OutAmount):c2}\n" +
									   $"Исходящий остаток {acc.Rest:c2}\n\n";
					var requests = db.GetTable<CRequestOpDto>().Where(r => r.User_ID == user.ID).ToArray();
					lbCashDescr.Text += $"Количество запросов на рассмотрении: {requests.Length}\n" +
										$"На общую сумму: {requests.Sum(r => r.Amount):c2}";

					var month = (DateTime)deMonth.EditValue;
					var start = new DateTime(month.Year, month.Month, 1);
					var end = start.AddMonths(1);
					var opsChart = db.Query<COperation>(Resources.Operations,
						new DataParameter("@accId", acc.ID),
						new DataParameter("@start", start),
						new DataParameter("@end", end))
						.ToArray();
					cOperationBindingSource.DataSource = opsChart;
				}
			}
			else
			{
				cOperationBindingSource.DataSource = Array.Empty<COperation>();
			}
		}
		private void UpdateZakup()
		{
			var user = ApplicationUser.User;
			Modules activeModules = new AccessModules(user);

			btZakup.Visible =
			btnGotoZakup.Visible =
			tpZakup.PageVisible = activeModules.HasFlag(Modules.Zakup);
			if (activeModules.HasFlag(Modules.Zakup))
			{
				using (var db = new DbContext())
				{
					var userId = user.Role == Role.Rukovod ? user.ID : 0;
					var month = (DateTime)deMonth.EditValue;
					var postup = db.Query<CSchet>(Resources.Scheta,
							new DataParameter("@userId", userId),
							new DataParameter("@month", month))
						.Where(s => !s.IsCash)
						.ToArray();

					lbZakupDescr.Text = $"Счетов за {month:MMMM}: {postup.Length}\n" +
										$"На общую сумму: {postup.Sum(s => s.Summa):c2}\n" +
										$"Оплачено: {postup.Sum(s => s.Oplata):c2}\n" +
										$"Не оплачено: {postup.Sum(s => s.Summa - s.Oplata):c2}";

					cSchetBindingSource.DataSource = postup;
				}
			}
			else
			{
				cSchetBindingSource.DataSource = Array.Empty<CSchet>();
			}
		}
		private void UpdateProda()
		{
			var user = ApplicationUser.User;
			Modules activeModules = new AccessModules(user);

			btProda.Visible =
			btnGotoProda.Visible =
			tpProda.PageVisible = activeModules.HasFlag(Modules.Proda);
			if (activeModules.HasFlag(Modules.Proda))
			{
				using (var db = new DbContext())
				{
					var userId = user.Role == Role.Rukovod ? user.ID : 0;
					var month = (DateTime)deMonth.EditValue;
					var sсhets = db.Query<CSchet>(Resources.SchetaProda,
							new DataParameter("@userId", userId),
							new DataParameter("@month", month))
						.ToArray();

					lbProdaDescr.Text = $"Счетов за {month:MMMM}: {sсhets.Length}\n" +
										$"На общую сумму: {sсhets.Sum(s => s.Summa):c2}\n" +
										$"Оплачено: {sсhets.Sum(s => s.Oplata):c2}\n" +
										$"Не оплачено: {sсhets.Sum(s => s.Summa - s.Oplata):c2}";

					cSchetProdaBindingSource.DataSource = sсhets;
				}
			}
			else
			{
				cSchetProdaBindingSource.DataSource = Array.Empty<CSchet>();
			}
		}
		private void UpdateTabel()
		{
			var user = ApplicationUser.User;
			Modules activeModules = new AccessModules(user);

			btTabel.Visible =
			btnGotoTabel.Visible =
			tpTabel.PageVisible = activeModules.HasFlag(Modules.Tabel);
			if (activeModules.HasFlag(Modules.Tabel))
			{
				using (var db = new DbContext())
				{
					var sql = user.Role == Role.Manager
						? Resources.ResOPsForManager
						: Resources.ResOPsForRukovod;
					var userId = user.Role == Role.Manager || user.Role == Role.Rukovod ? user.ID : 0;
					var month = (DateTime)deMonth.EditValue;
					var resOps = db.Query<CResOP>(sql,
							new DataParameter("@userId", userId),
							new DataParameter("@month", month))
						.ToArray();
					var resources = db.Query<CResuorce>(Resources.Resources_,
							new DataParameter("@userId", user.ID),
							new DataParameter("@month", month))
						.ToArray();

					lbTabelDescr1.Text = $"Сотрудников: {resources.Count(r => r.User_ID == null)}";
					if (user.Role == Role.Admin || user.Role == Role.Director)
					{
						lbTabelDescr1.Text += $"\nРуководителей проекта: {resources.Count(r => r.Role == Role.Rukovod)}";
					}
					if (user.Role == Role.Admin || user.Role == Role.Director || user.Role == Role.Rukovod)
					{
						lbTabelDescr1.Text += $"\nМенеджеров: {resources.Count(r => r.Role == Role.Manager)}";
					}
					if (user.Role == Role.Manager)
					{
						var objs = db.Query<CObjectDto>(@"select * from Object
								where Manager_ID = @userId	and Status = 0",
								new DataParameter("@userId", userId))
							.ToArray();
						lbTabelDescr1.Text += $"\nОбъектов: {objs.Count()}";
					}
					lbTabelDescr2.Text = $"Всего за {month:MMMM}:\n" +
										 $"Начислено: {resOps.Sum(r => r.Calculated):c2}\n" +
										 $"Авансов: {resOps.Sum(r => r.Avans):c2}\n" +
										 $"Выплачено: {resOps.Sum(r => r.Paid):c2}\n" +
										 $"Долг: {resOps.Sum(r => r.Debt):c2}";

					cResOPBindingSource.DataSource = resOps;
				}
			}
			else
			{
				cResOPBindingSource.DataSource = Array.Empty<CResOP>();
			}
		}

		private void btnGotoObjects_Click(object sender, EventArgs e) => Goto("SC.Object", "SC.Object.exe");
		private void btnGotoCash_Click(object sender, EventArgs e) => Goto("SC.Cash", "SC.Cash.exe");
		private void btnGotoProda_Click(object sender, EventArgs e) => Goto("SC.Proda", "SC.Proda.v.3.exe");
		private void btnGotoZakup_Click(object sender, EventArgs e) => Goto("SC.Zakup", "SC.Zakup.v.4.exe");
		private void btnGotoTabel_Click(object sender, EventArgs e) => Goto("SC.Tabel", "SC.Tabel.exe");
		private void Goto(string folderName, string appName)
		{
			var path = "";
			try
			{
#if DEBUG
				//var descr = "Откорректирован алгоритм загрузки из 1С\nУлучшено всё";
				//var v1 = new CVersionHistory
				//{
				//	Version = "3.0.1.2",
				//	Description = descr
				//};
				//var v2 = new CVersionHistory
				//{
				//	Serious = CVersionHistory.VersionSerious.Serious,
				//	Version = "3.0.1.3",
				//	Description = descr
				//};
				//var v3 = new CVersionHistory
				//{
				//	Serious = CVersionHistory.VersionSerious.Critical,
				//	Version = "3.0.1.3",
				//	Description = descr
				//};

				//using (var form = new FrmUpdateApp(new[]
				//{
				//	v1, v2, v3,
				//	v1, v2, v3,
				//	v1, v2, v3,
				//	v1, v2, v3,
				//}))
				//{
				//	form.ShowDialog(this);
				//}
				//throw new ArgumentOutOfRangeException("index");//Проверка ReportBug
#endif
				var user = ApplicationUser.User;
				var basePath = AppDomain.CurrentDomain.BaseDirectory;
				var parentDir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(basePath)));
				path = Path.Combine(parentDir, folderName, "Release", appName);
				Process.Start(path, user.ID.ToString());
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btObjects_Click(object sender, EventArgs e) => tcDescr.SelectedTabPage = tpObjects;
		private void btCash_Click(object sender, EventArgs e) => tcDescr.SelectedTabPage = tpCash;
		private void btProda_Click(object sender, EventArgs e) => tcDescr.SelectedTabPage = tpProda;
		private void btZakup_Click(object sender, EventArgs e) => tcDescr.SelectedTabPage = tpZakup;
		private void btTabel_Click(object sender, EventArgs e) => tcDescr.SelectedTabPage = tpTabel;

		private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				LayoutSaver.Save(this);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}
