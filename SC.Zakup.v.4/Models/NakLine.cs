using am.BL;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace SC.Zakup.Models
{
	[DebuggerDisplay("{ViewModelID}")]
	public class CNakLine : IViewModel
	{
		public CNakLine() { }
		public CNakLine(DataRow r)
		{
			ID = G._I(r["ID"]);
			Postup_ID = G._I(r["Postup_ID"]);
			DocDate = G._D(r["DocDate"]);
			Nomenkl = G._S(r["Nomenkl"]);
			Category = (PostupCategory)G._I(r["Category"]);
			Measure = G._S(r["Measure"]);
			InventoryNum = G._S(r["InventoryNum"]);
			Quantity = G._I(r["Quantity"]);
			QuantityOnSklad = G._I(r["QuantityOnSklad"]);
			Price = G._Dec(r["Price"]);
			PriceAdditional = G._Dec(r["PriceAdditional"]);
		}

		public CNakLine(CPostupleniya postupleniya)
		{
			var fromPi = postupleniya.GetType().GetProperties();
			var toPi = GetType().GetProperties();
			foreach (var to in toPi)
			{
				if (to.CanRead && to.CanWrite)
				{
					var from = fromPi.FirstOrDefault(p => p.Name == to.Name);
					if (from != null)
					{
						to.SetValue(this, from.GetValue(postupleniya));
					}
				}
			}

			ID = 0;
			Postup_ID = postupleniya.ID;
			QuantityOnSklad = postupleniya.QuantityOnSklad;
		}

		public int ID { get; set; }
		public int Postup_ID { get; set; }

		[Display(Name = "Дата", Description = "Дата поступления")]
		[Editable(false)]
		public DateTime DocDate { get; set; }

		[Display(Name = "Номенклатура")]
		[Editable(false)]
		public string Nomenkl { get; set; }

		[Display(Name = "Тип")]
		public PostupCategory Category { get; set; }

		[Display(Name = "Ед.изм", Description = "Единицы измерения")]
		[Editable(false)]
		public string Measure { get; set; }

		[Display(Name = "Инвентарный номер")]
		[Editable(false)]
		public string InventoryNum { get; set; }

		private int _quantity;
		[Range(0, 999999)]
		[Display(Name = "Количество")]
		public int Quantity
		{
			get => _quantity;
			set
			{
				QuantityOnSklad += _quantity - value;
				_quantity = value;
			}
		}

		[Display(Name = "Остаток", Description = "Остаток на складе")]
		[Editable(false)]
		public int QuantityOnSklad { get; set; }

		[Display(Name = "Цена итоговая", Description = "Итоговая цена, включаючая в себя цену самого товара и дополнительные расходы")]
		[DisplayFormat(DataFormatString = "c2")]
		[Editable(false)]
		public decimal PriceTotal => Price + (PriceAdditional ?? 0);

		[Display(Name = "Цена", Description = "Цена товара или услуги")]
		[Editable(false)]
		[DisplayFormat(DataFormatString = "c2")]
		public decimal Price { get; set; }

		[Display(Name = "Доп.расходы", Description = "Дополнительные расходы, связанные с товаром")]
		[Editable(false)]
		[DisplayFormat(DataFormatString = "c2")]
		public decimal? PriceAdditional { get; set; }

		[Display(Name = "Стоимость")]
		[DisplayFormat(DataFormatString = "c2")]
		[Editable(false)]
		public decimal Cost => Quantity * PriceTotal;

		public string ViewModelID { get; set; }
		public string ParentID { get; set; }

		public void Save()
		{
			G.db_exec("update NakladLine\n" +
						$"set Quantity = {Quantity}\n" +
						$"where ID = {ID}\n" +
						"update Postupleniya\n" +
						"set QuantityMoved = (select SUM(Quantity)\n" +
											"from NakladLine\n" +
											"where Postup_ID = Postupleniya.ID\n" +
											"group by Postup_ID)\n," +
						$"Category = {(int)Category}\n," +
						$"InventoryNum = '{InventoryNum}'\n" +
						$"where Postupleniya.ID = {Postup_ID}");
		}
	}
	public class CNakLineMove : CNakLine
	{
		public CNakLineMove(CNakLine line)
		{
			foreach (var property in line.GetType().GetProperties())
			{
				if (property.CanWrite)
				{
					property.SetValue(this, property.GetValue(line));
				}
			}

			IsMove = true;
			QuantityOrigin = line.Quantity;
		}

		[Display(Name = "Перемещать", Description = "Укажите, нужно перемещать товар или нет")]
		public bool IsMove { get; set; }
		public int QuantityOrigin { get; set; }
	}
}
