using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Async_Kursach
{
	/// <summary>
	/// Class for Api Client
	/// </summary>
	class ApiHelper
	{
		// Create static, 'cause We need one client per application
		public static HttpClient ApiClient { get; set; } = new HttpClient();

		public static void InitializeClient()
		{
			ApiClient = new HttpClient
			{
				BaseAddress = new Uri("")
			};
			ApiClient.DefaultRequestHeaders.Accept.Clear();
			ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}
	}
}
