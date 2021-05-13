using System;
using InstaSharp.Helpers;
using InstaSharp.Models.Cache;

namespace InstaSharp.API.Services {
	public class InstagramService {
		private readonly UserInformation _information;

		public InstagramService(UserInformation userInformation) {
			_information = userInformation;
			LoginSynchronous();
		}

		private void LoginSynchronous() {
			Console.WriteLine(CryptographyHelper.GenerateEncryptedPassword("sdfsdf"));
		}
	}
}