using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using LinqToDB;
using LinqToDB.Data;
using SC.Zakup.Properties;
using SC.Zakup.Tools;
using SC.Zakup.Views;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SC.Zakup
{
	public partial class FrmEditSchet : XtraForm
	{
		private CSchet _schet;
		private CSchetDto SchetDto => MapperService.Map<CSchetDto>(_schet);
		public FrmEditSchet(int? schetId = null)
		{
			try
			{
				InitializeComponent();

				LayoutSaver.Restore(this);

				void fill(ComboBoxEdit cb, object[] items) => cb.Properties.Items.AddRange(items);

				using (var db = new DbContext())
				{
					fill(cbProject, db.AllNames<CProjectDto>(p => !p.IsDeleted));
					fill(cbProject, db.AllNames<CProjectDto>(p => !p.IsDeleted));
					fill(cbSupplier, db.AllNames<CSupplierDto>());
					fill(cbDetail, db.AllNames<CDetailDto>(p => p.IsActual ?? false));
					fill(cbStRash, db.AllNames<CStRashDto>());
					fill(cbSCFirma, db.AllNames<CFirmaDto>());
				}

				Reload(schetId);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void Reload(int? schetId)
		{
			if (schetId != null)
			{
				Text = "Изменение счета";

				_schet = CSchet.GetTable(id: schetId)
						.FirstOrDefault(s => s.ID == schetId.Value);

				txtNomer.Text = _schet?.Nomer;
				txtSumma.Text = _schet?.Summa.ToString();
				deDateCr.DateTime = _schet?.DataCreate ?? DateTime.Now;
				deDateOp.DateTime = _schet?.DataPayTo ?? DateTime.Now;

				cbProject.Text = _schet?.ProjectName;
				cbSupplier.Text = _schet?.SupplierName;
				cbDetail.Text = _schet?.DetailName;
				cbStRash.Text = _schet?.StRashName;

				cbSCFirma.Text = _schet?.FirmaName;

				UpdateOplatas();

				memComment.Text = _schet?.Comment;

				gcOplatas.Focus();
			}
			else
			{
				txtSumma.Text = "0,00";
				deDateCr.DateTime = DateTime.Now;
				deDateOp.DateTime = DateTime.Now;

				btAddOplata.Enabled =
				btDeleteOplata.Enabled =
				btnDeleteSchet.Enabled =
				btnUpdateSchetFrom1C.Enabled = false;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				using (var db = new DbContext())
				{

					if (_schet == null) _schet = new CSchet();
					_schet.Nomer = txtNomer.Text;

					_schet.Summa = txtSumma.EditValue.ToDecimal();

					_schet.DataCreate = deDateCr.DateTime;
					_schet.DataPayTo = deDateOp.DateTime;

					_schet.Project_ID = db.GetID<CProjectDto>(cbProject.Text);
					_schet.Supplier_ID = db.GetID<CSupplierDto>(cbSupplier.Text);
					_schet.Detail_ID = db.GetID<CDetailDto>(cbDetail.Text);
					_schet.StRash_ID = db.GetID<CStRashDto>(cbStRash.Text);
					_schet.Firma_ID = db.GetID<CFirmaDto>(cbSCFirma.Text);
					_schet.Comment = memComment.Text;
					_schet.User = Environment.UserName;
					_schet.dtu = DateTime.Now;

					if (_schet.ID > 0) db.Update(SchetDto); //InsertOrReplace не работает
					else db.Insert(SchetDto);

					DialogResult = DialogResult.OK;
					Close();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gvOplatas_CellValueChanged(object sender, CellValueChangedEventArgs e)
		{
			try
			{
				if (!(gvOplatas.GetFocusedRow() is COplataDto oplata)) return;
				using (var db = new DbContext())
				{
					oplata.dtu = DateTime.Now;
					oplata.User = Environment.UserName;
					db.Update(oplata);
					_schet.UpdateOplatas();
					db.Update(SchetDto);
				}
				UpdateOplatas();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void UpdateOplatas()
		{
			try
			{
				using (var db = new DbContext())
				using (new GridViewStateSaver(gvOplatas))
				{
					var schetId = _schet?.ID ?? -1;
					var oplatas = db.GetTable<COplataDto>()
						.Where(o => o.Schet_ID == schetId)
						.Where(o => !o.IsDeleted)
						.ToArray();

					gcOplatas.DataSource = oplatas;
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gcOplatas_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Delete) btDeleteOplata_Click(sender, e);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btDeleteOplata_Click(object sender, EventArgs e)
		{
			try
			{
				if (!(gvOplatas.GetFocusedRow() is COplataDto op)) return;

				var question = $"Хотите удалить оплату на сумму {op.Summa:c2} от {op.Data:dd.MM.yyyy}?";
				if (MessageService.ShowQuestion(question) == DialogResult.Yes)
				{
					using (var db = new DbContext())
					{
						db.GetTable<COplataDto>()
							.Where(o => o.ID == op.ID)
							.Delete();
						_schet.UpdateOplatas();
					}
					UpdateOplatas();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btAddOplata_Click(object sender, EventArgs e)
		{
			try
			{
				using (var form = new FrmNewOplata(_schet.ID))
				{
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						using (var db = new DbContext())
						{
							_schet.UpdateOplatas();
							db.Update(SchetDto);
						}
						UpdateOplatas();
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btnDeleteSchet_Click(object sender, EventArgs e)
		{
			try
			{
				var question = "Вы хотите безвозвратно удалить этот счет из базы данных?\n" +
				"По данной кнопке счет реально удаляется из базы,\n" +
				"оплаты тоже будут удалены.";
				if (MessageService.ShowQuestion(question) == DialogResult.Yes)
				{
					using (var db = new DbContext())
					{
						db.Delete(SchetDto);
					}
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
		private void btnUpdateSchetFrom1C_Click(object sender, EventArgs e)
		{
			try
			{
				COM1C.LoadSingleSchet(_schet);
				if (COM1C.Scheta.Any())
				{
					using (var form = new FrmLoadScheta(COM1C.Scheta))
					{
						if (form.ShowDialog(this) == DialogResult.OK)
						{
							COM1C.LoadSchetaFinish();
							Reload(_schet.ID);
						}
						else
						{
							COM1C.OtchetSingle = "Загрузка отменена пользователем";
						}
					}
				}
				MessageService.ShowMessage(COM1C.OtchetSingle);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void FrmEditSchet_FormClosed(object sender, FormClosedEventArgs e)
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