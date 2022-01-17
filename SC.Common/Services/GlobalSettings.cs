using System;
using SC.Common.Dal;
using System.ComponentModel;
using System.IO;

namespace SC.Common.Services
{
	[Obsolete]
	public class GlobalSettings
	{
		private static readonly IRepository<GlobalSettings> Repos;

		private static GlobalSettings _instance;
		private static readonly object LockObject = new object();

		static GlobalSettings()
		{
			var file = Path.Combine("C:\\SCAS", "GlobalSettings.xml");
			Repos = new XmlRepository<GlobalSettings>(file);
			Value = Repos.Load();
		}

		[DefaultValue(15)] 
		public int DaysEditableNaklads { get; set; } = 15;


		public static void Save() => Repos.Save(Value);

		private static GlobalSettings Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (LockObject)
					{
						_instance = new GlobalSettings();
					}
				}
				return _instance;
			}
		}
		private GlobalSettings _value;
		public static GlobalSettings Value
		{
			get => Instance._value;
			set => Instance._value = value;
		}
	}
}
