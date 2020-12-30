using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Async_Kursach
{
	public class Jokes
	{
		public static async Task<JokesModel> LoadValue()
		{
			string url = "https://official-joke-api.appspot.com/random_joke";

			//open a call to a client
			//or open a new request of ApiClient as await for response
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// there We will read the data
					// convert json to ValueByNameModel with correct properties
					JokesModel jokesData = await response.Content.ReadAsAsync<JokesModel>();

					return jokesData;
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