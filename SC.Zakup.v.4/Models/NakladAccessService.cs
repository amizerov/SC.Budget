using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.Data;
using SC.Common.Dal;
using SC.Common.Model;

namespace SC.Zakup.Models
{
	public class NakladAccessService
	{
		private Common.Model.CNakladnaya _naklad;
		/// <summary>Сообщение в случае отказа</summary>
		public string Message { get; private set; }
		public bool IsAccess(Common.Model.CNakladnaya naklad)
		{
			if (naklad == null)
			{
				Message = "Накладная не выбрана.";
				return false;
			}
			_naklad = naklad;
			Message = null;
			var checks = new Dictionary<Role, CheckBuilder>
			{
				[Role.Admin] = If(Send),
				[Role.ManagerZakup] = If(From1C).ThenIf(EditableDate).ThenIf(Send),
				[Role.Kladovshchik] = If(From1C).ThenIf(EditableDate).ThenIf(Send),
			};

			var user = ApplicationUser.User;
			if (user == null || !checks.ContainsKey(user.Role))
			{
				Message = "У Вас нет доступа.\n" +
				          "Для редактирования обратитесь к администратору";
				return false;
			}
			foreach (var check in checks[user.Role].Checks)
			{
				var access = check.Invoke();
				if (!access) return false;
			}
			return true;
		}

		private bool From1C()
		{
			var access = _naklad.FromObject_ID != null;
			if (!access)
			{
				Message += "Редактирование накладной, загруженной из 1С, невозможно.\n" +
						  "Для редактирования обратитесь к администратору";
			}
			return access;
		}
		private bool EditableDate()
		{
			var endEditDate = AppSettings.EditableDate;
			var access = _naklad.DocDate > endEditDate;
			if (!access)
			{
				Message += $"Редактирование накладной, созданной ранее {endEditDate:d}, невозможно.\n" +
				          "Для редактирования обратитесь к администратору";
			}
			return access;
		}
		private bool Send()
		{
			using (var db = new DbContext())
			{
				var access = !db.Query<bool>(Properties.Resources.IsSendNaklad,
					new DataParameter("@nakladId", _naklad.ID))
					.FirstOrDefault();
				if (!access)
				{
					Message += "В накладной присутствуют поступления, которые уже разнесены по другим объектам\n" +
							  "Редактирование накладной невозможно.\n";
				}
				return access;
			}
		}
		/// <summary>Начинает проверку</summary>
		private CheckBuilder If(Func<bool> check) => new CheckBuilder(check);

		/// <summary>
		/// Беглый строитель проверки
		/// (Fluent Builder Pattern https://metanit.com/sharp/patterns/6.1.php)
		/// </summary>
		private class CheckBuilder
		{
			/// <summary>Цепочка проверки</summary>
			public List<Func<bool>> Checks { get; } = new List<Func<bool>>();

			/// <summary>Беглый строитель проверки</summary>
			public CheckBuilder(Func<bool> check)
			{
				Checks.Add(check);
			}
			/// <summary>Продолжает проверку</summary>
			public CheckBuilder ThenIf(Func<bool> check)
			{
				Checks.Add(check);
				return this;
			}
		}
	}
}
