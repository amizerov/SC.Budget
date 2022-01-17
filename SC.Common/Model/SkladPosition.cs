using System.ComponentModel.DataAnnotations;
using LinqToDB.Mapping;

namespace SC.Common.Model
{
	public class CSkladPositionDto
	{
		[Display(Name = "Номенклатура")]
		[Column] public string Nomenkl { get; set; }

		[Display(Name = "Ед.Изм.")]
		[Column] public string Measure { get; set; }

		[Column] public int QuantityStart { get; set; }
		[Column] public int QuantityIn { get; set; }
		[Column] public int QuantityOut { get; set; }

		[Column] public decimal CostStart { get; set; }
		[Column] public decimal CostIn { get; set; }
		[Column] public decimal CostOut { get; set; }

		[Column] public decimal CostAdditionalStart { get; set; }
		[Column] public decimal CostAdditionalIn { get; set; }
		[Column] public decimal CostAdditionalOut { get; set; }
		public PostupCategory Category { get; set; }
	}

	public class CSkladPosition
	{
		public enum EnumIndicator
		{
			[Display(Name = "Сумма, р")] Cost,
			[Display(Name = "Доп.расходы, р")] CostAdditional,
			[Display(Name = "Кол-во")] Quantity
		}
		public enum EnumParameter
		{
			[Display(Name = "Входящий остаток")] Start,
			[Display(Name = "Приход")] In,
			[Display(Name = "Расход")] Out,
			[Display(Name = "Исходящий остаток")] End,
		}

		public CSkladPosition(CObjectDto sklad, string nomenkl, string measure)
		{
			Sklad_ID = sklad.ID;
			Sklad = sklad.Name;
			Nomenkl = nomenkl;
			Measure = measure;
		}
		public int Sklad_ID { get; set; }

		[Display(Name = "Склад")]
		public string Sklad { get; set; }

		[Display(Name = "Номенклатура")]
		public string Nomenkl { get; set; }

		[Display(Name = "Ед.Изм.")]
		public string Measure { get; set; }

		[Display(Name = "Показатель")]
		public EnumIndicator Indicator { get; set; }

		[Display(Name = "Параметр")]
		public EnumParameter Parameter { get; set; }

		[Display(Name = "Значение")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal Value { get; set; }
	}
}
