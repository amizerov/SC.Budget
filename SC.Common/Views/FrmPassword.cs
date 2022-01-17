namespace SC.Common.Views
{
	public partial class FrmPassword : DevExpress.XtraEditors.XtraForm
	{
		public FrmPassword()
		{
			InitializeComponent();
		}
		public string Password => txtPassword.Text;
	}
}