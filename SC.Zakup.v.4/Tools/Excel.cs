using am.BL;
using SC.Zakup.Models;
using SC.Zakup.Views;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using LinqToDB;
using SC.Common.Dal;
using CNakladnaya = SC.Zakup.Models.CNakladnaya;
using Xls = Microsoft.Office.Interop.Excel;
using System.Linq;

namespace SC.Zakup.Tools
{
	public class Excel
	{
		public static string Error = "";
		public static string Otchet = "";
		public static bool LoadScheta(string fileToLoadFrom, out int cntLoaded)
		{
			string datc, nome, supp, proj, summ, opla, ship, orga, opdo, deta, comm, pena;

			Xls.Application app = new Xls.Application();
			Xls.Workbook wbk = app.Workbooks.Open(fileToLoadFrom,
				Type.Missing, true, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing);
			Xls.Worksheet sht = (Xls.Worksheet)wbk.Sheets[1];

			cntLoaded = 0;
			for (int i = 1; i < 999; i++)
			{
				datc = ((Xls.Range)sht.Cells[i, 1]).Value2 + "";
				nome = ((Xls.Range)sht.Cells[i, 2]).Value2 + "";
				supp = ((Xls.Range)sht.Cells[i, 3]).Value2 + "";
				proj = ((Xls.Range)sht.Cells[i, 4]).Value2 + "";
				summ = ((Xls.Range)sht.Cells[i, 5]).Value2 + "";
				pena = ((Xls.Range)sht.Cells[i, 6]).Value2 + "";
				opdo = ((Xls.Range)sht.Cells[i, 7]).Value2 + "";
				opla = ((Xls.Range)sht.Cells[i, 8]).Value2 + "";
				ship = ((Xls.Range)sht.Cells[i, 9]).Value2 + "";
				orga = ((Xls.Range)sht.Cells[i, 10]).Value2 + "";
				deta = ((Xls.Range)sht.Cells[i, 11]).Value2 + "";
				comm = ((Xls.Range)sht.Cells[i, 12]).Value2 + "";

				if (datc + nome + summ == "") break;

				if (i == 1)
				{
					if (!(datc == "Дата" && nome == "Номер" && supp == "Поставщик"
					   && proj == "Проект" && summ == "Сумма" && opla == "Оплата" && ship == "Отгрузка"
					   && orga == "Организация" && opdo == "Срок оплаты" && deta == "Детализация"))
					{
						Error = "Не правильный формат файла для загрузки";
						break;
					}
				}
				else
				{
					var a = datc.Split('.');
					if (a.Length == 1)
						datc = DateTime.FromOADate(double.Parse(datc)).ToString("yyyyMMdd");
					else
						datc = a[2] + "-" + a[1] + "-" + a[0];

					var b = opdo.Split('.');
					if (b.Length == 1)
						opdo = DateTime.FromOADate(double.Parse(opdo)).ToString("yyyyMMdd");
					else
						opdo = b[2] + "-" + b[1] + "-" + b[0];

					summ = summ.Replace(",", ".");

					if (pena.Length == 0)
						pena = "0";
					else
						pena = pena.Replace(",", ".");

					G.db_exec("sp_tmp_LoadScheta '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}'",
						datc, nome, supp, proj, summ, opla, ship, orga, opdo, deta, comm, pena, Environment.UserName);
					Error = G.LastError;

					cntLoaded = i;
				}
			}
			return Error.Length == 0;
		}
		public static void LoadNalog(string fileToLoadFrom, IWin32Window owner)
		{
			Xls.Application app = new Xls.Application();
			Xls.Workbook wbk = app.Workbooks.Open(fileToLoadFrom,
				Type.Missing, true, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing);

			Otchet = "Загрузка налогов\n";
			var hasLoaded = false;
			using (var db = new DbContext())
			{
				for (int shtNum = 1; shtNum < wbk.Sheets.Count + 1; shtNum++)
				{
					var loaded = 0;
					var sheet = (Xls.Worksheet)wbk.Sheets[shtNum];
					if (sheet.Visible != Xls.XlSheetVisibility.xlSheetVisible) continue;

					var sheetLow = sheet.Name.ToLower();
					var mm = sheetLow.Contains("январь") ? 1
						: sheetLow.Contains("февраль") ? 2
						: sheetLow.Contains("март") ? 3
						: sheetLow.Contains("апрель") ? 4
						: sheetLow.Contains("май") ? 5
						: sheetLow.Contains("июнь") ? 6
						: sheetLow.Contains("июль") ? 7
						: sheetLow.Contains("август") ? 8
						: sheetLow.Contains("сентябрь") ? 9
						: sheetLow.Contains("октябрь") ? 10
						: sheetLow.Contains("ноябрь") ? 11
						: sheetLow.Contains("декабрь") ? 12
						: -1;
					if (mm == -1) continue;
					var yyyy = 2100;
					while (!sheetLow.Contains(yyyy.ToString()) && yyyy > 2019) yyyy--;

					var month = new DateTime(yyyy, mm, 1);

					void TryLoadSchet(int row, int firma_ID, int detail_ID, bool isPeni)
					{
						string summaTxt = ((Xls.Range)sheet.Cells[row, 5]).Value2?.ToString();
						var summa = summaTxt.ToDecimal();
						if (summa <= 0) return;
						var id = $"{month:d}|{firma_ID}|{detail_ID}";
						var schet = db.FirstOrDefault<CSchetDto>(s => s.ID_1C == id);
						if (schet == null) schet = new CSchetDto { ID_1C = id };

						schet.Nomer = $"Налог {month:MMMM yyyy}";
						schet.Summa = summa;
						schet.DataCreate = month;

						string datePayTxt = ((Xls.Range)sheet.Cells[row, 3]).Value2?.ToString();
						datePayTxt = datePayTxt?.Replace(",", ".");
						if (DateTime.TryParse(datePayTxt, out var datePay)) schet.DataPayTo = datePay;
						else schet.DataPayTo = month.AddMonths(1);

						schet.Firma_ID = firma_ID;
						schet.Detail_ID = detail_ID;
						schet.Category = SchetCategory.Indirect;
						schet.StRash_ID = isPeni ? 5 : 1; //для пени Дополнительные, для налога Плановые
						schet.User = Environment.UserName;

						if (schet.ID > 0) db.Update(schet);
						else
						{
							schet.ID = db.InsertWithInt32Identity(schet);
							loaded++;
						}
						db.GetTable<COplataDto>()
							.Where(o => o.Schet_ID == schet.ID)
							.Delete();

						for (int col = 8; col <= 38; col++)
						{
							string oplataSummTxt = ((Xls.Range)sheet.Cells[row, col]).Value2?.ToString();
							var oplataSum = oplataSummTxt.ToDecimal();
							if (oplataSum > 0)
							{
								var oplata = new COplataDto
								{
									Schet_ID = schet.ID,
									Data = new DateTime(yyyy, mm, col - 7),
									Summa = oplataSum,
									User = Environment.UserName
								};
								db.Insert(oplata);
							}
						}
						schet.UpdateOplatas();
					}

					void TryLoadNalog(int row, int detail_ID)
					{
						TryLoadSchet(row++, 2, detail_ID, false);
						TryLoadSchet(row++, 2, detail_ID + 1, true);
						TryLoadSchet(row++, 1, detail_ID, false);
						TryLoadSchet(row++, 1, detail_ID + 1, true);
						TryLoadSchet(row++, 10, detail_ID, false);
						TryLoadSchet(row++, 10, detail_ID + 1, true);
						TryLoadSchet(row++, 13, detail_ID, false);
						TryLoadSchet(row++, 13, detail_ID + 1, true);
					}

					TryLoadNalog(5, 2208); // Налог на прибыль
					TryLoadNalog(14, 2210); // НДС
					TryLoadNalog(23, 2212); // Транспортный налог

					if (loaded > 0)
					{
						Otchet += $"За {month:MMMM yyyy} загружено строк: {loaded}\n";
						hasLoaded = true;
					}
				}
			}

			if ((!hasLoaded)) Otchet += "Ничего не загружено";
		}
		public static void CreateNaklad(CNakladnaya nakl, CObject obj)
		{
			var app = new Xls.Application();
			var exlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "Накладная.xltx");
			var wbk = app.Workbooks.Add(exlFile);
			try
			{
				var sht = (Xls.Worksheet)wbk.Sheets[1];

				sht.Range["Title"].Value2 = $"НАКЛАДНАЯ № {nakl.DocNumber} от {nakl.DocDate:dd/MM/yyyy}\nна отпуск материалов на сторону";
				sht.Range["DocDate"].Value2 = nakl.DocDate.ToString("dd/MM/yyyy");
				sht.Range["ObjectName"].Value2 = obj.Name;
				sht.Range["ObjectAdress"].Value2 = obj.Address;
				decimal sum = 0;
				var start = 17;

				for (var i = 0; i < nakl.Lines.Count; i++)
				{
					var l = nakl.Lines[i];

					sht.Rows[start + i].Insert();
					((Xls.Range)sht.Rows[start + i + 1]).Copy();
					((Xls.Range)sht.Rows[start + i]).PasteSpecial();

					((Xls.Range)sht.Cells[start + i, 6]).Value2 = l.Nomenkl;
					((Xls.Range)sht.Cells[start + i, 15]).Value2 = l.Measure;
					((Xls.Range)sht.Cells[start + i, 17]).Value2 = l.Quantity;
					((Xls.Range)sht.Cells[start + i, 19]).Value2 = l.Quantity;

					sum += l.Cost;
				}

				sht.Rows[start + nakl.Lines.Count].Delete();

				var sumTxt = MoneyToString.RurToWord(sum);
				var countTxt = MoneyToString.CountToWord(nakl.Lines.Count);
				sht.Range["TotalSum"].Value2 = $"Всего отпущено {nakl.Lines.Count} {countTxt} " +
											   $"на сумму {Math.Floor(sum)} {sumTxt}, в том числе сумма НДС ______ руб. ______ коп.";

				app.Visible = true;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, null);
#if DEBUG
				app.Visible = true;
#else
				wbk.Close(false);
				app.Quit();
#endif
				GC.Collect();
			}
		}
		public static void CreateAct(CNakladnaya nakl)
		{
			var app = new Xls.Application();
			var exlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "Акт_на_списание_материалов_.xltx");
			var wbk = app.Workbooks.Add(exlFile);
			try
			{
				var sht = (Xls.Worksheet)wbk.Sheets[1];

				sht.Range["Title"].Value2 = $"Акт на списание материалов № {nakl.DocNumber} от {nakl.DocDate:d}";
				sht.Range["Date"].Value2 = nakl.DocDate.ToString("d");
				decimal sum = 0;
				var start = 18;

				for (var i = 0; i < nakl.Lines.Count; i++)
				{
					var l = nakl.Lines[i];

					sht.Rows[start + i].Insert();
					((Xls.Range)sht.Rows[start + i + 1]).Copy();
					((Xls.Range)sht.Rows[start + i]).PasteSpecial();

					((Xls.Range)sht.Cells[start + i, 2]).Value2 = i + 1;
					((Xls.Range)sht.Cells[start + i, 4]).Value2 = l.Nomenkl;
					((Xls.Range)sht.Cells[start + i, 8]).Value2 = l.Measure;
					((Xls.Range)sht.Cells[start + i, 12]).Value2 = l.Quantity;
					((Xls.Range)sht.Cells[start + i, 14]).Value2 = l.PriceTotal;
					((Xls.Range)sht.Cells[start + i, 19]).Value2 = l.Cost;

					sum += l.Cost;
				}

				sht.Rows[start + nakl.Lines.Count].Delete();

				sht.Range["TotalSum"].Value2 = sum.ToString("c2");
				sht.Range["TotalSumDescr"].Value2 = $"Всего по настоящему акту списано материалов на общую сумму: {sum:c2}.";
				sht.Range["TotalSumTxt"].Value2 = MoneyToString.RurToWord(sum);

				app.Visible = true;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, null);
