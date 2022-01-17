using LinqToDB.Mapping;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SC.Budget.Model
{
	public class CPostupleniya
	{
		[Column(Name = "Cost")]
		[DisplayName("Поступления")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal Cost { get; set; } //Объект или проект

		[Column(Name = "ProjectName")]
		[DisplayName("Объект")]
		public string ProjectName { get; set; } //Объект или проект
	}
}
