using LinqToDB.Mapping;
using SC.Common.Services;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SC.Common.Model
{
	public enum PostupCategory
	{
		Расходники,
		ОС,
		Услуга,
		Инвентарь,
		Аренда
	}

	[Table(Name = "Postupleniya")]
	public class CPostupleniyaDto : IHasID
	{
		[PrimaryKey, Identity]
		public int ID { get; set; }

		[Display(Name = "Дата")]
		[Editable(false)]
		[Column] public DateTime DocDate { get; set; }

		[Display(Name = "Накладная")]
		[Editable(false)]
		[Column] public string Naklad { get; set; }

		[Column] public int LineNumber { get; set; }
		[Column] public string NomerInternal { get; set; }
		
		[Display(Name = "Контрагент")]
		[Column] public string Kontragent { get; set; }
		
		[Display(Name = "Организация")]
		[Column] public string Organization { get; set; }


		[Display(Name = "Счёт")]
		[Editable(false)]
		[Column] public string Schet { get; set; }

		[Display(Name = "Номенклатура")]
		[Editable(false)]
		[Column] public string Nomenkl { get; set; }
		[Column] public int Nomenkl_ID { get; set; }

		[Display(Name = "Инвентарный номер")]
		[Editable(false)]
		[Column] public string InventoryNum { get; set; } //только для основных средств

		[Display(Name = "Тип")]
		[Column] public PostupCategory Category { get; set; }

		[Display(Name = "Ед.изм", Description = "Единицы измерения")]
		[Editable(false)]
		[Column] public string Measure { get; set; }

		[Display(Name = "Количество")]
		[Column] public int Quantity { get; set; }

		[Display(Name = "Отгружено")]
		[Column] public int QuantityMoved { get; set; }

		[Display(Name = "Цена итоговая", Description = "Итоговая цена, включаючая в себя цену самого товара и дополнительные расходы")]
		[DisplayFormat(DataFormatString = "c2")]
		[Editable(false)]
		public decimal PriceTotal => Price + (PriceAdditional ?? 0);
		
		[Display(Name = "Цена", Description = "Цена товара или услуги")]
		[Editable(false)]
		[DisplayFormat(DataFormatString = "c2")]
		[Column] public decimal Price { get; set; }
		
		[Display(Name = "Доп.расходы", Description = "Дополнительные расходы, связанные с товаром")]
		[Editable(false)]
		[DisplayFormat(DataFormatString = "c2")]
		[Column] public decimal? PriceAdditional { get; set; }

		[Display(Name = "Сумма")]
		[DisplayFormat(DataFormatString = "c2")]
		[Editable(false)]
		public decimal Cost => Quantity * PriceTotal;

		[Column] public int? Project_ID { get; set; }

		[Display(Name = "Комментарий")]
		[Editable(false)]
		[Column] public string Comment { get; set; }
		[Column] public bool IsDeleted { get; set; }

		public CPostupleniyaDto Clone() => (CPostupleniyaDto)MemberwiseClone();

		[DisplayName("Кем изменён"), Description("Пользователь, внёсший последние изменения в базе данных")]
		[Column] public string User { get; set; }

		[DisplayName("Создан"), Description("Дата создания записи в базе данных")]
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }

		[DisplayName("Изменён"), Description("Дата изменения записи в базе данных")]
		[Column] public DateTime? dtu { get; set; }
	}
	public class CPostupleniya : CPostupleniyaDto
	{
		[Display(Name = "Номенклатура")]
		[Editable(false)]
		[Column] public string Nomenkl { get; set; }

		[Display(Name = "Остаток", Description = "Остаток на складе")]
		[Column] public int QuantityOnSklad { get; set; }

		public static PostupCategory[] EditableCategories => new[]
		{
			PostupCategory.Расходники,
			PostupCategory.Инвентарь
		};

		public override string ToString() => $"{Nomenkl} в количестве {Quantity} от {DocDate:d}";
	}

	public class CPostupleniyaForInsert : CPostupleniyaDto
	{
		public string Sklad { get; set; }
	}
}
