using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;
using SC.Budget.Model;
using SC.Budget.Properties;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.IO;
using System.Linq;
using Xls = Microsoft.Office.Interop.Excel;

namespace SC.Budget.Tools
{
	public class Excel
	{
		private readonly DetailClassService _classService = new DetailClassService();

		public void CreateMarginalityAllProjects(int year)
		{
			TaskbarProgress.Start();
			var app = new Xls.Application();
			var exlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "Маржинальность.xltx");
			var wbk = app.Workbooks.Add(exlFile);
			try
			{
				var sht = (Xls.Worksheet)wbk.Worksheets[1];
				var start = 5;

				using (var db = new DbContext())
				{
					#region Подготовка файла
					var user = ApplicationUser.User;
					var userId = user.Role == Role.Rukovod ? user.ID : 0;
					var projects = db.Query<CProject>(Resources.Projects,
							new DataParameter("@userId", userId))
						.ToArray();
					var progress = 0;
					var progressMax = projects.Length * 12 + 1;
					for (int i = 0; i < projects.Length; i++)
					{
						sht.Rows[start + i + 1].Insert();
					}
					sht.Rows[start + projects.Length].Delete();
					sht.Rows[start + projects.Length].Delete();
					for (int month = 1; month < 12; month++)
					{
						wbk.Worksheets[month].Copy(After: wbk.Worksheets[month]);
					}
					TaskbarProgress.SetValue(progress++, progressMax);
					#endregion

					for (int monthIndex = 1; monthIndex <= 12; monthIndex++)
					{
						#region Подготовка листа
						var month = new DateTime(year, monthIndex, 1);
						wbk.Worksheets[monthIndex].Name = month.ToString("MMMM");
						sht = wbk.Worksheets[monthIndex];

						var classes = db.Query<DetailClass>(Resources.SchetsCategoriesForMarginality,
								new DataParameter("@userId", userId),
								new DataParameter("@month", month))
							.OrderBy(c => _classService.Order(c))
							.ToArray();
						for (int catIndex = 1; catIndex < classes.Length; catIndex++)
						{
							((Xls.Range)sht.Columns["E:G"]).Copy();
							((Xls.Range)sht.Columns["H:H"]).Insert();
						}
						for (int catIndex = 0; catIndex < classes.Length; catIndex++)
						{
							var category = classes[catIndex];
							((Xls.Range)sht.Cells[start - 2, 5 + catIndex * 3]).Value2 = $"Расходы '{category}'";
							for (int r = start - 2; r < start + projects.Length; r++)
							{
								for (int c = 5 + catIndex * 3; c <= 5 + catIndex * 3 + 2; c++)
								{
									((Xls.Range)sht.Cells[r, c]).Interior.ColorIndex = _classService.Color(category); //выбираем цвет из палитры Excel
								}
							}
						}
						#endregion
						var sql = $"GetResOPForRukovod {userId}, N'{month:yyyyMMdd}'";
						var resOps = db.Query<ResOPViewModel>(sql)
							.Where(r => r.Type == ObjType.Project)
							.ToArray();
						for (int projIndex = 0; projIndex < projects.Length; projIndex++)
						{
							var col = 1;
							void Set(object value) => ((Xls.Range)sht.Cells[start + projIndex, col++]).Value2 = value;
							var pr = projects[projIndex];

							Set(pr.Name);

							#region Выставленные счета
							var sсhetsProda = db.GetTable<CSchetProdaDto>()
								.Where(s => s.Project_ID == pr.ID)
								.Where(s => s.DataCreate.Month == month.Month)
								.Where(s => s.DataCreate.Year == month.Year)
								.Where(s => !s.IsDeleted)
								.ToArray();

							Set(sсhetsProda.Sum(s => s.Summa));
							Set(sсhetsProda.Sum(s => s.Oplata));
							Set(sсhetsProda.Sum(s => s.Summa - s.Oplata));
							#endregion

							#region Расходы
							var sсhets = db.Query<SchetMarginality>(Resources.SchetsForMarginality,
									new DataParameter("@projectId", pr.ID),
									new DataParameter("@month", month))
								.ToArray();

							for (int catIndex = 0; catIndex < classes.Length; catIndex++)
							{
								var ss = sсhets.Where(s => s.Class == classes[catIndex]).ToArray();

								Set(ss.Sum(s => s.Summa));
								Set(ss.Sum(s => s.Oplata));
								Set(ss.Sum(s => s.Summa - s.Oplata));
							}
							#endregion

							#region Зарплата
							var resOp = resOps.FirstOrDefault(r => r.Project_ID == pr.ID);

							if (resOp != null)
							{
								Set(resOp.Calculated);
								Set(resOp.Avans + resOp.Paid);
								Set(resOp.Debt);
							}
							#endregion

							TaskbarProgress.SetValue(progress++, progressMax);
						}
					}
					sht.Columns.AutoFit();
				}
				app.Visible = true;
				TaskbarProgress.Finish();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, null);
				wbk.Close(false);
				app.Quit();
				GC.Collect();
			}
		}

		private class MarginalityObject
		{
			[Column] public decimal Expense { get; set; }
			[Column] public decimal Income { get; set; }
		}
		public void CreateMarginalityObject(int year, int objectId)
		{
			var app = new Xls.Application();
			var exlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "Маржинальность объекта_.xltx");
			var wbk = app.Workbooks.Add(exlFile);
			try
			{
				var sht = (Xls.Worksheet)wbk.Worksheets[1];
				using (var db = new DbContext())
				{
					var obj = db.GetByID<CObjectDto>(objectId);
					var res = db.Query<MarginalityObject>(Resources.MarginalityObject,
							new DataParameter("@object_ID", obj.ID),
							new DataParameter("@year", year))
						.ToArray();

					((Xls.Range)sht.Cells[1, 1]).Value2 = $"Маржинальность объекта {obj.Address}";
					var start = 3;
					for (int i = 0; i < 12; i++)
					{
						var col = 3;
						((Xls.Range)sht.Cells[start + i, col++]).Value2 = obj.Address;
						((Xls.Range)sht.Cells[start + i, col++]).Value2 = obj.Budget;
						((Xls.Range)sht.Cells[start + i, col++]).Value2 = res[i].Income;
						((Xls.Range)sht.Cells[start + i, col++]).Value2 = res[i].Expense;
					}
					sht.Columns.AutoFit();
				}
				app.Visible = true;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, null);
				wbk.Close(false);
				app.Quit();
				GC.Collect();
			}
		}

		public void CreateKPI(CProject project, int year)
		{
			var app = new Xls.Application();
			var exlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "KPI_.xltx");
			var wbk = app.Workbooks.Add(exlFile);
			TaskbarProgress.Start();
			try
			{
				var sht = (Xls.Worksheet)wbk.Sheets[1];
				var col = 5;
				var progress = 0;
				var progressMax = 13;

				using (var db = new DbContext())
				{
					sht.Range["ProjectName"].Value2 = sht.Name = project.Name;

					#region Подготовка листа
					var classes = db.Query<DetailClass>(Resources.SchetsCategoriesForKPI,
							new DataParameter("@projectId", project.ID),
							new DataParameter("@year", year))
						.OrderByDescending(c => c)
						.ToArray();

					var startScheta = 20;
					for (int i = 0; i < classes.Length; i++)
					{
						sht.Rows[startScheta + i + 1].Insert();
						((Xls.Range)sht.Cells[startScheta + i, 3]).Value2 = $"Расходы '{classes[i]}'";
					}
					sht.Rows[startScheta + classes.Length].Delete();
					#endregion

					TaskbarProgress.SetValue(progress++, progressMax);

					for (int month = 1; month <= 12; month++)
					{
						var resOps = db.Query<ResOPForKPI>(Resources.ResOPsForKPI,
							new DataParameter("@project_ID", project.ID),
							new DataParameter("@month", new DateTime(year, month, 1)))
							.ToArray();

						var row = 9;

						#region Кол-во сотрудников
						((Xls.Range)sht.Cells[row++, col]).Value2 = resOps
											.Where(r => r.Role_ID == Role.Manager)
											.Select(r => r.Resource_ID)
											.Distinct()
											.Count();

						((Xls.Range)sht.Cells[row++, col]).Value2 = resOps
							.Where(r => r.User_ID == null)
							.Select(r => r.Resource_ID)
							.Distinct()
							.Count();
						#endregion

						#region Доходы
						var schetaProda = db.GetTable<CSchetProdaDto>()
							.Where(s => s.Project_ID == project.ID)
							.Where(s => s.DataCreate.Year == year)
							.Where(s => s.DataCreate.Month == month)
							.Where(s => !s.IsDeleted)
							.ToArray();

						((Xls.Range)sht.Cells[row++, col]).Value2 = schetaProda.Sum(s => s.Summa);
						#endregion

						row++;

						#region Зарплата
						((Xls.Range)sht.Cells[row++, col]).Value2 = resOps
							.Where(r => r.Role_ID == Role.Rukovod)
							.Sum(r => r.FactSalary);
						((Xls.Range)sht.Cells[row++, col]).Value2 = resOps
							.Where(r => r.Role_ID == Role.Rukovod)
							.Sum(r => r.OfficialSalary);

						((Xls.Range)sht.Cells[row++, col]).Value2 = resOps
							.Where(r => r.Role_ID == Role.Manager)
							.Sum(r => r.FactSalary);
						((Xls.Range)sht.Cells[row++, col]).Value2 = resOps
							.Where(r => r.Role_ID == Role.Manager)
							.Sum(r => r.OfficialSalary);

						((Xls.Range)sht.Cells[row++, col]).Value2 = resOps
							.Where(r => r.User_ID == null)
							.Sum(r => r.FactSalary);
						((Xls.Range)sht.Cells[row++, col]).Value2 = resOps
							.Where(r => r.User_ID == null)
							.Sum(r => r.OfficialSalary);
						
						row++;
						#endregion

						#region Расходы
						var sсhets = db.Query<SchetMarginality>(Resources.SchetsForMarginality,
								new DataParameter("@projectId", project.ID),
								new DataParameter("@month", new DateTime(year, month, 1)))
							.ToArray();

						for (int i = 0; i < classes.Length; i++)
						{
							((Xls.Range)sht.Cells[row++, col]).Value2 = sсhets
								.Where(s => s.Class == classes[i])
								.Sum(s => s.Summa);
						}
						#endregion

						col += month % 3 == 0 ? 2 : 1; //прибавляем 1 или 2 (если квартал) к номеру столбца  
						TaskbarProgress.SetValue(progress++, progressMax);
					}
					sht.Columns.AutoFit();
				}
				app.Visible = true;
				TaskbarProgress.Finish();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, null);
				wbk.Close(false);
				app.Quit();
				GC.Collect();
			}
		}
	}
}
