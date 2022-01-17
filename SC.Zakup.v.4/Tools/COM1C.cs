using am.BL;
using LinqToDB;
using SC.Zakup.Models;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using LinqToDB.Common;
using LinqToDB.Data;
using NLog;
using V83;
using CStRash = SC.Zakup.Models.CStRash;

namespace SC.Zakup.Tools
{
	public class COM1C
	{
		#region Fields and Properties
		public static event Action<string> OnConnect;
		public static event Action<string> Progress;
		public static event Action<string> OnError;

		public static string Otchet { get; set; } = "";
		public static string OtchetSingle { get; set; } = "";
		public static bool Connecting { get; private set; }
		public static bool IsConnected { get; private set; }

		private static int _newSchetId = -1;
		public static List<CSchetLoad> Scheta { get; } = new List<CSchetLoad>();
		public static List<CSchetLineDto> SchetLines { get; } = new List<CSchetLineDto>();
		private static readonly List<CPostupleniyaForInsert> _postupLines = new List<CPostupleniyaForInsert>();

		private static string _connectionString;
		private static COMConnector _con;
		private static dynamic _база1С;
		private static WhatUpdateService<CSchetDto> _whatUpdateService;
		private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
		private static string _error = "";

		public static string LastError
		{
			get { return _error; }
			set { _error = value; if (_error.Length > 0) { OnError?.Invoke(_error); } }
		}
		#endregion
		public static void ConnectTo1C(string connectionString)
		{
			_connectionString = connectionString;
			new Thread(Connect).Start();
		}
		private static void Connect()
		{
			if (IsConnected) return;
			try
			{
				Connecting = true;
				_con = new COMConnector();
				_база1С = _con.Connect(_connectionString);
				IsConnected = true;
				OnConnect?.Invoke("Соединение с сервером 1С установлено.");
			}
			catch (Exception ex)
			{
				IsConnected = false;
				OnConnect?.Invoke("Ошибка соединения с сервером 1С.");
				LastError = ex.Message;
			}
			finally
			{
				Connecting = false;
			}
		}

