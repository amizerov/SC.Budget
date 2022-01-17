using System.ComponentModel;
using System.Diagnostics;
using LinqToDB.Mapping;
using SC.Common.Services;

namespace SC.Common.Model
{
	[DebuggerDisplay("{ViewModelID}")]
	public class ObjectProjectTree : IViewModel
	{
		[Column] public string ViewModelID { get; set; }
		[Column] public string ParentID { get; set; }
		[Column] public ObjType Type { get; set; }
		[Column] public int Project_ID { get; set; }
		[Column] public int Object_ID { get; set; }

		[DisplayName("Кол-во позиций")]
		[Column] public int PositionCount { get; set; }

		[DisplayName("Название")]
		[Column] public string Name { get; set; }

		[DisplayName("Адрес")]
		[Column] public string Address { get; set; }
		[Column] public int Rukovod_ID { get; set; }

		[DisplayName("Руководитель")]
		[Column] public string RukovodName { get; set; }
	}
}
