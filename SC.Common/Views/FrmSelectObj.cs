using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using LinqToDB.Data;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Properties;
using SC.Common.Services;

namespace SC.Common.Views
{
	public partial class FrmSelectObj : XtraForm
	{
		private bool _updating;
		public int Object_ID => (treeMain.GetFocusedRow() as ObjectProjectTree)?.Object_ID ?? -1;
		public int Project_ID => (treeMain.GetFocusedRow() as ObjectProjectTree)?.Project_ID ?? -1;

		public FrmSelectObj()
		{
			try
			{
				InitializeComponent();

				LayoutSaver.Restore(this);

				Reload(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void Reload(object sender, EventArgs e)
		{
			try
			{
				using (var db = new DbContext())
				{
					var user = ApplicationUser.User;
					var userId = user?.Role == Role.Admin ||
								 user?.Role == Role.Director ? 0
						: user?.ID ?? -1;
					btIsMyOnly.Enabled = btIsNoMyOnly.Enabled = btIsAll.Enabled = userId > 0;

					var hasMy = btIsMyOnly.Checked || btIsAll.Checked;
					var hasNoMy = btIsNoMyOnly.Checked || btIsAll.Checked;
					var projectId = CProjectDto.GetIds(btIsSklad.Checked, !btIsSklad.Checked, hasMy, hasNoMy);

					var sql = Resources.ObjectProjectTree
						.Replace("@projectIds", string.Join(",", projectId));

					var tree = db.Query<ObjectProjectTree>(sql, new DataParameter("@firmaId", null))
						.ToArray();

					using (new TreeListStateSaver(treeMain))
					{
						treeMain.DataSource = tree;
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void BtnOk_Click(object sender, EventArgs e)
		{
			try
			{
				if (!(treeMain.GetFocusedRow() is ObjectProjectTree vm)) return;
				if (vm.Type != ObjType.Object)
				{
					MessageService.ShowError("Объект не выбран.");
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
		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void MyNoMy_CheckedChanged(object sender, EventArgs e)
		{
			if (_updating) return;
			try
			{
				_updating = true;
				if (!(sender is CheckButton checkedButton)) return;

				new[] { btIsMyOnly, btIsNoMyOnly, btIsAll }
					.ForEach(button => button.Checked = button.Equals(checkedButton));

				Reload(sender, e);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
			finally
			{
				_updating = false;
			}
		}
		private void treeObjects_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
		{
			try
			{
				if (!(treeMain.GetRow(e.Node.Id) is ObjectProjectTree vm)) return;
				if (vm.Type == ObjType.Project)
				{
					e.Appearance.BackColor = Color.FromArgb(150, 213, 238, 255);
					e.Appearance.BorderColor = Color.FromArgb(255, 150, 153, 169);
				}
				else if (vm.Type == ObjType.Summary)
				{
					e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
					e.Appearance.BackColor = Color.FromArgb(75, 128, 128, 128);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void treeObjects_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
		{
			try
			{
				TreeListService.CustomDrawNodeCell(e);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void treeMain_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				var pt = treeMain.PointToClient(MousePosition);
				var hitInfo = treeMain.CalcHitInfo(pt);
				if (!hitInfo.InRow) return;

				if (!(treeMain.GetFocusedRow() is ObjectProjectTree vm)) return;
				if (vm.Type != ObjType.Object) return;
				BtnOk_Click(sender, e);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void FrmSelectObj_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				LayoutSaver.Save(this);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}
