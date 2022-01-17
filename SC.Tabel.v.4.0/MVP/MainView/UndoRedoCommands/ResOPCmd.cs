using SwissClean.MVP.MainView.ViewModels;
using SwissClean.Services.UndoRedo;

namespace SwissClean.MVP.MainView.UndoRedoCommands
{
	public class ResOpCmd : ICommand
	{
		public ResOpCmd(MainModel model, UndoRedoEventArgs<ResOPViewModel> e)
		{
			_model = model;
			_value = e.Value;
			_prevValue = e.PevValue;
		}

		private readonly MainModel _model;
		private readonly ResOPViewModel _value;
		private readonly ResOPViewModel _prevValue;

		/// <summary>
		/// Name for MenuItem
		/// </summary>
		public string Name => $"Изменение оплаты сотруднику '{_value.Name}'";

		/// <summary>
		/// Execute the command
		/// </summary>
		public void Execute()
		{
			_model.SaveResOp(_value);
		}
		/// <summary>
		/// UnExecute the command
		/// </summary>
		public void UnExecute()
		{
			_model.SaveResOp(_prevValue);
		}
	}
}