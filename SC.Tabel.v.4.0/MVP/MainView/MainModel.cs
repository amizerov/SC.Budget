using LinqToDB;
using SC.Common.Model;
using SC.Common.Services;
using SwissClean.Dal;
using SwissClean.Dal.Dto;
using SwissClean.MVP.CreateResource;
using SwissClean.MVP.Login;
using SwissClean.MVP.MainView.ViewModels;
using SwissClean.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwissClean.MVP.MainView
{
	public class MainModel
	{
		#region Fields
		private readonly IDataAccessService _db;
		private CUser _user;

		//private List<CPosition> _objPositions;
		private List<CResourceDto> _managerResources;
		private List<CResOPDto> _allResOps;
		#endregion

		public MainModel(IDataAccessService dataAccessService, ILoginModel loginModel)
		{
			_db = dataAccessService;
			LoginModel = loginModel;
			LoginModel.Logged += (sender, args) => UpdateLogin();
		}

		#region Events
		public event EventHandler<CUser> LoginChanged;
		public event EventHandler<MainViewModel> ResOpsUpdated;
		public event EventHandler<SelectionResOpViewModel> SelectedResOp;
		public event EventHandler<string> Error;
		#endregion

		#region Login
		public ILoginModel LoginModel { get; }
		public void Logout()
		{
			ApplicationUser.User = null;
			UpdateLogin();
		}
		private void UpdateLogin()
		{
			_user = ApplicationUser.User;
			Reload();
			LoginChanged?.Invoke(this, _user); //после обновления восстанавливаем состояние контролов
		}
		#endregion

		public DateTime Month { get; private set; } = DateTime.Now;
		public CResOPDto CurrentResOp { get; set; }

		public Filter DebtFilter { get; set; }
		public Filter NoWorkFilter { get; set; }

		#region TopMenu
		public CreateResourceModel GetCreateResourceModel()
		{
			var model = new CreateResourceModel(_db);
			model.Changed += (sender, vm) => Reload();
			return model;
		}
		public void EditResource(ResOPViewModel vm)
		{
			if (!Access()) return;
			var resource = MapperService.Map<CResourceDto>(vm);
			_db.SaveResource(resource);
			CurrentResOp = MapperService.Map<CResOPDto>(vm);
			CalculateSalaryAndSaveResOp(CurrentResOp);
			Reload();
		}
		public void DeleteResOp()
		{
			if (!Access()) return;
			_db.DeleteResOp(CurrentResOp.ID);
			Reload();
		}
		public void ChangeMonth(DateTime month)
		{
			Month = month;
			Reload();
		}
		public void CreateVedomost(int objectId)
		{
			try
			{
				var resOps = _db.GetResOPViewModels(_user, Month);

				resOps = resOps
					.Where(r => r.Type == ObjType.ResOP)
					.Where(r => objectId == 0 || r.Object_ID == objectId)
					.ToList();

				new Excel().CreateVedomost(resOps, Month);
			}
			catch (Exception ex) { Error?.Invoke(this, ex.ToString()); }
		}
		public void RecalculateAllPays()
		{
			try
			{
				if (!Access()) return;
				TaskbarProgress.Start();
				for (var i = 0; i < _allResOps.Count; i++)
				{
					var resOp = _allResOps[i];
					var resource = _db.GetResource(resOp.Resource_ID);
					//var position = _db.GetPosition(resOp.Object_ID ?? 0, resOp.Position_ID);

					resOp.CalculateSalary(resource);
					_db.SaveResOp(resOp);
					TaskbarProgress.SetValue(i, _allResOps.Count);
				}
				TaskbarProgress.Finish();
			}
			catch (Exception ex)
			{
				Error?.Invoke(this, ex.ToString());
			}
		}

		public void SaveClosedTabel(ResOPViewModel vm)
		{
			try
			{
				//if (vm.IsClosed && vm.Debt > 0)
				//{
				//	Error?.Invoke(this, "Долги не выполачены.\nПродолжение невозможно.");
				//	return;
				//}
				if (vm.Type == ObjType.Project)
				{
					var objs = _db.GetResOPViewModels(_user, vm.Month);
					objs = objs.Where(o => o.Project_ID == vm.Project_ID)
						.Where(o => o.Type == ObjType.Object).ToList();

					foreach (var obj in objs)
					{
						obj.IsClosed = vm.IsClosed;
						_db.SaveTabelClosedForObject(obj);
					}
				}
				else
				{
					_db.SaveTabelClosedForObject(vm);
				}
				Reload();
			}
			catch (Exception ex)
			{
				Error?.Invoke(this, ex.ToString());
			}
		}
		#endregion

		public void Reload()
		{
			try
			{
				_user = ApplicationUser.User;

				var objects = _db.GetObjects(_user);
				var objectsId = objects?.Select(o => o.ID).ToArray();

				_allResOps = _db.GetResOps(objectsId, Month);

				var vm = new MainViewModel
				{
					Rest = _db.GetRest(_user),
					LastRequestOp = _db.GetLastRequestOp(_user),
					Month = Month,
					ResOps = _db.GetResOPViewModels(_user, Month, DebtFilter, NoWorkFilter),
					SelectionResOp = GetSelectionResOpViewModel(),
				};

				ResOpsUpdated?.Invoke(this, vm);
			}
			catch (Exception ex)
			{
				Error?.Invoke(this, ex.ToString());
			}
		}

		public void ChangeResource(ResOPViewModel vm)
		{
			var resource = MapperService.Map<CResourceDto>(vm);
			_db.SaveResource(resource);
		}

		#region ResOps
		public void ChangeResOp(ResOpEventArgs e)
		{
			var resOpDb = _db.GetResOp(e.ViewModel.ResOP_ID);
			var prop = typeof(CResOPDto).GetProperty(e.FieldNameChanged);
			if (prop == null) return;
			var resOpVm = MapperService.Map<CResOPDto>(e.ViewModel);
			var val = prop.GetValue(resOpVm);
			prop.SetValue(resOpDb, val);

			resOpDb.User = Environment.UserName;
			resOpDb.dtu = DateTime.Now;

			CalculateSalaryAndSaveResOp(resOpDb);
			Reload();
		}

		public void CreateOperation(ResOPViewModel vm, decimal amount, OperationCategory category)
		{
			if (!Access()) return;
			if (amount == 0) return;
			var user = ApplicationUser.User;
			var (isError, error) = _db.CreateOperation(user, vm, amount, $"За {Month:MMMM yyyy}г", category);

			if (isError) Error?.Invoke(this, error);
			else Reload();
		}
		public void RejectOperation(COperationDto op)
		{
			if (!Access()) return;
			var (isError, error) = op.Reject();
			Reload();
			if (isError) Error?.Invoke(this, error);
		}
		public void CreateResOp(CResOPDto resOp)
		{
			if (!Access()) return;
			CurrentResOp = resOp;
			_db.SaveResOp(resOp);
			Reload();
		}
		public void ReplaceResource(ResOPViewModel vm)
		{
			CurrentResOp.Resource_ID = _managerResources.First(r => r.Name == vm.Name).ID;
			CalculateSalaryAndSaveResOp(CurrentResOp);
			Reload();
		}
		public void SelectResOp(ResOPViewModel vm)
		{
			try
			{
				CurrentResOp = vm.Type != ObjType.ResOP ? null
					: _allResOps.FirstOrDefault(resOp => resOp.ID == vm.ResOP_ID);

				//_objPositions = _db.GetPositions(vm.Object_ID);
				_managerResources = _db.GetResources(SelectionResourceMode.All, vm.ManagerID ?? -1);

				var tabelsDb = _db.GetTabels(vm.ResOP_ID, Month);
				CurrentTabels = Month.AllDaysInMonth()
					.Select(date => new CTabel
					{
						ResOP_ID = CurrentResOp?.ID,
						Date = date,
						IsExit = tabelsDb.Any(t => t.Date?.Date == date.Date)
					}).ToList();

				SelectedResOp?.Invoke(this, GetSelectionResOpViewModel());
			}
			catch (Exception ex)
			{
				Error?.Invoke(this, ex.ToString());
			}
		}
		#endregion

		#region Tabels
		public List<CTabel> CurrentTabels { get; private set; }
		public void SaveTabel(TabelViewModel vm)
		{
			var tabel = new CTabel
			{
				ID = vm.ID,
				ResOP_ID = vm.ResOP_ID,
				Date = vm.Date,
				IsExit = !vm.IsExit, // данные приходят до изменений, поэтому обратное значение
			};

			if (tabel.IsExit && !_allResOps.Any(resOp => resOp.Resource_ID == vm.Resource_ID))
			{
				CreateResOpBeforeCreatingTabel(vm);
				tabel.ResOP_ID = CurrentResOp?.ID ?? -1;
			}

			if (IsDublicateError(tabel)) return;
			_db.SaveTabels(tabel);
			var resOpDb = _db.GetResOp(tabel.ResOP_ID);
			CalculateSalaryAndSaveResOp(resOpDb);
			CurrentResOp = resOpDb;
			Reload();
		}
		private void CreateResOpBeforeCreatingTabel(TabelViewModel vm = null)
		{
			if (vm != null) CurrentResOp = new CResOPDto(Month, vm.Object_ID, vm.Resource_ID);
			CurrentResOp.User = Environment.UserName;

			_db.SaveResOp(CurrentResOp);
			Reload();
		}

		public void SaveTabels(DateTime first, int workCount, int weekendCount)
		{
			var tabels = GenTabels(first, workCount, weekendCount).ToArray();
			if (IsDublicateError(tabels)) return;
			_db.SaveTabels(tabels);
			CalculateSalaryAndSaveResOp(CurrentResOp);
			Reload();
		}

		private bool IsDublicateError(params CTabel[] tabels)
		{
			return false;
			foreach (var tabel in tabels)
			{
				if (!tabel.IsExit) continue;
				var resOp = _allResOps.FirstOrDefault(r => r.ID == tabel.ResOP_ID);

				var resource = _managerResources.FirstOrDefault(r => r.ID == resOp.Resource_ID);
				if (resource?.User_ID != null) return false;

				var otherResOps = _allResOps
					.Where(r => r.ID != resOp.ID)
					.Where(r => r.Resource_ID == resOp.Resource_ID);
				//.Where(r => r.Position_ID == resOp.Position_ID);
				foreach (var rr in otherResOps)
				{
					var otherTabels = _db.GetTabels(rr.ID, rr.Month.Value);
					if (otherTabels.Any(t => t.Date.Value.Date == tabel.Date && t.IsExit))
					{
						Error?.Invoke(this, "Этот сотружник уже выходил в этой должности в этот день на работу на других объектах.\n" +
											"Продолжение невозможно.");
						return true;
					}
				}
			}
			return false;
		}
		private List<CTabel> GenTabels(DateTime first, int workCount, int weekendCount)
		{
			if (!_allResOps.Any(res => res.Resource_ID == CurrentResOp.Resource_ID))
			{
				CreateResOpBeforeCreatingTabel();
			}
			bool IsWorkDay(DateTime day)
			{
				if (workCount <= 0) return false;
				if (weekendCount <= 0) return true;

				var mod = Math.Abs((first - day).TotalDays) % (workCount + weekendCount);
				return day < first ? (mod == 0 || mod > weekendCount) : mod < workCount;
			}

			var tabels = Month.AllDaysInMonth()
				.Select(date => new CTabel
				{
					ResOP_ID = CurrentResOp?.ID,
					Date = date,
					IsExit = IsWorkDay(date)
				}).ToList();
			return tabels;
		}
		#endregion

		private void CalculateSalaryAndSaveResOp(CResOPDto resOp)
		{
			if (!Access()) return;
			var tabelsDb = _db.GetTabels(resOp.ID, Month);
			CurrentTabels = Month.AllDaysInMonth()
				.Select(date => new CTabel
				{
					ResOP_ID = CurrentResOp.ID,
					Date = date,
					IsExit = tabelsDb.Any(t => t.Date?.Date == date.Date)
				}).ToList();

			resOp.FactDays = Month.AllDaysInMonth()
				.Count(date => CurrentTabels
					.Any(t => t.ResOP_ID == resOp.ID &&
							  t.Date?.Date == date.Date &&
							  t.IsExit));

			var resource = _db.GetResource(resOp.Resource_ID);
			//var position = _objPositions.FirstOrDefault(p => p.ID == resOp.Position_ID);

			resOp.CalculateSalary(resource);
			_db.SaveResOp(resOp);
		}

		#region GetSelectionResOpViewModel
		private SelectionResOpViewModel GetSelectionResOpViewModel() => new SelectionResOpViewModel
		{
			ResOp = CurrentResOp,
			ResourceNames = _managerResources?
				.Where(r => !_allResOps.Any(resOp => resOp.Resource_ID == r.ID))
				.Select(r => r.Name)
				.ToArray(),
			//PositionNames = _objPositions?.Select(p => p.Name).ToArray(),
			Tabels = TabelViewModel.Factory(CurrentResOp, Month, CurrentTabels),
		};
		#endregion

		public void SetRejectingOperation(RejectOperationEventArgs e)
		{
			e.Operation = _db.GetLastRejectingOperation(e.ViewModel.ResOP_ID, e.ResOpByCashUnit.Category);
		}

		public void SetPayAll(PayEventArgs e)
		{
			var projectId = e.ResOpViewModel.Type == ObjType.Project
				? e.ResOpViewModel.Project_ID : 0;
			var objId = e.ResOpViewModel.Type == ObjType.Object
				? e.ResOpViewModel.Object_ID : 0;
			e.Resources = _db.GetResOPViewModelsForProject(_user, Month, projectId, objId)
				.Where(r => r.Debt > 0)
				.OrderBy(r => r.ObjectNameForResOp)
				.ToList();
		}

		private bool Access()
		{
			if (ApplicationUser.User?.Role == Role.Admin) return true;
			var editableDate = AppSettings.EditableDate;
			var month = new DateTime(Month.Year, Month.Month, 1);
			if (month < editableDate)
			{
				Error?.Invoke(this, $"Редактирование позже {editableDate:d} запрещено.\n" +
									"Обратитесь к администратору");
				return false;
			}
			return true;
		}
	}
}
