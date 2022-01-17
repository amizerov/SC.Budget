using am.BL;
using LinqToDB;
using LinqToDB.Data;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using SwissClean.Dal.Dto;
using SwissClean.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CPosition = SwissClean.Dal.Dto.CPosition;

namespace SwissClean.Dal
{
	public enum Filter { Any = 0, Yes = 1, No = 2 }

	#region IDataAccessService
	public interface IDataAccessService
	{
		LoginPassword GetLoginPassword();
		bool SaveLoginPassword(LoginPassword loginPassword);
		CUser GetUser(int id);
		CUser GetUser(string login, string password);
		List<CObject> GetObjects(CUserDto user);
		List<CPosition> GetPositions(int objectId);
		//CPosition GetPosition(int objectId, int positionId);
		List<CResOPDto> GetResOps(int[] objectsId, DateTime month);
		CResourceDto GetResource(int resourceId);
		List<CResourceDto> GetResources(SelectionResourceMode selectionMode, int managerId);
		List<CResourceDto> GetUserResourcesForProject(int projectId);
		List<CTabel> GetTabels(int? resOpId, DateTime month);

		void SaveResource(CResourceDto resource);
		bool DeleteResource(CResourceDto resource);
		void SaveResOp(CResOPDto r);
		bool DeleteResOp(int resOpId);
		bool DeleteResOp(CResOPDto r);

		bool SaveTabels(params CTabel[] tabels);
		List<ResOPViewModel> GetResOPViewModels(CUserDto user, DateTime month, Filter debt = Filter.Any, Filter noWork = Filter.Any);
		List<ResOPViewModel> GetResOPViewModelsForProject(CUserDto user, DateTime month, int projectId, int objId);
		DataTable GetVedomost(CUserDto user, int objectId = 0);

		decimal GetRest(CUserDto user);
		CRequestOpDto GetLastRequestOp(CUserDto user);
		bool SaveRequestOp(CRequestOpDto requestOp);

		(bool isError, string error) CreateOperation(CUserDto user, ResOPViewModel vm, decimal amount, string comment, OperationCategory category);
		COperationDto GetLastRejectingOperation(int? resOpId, OperationCategory category);

		void SaveTabelClosedForObject(ResOPViewModel vm);
		CResOPDto GetResOp(int? resOpId);
	}
	#endregion

	public class DataAccessService : IDataAccessService
	{
		private readonly CultureInfo _en = CultureInfo.CreateSpecificCulture("en-GB");
		public LoginPassword GetLoginPassword()
		{
			var file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				"SC.Tabel",
				"LoginPassword.xml");

			var res = new XmlRepository<LoginPassword>(file).Load();
			return res;
		}