		public static void LoadPostup(DateTime start, DateTime end)
		{
			if (!IsConnected) return;

			Otchet = $"Загружены поступления с {start:dd.MM.yyyy} по {end:dd.MM.yyyy}:\n";
			var noLoaded = true;
			using (var db = new DbContext())
			{
				dynamic поступление = _база1С.Документы.ПоступлениеТоваровУслуг.Выбрать(start, end);
				while (поступление?.Следующий() ?? false)
				{
					if (!поступление.Проведен) continue;

					var postup = new CPostupleniyaDto
					{
						DocDate = поступление.ДатаВходящегоДокумента,
						NomerInternal = поступление.Номер,
						Naklad = поступление.НомерВходящегоДокумента,
						Kontragent = поступление.Контрагент.Наименование,
						Organization = поступление.Организация.Наименование,
						Schet = поступление.СчетНаОплатуПоставщика?.НомерВходящегоДокумента,
						Comment = поступление.Комментарий,
						User = Environment.UserName,
					};
					var schet = db.FirstOrDefault<CSchetDto>(s =>
						s.Nomer == postup.Schet && s.DataCreate.Year == postup.DocDate.Year);
					if (!schet?.IsShipped ?? false)
					{
						schet.IsShipped = true;
						db.Update(schet);
					}

					var otch = $"Накладная: {postup.Naklad} от {postup.DocDate:dd.MM.yyyy}";
					Progress?.Invoke(otch + "\n...");

					var postupLines = new List<CPostupleniyaDto>();
					foreach (dynamic товар in поступление.Товары)
					{
						var project = db.GetOrNew<CProjectDto>((string)товар.sc_Проект?.Наименование);
						var nomenkl = db.GetOrNew<CNomenklaturaDto>((string)товар.Номенклатура.НаименованиеПолное);
						if (!project?.IsShowInSklad ?? false) continue;

						var postupLine = postup.Clone();
						postupLine.LineNumber = товар.НомерСтроки;
						postupLine.Category = PostupCategory.Расходники;
						postupLine.Nomenkl_ID = nomenkl.ID;
						postupLine.Quantity = (int)товар.Количество;
						postupLine.Price = (decimal)товар.Цена;
						postupLine.Measure = товар.ЕдиницаИзмерения.НаименованиеПолное;
						postupLine.Project_ID = project?.ID;

						postupLines.Add(postupLine);
						Progress?.Invoke(otch + $"\nНайдено {postupLines.Count}");
					}
					foreach (dynamic ос in поступление.ОсновныеСредства)
					{
						var postupLine = postup.Clone();
						postupLine.LineNumber = ос.НомерСтроки;
						postupLine.Category = PostupCategory.ОС;
						postupLine.InventoryNum = ос.ИнвентарныйНомер;
						postupLine.Quantity = 1;
						postupLine.Price = (decimal)ос.Сумма;
						postupLine.Measure = "Штука";

						postupLines.Add(postupLine);
						Progress?.Invoke(otch + $"\nНайдено {postupLines.Count}");
					}

					string skladName = поступление.Склад.Наименование;
					var loadedCount = InsertOrUpdatePostupleniya(postupLines, postup.DocDate, postup.Naklad, skladName);
					if (loadedCount > 0)
					{
						Otchet += otch + $" Загружено {loadedCount}\n";
						noLoaded = false;
					}
				}

				dynamic допРасход = _база1С.Документы.ПоступлениеДопРасходов.Выбрать(start, end);
				while (допРасход?.Следующий() ?? false)
				{
					if (!допРасход.Проведен) continue;

					string naklad = допРасход.НомерВходящегоДокумента;
					var postupLinesDb = db.GetWhere<CPostupleniyaDto>(lDb =>
						lDb.Naklad == naklad &&
						!lDb.IsDeleted);
					var totalQuantity = postupLinesDb.Sum(p => p.Quantity);
					foreach (var postup in postupLinesDb)
					{
						postup.PriceAdditional = (decimal)(допРасход.Сумма / totalQuantity);
						postup.User = Environment.UserName;
						postup.dtu = DateTime.Now;
						db.Update(postup);
					}
				}
				if (noLoaded) Otchet = "Нет новых поступлений";
			}
		}
		public static void LoadUslugi(DateTime start, DateTime end)
		{
			if (!IsConnected) return;

			Otchet = $"Загружены услуги с {start:dd.MM.yyyy} по {end:dd.MM.yyyy}:\n";
			var noLoaded = true;
			using (var db = new DbContext())
			{
				dynamic поступление = _база1С.Документы.ПоступлениеТоваровУслуг.Выбрать(start, end);
				while (поступление?.Следующий() ?? false)
				{
					if (!поступление.Проведен) continue;

					var postup = new CPostupleniyaDto
					{
						DocDate = поступление.ДатаВходящегоДокумента,
						NomerInternal = поступление.Номер,
						Naklad = поступление.НомерВходящегоДокумента,
						Kontragent = поступление.Контрагент.Наименование,
						Organization = поступление.Организация.Наименование,
						Schet = поступление.СчетНаОплатуПоставщика?.НомерВходящегоДокумента,
						Comment = поступление.Комментарий,
						User = Environment.UserName,
					};
					var schet = db.FirstOrDefault<CSchetDto>(s =>
						s.Nomer == postup.Schet && s.DataCreate.Year == postup.DocDate.Year);
					if (!schet?.IsShipped ?? false)
					{
						schet.IsShipped = true;
						db.Update(schet);
					}

					var otch = $"Накладная: {postup.Naklad} от {postup.DocDate:dd.MM.yyyy}";
					Progress?.Invoke(otch + "\n...");

					var postupLines = new List<CPostupleniyaDto>();

					foreach (dynamic услуга in поступление.Услуги)
					{
						var project = db.GetOrNew<CProjectDto>((string)услуга.sc_Проект?.Наименование);
						var nomenkl = db.GetOrNew<CNomenklaturaDto>((string)услуга.Номенклатура.НаименованиеПолное);
						if (!project?.IsShowInSklad ?? false) continue;

						var postupLine = postup.Clone();
						postupLine.LineNumber = услуга.НомерСтроки;
						postupLine.Category = PostupCategory.Услуга;
						postupLine.Nomenkl_ID = nomenkl.ID;
						postupLine.Quantity = (int)услуга.Количество;
						postupLine.Price = (decimal)услуга.Цена;
						postupLine.Measure = "Штука";
						postupLine.Project_ID = project?.ID;

						postupLines.Add(postupLine);
						Progress?.Invoke(otch + $"\nНайдено {postupLines.Count}");
					}

					string skladName = поступление.Склад.Наименование;
					var loadedCount = InsertOrUpdatePostupleniya(postupLines, postup.DocDate, postup.Naklad, skladName);
					if (loadedCount > 0)
					{
						Otchet += otch + $" Загружено {loadedCount}\n";
						noLoaded = false;
					}
				}

				dynamic допРасход = _база1С.Документы.ПоступлениеДопРасходов.Выбрать(start, end);
				while (допРасход?.Следующий() ?? false)
				{
					if (!допРасход.Проведен) continue;

					string naklad = допРасход.НомерВходящегоДокумента;
					var postupLinesDb = db.GetWhere<CPostupleniyaDto>(lDb =>
						lDb.Naklad == naklad &&
						!lDb.IsDeleted);
					var totalQuantity = postupLinesDb.Sum(p => p.Quantity);
					foreach (var postup in postupLinesDb)
					{
						postup.PriceAdditional = (decimal)(допРасход.Сумма / totalQuantity);
						postup.User = Environment.UserName;
						postup.dtu = DateTime.Now;
						db.Update(postup);
					}
				}
				if (noLoaded) Otchet = "Нет новых поступлений";
			}
		}

