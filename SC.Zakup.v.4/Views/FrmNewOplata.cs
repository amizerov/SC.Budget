using LinqToDB;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Windows.Forms;

namespace SC.Zakup.Views
{
	public partial class FrmNewOplata : DevExpress.XtraEditors.XtraForm
	{
		private readonly int _schetId;

		public FrmNewOplata(int schetId)
		{
			try
			{
				InitializeComponent();

				_schetId = schetId;
				deDate.DateTime = DateTime.Now;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				var (isError, error) = IsError();
				if (isError)
				{
					MessageService.ShowError(error);
					return;
				}

				var sum = txtSumma.EditValue.ToDecimal();
				using (var db = new DbContext())
				{
					var Oplata = new COplataDto
					{
						Schet_ID = _schetId,
						Data = deDate.DateTime,
						Summa = sum,
						User = Environment.UserName,
					};
					db.Insert(Oplata);
				}
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private (bool isError, string error) IsError()
		{
			if (txtSumma.EditValue == null || txtSumma.EditValue.Equals(0m))
			{
				return (true, "Не заполнено поле 'Сумма'");
			}
			return (false, "");
		}
	}
}