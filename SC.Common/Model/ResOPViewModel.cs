using SC.Common.Services;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace SC.Common.Model
{
	public enum ObjType { Project, Object, ResOP, Summary }

	[DebuggerDisplay("{ViewModelID}")]
	public class ResOPViewModel : IViewModel, ICloneable
	{
		public ObjType Type { get; set; } //нет в базе
		public string ID { get; set; } //нет в базе
		public string ViewModelID => ID; //нет в базе. Костыль, чтобы реализовать IViewModel
		public string ParentID { get; set; } //нет в базе

		public int? ResOP_ID { get; set; } //в базе ResOP
		public int Project_ID { get; set; }
		public int Object_ID { get; set; } //в базе ResOP
		public bool IsClosed { get; set; } //в базе TabelClosed
		public string ObjectNameForResOp { get; set; } //в базе Object
		public int? ManagerID { get; set; } //в базе ResOP

		[DisplayName("В штате")]
		public bool IsStaff { get; set; } //нет в базе

		[DisplayName("Уволен")]
		public bool NoWorking { get; set; }
		public int NoWorkingCount { get; set; }
		//public int PositionID { get; set; } //в базе ResOP

		public int Resource_ID { get; set; } //в базе Resource

		public int? User_ID { get; set; } //в базе Resource

		[Required(ErrorMessage = "Не заполнено поле 'ФИО'")]
		[DisplayName("ФИО")]
		public string Name { get; set; } //в базе Resource

		[Required(ErrorMessage = "Не заполнено поле 'Телефон'")]
		[DisplayName("Телефон")]
		public string Phone { get; set; } //в базе Resource

		//[Required(ErrorMessage = "Не заполнено поле 'Карта'")]
		[DisplayName("Карта")]
		public string Card { get; set; }

		//[Required(ErrorMessage = "Поле 'Должность' не может быть пустым")]
		[DisplayName("Должность")]
		public string Position { get; set; } //в базе Resource

		[DisplayName("Оклад")]
		[DisplayFormat(DataFormatString = "N0")]
		[Required(ErrorMessage = "Не заполнено поле 'Оклад'")]
		public decimal Salary { get; set; } //в базе ResOP

		[DisplayName("Оф.оклад")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal OfficialSalary { get; set; } //в базе Resource
		
		[DisplayName("Налог")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal Nalog { get; set; } //в базе Resource

		//[Range(0, 31)]
		[DisplayName("Норма")]
		[DisplayFormat(DataFormatString = "N0")]
		public int RateDays { get; set; } //в базе ResOP

		[DisplayName("Факт")]
		[DisplayFormat(DataFormatString = "N0")]
		public int FactDays { get; set; } //в базе ResOP

		[DisplayName("Начислено")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal Calculated { get; set; }

		[DisplayName("К выдаче")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal FactSalary { get; set; } //в базе ResOP

		[DisplayName("Выдано")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal Paid { get; set; } //в базе ResOP

		[DisplayName("Долг")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal Debt => FactSalary - Paid;

		//[Range(0, 999999)]
		[DisplayName("Аванс")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal Avans { get; set; } //в базе ResOP

		//[Range(0, 999999)]
		[DisplayName("Штрафы")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal Penalty { get; set; } //в базе ResOP

		//[Range(0, 999999)]
		[DisplayName("Премии")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal Premium { get; set; } //в базе ResOP

		//[Range(0, 999999)]
		[DisplayName("Отмывки")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal Washings { get; set; } //в базе ResOP

		[DisplayName("Документы")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal Docs { get; set; } //в базе ResOP

		[DisplayName("Комментарий")]
		public string Comment { get; set; } //в базе ResOP

		public DateTime Month { get; set; }

		[DisplayName("Мед.книжка")]
		[Description("Медицинская книжка")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal MedBook { get; set; } //в базе ResOP

		[DisplayName("Спецодежда")]
		[DisplayFormat(DataFormatString = "N0")]
		public decimal SpecWear { get; set; } //в базе ResOP

		public object Clone()
		{
			return MemberwiseClone();
		}
		public CResOPDto ToResOp() => MapperService.Map<CResOPDto>(this);
		public static explicit operator CResOPDto(ResOPViewModel vm)
		{
			return MapperService.Map<CResOPDto>(vm);
		}
	}
}