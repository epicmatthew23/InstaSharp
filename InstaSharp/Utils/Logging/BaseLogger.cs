using System;

namespace InstaSharp.Utils.Logging {
	public class BaseLogger {
		private static readonly object Lock = new();

		public static void Log(string content, ConsoleColor consoleColor = ConsoleColor.White) {
			lock (Lock) {
				Console.ForegroundColor = consoleColor;
				Console.WriteLine($"[{DateTime.UtcNow}] {content}!");
				Console.ResetColor();
			}
		}
	}
}