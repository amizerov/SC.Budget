using LinqToDB.Mapping;
using SC.Common.Services;
using System.ComponentModel.DataAnnotations;

namespace SC.Common.Model
{
	public enum Role
	{
		[Display(Name = "Нет роли")] Null = -1,
		[Display(Name = "Сотрудник")] None = 0,
		[Display(Name = "Администратор")] Admin = 1,
		[Display(Name = "Бухгалтер")] Buh = 2,
		[Display(Name = "Менеджер закупок")] ManagerZakup = 3,
		[Display(Name = "Руководитель проекта")] Rukovod = 4,
		[Display(Name = "Менеджер")] Manager = 5,
		[Display(Name = "Директор")] Director = 6,
		[Display(Name = "Кладовщик")] Kladovshchik = 7,
		[Display(Name = "Уволен")] NoWorked = 9,
	}

	[Table(Name = "Role")]
	public class CRoleDto : IHasID, IHasName
	{
		[PrimaryKey, Identity]
		public int ID { get; set; }

		[Column(Name = "Name")]
		public string Name { get; set; }
		public override string ToString() => Name;
	}
}
