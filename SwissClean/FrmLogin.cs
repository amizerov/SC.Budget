using System;
using am.BL;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;

namespace SwissClean
{
    public partial class FrmLogin : XtraForm
    {
        public Model.CUser User;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CheckAccount();
        }

        private void CheckAccount()
        {
            string login = tbLogin.Text.Trim();
            string pass = tbPass.Text.Trim();
            User = new Model.CUser(login,  pass);

            if (User.ID > 0)
            {
                switch (User.Role.ID) {
                    case 1:
                        {
                            Hide();
                            Views.FrmAdmin fa = new Views.FrmAdmin(User);
                            fa.ShowDialog();
                            Close();
                            break;
                        }
                    case 2:
                        {
                            Hide();
                            FrmMain fa = new FrmMain(User);
                            fa.ShowDialog();
                            Close();
                            break;
                        }
                }
            }
            else
            {
                labelControl3.Visible = true;
            }
        }

        private void tbPass_KeyUp(object sender, KeyEventArgs e)
        {
            btnOk.Enabled = !string.IsNullOrEmpty(tbLogin.Text) && !string.IsNullOrEmpty(tbPass.Text);
            if (e.KeyCode == Keys.Enter)
            {
                CheckAccount();
            }
        }

        private void tbLogin_KeyUp(object sender, KeyEventArgs e)
        {
            btnOk.Enabled = !string.IsNullOrEmpty(tbLogin.Text) && !string.IsNullOrEmpty(tbPass.Text);
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(tbLogin.Text))
            {
                tbPass.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbSaveLoginAndPass_CheckedChanged(object sender, EventArgs e)
        {
            cbAutoLoginOnStart.Enabled = cbSaveLoginAndPass.Checked;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}