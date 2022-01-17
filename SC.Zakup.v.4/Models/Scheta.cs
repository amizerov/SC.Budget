using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using am.BL;
using LinqToDB.Mapping;
using SC.Zakup.Models;

namespace SC.Zakup.Models
{
	[Table("SchetZakupLine")]
	public class CSchetLine
	{
		[DisplayName("Номенклатура")]
		[Column] public string Nomenklatura { get; set; }

		[DisplayName("Количество")]
		[Column] public int Quantity { get; set; }

		[DisplayName("Цена")]
		[Column] public decimal Price { get; set; }
	}
	public class CSchet
	{
		public int ID { get; set; }
		public string Nomer { get; set; }
		public string NomerInternal { get; set; }
		public double Summa { get; set; }
		public DateTime DateCreate { get; set; }
		public DateTime DatePayTo { get; set; }
		public CProject Project { get; set; } = new CProject();
		public CSupplier Supplier { get; set; } = new CSupplier();
		public CDetail Detail { get; set; } = new CDetail();
		public CStRash StRash { get; set; } = new CStRash();
		public CFirma Firma { get; set; } = new CFirma();
		public COplatas Oplatas { get; set; }
		public string Comment { get; set; }
		public string User { get; set; }
		public bool IsAvance { get; set; }
		public int? AvanceUser_ID { get; set; }
		public List<CSchetLine> Lines { get; set; }
		public CSchet(int id)
		{
			ID = id;
			Update();

			Lines = new List<CSchetLine>();
			DataTable dt = G.db_select("select * from SchetZakupLine where Schet_ID = {1}", ID);
			foreach (DataRow r in dt.Rows)
			{
				CSchetLine l = new CSchetLine() { Nomenklatura = G._S(r["Nomenklatura"]), Price = G._Dec(r["Price"]), Quantity = G._I(r["Quantity"]) };
				Lines.Add(l);
			}
		}
		public void SaveLines()
		{
			G.db_exec($"delete SchetZakupLine where Schet_ID = {ID}");

			foreach (CSchetLine l in Lines)
			{
				G.db_exec(@"
                    insert SchetZakupLine(Schet_ID, Nomenklatura, Quantity, Price)
                    values({1}, '{2}', {3}, {4})
                ",
					ID, l.Nomenklatura, l.Quantity, l.Price.ToString().Replace(',', '.'));
			}
		}
		public void Save()
		{
			string sql = "SaveSchetZakup2 {1}, '{2}', '{3}', {4}, '{5}', '{6}', {7}, {8}, {9}, {10}, {11}, {12}, {13}, '{14}', '{15}'";
			DataTable dt = G.db_select(sql,
					ID, Nomer, NomerInternal, Summa.ToString().Replace(',', '.'),
					DateCreate.ToString("yyyyMMdd"),
					DatePayTo.ToString("yyyyMMdd"),
					Project.ID > 0 ? $"{Project.ID}" : "null", Supplier.ID, 
					Detail.ID > 0 ? $"{Detail.ID}" : "null", StRash.ID > 0 ? $"{StRash.ID}" : "null",
					Firma.ID, IsAvance ? 1 : 0, AvanceUser_ID?.ToString() ?? "null",
					Comment, Environment.UserName
				);
			ID = G._I(dt);
			Update();
		}
		public void Update()
		{
			string sql = @"select * from Scheta where ID = {1}";
			DataTable dt = G.db_select(sql, ID);
			foreach (DataRow r in dt.Rows)
			{
				ID = G._I(r["ID"]);
				Nomer = G._S(r["Nomer"]);
				NomerInternal = G._S(r["NomerInternal"]);
				Summa = double.Parse(G._S(r["Summa"]));

				Project = new CProject(G._I(r["Project_ID"]));
				Supplier = new CSupplier(G._I(r["Supplier_ID"]));
				Detail = new CDetail(G._I(r["Detail_ID"]));
				StRash = new CStRash(G._I(r["StRash_ID"]));
				IsAvance = G._B(r["IsAvance"]);
				Comment = G._S(r["Comment"]);

				Firma = new CFirma(G._I(r["Firma_ID"]));

				DateCreate = G._D(r["DataCreate"]);
				DatePayTo = G._D(r["DataPayTo"]);

				Oplatas = new COplatas(ID);

				User = G._S(r["User"]);
			}
		}
		public void Delete()
		{
			G.db_exec(@"
                insert _Log(src, msg, [User]) 
                values('Delete SchetZakup', '" + Nomer + "/" + Summa + "', '" + Environment.UserName + @"')

                delete Oplata where Schet_ID = {1}
                delete Scheta where ID = {1}", ID);
		}
		public void MarkAsDeleted()
		{
			G.db_exec(@"update Scheta set IsDeleted = 1 where ID = {1}", ID);
		}

		public void Pay()
		{
			DataTable dt = G.db_select($"select sum(Summa) from Oplata where Schet_ID = {ID}");
			double oplacheno = G._Double(dt);
			if (Summa - oplacheno > 0)
			{
				G.db_exec(@"
                insert Oplata(Schet_ID, Summa, Data, [User]) 
                values({1}, '{2}', '{3}', '{4}')", ID, (Summa - oplacheno).ToString().Replace(',', '.'),
					DateTime.Now.AddDays(-1).Date.ToString("yyyyMMdd"),
					Environment.UserName
				);
				G.db_exec("update Scheta set Oplata = '{1}', dtu = getdate(), [User] = '{3}' where ID = {2}",
					Summa.ToString().Replace(',', '.'), ID, Environment.UserName);
			}
		}

		public bool IsCash
		{
			get
			{
				if (ID <= 0) return false;
				if (DateCreate < new DateTime(2019, 12, 1)) return false;

				return Project?.IsCash ?? false; //В Budget.v.4 своя проверка 
			}
		}
		public override string ToString() => $"№ {Nomer} ({NomerInternal}) от {DateCreate:dd.MM.yyyy}";
	}
}
