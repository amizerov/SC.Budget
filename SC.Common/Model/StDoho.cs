using LinqToDB.Mapping;
using SC.Common.Services;
using System;
using System.ComponentModel;

namespace SC.Common.Model
{
	[Table("StDoho")]
	public class CStDohoDto : IHasID, IHasName
	{
		[PrimaryKey, Identity] public int ID { get; set; }

		[DisplayName("Наименование")]
		[Column] public string Name { get; set; }

		
		[DisplayName("Архив")]
		[Column] public bool NoUsed { get; set; }


		[DisplayName("Создано")]
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }
	}

	public class CStDoho : CStDohoDto { }
}
