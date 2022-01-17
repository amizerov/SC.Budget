using LinqToDB.Mapping;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SC.Common.Model
{
	[Table("OplataProda")]
	public class COplataProdaDto
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		[Column] public string ID_1C { get; set; }
		[Column] public int Schet_ID { get; set; }

		[DisplayName("Сумма")]
		[DisplayFormat(DataFormatString = "C2")]
		[Column] public decimal Summa { get; set; }

		[DisplayName("Дата")]
		[Column] public DateTime Data { get; set; }

		[DisplayName("Кем изменён"), Description("Пользователь, внёсший последние изменения в базе данных")]
		[Column] public string User { get; set; }

		[DisplayName("Создан"), Description("Дата создания записи в базе данных")]
		[Column(SkipOnInsert = true, SkipOnUpdate = true)]
		public DateTime dtc { get; set; }

		[DisplayName("Изменён"), Description("Дата изменения записи в базе данных")]
		[Column(SkipOnInsert = true)] public DateTime? dtu { get; set; }

		public override string ToString() => $"Дата: {Data} | Сумма: {Summa}";
	}
}
