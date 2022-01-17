using DevExpress.XtraSplashScreen;
using SC.Common.Model;
using SC.Proda.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CDetail = SC.Proda.Models.CDetail;

namespace SC.Proda.Views
{
	public partial class FrmEditServices : DevExpress.XtraEditors.XtraForm
	{
		private readonly List<int> _rhs1 = new List<int>();
		private readonly List<int> _rhs2 = new List<int>();

		public FrmEditServices()
		{
			try
			{
				InitializeComponent();
				Tools.COM1C.Progress += OnProgress;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void OnProgress(string msg)
		{
			if (!IsHandleCreated || IsDisposed || Disposing) return;
			Invoke(new Action(() =>
			{
				bliLog.Strings.Add(msg);
			}));
		}
		private void FrmEditServices_Load(object sender, EventArgs e)
		{
			BarButtonItem2_ItemClick(null, null);
		}

		private void btnGetServicesFrom1C_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				if (sender != null) SplashScreenManager.ShowForm(this, typeof(FrmLoadingFrom1C));

				gridControl2.DataSource = Tools.COM1C.GetServicesFrom1C();
				gridView2.BestFitColumns();
				gridView2.Columns[0].Width = 40;

				if (gridView2.Columns[0].Summary.Count == 0)
					gridView2.Columns[0].Summary.Add(DevExpress.Data.SummaryItemType.Count);

				if (sender != null) SplashScreenManager.CloseForm(false, 0, this);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void BarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				gridControl1.DataSource = new CDetails();
				gridView1.BestFitColumns();
				gridView1.Columns[0].Width = 40;

				if (gridView1.Columns[0].Summary.Count == 0)
					gridView1.Columns[0].Summary.Add(DevExpress.Data.SummaryItemType.Count);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btnAddOneServiceTo1C_Click(object sender, EventArgs e)
		{
			try
			{
				CDetail d = (CDetail)gridView1.GetFocusedRow();
				Tools.COM1C.UploadOneServiceTo1C(d.ID);
				btnGetServicesFrom1C_ItemClick(null, null);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btnAddAllServicesTo1C_Click(object sender, EventArgs e)
		{
			try
			{
				SplashScreenManager.ShowForm(this, typeof(FrmLoadingFrom1C));

				Tools.COM1C.UploadServicesTo1C();
				btnGetServicesFrom1C_ItemClick(null, null);

				SplashScreenManager.CloseForm(false, 0, this);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void GridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			try
			{
				if (_rhs2.Any(x => x == e.RowHandle))
					e.Appearance.BackColor = Color.Tomato;
			}
			catch { }
		}

		private void GridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			try
			{
				if (_rhs1.Any(x => x == e.RowHandle))
					e.Appearance.BackColor = Color.Tomato;
			}
			catch { }
		}

		private void BarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				CDetails ss = (CDetails)gridView2.DataSource; if (ss == null) return;
				foreach (CDetail s in (CDetails)gridView1.DataSource)
				{
					if (ss.Find(d => d.ID == s.ID) == null)
					{
						int rh = gridView1.FindRow(s);
						gridView1.FocusedRowHandle = rh + 1;
						gridView1.RefreshRow(rh);
						_rhs1.Add(rh);
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void BtnNewInDB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				using (var form = new FrmEditServ())
				{
					form.ShowDialog(this);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void BarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			try
			{
				CDetails ss = (CDetails)gridView1.DataSource;
				foreach (CDetail s in (CDetails)gridView2.DataSource)
				{
					if (ss.Find(d => d.ID == s.ID) == null)
					{
						int rh = gridView2.FindRow(s); gridView2.FocusedRowHandle = rh + 1;
						gridView2.RefreshRow(rh);
						_rhs2.Add(rh);
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}