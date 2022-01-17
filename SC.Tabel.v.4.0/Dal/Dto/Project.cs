using am.BL;
using System.Data;

namespace SwissClean.Dal.Dto
{
	public class CProject
	{
		public int ID { get; set; }
		public string Name { get; set; }

		public static CProject Factory(DataRow r) => new CProject
		{
			ID = G._I(r["ID"]),
			Name = G._S(r["Name"]),
		};
	}
}
