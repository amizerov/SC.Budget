using DevExpress.XtraEditors;
using SC.Common.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SC.Common.Services;

namespace SC.Zakup.Views
{
	public partial class FrmSelectExcelSheetForNalog : XtraForm
	{
		public FrmSelectExcelSheetForNalog(List<string> sheets)
		{
			try
			{
				InitializeComponent();

				cbExcelSheet.Properties.Items.AddRange(sheets);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public string Sheet => cbExcelSheet.Text;
		public DateTime? Month => deMonth.EditValue as DateTime?;

		private void cbExcelSheet_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				var sheetLow = Sheet.ToLower();
				var month = sheetLow.Contains("январь") ? 1
					: sheetLow.Contains("февраль") ? 2
					: sheetLow.Contains("март") ? 3
					: sheetLow.Contains("апрель") ? 4
					: sheetLow.Contains("май") ? 5
					: sheetLow.Contains("июнь") ? 6
					: sheetLow.Contains("июль") ? 7
					: sheetLow.Contains("август") ? 8
					: sheetLow.Contains("сентябрь") ? 9
					: sheetLow.Contains("октябрь") ? 10
					: sheetLow.Contains("ноябрь") ? 11
					: sheetLow.Contains("декабрь") ? 12
					: -1;
				if (month == -1)
				{
					deMonth.EditValue = null;
					return;
				}

				var year = 2100;
				while (!Sheet.Contains(year.ToString()) && year > 2019) year--;

				deMonth.EditValue = new DateTime(year, month, 1);
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
				if (Sheet.IsEmpty() || Month == null)
				{
					MessageService.ShowError("Не все поля заполнены");
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