		private static int InsertOrUpdateUslugi(List<CPostupleniyaDto> postupLines)
		{
			return InsertOrUpdatePostupleniya(postupLines, DateTime.MinValue, null, null);
		}
		private static int InsertOrUpdatePostupleniya(List<CPostupleniyaDto> postupLines, DateTime nakladDate, string nakladDocNum, string skladName)
		{
			if (postupLines.IsNullOrEmpty()) return 0;
			var loadedCount = 0;
			using (var db = new DbContext())
			{
				var sklad = skladName.IsEmpty() ? null
					: db.FirstOrDefault<CObjectDto>(o => o.Name == skladName);
				var naklad = new CNakladnayaDto
				{
					DocDate = nakladDate,
					DocNumber = nakladDocNum,
					Object_ID = sklad?.ID,
					Sklad1C = skladName,
					User = Environment.UserName
				};
				if (nakladDocNum.NoEmpty())
				{
					var nakladDb = db.FirstOrDefault<CNakladnayaDto>(n => n.DocNumber == naklad.DocNumber);
					naklad.ID = nakladDb?.ID ?? db.InsertWithInt32Identity(naklad);
					db.Update(naklad); //на всякий случай обновлять накладную если указали новый склад
				}
				foreach (var postupLine in postupLines)
				{
					if (postupLine.Quantity == 0) postupLine.Quantity = 1;
					var postupLineDb = db.FirstOrDefault<CPostupleniyaDto>(lDb =>
						   lDb.NomerInternal == postupLine.NomerInternal &&
						   lDb.LineNumber == postupLine.LineNumber);
					if (postupLineDb != null)
					{
						if (postupLineDb.IsDeleted) continue;

						postupLine.ID = postupLineDb.ID;
						postupLine.QuantityMoved = postupLineDb.QuantityMoved;
						postupLine.User = Environment.UserName;
						postupLine.dtu = DateTime.Now;
						db.Update(postupLine);
					}
					else
					{
						postupLine.QuantityMoved = nakladDocNum.NoEmpty() ? postupLine.Quantity : 0;
						postupLine.ID = db.InsertWithInt32Identity(postupLine);
						if (nakladDocNum.NoEmpty())
						{
							var nakLine = new CNakladLineDto
							{
								Naklad_ID = naklad.ID,
								Postup_ID = postupLine.ID,
								Quantity = postupLine.Quantity,
							};
							db.Insert(nakLine);
						}
						loadedCount++;
					}
				}
			}
			return loadedCount;
		}

		public static void CreateOplatasForPaidScheta(DateTime start, DateTime end)
		{
			var title = "Создание оплат по счетам со статусом 'Оплачен'";
			Otchet += $"{title}:\n";
			Logger.Debug(title, true);
			Progress?.Invoke($"{title}\n...");
			LoadManySchets(start, end, forPaidOnly: true);
		}
		public static void LoadSchetaFinish()
		{
			var loaded = new List<string>();
			var deleted = new List<string>();

			using (var db = new DbContext())
			{
				for (var i = 0; i < Scheta.Count; i++)
				{
					if (!Scheta[i].NeedLoad) continue;
					var schet = MapperService.Map<CSchetDto>(Scheta[i]);
					schet.User = Environment.UserName;

					var schetId = schet.ID;
					if (schetId > 0)
					{
						schet.dtu = DateTime.Now;
						db.Update(schet);
						db.GetTable<CSchetLineDto>()
							.Where(l => l.Schet_ID == schet.ID)
							.Delete();
						_whatUpdateService.AddAfterUpdate(schet);

						if (schet.IsDeleted && _whatUpdateService.IsUpdated(schetId, nameof(CSchetDto.IsDeleted)))
						{
							deleted.Add($"{deleted.Count + 1}) {schet}");
						}
					}
					else
					{
						schet.ID = db.InsertWithInt32Identity(schet);
						loaded.Add($"{loaded.Count + 1}) {schet}");
					}

					var lines = SchetLines.Where(l => l.Schet_ID == schetId).ToArray();

					if (lines.Any())
					{
						foreach (var l in lines) l.Schet_ID = schet.ID;
						db.BulkCopy(lines);

						if (schet.IsAvance)
						{
							var postups = _postupLines.Where(p => p.Naklad == schet.Nomer).ToArray();
							if (postups.Any())
							{
								var sklad = postups[0].Sklad;
								var postupsDto = postups.Select(MapperService.Map<CPostupleniyaDto>).ToList();
								var loadedCount = InsertOrUpdatePostupleniya(postupsDto, schet.DataCreate,
									schet.Nomer, sklad);
								if (loadedCount > 0)
								{
									Otchet += $"По авансовому отчёту {schet} загружено товаров: {loadedCount}\n";
								}
							}
						}
					}

					if (Scheta[i].NeedPaid) schet.Pay();
					if (schet.TryCreateCash(db)) Logger.Debug("Создана операция кэша");
				}
			}
			_whatUpdateService.SaveFile();
			if (loaded.Any()) Otchet += "Загружены счета:\n" + string.Join("\n", loaded);
			if (loaded.Any() && deleted.Any()) Otchet += "\n";
			if (deleted.Any()) Otchet += "Помечены удалёнными счета:\n" + string.Join("\n", deleted);
			if (!loaded.Any() && !deleted.Any()) Otchet += "Ничего не загружено";
		}

