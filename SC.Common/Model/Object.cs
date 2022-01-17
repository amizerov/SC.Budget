using LinqToDB.Mapping;
using SC.Common.Dal;
using SC.Common.Services;
using System;
using System.ComponentModel;
using System.Linq;
using LinqToDB.Data;

namespace SC.Common.Model
{
	[Table("Object")]
	public class CObjectDto : IHasID, IHasName
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		
		[Column] public string ID_1C { get; set; }
		
		[DisplayName("Имя")]
		[Column] public string Name { get; set; }
		[Column] public string City { get; set; }
		
		[DisplayName("Адрес")]
		[Column] public string Address { get; set; }
		[Column] public int Project_ID { get; set; }
		[Column] public int? Firma_ID { get; set; }
		[Column] public int? Manager_ID { get; set; }
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }
		[Column] public int Status { get; set; }
		[Column] public double? Area { get; set; }
		[Column] public string DirectorName { get; set; }
		[Column] public string DirectorPhoneNumber { get; set; }
		[Column] public string ContactPersonName { get; set; }
		[Column] public string ContactPersonPhoneNumber { get; set; }
		[Column] public double Fot { get; set; }
		[Column] public double? Kpi { get; set; }
		[Column] public double? Budget { get; set; }
		[Column] public int? Category { get; set; }
		[Column] public int? EmployeesCount { get; set; }
		[Column] public double? DistanceFromOffice { get; set; }
		[Column] public int? WorkingConditions { get; set; }
		[Column] public int? Complexity { get; set; }
		[Column] public double? Marginality { get; set; }
		[Column] public DateTime? dtu { get; set; }
		[Column] public string ModifiedBy { get; set; }
		[Column] public bool IsDeleted { get; set; }
		[Column] public string User { get; set; }

		public static int[] GetIds(bool isSklad, bool noSklad, bool hasMy, bool hasNoMy, int? firma_ID = null)
		{
			var projIds = CProjectDto.GetIds(isSklad, noSklad, hasMy, hasNoMy);

			using (var db = new DbContext())
			{
				var ids = db.GetWhere<CObjectDto>(o => o.Status == 0 &&
													   !o.IsDeleted &&
													   projIds.Contains(o.Project_ID))
					.Where(o => firma_ID == null || o.Firma_ID == firma_ID)
					.Select(o => o.ID)
					.ToArray();

				return ids.Any() ? ids : new[] { -1 };
			}
		}

		public static bool IsSklad(int objId)
		{
			using (var db = new DbContext())
			{
				var sql = @"--declare @objectId int = 1701;
							select pr.IsSklad 
							from Object obj 
								join Project pr on obj.Project_ID = pr.ID 
							where obj.ID = @objectId";

				var res = db.Query<bool>(sql,
					new DataParameter("@objectId", objId))
					.FirstOrDefault();

				return res;
			}
		}
	}
}
