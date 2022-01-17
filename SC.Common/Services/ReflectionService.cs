namespace SC.Common.Services
{
	public static class ReflectionService
	{
		public static void SetValue<T>(this T to, T from, string fieldName)
		{
			var prop = to.GetType().GetProperty(fieldName);
			if (prop == null) return;
			var val = prop.GetValue(from);

			prop.SetValue(to, val);
		}
	}
}
