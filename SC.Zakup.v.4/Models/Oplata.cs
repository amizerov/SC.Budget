using am.BL;
using System;
using System.Data;

namespace SC.Zakup.Models
{
	public class COplata
	{
		public int ID;
		public int Schet_ID;
		public DateTime Дата { get; set; }
		public double Сумма { get; set; }
		public COplata(int sid)
		{
			Schet_ID = sid;
		}
		public COplata(int sid, int id)
		{
			Schet_ID = sid;
			ID = id;
			DataTable dt = G.db_select("select ID, Summa [Сумма], Data [Дата] from Oplata where ID = {1}", ID);
			foreach (DataRow r in dt.Rows)
			{
				Дата = G._D(r[2]);
				Сумма = double.Parse(r[1] + "");
			}
		}
		public void Save()
		{
			if (ID > 0)
			{
				G.db_exec("update Oplata set Summa = {1}, Data = '{2}' where ID = {3}",
					Сумма.ToString().Replace(',', '.'), Дата.ToString("yyyyMMdd"), ID);
			}
			else
			{
				ID = G._I(G.db_select(
					@"insert Oplata(Summa, Data, Schet_ID) values({1}, '{2}', {3})
                            select @@IDENTITY",
					Сумма.ToString().Replace(',', '.'), Дата.ToString("yyyyMMdd"), Schet_ID));
			}
			DataTable dt = G.db_select("select sum(Summa) from Oplata where Schet_ID = {1}", Schet_ID);
			string sumo = G._S(dt).Replace(',', '.');
			G.db_exec("update Scheta set Oplata = {1} where ID = {2}", sumo, Schet_ID);
		}
	}

	public class COplatas
	{
		int Schet_ID = 0;
		public double Summa
		{
			get
			{
				string s = G._S(G.db_select("select sum(Summa) from Oplata where Schet_ID = {1}", Schet_ID));
				if (s.Length > 0)
					return double.Parse(s);

				return 0;
			}
		}
		public DataTable dt
		{
			get
			{
				return G.db_select("select ID, Summa [Сумма], Data [Дата] from Oplata where Schet_ID = {1}", Schet_ID);
			}
		}
		public static DataTable dtAll
		{
			get
			{
				return G.db_select(@"
                    select o.ID, Schet_ID, o.Summa [Сумма], o.Data [Дата], s.Nomer [№ Счета] 
                    from Oplata o join Scheta s on s.ID = o.Schet_ID order by [Дата] desc");
			}
		}
		public COplatas(int sid)
		{
			Schet_ID = sid;
		}
		public void Delete(int oid)
		{
			G.db_exec("delete Oplata where ID = {1}", oid);
			DataTable dt = G.db_select(@"
                declare @s decimal(18, 2)
                select @s = sum(Summa) from Oplata where Schet_ID = {1}
                select IsNull(@s, 0) s
                ", Schet_ID);
			string sumo = G._S(dt, "s").Replace(',', '.');
			G.db_exec("update Scheta set Oplata = {1}, dtu = getdate() where ID = {2}", sumo.Replace(',', '.'), Schet_ID);
		}
	}
}
