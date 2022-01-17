using LinqToDB.Mapping;
using SC.Common.Services;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SC.Common.Model
{
	[Table(Name = "ResOP")]
	public class CResOPDto : IHasID
	{
		public CResOPDto() { }
		public CResOPDto(DateTime? month, int? object_ID, int resource_ID)
		{
			Month = month;
			Object_ID = object_ID;
			Resource_ID = resource_ID;
			//Position_ID = position_ID;
		}

		[PrimaryKey, Identity]
		public int ID { get; set; }

		[Column] public DateTime? Month { get; set; }
		[Column] public int Resource_ID { get; set; }
		[Column] public int? Object_ID { get; set; }
		[Column] public int? Project_ID { get; set; }
		[Column] public int Position_ID { get; set; }
		[Column] public string Position { get; set; }
		[Column] public decimal? Avans { get; set; }
		[Column] public decimal? Penalty { get; set; }
		[Column] public decimal? Premium { get; set; }
		[Column] public decimal? MedBook { get; set; }
		[Column] public decimal? SpecWear { get; set; }
		[Column] public decimal? Washings { get; set; }
		[Column] public decimal? Docs { get; set; }
		[Column] public string Comment { get; set; }
		[Column] public int RateDays { get; set; }
		[Column] public int? FactDays { get; set; }
		[Column] public decimal Salary { get; set; }
		[Column] public decimal? FactSalary { get; set; }
		[Column] public decimal? Calculated { get; set; }

		[DisplayName("Выдано")]
		[DisplayFormat(DataFormatString = "N0")]
		[Column] public decimal? Paid { get; set; }

		[Display(Name = "Долг")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal? Debt => FactSalary - Paid;

		[DisplayName("Кем изменён"), Description("Пользователь, внёсший последние изменения в базе данных")]
		[Column] public string User { get; set; }

		[DisplayName("Создан"), Description("Дата создания записи в базе данных")]
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }

		[DisplayName("Изменён"), Description("Дата изменения записи в базе данных")]
		[Column] public DateTime? dtu { get; set; }

		public void CalculateSalary(CResourceDto resource)
		{
			var officialSalary = resource?.OfficialSalary ?? 0;
			var salaryBase = RateDays > 0 ? Salary / RateDays * (FactDays ?? 0) : 0;
			FactSalary = salaryBase
					   - officialSalary
					   - (Avans ?? 0)
					   - (Penalty ?? 0)
					   - (SpecWear ?? 0)
					   - (MedBook ?? 0)
					   - (Washings ?? 0)
					   - (Docs ?? 0)
					   + (Premium ?? 0);

			Calculated = salaryBase + (Premium ?? 0);
		}
	}
}