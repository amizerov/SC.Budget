using System;

namespace SC.Common.Model
{
	public class AvansByCashUnit : IResOpByCashUnit
	{
		public string FieldName => nameof(CResOPDto.Avans);
		public OperationCategory Category => OperationCategory.Avans;
		public Func<CResOPDto, decimal?> Value => r => r.Avans;
		public Action<CResOPDto, decimal?> Set => (r, value) => r.Avans = value;
	}
	//public class PremiumUnit : IResOpByCashUnit
	//{
	//	public string FieldName => nameof(CResOPDto.Premium);
	//	public OperationCategory Category => OperationCategory.Premium;
	//	public Func<CResOPDto, decimal> Value => r => r.Premium;
	//	public Action<CResOPDto, decimal?> Set => (r, value) => r.Premium = value;
	//}
	//public class MedBookUnit : IResOpByCashUnit
	//{
	//	public string FieldName => nameof(CResOPDto.MedBook);
	//	public OperationCategory Category => OperationCategory.Medbook;
	//	public Func<CResOPDto, decimal> Value => r => r.MedBook;
	//	public Action<CResOPDto, decimal?> Set => (r, value) => r.MedBook = value;
	//}
	//public class SpecWearUnit : IResOpByCashUnit
	//{
	//	public string FieldName => nameof(CResOPDto.SpecWear);
	//	public OperationCategory Category => OperationCategory.SpecWear;
	//	public Func<CResOPDto, decimal> Value => r => r.SpecWear;
	//	public Action<CResOPDto, decimal?> Set => (r, value) => r.SpecWear = value;
	//}
	//public class WashingsUnit : IResOpByCashUnit
	//{
	//	public string FieldName => nameof(CResOPDto.Washings);
	//	public OperationCategory Category => OperationCategory.Washings;
	//	public Func<CResOPDto, decimal> Value => r => r.Washings;
	//	public Action<CResOPDto, decimal?> Set => (r, value) => r.Washings = value;
	//}
	//public class DocsUnit : IResOpByCashUnit
	//{
	//	public string FieldName => nameof(CResOPDto.Docs);
	//	public OperationCategory Category => OperationCategory.Docs;
	//	public Func<CResOPDto, decimal> Value => r => r.Docs;
	//	public Action<CResOPDto, decimal?> Set => (r, value) => r.Docs = value;
	//}
	public class PaidByCashUnit : IResOpByCashUnit
	{
		public string FieldName => nameof(CResOPDto.Paid);
		public OperationCategory Category => OperationCategory.Paid;
		public Func<CResOPDto, decimal?> Value => r => r.Paid;
		public Action<CResOPDto, decimal?> Set => (r, value) => r.Paid = value;
	}
}
