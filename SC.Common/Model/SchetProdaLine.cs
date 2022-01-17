using LinqToDB.Mapping;
using System;

namespace SC.Common.Model
{
	[Table(Name = "SchetProdaLine")]
	public class CSchetProdaLineDto
	{
		[PrimaryKey, Identity]
		public int ID { get; set; }

		[Column] public int Schet_ID { get; set; }
		[Column] public int Object_ID { get; set; }
		[Column] public int? Service_ID { get; set; }
		[Column] public decimal Summa { get; set; }
		[Column] public decimal Penalty { get; set; }
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime Dtc { get; set; }
	}
}
