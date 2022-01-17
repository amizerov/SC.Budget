using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using LinqToDB;
using LinqToDB.Data;
using SC.Cash.Properties;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace SC.Cash.Views
{
	public partial class PageRequests : XtraUserControl
	{
		private List<RequestStatus> _statuses;
		private DateTime _start, _end;

		public PageRequests()
		{
			try
			{
				InitializeComponent();

				ImageComboBoxItem Item(RequestStatus status, int i)
				{
					return new ImageComboBoxItem(status.DisplayName(), status, i);
				}

				var imageIndex = 0;
				riStatus.Items.AddRange(new[]
				{
					Item(RequestStatus.Wait, imageIndex++),
					Item(RequestStatus.Rejected, imageIndex++),
					Item(RequestStatus.Agreed, imageIndex++),
					Item(RequestStatus.Paid, imageIndex++)
				});
				using (var db = new DbContext())
				{
					riProject.Items.AddRange(CProjectDto.GetNamesForCash());
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public event EventHandler Updated;

		public void UpdateData(DateTime start, DateTime end, List<RequestStatus> statuses)
		{
			try
			{
				_start = start;
				_end = end;
				_statuses = statuses;
				if (gvRequest.IsEditFormVisible) return;

				var user = ApplicationUser.User;
				if (user != null)
				{
					using (var db = new DbContext())
					{
						var requests = db.Query<CRequestOp>(Resources.Requests_In,
								new DataParameter("@userId", user.ID))
							.Where(r => statuses.Contains(r.Status))
							.Where(r => r.DateTime >= start && r.DateTime < end)
							.ToArray();

						gcRequest.DataSource = requests;
					}
				}
				else
				{
					gcRequest.DataSource = Array.Empty<CRequestOp>();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvRequest_CellValueChanging(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (!(gvRequest.GetFocusedRow() is CRequestOp vm)) return;
				if (e.Column == colStatus)
				{
					vm.Status = (RequestStatus)e.Value;
					gvRequest_CellValueChanged(sender, e);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvRequest_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (!(gvRequest.GetFocusedRow() is CRequestOp vm)) return;
				var request = MapperService.Map<CRequestOpDto>(vm);
				using (var db = new DbContext())
				{
					if (e.Column == colStatus &&
						e.Value is RequestStatus status &&
						status == RequestStatus.Paid)
					{
						var amount = request.Paid ?? 0;
						var comment = $"Запрос от {request.DateTime:d}";
						var category = OperationCategory.Other;
						var fromUserId = ApplicationUser.User.ID;
						var fromAcc = CAccountDto.GetOrCreate(fromUserId);
						var toAcc = CAccountDto.GetOrCreate(request.User_ID);
						var month = request.Month;
						var projectId = request.Project_ID;

						var op = COperationDto.Operation(DateTime.Now, amount, month, projectId, comment, category,
							fromAcc, toAcc);
						var (isErrorOp, errorOp) = op.Insert();

						if (isErrorOp)
						{
							MessageService.ShowError(errorOp);
							return;
						}

						db.Update(request);
						UpdateData(_start, _end, _statuses);
						Updated?.Invoke(this, EventArgs.Empty);
					}
					else
					{
						if (e.Column == colProjectName)
						{
							request.Project_ID = db.GetID<CProjectDto>(vm.ProjectName);
						}

						db.Update(request);
					}
				}
			}
			catch (ObjectDisposedException)
			{
			}
			catch (Exception exception)
			{
				MessageService.ShowError(exception.ToString());
			}
		}

		private void gvRequest_ShowingEditor(object sender, CancelEventArgs e)
		{
			if (!(gvRequest.GetFocusedRow() is CRequestOp vm)) return;
			if (gvRequest.FocusedColumn == colPaid ||
				gvRequest.FocusedColumn == colStatus)
			{
				e.Cancel = !vm.Editable;
			}
		}

		private void gvRequest_RowStyle(object sender, RowStyleEventArgs e)
		{
			try
			{
				if (!(gvRequest.GetRow(e.RowHandle) is CRequestOp vm)) return;
				switch (vm.Status)
				{
					case RequestStatus.Rejected:
						{
							e.Appearance.BackColor = Color.FromArgb(30, Color.Tomato);
							e.Appearance.ForeColor = Color.FromArgb(150, 0, 0);
						}
						break;
					case RequestStatus.Agreed:
						{
							e.Appearance.BackColor = Color.FromArgb(30, Color.Lime);
						}
						break;
					case RequestStatus.Paid:
						{
							e.Appearance.BackColor = Color.FromArgb(70, Color.LimeGreen);
						}
						break;
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvRequest_DoubleClick(object sender, EventArgs e)
		{
			if (!(gvRequest.GetFocusedRow() is CRequestOp vm)) return;
			if (vm.Editable)
			{
				gvRequest.OptionsBehavior.EditingMode = GridEditingMode.EditForm;
			}
		}

		private void gvRequest_Click(object sender, EventArgs e)
		{
			gvRequest.OptionsBehavior.EditingMode = GridEditingMode.Default;
		}

		public void ToExcel(string fileName) => gvRequest.ExportToXlsx(fileName);

		private void gvRequest_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
		{
			try
			{
				if (!(gvRequest.GetFocusedRow() is CRequestOp vm)) return;
				if (gvRequest.FocusedColumn == colStatus)
				{
					var status = (RequestStatus)e.Value;
					if ((status == RequestStatus.Paid || status == RequestStatus.Agreed) &&
						(vm.Paid ?? 0) <= 0)
					{
						e.ErrorText = $"Выданная сумма должна быть больше нуля. Текущее значение: {vm.Paid ?? 0:c2}";
						e.Valid = false;
					}
				}
			}
			catch (Exception ex)
			{
				e.ErrorText = ex.Message;
				e.Valid = false;
			}
		}
	}
}
