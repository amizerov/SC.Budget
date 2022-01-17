using am.BL;
using LinqToDB;
using NLog;
using SC.Common.Dal;
using SC.Common.Model;
using SC.Common.Services;
using SC.Proda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using DevExpress.XtraBars.Docking2010.Base;
using V83;
using CDetail = SC.Proda.Models.CDetail;
using CSchet = SC.Proda.Models.CSchet;

namespace SC.Proda.Tools
{
	public class COM1C
	{
		#region Fields and Properties

		private static string _connectionString;
		private static COMConnector _con;
		private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

		private static dynamic _база1С;
		private static dynamic _проекты;

		public static event Action<string> Connected;
		public static event Action<string> Progress;
		public static event Action<string> Completed;
		public static event Action<string> Error;

		private static string _err = "";

		public static string LastError
		{
			get => _err;
			set
			{
				_err = value;
				if (_err.Length > 0) Error?.Invoke(_err);
			}
		}

		public static string Otchet { get; set; } = "";
		public static bool IsConnected { get; set; }
		public static bool Connecting { get; set; }

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
				_проекты = _база1С.Справочники.sc_Проекты;

				IsConnected = true;
				Connected?.Invoke("Соединение с сервером 1С установлено.");
			}
			catch (COMException ex)
			{
				IsConnected = false;
				Connected?.Invoke("Ошибка соединения с 1С.");
				LastError = ex.Message;
			}
			finally
			{
				Connecting = false;
			}
		}

		public static void LoadManySchets(DateTime start, DateTime end)
		{
			if (!IsConnected)
			{
				LastError = "Нет соединения с 1С";
				return;
			}

			Otchet = $"Обновлены детали по счетам с {start:dd.MM.yyyy} по {end:dd.MM.yyyy}\n\n";
			Logger.Debug($"LoadManySchets с {start:dd.MM.yyyy} по {end:dd.MM.yyyy}");
			var loaded = new List<string>();
			var noLoaded = new List<string>();
			var deleted = new List<string>();

			var счета = _база1С.Документы.СчетНаОплатуПокупателю;
			var счет = счета.Выбрать(start, end);
			var whatUpdateService = new WhatUpdateService<CSchetProdaDto>();

			using (var db = new DbContext())
			{
				while (счет?.Следующий() ?? false)
				{
					string номер = счет.Номер;
					DateTime дата = счет.Дата;
#if DEBUG
					if (номер.Contains("437"))
					{
						//throw new Exception("Test");
					}
#endif
					var sd = _база1С.РегистрыСведений.СтатусыДокументов.ПолучитьСтатусыДокумента(счет.Ссылка,
						счет.Организация.Ссылка);
					string status = _база1С.XMLString(sd.Статус);

					var schet = db.FirstOrDefault<CSchetProdaDto>(s => s.Nomer == номер && s.DataCreate.Year == дата.Year)
						?? new CSchetProdaDto();

					bool проведен = счет.Проведен;
					bool помеченУдалённым = счет.ПометкаУдаления();
					CStDohoDto stDoho = db.GetOrNew<CStDohoDto>(счет.sc_СтатьяДоходовДерево.Наименование);
					CBuyerDto buyer = db.GetOrNew<CBuyerDto>(счет.Контрагент.Наименование);

					schet.Nomer = номер;
					schet.DataCreate = дата;
					schet.Summa = (decimal)счет.СуммаДокумента;

					(bool isDeleted, string why) TryDelete()
					{
						if (!проведен) return (true, "счёт не проведён");
						if (помеченУдалённым) return (true, "счёт помечен удалённым в 1С");
						if (status == "Отменен") return (true, "статус \"Отменен\"");
						if (stDoho?.NoUsed ?? false) return (true, "неактуальная статья дохода");
						if (buyer?.IsInternal ?? false) return (true, "\"внутренний\" поставщик");
						return (false, "");
					}

					var (isDeleted, whyDeleted) = TryDelete();
					if (isDeleted)
					{
						if (schet.ID > 0 && !schet.IsDeleted)
						{
							Logger.Debug($"Помечен удалённым счёт {schet} на сумму {schet.Summa:c2} ({whyDeleted})");
							schet.IsDeleted = true;
							deleted.Add($"{deleted.Count + 1}) {schet}");
							db.Update(schet);
						}
						else
						{
							noLoaded.Add($"{noLoaded.Count + 1}) {schet} на сумму {schet.Summa:c2} ({whyDeleted})");
							Logger.Debug($"Не загружен счёт {schet} на сумму {счет.СуммаДокумента:c2}");
						}
						continue;
					}

					if (schet.ID <= 0 || schet.IsDeleted)
					{
						loaded.Add($"{loaded.Count + 1}) {schet} на сумму {schet.Summa:c2}");
						Progress?.Invoke($"Загрузка счета {schet}");
						Logger.Debug($"Загружен счёт {schet} на сумму {счет.СуммаДокумента:c2}");
					}
					else
					{
						whatUpdateService.AddBeforeUpdate(schet);
						Progress?.Invoke($"Обновление счета {schet}");
						Logger.Debug($"Обновлён счёт {schet} на сумму {schet.Summa:c2}");
					}

					schet.IsDeleted = false;

					var sod = _база1С.СрокиОплатыДокументов;
					var so = sod.УстановленныйСрокОплаты(счет.Ссылка, счет.Организация.Ссылка);

					schet.DataPayTo = so ?? schet.DataCreate.AddDays(7);
					schet.Buyer_ID = buyer?.ID ?? 0;
					schet.Firma_ID = db.GetOrNew<CFirmaDto>(счет.Организация.Наименование)?.ID;
					schet.StDoho_ID = stDoho?.ID ?? 0;
					schet.Comment = счет.Комментарий;
					schet.IsShipped = _база1С.XMLString(sd.ДополнительныйСтатус) == "Отгружен";
					schet.User = Environment.UserName;

					string projName = счет.sc_Проект?.Наименование;
					var needFindProject = true;
					if (projName.NoEmpty())
					{
						schet.Project_ID = db.GetOrNew<CProjectDto>(projName)?.ID ?? 0;
						needFindProject = false;
					}
					else
					{
						projName = GetProjectNameByINN(счет.Контрагент.ИНН);
						schet.Project_ID = db.GetOrNew<CProjectDto>(projName)?.ID ?? 0;
					}

					if (schet.ID == 0) schet.ID = db.InsertWithInt32Identity(schet);

					db.GetTable<CSchetProdaLineDto>()
						.Where(l => l.Schet_ID == schet.ID)
						.Delete();

					schet.Penalty = 0;

					foreach (var товар in счет.Товары)
					{
						string objAddress = товар.sc_Объект.Наименование;
						var obj = db.FirstOrDefault<CObjectDto>(o => o.Address == objAddress);
						if (needFindProject &&
						    objAddress.NoEmpty() &&
							obj?.Project_ID > 0 &&
							schet.Project_ID != obj.Project_ID)
						{
							schet.Project_ID = obj.Project_ID;
						}

						var line = new CSchetProdaLineDto
						{
							Schet_ID = schet.ID,
							Summa = (decimal)(товар.Сумма + (счет.СуммаВключаетНДС ? 0 : товар.СуммаНДС)),
							Penalty = (decimal)товар.sc_Штраф,
							Object_ID = obj?.ID ?? 0,
						};

						schet.Penalty += line.Penalty;
						schet.Detail_ID = db.GetOrNew<CDetailProdaDto>(товар.Номенклатура.Наименование)?.ID ?? 0;
						line.Service_ID = schet.Detail_ID;
						db.Insert(line);
					}
					if (status == "Оплачен") schet.Pay();
					db.Update(schet);
					whatUpdateService.AddAfterUpdate(schet);
				}
			}

			whatUpdateService.SaveFile();
			if (loaded.Any())
			{
				Otchet += $"Загружены счета:\n{string.Join("\n", loaded)}\n";
			}
			if (noLoaded.Any())
			{
				Otchet += $"Не загружены счета:\n{string.Join("\n", noLoaded)}\n";
			}
			if (deleted.Any())
			{
				Otchet += $"Помечены удалёнными счета:\n{string.Join("\n", deleted)}";
			}
			if (!loaded.Any() && !noLoaded.Any() && !deleted.Any())
			{
				Otchet += "Ничего не загружено";
			}
		}

		public static void LoadSingleSchet(CSchet schet)
		{
			if (!IsConnected)
			{
				Otchet = "Ошибка!\nНет соединения с 1С";
				Completed?.Invoke("LoadSingleSchet");
				return;
			}

			try
			{
				var Счета = _база1С.Документы.СчетНаОплатуПокупателю;
				var счет = Счета.НайтиПоНомеру(schet.Nomer, schet.DateCreate);
				счет = счет.ПолучитьОбъект();

				schet.DateCreate = счет.Дата;
				log($"Обновление счета № {schet.Nomer} от {schet.DateCreate:dd.MM.yyyy}");

				var sod = _база1С.СрокиОплатыДокументов;
				var so = sod.УстановленныйСрокОплаты(счет.Ссылка, счет.Организация.Ссылка);
				schet.DatePayTo = so ?? schet.DateCreate.AddDays(7);

				schet.Buyer.Change(счет.Контрагент.Наименование);
				schet.Firma.Change(счет.Организация.Наименование);

				string projName = счет.sc_Проект?.Наименование;
				var needFindProject = true;
				if (projName.NoEmpty())
				{
					schet.Project.Change(projName);
					needFindProject = false;
				}
				else
				{
					schet.Project.Change(GetProjectNameByINN(счет.Контрагент.ИНН));
				}

				schet.StDoho.Change(счет.sc_СтатьяДоходовДерево.Наименование);
				schet.Summa = счет.СуммаДокумента;
				schet.Comment = счет.Комментарий;

				var sd =_база1С.РегистрыСведений.СтатусыДокументов.ПолучитьСтатусыДокумента(счет.Ссылка, счет.Организация.Ссылка);

				schet.Shipped = _база1С.XMLString(sd.ДополнительныйСтатус) == "Отгружен";
				schet.Save();

				schet.Lines.DeleteAll();
				schet.Штраф = 0;
				foreach (var строка in счет.Товары)
				{
					string objName = строка.sc_Объект.Наименование;
					var obj = new CObject(objName);
					if (obj.ID > 0 &&
						obj.Project.Name.Length > 0 &&
						needFindProject &&
						schet.Project.Name != obj.Project.Name)
					{
						schet.Project.Change(obj.Project.Name);
					}

					var line = new Models.CSchetLine
					{
						Summa = строка.Сумма + (счет.СуммаВключаетНДС ? 0 : строка.СуммаНДС),
						Штраф = строка.sc_Штраф,
						Object = obj
					};

					schet.Штраф += line.Штраф;
					schet.Detail.Change(строка.Номенклатура.Наименование);

					line.Service_ID = schet.Detail.ID;
					schet.Lines.Add(line);
				}

				schet.Save();

				Otchet = "Обновление прошло успешно!";
				Completed?.Invoke("LoadSingleSchet");
			}
			catch
			{
				Otchet = "Обновление прошло с ошибкой!";
			}
		}

		public static void LoadOplatas(DateTime start, DateTime end, List<CSchetProdaDto> schets = null)
		{
			var startMin = new DateTime(2020, 1, 1);
			if (start < startMin) start = startMin;
			if (end < startMin) end = startMin;
			var isFirst = schets == null;
			var stepTxt = $"{(isFirst ? "Первый этап " : "Второй этап ")} с {start:dd.MM.yyyy} по {end:dd.MM.yyyy}";
			Logger.Debug($"LoadOplatasProda {stepTxt}");
			Progress?.Invoke($"{stepTxt}\n...");
			if (isFirst)
			{
				Otchet = "Обновлены оплаты по счетам";
				schets = new List<CSchetProdaDto>();
			}
			Otchet += $"\n\n{stepTxt}:\n";

			using (var db = new DbContext())
			{
				var оплата = _база1С.Документы.ПоступлениеНаРасчетныйСчет.Выбрать(start, end);
				var prevIds = schets.Select(s => s.ID).ToArray();
				while (оплата?.Следующий() ?? false)
				{
					DateTime dateOplata = оплата.Дата;
					var sumOplata = (decimal)оплата.СуммаДокумента;
					foreach (var расшифровкаПлатежа in оплата.РасшифровкаПлатежа)
					{
						var счет = расшифровкаПлатежа.СчетНаОплату;
						if (счет == null)
						{
							Logger.Debug($"счет == null | Дата: {dateOplata} | Сумма: {sumOplata}");
							continue;
						}

						string nomer = счет.Номер;
						DateTime dateSchet = счет.Дата;
						var schet = db.GetTable<CSchetProdaDto>()
							.FirstOrDefault(s => s.Nomer == nomer &&
												 s.DataCreate.Year == dateSchet.Year &&
												 !s.IsDeleted &&
												 (isFirst || prevIds.Contains(s.ID)));
						if (schet == null)
						{
							Logger.Debug($"schet == null | Дата оплаты: {dateOplata} | Сумма оплаты: {sumOplata} " +
								$"| nomerInternal: {nomer} | Дата счёта: {dateSchet}");
							continue;
						}

						if (isFirst && !schets.Any(s => s.ID == schet.ID))
						{
							Logger.Debug($"DeleteOplatas schet.ID: {schet.ID} OplataBefore:{schet.Oplata}");
							db.GetTable<COplataProdaDto>()
								.Where(o => o.Schet_ID == schet.ID)
								.Where(o => o.Data >= startMin)
								.Delete();
							schets.Add(schet);
							Otchet += $"{schets.Count}) {schet}\n";
							Progress?.Invoke($"{stepTxt}\nОбновление оплат по счёту {schet}");
						}

						var oplata = new COplataProdaDto
						{
							Data = оплата.Дата,
							Schet_ID = schet.ID,
							Summa = (decimal)расшифровкаПлатежа.СуммаПлатежа,
							User = Environment.UserName,
						};
						db.Insert(oplata);
						Logger.Debug($"Insert(oplata) schet.ID: {schet.ID} nomerInternal: {nomer} {oplata}");
					}
				}
				schets.ForEach(s => s.UpdateOplatas());
				if (schets.Any() && isFirst && schets.Min(s => s.DataCreate) < start)
				{
					LoadOplatas(schets.Min(s => s.DataCreate), start, schets);
				}
				if (!schets.Any()) Otchet += "Ничего не загружено";
			}
		}

		private static string GetProjectNameByINN(string konInn)
		{
			if (konInn == "") return "";

			var проект = _проекты.Выбрать();
			while (проект?.Следующий() ?? false)
			{
				foreach (var к in проект.Контрагенты)
				{
					if (к.Контрагент.ИНН == konInn)
					{
						return проект.Наименование;
					}
				}
			}
			return "";
		}

		public static bool UploadOneServiceTo1C(int sid)
		{
			if (!IsConnected) return false;

			var Справочники = _база1С.Справочники;
			var Номенклатура = Справочники.Номенклатура;
			var ПапкаНовое = Номенклатура.НайтиПоНаименованию("_ММСервис+СвиссКлин УСЛУГИ ПРОДАЖА НОВЫЕ");

			var svc = new CDetail(sid);
			var art = svc.ID.ToString();
			var Услуга = _база1С.Справочники.Номенклатура.СоздатьЭлемент();
			Услуга.Наименование = svc.Name;
			Услуга.НаименованиеПолное = svc.Name;

			Услуга.Услуга = true;
			Услуга.ВидНоменклатуры = _база1С.Справочники.ВидыНоменклатуры.НайтиПоНаименованию("Услуги");
			Услуга.ЕдиницаИзмерения = _база1С.Справочники.КлассификаторЕдиницИзмерения.НайтиПоНаименованию("усл");
			Услуга.ВидСтавкиНДС = _база1С.Перечисления.ВидыСтавокНДС.Общая;
			Услуга.Артикул = art;

			Услуга.Родитель = ПапкаНовое;
			Услуга.Записать();

			return true;
		}

		public static bool UploadServicesTo1C()
		{
			if (!IsConnected) return false;

			var Справо = _база1С.Справочники;
			var Номенк = Справо.Номенклатура;
			var ПапкаНовое = Номенк.НайтиПоНаименованию("_ММСервис+СвиссКлин УСЛУГИ ПРОДАЖА НОВЫЕ");
			List<CDetail> Services = new CDetails();

			var c = 0;
			foreach (var svc in Services)
			{
				c++; var art = c + " - " + svc.ID.ToString();
				log(art);

				var sn = svc.Name.Length > 100 ? svc.Name.Substring(0, 100) : svc.Name;
				var Услуга = Номенк.НайтиПоНаименованию(sn, 1, ПапкаНовое);
				log(Услуга.Наименование + "/" + sn);
				if (Услуга.Наименование == "")
				{
					log("in - " + sn);
					Услуга = Номенк.СоздатьЭлемент();
					Услуга.Наименование = svc.Name;
					Услуга.НаименованиеПолное = svc.Name;

					Услуга.Услуга = true;
					Услуга.ВидНоменклатуры = Справо.ВидыНоменклатуры.НайтиПоНаименованию("Услуги");
					Услуга.ЕдиницаИзмерения = Справо.КлассификаторЕдиницИзмерения.НайтиПоНаименованию("усл");
					Услуга.ВидСтавкиНДС = _база1С.Перечисления.ВидыСтавокНДС.Общая;
					Услуга.Артикул = art;

					Услуга.Родитель = ПапкаНовое;
					Услуга.Записать(); log(svc.Name + ".Записать()");
				}
				else
				{
					if (Услуга.Артикул != art)
					{
						Услуга = Услуга.ПолучитьОбъект();
						Услуга.Артикул = art;
						Услуга.Записать();
					}
				}
			}
			var Услуга1C = _база1С.Справочники.Номенклатура.Выбрать(ПапкаНовое);
			while (Услуга1C?.Следующий() ?? false)
			{
				c--;
			}

			return c == 0;
		}

		public static CDetails GetServicesFrom1C()
		{
			if (!IsConnected) return null;

			var ПапкаНовое = _база1С.Справочники.Номенклатура.НайтиПоНаименованию("_ММСервис+СвиссКлин УСЛУГИ ПРОДАЖА НОВЫЕ");

			var services = new CDetails("empty");

			var Услуга = _база1С.Справочники.Номенклатура.Выбрать(ПапкаНовое);
			while (Услуга?.Следующий() ?? false)
			{
				string sn = Услуга.НаименованиеПолное;
				sn = sn.Replace('\n', ' ').TrimEnd(' ');
				string ar = Услуга.Артикул;
				var id = 0;
				if (ar.Contains(" - "))
					id = G._I(ar.Split('-')[1].Trim(' '));
				var d = new CDetail() { ID = id, Name = sn };
				services.Add(d);
			}

			return services;
		}

		private static void log(string msg)
		{
			Progress?.Invoke(msg);
		}
	}
}
