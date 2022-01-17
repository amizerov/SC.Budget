using DevExpress.XtraEditors;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SC.Common.Views
{
	public partial class FrmLogin : XtraForm
	{
		private CUser _user;
		private List<CUser> _users;
		private bool _updating;

		public FrmLogin(CUser user)
		{
			try
			{
				_updating = true;

				InitializeComponent();

				_user = user;

				Reload();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
			finally
			{
				_updating = false;
			}
		}

		protected void Reload()
		{
			_users = CUser.GetAutoLoginsPass();
			cbLogins.Properties.Items.Clear();
			cbLogins.Properties.Items.AddRange(_users.Select(u => u.Login).ToArray());

			cbLogins.Text = _user.Login;
			tbPass.Text = _user.Pass;
			checkRememberLogin.Checked = _user.IsRememberLogin;
			checkAutoLoginOnStart.Checked = _user.IsAutoLoginOnStart;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				_user.Login = cbLogins.Text;
				_user.Pass = tbPass.Text;
				_user.IsRememberLogin = checkRememberLogin.Checked;
				_user.IsAutoLoginOnStart = checkAutoLoginOnStart.Checked;

				if (_user.Login.IsEmpty())
				{
					MessageService.ShowError("Логин не может быть пустым");
					return;
				}
				if (_user.Pass.IsEmpty())
				{
					MessageService.ShowError("Пароль не может быть пустым");
					return;
				}

				if (_user.TryLogin())
				{
					_user.SaveAutoLoginPass();
					DialogResult = DialogResult.OK;
					Close();
				}
				else
				{
					MessageService.ShowError("Неверный логин или пароль.");
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void checkRememberLogin_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				checkAutoLoginOnStart.Enabled = checkRememberLogin.Checked;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void cbLogins_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (_updating) return;
				btDeleteLogin.Enabled = _users.Any(u => u.Login == cbLogins.Text);

				if (cbLogins.SelectedIndex < 0) return;
				_user = _users[cbLogins.SelectedIndex];
				Reload();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btDeleteLogin_Click(object sender, EventArgs e)
		{
			try
			{
				CUser.DeleteAutoLoginPass(cbLogins.Text);
				Reload();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}