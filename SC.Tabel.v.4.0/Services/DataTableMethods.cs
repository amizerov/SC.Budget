using System;
using System.Collections.Generic;
using System.Data;

namespace SwissClean.Services
{
	public static class DataTableMethods
	{
		public static List<T> ToObjList<T>(this DataTable dataTable, Func<DataRow, T> func)
		{
			var res = new List<T>();

			foreach (DataRow r in dataTable.Rows)
			{
				res.Add(func.Invoke(r));
			}

			return res;
		}
	}
}
