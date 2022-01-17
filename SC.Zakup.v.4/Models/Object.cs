using am.BL;
using SC.Common.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace SC.Zakup.Models
{
	public class CObjects : List<CObject>
	{
		private readonly int Project_ID = 0;
		public CObjects(int pid)
		{
			Project_ID = pid;

			DataTable dt = G.db_select("select ID, Name from Object where Project_ID = {1} order by Name", Project_ID);
			foreach (DataRow r in dt.Rows)
			{
				CObject p = new CObject() { ID = G._I(r[0]), Name = G._S(r[1]) };
				Add(p);
			}
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
				return new CProject(G._I(G.db_select("select Project_ID from Object where ID = {1}", ID)));
			}
		}

		public CObject() { }
		public CObject(int id)
		{
			DataTable dt = G.db_select("select ID, Name, Address from Object where ID = {1}", id);
			foreach (DataRow r in dt.Rows)
			{
				ID = G._I(r[0]); Name = G._S(r[1]); Address = G._S(r[2]);
			}
		}

		public override string ToString()
		{
			return Name;
		}
	}

	//Для дерева
	public class ObjectData : IViewModel
	{
		public int ID { get; set; }
		public int Project_ID { get; set; }

		[DisplayName("Название")]
		public string Name { get; set; }

		[DisplayName("Адрес")]
		public string Adress { get; set; }

		[DisplayName("Руководитель")]
		public string ManagerName { get; set; }
		public string ViewModelID => ID.ToString();
	}

	public class ObjectDataGenerator
	{
		public static List<ObjectData> GetObjectsTree(int userId, bool isSklad)
		{
			List<ObjectData> obs = new List<ObjectData>();
			string sql = @"
                select p.ID, p.Name Proj, 
                (select count(*) from Object where Project_ID = p.ID and IsDeleted = 0) cnt,
                u.Name Ruko 
                from Project p join [User] u on p.Rukovod_ID = u.ID 
					left join Project sklad on p.Sklad_ID = sklad.ID 
			   where p.IsDeleted = 0 " +
			   $"and ({userId} = 0 or p.Rukovod_ID = {userId} or sklad.Rukovod_ID = {userId}) " +
			   (isSklad ? "and p.IsSklad = 1 " : "") +
				"order by cnt desc";
			DataTable dtP = G.db_select(sql);
			foreach (DataRow r in dtP.Rows)
			{
				var p = new ObjectData()
				{
					ID = G._I(r["ID"]),
					Project_ID = -1,
					Name = "Проект: " + G._S(r["Proj"]),
					Adress = "Объектов: " + G._S(r["cnt"]),
					ManagerName = G._S(r["Ruko"])
				};

				obs.Add(p);
				sql = @"
                    select o.ID, o.Name, o.Address, u.Name Man 
                    from Object o join [User] u on o.Manager_ID = u.ID 
                    where Project_ID = {1} and IsDeleted = 0
                ";
				DataTable dtO = G.db_select(sql, p.ID);
				foreach (DataRow ro in dtO.Rows)
				{
					var o = new ObjectData()
					{
						ID = G._I(ro["ID"]),
						Project_ID = p.ID,
						Name = G._S(ro["Name"]),
						Adress = G._S(ro["Address"]),
						ManagerName = G._S(ro["Man"])
					};
					obs.Add(o);
				}
			}
			return obs;
		}
	}
}
