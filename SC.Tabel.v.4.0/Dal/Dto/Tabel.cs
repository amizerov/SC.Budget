using am.BL;
using System;
using System.Data;

namespace SwissClean.Dal.Dto
{
	public class CTabel
	{
		public int ID { get; set; }
		public int? ResOP_ID { get; set; }
		public DateTime? Date { get; set; }

		public bool IsExit { get; set; } //Вспомогательное свойство

		public static CTabel Factory(DataRow r) => new CTabel
		{
			ID = G._I(r["ID"]),
			ResOP_ID = G._I(r["ResOP_ID"]),
			Date = G._D(r["Date"]),
			IsExit = true,
		};
	}
}
