using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using am.BL;

namespace SwissClean.Model
{
    public class CProject
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public CProject(int id)
        {
            DataTable dt = G.db_select("select * from Project where ID = {1}", id);
            ID = G._I(dt, "ID");
            Name = G._S(dt, "Name");
        }
        public CProject(int id, string name)
        {
            ID = id; Name = name;
        }

        public void Save()
        {
            if(ID > 0)
                G.db_exec("update Project set Name = '{1}' where ID = {2}", Name, ID);
            else
                ID = G._I(G.db_select("insert Project(Name) values('{1}') select @@IDENTITY", Name));
        }

        public void Delete()
        {
            G.db_exec("delete Project where ID = {1}", ID);
        }
    }

    public class CProjects : List<CProject>
    {
        public DataTable dt;
        public CProjects()
        {
            Update();
        }
        public void Update()
        {
            dt = G.db_select("select * from Project");
            foreach (DataRow r in dt.Rows)
            {
                int id = G._I(r["ID"]);
                string name = G._S(r["Name"]);

                Add(new CProject(id, name));
            }
        }
    }
}
