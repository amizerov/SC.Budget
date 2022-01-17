using LinqToDB.Mapping;
using SC.Common.Model;

namespace SC.Budget.Model
{
	public class CResuorce : CResourceDto
	{
		[Column] public Role Role { get; set; }
	}
}
