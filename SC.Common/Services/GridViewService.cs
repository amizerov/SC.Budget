using System;
using System.Drawing;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using SC.Common.Model;

namespace SC.Common.Services
{
	public static class GridViewService
	{
		public static void DisableFilter(this GridView gv)
		{
			foreach (GridColumn c in gv.Columns)
			{
				c.OptionsFilter.AllowFilter = false;
			}
		}
		public static void DisableSort(this GridView gv)
		{
			foreach (GridColumn c in gv.Columns)
			{
				c.OptionsColumn.AllowSort = DefaultBoolean.False;
			}
		}

		public static void NoDrawBoolCell(this GridView gv, RowCellCustomDrawEventArgs e, Type type)
		{
			var boolFields = type.GetProperties()
				.Where(p => p.PropertyType == typeof(bool))
				.Select(p => p.Name);
			if (gv.GetRow(e.RowHandle) == null &&
				boolFields.Contains(e.Column.FieldName))
			{
				e.Cache.FillRectangle(e.Cache.GetSolidBrush(e.Appearance.BackColor), e.Bounds);
				e.Handled = true;
			}
		}
		public static void DrawFocusedCell(this GridView gv, RowCellCustomDrawEventArgs e)
		{
			if (e.Cell is GridCellInfo cellInfo &&
			    gv.FocusedRowHandle == cellInfo.RowHandle &&
			    gv.FocusedColumn == cellInfo.Column)
			{
				var color = gv.Appearance.FocusedCell.BackColor;
				e.Appearance.BackColor = e.Appearance.BackColor.Mix(color);
			}
		}
	}
}
