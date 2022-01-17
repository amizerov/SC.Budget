using LinqToDB;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Windows.Forms;

namespace SC.Common.Views
{
	public partial class FrmNewNote : DevExpress.XtraEditors.XtraForm
	{
		private readonly Modules _module;
		private CNote _note;
		private readonly string _pass;

		public FrmNewNote(Modules module, string pass, CNote note = null)
		{
			_module = module;
			_pass = pass;
			_note = note;
			try
			{
				InitializeComponent();
				LayoutSaver.Restore(this);

				Text = _note == null ? "Новая заметка" : "Редактировать заметку";

				deDate.DateTime = _note?.Date ?? DateTime.Now;
				txtContent.Text = _note?.DecryptedContent;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtContent.Text.IsEmpty())
				{
					MessageService.ShowError("Не заполнено поле 'Содержимое'");
					return;
				}
				using (var db = new DbContext())
				{
					if (_note == null)
					{
						var user = ApplicationUser.User;
						var noteDto = new CNoteDto
						{
							Date = deDate.DateTime,
							Module = _module,
							User_ID = user.ID,
						};
						noteDto.SetContent(txtContent.Text, _pass);
						db.Insert(noteDto);
					}
					else
					{
						_note.Date = deDate.DateTime;
						_note.SetContent(txtContent.Text, _pass);
						_note.dtu = DateTime.Now;
						db.Update(_note);
					}
				}
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void FrmNewNote_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				LayoutSaver.Save(this);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}