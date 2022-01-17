using DevExpress.DataProcessing;
using DevExpress.XtraPrinting.Native;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;
using SC.Common.Dal;
using SC.Common.Properties;
using SC.Common.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SC.Common.Model
{
	public enum OperationCategory
	{
		[Display(Name = "Другое")] Other = 0,
		[Display(Name = "Аванс")] Avans = 1,
		[Display(Name = "Зарплата")] Paid = 2,
		[Display(Name = "Мед.книжка")] Medbook = 3,
		[Display(Name = "Спец.одежда")] SpecWear = 4,
		[Display(Name = "Отмывки")] Washings = 5,
		[Display(Name = "Премия")] Premium = 6,
		[Display(Name = "Документы")] Docs = 7,
		[Display(Name = "Личное")] Personal = 8,
		[Display(Name = "Химчистка")] ChemCleaner = 9,
		[Display(Name = "Материалы")] Materials = 10,
		[Display(Name = "Командировочные")] Travel = 11,
		[Display(Name = "Комиссия банка")] BankCommission = 12,
		[Display(Name = "Кредит")] Credit = 13,
	}
	public enum OperationStatus
	{
		[Display(Name = "Проведена")] Success = 0,
		[Display(Name = "Отменена")] Rejected = 1,
	}
	public enum OpType { Operation, Input, Cash, ResOp }

	[Table(Name = "Operation")]
	public class COperationDto : IHasID
	{
		public COperationDto() { }
		public static COperationDto Operation(DateTime date, decimal amount, DateTime? month, int? projectId,
			string comment, OperationCategory category,
			CAccountDto fromAcc, CAccountDto toAcc)
		{
			var op = new COperationDto(date, amount, comment, category, month, projectId)
			{
				From_ID = fromAcc?.ID,
				To_ID = toAcc?.ID,
			};
			return op;
		}
		public static COperationDto Cash(DateTime date, decimal amount, DateTime? month, int? projectId, string comment,
			int fromCashId, CAccountDto toAcc)
		{
			var op = new COperationDto(date, amount, comment, OperationCategory.Other, month, projectId)
			{
				FromCash_ID = fromCashId,
				To_ID = toAcc?.ID,
			};
			return op;
		}
		public static COperationDto Commission(COperationDto opMain, decimal amount)
		{
			var comment = $"Коммиссия по операции от {opMain.DateTime:d} на сумму {opMain.Amount:c2}";
			var op = new COperationDto(opMain.DateTime.AddSeconds(1), amount, comment, OperationCategory.Other, opMain.Month, opMain.Project_ID)
			{
				From_ID = opMain.To_ID,
				IsCommissionForOperationId = opMain.ID
			};
			return op;
		}
		public static COperationDto Input(DateTime date, decimal amount, DateTime? month, int? projectId,
			string comment, OperationCategory category,
			CAccountDto fromAccCash, CAccountDto toAcc)
		{
			var op = new COperationDto(date, amount, comment, category, month, projectId)
			{
				FromAccCash_ID = fromAccCash?.ID,
				To_ID = toAcc?.ID,
			};
			return op;
		}
		public static COperationDto ResOp(DateTime date, decimal amount, DateTime? month, int? projectId,
			string comment, OperationCategory category,
			CAccountDto fromAcc, int toResOpId)
		{
			var op = new COperationDto(date, amount, comment, category, month, projectId)
			{
				From_ID = fromAcc?.ID,
				ToResOP_ID = toResOpId,
			};
			return op;
		}

		private COperationDto(DateTime dateCreate, decimal amount, string comment, OperationCategory category,
			DateTime? month, int? projectId)
		{
			DateTime = dateCreate;
			Amount = amount;
			Comment = comment;
			Category = category;
			Month = month;
			Project_ID = projectId;
			User = Environment.UserName;
		}

		[PrimaryKey, Identity]
		[Column] public int ID { get; set; }
		[Column] public int? From_ID { get; set; }
		[Column] public int? FromCash_ID { get; set; }
		[Column] public int? FromAccCash_ID { get; set; }
		[Column] public int? To_ID { get; set; }
		[Column] public int? ToResOP_ID { get; set; }

		[Display(Name = "Дата")]
		[Column] public DateTime DateTime { get; set; }

		[Display(Name = "Сумма")]
		[DisplayFormat(DataFormatString = "c2")]
		[Column] public decimal Amount { get; set; }

		[Display(Name = "Категория")]
		[Column] public OperationCategory Category { get; set; }

		[Display(Name = "Месяц")]
		[DisplayFormat(DataFormatString = "MMMM yyyy")]
		[Column] public DateTime? Month { get; set; }

		[Column] public int? Project_ID { get; set; }
		[Column] public int? IsCommissionForOperationId { get; set; }

		[Display(Name = "Комментарий")]
		[Column] public string Comment { get; set; }

		[Display(Name = "Статус")]
		[Column] public OperationStatus Status { get; set; }
		[Column] public string User { get; set; }
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }
		public (bool isError, string error) Insert(bool checkBalance = true)
		{
			if (Amount == 0) return (true, "Сумма операции равна нулю\nОперация перевода не будет создана.");
			if (DateTime.Date > DateTime.Today) return (true, "Дата операции не может быть больше сегодняшней.\nОперация перевода не будет создана.");

			using (var db = new DbContext())
			{
				if (checkBalance && From_ID != null)
				{
					var fromAcc = db.GetByID<CAccountDto>(From_ID);
					if (fromAcc == null ||
						(!fromAcc.IsPassive && fromAcc.Rest < Amount))
					{
						return (true, "У Вас недостаточно средств");
					}
				}
				ID = db.InsertWithInt32Identity(this);
				dtc = db.GetByID<COperationDto>(ID).dtc;
			}

			if (ToResOP_ID != null) UpdateToResOpSalary(Amount);
			var error = "";
			CRestDayDto.Recalculate(DateTime, From_ID, ref error);
			CRestDayDto.Recalculate(DateTime, To_ID, ref error);
			if (error.NoEmpty()) return (true, "Операция создана, но остатки не сошлись\nОбратитесь к администратору\n" + error);
			SaveHistory();

			return (false, null);
		}
		public (bool isError, string error) Reject()
		{
			using (var db = new DbContext())
			{
				var status = db.GetByID<COperationDto>(ID).Status;
				if (status == OperationStatus.Rejected)
				{
					return (true, "Операция уже отменена");
				}

				Status = OperationStatus.Rejected;
				User = Environment.UserName;

				db.Update(this);

				if (ToResOP_ID != null) UpdateToResOpSalary(-Amount);
				if (FromCash_ID != null)
				{
					var cashOp = db.GetByID<COperationCashDto>(FromCash_ID);
					cashOp.Status = OperationCashStatus.Wait;
					cashOp.AmountToAcc = null;
					db.Update(cashOp);
				}
				var error = "";
				CRestDayDto.Recalculate(DateTime, From_ID, ref error);
				CRestDayDto.Recalculate(DateTime, To_ID, ref error);
				if (error.NoEmpty()) return (true, "Операция отменена, но остатки не сошлись\nОбратитесь к администратору\n" + error);

				SaveHistory();
				return (false, null);
			}
		}
		public (bool isError, string error) Change(COperationDto newOp)
		{
			using (var db = new DbContext())
			{
				newOp.ID = ID;
				newOp.dtc = dtc;
				db.Update(newOp);

				if (newOp.Amount != Amount)
				{
					if (ToResOP_ID != null) UpdateToResOpSalary(newOp.Amount - Amount);
					if (newOp.FromCash_ID != null)
					{
						var opCash = db.GetByID<COperationCashDto>(newOp.FromCash_ID);
						opCash.AmountToAcc = newOp.Amount - Amount;
						db.Update(opCash);
					}
				}

				if (newOp.DateTime != DateTime ||
					newOp.Amount != Amount ||
					newOp.From_ID != From_ID ||
					newOp.To_ID != To_ID)
				{
					var minDate = newOp.DateTime < DateTime ? newOp.DateTime : DateTime;
					var accIds = new[] { From_ID, To_ID, newOp.From_ID, newOp.To_ID }.Distinct();
					var error = "";
					accIds.ForEach(accId => CRestDayDto.Recalculate(minDate, accId, ref error));

					if (error.NoEmpty()) return (true, "Операция изменена, но остатки не сошлись\nОбратитесь к администратору\n" + error);
				}
				newOp.SaveHistory();
				return (false, null);
			}
		}

		private void SaveHistory()
		{
			using (var dbHistory = new HistoryDbContext())
			{
				var operationHistory = MapperService.Map<COperationHistoryDto>(this);
				dbHistory.Insert(operationHistory);
			}
		}
		private void UpdateToResOpSalary(decimal amount)
		{
			if (ToResOP_ID == null) return;
			using (var db = new DbContext())
			{
				var resOp = db.GetByID<CResOPDto>(ToResOP_ID);
				if (resOp != null)
				{
					var unit = new ResOpUnitService().GetUnit(Category);
					if (unit != null)
					{
						var prevValue = unit.Value(resOp);
						unit.Set(resOp, (prevValue ?? 0) + amount);
						var resource = db.GetByID<CResourceDto>(resOp.Resource_ID);

						resOp.User = Environment.UserName;
						resOp.dtu = DateTime.Now;
						resOp.CalculateSalary(resource);
						db.Update(resOp);
					}
				}
			}
		}

		public static void InsertMissingResOps(int managerId)
		{
			using (var db = new DbContext())
			{
				var objIds = db.GetWhere<CObjectDto>(o => o.Status == 0 &&
														  !o.IsDeleted &&
														  o.Manager_ID == managerId)
					.Select(o => o.ID)
					.ToArray();
				var resOps = db.GetWhere<CResOPDto>(r => objIds.Contains(r.Object_ID ?? -1));
				var acc = CAccountDto.GetOrCreate(managerId);
				var existsOps = db.GetWhere<COperationDto>(op => op.From_ID == acc.ID && op.ToResOP_ID != null);

				foreach (var resOp in resOps)
				{
					var paidOp = existsOps.Where(o => o.ToResOP_ID == resOp.ID).Sum(o => o.Amount);
					var paidResOp = (resOp.Avans ?? 0) + (resOp.Paid ?? 0);
					if (paidResOp > paidOp)
					{
						var newOp = ResOp(resOp.Month ?? DateTime.Now, paidResOp - paidOp,
							resOp.Month, db.GetByID<CObjectDto>(resOp.Object_ID)?.Project_ID,
							$"Зарплата за {resOp.Month:MMMM yyyy} (создана автоматически)",
							OperationCategory.Paid, acc, resOp.ID);

						newOp.Insert(false);
					}
				}
			}
		}
		public static int MinusAllRejectResOp()
		{
			TaskbarProgress.Start();
			using (var db = new DbContext())
			{
				var ops = db.GetWhere<COperationDto>(o => o.ToResOP_ID != null &&
														  o.Status == OperationStatus.Rejected);
				var avanceOps = ops.Where(o => o.Category == OperationCategory.Avans).ToArray();
				var paidOps = ops.Where(o => o.Category == OperationCategory.Paid).ToArray();
				var resOps = db.GetTable<CResOPDto>().ToArray();

				var changedCount = 0;
				for (var i = 0; i < resOps.Length; i++)
				{
					var r = resOps[i];
					var avanceSum = avanceOps.Where(o => o.ToResOP_ID == r.ID).Sum(o => o.Amount);
					if (avanceSum > 0)
					{
						r.Avans -= avanceSum;
						db.Update(r);
						changedCount++;
					}

					var paidSum = paidOps.Where(o => o.ToResOP_ID == r.ID).Sum(o => o.Amount);
					if (paidSum > 0)
					{
						r.Paid -= paidSum;
						db.Update(r);
						changedCount++;
					}
					TaskbarProgress.SetValue(i, resOps.Length);
				}
				TaskbarProgress.Finish();

				return changedCount;
			}
		}
		public static int UpdateAllResOp()
		{
			TaskbarProgress.Start();
			using (var db = new DbContext())
			{
				var ops = db.GetWhere<COperationDto>(o => o.ToResOP_ID != null &&
														  o.Status == OperationStatus.Success);
				var avanceOps = ops.Where(o => o.Category == OperationCategory.Avans).ToArray();
				var paidOps = ops.Where(o => o.Category == OperationCategory.Paid).ToArray();
				var resOps = db.GetTable<CResOPDto>().ToArray();
				var closed = db.GetTable<CTabelClosedDto>().ToArray();

				var changedCount = 0;
				for (var i = 0; i < resOps.Length; i++)
				{
					var r = resOps[i];
					if (closed.Any(c => c.Object_ID == r.Object_ID &&
					                    c.Month.Year == r.Month?.Year &&
					                    c.Month.Month == r.Month?.Month))
					{
						continue;
					}

					var avanceSum = avanceOps.Where(o => o.ToResOP_ID == r.ID).Sum(o => o.Amount);
					if (r.Avans < avanceSum || r.Month?.Year >= 2020)
					{
						r.Avans = avanceSum;
						db.Update(r);
						changedCount++;
					}

					var paidSum = paidOps.Where(o => o.ToResOP_ID == r.ID).Sum(o => o.Amount);
					if (r.Paid < paidSum || r.Month?.Year >= 2020)
					{
						r.Paid = paidSum;
						db.Update(r);
						changedCount++;
					}
					TaskbarProgress.SetValue(i, resOps.Length);
				}
				TaskbarProgress.Finish();

				return changedCount;
			}
		}

		public override string ToString() => $"{DateTime:d} {Amount:N2} {(From_ID != null ? "from" : "to")}";
	}

	public class COperation : COperationDto
	{
		[Display(Name = "Расход")]
		[DisplayFormat(DataFormatString = "c2")]
		[Column] public decimal? OutAmount { get; set; }

		[Display(Name = "Кому")]
		[Column] public string ToUser { get; set; }
		[Column] public Role ToRole { get; set; }
		[Column] public string ToLogin { get; set; }

		[Display(Name = "Приход")]
		[DisplayFormat(DataFormatString = "c2")]
		[Column] public decimal? InAmount { get; set; }

		[Display(Name = "От кого")]
		[Column] public string FromUser { get; set; }
		[Column] public Role FromRole { get; set; }
		[Column] public string FromLogin { get; set; }

		[Display(Name = "Проект")]
		[Column] public string ProjectName { get; set; }
		public static COperation[] Factory(int accId, DateTime start, DateTime end)
		{
			using (var db = new DbContext())
			{
				var operations = db.Query<COperation>(Resources.Operations,
						new DataParameter("@accId", accId),
						new DataParameter("@start", start),
						new DataParameter("@end", end))
					.ToArray();

				return operations;
			}
		}
	}
}