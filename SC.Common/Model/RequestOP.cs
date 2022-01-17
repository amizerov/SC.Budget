using LinqToDB.Data;
using LinqToDB.Mapping;
using SC.Common.Dal;
using SC.Common.Properties;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SC.Common.Model
{
	public enum RequestStatus
	{
		[Display(Name = "Нет статуса")] None = 0,
		[Display(Name = "На рассмотрении")] Wait = 1,
		[Display(Name = "Согласовано")] Agreed = 2,
		[Display(Name = "Отклонено")] Rejected = 3,
		[Display(Name = "Деньги выданы")] Paid = 4
	}

	[Table(Name = "RequestOP")]
	public class CRequestOpDto
	{
		public CRequestOpDto() { }
		public CRequestOpDto(CUserDto user, DateTime dateTime, decimal amount, DateTime? month, int? projectId, string comment)
		{
			User_ID = user.ID;
			DateTime = dateTime;
			Amount = amount;
			Month = month;
			Project_ID = projectId;
			Comment = comment;
			Status = RequestStatus.Wait;
		}

		public static CRequestOp Last(CUserDto user)
		{
			if (user == null) return new CRequestOp();

			using (var db = new DbContext())
			{
				var request = db.Query<CRequestOp>(Resources.LastRequest_Out,
						new DataParameter("@userId", user.ID))
					.FirstOrDefault();

				return request ?? new CRequestOp(user);
			}
		}

		[PrimaryKey, Identity]
		public int ID { get; set; }
		[Column] public int User_ID { get; set; }

		[Display(Name = "Дата")]
		[Column] public DateTime DateTime { get; set; }

		[Display(Name = "Запрошено")]
		[DisplayFormat(DataFormatString = "c2")]
		[Column] public decimal Amount { get; set; }

		[Display(Name = "Выдано")]
		[DisplayFormat(DataFormatString = "c2")]
		[Column] public decimal? Paid { get; set; }

		[Display(Name = "Статус")]
		[Column] public RequestStatus Status { get; set; }

		[Display(Name = "Месяц")]
		[DisplayFormat(DataFormatString = "MMMM yyyy")]
		[Column] public DateTime? Month { get; set; }

		[Column] public int? Project_ID { get; set; }

		[Display(Name = "Комментарий")]
		[Column] public string Comment { get; set; }
	}

	public class CRequestOp : CRequestOpDto
	{
		public CRequestOp() { }
		public CRequestOp(CUserDto user)
		{
			User_ID = user?.ID ?? 0;
		}

		[Column(Name = "UserName")]
		[Display(Name = "От кого")]
		public string UserName { get; set; }

		[Display(Name = "Проект")]
		[Column] public string ProjectName { get; set; }

		[Display(Name = "Не выдано")]
		[DisplayFormat(DataFormatString = "c2")]
		public decimal? Rest => Amount - Paid;

		public bool Editable => Status != RequestStatus.Paid && Status != RequestStatus.Rejected;
	}
}