using SC.Common.Model;
using System;

namespace SC.Cash.Views
{
	public partial class FrmAmountOutNoToUser : DevExpress.XtraEditors.XtraForm
	{
		public FrmAmountOutNoToUser(string userName, DateTime start, DateTime end, COperation[] ops)
		{
			try
			{
				InitializeComponent();

				Text = $"Операции без получателя для счёта '{userName}' " +
					   $"с {start:dd.MM.yyyy} по {end:dd.MM.yyyy}";
				gcOperations.DataSource = ops;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}