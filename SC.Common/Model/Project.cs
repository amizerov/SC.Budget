using LinqToDB.Mapping;
using SC.Common.Dal;
using SC.Common.Services;
using System;
using System.Linq;
using LinqToDB;
using LinqToDB.Data;

namespace SC.Common.Model
{
	[Table("Project")]
	public class CProjectDto : IHasID, IHasName
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		[Column] public string ID_1C { get; set; }
		[Column] public string Name { get; set; }
		[Column] public int? Rukovod_ID { get; set; }
		[Column] public bool IsCash { get; set; }
		[Column] public bool IsSklad { get; set; }
		[Column] public int? Sklad_ID { get; set; }
		[Column] public bool IsShowInTabel { get; set; }
		[Column] public bool IsShowInSklad { get; set; }
		[Column] public bool IsShowInCash { get; set; }
		[Column] public bool IsLoadTo1C { get; set; }
		[Column] public bool IsDeleted { get; set; }
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }
		public override string ToString() => Name;

		public static int[] GetIds(bool isSklad = true, bool noSklad = true, bool hasMy = true, bool hasNoMy = false, Modules module = Modules.Zakup)
		{
			var user = ApplicationUser.User;
			var userId = user?.Role == Role.Admin ||
						 user?.Role == Role.Director ? 0
				: user?.ID ?? -1;

			bool IsHas(CProjectDto p, CProjectDto[] pp)
			{
				if (noSklad && p.IsSklad) return false;
				if (p.IsSklad)
				{
					if (!isSklad) return false;
				}
				else
				{
					if (!noSklad) return false;
				}
				if (userId == 0) return true;
				if (hasMy && p.Rukovod_ID == userId) return true;
				if (hasNoMy && p.Rukovod_ID != userId) return true;
				return false;
			}

			using (var db = new DbContext())
			{
				var projects = db.GetTable<CProjectDto>()
					.Where(p => !p.IsDeleted)
					.Where(p => module != Modules.Zakup || p.IsShowInSklad)
					.ToArray();

				var ids = projects.Where(p => IsHas(p, projects))
					.Select(p => p.ID)
					.ToArray();

				return ids.Any() ? ids : new[] { -1 };
			}
		}

		public static string[] GetNamesForCash()
		{
			var user = ApplicationUser.User;
			var rukId = user?.Role == Role.Rukovod ? user?.ID : 0;

			using (var db = new DbContext())
			{
				var names = db.AllNames<CProjectDto>(p => !p.IsDeleted &&
														  p.IsShowInCash &&
														  (rukId == 0 || p.Rukovod_ID == rukId));
				return names;
			}
		}
	}
}
