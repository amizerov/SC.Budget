using LinqToDB;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Windows.Forms;

namespace SC.Proda.Views
{
	public partial class FrmNewOrEditStDoho : DevExpress.XtraEditors.XtraForm
	{
		private CStDoho _stDoho;

		public FrmNewOrEditStDoho(CStDoho stDoho = null)
		{
			_stDoho = stDoho;
			try
			{
				InitializeComponent();

				if (_stDoho == null)
				{
					Text = "Новая статья дохода";
				}
				else
				{
					Text = "Редактирование статьи дохода";
					txtName.Text = _stDoho.Name;
					chbNoUsed.Checked = _stDoho.NoUsed;
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
				if (_stDoho == null) _stDoho = new CStDoho();

				_stDoho.Name = txtName.Text;
				_stDoho.NoUsed = chbNoUsed.Checked;

				if (_stDoho.Name.IsEmpty())
				{
					MessageService.ShowError("Не заполнено поле 'Наименование'.\n" +
											 "Продолжение невозможно!");
					return;
				}

				var stDohoDto = MapperService.Map<CStDohoDto>(_stDoho);

				using (var db = new DbContext())
				{
					if (stDohoDto.ID > 0) db.Update(stDohoDto);
					else db.Insert(stDohoDto);
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