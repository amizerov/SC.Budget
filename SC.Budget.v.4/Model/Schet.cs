using LinqToDB.Mapping;
using SC.Common.Model;

namespace SC.Budget.Model
{
	public class CSchet : CSchetDto
	{
		[Column] public string ProjectName { get; set; }
		[Column] public bool IsCash { get; set; }
	}

	public class SchetMarginality : CSchetDto
	{
		[Column] public DetailClass Class { get; set; }
	}
}
