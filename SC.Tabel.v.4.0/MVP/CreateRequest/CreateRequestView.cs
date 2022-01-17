using SC.Common.Model;
using SwissClean.Dal;
using SwissClean.Services.UI;
using System;
using System.Windows.Forms;
using SC.Common.Services;
using SwissClean.Services;

namespace SwissClean.MVP.CreateRequest
{
	public partial class CreateRequestView : DevExpress.XtraEditors.XtraForm
	{
		public CreateRequestView()
		{
			InitializeComponent();
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
				var request = new CRequestOP(user, DateTime.Now, amount, txtComment.Text)
				{
					Status = RequestStatus.Wait
				};

				new DataAccessService().SaveRequestOp(request);

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