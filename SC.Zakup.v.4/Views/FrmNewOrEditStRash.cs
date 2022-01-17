using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Windows.Forms;
using LinqToDB;
using SC.Common.Dal;

namespace SC.Zakup.Views
{
	public partial class FrmNewOrEditStRash : DevExpress.XtraEditors.XtraForm
	{
		private CStRash _stRash;

		public FrmNewOrEditStRash(CStRash stRash = null)
		{
			_stRash = stRash;
			try
			{
				InitializeComponent();

				if (_stRash == null)
				{
					Text = "Новая статья расхода";
				}
				else
				{
					Text = "Редактирование статьи расхода";
					txtName.Text = _stRash.Name;
					chbNoUsed.Checked = _stRash.NoUsed;
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
				if (_stRash == null) _stRash = new CStRash();

				_stRash.Name = txtName.Text;
				_stRash.NoUsed = chbNoUsed.Checked;

				if (_stRash.Name.IsEmpty())
				{
					MessageService.ShowError("Не заполнено поле 'Наименование'.\n" +
											 "Продолжение невозможно!");
					return;
				}

				var stRashDto = MapperService.Map<CStRashDto>(_stRash);

				using (var db = new DbContext())
				{
					if (stRashDto.ID > 0) db.Update(stRashDto);
					else db.Insert(stRashDto);
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