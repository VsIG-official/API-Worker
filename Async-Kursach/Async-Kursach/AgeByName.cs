using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Async_Kursach
{
	/// <summary>
	/// Access Agify API
	/// </summary>
	public class AgeByName
	{
		private const string defaultString = "Valentyn";

		/// <summary>
		/// Loads specific value
		/// </summary>
		public static async Task<AgeByNameModel> LoadValue(string text)
		{
			string url;
			if (text != defaultString)
			{
				url = $"https://api.agify.io?name={ text } ";
			}
			else
			{
				url = $"https://api.agify.io?name={ defaultString }";
			}

			//open a call to a client
			//or open a new request of ApiClient as await for response
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// there We will read the data
					// convert json to ValueByNameModel with correct properties
					AgeByNameModel age = await response.Content.ReadAsAsync<AgeByNameModel>();

					return age;
				}
				else
				{
					throw new Exception(response.ReasonPhrase);
				}
			}
			//there a response is closing and make sure, that Our calls are cleaned up
		}
	}
}
