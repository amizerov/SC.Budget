using LinqToDB.Data;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Linq;
using System.Windows.Forms;
using SC.Cash.Properties;

namespace SC.Cash.Views
{
	public partial class FrmNewAmountIn : DevExpress.XtraEditors.XtraForm
	{
		private readonly CUserDto[] _toUsers;

		public FrmNewAmountIn()
		{
			InitializeComponent();

			var user = ApplicationUser.Instance.User;
			using (var db = new DbDataContext())
			{
				switch (user.Role)
				{
					case Role.Admin:
						{
							_toUsers = db.GetTable<CUserDto>()
								.Where(u => !string.IsNullOrEmpty(u.Name))
								.OrderBy(u => u.Name)
								.ToArray();
							break;
						}
					case Role.Director:
						{
							_toUsers = db.GetTable<CUserDto>()
								.Where(u => u.ID == user.ID || u.Role == Role.Rukovod)
								.OrderBy(u => u.Name)
								.ToArray();
							break;
						}
					case Role.Rukovod:
						{
							_toUsers = db.Query<CUserDto>(Resources.Managers,
									new DataParameter("@rukId", user.ID))
								.ToArray();
							break;
						}
				}

				cbToUser.Properties.Items.AddRange(_toUsers.Select(u => u.Name).ToArray());
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				var amount = txtAmount.Text.ToDecimal();
				var (isErrorFill, errorFill) = ErrorFillField(amount);
				if (isErrorFill)
				{
					MessageService.ShowError(errorFill);
					return;
				}

				var toUserId = _toUsers[cbToUser.SelectedIndex].ID;
				var (isErrorOp, errorOp) = COperationDto.Insert(DateTime.Now, null,
						toUserId, null, amount, txtComment.Text, 0, null);

				if (isErrorOp)
				{
					MessageService.ShowError(errorOp);
					return;
				}
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageService.ShowError(ex.ToString());
			}
		}

		private (bool isError, string error) ErrorFillField(decimal amount)
		{
			if (cbToUser.SelectedIndex < 0) return (true, "Не заполнено поле 'Кому'");
			if (amount <= 0) return (true, "Не заполнено поле 'Сумма'");
			return (false, null);
		}
	}
}