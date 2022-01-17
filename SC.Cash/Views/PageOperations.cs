using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using LinqToDB;
using LinqToDB.Data;
using SC.Cash.Properties;
using SC.Cash.Tools;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SC.Cash.Views
{
	public partial class PageOperations : DevExpress.XtraEditors.XtraUserControl
	{
		private DateTime _start, _end;
		private bool _isMonth;
		private bool _isDebtTotal;
		private bool _isDebtCalculated;

		public PageOperations()
		{
			try
			{
				InitializeComponent();

				using (var db = new DbContext())
				{
					riProjects.Items.AddRange(CProjectDto.GetNamesForCash());
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public object FocusedAccount => gvAccounts.GetFocusedRow();

		public EventHandler Updated;

		public void UpdateData(DateTime start, DateTime end, bool isMonth, bool isDebtTotal, bool isDebtCalculated)
		{
			try
			{
				_start = start;
				_end = end;
				_isMonth = isMonth;
				_isDebtTotal = isDebtTotal;
				_isDebtCalculated = isDebtCalculated;
				var user = ApplicationUser.User;
				if (user == null)
				{
					gcAccounts.DataSource = Array.Empty<CAccount>();
					return;
				}

				btnNewAmountIn.Visible = user.Role == Role.Admin || user.Role == Role.Director;

				using (var db = new DbContext())
				{
					var users = db.GetTable<CUserDto>();
					var usersId = new List<int> { user.ID };
					if (user.Role == Role.Admin)
					{
						usersId.AddRange(users.Select(u => u.ID));
					}
					else if (user.Role == Role.Director)
					{
						usersId.AddRange(users
							.Where(u => u.Role == Role.Rukovod)
							.Select(u => u.ID));
					}
					else if (user.Role == Role.Rukovod)
					{
						var sqlManagers = Resources.Managers;
						usersId.AddRange(db.Query<CUserDto>(sqlManagers,
								new DataParameter("@rukId", user.ID))
							.Select(u => u.ID));
					}

					var sql = Resources.Accounts.Replace("@userId",
						string.Join(", ", usersId));
					var accounts = db.Query<CAccount>(sql,
						new DataParameter("@start", _start),
						new DataParameter("@end", _end),
						new DataParameter("@month", _isMonth ? (DateTime?)_start.AddMonths(-1) : null),
						new DataParameter("@isDebtTotal", _isDebtTotal),
						new DataParameter("@isDebtCalculated", _isDebtCalculated))
						.ToList();
					var userAcc = accounts.FirstOrDefault(a => a.User_ID == user.ID);
					accounts.Remove(userAcc);
					accounts.Insert(0, userAcc); //чтобы аккаунт юзера был на первом месте

					using (new GridViewStateSaver(gvAccounts))
					{
						gcAccounts.DataSource = accounts;
					}
					colSalaryCalculated.Visible = _isMonth;
					colDebt.Visible = _isDebtTotal || _isMonth;

					gvAccounts_FocusedRowChanged(this, null);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void EditFocusedOperation()
		{
			try
			{
				if (!(gvOperations.GetFocusedRow() is COperation op)) return;
				var user = ApplicationUser.User;
				if (user?.Role == Role.Rukovod)
				{
					using (var db = new DbContext())
					{
						var fromAcc = db.GetByID<CAccountDto>(op.From_ID);
						if (fromAcc.User_ID != user.ID)
						{
							MessageService.ShowError("Допускается только редактирование Ваших расходов.\n" +
													  "Продолжение невозможно.");
							return;
						}
					}
				}
				using (var form = new FrmEditOperation(op))
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						UpdateData(_start, _end, _isMonth, _isDebtTotal, _isDebtCalculated);
						Updated?.Invoke(this, EventArgs.Empty);
					};
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void RejectFocusedOperation()
		{
			try
			{
				if (!(gvOperations.GetFocusedRow() is COperation op)) return;

				var question = "Вы действительно хотите отменить следующую операцию:\n" +
							   $"Дата: {op.DateTime}\n" +
							   $"{(op.FromUser.IsEmpty() ? "" : $"От: {op.FromUser}\n")}" +
							   $"{(op.ToUser.IsEmpty() ? "" : $"Кому: {op.ToUser}\n")}" +
							   $"Сумма: {op.Amount:C2}?";
				if (MessageService.ShowQuestion(question) == DialogResult.Yes)
				{
					var (isError, error) = op.Reject();
					Updated?.Invoke(this, EventArgs.Empty);
					if (isError) MessageService.ShowError(error);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvAccounts_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
		{
			var accId = -1;
			try
			{
				if (gvAccounts.GetFocusedRow() is CAccount acc)
				{
					accId = acc.ID;
					gcOperations.DataSource = COperation.Factory(accId, _start, _end);
				}
				else
				{
					gcOperations.DataSource = Array.Empty<COperation>();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this, $"accId: {accId} start: {_start} end: {_end}");
			}
		}

		private void toolTipController_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
		{
			int rowHandle = -111;
			try
			{
				if (e.SelectedControl == gcOperations)
				{
					if (!(gcOperations.FocusedView is GridView view)) return;
					var info = view.CalcHitInfo(e.ControlMousePosition);
					if (!info.InRowCell) return;
					rowHandle = info.RowHandle;
					if (!(gvOperations.GetRow(rowHandle) is COperation op)) return;

					var title = view.GetRowCellDisplayText(info.RowHandle, info.Column);
					var text = "";
					if (op.To_ID == null && op.ToResOP_ID == null)
					{
						text += "Расход\n" +
								$"От кого: {op.FromUser}\n" +
								$"{op.FromRole.DisplayName()}\n" +
								$"Логин: {op.FromLogin}";
					}
					else if ((op.InAmount ?? 0) > 0)
					{
						text += "От кого: " + op.FromUser;
						if (op.FromCash_ID == null) text += "\n" + op.FromRole.DisplayName();
						else text += "\nОрганизация";
						if (op.FromRole != Role.None) text += $"\nЛогин: {op.FromLogin}";
					}
					else if ((op.OutAmount ?? 0) > 0)
					{
						text += "Кому: " + op.ToUser;
						text += "\n" + op.ToRole.DisplayName();
						if (op.ToRole != Role.None) text += $"\nЛогин: {op.ToLogin}";
					}

					var cellKey = $"{info.RowHandle} - {info.Column}";
					e.Info = new ToolTipControlInfo(cellKey, text, title);
				}

				if (e.SelectedControl == gcAccounts)
				{
					if (!(gcAccounts.FocusedView is GridView view)) return;
					var info = view.CalcHitInfo(e.ControlMousePosition);
					if (!info.InRowCell) return;
					rowHandle = info.RowHandle;
					if (!(gvAccounts.GetRow(rowHandle) is CAccount acc)) return;

					var title = view.GetRowCellDisplayText(info.RowHandle, info.Column);
					var text = acc.IsPassive ? "Пассивный счёт"
						: $"{acc.Role.DisplayName()}\nЛогин: {acc.Login}";
					var cellKey = $"{info.RowHandle} - {info.Column}";
					e.Info = new ToolTipControlInfo(cellKey, text, title);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this, $"rowHandle: {rowHandle}");
			}
		}

		private void gvOperations_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				var pt = gcOperations.PointToClient(MousePosition);
				var hitInfo = gvOperations.CalcHitInfo(pt);
				if (!hitInfo.InRow) return;

				EditFocusedOperation();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvOperations_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
		{
			try
			{
				var hitInfo = gvOperations.CalcHitInfo(e.Point);
				if (!hitInfo.InRow) return;

				var menuItemEdit = new DXMenuItem
				{
					Caption = "Редактировать операцию",
					Image = Resources.editdatasource_16x16,
				};
				menuItemEdit.Click += (s, ea) => EditFocusedOperation();
				e.Menu.Items.Add(menuItemEdit);
				var menuItemReject = new DXMenuItem
				{
					Caption = "Отменить операцию",
					Image = Resources.deletedatasource_16x16,
				};
				menuItemReject.Click += (s, ea) => RejectFocusedOperation();
				e.Menu.Items.Add(menuItemReject);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btnNewAmountIn_Click(object sender, EventArgs e)
		{
			try
			{
				using (var form = new FrmEditOperation(OpType.Input))
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						Updated(this, EventArgs.Empty);
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btnNewOperation_Click(object sender, EventArgs e)
		{
			try
			{
				using (var form = new FrmEditOperation(OpType.Operation))
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						Updated(this, EventArgs.Empty);
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btEditOperation_Click(object sender, EventArgs e) => EditFocusedOperation();

		private void btnRejectOperation_Click(object sender, EventArgs e) => RejectFocusedOperation();

		private void btnOrder_Click(object sender, EventArgs e)
		{
			try
			{
				if (!(gvOperations.GetFocusedRow() is COperation op)) return;
				new Excel().Order(op);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public void ExportVipiska()
		{
			try
			{
				if (!(gvAccounts.GetFocusedRow() is CAccount acc)) return;
				new Excel().Vipiska(acc, _start, _end);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btnOperationToExcel_Click(object sender, EventArgs e)
		{
			try
			{
				using (var excel = new ExcelService(this))
				{
					excel.GridToExcel(gvOperations.ExportToXlsx)
						.SetAutoFit();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvAccounts_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				var pt = gcAccounts.PointToClient(MousePosition);
				var hitInfo = gvAccounts.CalcHitInfo(pt);
				if (!hitInfo.InRow) return;

				if (!(FocusedAccount is CAccount acc)) return;
				if (!acc.IsPassive) return;
				using (var form = new FrmEditAccaunt(acc))
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						Updated?.Invoke(this, EventArgs.Empty);
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvOperations_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (!(gvOperations.GetFocusedRow() is COperation op)) return;
				using (var db = new DbContext())
				{
					if (e.Column == colProjectName && op.ProjectName.NoEmpty())
					{
						op.Project_ID = db.GetID<CProjectDto>(op.ProjectName);
					}
					var opDto = MapperService.Map<COperationDto>(op);
					db.Update(opDto);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}
