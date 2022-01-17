using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SwissClean.Services
{
	public static class StringMethods
	{
		private static readonly string defaultSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
		public static string ListToString<T>(this IEnumerable<T> list)
		{
			var res = list.Aggregate(new StringBuilder(),
					(sb, item) => sb.Append(item).Append('\n'));

			return res.ToString();
		}
		public static string ToString<T>(this IEnumerable<T> enumerable, string splitter)
		{
			var bld = new StringBuilder();
			var array = enumerable as T[] ?? enumerable.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				bld.Append(array.ElementAt(i));
				if (i < array.Length - 1) bld.Append(splitter);
			}
			return bld.ToString();
		}
		public static double ToDouble(this string str)
		{
			if (string.IsNullOrEmpty(str)) return 0;
			str = str.Replace(",", defaultSeparator).Replace(".", defaultSeparator);
			return double.Parse(str);
		}
		public static decimal ToDecimal(this string str)
		{
			if (string.IsNullOrEmpty(str)) return 0;
			str = str.Replace(",", defaultSeparator).Replace(".", defaultSeparator);
			return decimal.Parse(str);
		}
		public static decimal? ToNullableDecimal(this string str)
		{
			if (string.IsNullOrEmpty(str)) return null;
			str = str.Replace(",", defaultSeparator).Replace(".", defaultSeparator);
			return decimal.Parse(str);
		}
	}
}