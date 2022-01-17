using am.BL;
using SC.Proda.Models;
using System;
using Xls = Microsoft.Office.Interop.Excel;

namespace SC.Proda.Tools
{
	public class Excel
	{
		public int Count = 0;
		public string Error = "";
		public string ExlFile = "";

		private string datc, nome, buer, proj, summ, opla, ship, orga, opdo, serv, comm, pena, stdo/*статья дохода*/;
		private Xls.Worksheet Sht;
		public Excel(string file)
		{
			ExlFile = file;
			Xls.Application app = new Xls.Application();
			Xls.Workbook wbk = app.Workbooks.Open(ExlFile,
				Type.Missing, true, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing);
			Sht = (Xls.Worksheet)wbk.Sheets[1];

		}
		public bool CheckTemplate()
		{
			Error = "";
			GetLine(1);
			if (datc + nome + summ == "")
			{
				Error = "Пустой файл";
				return false;
			}
			if (!IsTemplateCorrect())
			{
				Error = "Неправлильный формат шаблона загрузки.\n\r" +
						"Проверьте наличие колонки <" + Error + ">";

				return false;
			}
			return true;
		}
		private bool IsLastLine()
		{
			return (Count > 1) && (datc + nome + summ == "");
		}
		public bool LoadScheta()
		{
			if (CheckTemplate())
			{
				for (Count = 2; Count < 999; Count++)
				{
					GetLine(Count);
					if (IsLastLine()) return true;

					if (proj.Length > 0)
					{
						CProjects ps = new CProjects();
						if (ps.FindAll(p => p.Name == proj).Count == 0)
						{
							Error = "Неправильное название проекта в строке " + (Count - 1) + ".\r\n" +
									"<" + proj + ">";
							return false;
						}
					}
					else
					{
						Error = "Название проекта в строке " + (Count - 1) + " пустое.\r\n" +
								"Счет № " + nome + ". Заполните поле Проект.";
						return false;
					}

					if (serv.Length > 0)
					{
						CDetails s = new CDetails();
						if (s.FindAll(d => d.Name == serv).Count == 0)
						{
							Error = "Неправильное название услуги в строке " + (Count - 1) + ".\r\n" +
									"<" + serv + ">";
							return false;
						}
					}
					else
					{
						Error = "Значение услуги в строке " + (Count - 1) + " пустое.\r\n" +
								"Счет № " + nome + ". Заполните поле Услуга.";
						return false;
					}

					if (stdo.Length > 0)
					{
						CStDohos sd = new CStDohos();
						if (sd.FindAll(d => d.Name == stdo).Count == 0)
						{
							Error = "Неправильная статья дохода в строке " + (Count - 1) + ".\r\n" +
									"<" + stdo + ">";
							return false;
						}
					}
					else
					{
						Error = "Cтатья дохода в строке " + (Count - 1) + " пустая.\r\n" +
								"Счет № " + nome + ". Заполните поле Cтатья дохода.";
						return false;
					}

					if (orga.Length > 0)
					{
						CFirmas fs = new CFirmas();
						if (fs.FindAll(f => f.Name == orga).Count == 0)
						{
							Error = "Неправильная Организация в строке " + (Count - 1) + ".\r\n" +
									"<" + orga + ">";
							return false;
						}
					}
					else
					{
						Error = "Организация в строке " + (Count - 1) + " пустая.\r\n" +
								"Счет № " + nome + ". Заполните поле Организация.";
						return false;
					}

					if (datc == "") { Error = "Дата обязательное поле не заполнено!"; return false; }
					datc = GetCorrectDateString(datc);
					if (opdo == "") { Error = "Срок оплаты обязательное поле не заполнено!"; return false; }
					opdo = GetCorrectDateString(opdo);

					if (summ.Length == 0) { Error = "Сумма счета обязательное поле не заполнено!"; return false; }
					summ = summ.Replace(",", ".");

					if (pena.Length == 0)
						pena = "0";
					else
						pena = pena.Replace(",", ".");

					G.db_exec(@"sp_tmp_LoadSchetaProda 
                    '{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}'",
						datc, nome, buer, proj, summ, opla, ship, orga, opdo, serv, stdo, comm, pena, Environment.UserName);
					Error = G.LastError;
				}
			}
			return Error.Length == 0;
		}
		private void GetLine(int n)
		{
			datc = ((Xls.Range)Sht.Cells[n, 1]).Value2 + "";
			nome = ((Xls.Range)Sht.Cells[n, 2]).Value2 + "";
			buer = ((Xls.Range)Sht.Cells[n, 3]).Value2 + "";
			proj = ((Xls.Range)Sht.Cells[n, 4]).Value2 + "";
			summ = ((Xls.Range)Sht.Cells[n, 5]).Value2 + "";
			pena = ((Xls.Range)Sht.Cells[n, 6]).Value2 + "";
			opdo = ((Xls.Range)Sht.Cells[n, 7]).Value2 + "";
			opla = ((Xls.Range)Sht.Cells[n, 8]).Value2 + "";
			ship = ((Xls.Range)Sht.Cells[n, 9]).Value2 + "";
			orga = ((Xls.Range)Sht.Cells[n, 10]).Value2 + "";
			serv = ((Xls.Range)Sht.Cells[n, 11]).Value2 + "";
			stdo = ((Xls.Range)Sht.Cells[n, 12]).Value2 + "";
			comm = ((Xls.Range)Sht.Cells[n, 13]).Value2 + "";
		}
		private string GetCorrectDateString(string dateFromExcel)
		{
			string correctDate = "";
			var a = dateFromExcel.Split('.');
			if (a.Length == 1)
				correctDate = DateTime.FromOADate(double.Parse(dateFromExcel)).ToString("yyyyMMdd");
			else
				correctDate = a[2] + "-" + a[1] + "-" + a[0];

			return correctDate;
		}
		private bool IsTemplateCorrect()
		{
			Error = "";

			if (datc != "Дата") Error = "Дата";
			if (nome != "Номер") Error = "Номер";
			if (buer != "Контрагент") Error = "Контрагент";
			if (proj != "Проект") Error = "Проект";
			if (summ != "Сумма") Error = "Сумма";
			if (opla != "Оплата") Error = "Оплата";
			if (ship != "Отгрузка") Error = "Отгрузка";
			if (orga != "Организация") Error = "Организация";
			if (opdo != "Срок оплаты") Error = "Срок оплаты";
			if (serv != "Услуга") Error = "Услуга";
			if (pena != "Штраф") Error = "Штраф";
			if (stdo != "Статья дохода") Error = "Статья дохода";

			return Error.Length == 0;
		}
	}
}
