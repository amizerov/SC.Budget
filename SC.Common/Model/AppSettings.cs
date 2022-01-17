using LinqToDB.Data;
using SC.Common.Dal;
using System;
using System.Linq;

namespace SC.Common.Model
{
	public static class AppSettings
	{
		public static DateTime EditableDate
		{
			get => GetDateTime(nameof(EditableDate));
			set => Set(nameof(EditableDate), value);
		}

		private static string Get(string name)
		{
			using (var db = new DbContext())
			{
				var sql = $"select Value from AppSettings where Name = '{name}'";
				var settings = db.Query<string>(sql).FirstOrDefault();
				return settings;
			}
		}

		private static DateTime GetDateTime(string name) => DateTime.Parse(Get(name));


		private static void Set(string name, object value)
		{
			using (var db = new DbContext())
			{
				var sql = $"update AppSettings set Value = '{value}' where Name = '{name}'";
				db.Execute(sql);
			}
		}

		private static void Set(string name, DateTime value) => Set(name, $"{value:s}");
	}
}
