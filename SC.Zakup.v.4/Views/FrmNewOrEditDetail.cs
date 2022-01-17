using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Windows.Forms;
using LinqToDB;
using SC.Common.Dal;

namespace SC.Zakup.Views
{
	public partial class FrmNewOrEditDetail : DevExpress.XtraEditors.XtraForm
	{
		private CDetail _detail;

		public FrmNewOrEditDetail(CDetail detail = null)
		{
			_detail = detail;
			try
			{
				InitializeComponent();

				cbCategory.Properties.Items.AddRange(EnumService.AllNames<SchetCategory>());
				cbClass.Properties.Items.AddRange(EnumService.AllNames<DetailClass>());

				if (_detail == null)
				{
					Text = "Новая детализация";
					cbCategory.SelectedIndex = 0;
					cbClass.SelectedIndex = 0;
				}
				else
				{
					Text = "Редактирование детализации";
					txtName.Text = _detail.Name;
					cbCategory.SelectedIndex = (int)_detail.Category;
					cbClass.SelectedIndex = (int)_detail.Class;
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
				if (_detail == null) _detail = new CDetail();

				_detail.Name = txtName.Text;
				_detail.Category = (SchetCategory)cbCategory.SelectedIndex;
				_detail.Class = (DetailClass)cbClass.SelectedIndex;
				_detail.NoUsed = chbNoUsed.Checked;

				if (_detail.Name.IsEmpty())
				{
					MessageService.ShowError("Не заполнено поле 'Наименование'.\n" +
											 "Продолжение невозможно!");
					return;
				}

				var detailDto = MapperService.Map<CDetailDto>(_detail);

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