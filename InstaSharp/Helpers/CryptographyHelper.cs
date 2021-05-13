using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using InstaSharp.Models;
using InstaSharp.Utils;
using Sodium;

namespace InstaSharp.Helpers {
	public static class CryptographyHelper {
		public static string GenerateEncryptedPassword(string password) {
			var timeString = DateTime.UtcNow.ToTimeStamp().ToString();
			byte[] keyBytes = CryptographyConstants.Key.HexToBytes();

			var key = new byte[32];
			ThreadSafeRandom.NextBytes(key);
			var iv = new byte[12];
			var tag = new byte[16];

			byte[] plainText = Encoding.UTF8.GetBytes(password);
			var cipherText = new byte[plainText.Length];

			using (var cipher = new AesGcm(key)) {
				cipher.Encrypt(iv,
					plainText,
					cipherText,
					tag,
					Encoding.UTF8.GetBytes(timeString));
			}

			byte[] encryptedKey = SealedPublicKeyBox.Create(key, keyBytes);
			byte[] bytesOfLen = BitConverter.GetBytes((short) encryptedKey.Length);

			var info = new byte[] {1, byte.Parse(CryptographyConstants.KeyId.ToString())};
			byte[] bytes = info.Concat(bytesOfLen).Concat(encryptedKey).Concat(tag).Concat(cipherText);

			return
				$"#PWD_INSTAGRAM_BROWSER:{CryptographyConstants.Version}:{timeString}:{Convert.ToBase64String(bytes)}";
		}

		private static byte[] HexToBytes(this string hex) {
			return Enumerable.Range(0, hex.Length / 2)
				.Select(x => Convert.ToByte(hex.Substring(x * 2, 2), 16))
				.ToArray();
		}

		private static T[] Concat<T>(this T[] x, T[] y) {
			var z = new T[x.Length + y.Length];
			x.CopyTo(z, 0);
			y.CopyTo(z, x.Length);
			return z;
		}
	}
}