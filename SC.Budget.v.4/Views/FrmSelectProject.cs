using SC.Budget.Model;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SC.Budget.Views
{
	public partial class FrmSelectProject : DevExpress.XtraEditors.XtraForm
	{
		public FrmSelectProject()
		{
			try
			{
				InitializeComponent();

				var user = ApplicationUser.User;

				using (var db = new DbContext())
				{
					var projects = db.GetTable<CProject>()
						.Where(p => !p.IsDeleted)
						.Where(p => user.Role == Role.Admin || user.Role == Role.Director || p.Rukovod_ID == user.ID)
						.OrderBy(p => p.Name)
						.ToArray();

					gcProjects.DataSource = projects;
				}
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}

		public CProject Project => gvProjects.GetFocusedRow() as CProject;

		private void ShowError(string error)
		{
			MessageService.ShowError(error);
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void gvProjects_DoubleClick(object sender, EventArgs e)
		{
			var pt = gcProjects.PointToClient(MousePosition);
			var hitInfo = gvProjects.CalcHitInfo(pt);
			if (hitInfo.InRow)
			{
				btnOk_Click(this, EventArgs.Empty);
			}
		}
	}
}