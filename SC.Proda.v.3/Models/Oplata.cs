using am.BL;
using System;
using System.Data;

namespace SC.Proda.Models
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
			DataTable dt = G.db_select("select ID, Summa [Сумма], Data [Дата] from OplataProda where ID = {1}", ID);
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
				G.db_exec("update OplataProda set Summa = {1}, Data = '{2}', [User] = '{4}', dtu = getdate() where ID = {3}",
					Сумма.ToString().Replace(',', '.'), Дата.ToString("yyyyMMdd"), ID, Environment.UserName);
			}
			else
			{
				ID = G._I(G.db_select(
					@"insert OplataProda(Summa, Data, Schet_ID, [User]) values({1}, '{2}', {3}, '{4}')
                            select @@IDENTITY",
					Сумма.ToString().Replace(',', '.'), Дата.ToString("yyyyMMdd"), Schet_ID, Environment.UserName));
			}
			DataTable dt = G.db_select("select sum(Summa) from OplataProda where Schet_ID = {1}", Schet_ID);
			string sumo = G._S(dt).Replace(',', '.');
			G.db_exec("update SchetaProda set Oplata = {1}, [User] = '{3}', dtu = getdate() where ID = {2}", sumo, Schet_ID, Environment.UserName);
		}
	}

	public class COplatas
	{
		int Schet_ID = 0;
		public double Summa
		{
			get
			{
				string s = G._S(G.db_select("select sum(Summa) from OplataProda where Schet_ID = {1}", Schet_ID));
				if (s.Length > 0)
					return double.Parse(s);

				return 0;
			}
		}
		public DataTable dt
		{
			get
			{
				return G.db_select("select ID, Summa [Сумма], Data [Дата] from OplataProda where Schet_ID = {1}", Schet_ID);
			}
		}
		public COplatas(int sid)
		{
			Schet_ID = sid;
		}
		public void Delete(int oid)
		{
			G.db_exec("delete OplataProda where ID = {1}", oid);
			DataTable dt = G.db_select(@"
                declare @s decimal(18, 2)
                select @s = sum(Summa) from OplataProda where Schet_ID = {1}
                select IsNull(@s, 0) s
                ", Schet_ID);
			string sumo = G._S(dt, "s").Replace(',', '.');
			G.db_exec("update SchetaProda set Oplata = {1}, dtu = getdate() where ID = {2}", sumo.Replace(',', '.'), Schet_ID);
		}
	}
}
