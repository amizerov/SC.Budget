using SwissClean.MVP.MainView.ViewModels;
using SwissClean.Services.UndoRedo;

namespace SwissClean.MVP.MainView.UndoRedoCommands
{
	public class ReplaceResourceCmd : ICommand
	{
		public ReplaceResourceCmd(MainModel model, UndoRedoEventArgs<ResOPViewModel> e)
		{
			_model = model;
			_value = e.Value;
			_prevValue = e.PevValue;
		}

		private readonly MainModel _model;
		private readonly ResOPViewModel _value;
		private readonly ResOPViewModel _prevValue;

		public string Name => $"Замена сотрудника '{_prevValue.Name}' на '{_value.Name}'";

		public void Execute()
		{
			_model.ReplaceResource(_value);
		}
		public void UnExecute()
		{
			_model.ReplaceResource(_prevValue);
		}
	}
}