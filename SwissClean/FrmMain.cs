using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using am.BL;

namespace SwissClean
{
    public partial class FrmMain : Form
    {
        int User_ID = 0;
        string Login = "Не задан";
        bool Editing = false;

        public FrmMain(Model.CUser u)
        {
            User_ID = u.ID;
            Login = u.Login;

            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            /*FrmLogin fl = new FrmLogin(); fl.ShowDialog(this); User_ID = fl.User.ID;
            if (User_ID == 0)
            {
                Close();
                Application.Exit();
            }
            Login = G._S(G.db_select("select Login from [User] where ID = {1}", User_ID));*/
            toolStripStatusLabel1.Text += " " + Login;
            
            //timer1.Enabled = true;
            //timer1.Start();

            UpdateData();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int ID = G._I(((DataRowView)gridView1.GetRow(e.RowHandle))[0]);
            string n = e.Column.Name.Replace("col", "");
            if (ID > 0)
            {
                if (n.Contains("Data"))
                {
                    int v = (int)(((decimal)e.Value) * 100);
                    G.db_exec("update test set {1} = {2}/100.0, User_ID = {4} where ID = {3}", n, v, ID, User_ID);
                }
                else if (n.Contains("Proj"))
                {
                    string v = e.Value.ToString();
                    G.db_exec("update test set Project = '{1}', User_ID = {3} where ID = {2}", v, ID, User_ID);
                }
            }
            else if(ID == 0)
            {
                if (n.Contains("Proj"))
                {
                    string v = e.Value.ToString();
                    G.db_exec("insert test(Project, User_ID) values('{1}', {2})", v, User_ID);
                }
            }
            UpdateData();
        }

        void UpdateData()
        {
            int r = -1;
            if(gridView1.SelectedRowsCount > 0)
                r = gridView1.GetSelectedRows()[0];

            string sql = @"select t.ID, Project, Data1, Data2, Login 
                           from Test t join [User] u on u.ID = t.User_ID 
                           order by t.dtc";
            gridControl1.DataSource = G.db_select(sql);
            gridView1.Columns[0].Visible = false;

            if(r > 0) gridView1.FocusedRowHandle = r;
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) UpdateData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!Editing) UpdateData();
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            Editing = true;
        }

        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            Editing = false;
        }
    }
}
