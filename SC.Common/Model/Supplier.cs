using LinqToDB.Mapping;
using SC.Common.Services;
using System;

namespace SC.Common.Model
{
	[Table("Supplier")]
	public class CSupplierDto : IHasID, IHasName
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		[Column] public string Name { get; set; }

		[Column(SkipOnInsert = true, SkipOnUpdate = true)]
		public DateTime dtc { get; set; }
	}
}
