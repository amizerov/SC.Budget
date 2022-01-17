using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using LinqToDB;
using LinqToDB.Data;
using SC.Zakup.Models;
using SC.Zakup.Properties;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CNakladnaya = SC.Common.Model.CNakladnaya;

namespace SC.Zakup.Views
{
	public partial class PageNaklads : DevExpress.XtraEditors.XtraUserControl
	{
		private NakladAccessService _accessService = new NakladAccessService();
		public PageNaklads()
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

		public event EventHandler Updated;

		public void UpdateData(DateTime start, DateTime end, bool from1C, bool fromUser,
			string firma, string sklad, PostupCategory[] categories)
		{
			try
			{
				using (var db = new DbContext())
				{
					var allFirma = firma.IsEmpty() || firma == "Все";
					var allSklad = sklad.IsEmpty() || sklad == "Все";
					var categoriesSql = categories.Select(c => (int)c).ToArray();
					var sql = Resources.Naklads.Replace("@categories", string.Join(",", categoriesSql));

					var naklads = db.Query<CNakladnaya>(sql,
						new DataParameter("@start", start),
						new DataParameter("@end", end))
						.Where(n => allFirma || n.FirmaName == firma)
						.Where(n => allSklad || n.ObjectName == sklad)
						.Where(n =>
						{
							if (from1C && n.FromObject_ID == null) return true;
							if (fromUser && n.FromObject_ID != null) return true;
							return false;
						})
						.ToArray();

					using (new GridViewStateSaver(gvNaklads))
					{
						gcNaklads.DataSource = naklads;
					}
					GvNaklads_FocusedRowChanged(this, null);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public CNakladnaya FocusedNaklad => gvNaklads.GetFocusedRow() as CNakladnaya;
		public void EditSlelectedNaklad()
		{
			try
			{
				if (!(gvNaklads.GetFocusedRow() is CNakladnaya naklad)) return;
				if (!_accessService.IsAccess(naklad))
				{
					MessageService.ShowError(_accessService.Message);
					return;
				}

				using (var form = new FrmEditNaklad(naklad.ID, naklad.Object_ID))
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						Updated?.Invoke(this, EventArgs.Empty);
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		public void DeleteSelectedNaklads()
		{
			try
			{
				var rows = gvNaklads.GetSelectedRows();
				var question = $"{rows.Length} накладных будут безвозвратно удалены.\n" +
							   "Также для всех позиций в накладной, будут удалены все накладные с последующими передвижениями этих позиций.\n\n" +
							   "Продолжить?";
				if (MessageService.ShowQuestion(question) != DialogResult.Yes) return;

				foreach (var h in rows)
				{
					if (!(gvNaklads.GetRow(h) is CNakladnaya naklad)) continue;
					{
						if (!_accessService.IsAccess(naklad))
						{
							MessageService.ShowError(_accessService.Message);
							continue;
						}
						naklad.Delete();
					}
				}
				CNakladnaya.DeleteEmpties();

				Updated?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void GvNaklads_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
		{
			try
			{
				if (!(gvNaklads.GetFocusedRow() is CNakladnaya naklad))
				{
					gcNakladLines.DataSource = new CNakladLine[0];
					return;
				}

				using (var db = new DbContext())
				{
					var lines = db.Query<CNakladLine>(Resources.NakladLines,
							new DataParameter("@nakladId", naklad.ID))
						.ToArray();

					gcNakladLines.DataSource = lines;
					gvNakladLines.OptionsBehavior.Editable = _accessService.IsAccess(naklad);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void GvNaklads_DoubleClick(object sender, EventArgs e)
		{
			var pt = gcNaklads.PointToClient(MousePosition);
			var hitInfo = gvNaklads.CalcHitInfo(pt);
			if (!hitInfo.InRow) return;

			EditSlelectedNaklad();
		}
		private void GvNakladLines_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (!(gvNakladLines.GetFocusedRow() is CNakladLine line)) return;
				var lineDto = MapperService.Map<CNakladLineDto>(line);
				using (var db = new DbContext())
				{
					db.Update(lineDto);
					db.Execute(Resources.UpdateQuantityMoved,
						new DataParameter("@postupId", line.Postup_ID));
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void GvNakladLines_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
		{
			try
			{
				if (!(gvNakladLines.GetFocusedRow() is CNakladLine line)) return;
				if (gvNakladLines.FocusedColumn == colQuantity)
				{
					if (int.Parse(e.Value.ToString()) > line.Quantity + line.QuantityOnSklad)
					{
						e.ErrorText = "Столько товара нет на складе";
						e.Valid = false;
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void gvNakladLines_ShowingEditor(object sender, CancelEventArgs e)
		{
			try
			{
				e.Cancel = !gvNakladLines.OptionsBehavior.Editable || !CNakladLine.IsEditableCell(gvNakladLines);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void gvNakladLines_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
		{
			if (!gvNakladLines.Editable) e.Appearance.BackColor = Color.FromArgb(20, Color.Black);
		}

		private void gvNaklads_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			try
			{
				if (!(gvNaklads.GetRow(e.RowHandle) is CNakladnaya naklad)) return;
				if (naklad.Object_ID == null)
				{
					e.Appearance.BackColor = Color.FromArgb(150, Color.Red);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}
