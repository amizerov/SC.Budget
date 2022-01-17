using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using LinqToDB;
using LinqToDB.Data;
using SC.Cash.Model;
using SC.Cash.Properties;
using SC.Cash.Services;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SC.Cash.Views
{
	public partial class FrmCash : XtraForm
	{
		private readonly COperationCash[] _operations;
		private readonly CAccountDto[] _passiveAccs;

		public FrmCash()
		{
			try
			{
				InitializeComponent();

				LayoutSaver.Restore(this);

				using (var db = new DbContext())
				{
					riStatus.Items.AddRange(new[]
					{
						new ImageComboBoxItem("Ожидает", OperationCashStatus.Wait, 0),
						new ImageComboBoxItem("Принято", OperationCashStatus.Completed, 1),
						new ImageComboBoxItem("Отменено", OperationCashStatus.Rejected, 2),
					});

					riProjects.Items.AddRange(CProjectDto.GetNamesForCash());
					var user = ApplicationUser.User;
					_passiveAccs = db.GetWhere<CAccountDto>(a => a.User_ID == user?.ID && a.IsPassive);
					riToAccount.Items.Add(user?.Name);
					riToAccount.Items.AddRange(_passiveAccs.Select(a => a.NameForPassive).ToArray());

					_operations = db.Query<COperationCash>(
						Resources.OperationsCash)
						.Where(op => op.Status == OperationCashStatus.Wait)
						.ToArray();
					gcCash.DataSource = _operations;
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				using (var db = new DbContext())
				{
					var user = ApplicationUser.User;
					foreach (var op in _operations)
					{
						if (op.Status == OperationCashStatus.Wait) continue;
						var opDto = MapperService.Map<COperationCashDto>(op);
						if (op.Status == OperationCashStatus.Completed)
						{
							var schet = db.GetTable<CSchetDto>()
								.FirstOrDefault(s => s.ID == op.Schet_ID);
							var date = op.DateToCash ?? DateTime.Now;
							var amount = op.AmountToAcc ?? 0;
							var comment = $"Счёт №{schet?.NomerInternal} от {schet.DataCreate:dd.MM.yyyy}";
							var toAcc = CAccountDto.GetOrCreate(user.ID);
							var projectId = db.GetID<CProjectDto>(op.ProjectName);
							var cash = COperationDto.Cash(date, op.Amount, op.Month, projectId, comment, op.ID, toAcc);
							var commission = COperationDto.Commission(cash, op.Amount - (op.AmountToAcc ?? 0));

							var (isErrorOp1, errorOp1) = cash.Insert();

							if (isErrorOp1)
							{
								MessageService.ShowError(errorOp1);
								return;
							}
							if (op.ToAccount.IsPassive)
							{
								var toPassOp = COperationDto.Operation(date, amount, op.Month, projectId, comment,
										OperationCategory.Other, toAcc, op.ToAccount);
								var (isErrorPassOp, errorPassOp) = toPassOp.Insert();
								if (isErrorPassOp)
								{
									MessageService.ShowError(errorPassOp);
									return;
								}
							}
							var (isErrorOp2, errorOp2) = commission.Insert();
							if (isErrorOp2)
							{
								MessageService.ShowError(errorOp2);
							}
						}
						db.Update(opDto);
					}

					DialogResult = DialogResult.OK;
					Close();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvCash_CellValueChanging(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (e.Column == colStatus)
				{
					if (!OperationCashStatus.Completed.Equals(e.Value))
					{
						gvCash.SetFocusedValue(e.Value);
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void gvCash_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (!(gvCash.GetFocusedRow() is COperationCash op)) return;
				var user = ApplicationUser.User;
				if (e.Column == colOutPercent || e.Column == colAmountToAcc)
				{
					if (e.Column == colOutPercent)
					{
						op.AmountToAcc = Math.Round(op.Amount * (1 - (decimal)e.Value / 100), 2);
					}
					if (e.Column == colAmountToAcc)
					{
						op.OutPercent = Math.Round((1 - (decimal)e.Value / op.Amount) * 100, 2);
					}
					if ((op.AmountToAcc ?? 0) > 0)
					{
						op.Status = OperationCashStatus.Completed;
						op.DateToCash = DateTime.Now;
						op.Month = DateTime.Now.AddMonths(-1);
						op.ToAccount = CAccountDto.GetOrCreate(user.ID);
						op.ToAccountName = user?.Name;
					}
				}
				if (e.Column == colToAccountName)
				{
					op.ToAccount = op.ToAccountName == user?.Name ? CAccountDto.GetOrCreate(user?.ID)
						: _passiveAccs.First(a => a.NameForPassive == op.ToAccountName);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void gvCash_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
		{
			try
			{
				if (!(gvCash.GetFocusedRow() is COperationCash op)) return;
				var fieldName = gvCash.FocusedColumn.FieldName;
				var prevVm1 = op.Clone();
				var validator = new OperationCashValidator(prevVm1);

				var prevVm2 = op.Clone();
				ValidateService.Validate(e, validator, prevVm2, op, fieldName);
			}
			catch (Exception ex)
			{
				e.ErrorText = ex.Message;
				e.Valid = false;
			}
		}
		private void gvCash_RowStyle(object sender, RowStyleEventArgs e)
		{
			try
			{
				if (!(gvCash.GetRow(e.RowHandle) is COperationCash op)) return;
				if (op.Status == OperationCashStatus.Rejected)
				{
					e.Appearance.BackColor = Color.FromArgb(30, Color.Tomato);
					e.Appearance.ForeColor = Color.FromArgb(150, 0, 0);
				}
				else if (op.Status == OperationCashStatus.Completed)
				{
					e.Appearance.BackColor = Color.FromArgb(30, Color.Lime);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void FrmCash_FormClosed(object sender, FormClosedEventArgs e)
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
	}
}