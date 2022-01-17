using System;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using SC.Common.Model;
using SC.Common.Services;
using SC.Common.Views;

namespace SC.Staff.Views
{
	public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		private Control _selectedPage;

		public FrmMain()
		{
			try
			{
				InitializeComponent();
				LayoutSaver.Restore(this);
				lbVersion.Caption = "Версия: " + Application.ProductVersion;

				Reload();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void Reload()
		{
			UpdateLogin();
			UpdateSelectedPage(this, EventArgs.Empty);
		}
		private void UpdateSelectedPage(object sender, EventArgs e)
		{
			if (ribbon.SelectedPage == rpUsers)
			{
				ShowPage(pageUsers);
				UpdateUsers();
			}
		}
		private void UpdateSelectedPage(object sender, ItemClickEventArgs e) => UpdateSelectedPage(sender, EventArgs.Empty);
		private void ShowPage(Control page)
		{
			try
			{
				Control[] pages = { pageUsers };
				pages.ForEach(p => p.Visible = p == page);
				if (page != null)
				{
					_selectedPage = page;
					page.Dock = DockStyle.Fill;
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void UpdateUsers()
		{
			pageUsers.UpdateData(btIsShowPass.Down);
		}

		#region Авторизация
		private void UpdateLogin()
		{
			var user = ApplicationUser.User;

			btnLogin.Visibility = user != null ? BarItemVisibility.Never : BarItemVisibility.Always;
			btnLogout.Visibility = user == null ? BarItemVisibility.Never : BarItemVisibility.Always;
			ribbon.Enabled = user != null;

			if (user == null)
			{
				lbUserProfile.Caption = "Вход не выполнен";
				return;
			}

			lbUserProfile.Caption = $"Пользователь: {user.Login.Trim()} / {user.Name.Trim()} / {user.RoleName.Trim()}";
		}
		private void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				var user = CUser.GetAutoLoginPass();
				using (var form = new FrmLogin(user))
				{
					if (form.ShowDialog() == DialogResult.OK)
					{
						Reload();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				var question = "Вы действительно хотите выйти из профиля?";
				if (MessageService.ShowQuestion(question) == DialogResult.Yes)
				{
					ApplicationUser.User = null;
					Reload();
					btnLogin_ItemClick(this, e);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		#endregion

		private void btGenPass_ItemClick(object sender, ItemClickEventArgs e)
		{
			pageUsers.GenPass();
		}

		private void btSendPassToEmail_ItemClick(object sender, ItemClickEventArgs e)
		{
			pageUsers.SendPassToEmail();
		}

		private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				LayoutSaver.Save(this);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btResetSettings_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				var question = "Настройки экрана будут сброшены.\nПродолжить?";
				if (MessageService.ShowQuestion(question) == DialogResult.Yes)
				{
					LayoutSaver.Reset();
					MessageService.ShowMessage("Настройки экрана сброшены.\nИзменения вступят после перезапуска приложения.");
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}
