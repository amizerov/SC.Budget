using LinqToDB;
using LinqToDB.Mapping;
using SC.Common.Dal;
using SC.Common.Services;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SC.Common.Model
{
	[Table("SchetaProda")]
	public class CSchetProdaDto : IHasID
	{
		[PrimaryKey, Identity] public int ID { get; set; }

		[DisplayName("№ Счета")]
		[Column] public string Nomer { get; set; }

		[DisplayName("Сумма")]
		[DisplayFormat(DataFormatString = "C2")]
		[Column] public decimal Summa { get; set; }

		[DisplayName("Штраф")]
		[Column] public decimal Penalty { get; set; }

		[DisplayName("Дата")]
		[Column] public DateTime DataCreate { get; set; }

		[DisplayName("Оплата до")]
		[Column] public DateTime DataPayTo { get; set; }
		[Column] public int Project_ID { get; set; }
		[Column] public int Buyer_ID { get; set; }

		[DisplayName("Оплачено")]
		[DisplayFormat(DataFormatString = "C2")]
		[Column] public decimal Oplata { get; set; }

		[DisplayName("Отгружено")]
		[Column] public bool IsShipped { get; set; }
		[Column] public int Detail_ID { get; set; }
		[Column] public int StDoho_ID { get; set; }
		[Column] public int Firma_ID { get; set; }
		[Column] public string Comment { get; set; }
		[Column] public bool IsDeleted { get; set; }

		[DisplayName("Кем изменён"), Description("Пользователь, внёсший последние изменения в базе данных")]
		[Column] public string User { get; set; }

		[DisplayName("Создан"), Description("Дата создания записи в базе данных")]
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }

		[DisplayName("Изменён"), Description("Дата изменения записи в базе данных")]
		[Column] public DateTime? dtu { get; set; }

		public void UpdateOplatas()
		{
			using (var db = new DbContext())
			{
				var oplataBefore = Oplata;
				Oplata = db.GetTable<COplataProdaDto>()
					.Where(o => o.Schet_ID == ID)
					.Sum(o => o.Summa);
				dtu = DateTime.Now;
				User = Environment.UserName;
				db.Update(this);
				Logger.Log1C($"UpdateOplatas schet.ID: {ID} " +
							 $"OplataBefore:{oplataBefore} " +
							 $"OplataAfter:{Oplata}");
			}
		}

		public void Pay()
		{
			using (var db = new DbContext())
			{
				db.GetTable<COplataProdaDto>()
					.Where(l => l.Schet_ID == ID)
					.Delete();
				var oplata = new COplataProdaDto
				{
					Schet_ID = ID,
					Summa = Summa - Penalty,
					Data = DataCreate,
					User = Environment.UserName
				};
				db.Insert(oplata);
				Oplata = Summa - Penalty;
				dtu = DateTime.Now;
				User = Environment.UserName;
				db.Update(this);
			}
		}
		public override string ToString() => $"№ {Nomer} от {DataCreate:dd.MM.yyyy}";
	}
	public class CSchetProdaViewModel : CSchetProdaDto
	{
		[DisplayName("Контрагент")]
		[Column] public string BuyerName { get; set; }

		[DisplayName("Услуга")]
		[Column] public string DetailName { get; set; }

		[DisplayName("Статья дохода")]
		[Column] public string StDohoName { get; set; }

		[DisplayName("Проект")]
		[Column] public string ProjectName { get; set; }

		[DisplayName("Фирма")]
		[Column] public string FirmaName { get; set; }

		[DisplayName("Дата оплаты")]
		[Column] public DateTime? OplataDate { get; set; }

		[DisplayName("Остаток")]
		[DisplayFormat(DataFormatString = "C2")]
		[Column] public decimal Rest { get; set; }

		public bool Purple => StDohoName == "Судебные";
		public bool Red => !Purple && Rest > 0 && DataPayTo < DateTime.Today;
		public bool Yellow => Rest > 0 && DataPayTo > DateTime.Today.AddDays(-1) && DataPayTo < DateTime.Today.AddDays(7);
		public bool Green => Rest == 0;
		public bool White => Rest > 0 && DataPayTo > DateTime.Today.AddDays(7);
	}
}
