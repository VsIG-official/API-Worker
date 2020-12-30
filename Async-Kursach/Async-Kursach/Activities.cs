using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Async_Kursach
{
	/// <summary>
	/// Access Activity API
	/// </summary>
	public class Activities
	{
		/// <summary>
		/// Loads specific value
		/// </summary>
		public static async Task<ActivitiesModel> LoadValue()
		{
			string url = "https://www.boredapi.com/api/activity";

			//open a call to a client
			//or open a new request of ApiClient as await for response
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// there We will read the data
					// convert json to ValueByNameModel with correct properties
					ActivitiesModel activityData = await response.Content.ReadAsAsync<ActivitiesModel>();

					return activityData;
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
