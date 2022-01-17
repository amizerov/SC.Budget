using am.BL;
using DevExpress.XtraSplashScreen;
using SC.Common.Model;
using SC.Proda.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using COplata = SC.Proda.Models.COplata;
using CSchet = SC.Proda.Models.CSchet;

namespace SC.Proda.Views
{
	public partial class FrmEditSchet : DevExpress.XtraEditors.XtraForm
	{
		private readonly CSchet _schet;
		public FrmEditSchet(CSchet schet = null)
		{
			try
			{
				InitializeComponent();

				_schet = schet ?? new CSchet();

				Tools.COM1C.Completed += OnCompletedWorkWith1C;

				Reload();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void Reload()
		{
			try
			{
				cbProject.Properties.Items.AddRange(new CProjects());
				cbSupplier.Properties.Items.AddRange(new CBuyers());

				cbServices.Properties.DataSource = new CDetails();
				cbServices.Properties.ValueMember = "Name";

				cbStDoho.Properties.Items.AddRange(new CStDohos());
				cbFirma.Properties.Items.AddRange(new CFirmas());
				cbFirma.Text = "Свисс Клин ООО";

				if (_schet.ID > 0)
				{
					Text = "Изменение счета";

					btnShipped.Checked = _schet.Shipped;
					btnShipped.Text = _schet.Shipped ? "Отгружено" : "Отгрузить";
					btnShipped.Enabled = !btnShipped.Checked;

					txtNomer.Text = _schet.Nomer;
					txtNomer.ReadOnly = true;
					txtSumma.Text = _schet.Summa + "";
					txtPenalty.Text = _schet.Штраф + "";
					deDateCr.DateTime = _schet.DateCreate;
					deDateOp.DateTime = _schet.DatePayTo;

					cbProject.Text = _schet.Project.Name;
					cbSupplier.Text = _schet.Buyer.Name;
					//cbService.Text = Schet.Detail.Name;
					cbServices.EditValue = _schet.Detail.Name;
					cbStDoho.Text = _schet.StDoho.Name;
					cbFirma.Text = _schet.Firma.Name;

					UpdateOplatas();
					/*btnPaied.Checked = Schet.Summa == Schet.Oplatas.Summa;
						btnPaied.Text = btnPaied.Checked ? "Оплачено" : "Оплатить";
						btnPaied.Enabled = !btnPaied.Checked;*/

					memComment.Text = _schet.Comment;

					gridControl1.Focus();
				}
				else
				{
					txtSumma.Text = "0,00";
					txtPenalty.Text = "0,00";
					deDateCr.DateTime = DateTime.Now;
					deDateOp.DateTime = DateTime.Now.AddMonths(1);
					btnDeleteSchet.Visible = false;
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				_schet.DateCreate = deDateCr.DateTime;
				_schet.Nomer = txtNomer.Text; //Если по № сч. и по дате найдет ID, то обновит

				string s = txtSumma.Text, p = txtPenalty.Text;
				s = s.Substring(0, s.Length - 2);
				p = p.Substring(0, p.Length - 2);

				_schet.Summa = double.Parse(s);
				_schet.Штраф = double.Parse(p);

				_schet.DatePayTo = deDateOp.DateTime;

				_schet.Project.Change(cbProject.Text);
				_schet.Buyer.Change(cbSupplier.Text);
				_schet.Detail.Change(cbServices.EditValue + "");
				_schet.StDoho.Change(cbStDoho.Text);
				_schet.Firma.Change(cbFirma.Text);

				_schet.Comment = memComment.Text;

				_schet.Save();

				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			try
			{
				int id = G._I(((DataRowView)gridView1.GetRow(e.RowHandle))[0]);
				string n = e.Column.Name.Replace("col", "");
				string v = e.Value.ToString();

				COplata o = null;
				if (id > 0)
				{
					o = new COplata(_schet.ID, id);

					if (n == "Сумма") o.Сумма = double.Parse(v);
					if (n == "Дата") o.Дата = G._D(v);
				}
				else if (n == "Сумма")
					o = new COplata(_schet.ID) { Сумма = double.Parse(v), Дата = DateTime.Now };
				else if (n == "Дата")
					o = new COplata(_schet.ID) { Сумма = 0, Дата = G._D(v) };

				if (o != null) o.Save();

				UpdateOplatas();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		void UpdateOplatas()
		{
			try
			{
				int r = -1;
				if (gridView1.SelectedRowsCount > 0) r = gridView1.GetSelectedRows()[0];

				gridControl1.DataSource = _schet.Oplatas.dt;
				gridView1.Columns[0].Visible = false;
				gridView1.Columns[1].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
				gridView1.Columns[2].DisplayFormat.FormatString = "{0:C}";
				gridView1.Columns[2].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
				gridView1.Columns[2].DisplayFormat.FormatString = "yyyy-MM-dd";

				txtOplata.Text = _schet.Oplatas.Summa + "";

				if (r > 0) gridView1.FocusedRowHandle = r;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void gridControl1_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Delete)
				{
					int r = gridView1.FocusedRowHandle;
					int id = G._I(((DataRowView)gridView1.GetRow(r))[0]);

					if (MessageBox.Show(this, "Хотите удалить оплату?", "Удаление оплаты",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						_schet.Oplatas.Delete(id);
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
				if (MessageBox.Show(this,
			"Хотите удалить этот счет?\nЕсли вы удалите счет, оплаты тоже будут удалены.",
			"Удаление счета",
			MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					_schet.Delete();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void BtnShipped_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				_schet.Shipped = btnShipped.Checked;
				btnShipped.Text = _schet.Shipped ? "Отгружено" : "Отгрузить";
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void CbServices_QueryPopUp(object sender, CancelEventArgs e)
		{
			try
			{
				searchLookUpEdit1View.Columns[0].Visible = false;
				searchLookUpEdit1View.Columns[1].Caption = "Услуга";
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void TxtNomer_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				Tools.COM1C.LoadSingleSchet(_schet);

				memComment.Text = _schet.Comment;
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void BtnUpdateSchetFrom1C_Click(object sender, EventArgs e)
		{
			try
			{
				SplashScreenManager.ShowForm(this, typeof(FrmLoadingFrom1C));

				Thread p = new Thread(() => Tools.COM1C.LoadSingleSchet(_schet));
				p.Start();
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void OnCompletedWorkWith1C(string res)
		{
			try
			{
				if (res == "LoadSingleSchet")
				{
					if (!IsHandleCreated || IsDisposed || Disposing) return;
					Invoke(new Action(() =>
					{
						MessageBox.Show(Tools.COM1C.Otchet, "Обновление счета завершено!", MessageBoxButtons.OK, MessageBoxIcon.Information);
						Reload();

						try
						{
							SplashScreenManager.CloseForm(false, 0, this);
						}
						catch { }
					}));
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}