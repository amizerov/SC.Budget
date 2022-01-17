using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using LinqToDB;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SC.Proda.Views
{
	public partial class FrmStDohos : RibbonForm
	{
		public FrmStDohos()
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
				var stDohosDto = db.GetTable<CStDohoDto>().ToArray();
				if (!btIsShowNoUsed.Down)
				{
					stDohosDto = stDohosDto.Where(s => !s.NoUsed).ToArray();
				}

				var stDohos = stDohosDto.Select(MapperService.Map<CStDoho>).ToArray();

				using (new GridViewStateSaver(gvStDoho))
				{
					gcStDoho.DataSource = stDohos;
				}
			}
		}


		private void gvStDoho_CellValueChanging(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (!(gvStDoho.GetFocusedRow() is CStDoho stDoho)) return;
				if (e.Column == colNoUsed)
				{
					stDoho.NoUsed = !stDoho.NoUsed;
					gvStDoho_CellValueChanged(sender, e);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void gvStDoho_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (!(gvStDoho.GetFocusedRow() is CStDoho stDoho)) return;

				var stRshDto = MapperService.Map<CStDohoDto>(stDoho);
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
				using (var form = new FrmNewOrEditStDoho())
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
				if (!(gvStDoho.GetFocusedRow() is CStDoho stDoho)) return;
				using (var form = new FrmNewOrEditStDoho(stDoho))
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
		private void gvStDoho_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				var pt = gcStDoho.PointToClient(MousePosition);
				var hitInfo = gvStDoho.CalcHitInfo(pt);
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
				if (!(gvStDoho.GetFocusedRow() is CStDoho stDoho)) return;
				var q = $"Статья дохода '{stDoho.Name}' будет безвозвратно удалена.\n" +
						$"Продолжить?";

				if (MessageService.ShowQuestion(q) == DialogResult.Yes)
				{
					using (var db = new DbContext())
					{
						db.Delete(stDoho);
					}
					UpdateData();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvStDoho_RowStyle(object sender, RowStyleEventArgs e)
		{
			try
			{
				if (!(gvStDoho.GetRow(e.RowHandle) is CStDoho stDoho)) return;
				if (stDoho.NoUsed)
				{
					e.Appearance.BackColor = Color.FromArgb(150, Color.Red);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void FrmStDoho_FormClosed(object sender, FormClosedEventArgs e)
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