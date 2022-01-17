using am.BL;
using SC.Zakup.Models;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Linq;
using System.Windows.Forms;
using LinqToDB;
using LinqToDB.Data;
using SC.Zakup.Properties;
using SC.Common.Dal;
using SC.Common.Views;
using SC.Zakup.Properties;
using CNakladnaya = SC.Zakup.Models.CNakladnaya;

namespace SC.Zakup.Views
{
	public partial class FrmEditNaklad : DevExpress.XtraEditors.XtraForm
	{
		private bool _updating;
		private readonly CNakladnayaDto _nakladnaya;
		private readonly CNakladLine[] _lines;
		private CProjectDto _toProject;
		private CObjectDto _toObject;

		public FrmEditNaklad(int nakladId, int? objId)
		{
			try
			{
				InitializeComponent();
				LayoutSaver.Restore(this);

				using (var db = new DbContext())
				{
					_nakladnaya = db.GetByID<CNakladnayaDto>(nakladId);
					_lines = db.Query<CNakladLine>(Resources.NakladLines,
						new DataParameter("@nakladId" , nakladId)).ToArray();
					_toObject = db.GetByID<CObjectDto>(objId);
					_toProject = db.GetByID<CProjectDto>(_toObject?.Project_ID);
					var postup = db.GetByID<CPostupleniyaDto>(_lines.FirstOrDefault()?.Postup_ID);
					lbKonragent.Text = postup?.Kontragent?.Trim();
					lbFirma.Text = postup?.Organization.Trim();
				}

				G.OnError += s => MessageService.ShowError($"Ошибка в базе данных!\n {s}");

				riCategory.Items.AddRange(Common.Model.CPostupleniya.EditableCategories);

				lbObject.Visible =
				btnSelectObject.Visible = _toObject != null;

				gvNakladLines.OptionsBehavior.Editable =
				txtNumber.Enabled =
				deDate.Enabled = (_nakladnaya.FromObject_ID ?? 0) > 0;

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
				using (var db = new DbContext())
				{
					db.Update(_nakladnaya);
					foreach (var line in _lines)
					{
						if (line.Quantity > 0) db.Update(_nakladnaya);
						else db.Delete(line);
					}
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

				_nakladnaya.Object_ID = _toObject?.ID;

				btnSelectObject.Text = $"Проект: {_toProject?.Name}  Объект: {_toObject?.Address}  Адрес: {_toObject?.Name}";
				txtNumber.Text = _nakladnaya.DocNumber;
				deDate.DateTime = _nakladnaya.DocDate;

				gcNakladLines.DataSource = _lines;
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
			if (_updating) return;
			_nakladnaya.DocNumber = txtNumber.Text;
			UpdateData();
		}
		private void BtSelectObject_Click(object sender, EventArgs e)
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

		private void EditDate_EditValueChanged(object sender, EventArgs e)
		{
			if (_updating) return;
			_nakladnaya.DocDate = deDate.DateTime;
			UpdateData();
		}

		private void gvNakladLines_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			UpdateData();
		}

		private void gvNakladLines_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				if (gvNakladLines.FocusedColumn == colCategory ||
					gvNakladLines.FocusedColumn == colInventoryNum)
				{
					e.Cancel = !CNakladLine.IsEditableCell(gvNakladLines);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void FrmEditNaklad_FormClosed(object sender, FormClosedEventArgs e)
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