		public static void LoadManySchets(DateTime start, DateTime end, string firma = null, string supplier = null, bool forPaidOnly = false)
		{
			if (!IsConnected) return;
			Logger.Debug($"LoadManySchets с {start:dd.MM.yyyy} по {end:dd.MM.yyyy}");

			if (!forPaidOnly) Otchet = null;
			ResetScheta();
			dynamic счет = _база1С.Документы.СчетНаОплатуПоставщика.Выбрать(start, end);
			while (счет?.Следующий() ?? false)
			{
				if (firma.NoEmpty() && firma != "Все" && firma != счет.Организация.Наименование) continue;
				if (supplier.NoEmpty() && supplier != "Все" && supplier != счет.Контрагент.Наименование) continue;

				LoadSingleSchet(счет, forPaidOnly);
			}
		}

		private static void ResetScheta()
		{
			_whatUpdateService = new WhatUpdateService<CSchetDto>();
			Scheta.Clear();
			SchetLines.Clear();
			_newSchetId = -1;
			_postupLines.Clear();
		}

		public static void LoadSingleSchet(CSchetDto schet)
		{
			OtchetSingle = null;
			ResetScheta();
			if (!IsConnected)
			{
				OtchetSingle = "Ошибка!\nНет соединения с 1С";
				return;
			}
			var nomer = schet.NomerInternal;
			if (nomer.IsEmpty())
			{
				OtchetSingle = "Поиск в 1С счёта без номера невозможен.\nПродолжение невозможно.";
				return;
			}
			_whatUpdateService.LoadPrevFile();
			var dateTime = schet.DataCreate;
			if (schet.IsAvance)
			{
				dynamic аванс = _база1С.Документы.АвансовыйОтчет.НайтиПоНомеру(nomer, dateTime);
				аванс = аванс?.ПолучитьОбъект();
				LoadSingleAnance(аванс);
			}
			else
			{
				dynamic счет = _база1С.Документы.СчетНаОплатуПоставщика.НайтиПоНомеру(nomer, dateTime);
				счет = счет?.ПолучитьОбъект();
				LoadSingleSchet(счет);
			}
		}
		private static void LoadSingleSchet(dynamic счет, bool forPaidOnly = false)
		{
			using (var db = new DbContext())
			{
				string id1C = _база1С.XMLСтрока(счет.Ссылка);
				string номер = счет.Номер;
				DateTime дата = счет.Дата;
				var std = _база1С.РегистрыСведений.СтатусыДокументов
					.ПолучитьСтатусыДокумента(счет.Ссылка, счет.Организация.Ссылка);
				string status = _база1С.XMLString(std.Статус).ToString();

				var schetDto = db.FirstOrDefault<CSchetDto>(s => s.ID_1C == id1C && !s.IsAvance)
					?? new CSchetDto();
				var schet = MapperService.Map<CSchetLoad>(schetDto);

				schet.ID_1C = id1C;
				if (status == "Оплачен")
				{
					schet.NeedPaid = true;
					if (forPaidOnly && schet.ID > 0)
					{
						if (schet.Pay())
						{
							Logger.Debug($"Оплачен счёт {schet}\n");
							Otchet += $"Оплачен счёт {schet}\n";
						}
						return;
					}
				}

				CStRashDto stRash = db.GetOrNew<CStRashDto>(счет.sc_СтатьяЗатратДерево.Наименование);
				schet.NomerInternal = номер;
				schet.DataCreate = дата;
				schet.Nomer = счет.НомерВходящегоДокумента;
				schet.Summa = (decimal)счет.СуммаДокумента;

				bool проведен = счет.Проведен;
				bool помеченУдалённым = счет.ПометкаУдаления();

				if (!проведен || status == "Отменен" ||
					помеченУдалённым || (stRash?.NoUsed ?? false))
				{
					if (schet.ID > 0 && !schet.IsDeleted)
					{
						Logger.Debug($"Помечен удалённым счёт {schet} на сумму {schet.Summa:c2}");
						schet.IsDeleted = true;
						Scheta.Add(schet);
						OtchetSingle = $"Помечен удалённым счёт {schet}";
					}
					return;
				}
				schet.IsDeleted = false;

				if (schet.ID > 0)
				{
					_whatUpdateService.AddBeforeUpdate(schet);
					Progress?.Invoke($"Обновление счета {schet}");
					Logger.Debug($"Обновлён счёт {schet} на сумму {schet.Summa:c2}");
				}
				else
				{
					Progress?.Invoke($"Загрузка счета {schet}");
					Logger.Debug($"Загружен счёт {schet} на сумму {счет.СуммаДокумента:c2}");
				}

				var sd = _база1С.СрокиОплатыДокументов;
				var so = sd.УстановленныйСрокОплаты(счет.Ссылка, счет.Организация.Ссылка);
				CProjectDto project = db.GetOrNew<CProjectDto>(счет.sc_Проект.Наименование);
				CDetailDto detail = db.GetOrNew<CDetailDto>(счет.sc_ДетализацияДерево.Наименование);

				schet.IsAvance = false;
				schet.DataPayTo = so ?? schet.DataCreate.AddDays(7);
				schet.Project_ID = project?.ID;
				schet.Supplier_ID = db.GetOrNew<CSupplierDto>(счет.Контрагент.Наименование)?.ID;
				schet.Detail_ID = detail?.ID;
				schet.Firma_ID = db.GetOrNew<CFirmaDto>(счет.Организация.Наименование)?.ID;
				schet.StRash_ID = stRash?.ID;
				schet.Category = detail?.Category ?? SchetCategory.Direct;
				schet.Comment = счет.Комментарий;

				if (schet.ID == 0) schet.ID = _newSchetId--;
				Scheta.Add(schet);

				Progress?.Invoke($"Поиск товаров по счёту {schet}");
				foreach (var товар in счет.Товары)
				{
					var nomenkl = db.GetOrNew<CNomenklaturaDto>((string)товар.Номенклатура.НаименованиеПолное);
					SchetLines.Add(new CSchetLineDto
					{
						Schet_ID = schet.ID,
						Nomenkl_ID = nomenkl.ID,
						Quantity = G._I(товар.Количество),
						Price = (decimal)товар.Цена
					});
				}
				OtchetSingle = $"Обновлён счёт {schet}";
			}
		}
		public static void LoadManyAvances(DateTime start, DateTime end, string firma = null)
		{
			if (!IsConnected) return;
			Logger.Debug($"LoadManyAvances с {start:dd.MM.yyyy} по {end:dd.MM.yyyy}");

			Otchet = null;
			ResetScheta();

			dynamic аванс = _база1С.Документы.АвансовыйОтчет.Выбрать(start, end);
			while (аванс?.Следующий() ?? false)
			{
				if (firma.NoEmpty() && firma != "Все" && firma != аванс.Организация.Наименование) continue;
				LoadSingleAnance(аванс);
			}
		}
		private static void LoadSingleAnance(dynamic аванс)
		{
			if ((аванс.sc_Проект.Наименование as string).IsEmpty()) return;

			using (var db = new DbContext())
			{
				string id1C = _база1С.XMLСтрока(аванс.Ссылка);
				var schetDto = db.FirstOrDefault<CSchetDto>(s => s.ID_1C == id1C && s.IsAvance)
							?? new CSchetDto();
				var schet = MapperService.Map<CSchetLoad>(schetDto);

				if (!аванс.Проведен || аванс.ПометкаУдаления())
				{
					if (schet.ID > 0 && !schet.IsDeleted)
					{
						Logger.Debug($"Помечен удалённым авансовый отчёт {schet} на сумму {schet.Summa:c2}");
						schet.IsDeleted = true;
						Scheta.Add(schet);
						OtchetSingle = $"Помечен удалённым авансовый отчёт {schet}";
					}
					return;
				}

				if (schet.ID == 0)
				{
					Progress?.Invoke($"Загрузка авансового отчёта {schet}");
					Logger.Debug($"Загружен авансовый отчёт {schet} на сумму {schet.Summa:c2}");
				}
				else
				{
					_whatUpdateService.AddBeforeUpdate(schet);
					Progress?.Invoke($"Обновление авансового отчёта {schet}");
					Logger.Debug($"Обновлён авансовый отчёт {schet} на сумму {schet.Summa:c2}");
				}

				CDetailDto detail = db.GetOrNew<CDetailDto>(аванс.sc_ДетализацияДерево.Наименование);

				schet.NeedPaid = true;
				schet.ID_1C = id1C;
				schet.NomerInternal = аванс.Номер;
				schet.DataCreate = аванс.Дата;
				schet.IsAvance = true;
				schet.DataPayTo = аванс.Дата;
				schet.Project_ID = db.GetOrNew<CProjectDto>(аванс.sc_Проект.Наименование)?.ID;
				schet.Detail_ID = detail?.ID;
				schet.Firma_ID = db.GetOrNew<CFirmaDto>(аванс.Организация.Наименование)?.ID;
				schet.StRash_ID = db.GetOrNew<CStRashDto>(аванс.sc_СтатьяЗатратДерево.Наименование)?.ID;
				schet.Category = detail?.Category ?? SchetCategory.Direct;
				schet.Summa = (decimal)аванс.СуммаДокумента;
				schet.Nomer = $"АВ-{аванс.ФизЛицо.Наименование}";
				schet.Comment = аванс.Комментарий;
				schet.IsShipped = true;

				if (schet.ID == 0) schet.ID = _newSchetId--;
				Scheta.Add(schet);

				Progress?.Invoke($"Поиск товаров по авансовому отчёту {schet}");
				var lines = new List<CSchetLineDto>();
				foreach (dynamic товар in аванс.Товары)
				{
					var nomenkl = db.GetOrNew<CNomenklaturaDto>((string)товар.Номенклатура.НаименованиеПолное);
					lines.Add(new CSchetLineDto
					{
						Schet_ID = schet.ID,
						Nomenkl_ID = nomenkl.ID,
						Quantity = G._I(товар.Количество),
						Price = (decimal)товар.Цена
					});
					if (schet.Supplier_ID == null)
					{
						schet.Supplier_ID = db.GetOrNew<CSupplierDto>(товар.Поставщик.Наименование)?.ID;
					}
				}
				if (lines.Any())
				{
					SchetLines.AddRange(lines);
					var firmaName = db.GetByID<CFirmaDto>(schet.Firma_ID)?.Name;
					var supplierName = db.GetByID<CSupplierDto>(schet.Supplier_ID)?.Name;
					for (int i = 0; i < lines.Count; i++)
					{
						_postupLines.Add(new CPostupleniyaForInsert
						{
							Sklad = аванс.Склад.Наименование,
							Nomenkl_ID = lines[i].Nomenkl_ID,
							NomerInternal = $"{schet.NomerInternal} [{schet.ID}]",
							LineNumber = i + 1,
							DocDate = schet.DataCreate,
							Naklad = schet.Nomer,
							Price = lines[i].Price,
							Organization = firmaName,
							Kontragent = supplierName,
							Schet = schet.Nomer,
							Measure = "Штука",
							Category = PostupCategory.Расходники,
							Quantity = lines[i].Quantity,
							Comment = $"Аванс от '{аванс.ФизЛицо.Наименование}'",
							User = Environment.UserName
						});
					}
				}
				OtchetSingle = $"Обновлён авансовый отчёт {schet}";
			}
		}
		public static void LoadOplatas(DateTime start, DateTime end, int[] prevIds = null)
		{
			var startMin = new DateTime(2020, 1, 1);
			if (start < startMin) start = startMin;
			if (end < startMin) end = startMin;
			var isFirst = prevIds == null;
			var stepTxt = $"{(isFirst ? "Первый этап " : "Второй этап ")} с {start:dd.MM.yyyy} по {end:dd.MM.yyyy}";
			Logger.Debug($"LoadOplatas {stepTxt}");
			Progress?.Invoke($"{stepTxt}\n...");
			if (isFirst) Otchet = $"Обновлены оплаты по счетам";
			Otchet += $"\n\n{stepTxt}:\n";

			using (var db = new DbContext())
			{
				dynamic оплата = _база1С.Документы.СписаниеСРасчетногоСчета.Выбрать(start, end);
				var schets = new List<CSchetDto>();
				while (оплата?.Следующий() ?? false)
				{
					DateTime dateOplata = оплата.Дата;
					var sumOplata = (decimal)оплата.СуммаДокумента;

					var счет = GetSchetFromOplata(оплата);
					if (счет == null)
					{
						Logger.Debug($"счет не найден Дата: {dateOplata} | Сумма: {sumOplata}");
						continue;
					}
					string nomerInternal = счет.Номер;
					DateTime dateSchet = счет.Дата;
					var schet = db.GetTable<CSchetDto>()
						.FirstOrDefault(s => s.NomerInternal == nomerInternal &&
											 s.DataCreate.Year == dateSchet.Year &&
											 !s.IsDeleted &&
											 (isFirst || prevIds.Contains(s.ID)));
					if (schet == null)
					{
						Logger.Debug($"schet == null | Дата оплаты: {dateOplata} | Сумма оплаты: {sumOplata} " +
							$"| nomerInternal: {nomerInternal} | Дата счёта: {dateSchet}");
						continue;
					}

					if (isFirst && !schets.Any(s => s.ID == schet.ID))
					{
						db.GetTable<COplataDto>()
							.Where(o => o.Schet_ID == schet.ID)
							.Where(o => o.Data >= startMin)
							.Where(o => o.Summa > 0)
							.Delete();
					}
					var oplata = new COplataDto
					{
						ID_1C = _база1С.XMLСтрока(оплата.Ссылка),
						Data = оплата.Дата,
						Schet_ID = schet.ID,
						Summa = (decimal)оплата.СуммаДокумента,
						User = Environment.UserName,
					};
					db.Insert(oplata);
					Logger.Debug($"Insert(oplata) nomerInternal: {nomerInternal} {oplata}");

					if (!schets.Any(s => s.ID == schet.ID))
					{
						schets.Add(schet);

						Otchet += $"{schets.Count}) {schet}\n";
						Progress?.Invoke($"{stepTxt}\nОбновление оплат по счёту {schet}");
					}
				}

				foreach (var schet in schets)
				{
					schet.UpdateOplatas();
					if (schet.TryCreateCash(db)) Logger.Debug("Создана операция кэша");
				}
				if (schets.Any() && isFirst && schets.Min(s => s.DataCreate) < start)
				{
					LoadOplatas(schets.Min(s => s.DataCreate), start, schets.Select(s => s.ID).ToArray());
				}
				if (!schets.Any()) Otchet += "Ничего не загружено\n";
			}
		}

