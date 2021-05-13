using System.Collections.Generic;
using Newtonsoft.Json;

namespace InstaSharp.Models.Instagram.Data {
	public class SharedData {
		[JsonProperty(PropertyName = "config")]
		public SharedDataConfig SharedDataConfig { get; set; }
	}

	public class SharedDataConfig {
		[JsonProperty(PropertyName = "csrf_token")]
		public string CsrfToken { get; set; }
	}
	
}