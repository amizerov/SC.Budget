using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using SC.Common.Dal;
using SC.Common.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using LinqToDB;
using LinqToDB.SqlQuery;
using SC.Common.Services;

namespace SC.Zakup.Views
{
	public partial class FrmStRashs : RibbonForm
	{
		public FrmStRashs()
		{
			try
			{
				InitializeComponent();
				LayoutSaver.Restore(this);
				UpdateData();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btUpdate_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				UpdateData();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void UpdateData()
		{
			using (var db = new DbContext())
			{
				var stRashsDto = db.GetTable<CStRashDto>().ToArray();
				if (!btIsShowNoUsed.Down)
				{
					stRashsDto = stRashsDto.Where(s => !s.NoUsed).ToArray();
				}

				var stRashs = stRashsDto.Select(MapperService.Map<CStRash>).ToArray();

				using (new GridViewStateSaver(gvStRash))
				{
					gcStRash.DataSource = stRashs;
				}
			}
		}


		private void gvStRash_CellValueChanging(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (!(gvStRash.GetFocusedRow() is CStRash stRash)) return;
				if (e.Column == colNoUsed)
				{
					stRash.NoUsed = !stRash.NoUsed;
					gvStRash_CellValueChanged(sender, e);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void gvStRash_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (!(gvStRash.GetFocusedRow() is CStRash stRash)) return;

				var stRshDto = MapperService.Map<CStRashDto>(stRash);
				using (var db = new DbContext())
				{
					db.Update(stRshDto);
				}
				UpdateData();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btNew_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var form = new FrmNewOrEditStRash())
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						UpdateData();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btEdit_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (!(gvStRash.GetFocusedRow() is CStRash stRash)) return;
				using (var form = new FrmNewOrEditStRash(stRash))
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						UpdateData();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void gvStRash_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				var pt = gcStRash.PointToClient(MousePosition);
				var hitInfo = gvStRash.CalcHitInfo(pt);
				if (!hitInfo.InRow) return;

				btEdit_ItemClick(sender, null);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btDelete_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (!(gvStRash.GetFocusedRow() is CStRash stRash)) return;
				var q = $"Статья расхода '{stRash.Name}' будет безвозвратно удалена.\n" +
						$"Продолжить?";

				if (MessageService.ShowQuestion(q) == DialogResult.Yes)
				{
					using (var db = new DbContext())
					{
						db.Delete(stRash);
					}
					UpdateData();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvStRash_RowStyle(object sender, RowStyleEventArgs e)
		{
			try
			{
				if (!(gvStRash.GetRow(e.RowHandle) is CStRash stRash)) return;
				if (stRash.NoUsed)
				{
					e.Appearance.BackColor = Color.FromArgb(150, Color.Red);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void FrmStRash_FormClosed(object sender, FormClosedEventArgs e)
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