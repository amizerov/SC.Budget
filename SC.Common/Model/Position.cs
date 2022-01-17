using LinqToDB.Mapping;
using System;

namespace SC.Common.Model
{
	[Table("Position")]
	public class CPositionDto
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		[Column] public string Name { get; set; }
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }
	}

	public class CPosition : CPositionDto
	{
		[Column] public decimal Salary { get; set; }
	}
}
