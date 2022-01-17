using LinqToDB.Mapping;
using SC.Common.Views;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using LinqToDB.SqlQuery;
using SC.Common.Services;

namespace SC.Common.Model
{
	[Table("Bug")]
	public class CBugDto
	{
		[PrimaryKey, Identity] public int ID { get; set; }

		[DisplayName("Решение")]
		[Column] public string Solution { get; set; }

		[DisplayName("Проект")]
		[Column] public string Project { get; set; }

		[DisplayName("Сообщение")]
		[Column] public string Message { get; set; }
		[Column] public string InfoToDeveloper { get; set; }

		[DisplayName("Снимок экрана")]
		[Column] public byte[] PrintScreen { get; set; }
		[Column] public string User { get; set; }


		[DisplayName("Дата исправления")]
		[Column] public DateTime? DateSolved { get; set; }


		[DisplayName("Сообщение пользователю")]
		[Column] public string InfoToUser { get; set; }


		[Column(SkipOnInsert = true, SkipOnUpdate = true)]
		[DisplayFormat(DataFormatString = "dd.MM.yy hh:mm")]
		public DateTime dtc { get; set; }

		public static void Report(Exception ex, IWin32Window owner, string infoToDeveloper = null)
		{
#if DEBUG
			MessageService.ShowError(ex.ToString());
			return;
#endif
			var message = ex.ToString();
			if (message.Contains("Время ожидания выполнения истекло") ||
			   message.Contains("Сервер не найден или недоступен") ||
			   message.Contains("сервер не отвечает") ||
			   message.Contains("Ошибка на транспортном уровне при получении результатов с сервера"))
			{
				MessageService.ShowError("Произошла ошибка подключения к серверу SQL.\n" +
										"Обратитесь к системному администратору.\n\n" +
										 $"{ex.Message}");
				return;
			}
			if (ex is SqlException && message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
			{
				MessageService.ShowError("Ошибка удаления.\nВозможно запись используется и не может быть удалена");
				return;
			}
			if (ex is UnauthorizedAccessException && message.Contains("Отказано в доступе по пути"))
			{
				MessageService.ShowError("Произошла ошибка доступа к файлу или папке.\n" +
				                         "Обратитесь к системному администратору.\n\n" +
				                         $"{ex.Message}");
				return;
			}

			using (var form = new FrmReportBug(ex, infoToDeveloper))
			{
				if (owner != null) form.ShowDialog(owner);
				else form.ShowDialog();
			}
		}
	}
}
