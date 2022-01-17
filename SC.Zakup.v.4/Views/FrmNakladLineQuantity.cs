using SC.Common.Model;
using System;
using System.Windows.Forms;
using SC.Common.Services;

namespace SC.Zakup.Views
{
	public partial class FrmNakladLineQuantity : DevExpress.XtraEditors.XtraForm
	{
		private readonly int _maxQuantity;
		public FrmNakladLineQuantity(CNakladLine fromObjLine, CNakladLine moveLine)
		{
			try
			{
				InitializeComponent();

				NakladLine = moveLine ?? fromObjLine.Clone();
				NakladLine.Quantity = moveLine?.Quantity ?? 1;

				_maxQuantity = fromObjLine.Quantity;
				lbNomenkl.Text = NakladLine.Nomenkl;
				lbMeasure.Text = $"Ед.изм: {NakladLine.Measure}";
				txtQuantity.EditValue = NakladLine.Quantity;
				btSelectAll.Text = $"Выбрать всё ({_maxQuantity})";
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		public CNakladLine NakladLine { get; }

		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				NakladLine.Quantity = int.Parse(txtQuantity.Text);
				if (NakladLine.Quantity > _maxQuantity)
				{
					MessageService.ShowError($"Введённое количество превышает количество на объекте ({_maxQuantity}).\n" +
											 "Продолжение невозможно.");
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

		private void btSelectAll_Click(object sender, EventArgs e)
		{
			try
			{
				NakladLine.Quantity = _maxQuantity;
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