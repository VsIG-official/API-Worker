using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Async_Kursach
{
	public class NationByName
	{
		const string defaultString = "Valentyn";
		public static async Task<NationByNameModel> LoadValue(string text)
		{
			string url;
			if (text != defaultString)
			{
				url = $"https://api.genderize.io/?name={ text } ";
			}
			else
			{
				url = $"https://api.genderize.io/?name={ defaultString }";
			}

			//open a call to a client
			//or open a new request of ApiClient as await for response
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// there We will read the data
					// convert json to ValueByNameModel with correct properties
					NationByNameModel genderAndProbability = await response.Content.ReadAsAsync<NationByNameModel>();

					return genderAndProbability;
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

