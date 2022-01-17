using am.BL;
using System.Collections.Generic;
using System.Data;
using SC.Zakup.Models;

namespace SC.Zakup.Models
{
	public static class CSklad
	{
		public static List<CPostupleniya> Postupleniya(int userID, bool isMyOnly)
		{
			string sql = @"
                    select ID, DocDate, Naklad, Schet, Nomenkl, Kontragent,
                    Quantity - QuantityMoved Quantity, Price, Measure, InventoryNum,
					Quantity - QuantityMoved QuantityOnSklad, Category, dtc, dtu, [User], Comment
                    from Postupleniya where Quantity-QuantityMoved > 0 
					and exists (select * from Project p
						join Project sklad on p.Sklad_ID = sklad.ID " +
							$"and (sklad.Rukovod_ID = {userID} or {userID} = 0) " +
						"join Scheta s on s.Project_ID = p.ID and s.Nomer = Schet)" +
							(isMyOnly && userID > 0 ? "" : " or Schet = '' or Schet is null") +
					" order by DocDate desc";
			var dt = G.db_select(sql);

			var res = new List<CPostupleniya>();
			foreach (DataRow r in dt.Rows)
			{
				res.Add(new CPostupleniya(r));
			}

			return res;
		}
		public static List<CNakladnaya> Naklads
		{
			get
			{
				string sql = @"                
                    select n.*, p.Name ProjectName, p.Rukovod_ID Rukovod_ID, o.Name + ' - ' + o.Address ObjectName
                    from Nakladnaya n join Object o on o.ID = n.Object_ID
                    join Project p on p.ID = o.Project_ID
                    order by DocDate desc                
                ";

				var dt = G.db_select(sql);

				var res = new List<CNakladnaya>();
				foreach (DataRow r in dt.Rows)
				{
					res.Add(new CNakladnaya(r));
				}
				return res;
			}
		}
	}
}
