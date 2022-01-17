using System.Windows.Forms;

namespace SwissClean.MVP.CreateResource
{
	public class CreateResourcePresenter
	{
		private readonly CreateResourceModel _model;
		private readonly ResourceView _view;

		public CreateResourcePresenter(CreateResourceModel model, ResourceView view)
		{
			_model = model;
			_view = view;

			_model.Error += (sender, error) => _view.ShowError(error);
			_model.Changed += (sender, args) => _view.Close();

			if (_view.ShowDialog() == DialogResult.OK)
			{
				_model.CreateResource(_view.ViewModel);
			}
		}
	}
}
