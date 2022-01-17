using SwissClean.MVP.MainView.ViewModels;
using SwissClean.Services.UndoRedo;

namespace SwissClean.MVP.MainView.UndoRedoCommands
{
	public class DeleteResOpCmd : ICommand
	{
		public DeleteResOpCmd(MainModel model, ResOPViewModel value)
		{
			_model = model;
			_value = value;
		}

		private readonly MainModel _model;
		private readonly ResOPViewModel _value;

		public string Name => $"Удаление оплаты сотруднику '{_value.Name}'";

		public void Execute()
		{
			_model.DeleteResOp();
		}
		public void UnExecute()
		{
			_model.SaveResOp(_value);
		}
	}
}