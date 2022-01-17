using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SC.Common.Model;

namespace SC.Common.Views
{
	public partial class FrmMessage : XtraForm
	{
		[DllImport("Kernel32.dll")]
		public static extern IntPtr LoadLibrary(string libName);

		[DllImport("User32.dll")]
		public static extern IntPtr LoadIcon(IntPtr libHandle, int lpIconName);

		public FrmMessage(string message,
			MessageBoxButtons buttons = MessageBoxButtons.OK,
			MessageBoxIcon icon = MessageBoxIcon.Information)
		{
			try
			{
				InitializeComponent();

				Text = Application.ProductName;

				txtMessage.Lines = message.Split('\n');

				LoadImage(icon);

				switch (buttons)
				{
					default:
						btOk.Visible = true;
						AcceptButton = btOk;
						break;
					case MessageBoxButtons.OKCancel:
						btOk.Visible = true;
						btCancel.Visible = true;
						AcceptButton = btOk;
						break;
					case MessageBoxButtons.YesNo:
						btYes.Visible = true;
						btNo.Visible = true;
						AcceptButton = btYes;
						break;
					case MessageBoxButtons.YesNoCancel:
						btYes.Visible = true;
						btNo.Visible = true;
						btCancel.Visible = true;
						AcceptButton = btYes;
						break;
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void LoadImage(MessageBoxIcon icon)
		{
			var lib = LoadLibrary("imageres.dll");
			IntPtr ico;
			switch (icon)
			{
				case MessageBoxIcon.Error: ico = LoadIcon(lib, 98); break;
				case MessageBoxIcon.Warning: ico = LoadIcon(lib, 84); break;
				default: ico = LoadIcon(lib, 81); break;
			}
			var pic = Icon.FromHandle(ico);
			pbIcon.Image = pic.ToBitmap();
		}
	}
}