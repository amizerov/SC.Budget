using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SwissClean.Model;
using am.BL;
using System.IO;

namespace SwissClean.Views
{
    public partial class FrmAdmin : DevExpress.XtraEditors.XtraForm
    {
        public CUser User;
        public CProject Project;
        public FrmAdmin(CUser u)
        {
            User = u;
            InitializeComponent();
            G.OnError += OnDbError;
        }

        void OnDbError(string msg)
        {
            MessageBox.Show(msg, "Ошибка БД!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            TryGetRibbonLayout();
            UpdateData();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int id = G._I(((DataRowView)gridView1.GetRow(e.RowHandle))[0]);
            string n = e.Column.Name.Replace("col", "");

            CProject p = new CProject(id, e.Value.ToString());
            p.Save();

            UpdateData();
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int id = G._I(((DataRowView)gridView2.GetRow(e.RowHandle))[0]);
            string n = e.Column.Name.Replace("col", "");
            string v = e.Value.ToString();

            CObject o = null;
            if(id > 0)
            {
                o = new CObject(id);

                if (n == "Name") o.Name = v;
                if (n == "City") o.City = v;
                if (n == "Address") o.Address = v;
            }
            else 
                if (n == "Name")
                    o = new CObject(v, Project);


            if(o != null) o.Save();

            UpdateData(Project);
        }

        void UpdateData(CProject p = null)
        {
            int r = -1;
            if (p == null)
            {
                if (gridView1.SelectedRowsCount > 0) r = gridView1.GetSelectedRows()[0];

                gridControl1.DataSource = new CProjects().dt;
                gridView1.Columns["ID"].Visible = false;
                gridView1.Columns["Rukovod_ID"].Visible = false;
                gridView1.Columns["dtc"].Visible = false;

                if (r > 0) gridView1.FocusedRowHandle = r;
            }
            else {
                if (gridView2.SelectedRowsCount > 0) r = gridView2.GetSelectedRows()[0];

                gridControl2.DataSource = new CObjects(p.ID).dt;
                gridView2.Columns["ID"].Visible = false;
                gridView2.Columns["Project_ID"].Visible = false;
                gridView2.Columns["Manager_ID"].Visible = false;
                gridView2.Columns["dtc"].Visible = false;

                if (r > 0) gridView2.FocusedRowHandle = r;
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int h = gridView1.FocusedRowHandle; if (h < 0) return;
            int id = G._I(((DataRowView)gridView1.GetRow(h))[0]);
            Project = new CProject(id);

            UpdateData(Project);
        }

        private void gridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int h = gridView1.FocusedRowHandle; if (h < 0) return;
                int id = G._I(((DataRowView)gridView1.GetRow(h))[0]);
                Project = new CProject(id);
                Project.Delete();

                UpdateData();
            }
        }

        private void gridControl2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int h = gridView2.FocusedRowHandle; if (h < 0) return;
                int id = G._I(((DataRowView)gridView2.GetRow(h))[0]);
                (new CObject(id)).Delete();

                UpdateData(Project);
            }
        }

        void SaveRibbonLayout()
        {
            string f = System.IO.Path.Combine(G.GetCurDir2(), "Ribbon.xml");
            ribbonControl1.SaveLayoutToXml(f);
        }
        void TryGetRibbonLayout()
        {
            string f = Path.Combine(G.GetCurDir2(), "Ribbon.xml");
            if (File.Exists(f))
                ribbonControl1.RestoreLayoutFromXml(f);
        }

        private void FrmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveRibbonLayout(); 
        }
    }
}