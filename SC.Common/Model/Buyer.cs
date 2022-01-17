using LinqToDB.Mapping;
using System;
using SC.Common.Services;

namespace SC.Common.Model
{
	[Table("Buyer")]
	public class CBuyerDto : IHasID, IHasName
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		[Column] public string Name { get; set; }
		[Column] public bool IsInternal { get; set; }
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }
	}
}
