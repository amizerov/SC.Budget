using SC.Common.Dal;
using SwissClean.Ioc;
using SwissClean.MVP.MainView;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToDB;
using SC.Common.Model;

namespace SwissClean
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			am.DB.DBManager.Instance.Init(DbContext.GetConnectionString());
			
			var resolver = IocContainerBuilder.Build();

			new Task(KillAboutDevExpressForm).Start();

			//UpdatePositions();

			var model = resolver.Resolve<MainModel>();
			var view = new MainView();
			new MainPresenter(model, view);

			if ((args?.Any() ?? false) && int.TryParse(args[0], out var id))
			{
				var loginModel = model.LoginModel;
				loginModel.Login(id);
			}

			Application.Run(view);
		}

		private static void KillAboutDevExpressForm()
		{
			var start = DateTime.Now;
			while ((DateTime.Now - start).TotalSeconds < 10)
			{
				System.Threading.Thread.Sleep(500);
				var activeWindows = Application.OpenForms;
				foreach (Form form in activeWindows)
				{
					if (form.Name == "AboutForm12")
					{
						form.Invoke(new Action(() => form.Close()));
						return;
					}
				}
			}
		}

		private static void UpdatePositions()
		{
			using (var db = new DbContext())
			{
				var positions = db.GetTable<CPositionDto>().ToArray();
				var oklads = db.GetTable<COkladDto>().ToArray();
				var resOps = db.GetTable<CResOPDto>().OrderByDescending(r => r.Month).ToArray();

				foreach (var resOp in resOps)
				{
					var pos = positions.FirstOrDefault(p => p.ID == resOp.Position_ID);
					var oklad = oklads.FirstOrDefault(o => o.Position_ID == pos?.ID);
					resOp.Position = pos?.Name;
					resOp.Salary = oklad?.Summa ?? 0;

					db.GetTable<CResOPDto>()
						.Where(r => r.ID == resOp.ID)
						.Set(r => r.Position, resOp.Position)
						.Set(r => r.Salary, resOp.Salary)
						.Update();
				}
			}
		}
	}
}
