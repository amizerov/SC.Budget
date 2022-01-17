using LinqToDB.Mapping;
using SC.Common.Services;
using System;
using System.ComponentModel;

namespace SC.Common.Model
{
	[Table("DetailProda")]
	public class CDetailProdaDto : IHasID, IHasName
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		
		[DisplayName("Наименование")]
		[Column] public string Name { get; set; }
		[Column] public bool? IsActual { get; set; }
		
		[DisplayName("Создано")]
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }
	}

	public class CDetailProda : CDetailProdaDto
	{
		[DisplayName("Архив")]
		public bool NoUsed
		{
			get => !IsActual ?? true;
			set => IsActual = !value;
		}
	}
}
