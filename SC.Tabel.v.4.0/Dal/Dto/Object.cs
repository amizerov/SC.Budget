using am.BL;
using System.Data;

namespace SwissClean.Dal.Dto
{
	public class CObject
	{
		public int ID { get; set; }
		public int? Manager_ID { get; set; }
		public int Project_ID { get; set; }
		public string Address { get; set; }
		public static CObject Factory(DataRow r) => new CObject
		{
			ID = G._I(r["ID"]),
			Manager_ID = G._I(r["Manager_ID"]),
			Project_ID = G._I(r["Project_ID"]),
			Address = G._S(r["Address"]),
		};
	}
}
