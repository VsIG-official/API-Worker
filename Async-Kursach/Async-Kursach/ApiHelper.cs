using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Async_Kursach
{
	/// <summary>
	/// Class for Api Client
	/// </summary>
	public static class ApiHelper
	{
		// Create static, 'cause We need one client per application
		public static HttpClient ApiClient { get; set; }

		public static void InitializeClient()
		{
			ApiClient = new HttpClient
			{
				// a lot of adresses will begin with the same string, 
				// so We can put the beginning here
				// but won't, because We need more than one adress
				/*
				BaseAddress = new Uri("http://somesite.com/")
				*/
			};
			ApiClient.DefaultRequestHeaders.Accept.Clear();
			// give Us json, not webpage or etc.
			ApiClient.DefaultRequestHeaders.Accept.Add(new 
				MediaTypeWithQualityHeaderValue("application/json"));
		}
	}
}