		public bool SaveLoginPassword(LoginPassword loginPassword)
		{
			var file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				"SC.Tabel",
				"LoginPassword.xml");
			new XmlRepository<LoginPassword>(file).Save(loginPassword);
			return true;
		}
		public CUser GetUser(int id) => CUser.GetById(id);

		public CUser GetUser(string login, string password)
		{
			using (var db = new DbContext())
			{
				var userDto = db.GetTable<CUserDto>()
					.FirstOrDefault(u => u.Login == login && u.Pass == password);

				if (userDto == null) return null;

				var user = MapperService.Map<CUser>(userDto);
				user.RoleName = db.GetTable<CRoleDto>()
					.First(r => r.ID == (int)user.Role)
					.Name;

				return user;
			}
		}
		public List<CObject> GetObjects(CUserDto user)
		{
			if (user == null) return new List<CObject>();
			var sql = "";

			if (user.Role == Role.Director || user.Role == Role.Admin)
			{
				sql = @"Select o.ID, o.Manager_ID, o.Project_ID, o.Address
						from Object o
						Left Join Project p
						on o.Project_ID = p.ID";
			}
			else if (user.Role == Role.Rukovod)
			{
				sql = @"Select o.ID, o.Manager_ID, o.Project_ID, o.Address
						from Object o
						Left Join Project p
						on o.Project_ID = p.ID
						where p.Rukovod_ID = {1}";
			}
			else
			{
				sql = @"Select o.ID, o.Manager_ID, o.Project_ID, o.Address
						from Object o
						where o.Manager_ID = {1}";
			}

			DataTable dt = G.db_select(sql, user.ID);

			var res = dt.ToObjList(CObject.Factory);
			return res;
		}

		public List<CPosition> GetPositions(int objectId)
		{
			var sql = @"Select p.ID, p.Name, p.dtc, o.Summa Salary
						from Position p Left outer Join Oklad o on o.Position_ID = p.ID 
						Where o.Object_ID = {1}";
			DataTable dt = G.db_select(sql, objectId);
			var res = dt.ToObjList(CPosition.Factory);
			return res;
		}
		public CPosition GetPosition(int objectId, int positionId)
		{
			var sql = @"Select p.ID, p.Name, p.dtc, o.Summa Salary
						from Position p Left outer Join Oklad o on o.Position_ID = p.ID " +
							$"and o.Object_ID = {objectId} " +
						$"Where p.ID = {positionId}";
			DataTable dt = G.db_select(sql);
			var res = dt.ToObjList(CPosition.Factory);
			return res.FirstOrDefault();
		}

		public List<CResOPDto> GetResOps(int[] objectsId, DateTime month)
		{
			if (objectsId == null || objectsId.Length == 0) return new List<CResOPDto>();
			using (var db = new DbContext())
			{
				var objectsIdTxt = objectsId.ToString(",");
				var sql = $"select * from ResOP where OBJECT_ID in ({objectsIdTxt}) " +
						  "and YEAR(Month) = Year(@month) and Month(Month) = Month(@month)";

				var res = db.Query<CResOPDto>(sql,
						new DataParameter("@month", month))
					.ToList();
				return res;
			}
		}
		public void SaveResOp(CResOPDto resOp)
		{
			using (var db = new DbContext())
			{
				if (resOp.ID > 0) db.Update(resOp);
				else resOp.ID = db.InsertWithInt32Identity(resOp);
			}
		}
		public bool DeleteResOp(int resOpId)
		{
			return G.db_exec(@"delete ResOP where ID = {1}", resOpId);
		}
		public bool DeleteResOp(CResOPDto r)
		{
			return G.db_exec(@"delete ResOP where Object_ID = {1}
										and Resource_ID = {2}
										and Year(Month) = {3}
										and Month(Month) = {4}",
								r.Object_ID,
								r.Resource_ID,
								r.Month?.Year,
								r.Month?.Month);
		}

		public List<CResourceDto> GetResources(SelectionResourceMode selectionMode, int managerId)
		{
			var cond = new Dictionary<SelectionResourceMode, string>
			{
				[SelectionResourceMode.All] = $"Manager_ID = {managerId} or Manager_ID is null",
				[SelectionResourceMode.Staff] = $"Manager_ID = {managerId}",
				[SelectionResourceMode.Freelance] = "Manager_ID is null",
			};

			using (var db = new DbContext())
			{
				var sql = $"select * from Resource where {cond[selectionMode]}";
				var res = db.Query<CResourceDto>(sql)
					.ToList();
				return res;
			}
		}

		public List<CResourceDto> GetUserResourcesForProject(int projectId)
		{
			using (var db = new DbContext())
			{
				var sqlRes = @"select distinct r.* from Resource r
							join[User] u on u.ID = r.User_ID
							join Object obj on obj.Manager_ID = u.ID
							join Project pr on obj.Project_ID = pr.ID " +
							 $"where pr.ID = {projectId}" +

							 @"union all select distinct r.* from Resource r
								join [User] u on u.ID = r.User_ID
							join Project pr on pr.Rukovod_ID = u.ID " +
						  $@"where pr.ID = {projectId}";
				var res = db.Query<CResourceDto>(sqlRes).ToList();
				var usersId = string.Join(", ", res.Select(r => r.User_ID));

				var sqlUsers = @"select distinct u.* from [User] u
								join Object obj on obj.Manager_ID = u.ID
								join Project pr on obj.Project_ID = pr.ID " +
							   $"where pr.ID = {projectId}";
				if (usersId.NoEmpty()) sqlUsers += $" and u.ID not in ({usersId})";

				sqlUsers += @"union all select distinct u.* from [User] u
								join Project pr on pr.Rukovod_ID = u.ID " +
								$"where pr.ID = {projectId}";
				if (usersId.NoEmpty()) sqlUsers += $" and u.ID not in ({usersId})";
				var users = db.Query<CUserDto>(sqlUsers).ToArray();

				res.AddRange(users.Select(MapperService.Map<CResourceDto>));
				return res.OrderBy(r => r.Name).ToList();
			}
		}

		public CResourceDto GetResource(int resourceId)
		{
			using (var db = new DbContext())
			{
				var res = db.GetTable<CResourceDto>()
					.FirstOrDefault(r => r.ID == resourceId);
				return res;
			}
		}
		public void SaveResource(CResourceDto r)
		{
			using (var db = new DbContext())
			{
				if (r.ID > 0) db.Update(r);
				else r.ID = db.InsertWithInt32Identity(r);
			}
		}
		public bool DeleteResource(CResourceDto r)
		{
			return G.db_exec(@"delete Resource 
									where Name = {1}
									and Object_ID = {2}
									and Manager_ID = {3}
									and Card = {4}
									and Phone = {5}
									and OfficialSalary = {6}"
				, r.Name != null ? $"'{r.Name}'" : "NULL",
				r.Object_ID?.ToString() ?? "NULL",
				r.Manager_ID?.ToString() ?? "NULL",
				r.Card != null ? $"'{r.Card}'" : "NULL",
				r.Phone != null ? $"'{r.Phone}'" : "NULL",
				r.OfficialSalary?.ToString() ?? "NULL");
		}

		public List<CTabel> GetTabels(int? resOpId, DateTime month)
		{
			if (resOpId == null) return new List<CTabel>();

			var sql = @"SELECT *
						FROM Tabel
						Where ResOP_ID = {1}
						and YEAR(Date) = {2}
						and Month(Date) = {3}";

			DataTable dt = G.db_select(sql, resOpId, month.Year, month.Month);

			var res = dt.ToObjList(CTabel.Factory);
			return res;
		}
		public bool SaveTabels(params CTabel[] tabels)
		{
			var bld = new StringBuilder();

			var deleted = tabels.Where(t => !t.IsExit).ToArray();
			if (deleted.Any())
			{
				var resOP_IDs = deleted.Select(t => t.ResOP_ID).Distinct().ToString(",");
				var years = deleted.Select(t => t.Date?.Year ?? -1).Distinct().ToString(",");
				var months = deleted.Select(t => t.Date?.Month ?? -1).Distinct().ToString(",");
				var days = deleted.Select(t => t.Date?.Day ?? -1).Distinct().ToString(",");

				bld.Append($"delete Tabel where ResOP_ID in ({resOP_IDs})\n");
				bld.Append($"and YEAR(Date) in ({years})\n");
				bld.Append($"and MONTH(Date) in ({months})\n");
				bld.Append($"and Day(Date) in ({days})\n");
			}

			var source = tabels.Where(t => t.IsExit).ToArray();
			if (source.Any())
			{
				bld.Append("merge Tabel using(\n");
				for (int i = 0; i < source.Length; i++)
				{
					if (i > 0) bld.Append("union ");
					bld.Append($"select {source[i].ResOP_ID} ResOP_ID, '{source[i].Date:yyyyMMdd}' Date\n");
				}
				bld.Append(@") as source
							on Tabel.ResOP_ID = source.ResOP_ID 
							and YEAR(Tabel.Date) = YEAR(source.Date)
							and MONTH(Tabel.Date) = MONTH(source.Date)
							and DAY(Tabel.Date) = DAY(source.Date)
						when not matched then
							insert (ResOP_ID, Date)
							values (source.ResOP_ID, source.Date);");
			}

			var sql = bld.ToString();
			return G.db_exec(sql);
		}

		public List<ResOPViewModel> GetResOPViewModels(CUserDto user, DateTime month, Filter debt = Filter.Any, Filter noWork = Filter.Any)
		{
			if (user == null) return new List<ResOPViewModel>();

			using (var db = new DbContext())
			{
				var sql = user.Role == Role.Director || user.Role == Role.Admin ? $"GetResOPForRukovod 0, N'{month:yyyyMMdd}', 0, {(int)debt}, {(int)noWork}"
					: user.Role == Role.Rukovod ? $"GetResOPForRukovod {user.ID}, N'{month:yyyyMMdd}', 0, {(int)debt}, {(int)noWork}"
					: $"GetResOPForManager {user.ID}, N'{month:yyyyMMdd}', 0, {(int)debt}, {(int)noWork}";
				var res = db.Query<ResOPViewModel>(sql)
					.ToList();
				return res;
			}
		}
		public List<ResOPViewModel> GetResOPViewModelsForProject(CUserDto user, DateTime month, int projectId, int objId)
		{
			if (user == null) return new List<ResOPViewModel>();

			using (var db = new DbContext())
			{
				var sql = projectId > 0 ? $"GetResOPForRukovod {user.ID}, N'{month:yyyyMMdd}', {projectId}"
					: $"GetResOPForManager {user.ID}, N'{month:yyyyMMdd}', {objId}";
				var res = db.Query<ResOPViewModel>(sql)
					.ToList();
				return res;
			}
		}

		public DataTable GetVedomost(CUserDto user, int objectId = 0)
		{
			return G.db_select($"GetVedomost {user.ID}, {objectId}");
		}

		public decimal GetRest(CUserDto user)
		{
			if (user == null) return 0;
			var dt = G.db_select($"select * from Account where User_ID = {user.ID}");
			if (dt.Rows.Count == 0) return 0;
			var res = G._Dec(dt.Rows[0]["Rest"]);
			return res;
		}

		public CRequestOpDto GetLastRequestOp(CUserDto user) => CRequestOpDto.Last(user);

		public bool SaveRequestOp(CRequestOpDto r)
		{
			return G.db_exec(
@"if exists (select id from RequestOP where id = {1})
		update RequestOP set
			User_ID = {2}, DateTime = {3}, Amount = {4}, Status = {5}, Comment = {6}
		where id = {1}
	else
		insert RequestOP(User_ID, DateTime, Amount, Status, Comment)
		values({2}, {3}, {4}, {5}, {6})",
				r.ID,
				r.User_ID,
				$"'{r.DateTime:yyyyMMdd HH:mm}'",
				r.Amount.ToString(_en),
				(int)r.Status,
				r.Comment != null ? $"'{r.Comment}'" : "NULL");
		}

		public (bool isError, string error) CreateOperation(CUserDto user, ResOPViewModel vm, decimal amount, string comment, OperationCategory category)
		{
			var fromAcc = CAccountDto.GetOrCreate(user.ID);
			var op = COperationDto.ResOp(DateTime.Now, amount, vm.Month, vm.Project_ID, comment, category, fromAcc, vm.ResOP_ID ?? -1);
			return op.Insert();
		}

		public COperationDto GetLastRejectingOperation(int? resOpId, OperationCategory category)
		{
			using (var db = new DbContext())
			{
				var res = db.GetTable<COperationDto>()
					.Where(o => o.ToResOP_ID == resOpId)
					.Where(o => o.Category == category)
					.OrderBy(o => o.DateTime)
					.ToArray();

				return res.LastOrDefault();
			}
		}

		public void SaveTabelClosedForObject(ResOPViewModel vm)
		{
			using (var db = new DbContext())
			{
				var tcExists = db.FirstOrDefault<CTabelClosedDto>(t =>
						t.Object_ID == vm.Object_ID &&
						t.Month.Year == vm.Month.Year &&
						t.Month.Month == vm.Month.Month);

				if (vm.IsClosed)
				{
					if (tcExists != null) return;

					var tc = new CTabelClosedDto
					{
						Month = vm.Month,
						Object_ID = vm.Object_ID,
						dtu = DateTime.Now,
						User = Environment.UserName
					};
					db.Insert(tc);
				}
				else if (tcExists != null)
				{
					db.Delete(tcExists);
				}
			}
		}

		public CResOPDto GetResOp(int? resOpId)
		{
			if (resOpId == null) return null;
			using (var db = new DbContext())
			{
				var res = db.GetByID<CResOPDto>(resOpId);
				return res;
			}
		}
	}
}