using DevExpress.XtraPivotGrid;

namespace SC.Common.Services
{
	public static class PivotGridService
	{
		public static object GetFocusedCell(this PivotGridControl grid, string fieldName)
		{
			var cell = grid.Cells.FocusedCell;
			var drillSource = grid.CreateDrillDownDataSource(cell.X, cell.Y);
			if (drillSource.RowCount > 0)
			{
				var value = drillSource.GetValue(0, fieldName);
				return value;
			}
			return null;
		}

		public static string GetFocusedText(this PivotGridControl grid, string fieldName) =>
			GetFocusedCell(grid, fieldName)?.ToString();
	}
}
