using LinqToDB.Mapping;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SC.Budget.Model
{
	public class CObject
	{
		[Column(Name = "Name")]
		[DisplayName("Объект")]
		public string Name { get; set; }

		[Column(Name = "Income")]
		[DisplayName("Доход")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal? Income { get; set; }

		[Column(Name = "Postup")]
		[DisplayName("Расходы на материалы")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal? Postup { get; set; }

		[Column(Name = "Salary")]
		[DisplayName("Зарплата")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal? Salary { get; set; }

		[DisplayName("Прибыль")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal? Profit => (Income ?? 0) - (Postup ?? 0) - (Salary ?? 0);
	}
}
