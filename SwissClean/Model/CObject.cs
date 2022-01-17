using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using am.BL;

namespace SwissClean.Model
{
    public class CObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public CProject Project;

        public CObject(){ }

        public CObject(string name, CProject proj)
        {
            Name = name; Project = proj;
        }

        public CObject(int id)
        {
            DataTable dt = G.db_select("select * from Object where ID = {1}", id);
            ID = G._I(dt, "ID");
            Name = G._S(dt, "Name");
            City = G._S(dt, "City");
            Address = G._S(dt, "Address");

            Project = new CProject(G._I(dt, "Project_ID"));
        }

        public void Save()
        {
            if (ID > 0)
                G.db_exec(@"update Object set 
                            Name = '{1}', City = '{2}', Address = '{3}'
                            where ID = {4}", Name, City, Address, ID);
            else
                ID = G._I(G.db_select("insert Object(Name, Project_ID) values('{1}', {2}) select @@IDENTITY", Name, Project.ID));
        }

        internal void Delete()
        {
            G.db_exec("delete Object where ID = {1}", ID);
        }
    }

    public class CObjects : List<CObject>
    {
        public DataTable dt;
        public CProject Project;
        public CObjects(int pid)
        {
            Project = new CProject(pid);
            Update();
        }
        public void Update()
        {
            dt = G.db_select("select * from Object where Project_ID = {1}", Project.ID);
            foreach (DataRow r in dt.Rows)
            {
                int id = G._I(r["ID"]);
                string name = G._S(r["Name"]);
                string city = G._S(r["City"]);
                string addr = G._S(r["Address"]);

                Add(new CObject() {
                    ID = id, Name = name, Address = addr, City = city, Project =this.Project
                });
            }
        }
    }

}
