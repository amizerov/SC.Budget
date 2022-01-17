using LinqToDB.Mapping;

namespace SC.Budget.Model
{
	public enum Role
	{
		None = 0,
		Admin = 1,
		Buh = 2,
		ManagerZakup = 3,
		Rukovod = 4,
		ManagerObj = 5,
		Director = 6,
	}

	[Table(Name = "Role")]
	public class CRole
	{
		[PrimaryKey, Identity]
		public int ID { get; set; }

		[Column(Name = "Name")]
		public string Name { get; set; }
	}
}
