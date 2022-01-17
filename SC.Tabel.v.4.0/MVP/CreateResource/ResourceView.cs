using am.BL;
using DevExpress.XtraEditors;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SwissClean.MVP.CreateResource
{
	public partial class ResourceView : XtraForm
	{
		private readonly int? _managerId;
		private bool _updating;
		public ResourceView()
		{
			try
			{
				InitializeComponent();
				G.OnError += error => ShowError($"Ошибка в базе данных:\n{error}");

				_managerId = ApplicationUser.User?.ID;
				ViewModel = new ResOPViewModel
				{
					IsStaff = true,
					ManagerID = _managerId
				};
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public ResOPViewModel ViewModel { get; private set; }

		public void Update(ResOPViewModel vm)
		{
			try
			{
				_updating = true;

				ViewModel = vm;

				txtName.Text = ViewModel.Name;
				txtPhone.Text = ViewModel.Phone;
				txtOfficialSalary.Text = ViewModel.OfficialSalary.ToString();
				txtNalog.Text = ViewModel.Nalog.ToString();
				checkFreeLance.Checked = !ViewModel.IsStaff;
				chbNoWorking.Checked = ViewModel.NoWorking;
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

		private void BtOk_Click(object sender, EventArgs e)
		{
			try
			{
				var (isError, error) = ValidateService.Validate(ViewModel);
				if (isError)
				{
					ShowError(error);
					return;
				}

				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void TbName_EditValueChanged(object sender, EventArgs e)
		{
			if (_updating) return;
			ViewModel.Name = txtName.Text;
		}
		private void TbName_KeyPress(object sender, KeyPressEventArgs e)
		{
			var length = txtName.Text.Length;
			txtName.Text = string.Concat(txtName.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)));
			if (txtName.Text.Length < length)
			{
				txtName.SelectionStart = txtName.Text.Length + 1;
			}
		}
		private void TbName_KeyUp(object sender, KeyEventArgs e)
		{
			var length = txtName.Text.Length;
			txtName.Text = string.Concat(txtName.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)));
			if (txtName.Text.Length < length)
			{
				txtName.SelectionStart = txtName.Text.Length + 1;
			}
		}
		private void TbPhone_TextChanged(object sender, EventArgs e)
		{
			if (_updating) return;
			ViewModel.Phone = txtPhone.MaskCompleted ? txtPhone.Text : null;
		}

		private void TbOfficialSalary_EditValueChanged(object sender, EventArgs e)
		{
			if (_updating) return;
			ViewModel.OfficialSalary = txtOfficialSalary.Text.ToDecimal();
			var nalog = Math.Round(ViewModel.OfficialSalary * 0.43m, 0);
			txtNalog.Text = nalog.ToString();
		}

		private void txtNalog_EditValueChanged(object sender, EventArgs e)
		{
			if (_updating) return;
			ViewModel.Nalog = txtNalog.Text.ToDecimal();
		}

		private void CheckFreeLance_CheckedChanged(object sender, EventArgs e)
		{
			if (_updating) return;
			ViewModel.IsStaff = !checkFreeLance.Checked;
			ViewModel.ManagerID = ViewModel.IsStaff ? _managerId : null;
		}
		private void chbNoWorking_CheckedChanged(object sender, EventArgs e)
		{
			if (_updating) return;
			ViewModel.NoWorking = chbNoWorking.Checked;
		}

		public void ShowError(string error)
		{
			if (Disposing || IsDisposed) return;
			MessageService.ShowError(error);
		}
	}
}