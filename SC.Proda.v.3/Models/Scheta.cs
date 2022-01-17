using am.BL;
using System;
using System.Data;

namespace SC.Proda.Models
{
	public class CSchet
	{
		string _nomer;
		public int ID { get; set; }
		public string Nomer
		{
			get => _nomer;
			set
			{
				_nomer = value;
				string dc = DateTime.Now.ToString("yyyyMMdd");
				if (DateCreate.Year >= 2018) dc = DateCreate.ToString("yyyyMMdd");

				ID = G._I(
						G.db_select(
							$@"select ID from SchetaProda 
                                where Nomer = '{_nomer}'
									and year(DataCreate) = year('{dc}')"));
				IsAlreadyLoaded = ID > 0;
			}
		}
		public bool IsAlreadyLoaded { get; set; }
		public double Summa { get; set; }
		public double Штраф { get; set; }
		public DateTime DateCreate { get; set; }
		public DateTime DatePayTo { get; set; }
		public CProject Project { get; set; } = new CProject();
		public CBuyer Buyer { get; set; } = new CBuyer();
		public CDetail Detail { get; set; } = new CDetail();
		public CStDoho StDoho { get; set; } = new CStDoho();
		public CFirma Firma { get; set; } = new CFirma();
		public COplatas Oplatas { get; set; } = new COplatas(0);
		public CSchetLines Lines { get; set; }
		public bool Shipped { get; set; }
		public bool IsDeleted { get; set; }
		public string Comment { get; set; }
		public string User { get; set; }
		public CSchet(int id = 0)
		{
			ID = id;
			Reload();
		}
		public CSchet(DateTime dc)
		{
			DateCreate = dc;
		}
		public CSchet(string nomer)
		{
			DataTable dt = G.db_select("select ID from SchetaProda where Nomer = '{1}'", nomer);
			ID = G._I(dt);
			Reload();
		}
		public void Save()
		{
			string sql = "SaveSchetProda {1}, '{2}', {3}, {4}, '{5}', '{6}', {7}, {8}, {9}, {10}, {11}, {12}, '{13}', '{14}', {15}";
			DataTable dt = G.db_select(sql, ID, Nomer, Summa.ToString().Replace(',', '.'), Штраф.ToString().Replace(',', '.'),
					DateCreate.ToString("yyyyMMdd"), DatePayTo.ToString("yyyyMMdd"),
					Project.ID, Buyer.ID, Detail.ID, StDoho.ID, Firma.ID, Shipped ? 1 : 0,
					Comment, Environment.UserName, IsDeleted ? 1 : 0
				);
			ID = G._I(dt);
			Reload();
		}
		public void Update()
		{

		}
		public void Reload()
		{
			string sql = @"select * from SchetaProda where ID = {1}";
			DataTable dt = G.db_select(sql, ID);
			foreach (DataRow r in dt.Rows)
			{
				ID = G._I(r["ID"]);

				DateCreate = G._D(r["DataCreate"]);
				_nomer = G._S(r["Nomer"]);

				Summa = double.Parse(G._S(r["Summa"]));
				Штраф = double.Parse(G._S(r["Penalty"]));

				Firma = new CFirma(G._I(r["Firma_ID"]));

				Project = new CProject(G._I(r["Project_ID"]));
				Buyer = new CBuyer(G._I(r["Buyer_ID"]));
				Detail = new CDetail(G._I(r["Detail_ID"]));
				StDoho = new CStDoho(G._I(r["StDoho_ID"]));

				Comment = G._S(r["Comment"]);

				DatePayTo = G._D(r["DataPayTo"]);

				Oplatas = new COplatas(ID);
				Shipped = G._B(r["IsShipped"]);
				IsDeleted = G._B(r["IsDeleted"]);

				User = G._S(r["User"]);

				Lines = new CSchetLines(ID);
			}
		}
		public void Delete()
		{
			G.db_exec("update SchetaProda set IsDeleted = 1, [User] = '{2}', dtu = getdate() where ID = {1}", ID, Environment.UserName);
			IsDeleted = true;
		}

		public void Pay()
		{
			G.db_exec(@"
                delete OplataProda where Schet_ID = {1}
                insert OplataProda(Schet_ID, Summa, Data, [User]) 
                values({1}, '{2}', '{3}', '{4}')", ID, (Summa - Штраф).ToString().Replace(',', '.'),
				DateCreate.ToString("yyyyMMdd"),
				Environment.UserName
			);
			G.db_exec("update SchetaProda set Oplata = '{1}', dtu = getdate(), [User] = '{3}' where ID = {2}",
				(Summa - Штраф).ToString().Replace(',', '.'), ID, Environment.UserName);
		}
		public override string ToString() => $"№ {Nomer} от {DateCreate:dd.MM.yyyy}";
	}

	public class CSchetLines
	{
		private readonly int Schet_ID = 0;
		public CSchetLines(int schet_ID)
		{
			Schet_ID = schet_ID;
		}
		public void Add(CSchetLine l)
		{
			G.db_exec(@"
                    insert SchetProdaLine(Schet_ID, Object_ID, Service_ID, Summa, Penalty) 
                        values({1}, {2}, {3}, {4}, {5})
            ",
			Schet_ID, l.Object.ID, l.Service_ID,
			l.Summa.ToString().Replace(',', '.'), l.Штраф.ToString().Replace(',', '.'));
		}
		public void DeleteAll()
		{
			if (Schet_ID > 0)
				G.db_exec($"delete SchetProdaLine where Schet_ID = {Schet_ID}");
		}

		public DataTable dt
		{
			get
			{
				string sql = @"
                    select o.ID, l.Summa [Сумма], l.Penalty [Штраф], s.Name [Услуга], o.Name [Объект], o.Address [Адрес] 
                    from SchetProdaLine l 
                    left outer join Object o on l.Object_ID = o.ID
                    left outer join DetailProda s on s.ID = l.Service_ID 
                    where Schet_ID = {1}
                ";
				DataTable dt = G.db_select(sql, Schet_ID);
				return dt;
			}
		}
	}
	public class CSchetLine
	{
		public double Summa { get; set; }
		public CObject Object { get; set; }
		public int Service_ID { get; set; }
		public double Штраф { get; set; }
		public CSchetLine()
		{

		}
	}
}
