using LinqToDB;
using LinqToDB.Mapping;
using SC.Common.Dal;
using SC.Common.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SC.Common.Model
{
	public enum OperationCashStatus
	{
		[Display(Name = "Ожидает")] Wait = 0,
		[Display(Name = "Рассмотрена")] Completed = 1,
		[Display(Name = "Отменена")] Rejected = 2,
	}

	[Table(Name = "OperationCash")]
	public class COperationCashDto : IHasID
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		[Column] public int Schet_ID { get; set; }

		[Display(Name = "Общая сумма")]
		[Editable(false)]
		[Column] public decimal Amount { get; set; }

		[Display(Name = "В кассу", Description = "Сумма, которая пойдет на Ваш счёт")]
		[Column] public decimal? AmountToAcc { get; set; }

		[Display(Name = "Статус")]
		[Column] public OperationCashStatus Status { get; set; }

		[Display(Name = "Месяц")]
		[DisplayFormat(DataFormatString = "MMMM yyyy")]
		[Column] public DateTime? Month { get; set; }

		[Column] public int? Project_ID { get; set; }
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }

		public static void Insert(int schetId, decimal amount)
		{
			using (var db = new DbContext())
			{
				var existOp = db.GetTable<COperationCashDto>()
					.Where(o => o.Schet_ID == schetId)
					.ToArray();
				amount -= existOp.Sum(s => s.Amount);

				if (amount <= 0) return;

				var op = new COperationCashDto
				{
					Schet_ID = schetId,
					Amount = amount
				};
				db.Insert(op);
			}
		}
	}
}