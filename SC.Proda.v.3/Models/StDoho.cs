using am.BL;
using System.Collections.Generic;
using System.Data;

namespace SC.Proda.Models
{
	public class CStDohos : List<CStDoho>
	{
		public CStDohos()
		{
			DataTable dt = G.db_select("select ID, Name from StDoho order by Name");
			foreach (DataRow r in dt.Rows)
			{
				CStDoho p = new CStDoho() { ID = G._I(r[0]), Name = G._S(r[1]) };
				Add(p);
			}
		}
	}
	public class CStDoho
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public bool NoUsed { get; set; }

		public CStDoho() { }
		public CStDoho(int id)
		{
			ID = id; Update();
		}
		public void Update()
		{
			DataTable dt = G.db_select("select * from StDoho where ID = {1}", ID);
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
                select @id = ID from StDoho where [Name] = '{1}'
                if @id is null begin
                    insert StDoho(Name) values('{1}')
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
