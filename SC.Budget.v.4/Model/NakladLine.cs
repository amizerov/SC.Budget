using LinqToDB.Mapping;
using SC.Common.Model;

namespace SC.Budget.Model
{
	public class NakladLine : CNakladLineDto
	{
		[Column] public decimal Cost { get; set; }
	}
}
