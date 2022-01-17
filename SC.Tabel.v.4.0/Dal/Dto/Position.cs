using am.BL;
using System;
using System.Data;

namespace SwissClean.Dal.Dto
{
	public class CPosition
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public DateTime dtc { get; set; }

		public decimal Salary { get; set; } // из базы данных Oklad

		public override string ToString() => Name;

		public static CPosition Factory(DataRow r) => new CPosition
		{
			ID = G._I(r["ID"]),
			Name = G._S(r["Name"]),
			dtc = G._D(r["dtc"]),
			Salary = G._Dec(r["Salary"]),
		};
	}
}
