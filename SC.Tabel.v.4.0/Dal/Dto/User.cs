using am.BL;
using System.Data;

namespace SwissClean.Dal.Dto
{
	public enum Role { Rukovod = 4, Manager = 5, Director = 6 }
	public class CUserDb
	{
		public int ID { get; set; }
		public string Login { get; set; }
		public string Name { get; set; }
		public Role Role { get; set; }
		public string RoleName { get; set; }

		public static CUserDb Factory(DataRow r) => new CUserDb
		{
			ID = G._I(r["ID"]),
			Login = G._S(r["Login"]),
			Name = G._S(r["Name"]),
			Role = (Role)G._I(r["Role_ID"]),
			RoleName = G._S(r["RoleName"]),
		};
	}
}
