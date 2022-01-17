using LinqToDB;
using LinqToDB.Mapping;
using SC.Common.Dal;
using SC.Common.Services;
using System;
using System.Linq;

namespace SC.Common.Model
{
	[Table(Name = "RestDay")]
	public class CRestDayDto
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		[Column] public DateTime Day { get; set; }
		[Column] public int Acc_ID { get; set; }
		[Column] public decimal Rest_In { get; set; }
		[Column] public decimal InAmount { get; set; }
		[Column] public decimal OutAmount { get; set; }

		public static void Recalculate(DateTime start, int? accId, ref string error, int recalcCount = 0)
		{
			if (accId == null) return;
			start = start.Date;
			using (var db = new DbContext())
			{
				var inOps = db.GetTable<COperationDto>()
					.Where(o => o.To_ID != null && o.To_ID == accId.Value)
					.Where(o => o.DateTime.Date >= start)
					.Where(o => o.Status == OperationStatus.Success)
					//.OrderBy(o => o.DateTime) //для отладки
					.ToArray();
				var outOps = db.GetTable<COperationDto>()
					.Where(o => o.From_ID != null && o.From_ID == accId.Value)
					.Where(o => o.DateTime.Date >= start)
					.Where(o => o.Status == OperationStatus.Success)
					//.OrderBy(o => o.DateTime) //для отладки
					.ToArray();

				var lastRestDay = LastRestDay(start, accId);
				var rest = lastRestDay == null ? 0
					: lastRestDay.Day == start.Date ? lastRestDay.Rest_In
					: lastRestDay.Rest_In + lastRestDay.InAmount - lastRestDay.OutAmount;

				db.GetTable<CRestDayDto>()
					.Where(r => r.Acc_ID == accId.Value)
					.Where(r => r.Day >= start)
					.Delete();

				var days = DateService.Days(start.Date, DateTime.Today);
				foreach (var day in days)
				{
#if DEBUG
					//if (day == new DateTime(2020, 2, 4)) { }
#endif
					var outAmount = outOps.Where(o => o.DateTime.Date == day).Sum(o => o.Amount);
					var inAmount = inOps.Where(o => o.DateTime.Date == day).Sum(o => o.Amount);

					if (outAmount > 0 || inAmount > 0)
					{
						var restDay = new CRestDayDto
						{
							Acc_ID = accId.Value,
							Day = day,
							Rest_In = rest,
							InAmount = inAmount,
							OutAmount = outAmount,
						};
						db.Insert(restDay);
						rest += inAmount - outAmount;
					}
				}

				var totalRest = db.GetTable<CRestDayDto>()
					.Where(r => r.Acc_ID == accId)
					.Sum(r => r.InAmount - r.OutAmount);
				db.GetTable<CAccountDto>()
					.Where(a => a.ID == accId)
					.Set(a => a.Rest, totalRest)
					.Update();

				if (rest != totalRest)
				{
					if (recalcCount <= 5) Recalculate(new DateTime(2019, 1, 1), accId, ref error, ++recalcCount);
					else error += $"accId: {accId} start:{start:d} rest: {rest:N2} totalRest: {totalRest:N2}";
				}
			}
		}

		public static CRestDayDto LastRestDay(DateTime start, int? accId)
		{
			using (var db = new DbContext())
			{
				var res = db.GetTable<CRestDayDto>()
						.Where(r => r.Acc_ID == accId.Value)
						.Where(r => r.Day <= start)
						.OrderByDescending(r => r.Day)
						.FirstOrDefault();
				return res;
			}
		}
	}
}
