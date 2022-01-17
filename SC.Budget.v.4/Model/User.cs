using LinqToDB.Mapping;
using SC.Budget.Services;
using SC.Common.Dal;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace SC.Budget.Model
{
	[Table(Name = "User")]
	public class CUserDto
	{
		[PrimaryKey, Identity]
		public int ID { get; set; }


		[Column(Name = "Login")]
		[Required(ErrorMessage = "Не указан логин")]
		public string Login { get; set; }


		[Column(Name = "Pass")]
		[Required(ErrorMessage = "Не указан Пароль")]
		public string Pass { get; set; }


		[Column(Name = "Name")]
		public string Name { get; set; }

		[Column(Name = "Role_ID")]
		public Role Role { get; set; }
		public string RoleName { get; set; }
	}

	public class CUser : CUserDto
	{
		public bool IsRememberLogin { get; set; }
		public bool IsAutoLoginOnStart { get; set; }

		public static CUser GetAutoLoginPass()
		{
			var file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				"SC",
				"AutoLoginPass.xml");

			var res = new XmlRepository<CUser>(file).Load();
			return res;
		}

		public bool TryLogin()
		{
			using (var db = new DbDataContext())
			{
				var user = db.GetTable<CUserDto>()
					.FirstOrDefault(u => u.Login == Login && u.Pass == Pass);

				if (user == null) return false;

				user.RoleName = db.GetTable<CRole>()
					.First(r => r.ID == (int)user.Role)
					.Name;

				ApplicationUser.Instance.User = Adapter.Convert<CUser>(user);

				return true;
			}
		}

		public void SaveAutoLoginPass()
		{
			Pass = Pass.Trim();
			var file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				"SC",
				"AutoLoginPass.xml");

			new XmlRepository<CUser>(file).Save(this);
		}
	}
}
