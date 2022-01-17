using am.BL;
using System.Data;

namespace SwissClean.Model
{
    public class CUser
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public CRole Role { get; set; }

        public CUser(string login, string pass)
        {
            string sql = @"
                    select u.ID, Role_ID
                    from [User] u join Role r on r.ID = u.Role_ID 
                    where Login='{1}' and Pass='{2}'";

            DataTable dt = G.db_select(sql, login, pass);
            ID = G._I(dt, "ID");
            Role = new CRole(G._I(dt, "Role_ID"));

        }
    }

    public class CRole
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public CRole(int id)
        {
            DataTable dt = G.db_select("select * from Role where ID = {1}", id);
            ID = G._I(dt, "ID");
            Name = G._S(dt, "Name");
        }
    }
}
