using System;
using Newtonsoft.Json;

namespace InstaSharp.Models.Instagram.User {
	[Serializable]
	public class LoginResultInformation {

		[JsonProperty(PropertyName = "authenticated")]
		public bool IsAuthenticated { get; set; }

	}
}