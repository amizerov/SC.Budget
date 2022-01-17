using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwissClean
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            am.DB.DBManager.Instance.Init(".", "SwissClean", "scuser", "!QAZ1qaz");

            Application.Run(new FrmLogin());
        }
    }
}
