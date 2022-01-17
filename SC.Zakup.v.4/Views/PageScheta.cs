using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using LinqToDB;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CSchet = SC.Common.Model.CSchet;

namespace SC.Zakup.Views
{
	public partial class PageScheta : DevExpress.XtraEditors.XtraUserControl
	{
		public enum Filter { None, Red, Green, Yellow, White, YellowOrWhite }

		private Filter _oplataFilter;
		private DateTime _start, _end;
		private DateTime? _oplataStart, _oplataEnd;
		private WhatUpdateService<CSchetDto> _whatUpdateService;

		public PageScheta()
		{
			try
			{
				InitializeComponent();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public event EventHandler EditingSchet;
		public event EventHandler DeletingSchet;

		public CSchet FocusedSchet => gvScheta.GetFocusedRow() as CSchet;

		private bool _isShowLoadToday;
		public bool IsShowLoadToday
		{
			get => _isShowLoadToday;
			set { _isShowLoadToday = value; gvScheta.LayoutChanged(); }
		}

		private bool _isShowUpdateValues;
		private bool _isSnippenOnly;
		private string _firma;
		private string _supplier;
		private string _isAvance;

		public bool IsShowUpdateValues
		{
			get => _isShowUpdateValues;
			set
			{
				_isShowUpdateValues = value;
				_whatUpdateService = new WhatUpdateService<CSchetDto>();
				gvScheta.LayoutChanged();
			}
		}

		public void UpdateData(DateTime start, DateTime end,
			DateTime? oplataStart, DateTime? oplataEnd,
			Filter filter, bool isSnippedOnly,
			string firma, string supplier, string isAvance)
		{
			try
			{
				_start = start;
				_end = end;
				_oplataStart = oplataStart;
				_oplataEnd = oplataEnd;
				_oplataFilter = filter;
				_isSnippenOnly = isSnippedOnly;
				_firma = firma;
				_supplier = supplier;
				_isAvance = isAvance;

				var user = ApplicationUser.User;
				if (user == null)
				{
					gcScheta.DataSource = new CSchet[0];
					return;
				}
				var allFirma = firma.IsEmpty() || firma == "Все";
				var allSuppliers = supplier.IsEmpty() || supplier == "Все";
				var projIds = user.Role == Role.Rukovod ? CProjectDto.GetIds() : new int[0];
				var isShowCash = user.Role == Role.Admin ||
							  user.Role == Role.Director ||
							  user.Role == Role.Buh;

				var scheta = CSchet.GetTable(start: _start, end: _end,
						oplataStart: _oplataStart, oplataEnd: _oplataEnd, isDeleted: false)
					.Where(s => allFirma || s.FirmaName == firma)
					.Where(s => allSuppliers || s.SupplierName == supplier)
					.Where(s => isShowCash || !s.IsCash)
					.Where(s => isAvance == "All" || isAvance == "Scheta" == !s.IsAvance)
					.Where(s => user.Role != Role.Rukovod || projIds.Contains(s.Project_ID ?? -1))
					.ToArray();

				switch (_oplataFilter)
				{
					case Filter.Red: scheta = scheta.Where(s => s.Red).ToArray(); break;
					case Filter.Yellow: scheta = scheta.Where(s => s.Yellow).ToArray(); break;
					case Filter.Green: scheta = scheta.Where(s => s.Green).ToArray(); break;
					case Filter.White: scheta = scheta.Where(s => s.White).ToArray(); break;
					case Filter.YellowOrWhite: scheta = scheta.Where(s => s.Yellow || s.White).ToArray(); break;
				}

				if (_isSnippenOnly) scheta = scheta.Where(s => s.IsShipped).ToArray();

				using (new GridViewStateSaver(gvScheta))
				{
					gcScheta.DataSource = scheta;
				}
				GvScheta_FocusedRowChanged(this, null);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public void PaySelectedSchets()
		{
			try
			{
				foreach (int h in gvScheta.GetSelectedRows())
				{
					if (!(gvScheta.GetRow(h) is CSchet vm)) continue;
					var schet = new Zakup.Models.CSchet(vm.ID);
					if (schet.Summa == schet.Oplatas.Summa)
					{
						MessageBox.Show($"Счет № {schet.Nomer} уже оплачен!", "Быстрая оплата", MessageBoxButtons.OK,
							MessageBoxIcon.Information);
						return;
					}

					if (DialogResult.Yes == MessageBox.Show(
							$"Счет № {schet.Nomer} будет оплачен одной суммой\n\r датой " +
							DateTime.Now.AddDays(-1).Date.ToString("dd/MM/yyyy") + "\n\r согласны?",
							"Быстрая оплата", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
					{
						schet.Pay();
						UpdateData(_start, _end, _oplataStart, _oplataEnd,
							_oplataFilter, _isSnippenOnly, _firma, _supplier, _isAvance);
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public void ExportToXlsx(string fileName) => gvScheta.ExportToXlsx(fileName);

		private void GvScheta_RowStyle(object sender, RowStyleEventArgs e)
		{
			try
			{
				if (!(gvScheta.GetRow(e.RowHandle) is CSchet schet)) return;
				var opacity = IsShowLoadToday ? 0.5 : 1;
				e.Appearance.BackColor = schet.Red ? Color.FromArgb((int)(opacity * 150), Color.Red)
					: schet.Yellow ? Color.FromArgb((int)(opacity * 50), Color.Yellow)
					: schet.Green ? Color.FromArgb((int)(opacity * 100), Color.Lime)
					: Color.White;

				if (IsShowLoadToday &&
					schet.dtc.Date == DateTime.Today &&
					schet.NomerInternal.NoEmpty())
				{
					e.Appearance.BackColor = Color.FromArgb(255, 128, 0);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void gvScheta_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
		{
			try
			{
				if (!(gvScheta.GetRow(e.RowHandle) is CSchet schet)) return;

				if (IsShowUpdateValues)
				{
					var fieldName = e.Column.FieldName.Replace("Name", "_ID");
					if (_whatUpdateService.IsUpdated(schet.ID, fieldName))
					{
						e.Appearance.BackColor = Color.FromArgb(0, 100, 200);
						e.Appearance.ForeColor = Color.White;
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void GcScheta_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				if (!(sender is GridControl gc)) return;
				var pt = gc.PointToClient(MousePosition);
				if (!(gc.Views[0] is GridView gv)) return;
				var hitInfo = gv.CalcHitInfo(pt);
				if (!hitInfo.InRow) return;

				EditingSchet?.Invoke(sender, e);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void GcScheta_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				EditingSchet?.Invoke(sender, e);

			if (e.KeyCode == Keys.Delete)
				DeletingSchet?.Invoke(sender, e);
		}
		private void GvScheta_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
		{
			try
			{
				if (!(gvScheta.GetFocusedRow() is CSchet vm))
				{
					gcOplatas.DataSource = null;
					gcSchetLines.DataSource = null;
					txtComment.ResetText();
					return;
				}

				var schet = new Zakup.Models.CSchet(vm.ID);
				gcOplatas.DataSource = schet.Oplatas.dt;
				gvOplatas.Columns[0].Visible = false;

				gcSchetLines.DataSource = schet.Lines;
				txtComment.Text = schet.Comment;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvScheta_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (IsErrorAccess()) return;
				if (!(gvScheta.GetFocusedRow() is CSchet vm)) return;
				using (var db = new DbContext())
				{
					vm.User = Environment.UserName;
					vm.dtu = DateTime.Now;
					db.Update((CSchetDto)vm);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvScheta_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				//if (IsErrorAccess()) return;
				if (!(gvScheta.GetFocusedRow() is CSchet vm)) return;
				if (gvScheta.FocusedColumn == colIsShipped && vm.IsAvance) e.Cancel = true;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public bool IsErrorAccess()
		{
			var user = ApplicationUser.User;
			if (user?.Role == Role.Rukovod)
			{
				MessageService.ShowError("У Вас нет доступа к редактированию счетов.");
				return true;
			}
			return false;
		}
	}
}
