using LinqToDB.Mapping;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SC.Common.Services;

namespace SC.Common.Model
{
	[Table("Oplata")]
	public class COplataDto : IHasID
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		[Column] public string ID_1C { get; set; }
		
		[DisplayName("ID счёта")]
		[Column] public int? Schet_ID { get; set; }

		[DisplayName("Сумма")]
		[DisplayFormat(DataFormatString = "C2")]
		[Column] public decimal Summa { get; set; }

		[DisplayName("Дата")]
		[Column] public DateTime Data { get; set; }

		[DisplayName("Кем изменена"), Description("Пользователь, внёсший последние изменения в базе данных")]
		[Column] public string User { get; set; }
		
		[DisplayName("Удалена")]
		[Column] public bool IsDeleted { get; set; }

		[DisplayName("Создана"), Description("Дата создания записи в базе данных")]
		[Column(SkipOnInsert = true, SkipOnUpdate = true)]
		public DateTime dtc { get; set; }

		[DisplayName("Изменёна"), Description("Дата изменения записи в базе данных")]
		[Column(SkipOnInsert = true)] public DateTime? dtu { get; set; }

		public override string ToString() => $"Дата: {Data} | Сумма: {Summa}";
	}

	public class COplata : COplataDto
	{
		[DisplayName("№ счёта")]
		[Column] public string Schet_Nomer { get; set; }
		
		[DisplayName("№ 1С счёта")]
		[Column] public string Schet_NomerInternal { get; set; }
		[Column] public int? Detail_ID { get; set; }
		
		[DisplayName("Детализация")]
		[Column] public string DetailName { get; set; }
		[Column] public int? Firma_ID { get; set; }
		
		[DisplayName("Организация")]
		[Column] public string FirmaName { get; set; }
		[Column] public int? Supplier_ID { get; set; }
		
		[DisplayName("Поставщик")]
		[Column] public string SupplierName { get; set; }
	}
}
