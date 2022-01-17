using SC.Common.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using LinqToDB.Data;
using SC.Zakup.Properties;
using SC.Common.Dal;
using SC.Common.Services;
using DevExpress.DataProcessing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace SC.Zakup.Views
{
	public partial class FrmLoadScheta : XtraForm
	{
		private bool _updating;
		private readonly CSchetLoad[] _oldScheta;
		private readonly CSchetLoad[] _scheta;

		public FrmLoadScheta(List<CSchetLoad> scheta)
		{
			try
			{
				InitializeComponent();
				LayoutSaver.Restore(this);
				_scheta = scheta.ToArray();
				using (var db = new DbContext())
				{
					var firmas = db.GetTable<CFirmaDto>().ToArray();
					var projects = db.GetTable<CProjectDto>().ToArray();
					var suppliers = db.GetTable<CSupplierDto>().ToArray();
					var details = db.GetTable<CDetailDto>().ToArray();
					var stRash = db.GetTable<CStRash>().ToArray();

					void BuildSchetLoad(CSchetLoad s)
					{
						if (s == null) return;
						s.NeedLoad = true;
						s.FirmaName = firmas.FirstOrDefault(o => o.ID == s.Firma_ID)?.Name;
						s.ProjectName = projects.FirstOrDefault(o => o.ID == s.Project_ID)?.Name;
						s.SupplierName = suppliers.FirstOrDefault(o => o.ID == s.Supplier_ID)?.Name;
						s.DetailName = details.FirstOrDefault(o => o.ID == s.Detail_ID)?.Name;
						s.StRashName = stRash.FirstOrDefault(o => o.ID == s.StRash_ID)?.Name;
					}

					_scheta.ForEach(BuildSchetLoad);

					var ids = _scheta.Select(s => s.ID).ToArray();
					var start = _scheta.Min(s => s.DataCreate);
					var end = _scheta.Max(s => s.DataCreate).AddDays(1);
					var schetaDb = CSchet.GetTable(start: start, end: end)
							.Where(s => ids.Contains(s.ID))
							.Select(MapperService.Map<CSchetLoad>)
							.ToArray();
					_oldScheta = new CSchetLoad[_scheta.Length];
					for (int i = 0; i < _scheta.Length; i++)
					{
						_oldScheta[i] = schetaDb.FirstOrDefault(s => s.ID == _scheta[i].ID);
						BuildSchetLoad(_oldScheta[i]);
					}
					using (new GridViewStateSaver(gvOldScheta))
					{
						gcOldScheta.DataSource = _oldScheta;
					}
					using (new GridViewStateSaver(gvScheta))
					{
						gcScheta.DataSource = _scheta;
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btSelectAll_Click(object sender, EventArgs e) => SelectAll(true);
		private void btSelectAllNew_Click(object sender, EventArgs e) => SelectAll(false);
		private void SelectAll(bool includesOld)
		{
			try
			{
				for (var i = 0; i < _scheta.Length; i++)
				{
					var old = _oldScheta[i];
					_scheta[i].NeedLoad = old == null || includesOld;
					if (old != null) old.NeedLoad = includesOld;
				}

				gvScheta.LayoutChanged();
				gvOldScheta.LayoutChanged();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btCancelAll_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (var s in _scheta) s.NeedLoad = false;
				foreach (var s in _oldScheta) if (s != null) s.NeedLoad = false;
				gvScheta.LayoutChanged();
				gvOldScheta.LayoutChanged();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvScheta_CellValueChanging(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (!(sender is GridView gv)) return;

				if (gv.FocusedColumn.FieldName == nameof(CSchetLoad.NeedLoad))
				{
					gvScheta_CellValueChanged(sender, e);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void gvScheta_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (!(sender is GridView gv)) return;
				if (gv.FocusedColumn.FieldName == nameof(CSchetLoad.NeedLoad))
				{
					var i = gv.FocusedRowHandle;
					if (e.Value is bool value)
					{
						_scheta[i].NeedLoad = value;
						if (_oldScheta[i] != null) _oldScheta[i].NeedLoad = value;
						gvScheta.LayoutChanged();
						gvOldScheta.LayoutChanged();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvScheta_RowStyle(object sender, RowStyleEventArgs e)
		{
			try
			{
				if (!(sender is GridView gv)) return;
				if (!(gv.GetRow(e.RowHandle) is CSchetLoad schet)) return;
				if (schet.NeedLoad)
				{
					if (gvOldScheta.GetRow(e.RowHandle) is CSchetLoad)
					{
						e.Appearance.BackColor = Color.FromArgb(30, Color.Lime);
					}
					else
					{
						e.Appearance.BackColor = Color.FromArgb(120, Color.LimeGreen);
					}
				}
				if (schet.IsDeleted)
				{
					e.Appearance.BackColor = Color.FromArgb(100, Color.Red);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void gvScheta_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
		{
			try
			{
				if (!(sender is GridView gv)) return;
				gv.NoDrawBoolCell(e, typeof(CSchetLoad));
				ShowUpdatedValues(e, gv);
				gv.DrawFocusedCell(e);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void ShowUpdatedValues(RowCellCustomDrawEventArgs e, GridView gv)
		{
			if (e.Column.FieldName == nameof(CSchetLoad.NeedLoad)) return;
			if (!(gv.GetRow(e.RowHandle) is CSchetLoad schet)) return;
			var schet2 = gv == gvScheta
				? _oldScheta.FirstOrDefault(s => s?.ID == schet.ID)
				: _scheta.FirstOrDefault(s => s?.ID == schet.ID);
			if (schet2 == null) return;
			var prop = schet.GetType().GetProperties()
				.FirstOrDefault(p => p.Name == e.Column.FieldName);

			if (prop == null) return;
			var value = prop.GetValue(schet);
			var value2 = prop.GetValue(schet2);

			if (!value?.Equals(value2) ?? value2 != null)
			{
				e.Appearance.BackColor = Color.FromArgb(0, 100, 200);
				e.Appearance.ForeColor = Color.White;
			}
		}

		private void gvScheta_Layout(object sender, EventArgs e)
		{
			if (_updating) return;
			try
			{
				_updating = true;
				if (!(sender is GridView gv)) return;
				var gv2 = gv == gvScheta ? gvOldScheta : gvScheta;

				var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
					"SCAS", "LayoutTemp.xml");
				gv.SaveLayoutToXml(path);
				var layout = File.ReadAllText(path);
				for (int i = 0; i < gv.Columns.Count; i++)
				{
					var c1 = gv.Columns[i];
					var c2 = gv2.Columns.FirstOrDefault(c => c.FieldName == c1.FieldName);
					layout = layout.Replace(c1.Name, c2?.Name);
				}
				File.WriteAllText(path, layout);
				gv2.RestoreLayoutFromXml(path);
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

		private void gvScheta_CustomDrawScroll(object sender, ScrollBarCustomDrawEventArgs e)
		{
			if (_updating) return;
			try
			{
				_updating = true;
				if (!(sender is GridView gv)) return;
				var gv2 = gv == gvScheta ? gvOldScheta : gvScheta;
				gv2.TopRowIndex = gv.TopRowIndex;
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
		private void gvScheta_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
		{
			if (_updating) return;
			try
			{
				_updating = true;
				if (!(sender is GridView gv)) return;
				var gv2 = gv == gvScheta ? gvOldScheta : gvScheta;

				gv2.FocusedColumn = gv2.Columns.FirstOrDefault(c => c.FieldName == e.FocusedColumn.FieldName);
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
		private void gvScheta_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
		{
			if (_updating) return;
			try
			{
				_updating = true;
				if (!(sender is GridView gv)) return;
				var gv2 = gv == gvScheta ? gvOldScheta : gvScheta;
				if (!(gv.GetFocusedRow() is CSchetLoad schet))
				{
					gv2.FocusedRowHandle = gv.FocusedRowHandle;
					return;
				}
				for (int i = 0; i < gv2.RowCount; i++)
				{
					if (gv2.GetRow(i) is CSchetLoad s2 && s2.ID == schet.ID)
					{
						gv2.FocusedRowHandle = i;
						return;
					}
				}
				gv2.FocusedRowHandle = gv.FocusedRowHandle;
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

		private void FrmLoadScheta_FormClosed(object sender, FormClosedEventArgs e)
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