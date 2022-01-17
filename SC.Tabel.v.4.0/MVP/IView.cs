using System.Windows.Forms;

namespace SwissClean.MVP
{
	public interface IView : IWin32Window
	{
		string Text { get; set; }
		void Show();
		DialogResult ShowDialog();
		void Hide();
		void Close();

		void ShowError(string error);
	}
}
