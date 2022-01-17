using DevExpress.XtraWaitForm;
using SC.Proda.Tools;
using System;

namespace SC.Proda.Views
{
	public partial class FrmLoadingFrom1C : WaitForm
	{
		public FrmLoadingFrom1C()
		{
			InitializeComponent();

			COM1C.Progress += (message) =>
			{
				if (!IsHandleCreated || IsDisposed || Disposing) return;
				Invoke(new Action(() =>
				{
					lbProgress.Text = message;
				}));
			};
		}
	}
}
