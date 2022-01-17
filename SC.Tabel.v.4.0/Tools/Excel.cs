using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Collections.Generic;
using System.IO;

using Xls = Microsoft.Office.Interop.Excel;

namespace SwissClean.Tools
{
	public class Excel
	{
		public void CreateVedomost(List<ResOPViewModel> resOps, DateTime month)
		{
			var app = new Xls.Application();
			var exlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tools", "Ведомость.xlt");
			var wbk = app.Workbooks.Add(exlFile);
			try
			{
				var sht = (Xls.Worksheet)wbk.Sheets[1];
				decimal sum = 0;
				var start = 34;

				for (var i = 0; i < resOps.Count; i++)
				{
					sht.Rows[start + i].Insert();
					((Xls.Range)sht.Rows[start + i + 1]).Copy();
					((Xls.Range)sht.Rows[start + i]).PasteSpecial();

					var r = resOps[i];

					var salary = r.RateDays > 0
						? r.Salary / r.RateDays * r.FactDays + r.Premium
						: 0;

					var vichet = r.Avans
								 + r.Penalty
								 + r.SpecWear
								 + r.MedBook
								 + r.Washings
								 + r.Docs;

					((Xls.Range)sht.Cells[start + i, 1]).Value2 = i + 1;
					((Xls.Range)sht.Cells[start + i, 3]).Value2 = r.ObjectNameForResOp;
					((Xls.Range)sht.Cells[start + i, 4]).Value2 = r.Name;
					//((Xls.Range)sht.Cells[start + i, 8]).Value2 = salary - vichet;
					((Xls.Range)sht.Cells[start + i, 8]).Value2 = r.Debt;

					sum += r.Debt;
				}
				sht.Rows[start + resOps.Count].Delete();
				((Xls.Range)sht.Cells[start + resOps.Count, 8]).Value2 = sum;

				sht.Range["Date"].Value2 = DateTime.Now.ToString("dd.MM.yyyy");
				var yyyy = month.Year;
				var MM = month.Month;
				sht.Range["StartDate"].Value2 = new DateTime(yyyy, MM, 1).ToString("dd.MM.yyyy");
				sht.Range["EndDate"].Value2 = new DateTime(yyyy, MM, DateTime.DaysInMonth(yyyy, MM)).ToString("dd.MM.yyyy");
				sht.Range["SumText"].Value2 = MoneyToString.RurToWord(sum);
				sht.Range["SumNum"].Value2 = $"( {Math.Floor(sum):N0} руб. {sum % 1 * 100:##} коп. )";

				app.Visible = true;
			}
			catch
			{
				wbk.Close(false);
				app.Quit();
				GC.Collect();
				throw;
			}
		}
	}
}
