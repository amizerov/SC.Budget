using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
using LinqToDB;
using LinqToDB.Data;
using SC.Zakup.Models;
using SC.Zakup.Properties;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SC.Common.Views;
using CPostupleniya = SC.Common.Model.CPostupleniya;

namespace SC.Zakup.Views
{
	public partial class PagePostup : DevExpress.XtraEditors.XtraUserControl
	{
		private CNakladnayaDto _nakladnaya;
		private List<CNakladLine> _nakladLines = new List<CNakladLine>();
		private DateTime _start, _end;
		private bool _isOnlyMy;
		private int? _firma_ID;

		public PagePostup()
		{
			try
			{
				InitializeComponent();

				Reload();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void Reload()
		{
			_nakladnaya = new CNakladnayaDto
			{
				DocNumber = "Не задан",
				User = Environment.UserName
			};
			_nakladLines = new List<CNakladLine>();
			btnSelectObject.Text = "Выбрать объект";

			gcNaklad.DataSource = _nakladLines;
			btnSelectObject.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
		}
		public void UpdateData(DateTime start, DateTime end, bool isOnlyMy, string firma = null)
		{
			try
			{
				_start = start;
				_end = end;
				_isOnlyMy = isOnlyMy;

				using (var db = new DbContext())
				{
					var projectsId = CProjectDto.GetIds(true, false, true, !isOnlyMy);
					if (firma == "Все") _firma_ID = null;
					else if (firma.NoEmpty())
					{
						_firma_ID = db.GetID<CFirmaDto>(firma);
					}
					var postup = db.Query<CPostupleniya>(Resources.Postupleniya, 
							new DataParameter("@firmaId", _firma_ID))
						.Where(p => p.DocDate >= start && p.DocDate < end)
						.Where(p => p.Category == PostupCategory.Услуга || p.Category == PostupCategory.Аренда)
						.Where(p => !_isOnlyMy || projectsId.Contains(p.Project_ID ?? -1))
					.ToArray();

					using (new GridViewStateSaver(gvPostup))
					{
						gcPostup.DataSource = postup;
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void BtnSelectObject_Click(object sender, EventArgs e)
		{
			try
			{
				using (var form = new FrmSelectObj())
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						var obj = new CObject(form.Object_ID);
						btnSelectObject.Text = $"{obj.Project.Name}: {obj.Name} {obj.Address}";
						_nakladnaya.Object_ID = form.Object_ID;
						btnSelectObject.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void BtnClearNakl_Click(object sender, EventArgs e)
		{
			try
			{
				Reload();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void BtnNaklCreate_Click(object sender, EventArgs e)
		{
			try
			{
				if (_nakladnaya.Object_ID == null)
				{
					MessageService.ShowError("Не выбран объект!");
					return;
				}

				if (_nakladnaya == null || !_nakladLines.Any())
				{
					MessageService.ShowError("Пустая накладная!");
					return;
				}

				_nakladnaya.DocDate = DateTime.Now;

				using (var db = new DbContext())
				{
					var nakladId = db.InsertWithInt32Identity(_nakladnaya);
					_nakladLines.ForEach(line =>
					{
						line.Naklad_ID = nakladId;
						db.Insert((CNakladLineDto)line);
					});
					_nakladLines.Select(l => l.Postup_ID).Distinct()
						.ForEach(postupId => db.Execute(Resources.UpdateQuantityMoved,
							new DataParameter("@postupId", postupId)));
				}

				UpdateData(_start, _end, _isOnlyMy);
				BtnClearNakl_Click(null, null);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void GvPostup_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				var pt = gcPostup.PointToClient(MousePosition);
				var hitInfo = gvPostup.CalcHitInfo(pt);
				if (!hitInfo.InRow) return;

				if (gvPostup.GetFocusedRow() is CPostupleniya postup)
				{
					AddPostupToNaklad(postup);
					UpdateNaklad();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public void AddSelectedPostupsToNaklad()
		{
			try
			{
				foreach (var h in gvPostup.GetSelectedRows())
				{
					if (gvPostup.GetRow(h) is CPostupleniya postup)
					{
						AddPostupToNaklad(postup);
					}
				}
				UpdateNaklad();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void AddPostupToNaklad(CPostupleniya postup)
		{
			try
			{
				if (_nakladLines.Any(l => l.Postup_ID == postup.ID)) return;

				var line = MapperService.Map<CNakladLine>(postup);
				_nakladLines.Add(line);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void UpdateNaklad()
		{
			try
			{
				gcNaklad.DataSource = null;
				gcNaklad.DataSource = _nakladLines;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void GvNaklad_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Delete)
				{
					if (!(gvNaklad.GetFocusedRow() is CNakladLine nl)) return;

					_nakladLines.Remove(nl);

					gcNaklad.DataSource = null;
					gcNaklad.DataSource = _nakladLines;
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void GvNakladLines_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
		{
			try
			{
				if (!(gvNaklad.GetFocusedRow() is CNakladLine line)) return;

				if (gvNaklad.FocusedColumn == colQuantity)
				{
					if (int.Parse(e.Value.ToString()) > line.QuantityOnSklad)
					{
						e.ErrorText = "Столько товара нет на складе";
						e.Valid = false;
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public void DeleteSelectedPostup()
		{
			try
			{
				var rows = gvPostup.GetSelectedRows();
				var question = $"{rows.Length} поступлений будут помечены удалёнными.\nПродолжить?";
				if (MessageService.ShowQuestion(question) != DialogResult.Yes) return;

				using (var db = new DbContext())
				{
					foreach (var h in rows)
					{
						if (!(gvPostup.GetRow(h) is CPostupleniya postup)) continue;
						{
							if (db.GetTable<CNakladLineDto>()
									.Any(n => n.Postup_ID == postup.ID))
							{
								var q = $"Поступление {postup} уже разнесено " +
										"(частично или полностью) по объектам.\n" +
										"При продолжении поступления на объектах " +
										"также будут помечены удалёнными\n" +
										"Продолжить?";
								if (MessageService.ShowQuestion(q) != DialogResult.OK) continue;
							}

							db.GetTable<CPostupleniyaDto>()
								.Where(p => p.ID == postup.ID)
								.Set(p => p.IsDeleted, true)
								.Update();
						}
					}
				}
				UpdateData(_start, _end, _isOnlyMy);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}
