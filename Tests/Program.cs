using System;
using InstaSharp;
using InstaSharp.API.Services;
using InstaSharp.Models.Instagram.User;

namespace Tests {
	class Program {

		static void Main(string[] args) {

			var accountData = new UserInformation {
				Username = "userame",
				Password = "password"
			};
			
			var instagramService = new InstagramService(accountData);

			LoginResultInformation resultInformation = instagramService.GrabLoginResultInformation();
			
			Console.WriteLine(resultInformation.IsAuthenticated);
			
		}
	}
}