using SwissClean.MVP.MainView.ViewModels;
using SwissClean.Services.UndoRedo;

namespace SwissClean.MVP.CreateResource.UndoRedoCommands
{
	public class CreateResourceCmd : ICommand
	{
		public CreateResourceCmd(CreateResourceModel model, ResOPViewModel value)
		{
			_model = model;
			_value = value;
			Name = $"Создание сотрудника '{_value.Name}'";
		}

		private readonly CreateResourceModel _model;
		private readonly ResOPViewModel _value;

		public string Name { get; }

		public void Execute()
		{
			_model.CreateResource(_value);
		}
		public void UnExecute()
		{
			_model.DeleteResource(_value);
		}
	}
}