using DevExpress.SpreadsheetSource.Implementation;
using LinqToDB.Mapping;
using SC.Common.Services;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SC.Common.Model
{
	[Table("Nomenklatura")]
	public class CNomenklaturaDto : IHasID, IHasName
	{
		[PrimaryKey, Identity]
		public int ID { get; set; }

		[Display(Name = "Наименование")]
		[Column] public string Name { get; set; }
		 
		[Display(Name = "Кем изменён"), Description("Пользователь, внёсший последние изменения в базе данных")]
		[Column] public string User { get; set; }

		[Display(Name = "Создан"), Description("Дата создания записи в базе данных")]
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }

		[Display(Name = "Изменён"), Description("Дата изменения записи в базе данных")]
		[Column] public DateTime? dtu { get; set; }
	}
}
