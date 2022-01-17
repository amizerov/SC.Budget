using System.Reflection;
using System.Runtime.InteropServices;
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("SC.Budget.v._4")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("SCAS")]
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
[assembly: AssemblyVersion("1.0.1.4")]
[assembly: AssemblyFileVersion("1.0.1.4")]

/*
 * Личный кабинет: 1.0.1.4 - 06.08.2020 FS
 * Изменён отчёт KPI в соотвтетствии с новой формой
 * 
 * Личный кабинет: 1.0.1.3 - 12.07.2020 FS
 * Для админа добавлена возможность менять дату редактирования.
 * Сам запрет редактирования в зависимости от этой даты будет реализован отдельно
 *
 * Личный кабинет: 1.0.1.2 - 12.07.2020 FS
 * Улучшено окно выбора объекта
 *
 * Личный кабинет: 1.0.1.1 - 07.07.2020 FS
 * Добавлена функция отчёта маржинальности объекта
 *
 * Личный кабинет: 1.0.1.0 - 10.03.2020 FS
 * Автоматизировано отправление сообщений о багах и получение информации о планируемой дате решения проблемы
 *
 * Личный кабинет: 1.0.0.9 - 06.03.2020 FS
 * Устранён баг при отображении входящего остатка у Кассы
 *
 * 1.0.0.8 - 01.03.2020
 * У кассы добавлено отображение входящего остатка
 * В окне авторизации добавлен выпадающий список успешно авторизованных логинов для удобства перехода из одного профиля в другой
 *
 * 1.0.0.7 - 24.01.2020
 * Исправлена ошибка при формировании маржинальности
 *
 * 1.0.0.6 - 21.01.2020
 * Добавлена роль "Кладовщик"
 * По нажатию на кнопке "Перейти" переход осуществляется на актуальную версию соответствующего модуля
 * 
 * 1.0.0.5
 * Переделана арифметика согласно замечаниям Гоар
 * Откорректирована маржинальность для директора
 * Название листа в KPI стало присвавиваться по названию проекта
 * 
 * 1.0.0.4
 * Добавлен модуль "Касса"
 * Добавлена детализация статистики
 * 
 * 1.0.0.3
 * Добавлена детализация расходов в отчётности
 * Отчёты маржинальности и KPI выведены в фоновый поток
 * Добавлено отображение прогресса выполнения отчёта в панели задач
 * 
 *  1.0.0.2
 *  Добавлены отчёты маржинальности и KPI
 * 
 *  1.0.0.1
 *  Добавлены графики
 */
