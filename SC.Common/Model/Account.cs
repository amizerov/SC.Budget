using LinqToDB;
using LinqToDB.Mapping;
using SC.Common.Dal;
using SC.Common.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace SC.Common.Model
{
	[Table(Name = "Account")]
	public class CAccountDto : IHasID
	{
		public enum AccStatus { Active, Close }

		public CAccountDto() { }
		public static CAccountDto GetOrCreate(int? userId)
		{
			if (userId == null) return null;
			using (var db = new DbContext())
			{
				var acc = db.FirstOrDefault<CAccountDto>(a => a.User_ID == userId);
				if (acc != null) return acc;

				acc = new CAccountDto { User_ID = (int)userId };
				acc.ID = db.InsertWithInt32Identity(acc);
				return acc;
			}
		}

		[PrimaryKey, Identity]
		public int ID { get; set; }
		[Column] public int User_ID { get; set; }
		[Column] public decimal Rest { get; set; }
		[Column] public bool IsPassive { get; set; }
		[Column] public string NameForPassive { get; set; }
		[Column] public AccStatus Status { get; set; }
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }
	}

	public class CAccount : CAccountDto
	{
		[Display(Name = "Аккаунт")]
		[Column] public string UserName { get; set; }
		[Column] public Role Role { get; set; }
		[Column] public string Login { get; set; }

		[Display(Name = "Входящий остаток")]
		[DisplayFormat(DataFormatString = "c2")]
		[Column] public decimal Rest_In { get; set; }

		[Display(Name = "Расход")]
		[DisplayFormat(DataFormatString = "c2")]
		[Column] public decimal OutAmount { get; set; }

		[Display(Name = "Приход")]
		[DisplayFormat(DataFormatString = "c2")]
		[Column] public decimal InAmount { get; set; }

		[Display(Name = "Исходящий остаток")]
		[DisplayFormat(DataFormatString = "c2")]
		[Column] public decimal Rest_Out { get; set; }

		[Display(Name = "Долг")]
		[DisplayFormat(DataFormatString = "c2")]
		[Column] public decimal? Debt { get; set; }

		[Display(Name = "Начислено")]
		[DisplayFormat(DataFormatString = "c2")]
		[Column] public decimal? SalaryCalculated { get; set; }
	}
}