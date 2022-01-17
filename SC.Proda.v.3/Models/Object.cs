using am.BL;
using System.Collections.Generic;
using System.Data;

namespace SC.Proda.Models
{
	public class CObjects : List<CObject>
	{
		public int Project_ID { get; set; }
		public CObjects(int proj_id)
		{
			Project_ID = proj_id;
		}
	}

	public class CObject
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public CProject Project
		{
			get
			{
				int pid = G._I(G.db_select("select Project_ID from Object where ID = {1}", ID));
				return new CProject(pid);
			}
		}

		public CObject()
		{

		}

		public CObject(string address)
		{
			DataTable dt = G.db_select("select * from Object where IsDeleted = 0 and Address = '{1}'", address);
			if (dt.Rows.Count == 0 || address.Length == 0)
			{
				ID = 0; Name = "Не задан"; Address = "";
			}
			else
				foreach (DataRow r in dt.Rows)
				{
					ID = G._I(r["ID"]);
					Name = G._S(r["Name"]);
					Address = G._S(r["Address"]);
				}
		}
	}
}
