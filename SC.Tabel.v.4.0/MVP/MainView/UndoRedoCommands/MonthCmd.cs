using SwissClean.Services.UndoRedo;
using System;

namespace SwissClean.MVP.MainView.UndoRedoCommands
{
	public class MonthCmd : ICommand
	{
		public MonthCmd(MainModel model, DateTime value)
		{
			_model = model;
			_value = value;
			_prevValue = _model.Month;
		}

		private readonly MainModel _model;
		private readonly DateTime _value;
		private readonly DateTime _prevValue;

		public string Name => "Изменение месяца";

		public void Execute()
		{
			_model.ChangeMonth(_value);
		}
		public void UnExecute()
		{
			_model.ChangeMonth(_prevValue);
		}
	}
}