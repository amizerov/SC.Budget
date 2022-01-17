using DevExpress.XtraEditors;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Windows.Forms;

namespace SC.Budget.Views
{
	public partial class FrmLogin : XtraForm
	{
		private readonly CUser _user;
		public FrmLogin(CUser user)
		{
			InitializeComponent();

			_user = user;
			tbLogin.Text = _user.Login;
			tbPass.Text = _user.Pass;
			checkRememberLogin.Checked = _user.IsRememberLogin;
			checkAutoLoginOnStart.Checked = _user.IsAutoLoginOnStart;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			_user.Login = tbLogin.Text;
			_user.Pass = tbPass.Text;
			_user.IsRememberLogin = checkRememberLogin.Checked;
			_user.IsAutoLoginOnStart = checkAutoLoginOnStart.Checked;

			if (string.IsNullOrEmpty(_user.Login))
			{
				MessageService.ShowError("Логин не может быть пустым");
				return;
			}
			if (string.IsNullOrEmpty(_user.Pass))
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

		private void checkRememberLogin_CheckedChanged(object sender, EventArgs e)
		{
			checkAutoLoginOnStart.Enabled = checkRememberLogin.Checked;
		}
	}
}