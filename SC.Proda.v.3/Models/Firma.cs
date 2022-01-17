using am.BL;
using System.Collections.Generic;
using System.Data;

namespace SC.Proda.Models
{
	public class CFirmas : List<CFirma>
	{
		public CFirmas()
		{
			DataTable dt = G.db_select("select ID, Name from SCFirma order by Name");
			foreach (DataRow r in dt.Rows)
			{
				CFirma f = new CFirma() { ID = G._I(r[0]), Name = G._S(r[1]) };
				Add(f);
			}
		}
	}
	public class CFirma
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public CFirma() { }
		public CFirma(int id)
		{
			ID = id; Update();
		}
		public void Update()
		{
			DataTable dt = G.db_select("select * from SCFirma where ID = {1}", ID);
			foreach (DataRow r in dt.Rows)
			{
				ID = G._I(r["ID"]);
				Name = G._S(r["Name"]);
			}
		}
		public void Change(string name)
		{
			if (Name == name) return;

			Name = name;
			string sql = @"
                declare @id int
                select @id = ID from SCFirma where [Name] = '{1}'
                if @id is null begin
                    insert SCFirma(Name) values('{1}')
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
