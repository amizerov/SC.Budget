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
	public partial class FrmDetails : RibbonForm
	{
		public FrmDetails()
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
				var detailsDto = db.GetTable<CDetailProdaDto>().ToArray();
				var details = detailsDto.Select(MapperService.Map<CDetailProda>).ToArray();

				if (!btIsShowNoUsed.Down)
				{
					details = details.Where(s => !s.NoUsed).ToArray();
				}
				using (new GridViewStateSaver(gvDetail))
				{
					gcDetail.DataSource = details;
				}
			}
		}

		private void gvDetail_CellValueChanging(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (!(gvDetail.GetFocusedRow() is CDetailProda detail)) return;
				if (e.Column == colNoUsed)
				{
					detail.NoUsed = !detail.NoUsed;
					gvDetail_CellValueChanged(sender, e);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void gvDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (!(gvDetail.GetFocusedRow() is CDetailProda detail)) return;

				var detailDto = MapperService.Map<CDetailProdaDto>(detail);
				using (var db = new DbContext())
				{
					db.Update(detailDto);
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
				using (var form = new FrmNewOrEditDetail())
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
				if (!(gvDetail.GetFocusedRow() is CDetailProda detail)) return;
				using (var form = new FrmNewOrEditDetail(detail))
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
		private void gvDetail_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				var pt = gcDetail.PointToClient(MousePosition);
				var hitInfo = gvDetail.CalcHitInfo(pt);
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
				if (!(gvDetail.GetFocusedRow() is CDetailProda detail)) return;
				var q = $"Детализация '{detail.Name}' будет безвозвратно удалена.\n" +
						"Продолжить?";

				if (MessageService.ShowQuestion(q) == DialogResult.Yes)
				{
					using (var db = new DbContext())
					{
						db.Delete(detail);
					}

					UpdateData();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvDetail_RowStyle(object sender, RowStyleEventArgs e)
		{
			try
			{
				if (!(gvDetail.GetRow(e.RowHandle) is CDetailProda detail)) return;
				if (detail.NoUsed)
				{
					e.Appearance.BackColor = Color.FromArgb(150, Color.Red);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void FrmDetail_FormClosed(object sender, FormClosedEventArgs e)
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