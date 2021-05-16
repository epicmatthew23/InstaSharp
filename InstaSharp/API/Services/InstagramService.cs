using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using InstaSharp.Exceptions;
using InstaSharp.Helpers;
using InstaSharp.Models;
using InstaSharp.Models.Instagram.Data;
using InstaSharp.Models.Instagram.User;

namespace InstaSharp.API.Services {
	public class InstagramService {
		private static UserInformation _information;

		public bool IsAuthenticated;
		private string _cookie;
		
		public InstagramService(UserInformation userInformation) {
			_information = userInformation;
			LoginToAccount();
		}
		
		private void LoginToAccount() {
			
			var formContent = new FormUrlEncodedContent(new[] {
				new KeyValuePair<string, string>("username", _information.Username),
				new KeyValuePair<string, string>("enc_password",
					CryptographyHelper.GenerateEncryptedPassword(_information.Password)),
				new KeyValuePair<string, string>("queryParams", "{}"),
				new KeyValuePair<string, string>("optIntoOneTap", "false"),
				new KeyValuePair<string, string>("stopDeletionNonce", "")
			});

			var request = new HttpRequestMessage {
				RequestUri = new Uri(ApiConstants.LoginApi),
				Method = HttpMethod.Post,
				Headers = {
					{"x-csrftoken", GrabCsrfToken()}
				},
				Content = formContent
			};

			HttpResponseMessage response = GeneralFields.HttpClient.SendAsync(request).Result;
			
			LoginResultInformation loginResultInformation = response
				.Content.ReadAsJsonAsync<LoginResultInformation>().Result;

			IsAuthenticated = loginResultInformation.IsAuthenticated;
			//_cookie = string.Join(' ',response.Headers.GetValues("Set-Cookie").ToArray());
			
			
		}

		private string GrabCsrfToken() {
			var request = new HttpRequestMessage {
				RequestUri = new Uri(ApiConstants.SharedDataApi),
				Method = HttpMethod.Get,
			};

			return GeneralFields.HttpClient.SendAsync(request).Result
				.Content.ReadAsJsonAsync<SharedData>().Result
				.SharedDataConfig.CsrfToken;
		}
	}
}