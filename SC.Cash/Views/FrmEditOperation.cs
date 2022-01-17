using DevExpress.XtraEditors;
using LinqToDB.Data;
using SC.Cash.Properties;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SC.Cash.Views
{
	public partial class FrmEditOperation : XtraForm
	{
		private readonly OpType _opType;
		private readonly COperation _operation;
		private readonly List<CUserDto> _users = new List<CUserDto>();
		private CAccountDto[] _passiveAccounts;
		private OperationCategory[] _categories;

		public FrmEditOperation(OpType opType)
		{
			try
			{
				_opType = opType;
				if (_opType != OpType.Input && _opType != OpType.Operation)
				{
					throw new ArgumentException("Создание такого типа операций не предусмотрено");
				}
				LoadForm();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		public FrmEditOperation(COperation operation)
		{
			try
			{
				_operation = operation;
				_opType = _operation?.FromCash_ID != null ? OpType.Cash
					: _operation?.From_ID == null ? OpType.Input
					: _operation?.ToResOP_ID != null ? OpType.ResOp
					: OpType.Operation;

				LoadForm();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void LoadForm()
		{
			InitializeComponent();

			LayoutSaver.Restore(this);

			using (var db = new DbContext())
			{
				LoadUsers();

				var user = ApplicationUser.User;
				cbFromUser.Properties.Items.Add("Без отправителя");
				cbFromUser.Properties.Items.Add(user.Name);
				if (user.Role == Role.Director)
				{
					cbFromUser.Properties.Items.AddRange(_passiveAccounts.Select(u => u.NameForPassive).ToArray());
				}
				cbFromUser.Properties.Items.AddRange(_users.Select(u => u.Name).ToArray());
				if (_opType == OpType.Cash) cbFromUser.Properties.Items.Add(_operation?.FromUser);
				cbToUser.Properties.Items.Add("Без получателя");
				cbToUser.Properties.Items.Add(user.Name);
				if (user.Role == Role.Director)
				{
					cbToUser.Properties.Items.AddRange(_passiveAccounts.Select(u => u.NameForPassive).ToArray());
				}
				cbToUser.Properties.Items.AddRange(_users.Select(u => u.Name).ToArray());
				_categories = (OperationCategory[])Enum.GetValues(typeof(OperationCategory));
				cbCategory.Properties.Items.AddRange(EnumService.AllNames<OperationCategory>());

				cbProject.Properties.Items.AddRange(CProjectDto.GetNamesForCash());

				if (_operation != null)
				{
					Text = _opType == OpType.Cash ? "Редактирование кэша"
						: _opType == OpType.Input ? "Редактирование прихода"
						: _opType == OpType.ResOp ? "Редактирование выдачи зарплаты (аванса)"
						: "Редактирование операции";

					if (_opType == OpType.Cash)
					{
						cbFromUser.Text = _operation.FromUser;
						cbFromUser.Enabled = false;
					}
					else
					{
						var fromAccId = _opType == OpType.Input ? _operation.FromAccCash_ID
							: _operation.From_ID;
						var fromAcc = db.GetByID<CAccountDto>(fromAccId);
						if (fromAcc != null)
						{
							cbFromUser.Text = fromAcc.IsPassive ? fromAcc.NameForPassive
								: db.GetByID<CUserDto>(fromAcc.User_ID)?.Name;
						}
						else cbFromUser.SelectedIndex = 0;
					}
					var toAcc = db.GetByID<CAccountDto>(_operation.To_ID);
					if (toAcc != null)
					{
						cbToUser.Text = toAcc.IsPassive ? toAcc.NameForPassive
							: db.GetByID<CUserDto>(toAcc.User_ID)?.Name;
					}
					else cbToUser.SelectedIndex = 0;

					deDate.DateTime = _operation.DateTime;
					txtAmount.Text = _operation.Amount.ToString();
					txtAmount.Enabled = user?.Role == Role.Admin || user?.Role == Role.Director;

					cbCategory.Text = _operation.Category.DisplayName();
					deMonth.EditValue = _operation.Month;
					cbProject.Text = db.GetByID<CProjectDto>(_operation.Project_ID)?.Name;
					txtComment.Text = _operation.Comment;
				}
				else //новая операция или приход
				{
					Text = _opType == OpType.Input ? "Новый приход" : "Новая операция";
					if (_opType == OpType.Operation) cbFromUser.Text = user.Name;
					else
					{
						cbFromUser.SelectedIndex = 0;
						cbToUser.Text = user.Name;
					}
					deDate.DateTime = DateTime.Now;
					cbCategory.SelectedIndex = 0;
					deMonth.EditValue = DateTime.Now.AddMonths(-1);
				}
			}
		}

		private void LoadUsers()
		{
			var user = ApplicationUser.User;
			using (var db = new DbContext())
			{
				if (user.Role == Role.Admin)
				{
					_users.AddRange(db.GetTable<CUserDto>()
						.Where(u => !string.IsNullOrEmpty(u.Name))
						.OrderBy(u => u.Name));
				}
				else if (user.Role == Role.Director)
				{
					_users.AddRange(db.GetTable<CUserDto>()
						.Where(u => u.Role == Role.Rukovod ||
									u.Role == Role.Director ||
									u.Role == Role.Admin)
						.OrderBy(u => u.Name));
				}
				else if (user.Role == Role.Rukovod)
				{
					_users.AddRange(db.Query<CUserDto>(Resources.Managers,
						new DataParameter("@rukId", user.ID)));
				}
				_passiveAccounts = db.GetTable<CAccountDto>()
					.Where(a => a.User_ID == user.ID)
					.Where(a => a.IsPassive)
					.ToArray();
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				var date = deDate.DateTime;
				var amount = txtAmount.Text.ToDecimal();
				CAccountDto GetAccount(int pos)
				{
					if (pos <= 0) return null;
					if (pos == 1)
					{
						var user = ApplicationUser.User;
						return CAccountDto.GetOrCreate(user.ID);
					}
					if (_passiveAccounts.Any() && pos - 1 <= _passiveAccounts.Length)
					{
						return _passiveAccounts[pos - 2];
					}
					var accUser = _users[pos - _passiveAccounts.Length - 2];
					return CAccountDto.GetOrCreate(accUser.ID);
				}
				var fromAcc = _opType != OpType.Cash ? GetAccount(cbFromUser.SelectedIndex) : null;
				var toAcc = GetAccount(cbToUser.SelectedIndex);
				var category = _categories[cbCategory.SelectedIndex];

				var (isErrorFields, errorFields) = ErrorFillField(amount, fromAcc, toAcc);
				if (isErrorFields)
				{
					MessageService.ShowError(errorFields);
					return;
				}

				var month = deMonth.EditValue as DateTime?;
				using (var db = new DbContext())
				{
					var projectId = db.GetID<CProjectDto>(cbProject.Text);
					var comment = txtComment.Text;

					if (_operation == null)
					{
						var op = _opType == OpType.Input
							? COperationDto.Input(date, amount, month, projectId, comment, category, fromAcc, toAcc)
							: COperationDto.Operation(date, amount, month, projectId, comment, category, fromAcc, toAcc);

						var (isErrorOp, errorOp) = op.Insert();
						if (isErrorOp)
						{
							MessageService.ShowError(errorOp);
							return;
						}
					}
					else
					{
						COperationDto changedOp;
						if (_opType == OpType.Cash)
						{
							var fromCashId = _operation.FromCash_ID ?? -1;
							changedOp = COperationDto.Cash(date, amount, month, projectId, comment, fromCashId, toAcc);
						}
						else if (_opType == OpType.Input)
						{
							changedOp = COperationDto.Input(date, amount, month, projectId, comment, category, fromAcc, toAcc);
						}
						else if (_opType == OpType.ResOp)
						{
							var resOpId = _operation.ToResOP_ID ?? -1;
							changedOp = COperationDto.ResOp(date, amount, month, projectId, comment, category, fromAcc, resOpId);
						}
						else
						{
							changedOp = COperationDto.Operation(date, amount, month, projectId, comment, category, fromAcc, toAcc);
						}
						var (isError, error) = _operation.Change(changedOp);
						if (isError) MessageService.ShowError(error);
					}
				}

				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private (bool isError, string error) ErrorFillField(decimal amount, CAccountDto fromAcc, CAccountDto toAcc)
		{
			if (cbFromUser.SelectedIndex < 0) return (true, "Не заполнено поле 'От кого'");
			if (cbToUser.SelectedIndex < 0) return (true, "Не заполнено поле 'Кому'");
			if (amount <= 0) return (true, "Не заполнено поле 'Сумма'");
			if (fromAcc == null && toAcc == null)
			{
				return (true, "Невозможно создать операцию без отправителя и без получателя.");
			}
			if (fromAcc == toAcc)
			{
				return (true, "Невозможно создать операцию самому себе.");
			}
			if (_opType == OpType.Input && (fromAcc?.IsPassive ?? false))
			{
				return (true, "Невозможно создать приход из пассивного счёта.\n" +
								"Для этого используйте функцию 'Создать операцию'");
			}
			return (false, null);
		}

		private void FrmEditOperation_FormClosed(object sender, FormClosedEventArgs e)
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