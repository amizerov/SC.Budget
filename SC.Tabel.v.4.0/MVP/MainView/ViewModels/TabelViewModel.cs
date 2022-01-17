using SC.Common.Model;
using SwissClean.Dal.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SwissClean.MVP.MainView.ViewModels
{
	public class TabelViewModel
	{
		public int ID { get; set; } //в базе Tabel
		public int Object_ID { get; set; } //в базе Resource
		public int Resource_ID { get; set; } //в базе Resource
		public int? ResOP_ID { get; set; } //в базе Tabel

		[DisplayName("Дата")]
		public DateTime Date { get; set; } //в базе Tabel

		[DisplayName("Выход")]
		public bool IsExit { get; set; } //нет в базе


		public static TabelViewModel[] Factory(CResOPDto resOp, DateTime month, List<CTabel> tabels)
		{
			if (resOp == null) return Array.Empty<TabelViewModel>();

			var start = new DateTime(month.Year, month.Month, 1);
			var count = DateTime.DaysInMonth(month.Year, month.Month);

			var res = new TabelViewModel[count];
			for (int i = 0; i < count; i++)
			{
				var date = start.AddDays(i);
				var tabel = tabels?.FirstOrDefault(t => t.Date?.Date == date.Date);
				res[i] = new TabelViewModel
				{
					ID = tabel?.ID ?? -1,
					Object_ID = resOp.Object_ID ?? -1,
					Resource_ID = resOp.Resource_ID,
					ResOP_ID = resOp.ID,
					Date = date,
					IsExit = tabel?.IsExit ?? false,
				};
			}

			return res;
		}
	}
}
