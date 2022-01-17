using System;
using System.Collections.Generic;
using System.Linq;

namespace SwissClean.Services
{
	public static class EnumerableMethods
	{
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
		{
			var array = enumerable as T[] ?? enumerable.ToArray();
			foreach (var item in array)
			{
				action?.Invoke(item);
			}
			return array;
		}
		public static IEnumerable<T> ForEach<T, TR>(this IEnumerable<T> enumerable, Func<T, TR> func)
		{
			var array = enumerable as T[] ?? enumerable.ToArray();
			foreach (var item in array)
			{
				func?.Invoke(item);
			}
			return array;
		}
	}
}
