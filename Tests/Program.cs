using System;
using InstaSharp;
using InstaSharp.API.Services;
using InstaSharp.Models.Cache;

namespace Tests {
	class Program {

		static void Main(string[] args) {

			var accountData = new UserInformation {
				Username = "",
				Password = ""
			};
			
			var instagramService = new InstagramService(accountData);
			
		}
	}
}