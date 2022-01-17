using am.BL;
using SwissClean.MVP.MainView.ViewModels;
using System;
using System.Data;

namespace SwissClean.Dal.Dto
{
	public class CResOP
	{
		public CResOP() { }
		public CResOP(DataRow r)
		{
			ID = G._I(r["ID"]);
			Month = G._D(r["Month"]);
			Resource_ID = G._I(r["Resource_ID"]);
			Object_ID = G._I(r["Object_ID"]);
			Position_ID = G._I(r["Position_ID"]);
			Avans = G._Dec(r["Avans"]);
			Penalty = G._Dec(r["Penalty"]);
			Premium = G._Dec(r["Premium"]);
			SpecWear = G._Dec(r["SpecWear"]);
			MedBook = G._Dec(r["MedBook"]);
			Washings = G._Dec(r["Washings"]);
			Docs = G._Dec(r["Docs"]);
			Comment = G._S(r["Comment"]);
			RateDays = G._I(r["RateDays"]);
			FactDays = G._I(r["FactDays"]);
			FactSalary = G._Dec(r["FactSalary"]);
			Paid = G._Dec(r["Paid"]);
		}
		public CResOP(DateTime? month, int? object_ID, int resource_ID, int position_ID)
		{
			Month = month;
			Object_ID = object_ID;
			Resource_ID = resource_ID;
			Position_ID = position_ID;
		}
		public CResOP(ResOPViewModel vm)
		{
			ID = vm.ResOP_ID ?? -1;
			Resource_ID = vm.Resource_ID;
			Position_ID = vm.PositionID;
			Object_ID = vm.Object_ID;
			Avans = vm.Avans;
			Month = vm.Month;
			RateDays = vm.RateDays ?? 0;
			FactDays = vm.FactDays;
			Penalty = vm.Penalty;
			Premium = vm.Premium;
			MedBook = vm.MedBook;
			SpecWear = vm.SpecWear;
			Washings = vm.Washings;
			Docs = vm.Docs;
			Comment = vm.Comment;
			FactSalary = vm.FactSalary;
			Paid = vm.Paid;
		}

		public int ID { get; set; }
		public DateTime? Month { get; set; }
		public int Resource_ID { get; set; }
		public int? Object_ID { get; set; }
		public int Position_ID { get; set; }
		public decimal? Avans { get; set; }
		public decimal? Penalty { get; set; }
		public decimal? Premium { get; set; }
		public decimal? MedBook { get; set; }
		public decimal? SpecWear { get; set; }
		public decimal? Washings { get; set; }
		public decimal? Docs { get; set; }
		public string Comment { get; set; }
		public int RateDays { get; set; }
		public int? FactDays { get; set; }
		public decimal? FactSalary { get; set; }
		public decimal? Paid { get; set; }
	}
}