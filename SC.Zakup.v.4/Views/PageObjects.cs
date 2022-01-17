using DevExpress.XtraTreeList;
using LinqToDB;
using LinqToDB.Data;
using SC.Zakup.Models;
using SC.Zakup.Properties;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LinqToDB.Common;

namespace SC.Zakup.Views
{
	public partial class PageObjects : DevExpress.XtraEditors.XtraUserControl
	{
		private DateTime _start, _end;
		private int? _firma_ID;
		private CNakladLine[] _objLines;

		public PageObjects()
		{
			try
			{
				InitializeComponent();
				riCategory.Items.AddRange(Common.Model.CPostupleniya.EditableCategories);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public object FocusedObjectProjectTree => treeObjects.GetFocusedRow();

		public List<PostupCategory> CategoryFilter { get; set; }
		public void UpdateData() => UpdateData(_start, _end);
		public void UpdateData(DateTime start, DateTime end, string firma = null)
		{
			try
			{
				_start = start;
				_end = end;
				var projectsId = CProjectDto.GetIds(false, true, true, false);

				using (var db = new DbContext())
				{
					_firma_ID = firma.IsEmpty() || firma == "Все" ? (int?)null
						: db.GetID<CFirmaDto>(firma);

					var sql = Resources.ObjectProjectTree
						.Replace("@projectIds", string.Join(",", projectsId));

					var tree = db.Query<ObjectProjectTree>(sql,
							new DataParameter("@start", _start),
							new DataParameter("@end", _end),
							new DataParameter("@firmaId", _firma_ID))
						.ToArray();

					using (new TreeListStateSaver(treeObjects))
					{
						treeObjects.DataSource = tree;
					}
				}
				TreeObjects_FocusedNodeChanged(this, null);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public void TreeObjects_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
		{
			try
			{
				if (!(treeObjects.GetFocusedRow() is ObjectProjectTree vm)) return;
				using (var db = new DbContext())
				{
					_objLines = db.Query<CNakladLine>(Resources.SkladGrouping,
							new DataParameter("@objectId", vm.Object_ID),
							new DataParameter("@start", _start),
							new DataParameter("@end", _end))
						.Where(nl => CategoryFilter.IsNullOrEmpty() || CategoryFilter.Contains(nl.Category))
						.ToArray();
					gcObjSklad.DataSource = _objLines;
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public void NewNaklad(bool isToNull)
		{
			try
			{
				if (!(treeObjects.GetFocusedRow() is ObjectProjectTree vm)) return;
				if (vm.Type != ObjType.Object)
				{
					MessageService.ShowError("Для продолжения выделите объект в нижней таблице.");
					return;
				}
				if (!_objLines.Any())
				{
					MessageService.ShowError("В выбранном объекте не осталось поступлений");
					return;
				}
				using (var form = new FrmNewNaklad(_objLines, vm.Object_ID, isToNull))
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

		private void treeObjects_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
		{
			try
			{
				if (!(treeObjects.GetRow(e.Node.Id) is ObjectProjectTree vm)) return;
				if (vm.Type == ObjType.Project)
				{
					e.Appearance.BackColor = Color.FromArgb(150, 213, 238, 255);
					e.Appearance.BorderColor = Color.FromArgb(255, 150, 153, 169);
				}
				else if (vm.Type == ObjType.Summary)
				{
					e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
					e.Appearance.BackColor = Color.FromArgb(75, 128, 128, 128);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void treeObjects_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
		{
			try
			{
				TreeListService.CustomDrawNodeCell(e);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvObjSklad_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			try
			{
				if (!(gvObjSklad.GetFocusedRow() is CNakladLine nakladLine)) return;
				using (var db = new DbContext())
				{
					if (e.Column == colCategory)
					{
						db.GetTable<CPostupleniyaDto>()
							.Where(p => p.ID == nakladLine.Postup_ID)
							.Set(p => p.Category, nakladLine.Category)
							.Update();
					}
					else
					{
						var nakladLineDto = MapperService.Map<CNakladLineDto>(nakladLine);
						db.Update(nakladLineDto);
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvObjSklad_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				e.Cancel = !CNakladLine.IsEditableCell(gvObjSklad);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}