		public static void LoadOplatas2(DateTime start, DateTime end)
		{
			var startMin = new DateTime(2020, 1, 1);
			if (start < startMin) start = startMin;
			if (end < startMin) end = startMin;
			Logger.Debug($"LoadOplatas2 с {start:dd.MM.yyyy} по {end:dd.MM.yyyy}");
			Progress?.Invoke("Загрузка\n...");
			Otchet = $"Обновлены оплаты с {start:dd.MM.yyyy} по {end:dd.MM.yyyy}:\n";

			using (var db = new DbContext())
			{
				var loadCount = 0;
				dynamic оплата = _база1С.Документы.СписаниеСРасчетногоСчета.Выбрать(start, end);
				while (оплата?.Следующий() ?? false)
				{
					DateTime dateOplata = оплата.Дата;
					var sumOplata = (decimal)оплата.СуммаДокумента;

					var счет = GetSchetFromOplata(оплата);
					string nomerInternal = счет?.Номер;
					DateTime dateSchet = счет?.Дата ?? new DateTime(1900, 1, 1);
					var schet = db.GetTable<CSchetDto>()
						.FirstOrDefault(s => s.NomerInternal == nomerInternal &&
											 s.DataCreate.Year == dateSchet.Year &&
											 !s.IsDeleted);
					if (schet == null)
					{
						Logger.Debug($"schet == null | Дата оплаты: {dateOplata} | Сумма оплаты: {sumOplata} " +
							$"| nomerInternal: {nomerInternal} | Дата счёта: {dateSchet}");
					}

					string id1C = _база1С.XMLСтрока(оплата.Ссылка);
					var oplata = db.FirstOrDefault<COplataDto>(o => o.ID_1C == id1C);
					if (oplata == null) oplata = new COplataDto();
					oplata.ID_1C = id1C;
					oplata.Data = оплата.Дата;
					oplata.Schet_ID = schet?.ID;
					oplata.Summa = (decimal)оплата.СуммаДокумента;
					oplata.User = Environment.UserName;
					if (oplata.ID > 0)
					{
						db.Update(oplata);
						Logger.Debug($"Update(oplata) nomerInternal: {nomerInternal} {oplata}");
						Progress?.Invoke($"Обновляется оплата\n{oplata}");
					}
					else
					{
						db.Insert(oplata);
						Logger.Debug($"Insert(oplata) nomerInternal: {nomerInternal} {oplata}");
						Progress?.Invoke($"Загружается оплата\n{oplata}");
						Otchet += $"{++loadCount}) {oplata}\n";
					}
					schet?.UpdateOplatas();
				}
				if (loadCount == 0) Otchet += "Ничего не загружено\n\n";
			}
		}

