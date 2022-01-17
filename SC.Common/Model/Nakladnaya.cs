using LinqToDB.Mapping;
using SC.Common.Services;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LinqToDB;
using SC.Common.Dal;
using System.Linq;
using LinqToDB.Common;
using LinqToDB.Data;

namespace SC.Common.Model
{
	[Table("Nakladnaya")]
	public class CNakladnayaDto : IHasID
	{
		[PrimaryKey, Identity] public int ID { get; set; }

		[DisplayName("Дата")]
		[Column] public DateTime DocDate { get; set; }

		[DisplayName("Номер")]
		[Column] public string DocNumber { get; set; }
		[Column] public int? Object_ID { get; set; }
		[Column] public int? FromObject_ID { get; set; }
		[Column] public int Status { get; set; }
		[Column] public string Sklad1C { get; set; }
		[Column] public string User { get; set; }
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }
	}

	public class CNakladnaya : CNakladnayaDto
	{
		[DisplayName("Контрагент")]
		[Column] public string Kontragent { get; set; }

		[DisplayName("Организация")]
		[Column] public string FirmaName { get; set; }

		[DisplayName("С проекта")]
		[Column] public string FromProjectName { get; set; }

		[DisplayName("С объекта")]
		[Column] public string FromObjectName { get; set; }
		[DisplayName("На проект")]
		[Column] public string ProjectName { get; set; }

		[DisplayName("На объект")]
		[Column] public string ObjectName { get; set; }

		[DisplayName("Позиций")]
		[Column] public int PosiitionCount { get; set; }

		[DisplayFormat(DataFormatString = "c2")]
		[Display(Name = "Сумма")]
		[Column] public decimal Cost { get; set; }
		[Display(Name = "Доп.расходы", Description = "Дополнительные расходы, связанные с товаром")]
		[DisplayFormat(DataFormatString = "c2")]
		[Column] public decimal? CostAdditional { get; set; }

		[Display(Name = "Итоговая сумма")]
		[DisplayFormat(DataFormatString = "c2")]
		public decimal CostTotal => Cost + (CostAdditional ?? 0);

		public void Delete()
		{
			using (var db = new DbContext())
			{
				var lines = db.GetWhere<CNakladLineDto>(l => l.Naklad_ID == ID && l.dtc > DocDate);
				foreach (var line in lines)
				{
					db.GetTable<CNakladLineDto>()
						.Where(l => l.Postup_ID == line.Postup_ID)
						.Where(l => l.dtc > DocDate)
						.Delete();
					db.DeleteById<CNakladLineDto>(line.ID);
				}
				db.DeleteById<CNakladnayaDto>(ID);
			}
		}

		public static void DeleteEmpties()
		{
			using (var db = new DbContext())
			{
				db.Execute(Properties.Resources.DeleteEmptyNaklads);
			}
		}
	}
}
