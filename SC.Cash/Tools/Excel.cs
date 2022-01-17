using SC.Cash.Model;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Data;
using System.IO;
using SC.Common.Dal;
using Xls = Microsoft.Office.Interop.Excel;
using am.BL;

namespace SC.Cash.Tools
{
	public class Excel
	{
		public void Order(COperation op)
		{
			var app = new Xls.Application();
			var exlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "cash_order.xltx");
			var wbk = app.Workbooks.Add(exlFile);
			try
			{
				var sht = (Xls.Worksheet)wbk.Sheets[1];

				sht.Range["Date"].Value2 = op.DateTime.ToString("dd.MM.yyyy");
				sht.Range["ToUser1"].Value2 =
				sht.Range["ToUser2"].Value2 = op.ToUser;
				sht.Range["Comment"].Value2 = op.Comment;
				sht.Range["SumText"].Value2 = MoneyToString.RurToWord(op.Amount);
				sht.Range["SumNum"].Value2 = $"{Math.Floor(op.Amount):N0} руб. {op.Amount % 1 * 100:##} коп.";
				sht.Columns.AutoFit();

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
		public void Cash(COperationCash[] ops)
		{
			var app = new Xls.Application();
			var wbk = app.Workbooks.Add();
			try
			{
				var sht = (Xls.Worksheet)wbk.Sheets[1];
				var col = 1;
				const string amountHeader = "Общая сумма";
				const string amountOutHeader = "Отдано денег";
				const string amountToAccHeader = "Денег в кассе";
				const string companyHeader = "Организация";
				((Xls.Range)sht.Cells[1, col++]).Value2 = "Фирма";
				((Xls.Range)sht.Cells[1, col++]).Value2 = "Дата";
				((Xls.Range)sht.Cells[1, col++]).Value2 = amountHeader;
				((Xls.Range)sht.Cells[1, col++]).Value2 = "Отдано процентов";
				((Xls.Range)sht.Cells[1, col++]).Value2 = amountOutHeader;
				((Xls.Range)sht.Cells[1, col++]).Value2 = amountToAccHeader;
				((Xls.Range)sht.Cells[1, col++]).Value2 = companyHeader;

				for (var i = 0; i < ops.Length; i++)
				{
					col = 1;
					ops[i].OutPercent = Math.Round((1 - (ops[i].AmountToAcc ?? 0) / ops[i].Amount) * 100, 2);
					((Xls.Range)sht.Cells[i + 2, col++]).Value2 = ops[i].FirmaName;
					((Xls.Range)sht.Cells[i + 2, col++]).Value2 = ops[i].DataCreate.ToString("dd.MM.yyyy");
					((Xls.Range)sht.Cells[i + 2, col++]).Value2 = ops[i].Amount;
					((Xls.Range)sht.Cells[i + 2, col++]).Value2 = ops[i].OutPercent;
					((Xls.Range)sht.Cells[i + 2, col++]).Value2 = ops[i].Amount - ops[i].AmountToAcc;
					((Xls.Range)sht.Cells[i + 2, col++]).Value2 = ops[i].AmountToAcc;
					((Xls.Range)sht.Cells[i + 2, col++]).Value2 = ops[i].Comment;
				}

				var table = sht.ListObjects.Add(Xls.XlListObjectSourceType.xlSrcRange, sht.Range[$"A1:G{ops.Length + 1}"]);
				table.ShowTotals = true;
				table.ListColumns[amountHeader].TotalsCalculation = Xls.XlTotalsCalculation.xlTotalsCalculationSum;
				table.ListColumns[amountOutHeader].TotalsCalculation = Xls.XlTotalsCalculation.xlTotalsCalculationSum;
				table.ListColumns[amountToAccHeader].TotalsCalculation = Xls.XlTotalsCalculation.xlTotalsCalculationSum;
				table.ListColumns[companyHeader].TotalsCalculation = Xls.XlTotalsCalculation.xlTotalsCalculationNone;
				sht.Columns.AutoFit();
				sht.Cells[1, 1].Select();
				sht.Columns.AutoFit();

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

		public void Vipiska(CAccount acc, DateTime start, DateTime end)
		{
			var app = new Xls.Application();
			var exlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "Свис_Выписка_по_счету_.xltx");
			var wbk = app.Workbooks.Add(exlFile);
			try
			{
				var sht = (Xls.Worksheet)wbk.Sheets[1];
				var userName = acc.IsPassive ? acc.NameForPassive : acc.UserName;

				sht.Range["Title"].Value2 = $"Выписка по счёту {userName} с {start:d} по {end:d}";

				var dt = G.db_select($"Cash_Vipiska {acc.ID}, N'{start:yyyyMMdd}', N'{end:yyyyMMdd}'");
				double debt = 0, credit = 0;
				for (var i = 0; i < dt.Rows.Count; i++)
				{
					var col = 1;
					var r = dt.Rows[i];
					((Xls.Range)sht.Cells[5 + i, col++]).Value2 = G._S(r["Дата"]);
					var debt_i = G._Double(r["Дебет"]);
					((Xls.Range)sht.Cells[5 + i, col++]).Value2 = debt_i;
					debt += debt_i;
					var credit_i = G._Double(r["Кредит"]);
					((Xls.Range)sht.Cells[5 + i, col++]).Value2 = credit_i;
					credit += credit_i;
					((Xls.Range)sht.Cells[5 + i, col++]).Value2 = G._Double(r["Сальдо"]);
					((Xls.Range)sht.Cells[5 + i, col++]).Value2 = G._S(r["Коментарий"]);
				}

				sht.Range["Debt"].Value2 = debt;
				sht.Range["Credit"].Value2 = credit;

				sht.Columns.AutoFit();
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
	}
}
