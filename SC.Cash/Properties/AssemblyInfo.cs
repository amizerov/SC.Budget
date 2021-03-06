using System.Reflection;
using System.Runtime.InteropServices;

// Общие сведения об этой сборке предоставляются следующим набором
// набора атрибутов. Измените значения этих атрибутов для изменения сведений,
// связанных со сборкой.
[assembly: AssemblyTitle("SC.Cash")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Касса")]
[assembly: AssemblyCopyright("Copyright © 2019-2020")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Установка значения False для параметра ComVisible делает типы в этой сборке невидимыми
// для компонентов COM. Если необходимо обратиться к типу в этой сборке через
// COM, следует установить атрибут ComVisible в TRUE для этого типа.
[assembly: ComVisible(false)]

// Следующий GUID служит для идентификации библиотеки типов, если этот проект будет видимым для COM
[assembly: Guid("e15ddb19-9f95-4b80-9a3a-3bc56e5dc81c")]

// Сведения о версии сборки состоят из указанных ниже четырех значений:
//
//      Основной номер версии
//      Дополнительный номер версии
//      Номер сборки
//      Редакция
//
// Можно задать все значения или принять номера сборки и редакции по умолчанию 
// используя "*", как показано ниже:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.3.3")]
[assembly: AssemblyFileVersion("1.0.3.3")]

/* Касса 1.0.3.3 - 26.05.2020 FS
 * Добавлена кнопка "Выписка по счёту" с выгрузкой выписки в эксель
 *
 * Касса 1.0.3.2 - 18.05.2020 FS
 * Исправлен баг с отправкой багов разрабочику
 *
 * Касса 1.0.3.1 - 14.05.2020 FS
 * Запрещен пересчёт зарплат в закрытом табеле
 *
 * Касса 1.0.3.0 - 22.04.2020 FS
 * При создании кэша создаётся две операции - основная и коммиссия
 *
 * Касса 1.0.2.9 - 16.04.2020 FS
 * Откорректирован выпадающий список проектов в окне создания запроса
 * Добавлен столбец "Не выдано" в таблицу запросов
 *
 * Касса 1.0.2.8 - 01.04.2020 FS
 * Улучшен интерфейс заметок для директора
 *
 * Касса 1.0.2.7 - 31.03.2020 FS
 * Добавлена возможность шифрования заметок для директора
 * Устранено несколько некритичных багов
 *
 * Касса 1.0.2.6 - 25.03.2020 FS
 * Выпадающие списки проектов отфильтрованы в соответствии с параметром проекта "Отображать в Кассе", который настраивается в Объектах.
 * Для руководителя проекта в выпадающие списки попадают только свои проекты
 * Поправлены некритичные баги
 *
 * Касса 1.0.2.5 - 11.03.2020 FS
 * Устранён баг при создании прихода без отправителя
 * При закрытии формы значение в поле "Месяц" сохраняется
 *
 * Касса 1.0.2.4 - 10.03.2020 FS
 * Добавлено ведение истории операций.
 * При пересчёте зарплат начиная с 1 января 2020г теперь зарплата и аванс будут точно совпадать по сумме с операциями
 * Записи обо всех редактированиях, отменах и созданиях операций сохраняются в отдельной БД
 * Автоматизировано отправление сообщений о явных багах и получение информации о планируемой дате решения проблемы
 *
 * Касса 1.0.2.3 - 05.03.2020 FS
 * Улучшен пересчёт остатков при создании/изменении/отмене операций
 * Откорректирован пересчёт зарплат
 *
 * Касса 1.0.2.2 - 04.03.2020 FS
 * Внесены корретировки в методы создания/изменения/отмены операций.
 * Добалена кнопка для админа "Пересчитать все зарплаты на основании операций"
 *
 * Касса 1.0.2.1 - 03.03.2020 FS
 * Добавлена категория операций "Кредит"
 * Откорректировано отображение запросов
 *
 * Касса 1.0.2.0 - 02.03.2020 FS
 * У запроса добавлена возможность частичной выдачи при помощи поля "Выдано"
 *
 * Касса 1.0.1.9 - 01.03.2020 FS
 * В окне редактирования операции добавлены свойства "Месяц" и "Проект"
 * Запросу добавлено свойства "Месяц" и "Проект"
 * Кэшу добавлены свойства "Месяц" и "Проект"
 * Месяц при рассмотрении кэша по умолчанию присваивается как предыдущий
 *
 * Касса 1.0.1.8 - 27.02.2020 FS
 * Для операции добавлены свойства "Месяц" и "Проект"
 * Добавлен переключатель "Фактический долг" и расчётный ("К выдаче" из табеля минус сумма всех операций с категорией "зарплата")
 * Добавлен переключатель "Долг по месяцам/ общий"
 * Долги и начислено отображаются за предыдущий месяц
 * Внесены корректировки в расчёт долгов
 *
 * Касса 1.0.1.7 - 26.02.2020 FS
 * Устранён баг при создании операции под руководителем проекта
 *
 * 1.0.1.6 - 24.02.2020 FS
 * Добавлена возможность закрытия счёта
 * Добавлена возможность создавать операции от директора к директору
 * Добавлена возможность создавать пассивные счета для директора
 *
 * 1.0.1.5 - 20.02.2020 FS
 * Добавлена возможность редактирования операций.
 * Добавлен столбец "Долги" и отдельное окно для них
 * Добавлен столбец "Начислено" и отдельное окно для них
 * В окне "Без получателя" добавлены подробности в заголовок
 * Кнопки управления операциями перенесены ближе к таблице с операциями
 * Добавлены категории операций: "Командировочные", "Комиссия банка"
 * В окне авторизации добавлен выпадающий список успешно авторизованных логинов для удобства перехода из одного профиля в другой
 * В Excel-отчёт Кэша добавлено поле "Фирма"
 *
 * 1.0.1.4 - 11.02.2020 FS
 * Добавлено окно с заметками(Добавление, Редактирование, Удаление заметок)
 *
 * 1.0.1.3 - 10.02.2020 FS
 * Добавлена возможность уведомления по почте о новых запросах
 * Для всех отчётов Excel настроена автоширина стоблцов
 * Добавлены категории операций "Химчистка" и "Материалы"
 * В окне Кэша добавлено поле "Фирма"
 * В таблице кэша добавлены итоги
 * Таблица кэша улучшена для группировки (добавлена информация об итоговых суммах)
 * Сделан единый фильтр дат операций и запросов.
 * Добавлено сохранение режима выбора даты и самих дат при завершении работы программы
 * Почти для всех окон приложения настроено сохранение почти всех настроек экрана при закрытии формы (ширина и видимость столбцов, группировка, положение разделителей и прочее)
 * Добавлена кнопка сброса настроек экрана (справа вверху, где кнопки сворачивания/разворачивания окна)
 * 
 *
 * 1.0.1.2 - 15.01.2020
 * Добавлена возможность просмотра операций без получателя в отдельном окне
 * При рассмотрении кэша добавлена возможность выбирать дату операции перевода в кассу
 * Устранена проблема с вводом копеек
 *
 * 1.0.1.1 - 14.01.2020
 * Добавлен фильтр операций по месяцам
 * Добавлен переключатель на фильтр по месяцам/по датам
 * Добавлен отчёт в Excel по рассмотренному кэшу
 * При изменении периода программа стала выделять (по возможности) тот же счёт в таблице счетов
 *
 * 1.0.1.0 - 09.01.2020
 * Устранён баг при пересчитывании зарплаты
 *
 * 1.0.0.9 - 08.01.2020
 * Добавлена всплывающая подсказка в таблице операций с ролью и логином пользователей
 * При отмене операции выдачи денег сотруднику проиходит пересчёт зарплаты и долга
 *
 * 1.0.0.8
 * Добавлена функция обработки кэша
 * 
 * 1.0.0.7
 * В окне "Новый приход" Директору добавлена возможность выбирать самого себя в поле "Кому"
 * 
 * 1.0.0.6
 * Добавлена категория операций "Личное"
 * 
 * 1.0.0.5
 * Приход без счёта стал доступен еще и директору
 * 
 *  1.0.0.4
 * Добавлен выбор категории в окне "Новая операция"
 * 
 * 1.0.0.3
 * Добавлено создание ордеров
 * Добавлено создание приходов без счёта
 * Убраны итоги по счетам
 * 
 * 1.0.0.2
 * Корректировка арифметики на закладке "Операции"
 * Ввод комментариев запроса сделан многострочным
 * Добавлена форма редактирования запроса по двойному клику на запросе
 * Добавлены итоговые суммы в подвалах таблиц и в строчке группировки
 * Добавлена возможность операции без получателя.
 * 
 * 1.0.0.1
 * Изменения по результатам тестирования
 * Улучшен фильтр запросов
 *
 */
