using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LinqToDB;
using LinqToDB.Data;
using SC.Cash.Sql;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;

namespace SC.Cash.Views
{
	public partial class CreateRequestView : DevExpress.XtraEditors.XtraForm
	{
		private CUserDto[] _bosses;

		public CreateRequestView()
		{
			try
			{
				InitializeComponent();

				using (var db = new DbDataContext())
				{
					var user = ApplicationUser.Instance.User;
					var userId = user?.ID ?? -1;
					_bosses = db.Query<CUserDto>(SqlFiles.Get("Bosses.sql"),
						new DataParameter("@userId", userId))
						.ToArray();
					if (_bosses.All(b => string.IsNullOrEmpty(b.Email)))
					{
						chbSendEmail.ToolTip = "У получателей не указана почта в базе данных";
						chbSendEmail.Enabled = false;
					}
				}
			}
			catch (Exception ex)
			{
				MessageService.ShowError(ex.ToString());
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(txtAmount.Text))
				{
					MessageService.ShowError("Не заполнено поле 'Сумма'");
					return;
				}

				var amount = txtAmount.Text.ToDecimal();
				var user = ApplicationUser.Instance.User;
				var request = new CRequestOP(user, DateTime.Now, amount, txtComment.Text);

				using (var db = new DbDataContext())
				{
					db.Insert(request);
				}

				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageService.ShowError(ex.ToString());
			}
		}
	}
}