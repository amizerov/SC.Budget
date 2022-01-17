using am.BL;
using System.Collections.Generic;
using System.Data;

namespace SC.Zakup.Models
{
	class CSuppliers : List<CSupplier>
	{
		public CSuppliers()
		{
			DataTable dt = G.db_select("select ID, Name from Supplier order by Name");
			foreach (DataRow r in dt.Rows)
			{
				CSupplier p = new CSupplier() { ID = G._I(r[0]), Name = G._S(r[1]) };
				Add(p);
			}
		}
	}
	public class CSupplier
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public bool IsInternal { get; set; }
		public CSupplier() { }
		public CSupplier(int id)
		{
			ID = id; Update();
		}
		public void Update()
		{
			DataTable dt = G.db_select("select * from Supplier where ID = {1}", ID);
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
                select @id = ID from Supplier where [Name] = '{1}'
                if @id is null begin
                    insert Supplier(Name) values('{1}')
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
