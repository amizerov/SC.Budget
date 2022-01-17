using DevExpress.UserSkins;
using SC.Common.Model;
using SC.Common.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SC.Budget
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			BonusSkins.Register();

			new Task(KillAboutDevExpressForm).Start();

			var user = CUser.GetAutoLoginPass();
			if (!user.IsRememberLogin ||
				!user.IsAutoLoginOnStart ||
				!user.TryLogin())
			{
				using (var form = new FrmLogin(user))
				{
					if (form.ShowDialog() != DialogResult.OK) return;
				}
			}

			Application.Run(new Views.FrmMain());
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
	}
}
