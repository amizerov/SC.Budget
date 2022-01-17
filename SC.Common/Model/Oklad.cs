using LinqToDB.Mapping;

namespace SC.Common.Model
{
	[Table("Oklad")]
	public class COkladDto
	{
		[Column] public int Object_ID { get; set; }
		[Column] public int Position_ID { get; set; }
		[Column] public decimal Summa { get; set; }
	}
}
