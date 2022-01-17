using LinqToDB;
using LinqToDB.Mapping;
using SC.Common.Dal;
using SC.Common.Services;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LinqToDB.Data;
using SC.Common.Properties;

namespace SC.Common.Model
{
	public enum SchetCategory
	{
		[Display(Name = "Прямые расходы")] Direct,
		[Display(Name = "Косвенные расходы")] Indirect
	}

	[Table("Scheta")]
	public class CSchetDto : IHasID
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		[Column] public string ID_1C { get; set; }

		[DisplayName("№ Счета")]
		[Column] public string Nomer { get; set; }

		/// <summary>Номер из 1С</summary>
		[DisplayName("№ 1С")]
		[Column] public string NomerInternal { get; set; }

		[DisplayName("Сумма")]
		[DisplayFormat(DataFormatString = "C2")]
		[Column] public decimal Summa { get; set; }
		[Column] public decimal? Penalty { get; set; }

		[DisplayName("Дата")]
		[Column] public DateTime DataCreate { get; set; }

		[DisplayName("Оплата до")]
		[Column] public DateTime? DataPayTo { get; set; }
		[Column] public int? Project_ID { get; set; }
		[Column] public int? Supplier_ID { get; set; }

		[DisplayName("Оплачено")]
		[DisplayFormat(DataFormatString = "C2")]
		[Column] public decimal Oplata { get; set; }

		[DisplayName("Отгружено")]
		[Column] public bool IsShipped { get; set; }
		[Column] public int? Detail_ID { get; set; }
		[Column] public int? StRash_ID { get; set; }
		[Column] public int? Firma_ID { get; set; }

		[DisplayName("Категория")]
		[Column] public SchetCategory Category { get; set; }
		[Column] public bool IsAvance { get; set; }
		[Column] public int? AvanceUser_ID { get; set; }

		[DisplayName("Комментарий")]
		[Column] public string Comment { get; set; }

		[DisplayName("Удалён")]
		[Column] public bool IsDeleted { get; set; }

		[DisplayName("Кем изменён"), Description("Пользователь, внёсший последние изменения в базе данных")]
		[Column] public string User { get; set; }

		[DisplayName("Создан"), Description("Дата создания записи в базе данных")]
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }

		[DisplayName("Изменён"), Description("Дата изменения записи в базе данных")]
		[Column] public DateTime? dtu { get; set; }

		public override string ToString() => $"№ {Nomer} ({NomerInternal}) от {DataCreate:dd.MM.yyyy}";

		public void UpdateOplatas()
		{
			using (var db = new DbContext())
			{
				Oplata = db.GetTable<COplataDto>()
					.Where(o => o.Schet_ID == ID)
					.Where(o => !o.IsDeleted)
					.Sum(o => o.Summa);
				User = Environment.UserName;
				dtu = DateTime.Now;
				db.Update(this);
			}
		}
		public bool Pay()
		{
			using (var db = new DbContext())
			{
				var oplataPositive = db.GetTable<COplataDto>()
					.Where(o => o.Schet_ID == ID)
					.Where(o => !o.IsDeleted)
					.Where(o => o.Summa > 0)
					.Sum(o => o.Summa);

				if (Summa <= oplataPositive) return false;

				var oplata = new COplataDto
				{
					Schet_ID = ID,
					Summa = Summa - Oplata,
					Data = DataCreate,
					User = Environment.UserName
				};
				db.Insert(oplata);
			}
			UpdateOplatas();
			return true;
		}

		public bool TryCreateCash(DbContext db)
		{
			var project = db.GetByID<CProjectDto>(Project_ID);
			if ((project?.IsCash ?? false) && DataCreate.Year >= 2020) //Если кэш
			{
				COperationCashDto.Insert(ID, Oplata);
				return true;
			}
			return false;
		}
	}
	public class CSchet : CSchetDto
	{
		[DisplayName("Поставщик")]
		[Column] public string SupplierName { get; set; }

		[DisplayName("Детализация")]
		[Column] public string DetailName { get; set; }

		[DisplayName("Статья расхода")]
		[Column] public string StRashName { get; set; }

		[DisplayName("Проект")]
		[Column] public string ProjectName { get; set; }
		[Column] public bool IsCash { get; set; }

		[DisplayName("Организация")]
		[Column] public string FirmaName { get; set; }

		[DisplayName("Дата оплаты")]
		[Column] public DateTime? OplataDate { get; set; }

		[DisplayName("Остаток")]
		[DisplayFormat(DataFormatString = "C2")]
		[Column] public decimal Rest { get; set; }

		public bool Red => Rest > 0 && DataPayTo < DateTime.Today;
		public bool Yellow => Rest > 0 && DataPayTo > DateTime.Today.AddDays(-1) && DataPayTo < DateTime.Today.AddDays(7);
		public bool Green => Rest == 0;
		public bool White => Rest > 0 && DataPayTo > DateTime.Today.AddDays(7);

		public static CSchet[] GetTable(int? id = null, 
			DateTime? start = null, DateTime? end = null, 
			DateTime? oplataStart = null, DateTime? oplataEnd = null, 
			bool? isDeleted = null)
		{
			using (var db = new DbContext())
			{
				var isDeletedInt = isDeleted == null ? (int?)null : isDeleted.Value ? 1 : 0;
				var scheta = db.Query<CSchet>(Resources.Scheta,
					new DataParameter("@id", id),
					new DataParameter("@start", start),
					new DataParameter("@end", end),
					new DataParameter("@oplataStart", oplataStart),
					new DataParameter("@oplataEnd", oplataEnd),
					new DataParameter("@isDeleted", isDeletedInt))
					.ToArray();
				return scheta;
			}
		}
	}

	public class CSchetLoad : CSchet
	{
		[DisplayName("Обновить")]
		public bool NeedLoad { get; set; }
		public bool NeedPaid { get; set; }
	}
}
