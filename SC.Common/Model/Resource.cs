using LinqToDB.Mapping;
using SC.Common.Services;
using System;

namespace SC.Common.Model
{
	[Flags]
	public enum SelectionResourceMode
	{
		Staff = 1,
		Freelance = 1 << 1,
		All = Staff | Freelance
	}

	[Table(Name = "Resource")]
	public class CResourceDto : IHasID
	{
		[PrimaryKey, Identity]
		public int ID { get; set; }

		[Column] public int? Object_ID { get; set; }
		[Column] public int? Manager_ID { get; set; }
		[Column] public string Name { get; set; }
		[Column] public string Phone { get; set; }
		[Column] public string Description { get; set; }
		[Column] public decimal? OfficialSalary { get; set; }
		[Column] public decimal? Nalog { get; set; }
		[Column] public string Card { get; set; }
		[Column] public bool NoWorking { get; set; }
		[Column] public int? User_ID { get; set; }
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }
	}
}
