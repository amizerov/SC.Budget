using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using LinqToDB;
using LinqToDB.Data;

namespace SC.Common.Views
{
	public partial class FrmNotes : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		private readonly Modules _module;
		private CNote[] _notes;
		private string _password;
		public FrmNotes(Modules module)
		{
			_module = module;
			try
			{
				InitializeComponent();
				LayoutSaver.Restore(this);

				var user = ApplicationUser.User;
				ribpgCrypt.Visible = user?.Role == Role.Director;
				UpdateData();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void UpdateData()
		{
			var user = ApplicationUser.User;
			var userId = user?.ID ?? -1;

			using (var db = new DbContext())
			{
				var notesDto = db.GetTable<CNoteDto>()
					.Where(n => n.Module == _module)
					.Where(n => n.User_ID == userId)
					.OrderByDescending(n => n.Date)
					.ToArray();
				_notes = notesDto.Select(MapperService.Map<CNote>).ToArray();
				if (_password.NoEmpty())
				{
					var cryptor = new CryptorService(_password);
					try
					{
						_notes.ForEach(n => n.DecryptedContent = cryptor.Decrypt(n.Content));
						SetEnabled(true);
					}
					catch (FormatException)
					{
						MessageService.ShowError("При расшифровке произошла ошибка.\n" +
												 "Убедитесь, что содержимое было предварительно зашифровано паролем и повторите попытку");
						SetEnabled(false);
					}
					catch (CryptographicException)
					{
						MessageService.ShowError("Не удалось расшифровать текст");
						_notes.ForEach(n => n.DecryptedContent = n.Content);
						SetEnabled(false);
					}
				}
				else
				{
					_notes.ForEach(n => n.DecryptedContent = n.Content);
					SetEnabled(user?.Role != Role.Director);
				}
				gcNotes.DataSource = _notes;
			}
		}

		private void SetEnabled(bool enabled)
		{
			gvNotes.OptionsBehavior.Editable =
			btAdd.Enabled =
			btEdit.Enabled = enabled;
		}
		private void FrmNotes_FormClosed(object sender, FormClosedEventArgs e)
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

		private void gvNotes_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			try
			{
				if (!(gvNotes.GetFocusedRow() is CNote note)) return;
				if (e.Column == colDecryptedContent)
				{
					if (_password.NoEmpty())
					{
						var cryptor = new CryptorService(_password);
						note.Content = cryptor.Encrypt(note.DecryptedContent);
					}
				}

				var noteDto = MapperService.Map<CNoteDto>(note);
				using (var db = new DbContext())
				{
					db.Update(noteDto);
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void FrmNotes_Shown(object sender, EventArgs e)
		{
			var user = ApplicationUser.User;
			if (user?.Role == Role.Director)
			{
				btInputPassword_ItemClick(this, null);
			}
		}

		private void btAdd_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var form = new FrmNewNote(_module, _password))
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						UpdateData();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btEdit_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (!(gvNotes.GetFocusedRow() is CNote note)) return;
				using (var form = new FrmNewNote(_module, _password, note))
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						UpdateData();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (!(gvNotes.GetFocusedRow() is CNote note)) return;

				var content = note.Content.Length <= 170 ? note.DecryptedContent
					: $"{note.DecryptedContent.Substring(0, 170)}...";
				var question = $"Заметка '{content}' будет безвозвратно удалена.\n\n" +
							   "Продолжить?";
				if (MessageService.ShowQuestion(question) == DialogResult.Yes)
				{
					var noteDto = MapperService.Map<CNoteDto>(note);
					using (var db = new DbContext())
					{
						db.Delete(noteDto);
					}
					UpdateData();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btInputPassword_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				using (var form = new FrmPassword())
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						_password = form.Password;
						UpdateData();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btChangePassword_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				var encrypted = _notes.FirstOrDefault()?.Content ?? "";

				using (var form = new FrmChangeEncryptPassword(encrypted))
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						if (form.OldPassword.NoEmpty())
						{
							var oldCryptor = new CryptorService(form.OldPassword);
							_notes.ForEach(n => n.DecryptedContent = oldCryptor.Decrypt(n.Content));
						}
						var newCryptor = new CryptorService(form.NewPassword);
						using (var db = new DbContext())
						{
							_notes.ForEach(note =>
							{
								note.Content = newCryptor.Encrypt(note.DecryptedContent);
								var noteDto = MapperService.Map<CNoteDto>(note);
								db.Update(noteDto);
							});
						}
						Update();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}