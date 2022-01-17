using System;
using System.Linq;
using System.Windows.Forms;
using LinqToDB.Data;
using SC.Cash.Sql;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;

namespace SC.Cash.Views
{
	public partial class FrmNewOperation : DevExpress.XtraEditors.XtraForm
	{
		private readonly CUserDto[] _toUsers;
		private readonly OperationCategory[] _categories;
		public FrmNewOperation()
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
								.Where(u => u.Role == Role.Rukovod)
								.OrderBy(u => u.Name)
								.ToArray();
							break;
						}
					case Role.Rukovod:
						{
							var sql = SqlFiles.Get("Managers.sql");
							_toUsers = db.Query<CUserDto>(sql,
									new DataParameter("@rukId", user.ID))
								.ToArray();
							break;
						}
				}

				cbToUser.Properties.Items.Add("Без получателя");
				cbToUser.Properties.Items.AddRange(_toUsers.Select(u => u.Name).ToArray());

				_categories = (OperationCategory[]) Enum.GetValues(typeof(OperationCategory));
				cbCategory.Properties.Items.AddRange(OperationCategoryToString.AllNames);
				cbCategory.SelectedIndex = 0;
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				var amount = decimal.Parse(txtAmount.Text);
				var (isErrorFill, errorFill) = ErrorFillField(amount);
				if (isErrorFill)
				{
					MessageService.ShowError(errorFill);
					return;
				}

				var fromUserId = ApplicationUser.Instance.User.ID;
				var toUserId = cbToUser.SelectedIndex == 0 ? (int?)null : _toUsers[cbToUser.SelectedIndex - 1].ID;
				var category = _categories[cbCategory.SelectedIndex];
				var (isErrorOp, errorOp) = COperationDto.Insert(fromUserId, toUserId, null, amount, txtComment.Text, category, null);

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