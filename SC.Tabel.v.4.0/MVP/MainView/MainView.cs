using am.BL;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using SwissClean.MVP.Login;
using SwissClean.MVP.MainView.ViewModels;
using SwissClean.MVP.SetResourceOnObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SwissClean.Properties;

namespace SwissClean.MVP.MainView
{
	public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		#region Fields and Properties
		private ResOPViewModel _currentResOp;
		private ResOPViewModel _prevResOp;
		private decimal _rest;
		private bool _updating;

		private bool TreeResOpEditable(bool toPay = false)
		{
			var vm = _currentResOp;
			if (!toPay && vm.IsClosed) return false;
			if (vm.Type != ObjType.ResOP) return false;
			var user = ApplicationUser.User;
			if (user?.Role == Role.Manager && vm.User_ID == null) return true;
			if (user?.Role == Role.Rukovod && vm.User_ID != null) return true;
			return false;
		}
		public DateTime FirstWorkDay => (DateTime)deFirstWorkDay.EditValue;
		#endregion

		public MainView()
		{
			try
			{
				InitializeComponent();

				G.OnError += error => ShowError($"Ошибка в базе данных:\n{error}");
#if DEBUG
				WindowState = FormWindowState.Maximized;
				Text += $" [DEBUG] {DbContext.DataSource}";
#endif
				LayoutSaver.Restore(this);
				lblVersion.Caption = "Версия: " + Application.ProductVersion;

				cbMonth.EditValue = DateTime.Now;
				deFirstWorkDay.EditValue = DateTime.Now.FirstMonday();

				gcTabels.Paint += GcTabels_Paint;

				UpdateLogin();
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}

		#region Events
		public event EventHandler Logging;
		public event EventHandler Logout;

		public event EventHandler<Dal.Filter> DebtFilterChange;
		public event EventHandler<Dal.Filter> NoWorkFilterChange;
		public event EventHandler<ResOPViewModel> CreatingResource;
		public event EventHandler<ResOPViewModel> EditingResource;
		public event EventHandler<ResOPViewModel> DeletingResOp;
		public event EventHandler AllResourceEditing;

		public event EventHandler<DateTime> ChangedMonth;

		public event EventHandler Days2_2Click;
		public event EventHandler Days5_2Click;
		public event EventHandler AllDaysClick;
		public event EventHandler DeletingAllDays;

		public event EventHandler<int> VedomostClick;

		public event EventHandler UpdatingRest;
		public event EventHandler<PayEventArgs> BeforePayAll;

		public event EventHandler CreatingRequestOp;
		public event EventHandler<ResOpEventArgs> ChangedResOp;
		public event Action<ResOPViewModel, decimal, OperationCategory> CreatingOperation;
		public event EventHandler<RejectOperationEventArgs> GetRejectingOperation;
		public event EventHandler RecalculatingAllPays;
		public event EventHandler<COperationDto> RejectingOperation;
		public event EventHandler<ResOPViewModel> ReplacingResource;
		public event EventHandler SettingResourceOnObject;
		public event EventHandler<ResOPViewModel> SelectResource;

		public event EventHandler<TabelViewModel> ChangedTabel;

		public event EventHandler<ResOPViewModel> ClosingTabel;
		#endregion

		#region Login
		public void UpdateLogin()
		{
			try
			{
				pnTabelMain.BeginInit();

				var user = ApplicationUser.User;

				pnTabelMain.Visible //Контролы должны быть видимыми до заполнения
					= ribbon.Enabled //Контролы должны быть неактивными если юзер вышел
					= user != null;

				pnTabelMain.EndInit();
				btnLogin.Visibility = user != null ? BarItemVisibility.Never : BarItemVisibility.Always;
				btnLogOut.Visibility = user == null ? BarItemVisibility.Never : BarItemVisibility.Always;

				btnRecalculateAllPays.Visibility = user?.Role == Role.Admin ? BarItemVisibility.Always : BarItemVisibility.Never;

				if (user != null)
				{
					lblUser.Caption = $"Пользователь: {user.Login} / {user.Name} / {user.RoleName}";
					colNalog.Visible = user.Role != Role.Manager;
					ResOpSelectionChange();
				}
				else
				{
					lblUser.Caption = "Вход не выполнен";
				}
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}

		public ILoginView LoginView => new LoginView { Owner = this };

		private void BtnLogin_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				Logging?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}

		private void BtnLogOut_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (MessageService.ShowQuestion("Вы уверены, что хотите выйти?") == DialogResult.Yes)
				{
					Logout?.Invoke(this, EventArgs.Empty);
				}
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		#endregion

		#region TopMenu
		private void BtnCreateResource_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				CreatingResource?.Invoke(this, _currentResOp);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		public SetResourceOnObjectView SetResourceOnObjectView
		{
			get => new SetResourceOnObjectView(_currentResOp) { Owner = this };
		}
		private void BtnEditResource_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				EditingResource?.Invoke(this, _currentResOp);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void BtnSetResourceOnObject_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				SettingResourceOnObject?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void BtnDeleteResource_ItemClick(object sender, ItemClickEventArgs e)
		{
			DeleteResOp();
		}
		private void btnAllResources_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				AllResourceEditing?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void CbMonth_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (_updating) return;
				ChangedMonth?.Invoke(this, (DateTime)cbMonth.EditValue);
				deFirstWorkDay.EditValue = ((DateTime)cbMonth.EditValue).FirstMonday();
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void btnDebt_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				var filter = (Dal.Filter)Enum.Parse(typeof(Dal.Filter), btnDebt.EditValue?.ToString());
				DebtFilterChange?.Invoke(this, filter);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void btnsNoWorking_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				var filter = (Dal.Filter)Enum.Parse(typeof(Dal.Filter), btnsNoWorking.EditValue?.ToString());
				NoWorkFilterChange?.Invoke(this, filter);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void BtnVedomostTotal_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				VedomostClick?.Invoke(this, 0);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void BtnVedomostForObject_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				VedomostClick?.Invoke(this, _currentResOp.Object_ID);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void BtnExportToExcel_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var excel = new ExcelService(this))
				{
					excel.GridToExcel(treeResOp.ExportToXlsx)
						.SetAutoFit();
				}
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}

		private void Btn5_2Days_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{

				Days5_2Click?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void btn2_2Days_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				Days2_2Click?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void BtnAllDays_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				AllDaysClick?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void BtnDeleteAllDays_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				DeletingAllDays?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}

		private void btnRestUpdate_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				UpdatingRest?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void btnRequest_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				CreatingRequestOp?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}

		private void btnPayAll_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (!btnPayAll.Enabled) return;
				var vm = _currentResOp;
				var eaPay = new PayEventArgs { ResOpViewModel = vm };
				BeforePayAll?.Invoke(this, eaPay);

				if (!eaPay.Resources.Any())
				{
					MessageService.ShowMessage("Всё долги Вашим сотрудникам выданы.\n" +
											   "Продолжение невозможно.");
					return;
				}

				var i = 1;
				var quest = $"Выдать долги всем сотрудникам на {(vm.Type == ObjType.Project ? "проекте" : "объекте")}:\n" +
							$"'{vm.Name}'\n\n" +
							string.Join("\n", eaPay.Resources.Select(r =>
								 $"{i++}) {r.Name} ({r.Position})" +
								 $"{(vm.Type == ObjType.Project ? $" Объект: {r.ObjectNameForResOp}" : "")}" +
								 $": {r.Debt:c2}\n")) + "\n" +
							$"Итого: {eaPay.Resources.Sum(res => res.Debt):c2}?";
				if (MessageService.ShowQuestion(quest, MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
				{
					eaPay.Resources.ForEach(r =>
					{
						CreatingOperation?.Invoke(r, r.Debt, OperationCategory.Paid);
					});
				}
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void btnPayOne_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (!btnPayOne.Enabled) return;

				var r = _currentResOp;
				if (r.Type != ObjType.ResOP) return;

				var amount = r.Debt;
				if (amount <= 0)
				{
					MessageService.ShowMessage($"Сотруднику '{r.Name}' зарплата выплачена в полном размере.\n" +
											   "Продолжение невозможно.");
					return;
				}

				var quest = $"Выдать сотруднику '{r.Name}' зарплату {amount:c2}?";
				if (MessageService.ShowQuestion(quest) != DialogResult.Yes) return;

				CreatingOperation?.Invoke(r, amount, OperationCategory.Paid);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void btnRecalculateAllPays_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				RecalculatingAllPays?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}

		}
		private void btCloseTabel_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				var vm = (ResOPViewModel)_currentResOp.Clone();
				vm.IsClosed = btCloseTabel.Down;

				var q = $"{(vm.IsClosed ? "Закрыть" : "Отменить закрытие")} " +
						$"{(vm.Type == ObjType.Project ? "проект" : "объект")}" +
						$"{(vm.IsClosed ? "" : "а")} " +
						$"'{(vm.Type == ObjType.Project ? vm.Name : vm.ObjectNameForResOp)}'?";
				if (MessageService.ShowQuestion(q) != DialogResult.Yes)
				{
					btCloseTabel.Down = vm.IsClosed;
					return;
				}
				ClosingTabel?.Invoke(this, vm);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		#endregion

		#region Update
		public void UpdateAll(MainViewModel viewModel)
		{
			try
			{
				_updating = true;

				using (new TreeListStateSaver(treeResOp))
				{
					treeResOp.DataSource = viewModel.ResOps;
				}

				UpdateBalance(viewModel);
				ResOpSelectionChange();
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
			finally
			{
				_updating = false;
			}
		}

		private void UpdateBalance(MainViewModel viewModel)
		{
			try
			{
				_rest = viewModel.Rest;
				lbRest.Caption = $"Ваш баланс: {_rest:N0} р";

				var request = viewModel.LastRequestOp;

				lbLastRequestAmount.Caption = $"Сумма: {request.Amount:N0}р";
				lbLastRequestDate.Caption = $"Дата: {request.DateTime:d}";
				lbLastRequestStatus.Caption = $"Статус: {request.Status.DisplayName()}";
				var images = new Dictionary<RequestStatus, Bitmap>
				{
					[0] = Properties.Resources.Clock,
					[RequestStatus.Wait] = Properties.Resources.Clock,
					[RequestStatus.Rejected] = Properties.Resources.Rejected,
					[RequestStatus.Agreed] = Properties.Resources.Ok,
					[RequestStatus.Paid] = Properties.Resources.Money,
				};
				lbLastRequestStatus.ImageOptions.Image = images[request.Status];

				var user = ApplicationUser.User;
				ribpgLastRequst.Visible = request.Status > 0;
				btnNewRequest.Visibility = user?.Role != Role.Admin ? BarItemVisibility.Always : BarItemVisibility.Never;
				btnNewRequest.Enabled = request.Status != RequestStatus.Wait;
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}

		public void UpdateSelectedResOp(SelectionResOpViewModel viewModel)
		{
			try
			{
				//riPositions.Items.Clear();
				//riPositions.Items.AddRange(viewModel.PositionNames ?? Array.Empty<object>());

				riResourceNames.Items.Clear();
				riResourceNames.Items.AddRange(viewModel.ResourceNames ?? Array.Empty<object>());

				using (new GridViewStateSaver(gvTabels))
				{
					gcTabels.DataSource = viewModel.Tabels ?? new TabelViewModel[0];
				}

				btCloseTabel.Down = _currentResOp.IsClosed;
				btCloseTabel.Caption = _currentResOp.IsClosed ? "Табель закрыт" : "Табель не закрыт";
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		#endregion

		#region TreeResOp
		private void TreeResOp_CellValueChanging(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				_prevResOp = (ResOPViewModel)_currentResOp.Clone();
				if (e.Column == colName)
				{
					if (_currentResOp.FactDays > 0)
					{
						MessageService.ShowMessage($"Замена сотрудника '{_currentResOp.Name}' невозможна, " +
												   "так как у него есть отработанные дни.\n" +
												   "Удалите отработанные дни сотрудника и повторите попытку.");
						return;
					}
					_currentResOp.Name = e.Value.ToString();
					TreeResOp_CellValueChanged(sender, e);
				}
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void TreeResOp_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				var unit = new ResOpUnitService().GetUnit(e.Column.FieldName);
				if (unit != null)
				{
					var r1 = MapperService.Map<CResOPDto>(_currentResOp);
					var r2 = MapperService.Map<CResOPDto>(_prevResOp);
					var amount = (unit.Value(r1) ?? 0) - (unit.Value(r2) ?? 0);
					CreatingOperation?.Invoke(_currentResOp, amount, unit.Category);
					return;
				}
				if (e.Column == colName)
				{
					ReplacingResource?.Invoke(this, _currentResOp);
				}
				else
				{
					ChangedResOp?.Invoke(this, new ResOpEventArgs
					{
						ViewModel = _currentResOp,
						FieldNameChanged = e.Column.FieldName
					});
				}
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}

		private void treeResOp_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
		{
			try
			{
				var fieldName = treeResOp.FocusedColumn.FieldName;
				var prevVm1 = (ResOPViewModel)_currentResOp.Clone();
				var vm = _currentResOp;
				var month = _currentResOp.Month;
				var validator = new ResOpValidator(prevVm1, month, _rest);

				var prevVm2 = (ResOPViewModel)_currentResOp.Clone();
				ValidateService.Validate(e, validator, prevVm2, vm, fieldName);
			}
			catch (Exception ex)
			{
				e.ErrorText = ex.Message;
				e.Valid = false;
			}
		}
		[DebuggerStepThrough]
		private void TreeResOp_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
		{
			try
			{
				if (!(treeResOp.GetRow(e.Node.Id) is ResOPViewModel vm)) return;

				if (vm.Type == ObjType.Project)
				{
					if (vm.IsClosed)
					{
						e.Appearance.BackColor = Color.FromArgb(255, 100, 200, 100);
						e.Appearance.ForeColor = Color.White;
						e.Appearance.BorderColor = Color.FromArgb(255, 50, 50, 50);
					}
					else
					{
						e.Appearance.BackColor = Color.FromArgb(150, 255, 190, 64);
						e.Appearance.BorderColor = Color.FromArgb(255, 121, 124, 145);
					}
					e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
				}
				else if (vm.Type == ObjType.Object)
				{
					if (e.Column != colName && e.Column != colPhone)
					{
						if (ApplicationUser.User?.Role == Role.Manager)
						{
							e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
						}
						else
						{
							e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Underline);
						}
					}
					if (vm.IsClosed)
					{
						e.Appearance.BackColor = Color.FromArgb(100, 100, 200, 100);
					}
					else
					{
						e.Appearance.BackColor = Color.FromArgb(150, 213, 238, 255);
					}
					e.Appearance.BorderColor = Color.FromArgb(255, 150, 153, 169);
				}
				else if (vm.Type == ObjType.ResOP)
				{
				}
				else if (vm.Type == ObjType.Summary)
				{
					e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
					if (vm.IsClosed)
					{
						e.Appearance.ForeColor = Color.White;
						e.Appearance.BackColor = Color.FromArgb(255, 50, 150, 50);
					}
					else
					{
						e.Appearance.BackColor = Color.FromArgb(75, 128, 128, 128);
					}
				}
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}

		[DebuggerStepThrough]
		private void TreeResOp_ShowingEditor(object sender, CancelEventArgs e)
		{
			if (treeResOp.FocusedColumn == colPaid)
			{
				if (!TreeResOpEditable(true)) e.Cancel = true;
			}
			else if (!TreeResOpEditable()) e.Cancel = true;
		}

		[DebuggerStepThrough]
		private void TreeResOp_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
		{
			try
			{
				if (treeResOp.GetRow(e.Node.Id) is ResOPViewModel vm &&
					vm.Type != ObjType.ResOP)
				{
					if (e.Column == colIsStaff || e.Column == colNoWorking)
					{
						e.Cache.FillRectangle(e.Cache.GetSolidBrush(e.Info.Appearance.BackColor), e.Bounds);
						if (e.Column == colNoWorking && vm.NoWorkingCount > 0)
						{
							var text = $"{vm.NoWorkingCount} шт";
							var font = e.Info.Appearance.Font;
							var brush = e.Cache.GetSolidBrush(e.Info.Appearance.ForeColor);
							var textSize = e.Cache.CalcTextSize(text, font);
							var pt = new Point((e.Bounds.X + e.Bounds.Right) / 2 - (int)textSize.Width / 2, e.Bounds.Y);
							e.Cache.DrawString(text, font, brush, pt);
						}
						e.Handled = true;
					}

					if (e.Info.Appearance.Options.UseBorderColor)
					{
						var b = e.Bounds;
						b.Inflate(1, 1);
						e.Cache.DrawRectangle(e.Cache.GetPen(Color.FromArgb(25, e.Info.Appearance.BorderColor)), b);
						e.Cache.DrawLine(e.Cache.GetPen(e.Info.Appearance.BorderColor),
							new Point(b.Left, b.Top), new Point(b.Right, b.Top));
						e.Cache.DrawLine(e.Cache.GetPen(e.Info.Appearance.BorderColor),
							new Point(b.Left, b.Bottom - 1), new Point(b.Right, b.Bottom - 1));
					}
				}
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}

		private void TreeResOp_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
		{
			ResOpSelectionChange();
		}

		private void TreeResOp_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				var pt = treeResOp.PointToClient(MousePosition);
				var hitInfo = treeResOp.CalcHitInfo(pt);
				if (!hitInfo.InRow) return;

				if (treeResOp.FocusedColumn == colDebt)
				{
					if (_currentResOp.Type == ObjType.ResOP)
					{
						btnPayOne_ItemClick(sender, null);
					}
					if (_currentResOp.Type == ObjType.Object ||
						_currentResOp.Type == ObjType.Project)
					{
						btnPayAll_ItemClick(sender, null);
					}
					return;
				}

				if (_currentResOp.Type != ObjType.ResOP) return;
				var user = ApplicationUser.User;
				if (user?.Role == Role.Manager || _currentResOp.User_ID != null)
				{
					EditingResource?.Invoke(this, _currentResOp);
				}
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void treeResOp_BeforeExpand(object sender, BeforeExpandEventArgs e)
		{
			e.CanExpand = treeResOp.FocusedColumn != colDebt;
		}
		private void treeResOp_BeforeCollapse(object sender, BeforeCollapseEventArgs e)
		{
			e.CanCollapse = treeResOp.FocusedColumn != colDebt;
		}
		private void DeleteResOp()
		{
			try
			{
				if (_currentResOp.Type != ObjType.ResOP) return;
				var resName = _currentResOp.Name;
				if (_currentResOp.FactDays > 0)
				{
					MessageService.ShowMessage($"Удаление сотрудника '{resName}' невозможно, так как у него есть отработанные дни.\n" +
											   "Удалите отработанные дни сотрудника и повторите попытку.");
					return;
				}
				if (_currentResOp.Avans > 0)
				{
					MessageService.ShowMessage($"Удаление сотрудника '{resName}' невозможно, так как ему выплачен аванс.\n" +
											   "Попросите администратора отменить аванс сотруднику и повторите попытку.");
					return;
				}
				if (_currentResOp.Paid > 0)
				{
					MessageService.ShowMessage($"Удаление сотрудника '{resName}' невозможно, так как ему выплачена зарплата.\n" +
											   "Попросите администратора отменить зарплату сотруднику и повторите попытку.");
					return;
				}

				if (MessageService.ShowQuestion($"Будет удален сотрудник '{resName}'.\nПродолжить?") == DialogResult.Yes)
				{
					DeletingResOp?.Invoke(this, _currentResOp);
				}
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void TreeResOp_Enter(object sender, EventArgs e)
		{
			ResOpSelectionChange();
		}
		private void ResOpSelectionChange()
		{
			try
			{
				if (treeResOp.Tag?.Equals(TreeListStateSaver.Updating) ?? false) return;
				if (treeResOp.GetFocusedRow() is ResOPViewModel vm)
				{
					_currentResOp = vm;
					var user = ApplicationUser.User;

					btnCreateResource.Enabled = user?.Role == Role.Manager &&
												(vm.Type == ObjType.Object ||
												vm.Type == ObjType.ResOP);

					btnEditResource.Enabled = vm.Type == ObjType.ResOP &&
											  (user?.Role == Role.Manager ||
											  _currentResOp.User_ID != null);

					btnSetResourceOnObject.Enabled =
					btnVedomostForObject.Enabled =
						vm.Type == ObjType.Object ||
						vm.Type == ObjType.ResOP;

					gvTabels.OptionsBehavior.Editable = TreeResOpEditable();

					btnDeleteResource.Enabled =
					btnAllDays.Enabled =
					btn5_2Days.Enabled =
					btn2_2Days.Enabled =
					btnDeleteAllDays.Enabled = vm.Type == ObjType.ResOP && TreeResOpEditable();
					btnPayOne.Enabled = vm.Type == ObjType.ResOP && TreeResOpEditable(true);

					SelectResource?.Invoke(this, vm);
				}
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void treeResOp_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
		{
			try
			{
				if (ApplicationUser.User?.Role != Role.Admin) return;

				var hitInfo = treeResOp.CalcHitInfo(e.Point);
				if (!hitInfo.InRow) return;
				if (!(treeResOp.GetRow(hitInfo.Node.Id) is ResOPViewModel vm)) return;
				if (vm.Type != ObjType.ResOP) return;

				var unit = new ResOpUnitService().GetUnit(hitInfo.Column.FieldName);
				if (unit == null) return;

				var eaOperation = new RejectOperationEventArgs
				{
					ResOpByCashUnit = unit,
					ViewModel = vm
				};
				GetRejectingOperation?.Invoke(this, eaOperation);
				var op = eaOperation.Operation;
				var menuItem = new DXMenuItem
				{
					Caption = "Отменить последнюю операцию\n" +
							  $"Категория: {unit.Category.DisplayName()}\n" +
							  $"Дата: {op?.DateTime}\n" +
							  $"Сумма: {op?.Amount}",
					Enabled = op != null,
					Image = Resources.Rejected
				};
				menuItem.Click += (s, ea) => RejectingOperation?.Invoke(this, op);
				e.Menu.Items.Add(menuItem);
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void TreeResOp_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete ||
				e.KeyCode == Keys.OemMinus ||
				e.KeyCode == Keys.Subtract)
			{
				DeleteResOp();
			}
			else if (e.KeyCode == Keys.Insert || e.KeyCode == Keys.Add)
			{
				CreatingResource?.Invoke(this, _currentResOp);
			}
		}
		#endregion

		#region GridTabels
		private void GridTabels_CellValueChanging(object sender,
			DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			try
			{
				if (sender is GridView view && view.GetRow(e.RowHandle) is TabelViewModel vm)
				{
					ChangedTabel?.Invoke(this, vm);
				}
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}

		[DebuggerStepThrough]
		private void GridTabels_RowStyle(object sender, RowStyleEventArgs e)
		{
			try
			{
				if (!(gvTabels.GetRow(e.RowHandle) is TabelViewModel vm)) return;

				if (vm.Date.DayOfWeek == DayOfWeek.Saturday ||
					 vm.Date.DayOfWeek == DayOfWeek.Sunday)
				{
					e.Appearance.BackColor = gvTabels.Editable ? Color.FromArgb(255, 103, 103) : Color.Gainsboro;
					e.Appearance.BorderColor = Color.FromArgb(200, 121, 124, 145);
				}
				else
				{
					e.Appearance.BackColor = gvTabels.Editable ? Color.White : Color.WhiteSmoke;
				}
				e.HighPriority = true;
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}
		private void GcTabels_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				if (gvTabels.GetViewInfo() is GridViewInfo viewInfo)
				{
					foreach (var rowInfo in viewInfo.RowsInfo)
					{
						if (rowInfo.Appearance.Options.UseBorderColor)
						{
							using (var pen = new Pen(rowInfo.Appearance.BorderColor))
							{
								var bounds = rowInfo.TotalBounds;
								bounds.Offset(0, -1);
								e.Graphics.DrawRectangle(pen, bounds);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ShowError(ex.ToString());
			}
		}

		private void gvTabels_ShowingEditor(object sender, CancelEventArgs e)
		{
			if (!gvTabels.Editable) e.Cancel = true; //почему то не работает
		}
		#endregion

		#region Form service
		public void ShowError(string error)
		{
			try
			{

				if (Disposing || IsDisposed) return;
				MessageService.ShowError(error);
			}
			catch { }
		}
		private void MainView_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				LayoutSaver.Save(this);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void menuMain_SelectedPageChanged(object sender, EventArgs e)
		{
			ribpgFilter.GetType().GetProperty("Page")? //костыль чтобы вкладка не переключалась при использовании фильтров
				.SetValue(ribpgFilter, ribbon.SelectedPage);
		}
		private void btResetSettings_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				var question = "Настройки экрана будут сброшены.\nПродолжить?";
				if (MessageService.ShowQuestion(question) == DialogResult.Yes)
				{
					LayoutSaver.Reset();
					MessageService.ShowMessage("Настройки экрана сброшены.\nИзменения вступят после перезапуска приложения.");
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		#endregion
	}
}