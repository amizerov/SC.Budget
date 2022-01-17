using LinqToDB.Mapping;
using SC.Common.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace SC.Common.Model
{
	[Table("Note")]
	public class CNoteDto : IHasID
	{
		[PrimaryKey, Identity] public int ID { get; set; }
		[Column] public int User_ID { get; set; }
		[Column] public Modules? Module { get; set; }
		[Display(Name = "Дата")]
		[Column] public DateTime Date { get; set; }
		[Column] public string Content { get; set; }
		[Column(SkipOnInsert = true, SkipOnUpdate = true)] public DateTime dtc { get; set; }
		[Column] public DateTime? dtu { get; set; }

		public void SetContent(string content, string pass)
		{
			if (pass.NoEmpty())
			{
				var cryptor = new CryptorService(pass);
				Content = cryptor.Encrypt(content);
			}
			else Content = content;
		}
	}

	public class CNote : CNoteDto
	{
		[Display(Name = "Содержимое")]
		public string DecryptedContent { get; set; }
	}
}
