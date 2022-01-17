using DevExpress.XtraGrid.Views.Grid;
using LinqToDB.Mapping;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SC.Common.Services;

namespace SC.Common.Model
{
	public class CNakladLineInvented : CNakladLine
	{
		[Display(Name = "Кол-во учёт")]
		[Column] public int QuantityAccount { get; set; }
		
		[Display(Name = "Кол-во факт")]
		[Column] public int QuantityFact { get; set; }

		[Display(Name = "Отклонение")] 
		public int QuantityDiff => QuantityFact - QuantityAccount;

		[Display(Name = "Сумма учёт")]
		[DisplayFormat(DataFormatString = "c2")]
		public decimal CostAccount => PriceTotal * QuantityAccount;
		
		[Display(Name = "Сумма факт")]
		[DisplayFormat(DataFormatString = "c2")]
		public decimal CostFact => QuantityDiff < 0 ? PriceTotal * QuantityFact
			: CostAccount;
	}
}
