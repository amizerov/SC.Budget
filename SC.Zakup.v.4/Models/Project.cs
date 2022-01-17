using am.BL;
using System.Data;
using SC.Common.Services;

namespace SC.Zakup.Models
{
	public class CProject
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public bool IsCash { get; set; }
		public bool IsSklad { get; set; }
		public CObjects Objects => new CObjects(ID);
		public CProject() { }
		public CProject(int id)
		{
			ID = id; Update();
		}
		public void Update()
		{
			DataTable dt = G.db_select("select * from Project where ID = {1}", ID);
			foreach (DataRow r in dt.Rows)
			{
				ID = G._I(r["ID"]);
				Name = G._S(r["Name"]);
				IsCash = G._B(r["IsCash"]);
				IsSklad = G._B(r["IsSklad"]);
			}
		}
		public void Change(string name)
		{
			if (name.IsEmpty())
			{
				ID = 0;
				return;
			}
			if (Name == name) return;

			Name = name;
			string sql = @"
                declare @id int
                select @id = ID from Project where [Name] = '{1}'
                if @id is null begin
                    insert Project(Name) values('{1}')
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
