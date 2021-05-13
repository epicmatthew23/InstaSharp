using System;

namespace InstaSharp.Exceptions {
	public class FailedToLoginException : Exception {
		public FailedToLoginException(string message) : base(message) { }
	}
}