using DevExpress.XtraEditors;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using LinqToDB;
using LinqToDB.Data;
using SC.Common.Dal;

namespace SC.Staff.Views
{
	public partial class PageUsers : XtraUserControl
	{
		private bool _isShowPass;
		public PageUsers()
		{
			try
			{
				InitializeComponent();
				UpdateData(_isShowPass);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public void UpdateData(bool isShowPass)
		{
			_isShowPass = isShowPass;
			try
			{
				colPass.ColumnEdit = _isShowPass ? null : riPass;
				var users = CUser.All();
				using (new GridViewStateSaver(gvUsers))
				{
					gcUsers.DataSource = users;
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public void GenPass()
		{
			try
			{
				var users = GetSelectedUsers();
				var question = "Для следующих пользователей будут сгенерированы новые пароли:\n" +
							   string.Join("\n", users.Select(u => $"{u.Login.Trim()} ({u.Name.Trim()})")) +
							   "\n\nПродолжить?";

				if (MessageService.ShowQuestion(question) != DialogResult.Yes) return;

				users.ForEach(u => u.GenPass());
				var usersDto = users.Select(MapperService.Map<CUserDto>).ToArray();
				using (var db = new DbContext())
				{
					usersDto.ForEach(u => db.Update(u));
					//db.BulkCopy(usersDto); - не работает хз почему
				}
				UpdateData(_isShowPass);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public async void SendPassToEmail()
		{
			try
			{
				var users = GetSelectedUsers();
				var success = new List<CUser>();
				var error = new List<CUser>();

				foreach (var user in users)
				{
					try
					{
						await Email.SendPass(user);
						success.Add(user);
					}
					catch
					{
						error.Add(user);
					}
				}
				var message = "";
				if (success.Any())
				{
					message += "Следующим пользователям были успешно отправлены пароли на почту:\n" +
							   string.Join("\n", success.Select(u => $"{u.Login.Trim()} ({u.Name.Trim()})"));
				}
				if (error.Any())
				{
					if (success.Any()) message += "\n\n";
					message += "Следующим пользователям не удалось отправить пароли на почту:\n" +
							  string.Join("\n", error.Select(u => $"{u.Login.Trim()} ({u.Name.Trim()})"));
					MessageService.ShowExclamation(message);
				}
				else
				{
					MessageService.ShowMessage(message);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private List<CUser> GetSelectedUsers()
		{
			var users = new List<CUser>();
			foreach (var row in gvUsers.GetSelectedRows())
			{
				if (gvUsers.GetRow(row) is CUser user) users.Add(user);
			}
			return users;
		}
	}
}
