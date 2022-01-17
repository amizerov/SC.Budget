using LinqToDB.Mapping;
using SC.Common.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SC.Budget.Model
{
	public class CResOP : CResOPDto
	{

		[DisplayName("Объект")]
		[Column] public string ObjectName { get; set; } //Объект или проект


		[DisplayName("Начислено")]
		[DisplayFormat(DataFormatString = "N0")]

		public decimal TotalCalculated => (Calculated ?? 0) + (Avans ?? 0);
		public decimal TotalPaid => (Paid ?? 0) + (Avans ?? 0);
	}

	public class ResOPForKPI : CResOPDto
	{
		[Column] public Role Role_ID { get; set; }
		[Column] public int? User_ID { get; set; }
		[Column] public decimal OfficialSalary { get; set; }
	}
}