		private static dynamic GetSchetFromOplata(dynamic оплата)
		{
			DateTime date = оплата.Дата;
			var sum = (decimal)оплата.СуммаДокумента;

			foreach (var расшифровкаПлатежа in оплата.РасшифровкаПлатежа)
			{
				var счетИзРасшифровки = расшифровкаПлатежа.СчетНаОплату;
				if (счетИзРасшифровки != null)
				{
					Logger.Debug($"найден счет из расшифровки Дата: {date} | Сумма: {sum}");
					return счетИзРасшифровки;
				}
			}
			Logger.Debug($"счет из расшифровки не найден Дата: {date} | Сумма: {sum}");

			var счет = оплата.ДокументОснование;
			if (счет == null) return null;
			while (счет != null && _база1С.XMLТипЗнч(счет).TypeName != "DocumentRef.СчетНаОплатуПоставщика")
			{
				Logger.Debug($"Основание: {_база1С.XMLТипЗнч(счет).TypeName}");
				try
				{
					if (_база1С.XMLТипЗнч(счет).TypeName == "DocumentRef.ПоступлениеТоваровУслуг")
					{
						счет = счет.СчетНаОплатуПоставщика;
					}
					else счет = счет.ДокументОснование;
				}
				catch { счет = null; }
			}

			if (счет != null)
			{
				Logger.Debug($"найден счет Дата: {date} | Сумма: {sum}");
			}
			else
			{
				Logger.Debug($"счет не найден Дата: {date} | Сумма: {sum}");
			}
			return счет;
		}

