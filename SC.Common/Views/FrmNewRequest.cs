using DevExpress.Utils.Extensions;
using LinqToDB;
using LinqToDB.Data;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Properties;
using SC.Common.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SC.Common.Views
{
	public partial class FrmNewRequest : DevExpress.XtraEditors.XtraForm
	{
		private readonly CUserDto[] _bosses;

		public FrmNewRequest()
		{
			try
			{
				InitializeComponent();

				using (var db = new DbContext())
				{
					var user = ApplicationUser.User;
					var userId = user?.ID ?? -1;
					cbProject.Properties.Items.AddRange(db.AllNames<CProjectDto>(p => !p.IsDeleted));
					_bosses = db.Query<CUserDto>(Resources.Bosses,
						new DataParameter("@userId", userId))
						.ToArray();
					if (_bosses.All(b => b.Email.IsEmpty()))
					{
						chbSendEmail.Text += "\n(у получателей не указана почта в базе данных)";
						chbSendEmail.Enabled = false;
					}
				}
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
				if (txtAmount.Text.IsEmpty())
				{
					MessageService.ShowError("Не заполнено поле 'Сумма'");
					return;
				}
				using (var db = new DbContext())
				{
					var amount = txtAmount.Text.ToDecimal();
					var user = ApplicationUser.User;
					var month = deMonth.EditValue as DateTime?;
					var projectId = db.GetID<CProjectDto>(cbProject.Text);

					var request = new CRequestOpDto(user, DateTime.Now, amount, month, projectId, txtComment.Text);

					db.Insert(request);

					if (chbSendEmail.Checked)
					{
						_bosses.ForEach(boss =>
						{
							if (boss.Login.NoEmpty())
							{
								try
								{
									Email.SendRequestOp(boss.Email, user, request).GetAwaiter();
								}
								catch (Exception exception)
								{
									MessageService.ShowError(exception.ToString());
								}
							}
						});
					}
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