using System;

namespace InstaSharp.Models.Cache {
	[Serializable]
	public class UserInformation {
		public string Username { get; set; }
		public string Password { get; set; }
	}
}