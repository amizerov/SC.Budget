using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using am.BL;
using SC.Zakup.Models;

namespace SC.Zakup.Models
{
	public class CNakladnaya
	{
		public int ID { get; set; }

		[DisplayName("Дата")]
		public DateTime DocDate { get; set; }

		[DisplayName("Номер")]
		public string DocNumber { get; set; }

		[DisplayName("Проект")]
		public string ProjectName { get; set; }
		public int Rukovod_ID { get; set; }

		[DisplayName("Объект")]
		public string ObjectName { get; set; }
		public string User { get; set; }
		public int? Object_ID { get; set; }
		public int? FromObject_ID { get; set; }
		public List<CNakLine> Lines { get; set; }

		public CNakladnaya()
		{
			Lines = new List<CNakLine>();
		}

		public CNakladnaya(DataRow r)
		{
			ID = G._I(r["ID"]);
			DocDate = G._D(r["DocDate"]);
			DocNumber = G._S(r["DocNumber"]);
			ProjectName = G._S(r["ProjectName"]);
			Rukovod_ID = G._I(r["Rukovod_ID"]);
			ObjectName = G._S(r["ObjectName"]);
			User = G._S(r["User"]);
		}
		public CNakladnaya(int id)
		{
			Lines = new List<CNakLine>();
			ID = id;
			DataTable dt = G.db_select("select * from Nakladnaya where ID = {1}", ID);
			if (dt.Rows.Count == 1)
			{
				DataRow r = dt.Rows[0];
				DocDate = G._D(r["DocDate"]);
				DocNumber = G._S(r["DocNumber"]);
				Object_ID = G._I(r["Object_ID"]);
				FromObject_ID = G._I(r["FromObject_ID"]);

				dt = G.db_select(@"select nl.ID, nl.Postup_ID, n.DocDate, p.Nomenkl, p.Measure, p.Category,
						nl.Quantity, p.Price, p.PriceAdditional, p.Quantity - p.QuantityMoved QuantityOnSklad, p.InventoryNum
					from NakladLine nl 
						join Postupleniya p on p.ID = nl.Postup_ID						
						join Nakladnaya n on nl.Naklad_ID = n.ID
                    where Naklad_ID = {1}",
					ID);
				foreach (DataRow l in dt.Rows)
				{
					Lines.Add(new CNakLine(l));
				}
			}
		}
		public void Create()
		{
			string sql = @"insert Nakladnaya(DocDate, DocNumber, Object_ID, FromObject_ID, Status, [User])
                values('{1}', '{2}', {3}, {4}, {5}, '{6}')
                select @@IDENTITY";
			int ID = G._I(G.db_select(sql,
				DocDate.ToString("yyyyMMdd"),
				DocNumber,
				Object_ID?.ToString() ?? "NULL",
				FromObject_ID?.ToString() ?? "NULL",
				1,
				Environment.UserName));

			Lines.ForEach(l =>
			{
				sql = @"insert NakladLine(Naklad_ID, Postup_ID, Quantity)
                    values({1}, {2}, {3})";

				if (FromObject_ID == null) // если это не перемещение или списание, то пересчитываем остаток от поступления
				{
					sql += "update Postupleniya set QuantityMoved = QuantityMoved + {3} where ID = {2}";
				}
				G.db_exec(sql, ID, l.Postup_ID, l.Quantity);
			});
		}

		public void Save()
		{
			var bld = new StringBuilder();

			bld.AppendLine(@"update Nakladnaya
						set DocDate = '{2}', DocNumber = '{3}', Object_ID = {4}, FromObject_ID = {5}, Status = {6}, [User] = '{7}'
						where ID = {1}");

			bld.AppendLine(@"update Postupleniya
					   set QuantityMoved = (select SUM(Quantity)
							from NakladLine
							where Postup_ID = Postupleniya.ID
							group by Postup_ID)
					   where Postupleniya.ID in (
							select Postup_ID
							from NakladLine
							where NakladLine.Naklad_ID = {1})");

			var sql = bld.ToString();

			G.db_select(sql,
				ID,
				DocDate.ToString("yyyyMMdd"),
				DocNumber,
				Object_ID?.ToString() ?? "'NULL'",
				FromObject_ID?.ToString() ?? "'NULL'",
				1,
				Environment.UserName);

			Lines.ForEach(l => l.Save());
		}
	}
}
