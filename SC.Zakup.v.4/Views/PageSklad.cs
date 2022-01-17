using LinqToDB.Data;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using LinqToDB.Common;
using SC.Zakup.Properties;

namespace SC.Zakup.Views
{
	public partial class PageSklad : DevExpress.XtraEditors.XtraUserControl
	{
		private DateTime _start, _end;
		private string _skladName;

		public PageSklad()
		{
			InitializeComponent();
		}

		public List<PostupCategory> CategoryFilter { get; set; }

		public void UpdateData() => UpdateData(_start, _end, _skladName);
		public void UpdateData(DateTime start, DateTime end, string skladName)
		{
			try
			{
				_start = start;
				_end = end;
				_skladName = skladName;

				using (var db = new DbContext())
				{
					var allSklad = skladName.IsEmpty() || skladName == "Все";
					var skladsIds = allSklad ? CObjectDto.GetIds(true, false, true, true)
						: new[] { db.GetID<CObjectDto>(skladName) };
					var positions = new List<CSkladPosition>();

					foreach (var skladId in skladsIds)
					{
						var sql = $"Sklad2 '{start:yyyyMMdd}', '{end:yyyyMMdd}', {skladId}";
						var possDto = db.Query<CSkladPositionDto>(sql).ToArray();
						var sklad = db.GetByID<CObjectDto>(skladId);

						foreach (var p in possDto)
						{
							if (!CategoryFilter.IsNullOrEmpty() && !CategoryFilter.Contains(p.Category)) continue;

							positions.Add(new CSkladPosition(sklad, p.Nomenkl, p.Measure)
							{
								Indicator = CSkladPosition.EnumIndicator.Cost,
								Parameter = CSkladPosition.EnumParameter.Start,
								Value = p.CostStart
							});
							positions.Add(new CSkladPosition(sklad, p.Nomenkl, p.Measure)
							{
								Indicator = CSkladPosition.EnumIndicator.Cost,
								Parameter = CSkladPosition.EnumParameter.In,
								Value = p.CostIn
							});
							positions.Add(new CSkladPosition(sklad, p.Nomenkl, p.Measure)
							{
								Indicator = CSkladPosition.EnumIndicator.Cost,
								Parameter = CSkladPosition.EnumParameter.Out,
								Value = p.CostOut
							});
							positions.Add(new CSkladPosition(sklad, p.Nomenkl, p.Measure)
							{
								Indicator = CSkladPosition.EnumIndicator.Cost,
								Parameter = CSkladPosition.EnumParameter.End,
								Value = p.CostStart + p.CostIn - p.CostOut
							});

							positions.Add(new CSkladPosition(sklad, p.Nomenkl, p.Measure)
							{
								Indicator = CSkladPosition.EnumIndicator.CostAdditional,
								Parameter = CSkladPosition.EnumParameter.Start,
								Value = p.CostAdditionalStart
							});
							positions.Add(new CSkladPosition(sklad, p.Nomenkl, p.Measure)
							{
								Indicator = CSkladPosition.EnumIndicator.CostAdditional,
								Parameter = CSkladPosition.EnumParameter.In,
								Value = p.CostAdditionalIn
							});
							positions.Add(new CSkladPosition(sklad, p.Nomenkl, p.Measure)
							{
								Indicator = CSkladPosition.EnumIndicator.CostAdditional,
								Parameter = CSkladPosition.EnumParameter.Out,
								Value = p.CostAdditionalOut
							});
							positions.Add(new CSkladPosition(sklad, p.Nomenkl, p.Measure)
							{
								Indicator = CSkladPosition.EnumIndicator.CostAdditional,
								Parameter = CSkladPosition.EnumParameter.End,
								Value = p.CostAdditionalStart + p.CostAdditionalIn - p.CostAdditionalOut
							});

							positions.Add(new CSkladPosition(sklad, p.Nomenkl, p.Measure)
							{
								Indicator = CSkladPosition.EnumIndicator.Quantity,
								Parameter = CSkladPosition.EnumParameter.Start,
								Value = p.QuantityStart
							});
							positions.Add(new CSkladPosition(sklad, p.Nomenkl, p.Measure)
							{
								Indicator = CSkladPosition.EnumIndicator.Quantity,
								Parameter = CSkladPosition.EnumParameter.In,
								Value = p.QuantityIn
							});
							positions.Add(new CSkladPosition(sklad, p.Nomenkl, p.Measure)
							{
								Indicator = CSkladPosition.EnumIndicator.Quantity,
								Parameter = CSkladPosition.EnumParameter.Out,
								Value = p.QuantityOut
							});
							positions.Add(new CSkladPosition(sklad, p.Nomenkl, p.Measure)
							{
								Indicator = CSkladPosition.EnumIndicator.Quantity,
								Parameter = CSkladPosition.EnumParameter.End,
								Value = p.QuantityStart + p.QuantityIn - p.QuantityOut
							});
						}
					}
					gvSklad.DataSource = positions;
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		public void NewNaklad(bool isToNull, bool selectedOnly)
		{
			try
			{
				if (!int.TryParse(
					gvSklad.GetFocusedText(nameof(CSkladPosition.Sklad_ID)),
					out var sklad_ID))
				{
					MessageService.ShowError("Склад не выбран");
					return;
				}
				var nomenkl = gvSklad.GetFocusedText(nameof(CSkladPosition.Nomenkl))?.Trim();
				using (var db = new DbContext())
				{
					var objLines = db.Query<CNakladLine>(Resources.Sklad,
						new DataParameter("@objectId", sklad_ID))
						.Where(l => !selectedOnly || l.Nomenkl.Trim() == nomenkl)
						.ToArray();
					if (!objLines.Any())
					{
						MessageService.ShowError("На выбранном складе не осталось поступлений");
						return;
					}
					using (var form = new FrmNewNaklad(objLines, sklad_ID, isToNull))
					{
						if (form.ShowDialog(this) == DialogResult.OK)
						{
							UpdateData();
						}
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvSklad_CellDoubleClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
		{
			NewNaklad(false, true);
		}

		private void gvSklad_PopupMenuShowing(object sender, DevExpress.XtraPivotGrid.PopupMenuShowingEventArgs e)
		{
			try
			{
				if (e.HitInfo.CellInfo == null) return;
				gvSklad.Cells.FocusedCell = new Point(e.HitInfo.CellInfo.ColumnIndex, e.HitInfo.CellInfo.RowIndex);

				var itemMove = new DXMenuItem("Переместить поступление");
				itemMove.ImageOptions.SvgImage = Resources.buynow;
				itemMove.Click += (s, ea) => NewNaklad(false, true);
				e.Menu.Items.Add(itemMove);
				var itemToNull = new DXMenuItem("Списать поступление");
				itemToNull.ImageOptions.SvgImage = Resources.shopping_shoppingcart;
				itemToNull.Click += (s, ea) => NewNaklad(true, true);
				e.Menu.Items.Add(itemToNull);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public void AddNakladLines()
		{
			try
			{
				if (!int.TryParse(gvSklad.GetFocusedText(nameof(CSkladPosition.Sklad_ID)),
					out var sklad_ID))
				{
					MessageService.ShowError("Склад не выбран.");
					return;
				}
				var sklad = gvSklad.GetFocusedText(nameof(CSkladPosition.Sklad));

				using (var form = new FrmAddNakladLines(sklad_ID, sklad))
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
	}
}
