using am.BL;
using SC.Common.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SC.Zakup.Models
{

	public class CPostupleniya
	{
		public CPostupleniya(DataRow r)
		{
			ID = G._I(r["ID"]);
			DocDate = G._D(r["DocDate"]);
			Naklad = G._S(r["Naklad"]);
			Kontragent = G._S(r["Kontragent"]);
			Schet = G._S(r["Schet"]);
			Nomenkl = G._S(r["Nomenkl"]);
			Category = (PostupCategory)G._I(r["Category"]);
			Measure = G._S(r["Measure"]);
			Comment = G._S(r["Comment"]);
			InventoryNum = G._S(r["InventoryNum"]);
			Quantity = G._I(r["Quantity"]);
			QuantityOnSklad = G._I(r["QuantityOnSklad"]);
			Price = G._Dec(r["Price"]);
		}

		public int ID { get; set; }
		public DateTime dtc { get; set; }
		public DateTime dtu { get; set; }
		public string User { get; set; }

		[Display(Name = "Дата")]
		[Editable(false)]
		public DateTime DocDate { get; set; }

		[Display(Name = "Накладная")]
		[Editable(false)]
		public string Naklad { get; set; }


		[Display(Name = "Счёт")]
		[Editable(false)]
		public string Schet { get; set; }

		[Display(Name = "Номенклатура")]
		[Editable(false)]
		public string Nomenkl { get; set; }

		[Display(Name = "Контрагент")]
		[Editable(false)]
		public string Kontragent { get; set; }

		[Display(Name = "Тип")]
		public PostupCategory Category { get; set; }

		[Display(Name = "Ед.изм", Description = "Единицы измерения")]
		[Editable(false)]
		public string Measure { get; set; }

		[Display(Name = "Инвентарный номер")]
		[Editable(false)]
		public string InventoryNum { get; set; }

		[Range(0, 999999)]
		[Display(Name = "Количество")]
		public int Quantity { get; set; }

		[Display(Name = "Остаток", Description = "Остаток на складе")]
		public int QuantityOnSklad { get; set; }

		[Range(0, 999999)]
		[Display(Name = "Цена")]
		[DisplayFormat(DataFormatString = "c2")]
		[Editable(false)]
		public decimal Price { get; set; }

		[Display(Name = "Стоимость")]
		[DisplayFormat(DataFormatString = "c2")]
		[Editable(false)]
		public decimal Cost
		{
			get => Quantity * Price;
		}

		[Display(Name = "Комментарий")]
		[Editable(false)]
		public string Comment { get; set; }

		public void Delete()
		{
			G.db_exec($"delete Postupleniya where ID = {ID}");
		}
	}
}
