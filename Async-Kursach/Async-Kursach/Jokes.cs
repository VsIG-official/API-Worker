using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Async_Kursach.Fundamentals
{
	/// <summary>
	/// Access Jokes API
	/// </summary>
	public class Jokes
	{
		/// <summary>
		/// Loads specific value
		/// </summary>
		public static async Task<JokesModel> LoadValue()
		{
			//open a call to a client
			//or open a new request of ApiClient as await for response
			using (HttpResponseMessage response = await ApiHelper.ApiClient.
				GetAsync(ConfigUtils.JokesURL))
			{
				if (response.IsSuccessStatusCode)
				{
					// there We will read the data
					// convert json to ValueByNameModel with correct properties
					JokesModel jokesData = await response.Content.
						ReadAsAsync<JokesModel>();

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
