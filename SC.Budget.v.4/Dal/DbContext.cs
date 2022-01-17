using LinqToDB.Data;
using LinqToDB.DataProvider;
using LinqToDB.DataProvider.SqlServer;

namespace SC.Budget.Dal
{
	public class DbDataContext : DataConnection
	{
		public DbDataContext() : base(GetDataProvider(), GetConnectionString()) { }

		private static string GetConnectionString()
		{
			return "Data Source = mizeroff.net; Initial Catalog = SwissClean; User ID = scuser; Password = !QAZ1qaz;";
		}

		private static IDataProvider GetDataProvider()
		{
			// you can move this line to other place, but it should be
			// allways set before LINQ to DB provider instance creation
			LinqToDB.Common.Configuration.AvoidSpecificDataProviderAPI = true;

			return new SqlServerDataProvider("", SqlServerVersion.v2017);
		}
	}
}