		public static void LoadSchetId_1C()
		{
			var start = new DateTime(2020, 1, 1);
			dynamic счет = _база1С.Документы.СчетНаОплатуПоставщика.Выбрать(start, DateTime.Today.AddDays(1));
			LoadId_1C(счет);
		}
		public static void LoadAvanceId_1C()
		{
			var start = new DateTime(2020, 1, 1);
			dynamic аванс = _база1С.Документы.АвансовыйОтчет.Выбрать(start, DateTime.Today.AddDays(1));
			LoadId_1C(аванс);
		}
		private static void LoadId_1C(dynamic счет)
		{
			using (var db = new DbContext())
			{
				while (счет?.Следующий() ?? false)
				{
					string nomer = счет.Номер;
					string id1c = _база1С.XMLСтрока(счет.Ссылка);

					var schetDb = db.FirstOrDefault<CSchetDto>(s => string.IsNullOrEmpty(s.ID_1C) &&
																	s.DataCreate.Year == 2020 &&
																	s.NomerInternal == nomer);
					if (schetDb != null)
					{
						schetDb.ID_1C = id1c;
						db.Update(schetDb);
					}
				}
			}
		}
		public static void LoadOplatasID_1C()
		{
			using (var db = new DbContext())
			{
				var start = new DateTime(2020, 1, 1);
				dynamic оплата = _база1С.Документы.СписаниеСРасчетногоСчета.Выбрать(start, DateTime.Today);
				while (оплата?.Следующий() ?? false)
				{
					DateTime dateOplata = оплата.Дата;
					var sumOplata = (decimal)оплата.СуммаДокумента;
					string id1c = _база1С.XMLСтрока(оплата.Ссылка);

					db.GetTable<COplataDto>()
						.Where(o => o.Data == dateOplata)
						.Where(o => o.Summa == sumOplata)
						.Set(o => o.ID_1C, id1c)
						.Update();
				}
			}
		}

		public static bool UploadStRashTo1C()
		{
			if (!IsConnected) return false;

			CStRashs rs = new CStRashs();

			foreach (CStRash r in rs)
			{
				if (r.Name.Length > 0)
				{
					dynamic Справочники = _база1С.Справочники;
					dynamic СтатьиЗатрат = Справочники.sc_СтатьиЗатратДерево;
					dynamic СтатьяРасхода = СтатьиЗатрат.НайтиПоНаименованию(r.Name, 1, 1);
					if (СтатьяРасхода.Наименование == "")
					{
						СтатьяРасхода.Наименование = r.Name;
						СтатьяРасхода.Записать();
					}
				}
			}
			return true;
		}
	}
}