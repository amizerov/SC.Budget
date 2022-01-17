using System;
using DevExpress.XtraEditors;
using SC.Common.Model;

namespace SC.Zakup.Views
{
	public partial class FrmNewNakladInvented : XtraForm
	{
		public FrmNewNakladInvented()
		{
			try
			{
				InitializeComponent();
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
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}