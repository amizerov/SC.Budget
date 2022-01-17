using DevExpress.XtraGrid.Views.Grid;
using LinqToDB.Mapping;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SC.Common.Services;

namespace SC.Common.Model
{
	[Table("NakladLine")]
	public class CNakladLineDto : IHasID
	{
		[PrimaryKey, Identity] public int ID { get; set; }

		[Column] public int Naklad_ID { get; set; }
		[Column] public int Postup_ID { get; set; }

		[Display(Name = "Инвентарный номер")]
		[Editable(false)]
		[Column] public string InventoryNum { get; set; }

		[Display(Name = "Количество")]
		[Column] public int Quantity { get; set; }

		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }
	}

	public class CNakladLine : CNakladLineDto
	{
		[DisplayName("Дата")]
		[Column] public DateTime DocDate { get; set; }

		[Display(Name = "Накладная")]
		[Editable(false)]
		[Column] public string Naklad { get; set; } //Накладная из 1С

		[Display(Name = "Номенклатура")]
		[Editable(false)]
		[Column] public string Nomenkl { get; set; }

		[Display(Name = "Тип")]
		[Column] public PostupCategory Category { get; set; }

		[Display(Name = "Ед.изм", Description = "Единицы измерения")]
		[Editable(false)]
		[Column] public string Measure { get; set; }

		[Display(Name = "Остаток", Description = "Остаток от поступления, который осталось разнести")]
		[Editable(false)]
		[Column] public int QuantityOnSklad { get; set; }

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

		[Display(Name = "Комментарий")]
		[Editable(false)]
		[Column] public string Comment { get; set; }

		public static bool IsEditableCell(GridView gv)
		{
			if (!(gv.GetFocusedRow() is CNakladLine nakladLine)) return false;

			if (gv.FocusedColumn.FieldName == nameof(Category))
			{
				return CPostupleniya.EditableCategories.Contains(nakladLine.Category);
			}
			if (gv.FocusedColumn.FieldName == nameof(InventoryNum))
			{
				return nakladLine.Category == PostupCategory.Инвентарь;
			}

			return false;
		}

		public CNakladLine Clone()
		{
			return (CNakladLine)MemberwiseClone();
		}
	}
}
