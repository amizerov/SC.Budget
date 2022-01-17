using am.BL;
using System.Collections.Generic;
using System.Data;

namespace SC.Proda.Models
{
	public class CDetails : List<CDetail>
	{
		public CDetails()
		{
			DataTable dt = G.db_select("select ID, Name from DetailProda where IsActual = 1 order by Name");
			foreach (DataRow r in dt.Rows)
			{
				CDetail p = new CDetail() { ID = G._I(r[0]), Name = G._S(r[1]) };
				Add(p);
			}
		}

		public CDetails(string empty) { }
	}
	public class CDetail
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public CDetail() { }
		public CDetail(int id)
		{
			ID = id; Update();
		}
		public void Update()
		{
			DataTable dt = G.db_select("select * from DetailProda where ID = {1}", ID);
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
                select @id = ID from DetailProda where [Name] = '{1}'
                if @id is null begin
                    insert DetailProda(Name) values('{1}')
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
