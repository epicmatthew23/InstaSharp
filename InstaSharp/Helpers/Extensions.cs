using System;
using InstaSharp.Models;

namespace InstaSharp.Helpers {
	public static class TimeExtensions {
		public static long ToTimeStamp(this DateTime dateTime) {
			return (long) (dateTime.ToUniversalTime() - TimeConstants.Jan1St1970).TotalSeconds;
		}
	}
}