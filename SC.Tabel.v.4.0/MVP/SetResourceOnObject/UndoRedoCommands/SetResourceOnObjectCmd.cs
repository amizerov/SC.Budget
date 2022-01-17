using SwissClean.Dal;
using SwissClean.Dal.Dto;
using SwissClean.MVP.MainView;
using SwissClean.Services.UndoRedo;

namespace SwissClean.MVP.SetResourceOnObject.UndoRedoCommands
{
	public class SetResourceOnObjectCmd : ICommand
	{
		public SetResourceOnObjectCmd(MainModel model, CResOP resOp, string resourceName)
		{
			_model = model;
			_resOp = resOp;
			Name = $"Назначение сотрудника '{resourceName}'";
		}

		private readonly IDataAccessService _db = new DataAccessService();

		private readonly MainModel _model;
		private readonly CResOP _resOp;

		public string Name { get; }

		public void Execute()
		{
			_db.SaveResOp(_resOp);
			_model.Reload();
		}
		public void UnExecute()
		{
			_db.DeleteResOp(_resOp);
			_model.Reload();
		}
	}
}