using SwissClean.Dal.Dto;
using SwissClean.MVP.MainView.ViewModels;
using SwissClean.Services.UndoRedo;

namespace SwissClean.MVP.MainView.UndoRedoCommands
{
	public class TabelCmd : ICommand
	{
		public TabelCmd(MainModel model, TabelViewModel value)
		{
			_model = model;
			_value = value;
			_prevValue = new TabelViewModel
			{
				ID = value.ID,
				Date = value.Date,
				Object_ID = value.Object_ID,
				ResOP_ID = value.ResOP_ID,
				Resource_ID = value.Resource_ID,
				IsExit = !value.IsExit,
			};
			Name = $"Изменение дня выхода для сотрудника '{_model.CurrentResourceName}'";
			_resOP = _model.CurrentResOp;
		}

		private readonly MainModel _model;
		private readonly TabelViewModel _value;
		private readonly TabelViewModel _prevValue;
		private readonly CResOP _resOP;

		public string Name { get; }

		public void Execute()
		{
			_model.CurrentResOp = _resOP;
			_model.SaveTabel(_value);
		}
		public void UnExecute()
		{
			_model.CurrentResOp = _resOP;
			_model.SaveTabel(_prevValue);
		}
	}
}