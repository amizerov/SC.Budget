using SC.Common.Model;
using SC.Common.Services;
using SwissClean.Dal;
using SwissClean.Dal.Dto;
using System;

namespace SwissClean.MVP.Login
{
	public interface ILoginModel
	{
		event EventHandler<string> Error;
		event EventHandler<LoginViewModel> Updated;
		event EventHandler Logged;
		bool LoginChecked { get; }

		void Update(bool isStartApp);
		void Login(object sender, LoginViewModel viewModel);
		void Login(int id);
	}
	public class LoginModel : ILoginModel
	{
		private readonly IDataAccessService _db;
		private LoginViewModel _vm;

		public bool LoginChecked { get; private set; }

		public LoginModel(IDataAccessService dataAccessService)
		{
			_db = dataAccessService;
		}

		public event EventHandler<LoginViewModel> Updated;
		public event EventHandler Logged;
		public event EventHandler<string> Error;

		public void Update(bool isStartApp)
		{
			_vm = new LoginViewModel { CanLogin = isStartApp };
			var loginPass = _db.GetLoginPassword();
			if (loginPass != null)
			{
				_vm.Login = loginPass.Login;
				_vm.Password = loginPass.Password;
				_vm.IsRemember = loginPass.Login.NoEmpty();
				_vm.IsAutoLoginOnStart = loginPass.Password.NoEmpty();
				if (_vm.IsRemember && _vm.IsAutoLoginOnStart)
				{
					Login(this, _vm);
				}
			}
			Updated?.Invoke(this, _vm);
		}

		public void Login(object sender, LoginViewModel viewModel)
		{
			_vm = viewModel;
			var (isError, error) = ValidateService.Validate(_vm);
			if (isError)
			{
				Error?.Invoke(this, error);
				return;
			}

			var user = _db.GetUser(_vm.Login, _vm.Password);
			if (user != null)
			{
				ApplicationUser.User = user;
				var loginPass = new LoginPassword();
				if (_vm.IsRemember)
				{
					loginPass.Login = _vm.Login;
					if (_vm.IsAutoLoginOnStart) loginPass.Password = _vm.Password;
				}

				_db.SaveLoginPassword(loginPass);
				LoginChecked = true;

				if (_vm.CanLogin)
				{
					Logged?.Invoke(this, EventArgs.Empty);
				}
			}
			else
			{
				ApplicationUser.User = null;
				LoginChecked = false;

				Error?.Invoke(this, "Неверные данные");
			}
		}
		public void Login(int id)
		{
			var user = _db.GetUser(id);
			if (user != null)
			{
				ApplicationUser.User = user;
				LoginChecked = true;
				Logged?.Invoke(this, EventArgs.Empty);
			}
		}
	}
}
