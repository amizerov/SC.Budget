using System;
using System.Collections.Generic;
using System.Linq;

namespace SC.Common.Model
{
	/// <summary>
	/// Интерфейс для проведения операций через кассу
	/// </summary>
	public interface IResOpByCashUnit
	{
		string FieldName { get; }
		OperationCategory Category { get; }
		Func<CResOPDto, decimal?> Value { get; }
		Action<CResOPDto, decimal?> Set { get; }
	}

	public class ResOpUnitService
	{
		public ResOpUnitService()
		{
			var types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
				.Where(t => typeof(IResOpByCashUnit).IsAssignableFrom(t))
				.Where(t => !t.IsAbstract);

			AllUnits = new List<IResOpByCashUnit>();
			foreach (var type in types)
				AllUnits.Add((IResOpByCashUnit)Activator.CreateInstance(type));
		}

		public IResOpByCashUnit GetUnit(string fieldName) => AllUnits.FirstOrDefault(u => u.FieldName == fieldName);
		public IResOpByCashUnit GetUnit(OperationCategory category) => AllUnits.FirstOrDefault(u => u.Category == category);

		public List<IResOpByCashUnit> AllUnits { get; }
	}
}