#if DEBUG
				app.Visible = true;
#else
				wbk.Close(false);
				app.Quit();
#endif
				GC.Collect();
			}
		}
		public static void CreateNaklineInProjects()
		{
			var app = new Xls.Application();
			var exlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "Расходы по проектам.xltx");
			var wbk = app.Workbooks.Add(exlFile);
			try
			{
				var sht = (Xls.Worksheet)wbk.Sheets[1];
				var start = 2;
				var user = ApplicationUser.User;
				var hasNoMy = user?.Role == Role.Admin || user?.Role == Role.Director;
				var projectIds = CProjectDto.GetIds(true, true, true, hasNoMy);
				var projIdsSql = string.Join(",", projectIds);

				var res = G.db_select(@"select pr.Name
						,SUM((case when p.Category = 0 then p.Price * nl.Quantity else 0 end)) Расходники
						,SUM((case when p.Category = 1 then p.Price * nl.Quantity else 0 end)) ОС
						,SUM((case when p.Category = 2 then p.Price * nl.Quantity else 0 end)) Услуги
						,SUM((case when p.Category = 3 then p.Price * nl.Quantity else 0 end)) Инвентарь
						,SUM((case when p.Category = 4 then p.Price * nl.Quantity else 0 end)) Аренда
						from Project pr
							join Object obj  on obj.Project_ID = pr.ID
							left join Nakladnaya n on n.Object_ID = obj.ID
							left join NakladLine nl on nl.Naklad_ID = n.ID
							left join Postupleniya p on nl.Postup_ID = p.ID
						where pr.ID in (" + projIdsSql + @")
						group by pr.ID, pr.Name
						order by pr.Name"
				);

				decimal rasch = 0, os = 0, serv = 0, inv = 0, rent = 0;
				for (var i = 0; i < res.Rows.Count; i++)
				{
					var r = res.Rows[i];
					sht.Rows[start + i].Insert();
					//((Xls.Range)sht.Rows[start + i + 1]).Copy();
					//((Xls.Range)sht.Rows[start + i]).PasteSpecial();

					((Xls.Range)sht.Cells[start + i, 1]).Value2 = G._S(r["Name"]);
					((Xls.Range)sht.Cells[start + i, 2]).Value2 = G._Dec(r["Расходники"]);
					((Xls.Range)sht.Cells[start + i, 3]).Value2 = G._Dec(r["ОС"]);
					((Xls.Range)sht.Cells[start + i, 4]).Value2 = G._Dec(r["Услуги"]);
					((Xls.Range)sht.Cells[start + i, 5]).Value2 = G._Dec(r["Инвентарь"]);
					((Xls.Range)sht.Cells[start + i, 6]).Value2 = G._Dec(r["Аренда"]);

					rasch += G._Dec(r["Расходники"]);
					os += G._Dec(r["ОС"]);
					serv += G._Dec(r["Услуги"]);
					inv += G._Dec(r["Инвентарь"]);
					rent += G._Dec(r["Аренда"]);
				}
				((Xls.Range)sht.Cells[start + res.Rows.Count, 1]).Value2 = "Итого";
				((Xls.Range)sht.Cells[start + res.Rows.Count, 2]).Value2 = rasch;
				((Xls.Range)sht.Cells[start + res.Rows.Count, 3]).Value2 = os;
				((Xls.Range)sht.Cells[start + res.Rows.Count, 4]).Value2 = serv;
				((Xls.Range)sht.Cells[start + res.Rows.Count, 5]).Value2 = inv;
				((Xls.Range)sht.Cells[start + res.Rows.Count, 6]).Value2 = rent;

				sht.Columns.AutoFit();
				app.Visible = true;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, null);
#if DEBUG
				app.Visible = true;
#else
				wbk.Close(false);
				app.Quit();
#endif
				GC.Collect();
			}
		}

		public static void SaveSchetaBeforeLoadDetails(DateTime start, DateTime end)
		{
#if DEBUG
			return;
#endif
			var page = new PageScheta();
			page.UpdateData(start, end,null,null, 
				PageScheta.Filter.None, false, "Все", "Все", "All");

			var appFolder = Path.Combine("C:\\SCAS", "Закупки");
			var dir = new DirectoryInfo(appFolder);
			if (!dir.Exists) dir.Create();
			var file = $"Счета {DateTime.Now:yyyy-MM-dd hh.mm} перед обновлением с {start:d} по {end:d}.xlsx";
			file = Path.Combine(appFolder, file);

			page.ExportToXlsx(file);

			var app = new Xls.Application();
			var wbk = app.Workbooks.Open(file);
			wbk.Sheets[1].Columns.AutoFit();
			wbk.Save();
			wbk.Close(false);
		}
	}
}
