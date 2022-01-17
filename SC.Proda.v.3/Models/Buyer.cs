using am.BL;
using System.Collections.Generic;
using System.Data;

namespace SC.Proda.Models
{
	class CBuyers : List<CBuyer>
	{
		public CBuyers()
		{
			DataTable dt = G.db_select("select ID, Name from Buyer order by Name");
			foreach (DataRow r in dt.Rows)
			{
				CBuyer p = new CBuyer() { ID = G._I(r[0]), Name = G._S(r[1]) };
				Add(p);
			}
		}
	}
	public class CBuyer
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public bool IsInternal { get; set; }
		public CBuyer() { }
		public CBuyer(int id)
		{
			ID = id; Update();
		}
		public void Update()
		{
			DataTable dt = G.db_select("select * from Buyer where ID = {1}", ID);
			foreach (DataRow r in dt.Rows)
			{
				ID = G._I(r["ID"]);
				Name = G._S(r["Name"]);
				IsInternal = G._B(r["IsInternal"]);
			}
		}
		public void Change(string name)
		{
			if (Name == name) return;

			Name = name;
			string sql = @"
                declare @id int
                select @id = ID from Buyer where [Name] = '{1}'
                if @id is null begin
                    insert Buyer(Name) values('{1}')
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
