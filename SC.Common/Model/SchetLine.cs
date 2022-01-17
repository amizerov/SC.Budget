using System;
using System.ComponentModel.DataAnnotations;
using LinqToDB.Mapping;

namespace SC.Common.Model
{
	[Table("SchetZakupLine")]
	public class CSchetLineDto
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		[Column] public int Schet_ID { get; set; }
		[Column] public int Nomenkl_ID { get; set; }

		[Display(Name = "Количество")]
		[Column] public int Quantity { get; set; }
		
		[Display(Name = "Цена", Description = "Цена товара или услуги")]
		[Column] public decimal Price { get; set; }
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }
	}

	public class CSchetLine : CSchetLineDto
	{
		[Display(Name = "Номенклатура")]
		[Column] public string Nomenklatura { get; set; }
	}
}
