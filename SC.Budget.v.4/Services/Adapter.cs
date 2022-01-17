using System.Linq;

namespace SC.Budget.Services
{
	public static class Adapter
	{
		public static T Convert<T>(object obj) where T : new()
		{
			var res = new T();
			var pi1 = obj.GetType().GetProperties();
			var pi2 = typeof(T).GetProperties();
			foreach (var p1 in pi1)
			{
				if (p1.CanRead && p1.CanWrite)
				{
					var p2 = pi2.FirstOrDefault(p => p.Name == p1.Name);
					if (p2 != null)
					{
						p2.SetValue(res, p1.GetValue(obj));
					}
				}
			}
			return res;
		}
	}
}
