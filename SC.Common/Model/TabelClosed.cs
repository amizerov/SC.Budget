using LinqToDB.Mapping;
using SC.Common.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace SC.Common.Model
{
	[Table("TabelClosed")]
	public class CTabelClosedDto : IHasID
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		[Column] public int Object_ID { get; set; }
		[Column] public DateTime Month { get; set; }
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }
		[Column] public DateTime? dtu { get; set; }
		[Column] public string User { get; set; }
	}

	public class CTabelClosed : CTabelClosedDto
	{
		
	}
}
