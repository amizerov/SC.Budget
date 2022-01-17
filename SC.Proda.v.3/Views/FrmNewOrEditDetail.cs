using LinqToDB;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Windows.Forms;

namespace SC.Proda.Views
{
	public partial class FrmNewOrEditDetail : DevExpress.XtraEditors.XtraForm
	{
		private CDetailProda _detail;

		public FrmNewOrEditDetail(CDetailProda detail = null)
		{
			_detail = detail;
			try
			{
				InitializeComponent();

				if (_detail == null)
				{
					Text = "Новая услуга";
				}
				else
				{
					Text = "Редактирование услуги";
					txtName.Text = _detail.Name;
					chbNoUsed.Checked = _detail.NoUsed;
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
				if (_detail == null) _detail = new CDetailProda();

				_detail.Name = txtName.Text;
				_detail.NoUsed = chbNoUsed.Checked;

				if (_detail.Name.IsEmpty())
				{
					MessageService.ShowError("Не заполнено поле 'Наименование'.\n" +
											 "Продолжение невозможно!");
					return;
				}

				var detailDto = MapperService.Map<CDetailProdaDto>(_detail);

				using (var db = new DbContext())
				{
					if (detailDto.ID > 0) db.Update(detailDto);
					else db.Insert(detailDto);
				}

				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}