using am.BL;
using System.Collections.Generic;
using System.Data;

namespace SC.Zakup.Models
{
	public class CStRashs : List<CStRash>
	{
		public CStRashs()
		{
			DataTable dt = G.db_select("select * from StRash order by Name");
			foreach (DataRow r in dt.Rows)
			{
				var p = new CStRash
				{
					ID = G._I(r["ID"]),
					Name = G._S(r["Name"]),
					NoUsed = G._B(r["NoUsed"]),
				};
				Add(p);
			}
		}
	}
	public class CStRash
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public bool NoUsed { get; set; }
		public CStRash() { }
		public CStRash(int id)
		{
			ID = id; Update();
		}
		public void Update()
		{
			DataTable dt = G.db_select("select * from StRash where ID = {1}", ID);
			foreach (DataRow r in dt.Rows)
			{
				ID = G._I(r["ID"]);
				Name = G._S(r["Name"]);
				NoUsed = G._B(r["NoUsed"]);
			}
		}
		public void Change(string name)
		{
			if (Name == name) return;

			Name = name;
			string sql = @"
                declare @id int
                select @id = ID from StRash where [Name] = '{1}'
                if @id is null begin
                    insert StRash(Name) values('{1}')
                    set @id = @@IDENTITY
                end
                select @id 
            ";
			DataTable dt = G.db_select(sql, Name);
			foreach (DataRow r in dt.Rows) ID = G._I(r);
			Update();
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
