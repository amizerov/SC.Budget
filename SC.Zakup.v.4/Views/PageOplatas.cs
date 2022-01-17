using SC.Common.Model;
using System;
using System.Linq;
using System.Windows.Forms;
using LinqToDB;
using LinqToDB.Data;
using SC.Zakup.Properties;
using SC.Common.Dal;
using SC.Common.Services;
using COplata = SC.Common.Model.COplata;

namespace SC.Zakup.Views
{
	public partial class PageOplatas : DevExpress.XtraEditors.XtraUserControl
	{
		private DateTime _start, _end;
		public PageOplatas()
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
		public void UpdateData(DateTime start, DateTime end)
		{
			try
			{
				_start = start;
				_end = end;
				using (var db = new DbContext())
				{
					var oplatas = db.Query<COplata>(Resources.Oplatas)
						.Where(s => s.Data >= _start && s.Data < _end)
						.ToArray();

					using (new GridViewStateSaver(gvOplatas))
					{
						gcOplatas.DataSource = oplatas;
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvOplatas_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			try
			{
				if (!(gvOplatas.GetFocusedRow() is COplata oplata)) return;
				using (var db = new DbContext())
				{
					var oplataDto = MapperService.Map<COplataDto>(oplata);
					oplataDto.User = Environment.UserName;
					oplataDto.dtu = DateTime.Now;
					db.Update(oplataDto);
				}
				UpdateData(_start, _end);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public void DeleteFocusedOplata()
		{
			try
			{
				if (!(gvOplatas.GetFocusedRow() is COplata oplata)) return;
				var question = $"Оплата {oplata} будет помечена удалённой.\n" +
							   "Продолжить?";
				if (MessageService.ShowQuestion(question) == DialogResult.Yes)
				{
					using (var db = new DbContext())
					{
						oplata.IsDeleted = true;
						oplata.User = Environment.UserName;
						oplata.dtu = DateTime.Now;
						db.Update(oplata);
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}
