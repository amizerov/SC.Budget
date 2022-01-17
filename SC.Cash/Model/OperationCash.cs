using LinqToDB.Mapping;
using SC.Common.Model;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SC.Cash.Model
{
	public class COperationCash : COperationCashDto
	{
		[Display(Name = "Дата создания"), Description("Дата создания счёта")]
		[Editable(false)]
		[Column] public DateTime DataCreate { get; set; }

		[Display(Name = "Дата перевода"), Description("Дата перевода в кассу")]
		public DateTime? DateToCash { get; set; }

		[Display(Name = "Отдать процент")]
		public decimal? OutPercent { get; set; }

		[Display(Name = "Организация")]
		[Editable(false)]
		[Column] public string Comment { get; set; }

		[Display(Name = "Фирма")]
		[Editable(false)]
		[Column] public string FirmaName { get; set; }

		public CAccountDto ToAccount { get; set; }

		[Display(Name = "На счёт", Description = "Укажите счёт, на который будут зачислены деньги")]
		public string ToAccountName { get; set; }

		[Display(Name = "Проект")]
		[Column] public string ProjectName { get; set; }

		public COperationCash Clone() => (COperationCash)MemberwiseClone();
	}
}
