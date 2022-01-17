using SC.Cash.Views;
using SC.Common.Model;
using SC.Common.Views;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SC.Cash
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

			new Task(KillAboutDevExpressForm).Start();

			if ((args?.Any() ?? false) && int.TryParse(args[0], out var id))
			{
				ApplicationUser.User = CUser.GetById(id);
				Application.Run(new FrmMain());
			}
			else
			{
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

				Application.Run(new FrmMain());
			}
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
