using LinqToDB.Mapping;
using System;

namespace SC.Common.Model
{
	[Table(Name = "Operation")]
	public class COperationHistoryDto : COperationDto
	{
		[Column] public int Op_ID { get; set; }

		[Column("dtc")]
		public DateTime Op_dtc { get; set; }

		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtcc { get; set; }
	}
}
