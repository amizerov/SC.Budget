using LinqToDB.Mapping;
using SC.Common.Services;
using System;

namespace SC.Common.Model
{
	[Table(Name = "Operation")]
	public class CVersionHistory : IHasID
	{
		public enum VersionSerious { Standard, Serious, Critical }

		[PrimaryKey, Identity] public int ID { get; set; }
		[Column] public string Solution { get; set; }
		[Column] public string Project { get; set; }
		[Column] public string Version { get; set; }
		[Column] public DateTime DateTime { get; set; }
		[Column] public string Description { get; set; }
		[Column] public VersionSerious Serious { get; set; }
		[Column] public string User { get; set; }
	}
}