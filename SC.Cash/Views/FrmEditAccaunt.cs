using DevExpress.XtraEditors;
using LinqToDB;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Windows.Forms;

namespace SC.Cash.Views
{
	public partial class FrmEditAccaunt : XtraForm
	{
		private CAccountDto _acc;

		public FrmEditAccaunt(CAccountDto acc = null)
		{
			_acc = acc;
			try
			{
				InitializeComponent();

				Text = _acc == null ? "Новый счёт" : "Редактироваание счёта";

				txtName.Text = _acc?.NameForPassive;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				var user = ApplicationUser.User;
				if (user == null) return;
				if (txtName.Text.IsEmpty())
				{
					MessageService.ShowMessage("Убедитесь, что Вы ввели имя.");
					return;
				}
				using (var db = new DbContext())
				{
					if (_acc == null)
					{
						_acc = new CAccountDto
						{
							IsPassive = true,
							NameForPassive = txtName.Text,
							User_ID = user.ID,
						};
						db.Insert(_acc);
					}
					else
					{
						_acc.NameForPassive = txtName.Text;
						db.Update(_acc);
					}

					DialogResult = DialogResult.OK;
					Close();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}