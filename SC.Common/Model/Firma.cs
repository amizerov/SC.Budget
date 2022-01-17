using LinqToDB.Mapping;
using SC.Common.Dal;
using SC.Common.Services;
using System;
using LinqToDB;

namespace SC.Common.Model
{
	[Table("SCFirma")]
	public class CFirmaDto : IHasID, IHasName
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		[Column] public string Name { get; set; }

		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }
	}
}
