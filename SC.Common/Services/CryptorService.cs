using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SC.Common.Services
{
	public class CryptorService
	{
		private readonly byte[] _key;
		private byte[] _iv = { 107, 148, 140, 5, 232, 197, 61, 59, 87, 144, 165, 190, 115, 203, 50, 100 };

		public CryptorService(string pass)
		{
			_key = PasswordToByte(pass);
		}

		public string Encrypt(string txt)
		{
			byte[] encrypted;
			// Create an RijndaelManaged object
			// with the specified key and IV.
			using (var rijAlg = new RijndaelManaged())
			{
				rijAlg.Key = _key;
				rijAlg.IV = _iv;

				// Create an encryptor to perform the stream transform.
				var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

				// Create the streams used for encryption.
				using (var msEncrypt = new MemoryStream())
				using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
				{
					using (var swEncrypt = new StreamWriter(csEncrypt))
					{
						swEncrypt.Write(txt);
					}
					encrypted = msEncrypt.ToArray();
				}
			}
			var encryptedTxt = Convert.ToBase64String(encrypted);
			return encryptedTxt;
		}
		public string Decrypt(string txt)
		{
			var encrypted = Convert.FromBase64String(txt);
			using (var rijAlg = new RijndaelManaged())
			{
				rijAlg.Key = _key;
				rijAlg.IV = _iv;

				var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

				using (var msDecrypt = new MemoryStream(encrypted))
				using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
				using (var srDecrypt = new StreamReader(csDecrypt))
				{
					var decrypted = srDecrypt.ReadToEnd();
					return decrypted;
				}
			}
		}
		public static byte[] PasswordToByte(string pass)
		{
			using (MD5 md5 = new MD5CryptoServiceProvider())
			{
				var passBytes = Encoding.UTF8.GetBytes(pass);
				var md5Bytes = md5.ComputeHash(passBytes);
				var md5Txt = BitConverter.ToString(md5Bytes).Replace("-", string.Empty);

				var res = Encoding.ASCII.GetBytes(md5Txt);
				return res;
			}
		}
	}
}
