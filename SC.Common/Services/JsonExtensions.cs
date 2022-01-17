using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace SC.Common.Services
{
	public static class JsonService
	{
		public static string ToJson<T>(this T obj)
		{
			var serializer = new DataContractJsonSerializer(obj.GetType());
			var ms = new MemoryStream();
			serializer.WriteObject(ms, obj);
			return Encoding.Default.GetString(ms.ToArray());
		}
		public static T FromJson<T>(string json)
		{
			var serializer = new DataContractJsonSerializer(typeof(T));
			using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
				return (T)serializer.ReadObject(ms);
		}
	}
}
