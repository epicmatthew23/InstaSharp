using System;
using System.Net.Http;

namespace InstaSharp.Models {
	public class GeneralFields {
		public static readonly HttpClient HttpClient = new();
		public static readonly Random Random = new();
	}

	public class ApiConstants {
		public const string FriendshipApi = "https://www.instagram.com/web/friendships/";
		public const string SearchApi = "https://www.instagram.com/web/search/topsearch/?query=";
		public const string LoginApi = "https://www.instagram.com/accounts/login/ajax/";
		public const string SharedDataApi = "https://www.instagram.com/data/shared_data/";
		
		public const string UserAgent =
			"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.85 Safari/537.36";
	}

	public class CryptographyConstants {
		public const string Key = "48e841118c966c141306c45395954cf877389dd9559608a9c68a2ab9dbe96849";
		public const int KeyId = 97;
		public const int Version = 10;
	}

	public static class TimeConstants {
		public static readonly DateTime Jan1St1970 = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
	}
}