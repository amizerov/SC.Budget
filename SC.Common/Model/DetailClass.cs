using System.Collections.Generic;

namespace SC.Common.Model
{
	public enum DetailClass
	{
		Прочее = 0,
		Услуги = 1,
		Аренда = 2,
		Командировки = 3,
		Транспорт = 4,
		Товары = 5,
	}

	public class DetailClassService
	{
		private readonly Dictionary<DetailClass, Prop> _allUnits;
		public DetailClassService()
		{
			_allUnits = new Dictionary<DetailClass, Prop>
			{
				[DetailClass.Товары] = new Prop(37, 0),
				[DetailClass.Аренда] = new Prop(36, 1),
				[DetailClass.Командировки] = new Prop(38, 2),
				[DetailClass.Транспорт] = new Prop(39, 3),
				[DetailClass.Услуги] = new Prop(40, 4),
				[DetailClass.Прочее] = new Prop(35, 5),
			};
		}

		/// <summary>
		/// Порядок вывода в Excel
		/// </summary>
		public int Order(DetailClass category) => _allUnits[category].Order;
		/// <summary>
		/// Цвет ячеек в Excel
		/// </summary>
		public int Color(DetailClass category) => _allUnits[category].Color;

		private class Prop
		{
			public Prop(int color, int order)
			{
				Color = color;
				Order = order;
			}

			public int Color { get; }
			public int Order { get; }
		}
	}
}
