using LinqToDB.Mapping;
using System;
using System.ComponentModel.DataAnnotations;

namespace SC.Cash.Model
{
	public class CDebt
	{
		[Display(Name = "Руководитель проекта")]
		[Column] public string RukovodName { get; set; }
		[Column] public int Project_ID { get; set; }

		[Display(Name = "Проект")]
		[Column] public string ProjectName { get; set; }
		[Column] public int Object_ID { get; set; }

		[Display(Name = "Менеджер")]
		[Column] public string ManagerName { get; set; }

		[Display(Name = "Объект")]
		[Column] public string ObjectName { get; set; }

		[Display(Name = "Месяц")]
		[DisplayFormat(DataFormatString = "MMMM yyyy")]
		[Column] public DateTime Month { get; set; }

		[Display(Name = "Долг")]
		[DisplayFormat(DataFormatString = "с2")]
		[Column] public decimal Debt { get; set; }

		[Display(Name = "Начислено")]
		[DisplayFormat(DataFormatString = "с2")]
		[Column] public decimal Calculated { get; set; }
	}
}
