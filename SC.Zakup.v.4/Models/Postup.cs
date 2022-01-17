using am.BL;
using SC.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace SC.Zakup.Models
{
	public class Postup
	{
		public string DataIncomDoc { get; set; }
		public string NomerInternal { get; set; }
		public string NomerNakladn { get; set; }
		public string NomerScheta { get; set; }
		public string Kontragent { get; set; }
		public string Organization { get; set; }
		public List<PostupLine> Lines { get; set; }

		public Postup()
		{
			Lines = new List<PostupLine>();
		}

		public int Save()
		{
			int c = 0;
			foreach (PostupLine l in Lines)
			{
				DataTable dt = G.db_select("SaveNewPostuplenie4 " +
					"'{1}', {2}, '{3}', '{4}', '{5}', '{6}', {7}, {8}, '{9}', '{10}', {11}, '{12}', '{13}', '{14}'",
				NomerInternal, l.LineNumber,
				DataIncomDoc, NomerNakladn, NomerScheta, l.Nomenklatura, l.Quantity,
				l.Price.ToString().Replace(',', '.'), l.Measure, G._S(l.InventarNomer), (int)l.Category,
				Kontragent, Organization, Environment.UserName);

				c += G._I(dt);
			}
			return c;
		}
	}

	public class PostupLine
	{
		public int LineNumber { get; set; }
		public string InventarNomer { get; set; }
		public string Nomenklatura { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
		public string Measure { get; set; }
		public PostupCategory Category { get; set; }
	}
}
