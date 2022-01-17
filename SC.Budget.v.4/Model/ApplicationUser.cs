namespace SC.Budget.Model
{
	public class ApplicationUser
	{
		private static ApplicationUser _instance;
		private static readonly object _lockObject = new object();

		private ApplicationUser() { }

		public static ApplicationUser Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (_lockObject)
					{
						_instance = new ApplicationUser();
					}
				}
				return _instance;
			}
		}

		public CUser User { get; internal set; }
	}
}
