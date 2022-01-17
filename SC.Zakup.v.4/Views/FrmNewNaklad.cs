using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using LinqToDB;
using LinqToDB.Data;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SC.Common.Views;

namespace SC.Zakup.Views
{
	public partial class FrmNewNaklad : XtraForm
	{
		private bool _updating;
		private readonly CNakladnayaDto _nakladnaya;
		private readonly bool _isToNull;
		private CProjectDto _toProject;
		private CObjectDto _toObject;
		private readonly CNakladLine[] _fromObjLines;
		private readonly List<CNakladLine> _movingLines = new List<CNakladLine>();

		public FrmNewNaklad(CNakladLine[] lines, int? fromObjId, bool isToNull)
		{
			_isToNull = isToNull;
			try
			{
				InitializeComponent();

				LayoutSaver.Restore(this);

				_fromObjLines = lines;

				_nakladnaya = new CNakladnayaDto
				{
					FromObject_ID = fromObjId,
					DocDate = DateTime.Now,
					DocNumber = "Без номера",
					User = Environment.UserName
				};

				lbObject.Visible =
				btnSelectObject.Visible = !_isToNull;
				if (_isToNull)
				{
					Text = "Списание товара";
					lbMovingLinesTitle.Text = "Позиции на списание";
				}
				UpdateData();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void BtnOk_Click(object sender, EventArgs e)
		{
			try
			{
				if (!_isToNull && _toObject == null)
				{
					MessageService.ShowError("Объект не выбран.");
					return;
				}
				if (_nakladnaya.DocNumber.IsEmpty())
				{
					MessageService.ShowError("Не заполнено поле 'Номер документа'.");
					return;
				}
				if (!_movingLines.Any())
				{
					MessageService.ShowError($"Не заполнено поле '{lbMovingLinesTitle.Text}'.");
					return;
				}
				_nakladnaya.Object_ID = _isToNull ? 0 : _toObject?.ID;

				using (var db = new DbContext())
				{
					var nakladId = db.InsertWithInt32Identity(_nakladnaya);
					_movingLines.ForEach(l =>
					{
						l.ID = 0;
						l.Naklad_ID = nakladId;
					});
					var movingLinesDto = _movingLines
						.Select(MapperService.Map<CNakladLineDto>)
						.ToArray();
					db.BulkCopy(movingLinesDto);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void UpdateData()
		{
			try
			{
				_updating = true;

				txtNumber.Text = _nakladnaya.DocNumber;

				btnSelectObject.Visible = !_isToNull;
				btnSelectObject.Text = _toObject == null ? "Выбрать объект"
					: $"Проект: {_toProject?.Name}  Объект: {_toObject.Address}  Адрес: {_toObject.Name}";
				btnSelectObject.Enabled = !_isToNull;

				deDate.DateTime = _nakladnaya.DocDate;

				var fromObjLines = new List<CNakladLine>();
				foreach (var line in _fromObjLines)
				{
					var movingLine = _movingLines.FirstOrDefault(l => l.ID == line.ID);
					if (movingLine == null) fromObjLines.Add(line);
					else if (movingLine.Quantity < line.Quantity)
					{
						var calcFromLine = line.Clone();
						calcFromLine.Quantity -= movingLine.Quantity;
						fromObjLines.Add(calcFromLine);
					}
				}
				gcFromObjLines.DataSource = fromObjLines;
				gcMovingLines.DataSource = _movingLines.ToArray();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
			finally
			{
				_updating = false;
			}
		}

		private void TbNumber_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (_updating) return;
				_nakladnaya.DocNumber = txtNumber.Text;
				UpdateData();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void BtSelectObject_Click(object sender, EventArgs e)
		{
			try
			{
				using (var form = new FrmSelectObj())
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						using (var db = new DbContext())
						{
							_toObject = db.GetByID<CObjectDto>(form.Object_ID);
							_toProject = db.GetByID<CProjectDto>(form.Project_ID);
						}
						UpdateData();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void EditDate_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (_updating) return;
				_nakladnaya.DocDate = deDate.DateTime;
				UpdateData();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvFromObjLines_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				var pt = gcFromObjLines.PointToClient(MousePosition);
				var hitInfo = gvFromObjLines.CalcHitInfo(pt);
				if (!hitInfo.InRow) return;

				if (!(gvFromObjLines.GetFocusedRow() is CNakladLine line)) return;
				using (var form = new FrmNakladLineQuantity(line, null))
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						_movingLines.Add(form.NakladLine);
						UpdateData();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void gvMovingLines_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				var pt = gcMovingLines.PointToClient(MousePosition);
				var hitInfo = gvMovingLines.CalcHitInfo(pt);
				if (!hitInfo.InRow) return;

				if (!(gvMovingLines.GetFocusedRow() is CNakladLine line)) return;
				var fromLine = _fromObjLines.First(l => l.ID == line.ID);
				using (var form = new FrmNakladLineQuantity(fromLine, line))
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						UpdateData();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void FrmMoveNakLines_FormClosed(object sender, FormClosedEventArgs e)
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

		private void btSendAll_Click(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < gvFromObjLines.RowCount; i++)
				{
					if (gvFromObjLines.IsDataRow(i) &&
						gvFromObjLines.GetRow(i) is CNakladLine line &&
						!_movingLines.Contains(line))
					{
						_movingLines.Add(line);
					}
				}
				UpdateData();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvMovingLines_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Delete)
				{
					if (!(gvMovingLines.GetFocusedRow() is CNakladLine line)) return;
					_movingLines.Remove(line);
					UpdateData();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btClearMoving_Click(object sender, EventArgs e)
		{
			try
			{
				_movingLines.Clear();
				UpdateData();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void FrmNewNaklad_Resize(object sender, EventArgs e)
		{
			try
			{
				splitContainerControl1.Dock = DockStyle.Fill;
				var size = splitContainerControl1.Size;
				splitContainerControl1.Dock = DockStyle.Top;
				splitContainerControl1.Size = size;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}