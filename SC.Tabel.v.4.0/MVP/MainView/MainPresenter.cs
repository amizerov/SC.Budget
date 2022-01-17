using SC.Common.Model;
using SC.Common.Views;
using SwissClean.MVP.CreateResource;
using SwissClean.MVP.Login;
using System.Windows.Forms;

namespace SwissClean.MVP.MainView
{
	public class MainPresenter
	{
		private readonly MainModel _model;
		private readonly MainView _view;
		private LoginPresenter _loginPresenter;

		public MainPresenter(MainModel model, MainView view)
		{
			_model = model;
			_view = view;

			_model.LoginChanged += (sender, user) => _view.UpdateLogin();
			_model.ResOpsUpdated += (sender, modelView) => _view.UpdateAll(modelView);
			_model.SelectedResOp += (sender, modelView) => _view.UpdateSelectedResOp(modelView);
			_model.Error += (sender, error) => _view.ShowError(error);

			_view.Logging += (sender, args) => Login(false);
			_view.Logout += (sender, args) =>
			{
				_model.Logout();
				Login(false);
			};

			_view.DebtFilterChange += (sender, filter) =>
			{
				_model.DebtFilter = filter;
				_model.Reload();
			};
			_view.NoWorkFilterChange += (sender, filter) =>
			{
				_model.NoWorkFilter = filter;
				_model.Reload();
			};

			_view.CreatingResource += (sender, viewModel) => CreateResource(viewModel);
			_view.EditingResource += (sender, viewModel) => EditResource(viewModel);
			_view.SettingResourceOnObject += (sender, args) => SetResourceOnObject();
			_view.DeletingResOp += (sender, viewModel) => _model.DeleteResOp();

			_view.ChangedMonth += (sender, month) => _model.ChangeMonth(month);
			_view.VedomostClick += (sender, objectId) => _model.CreateVedomost(objectId);

			_view.Days5_2Click += (sender, args) => _model.SaveTabels(_view.FirstWorkDay, 5, 2);
			_view.Days2_2Click += (sender, args) => _model.SaveTabels(_view.FirstWorkDay, 2, 2);
			_view.AllDaysClick += (sender, args) => _model.SaveTabels(_view.FirstWorkDay, 1, -1);
			_view.DeletingAllDays += (sender, args) => _model.SaveTabels(_view.FirstWorkDay, -1, 1);

			_view.UpdatingRest += (sender, args) => _model.Reload();
			_view.BeforePayAll += (sender, args) => _model.SetPayAll(args);

			_view.CreatingRequestOp += (sender, viewModel) => CreateRequestOp();

			_view.ReplacingResource += (sender, viewModel) => _model.ReplaceResource(viewModel);
			_view.ChangedResOp += (sender, args) => _model.ChangeResOp(args);
			_view.GetRejectingOperation += (sender, e) => _model.SetRejectingOperation(e);
			_view.RejectingOperation += (sender, op) => _model.RejectOperation(op);
			_view.CreatingOperation += (vm, amount, category) => _model.CreateOperation(vm, amount, category);
			_view.RecalculatingAllPays += (sender, e) => _model.RecalculateAllPays();
			_view.SelectResource += (sender, viewModel) => _model.SelectResOp(viewModel);
			_view.ChangedTabel += (sender, viewModel) => _model.SaveTabel(viewModel);
			
			_view.ClosingTabel += (sender, viewModel) => _model.SaveClosedTabel(viewModel);

			_model.Reload();

			_view.Show();
			Login(true);
		}

		private void CreateRequestOp()
		{
			using (var form = new FrmNewRequest())
			{
				if (form.ShowDialog(_view) == DialogResult.OK)
				{
					_model.Reload();
				}
			}
		}

		private void Login(bool isStartApp)
		{
			var model = _model.LoginModel;
			var view = _view.LoginView;
			if (_loginPresenter == null)
			{
				_loginPresenter = new LoginPresenter(model, view);
			}
			_loginPresenter.ShowView(isStartApp);
		}

		private void CreateResource(ResOPViewModel viewModel)
		{
			var model = _model.GetCreateResourceModel();
			var view = new ResourceView { Owner = _view };
			new CreateResourcePresenter(model, view);
		}
		private void EditResource(ResOPViewModel viewModel)
		{
			var view = new ResourceView { Owner = _view };
			view.Text = $"Изменить сотрудника {viewModel.Name}";
			view.Update(viewModel);
			if (view.ShowDialog() == DialogResult.OK)
			{
				_model.EditResource(view.ViewModel);
			}
		}
		private void SetResourceOnObject()
		{
			var view = _view.SetResourceOnObjectView;
			if (view.ShowDialog() == DialogResult.OK)
			{
				_model.CreateResOp(view.ResOp);
			}
		}
	}
}
