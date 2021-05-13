using InstaSharp.Models;

namespace InstaSharp.Utils {
	public class ThreadSafeRandom {
		private static readonly object Lock = new();

		public static int Next(int min, int max) {
			lock (Lock) {
				return GeneralFields.Random.Next(min, max);
			}
		}

		public static void NextBytes(byte[] buffer) {
			lock (Lock) {
				GeneralFields.Random.NextBytes(buffer);
			}
		}
	}
}