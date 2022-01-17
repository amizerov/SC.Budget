using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using SC.Common.Model;
using SC.Common.Services;

namespace SC.Common.Views
{
	public partial class FrmChangeEncryptPassword : DevExpress.XtraEditors.XtraForm
	{
		private readonly string _encrypted;

		public FrmChangeEncryptPassword(string encrypted)
		{
			_encrypted = encrypted;
			try
			{
				InitializeComponent();

				lbPrevViewValue.Text = encrypted;

				lbInfo.Visible =
				lbOldPass.Visible =
				txtOldPass.Visible =
				lbPrevViewTitle.Visible =
				lbPrevViewValue.Visible = encrypted.NoEmpty();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public string OldPassword => txtOldPass.Text;
		public string NewPassword => txtNewPass.Text;
		private void txtOldPass_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				var oldPass = txtOldPass.EditValue as string;
				if (oldPass.IsEmpty())
				{
					lbPrevViewValue.Text = _encrypted;
					return;
				}
				var cryptor = new CryptorService(oldPass);
				lbPrevViewValue.Text = cryptor.Decrypt(_encrypted);
			}
			catch (FormatException)
			{
				MessageService.ShowError("При расшифровке произошла ошибка.\n" +
				                         "Убедитесь, что содержимое было предварительно зашифровано паролем и повторите попытку");
				txtOldPass.EditValue = "";
			}
			catch (CryptographicException)
			{
				MessageService.ShowError("Не удалось расшифровать текст");
				txtOldPass.EditValue = "";
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
				txtOldPass.EditValue = "";
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtNewPass.Text.IsEmpty())
				{
					MessageService.ShowError("Убедитесь, что поле 'Новый пароль' заполнено и повторите попытку.");
					return;
				}
				if (txtNewPass.Text != txtNewPassConfirm.Text)
				{
					MessageService.ShowError("Убедитесь, что новый пароль и подтверждение пароля совпадают и повторите попытку.");
					return;
				}

				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}