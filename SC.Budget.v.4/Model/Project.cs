using LinqToDB.Mapping;
using System.ComponentModel;

namespace SC.Budget.Model
{
	[Table(Name = "Project")]
	public class CProject
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		[Column] public int Rukovod_ID { get; set; }

		[DisplayName("Наименование")]
		[Column] public string Name { get; set; }
		[Column] public bool IsDeleted { get; set; }
	}
}
