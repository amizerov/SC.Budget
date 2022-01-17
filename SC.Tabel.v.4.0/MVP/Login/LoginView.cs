using am.BL;
using DevExpress.XtraEditors;
using SC.Common.Services;
using System;

namespace SwissClean.MVP.Login
{
	public interface ILoginView : IView
	{
		event EventHandler<LoginViewModel> Logging;
		void Update(LoginViewModel viewModel = null);
	}
	public partial class LoginView : XtraForm, ILoginView
	{
		private bool _updating;
		private LoginViewModel _vm;
		public LoginView()
		{
			InitializeComponent();
			G.OnError += error => ShowError($"Ошибка в базе данных:\n{error}");
		}
		public event EventHandler<LoginViewModel> Logging;

		public void Update(LoginViewModel viewModel = null)
		{
			try
			{
				_updating = true;
				if (viewModel != null) _vm = viewModel;
				tbLogin.Text = _vm.Login;
				tbPass.Text = _vm.Password;
				checkRemember.Checked = checkAutoLoginOnStart.Enabled = _vm.IsRemember;
				checkAutoLoginOnStart.Checked = _vm.IsAutoLoginOnStart;
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
			finally
			{
				_updating = false;
			}
		}
		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				_vm.CanLogin = true;
				Logging?.Invoke(this, _vm);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}

		private void checkRemember_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (_updating) return;
				_vm.IsRemember = checkRemember.Checked;
				Update();
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void CheckAutoLoginOnStart_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (_updating) return;
				_vm.IsAutoLoginOnStart = checkAutoLoginOnStart.Checked;
				Update();
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}

		private void TbLogin_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (_updating) return;
				_vm.Login = tbLogin.Text?.Trim();
				Update();
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}

		private void TbPass_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (_updating) return;
				_vm.Password = tbPass.Text?.Trim();
				Update();
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
		public void ShowError(string error)
		{
			if (Disposing || IsDisposed) return;
			MessageService.ShowError(error);
		}
	}
}