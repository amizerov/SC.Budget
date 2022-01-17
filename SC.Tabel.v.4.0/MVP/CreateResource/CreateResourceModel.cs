using SC.Common.Model;
using SC.Common.Services;
using SwissClean.Dal;
using System;

namespace SwissClean.MVP.CreateResource
{
	public class CreateResourceModel
	{
		private readonly IDataAccessService _db;

		public CreateResourceModel(IDataAccessService dataAccessService)
		{
			_db = dataAccessService;
		}

		public event EventHandler<string> Error;
		public event EventHandler Changed;

		public void CreateResource(ResOPViewModel vm)
		{
			try
			{
				var resource = MapperService.Map<CResourceDto>(vm);

				_db.SaveResource(resource);
				Changed?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex) { Error?.Invoke(this, ex.ToString()); }
		}
		public void DeleteResource(ResOPViewModel vm)
		{
			try
			{
				var resource = MapperService.Map<CResourceDto>(vm);

				if (_db.DeleteResource(resource)) Changed?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex) { Error?.Invoke(this, ex.ToString()); }
		}
	}
}
