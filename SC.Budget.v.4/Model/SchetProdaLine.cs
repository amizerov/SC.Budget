using LinqToDB.Mapping;
using SC.Common.Model;
using System.ComponentModel;

namespace SC.Budget.Model
{
	public class CSchetProdaLine : CSchetProdaLineDto
	{
		[Column(Name = "ProjectName")]
		[DisplayName("Проект")]
		public string ProjectName { get; set; }
	}
}
