using System;
using System.Net.Http;
using System.Threading.Tasks;
using InstaSharp.Models;
using Newtonsoft.Json;

namespace InstaSharp.Helpers {
	public static class TimeExtensions {
		public static long ToTimeStamp(this DateTime dateTime) {
			return (long) (dateTime.ToUniversalTime() - TimeConstants.Jan1St1970).TotalSeconds;
		}
	}

	public static class HttpClientExtensions {
		public static async Task<T> ReadAsJsonAsync<T>(this HttpContent httpContent) {
			string stringContent = await httpContent.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(stringContent);
		}
	}
	
}