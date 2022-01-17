using SwissClean.Dal.Dto;
using SwissClean.MVP.MainView;
using System.Collections.Generic;

namespace SwissClean.Services.UndoRedo.Commands
{
	public class TabelsCmd : ICommand
	{
		public TabelsCmd(MainModel model, List<CTabel> value)
		{
			_model = model;
			_value = value;
			_prevValue = _model.CurrentTabels;
			Name = $"Изменение дней выхода для сотрудника '{_model.CurrentResourceName}'";
			_resOP = _model.CurrentResOp;
		}

		private readonly MainModel _model;
		private readonly List<CTabel> _value;
		private readonly List<CTabel> _prevValue;
		private readonly CResOP _resOP;

		public string Name { get; }

		public void Execute()
		{
			_model.CurrentResOp = _resOP;
			_model.SaveTabels(_value);
		}
		public void UnExecute()
		{
			_model.CurrentResOp = _resOP;
			_model.SaveTabels(_prevValue);
		}
	}
}