﻿using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Закупки")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Закупки")]
[assembly: AssemblyCopyright("UltraZoom © 2019-2020")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]
// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("9006f149-aa49-4b8e-ba69-386d945fa738")]
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("4.1.0.7")]
[assembly: AssemblyFileVersion("4.1.0.7")]
[assembly: NeutralResourcesLanguage("en-US")]
/* 
 * Закупки 4.1.0.7 - 26.08.2020 FS
 * Внесены корретировки в фильтр по складам
 * Убрана ошибочная фраза "не найден склад"
 * Во вкладке Услуги и Накладные Кнопки переместить и списать накладную активны только при нажатом фильтре "Из 1С"
 * В окне редактирования накладной добавлено поле Организация
 *
 * Закупки 4.1.0.6 - 25.08.2020 FS
 * Добавлена вкладка Оплаты
 *
 * Закупки 4.1.0.5 - 04.08.2020 FS
 * Добавлен фильтр счетов по диапазону дат оплат
 *
 * Закупки 4.1.0.4 - 03.08.2020 FS
 * Добавлено создание кэша при загрузке оплат из 1С для более быстрого попадания таких счетов в кассу
 * Быстрое создание кэша в кассе при загрузке деталей счетов со статусом "Оплачен" также сохранено
 *
 * Закупки 4.1.0.3 - 31.07.2020 FS
 * Добавлена возможность загрузки ранее удалённых счетов
 * Повышена отказоустойчивость алгоритма загрузки из 1С
 *
 * Закупки 4.1.0.2 - 28.07.2020 FS
 * Столбец Организация во вкладке Услуги и Накладные заполняется по организации, указанной в поступлении
 *
 * Закупки 4.1.0.1 - 24.07.2020 FS
 * Восстановлено добавления кэша в кассу после выгрузки счетов из 1С
 *
 * Закупки 4.1.0.0 - 24.07.2020 FS
 * Вкладка "Накладные". Стало возможным перемещать целиком накладную и произвольные единичные товары на объект
 * при помощи кнопки "Переместить накладную"
 * Вкладка "Накладные". Стало возможным списывать целиком накладную и произвольные единичные товары 
 * при помощи кнопки "Списать накладную"
 * Вкладка "Услуги". Стало возможным перемещать целиком накладную и произвольные единичные товары на объект
 * при помощи кнопки "Переместить услугу"
 * Вкладка "Услуги". Стало возможным списывать целиком накладную и произвольные единичные товары
 * при помощи кнопки "Списать услугу"
 * СКЛАД - по двойному клику на товар или по кнопке "Переместить поступление" создаётся накладная только с этим товаром
 * СКЛАД - по правому клику на товаре или по кнопке "Списать поступление" создаётся списание только с этим товаром
 * Улучшены окна "Редактирование накладной" и "Создание накладной"
 * В соответствии с новыми данными настроен доступ к редактированию в окне "Редактирование накладной"
 * В зависимости от роли пользователя и вида накладной (из 1с или перемещение)
 *
 * Закупки 4.0.9.9 - 22.07.2020 FS
 * Откорректирована загрузка услуг из 1С
 * Откорректировано отображение столбца "из объекта" во вкладке Услуги и Накладные
 * Добавлен запрет на изменение накладных, в которых присутствуют поступления, которые уже разнесены по другим объектам
 * Окно создания накладной адаптировано под маленький монитор
 * Окно редактирования накладной изменено по подобию окна создания накладной
 *
 * Закупки 4.0.9.8 - 20.07.2020 FS
 * Добавлен фильтр типа поступления во вкладке Склад
 * В окне добавления поступлений на склад добавлен выпадающий список в столбце Номенклатура
 * Произведена оптимизация работы фильтра типа поступления во вкладке Объекты
 *
 * Закупки 4.0.9.7 - 15.07.2020 FS
 * Восстановлен доступ бухгалтеру к кнопкам обмена 1С
 *
 * Закупки 4.0.9.6 - 15.07.2020 FS
 * Исправлен баг с отображением товаров во вкладке услуги
 * Вкладку Склад видят админ, директор, менеджер закупок и кладовщик
 * Редактирование накладных доступно админу всегда и всех накладных.
 * Остальным только накладных-перемещений, дата которых больше даты, указанной админом в личном кабинете в поле "Редактировать с"
 * То же с накладными услуг.
 * Во вкладке Услуги добавлен фильтр услуги из 1с и услуги-перемещения
 *
 * Закупки 4.0.9.5 - 14.07.2020 FS
 * Устранён баг при оплате авансовых отчётов при загрузке
 * Оптимизировано чтение счетов из базы данных
 * В окне загрузки счетов из 1с добавлена видимость удалённых счетов
 *
 * Закупки 4.0.9.4 - 12.07.2020 FS
 * Оптимизирована загрузка окна редактора счетов
 *
 * Закупки 4.0.9.3 - 12.07.2020 FS
 * Устранён баг с отображением накладных - перемещений
 * Кнопка "Перемещение" переименована в "Накладные - перемещения"
 * Исправлена проблема идентификации счетов. При смене фирмы теперь не должен создаваться новый счёт, должен обновляться старый.
 * Это касается счетов не ранее 2020 года и в этом году нужно проверить 66 счетов из файла. Скорее всего они вручную созадны, поэтому не удалось найти их идентификатор в 1с.
 * Исправлен баг загрузки из 1с одиночного счёта.
 * Улучшено окно сравнения старых значений счетов и новых при загрузке из 1с:
 * Для удобства сравнения синхронизированы прокрутка, выбор строки, столбца, фильтры, ширина и распорложение столбцов двух таблиц.
 * Например, при изменении ширины столбца в одной таблице во второй ширина соответствующего столбца также поменяется.
 * Оптимизирована производительность окна выбора объекта
 * 
 * Закупки 4.0.9.2 - 09.07.2020 FS
 * Устранён баг с оплатой авансовых платежей при загрузке их из 1с
 *
 * Закупки 4.0.9.1 - 08.07.2020 FS
 * Для проектов, указанных в модуле "Объекты" как невидимые в складе, поступления отгружаться не будут 
 *
 * Закупки 4.0.9.0 - 23.06.2020 FS
 * Добавлен фильтр счета/авансовые отчёты на вкладке Счета
 * Устранена проблема с доступом по пути C:\ProgramData\SCAS
 *
 * Закупки 4.0.8.9 - 18.06.2020 FS
 * Откорректирован выбор дат при загрузке из 1С услуг и накладных
 * На вкладке счета добавлен фильтр Неоплаченные
 * Убрана кнопка "Добавить в отгрузку" с вкладки Услуги
 * Админу добавлена возможность редактирования количества дней для редактирования накладных (вкладка накладные)
 * Во вкладке Склад добавлен функционал для добавления на склад поступлений, которых нет в 1С
 * 
 * Закупки 4.0.8.8 - 28.05.2020 FS
 * Фильтр по датам сделан отдельно в каждой вкладке
 *
 * Закупки 4.0.8.7 - 28.05.2020 FS
 * Исправлен баг в окне выбора объекта
 * Кнопка "Изменить накладную" и кнопка "Удалить накладную" теперь только у администратора
 * Во вкладке Счета добавлен фильтр "Контрагент"
 * Фильтры по датам размещены ближе к фильтру по организациям
 * Счета из 1С загружаются согласно фильтрам «Организация», «Фильтр по датам» и «Контрагент»
 * Авансовые платежи из 1С загружаются согласно фильтрам «Фильтр по датам»
 *
 * Закупки 4.0.8.6 - 26.05.2020 FS
 * Для администратора сделано возможным всегда вносить корректировки в накладную даже в старую
 * Вкладка "Накладные". Внизу накладной (в правой части) добаылены итоги по сумме денег и по количеству позиций.
 * Вкладка "Объекты". Удалены кнопки "Услуги" и "Аренда"
 *
 * Закупки 4.0.8.5 - 25.05.2020 FS
 * Добавлен фильтр "Организация" во вкладке "Объекты"
 * Добавлен фильтр "Организация" во вкладке "Услуги"
 * Изменён внешний вид вкладки "Услуги" по образцу "Накладные"
 * Изменён алгоритм загрузки услуг. Теперь услуги грузятся через накладные
 *
 * Закупки 4.0.8.4 - 22.05.2020 FS
 * в Складе добавлены кнопки Новая накладная и Списание
 * из вкладки Объекты убраны Склады 
 * на вкладке Объекты добавлен фильтр по диапазону дат
 *
 * Закупки 4.0.8.3 - 21.05.2020 FS
 * На вкладке Счета добавлен фильтр Организация
 * На вкладке Склад добавлен фильтр Склад
 *
 * Закупки 4.0.8.2 - 20.05.2020 FS
 * Скрыта кнопка загрузки налогов из Excel
 * В интерфейсе таблицы склада убраны лишние кнопки
 * На вкладке Счета добавлен столбец "Отгружено", убрано выделение жирным шрифтом
 *
 * Закупки 4.0.8.1 - 19.05.2020 FS
 * Добавлена вкладка склад
 *
 * Закупки 4.0.8.0 - 09.05.2020 FS
 * Вкладка "Поступления" переделана во вкладку "Услуги"
 * Загрузка товаров и услуг разделена на загрузку товаров и загрузку услуг
 * Загрузкка услуг осуществляется на не склад, а в буфер ("к порогу")
 *
 * Закупки 4.0.7.9 - 06.05.2020 FS
 * В редакторе статей расхода убран столбец "Категория"
 * Добавлено окно редактирования детализации
 * У детализации добавлены поля "Категория" и "Класс" (бывш.Категория)
 * Категория счета и авансового отчёта при загрузке из 1с берётся в соответствии с таблицей детализации из дерева
 * В качестве эксперимента на вкладке Счета применена умная настрока размера кнопок, которая адаптируется под размер экрана
 *
 * Закупки 4.0.7.8 - 01.05.2020 FS
 * Кнопка "Накладные от пользователей" переименована в "Перемещения"
 *
 * Закупки 4.0.7.7 - 30.04.2020 FS
 * Во вкладке Накладные добавлен столбец "Фирма"
 * Во вкладке Накладные добавлены фильтры "Фирма", "Накладные из 1с", "Накладные от пользователей"
 *
 * Закупки 4.0.7.6 - 29.04.2020 FS
 * При загрузке поступлений привязанные счета помещаются отгруженными
 * Отгруженные счета помечаются жирным шрифтом
 * Добавлен фильтр по складам для накладных
 * Добавлено окно редактирования статей расхода. Открыть это окно можно при помощи кнопки "Статьи расхода" на вкладке счета
 *
 * Закупки 4.0.7.5 - 28.04.2020 FS
 * При удалении накладной для всех позиций в ней будут удалены все накладные с последующими передвижениями этих позиций
 * Добавлена возможность группировки отображения товаров на объектах по номенклатуре
 * Накладные, не привязанные к объектам подсвечиваются красным как ошибочные
 * В случае ошибки поиска склада при загрузке накладных из 1с в столбце "На объект" пишет название искомого склада + "(не найдено)" 
 *
 * Закупки 4.0.7.4 - 27.04.2020 FS
 * В таблицу накладных добавлены столбцы: Контрагент, стоимость, доп.расходы, Итоговая стоимость, с Проекта, с Объекта
 * В подвале таблицы накладных добавлены итоговые суммы 
 * При группировке таблицы накладных добавлены итоговые суммы в подвалах и в строке группировки
 *
 * Закупки 4.0.7.3 - 15.04.2020 FS
 * Устранён баг загрузки авансовых отчётов.
 * Для поступлений, у которых не указан Склад исключена привязка к объектам с пустым именем
 *
 * Закупки 4.0.7.2 - 14.04.2020 FS
 * Исключено дублирование авансовых отчётов при смене номера 1С, например, при смене фирмы
 * Добавлено получение детализации и статьи расходов авансовых счетов
 * Добавлен доступ Руководителям проекта к вкладке "Счета" только для чтения
 *
 * Закупки 4.0.7.1 - 07.04.2020 FS
 * Добавлена загрузка счетов и поступлений на основании авансовых отчётов
 *
 * Закупки 4.0.7.0 - 27.03.2020 FS
 * Добавлена возможность экспорта в Excel акта списания материала на основе накладной
 * Улучшен поиск счёта для оплат
 *
 * Закупки 4.0.6.9 - 26.03.2020 FS
 * Настроено автоматическое сохранение состояния счетов (BackUp) перед загрузкой деталей счетов из 1С
 * Добавлена кнопка открытия папки с этими BackUp-ами
 * Настроена фильтрация проектов в соответствии с настройками проекта из модуля Объекты
 *
 * Закупки 4.0.6.8 - 20.03.2020 FS
 * Исправлен баг при нажатии на кнопку Ок в окне добавления товаров форма стала закрываться
 *
 * Закупки 4.0.6.7 - 20.03.2020 FS
 * Добавлена возможность добавления товаров на объект вручную
 *
 * Закупки 4.0.6.6 - 19.03.2020 FS
 * Откорректирован вывод товаров по проектам в Excel
 *
 * Закупки 4.0.6.5 - 18.03.2020 FS
 * Исправлен баг с выгрузкой счетов в excel
 *
 * Закупки 4.0.6.4 - 17.03.2020 FS
 * Добавлена категория счетов (прямые/косвенные расходы)
 *
 * Закупки 4.0.6.3 - 17.03.2020 FS
 * Добавлена стоимость доп.расходов в стоимость товаров
 *
 * Закупки 4.0.6.2 - 12.03.2020 FS
 * В окне создания накладной функция "Включить всё" стала работать с учётом фильтра
 * В окне создания накладной добавлена кнопка "Очистить"
 *
 * Закупки 4.0.6.1 - 12.03.2020 FS
 * Устранен баг при удалении накладной
 * Добавлена возможность копирования в буфер обмена текста отчёта после загрузки из 1С.
 *
 * Закупки 4.0.6.0 - 12.03.2020 FS
 * Интерфейс окна создания накладной выполнен по аналогии с интерфейсом 1с
 *
 * Закупки 4.0.5.9 - 02.03.2020 FS
 * Добавлено название накладной в списке поступлений на объекте и в окне перемещения товара
 * Исправлена ошибка создания перемещений с нулевым количеством
 * Внесены корректировки в алгоритмы обработки поступлений
 *
 * Закупки 4.0.5.8 - 28.02.2020 FS
 * Внесены корретировки в загрузку оплат из 1С.
 *
 * 4.0.5.7 - 24.02.2020 FS
 * При выгрузке поступлений из 1С они (поступления) автоматически попадают на склады.
 * При этом автоматически формируются накладные с номером из 1С.
 * Для позиций, не привязанных к складу, тоже формируются накладные, у которых не запонено поле "Объект"
 * (оно заполняется вручную во вкладке "Накладные" или накладная удаляется и после этого разносится попозиционно во вкладке "Поступления").
 * Вкладка "Поступления" теперь достпна только для админа и директора.
 * Списание и перемещение товара разделено на две кнопки.
 *
 * 4.0.5.6 - 21.02.2020 FS
 * Устранен баг с колчичеством перемещаемого товара
 *
 * 4.0.5.4 - 17.02.2020 FS
 * В окне перемещения товара теперь достаточно нужно ввести перемещаемое количество (без галочек) в колонке "Переместить"
 *
 * 4.0.5.3 - 17.02.2020 FS
 * Откорректирована загрузка оплат
 * В окне авторизации добавлен выпадающий список успешно авторизованных логинов для удобства перехода из одного профиля в другой
 *
 * 4.0.5.3 - 13.02.2020 FS
 * Устранён баг при перемещении товара
 *
 * 4.0.5.2 - 13.02.2020 FS
 * Корректировка загрузки оплат и деталей счетов с учётом удаленных счетов
 *
 * 4.0.5.1 - 11.02.2020 FS
 * При перемещении товара по умолчанию галочка "Переместить" отжата
 * Номенклатурный номер поступления теперь привян не к поступлению, а к распределённому по объектам инвентарю.
 * Номенклатурный номер Основных средств остался привязанным к поступлению и берётся из 1С
 *
 * 4.0.5.0 - 07.02.2020 FS
 * Устранён баг с счетами, по которым нет оплат, но они помечаются как оплаченные
 *
 * 4.0.4.9 - 07.02.2020 FS
 * Добавлена кнопка сброса настроек экрана (справа вверху, где кнопки сворачивания/разворачивания окна)
 *
 * 4.0.4.8 - 06.02.2020 FS
 * Добавлена возможность добавлять отрицательные оплаты для возврата денег.
 * Остаток счета определяется как Сумма счёта минус сумма всех положительных оплат.
 * Таким образом оплаченные счета с возвратом тоже имеют нулевой остаток и помечабются зелёным цветом.
 * При загрузке оплат из 1С отрицательные оплаты не удаляются.
 * Почти для всех окон приложения настроено сохранение почти всех настроек экрана при закрытии формы (ширина и видимость столбцов, группировка, положение разделителей и прочее)
 *
 * 4.0.4.7 - 06.02.2020 FS
 * Добавлено автоматическое создание оплат по счетам со статусом 'Оплачен'
 * Откорректированы значения количества позиций на объектах
 * Откоректированы позиции на складе
 * Откорретировано внесение изменений (Тип, Инвентарный номер) в таблице поступлений
 *
 * 4.0.4.6 - 05.02.2020 FS
 * Добавлены комментарии для поступлений.
 * 
 * 4.0.4.5 - 04.02.2020 FS
 * Откорректировано отображение остатков на объектах
 *
 * 4.0.4.4 - 03.02.2020 FS
 * Устранён баг при выборе даты "С"
 *
 * 4.0.4.3 - 31.01.2020 FS
 * Откорректирован фильтр по дате
 * 
 * 4.0.4.2 - 31.01.2020 FS
 * Устранена проблема с совпадением номера платёжного поручения и счёта при загрузке оплат из 1С
 * 
 * 4.0.4.1 - 30.01.2020 FS
 * Оптимизация производительности во вкладке "Объекты"
 * В таблице объектов добавлены: столбец "Количество позиций", итоговая строка, цветовая подсветка
 * Настроено отображение накладных во вкладке накладные
 * Добавлен фильтр "От меня", "Ко мне", "Списания" во вкладке накладные
 * Окно "Выбор объекта" сделан аналогично вкладке "Объекты" с количеством позиций, итоговой срокой и подсветкой
 * В окне "Выбор объекта" добавлены фильтры "Только склады" и "Мои-не мои объекты"
 * Откорректированы некоторые баги
 *
 * 4.0.4.0 - 29.01.2020 FS
 * Счета со статьёй расхода "Прочие 2" не попадают в базу данных
 * 
 * 4.0.3.9 - 28.01.2020 FS
 * Добавлена функция "Загрузить оплаты"
 * Добавлено сохранение режима выбора даты и самих дат при завершении работы программы
 * В поступлениях исключены позиции из других складов, даже при отжатой кнопке "Только мои поступления"
 * Исправлена ошибка при загрузке поступлений
 *
 * 4.0.3.8 - 24.01.2020 FS
 * В поступлениях добавлен фильтр "Только мои поступления"
 *
 * 4.0.3.7 - 24.01.2020 FS
 * Добавлен вход по логину и паролю и разделенеие по ролям:
 * Бухгалтер - все счета
 * Менеджер закупок - счета кроме кэша, поступления, накладные, объекты
 * Кладовщик - поступления, накладные, объекты
 * Админ и Директор - всё
 * Во вкладке "Объекты" добавлен фильтр "Только склады"
 *
 * 4.0.3.6 - 20.01.2020 FS
 * Добавлен фильтр по месяцам
 * Добавлен переключатель на фильтр по месяцам/по датам
 * Загрузка из 1С стала производиться по выбранному периоду 
 *
 * 4.0.3.5 - 20.01.2020
 * Добавлено обновление одного счёта из 1С в редакторе счёта
 *
 * 4.0.3.4 - 17.01.2020
 * Кнопка Оплатить Счет добавляет одну оплату с учетом ранее введенных оплат,
 * а именно на сумму (Сумма счета) - (Сумма ранее введенных оплат)
 *
 * 4.0.3.3 - 15.01.2020
 * Загрузка поступлений только в статусе проведет
 * Статистика по зогрузке поступлений
 *
 * 4.0.3.2 - 07.01.2020
 * Устранён баг при загрузке, связанный с началом года
 *
 * 4.0.3.1
 * Если счёт не проведён в 1С или у него в 1С статус "Отменен", то при загрузке счёт в нашей БД помечается как удалённый
 * Добавлена возможность подсветки счетов, загруженных сегодня и обновлённых значений
 * --------------------
 * 4.0.3.0
 * Устранены баги с нулевыми оплатами при загрузке счетов из 1с
 * Устранен баги с оплатой счёта
 * --------------------
 * 4.0.2.9
 * 1 - Добавлен фильтр месяца для поступлений и накладных
 * 2 - Устранены баги при загрузке счетов из 1с
 * 3 - Внесены изменения в интерфейс
 * --------------------
 * 4.0.2.8
 * 1 - Исправлен баг при сохранении накладной
 * 2 - При загрузке счета обновляются 
 * 3 - При загрузке счета Склад 2 и Склад прочее добавляются в кэш 
 * --------------------
 * 4.0.2.7
 * 1 - Добавлено автоматическое добавление счетов Кэша на рассмотрение в кассу
 * --------------------
 * 4.0.2.6
 * 1 - Добавлен Excel-отчёт расходов по проектам
 * --------------------
 * 4.0.2.5
 * 1 - Объедененная версия
 * --------------------
 * 4.0.2.4
 * 1 - Добавлена дата поступления товара в закладке "Объекты" и в окне перемещения поступлений
 * --------------------
 * 4.0.2.3
 * 1 - Добавлена фильтрация по типам поступлений 
 * 2 - Добавлена возможность удаления загруженного из 1С поступления
 * 3 - Реализовано обновление поступления в случае изменения в 1С уже после загрузки
 * --------------------
 * 4.0.2.2
 * 1 - Добавил тип поступления(товары, услуги, аренда, ..)
 * 2 - Доблено поле Контрагент
 * --------------------
 * 4.0.2.1
 * 1 - Исправил баг с Фирмой
 * --------------------
 * 4.0.2.0
 * 1 - Ким не видит счета со Склад 2 и Склад прочее
 * --------------------
 * 4.0.1.9
 * 1 - Добавлена колонка внутренний номер 1С - № 1С
 * --------------------
 * 4.0.1.8
 * 1 - Добавлена загрузка поля Фирма из 1С
 * --------------------
 * 4.0.1.7
 * 1 - Изменено имя базы с DB1C на SwissAcc
 * 2 - Проверяется и сохраняется статус оплаты счета
 * --------------------
 * 4.0.1.6
 * 1 - добавлена возможность группировки в таблицах счетов, поступлений и накладных
 * --------------------
 * 4.0.1.5
 * 1 - Изменено имя базы с Accounting на DB1C
 * 2 - Обновлена версия ComConnector
 * 4.0.1.4
 * 1 - добавлена колонка/поле Фирма (юр.лицо Свисс ООО или ММС)
 * --------------------
 * 4.0.1.3
 * 1 - убрал проверку дублирования линий при загрузке из 1С
 * 2 - добавил сообщение об итогах загрузки из 1С
 * 3 - обновил картинрку заставки
 * ---------------
 * 4.0.1.2
 * 1 - В счет добавил поле NomerInternal это для идентификации загруженных счетов
 * 2 - Удаление в списке счетов поменял на MarkAsDeleted
 * 3 - Метод счета Delete оставил на форме редактора счета и пишет лог
 * --------------------
 * 4.0.1.1
 * 1 - Заставка
 * --------------------
 4.0.1.0
 1 - На форме редактирования счета, комбо Детализация сделал не редактируемым
 2 - В базе в таблице Detail добавил поле IsActual
 3 - в моделе CDetails вставил where IsActual=1
 4 - На форме редактирования счета теперб будет только актуальные Детализации
 ------------------------
 4.0.0.9
 1 - в Programm.cs добавил SplashScreenManager.ShowForm(typeof(Forms.WaitForm1));
 2 - Переключил 1С на localhost

*/