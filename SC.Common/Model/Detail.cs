using LinqToDB.Mapping;
using SC.Common.Services;
using System;
using System.ComponentModel;

namespace SC.Common.Model
{
	[Table("Detail")]
	public class CDetailDto : IHasID, IHasName
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		
		[DisplayName("Наименование")]
		[Column] public string Name { get; set; }
		[Column] public bool? IsActual { get; set; }
		
		[DisplayName("Категория")]
		[Column] public SchetCategory Category { get; set; }
		
		[DisplayName("Класс")]
		[Column] public DetailClass Class { get; set; }
		
		[DisplayName("Создано")]
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }
	}

	public class CDetail : CDetailDto
	{
		[DisplayName("Архив")]
		public bool NoUsed
		{
			get => !IsActual ?? true;
			set => IsActual = !value;
		}
	}
}
