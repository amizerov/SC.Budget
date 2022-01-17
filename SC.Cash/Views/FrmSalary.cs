using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraPivotGrid;
using LinqToDB.Data;
using SC.Cash.Model;
using SC.Cash.Properties;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SC.Cash.Views
{
	public partial class FrmSalary : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		private readonly Dictionary<PivotGridField, Color> _colorsByField;

		public FrmSalary()
		{
			try
			{
				InitializeComponent();

				LayoutSaver.Restore(this);
				chbRules.Down = gvCalculated.FormatRules.All(r => r.Enabled);

				_colorsByField = new Dictionary<PivotGridField, Color>
				{
					[fieldRukovodName] = Color.FromArgb(255, 217, 143),
					[fieldProjectName] = Color.FromArgb(252, 239, 216),
					[fieldManagerName] = Color.FromArgb(230, 245, 255),
					[fieldObjectName] = Color.FromArgb(254, 255, 255), //с дефолтным цветом итоги слишком тёмные
				};

				using (var db = new DbContext())
				{
					var user = ApplicationUser.User;
					var rukovodId = user.Role == Role.Rukovod ? user.ID : 0;

					var debts = db.Query<CDebt>(Resources.Debts,
							new DataParameter("@rukovodId", rukovodId))
						.ToArray();

					gvCalculated.DataSource = debts;
					fieldRukovodName.Visible = user.Role != Role.Rukovod;
					gvCalculated.BestFitColumnArea();
					gvCalculated.CollapseAll();
					gvCalculated_CellSelectionChanged(this, EventArgs.Empty);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvCalculated_CustomDrawCell(object sender, PivotCustomDrawCellEventArgs e)
		{
			try
			{
				if (e.RowField != null && _colorsByField.ContainsKey(e.RowField))
				{
					e.Appearance.BackColor = _colorsByField[e.RowField];
				}
				if (e.RowValueType == PivotGridValueType.Total ||
					(e.ColumnValueType == PivotGridValueType.GrandTotal &&
					e.RowValueType != PivotGridValueType.GrandTotal))
				{
					e.Appearance.BackColor = e.Appearance.BackColor.ToLight(-20);
				}
				if (gvCalculated.Cells.GetCellInfo(e.ColumnIndex, e.RowIndex).Selected)
				{
					e.Appearance.BackColor = e.Appearance.BackColor.ToLight(-20);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void gvCalculated_CustomDrawFieldValue(object sender, PivotCustomDrawFieldValueEventArgs e)
		{
			try
			{
				if (e.Field != null && _colorsByField.ContainsKey(e.Field))
				{
					e.Appearance.BackColor = _colorsByField[e.Field];
				}
				if (e.ValueType == PivotGridValueType.Total)
				{
					e.Appearance.BackColor = e.Appearance.BackColor.ToLight(-20);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btnExpandAll_ItemClick(object sender, ItemClickEventArgs e) => gvCalculated.ExpandAll();
		private void btCollapceAll_ItemClick(object sender, ItemClickEventArgs e) => gvCalculated.CollapseAll();

		private void btToExcel_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var excel = new ExcelService(this))
				{
					excel.GridToExcel(gvCalculated.ExportToXlsx)
						.SetAutoFit()
						.SetMonthOnTopRow();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void chbRules_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				gvCalculated.FormatRules.ForEach(r => r.Enabled = chbRules.Down);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void FrmSalary_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
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

		private void gvCalculated_CellSelectionChanged(object sender, EventArgs e)
		{
			try
			{
				var values = new List<decimal>();
				for (int c = 0; c < gvCalculated.Cells.ColumnCount; c++)
				{
					for (int r = 0; r < gvCalculated.Cells.RowCount; r++)
					{
						var info = gvCalculated.Cells.GetCellInfo(c, r);
						if (info.Selected || info.Focused)
						{
							values.Add(gvCalculated.GetCellValue(c, r).ToDecimal());
						}
					}
				}
				if (!values.Any())
				{
					var focusedInfo = gvCalculated.Cells.GetFocusedCellInfo();
					values.Add(gvCalculated.GetCellValue(focusedInfo.ColumnIndex, focusedInfo.RowIndex).ToDecimal());
				}
				var descr = $"Максимум {values.Max():c2}\n" +
							$"Минимум {values.Min():c2}\n" +
							$"Среднее {values.Average():c2}\n" +
							$"Сумма {values.Sum():c2}";

				lbSelectionSummary.SuperTip = new SuperToolTip();
				lbSelectionSummary.SuperTip.Items.Add(new ToolTipTitleItem { Text = "Итоги по выбранным ячейкам" });
				lbSelectionSummary.SuperTip.Items.Add(new ToolTipItem { Text = descr });
				lbSelectionSummary.Caption = descr.Replace("\n", "    ");
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}