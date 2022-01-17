using SC.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LinqToDB;
using SC.Zakup.Models;
using SC.Common.Dal;
using SC.Common.Services;

namespace SC.Zakup.Views
{
	public partial class FrmAddNakladLines : DevExpress.XtraEditors.XtraForm
	{
		private readonly int _objectId;
		private readonly List<CNakladLine> _lines = new List<CNakladLine>();
		public FrmAddNakladLines(int objectId, string objName)
		{
			try
			{
				InitializeComponent();

				LayoutSaver.Restore(this);

				_objectId = objectId;
				Text = $"Добавление товара на объект {objName}";

				using (var db = new DbContext())
				{
					var nomenkls = db.AllNames<CNomenklaturaDto>();
					riNomekl.Items.AddRange(nomenkls);
				}
				UpdateData();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void UpdateData()
		{
			gcNakladLines.DataSource = _lines.ToArray();
			btDelete.Enabled = _lines.Any();
		}
		private void btAdd_Click(object sender, EventArgs e)
		{
			try
			{
				_lines.Add(new CNakladLine
				{
					Nomenkl = "Наименование",
					Measure = "Штука",
					Quantity = 1,
				});
				UpdateData();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btDelete_Click(object sender, EventArgs e)
		{
			try
			{
				if (!(gvNakladlines.GetFocusedRow() is CNakladLine line)) return;
				_lines.Remove(line);
				UpdateData();
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
					var naklad = new CNakladnayaDto
					{
						Object_ID = _objectId,
						DocDate = DateTime.Now,
						DocNumber = "Остатки",
						User = Environment.UserName
					};
					naklad.ID = db.InsertWithInt32Identity(naklad);

					foreach (var line in _lines)
					{
						line.Naklad_ID = naklad.ID;
						line.Naklad = naklad.DocNumber;
						line.DocDate = DateTime.Now;
						var postup = MapperService.Map<CPostupleniyaDto>(line);
						postup.Schet = "";
						postup.Nomenkl_ID = db.GetOrNew<CNomenklaturaDto>(line.Nomenkl)?.ID ?? 0;
						postup.User = Environment.UserName;
						postup.ID = db.InsertWithInt32Identity(postup);
						var nakLine = new CNakladLineDto
						{
							Naklad_ID = naklad.ID,
							Postup_ID = postup.ID,
							Quantity = line.Quantity,
							InventoryNum = line.InventoryNum,
						};
						db.Insert(nakLine);
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

		private void gvNakladlines_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
		{
			try
			{
				if (!(gvNakladlines.GetFocusedRow() is CNakladLine vm)) return;
				var fieldName = gvNakladlines.FocusedColumn.FieldName;
				var validator = new NakladLineValidator();

				var prevVm = vm.Clone();
				ValidateService.Validate(e, validator, prevVm, vm, fieldName);
			}
			catch (Exception ex)
			{
				e.ErrorText = ex.Message;
				e.Valid = false;
			}
		}
		private void gvNakladlines_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				if (gvNakladlines.FocusedColumn == colCategory ||
					gvNakladlines.FocusedColumn == colInventoryNum)
				{
					e.Cancel = !CNakladLine.IsEditableCell(gvNakladlines);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void FrmAddNakladLines_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
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