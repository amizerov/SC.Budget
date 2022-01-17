using am.BL;
using DevExpress.XtraEditors;
using SC.Common.Model;
using SC.Common.Services;
using SwissClean.Dal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using CPosition = SwissClean.Dal.Dto.CPosition;

namespace SwissClean.MVP.SetResourceOnObject
{
	public partial class SetResourceOnObjectView : XtraForm
	{
		private readonly IDataAccessService _db;
		private readonly int _managerId;
		private List<CResourceDto> _resources;
		private CResourceDto _resource;
		private readonly List<CPosition> _positions;

		public SetResourceOnObjectView(ResOPViewModel vm)
		{
			InitializeComponent();

			try
			{
				_db = new DataAccessService();
				G.OnError += error => ShowError($"Ошибка в базе данных:\n{error}");

				lblObject.Text = $"Объект: {vm.ObjectNameForResOp}";

				_managerId = ApplicationUser.User?.ID ?? -1;
				_resources = ApplicationUser.User?.Role == Role.Manager
					? _db.GetResources(SelectionResourceMode.Staff, _managerId)
					: _db.GetUserResourcesForProject(vm.Project_ID);
				_positions = _db.GetPositions(vm.Object_ID);

				cbResource.Properties.Items
					.AddRange(_resources?.Select(r => r.Name).ToArray());
				cbPosition.Properties.Items
					.AddRange(_positions?.Select(r => r.Name).ToArray());

				ResOp = new CResOPDto(vm.Month, vm.Object_ID, vm.Resource_ID);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public CResOPDto ResOp { get; }

		private void BtnOk_Click(object sender, EventArgs e)
		{
			try
			{
				if (cbResource.SelectedIndex >= 0)
				{
					var resource = _resources[cbResource.SelectedIndex];
					_db.SaveResource(resource);

					ResOp.Resource_ID = resource.ID;
					ResOp.Position = cbPosition.Text;
					ResOp.Salary = txtSalary.Text.ToDecimal();
					//ResOp.Position_ID = _positions[cbPosition.SelectedIndex].ID;

					DialogResult = DialogResult.OK;
					Close();
				}
				else
				{
					lblErrorCreate.Visible = true;
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void CbResource_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_resource = _resources[cbResource.SelectedIndex];
				txtPhone.Text = _resource.Phone;
				txtOfficialSalary.Text = _resource.OfficialSalary?.ToString(CultureInfo.CurrentCulture);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void CheckFreelance_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				_resources = checkFreeLance.Checked
					? _db.GetResources(SelectionResourceMode.Freelance, _managerId)
					: _db.GetResources(SelectionResourceMode.Staff, _managerId);

				cbResource.Properties.Items.Clear();
				cbResource.SelectedIndex = -1;

				txtPhone.ResetText();

				if (_resources.Count > 0)
				{
					cbResource.Properties.Items
						.AddRange(_resources?.Select(r => r.Name).ToArray());
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		public void ShowError(string error)
		{
			if (Disposing || IsDisposed) return;
			MessageService.ShowError(error);
		}

		private void cbPosition_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (cbPosition.SelectedIndex < 0) return;
				var position = _positions[cbPosition.SelectedIndex];
				txtSalary.Text = position.Salary.ToString(CultureInfo.CurrentCulture);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}