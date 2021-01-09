using System.Net.Http;
using System.Net.Http.Headers;

namespace Async_Kursach.Fundamentals
{
	/// <summary>
	/// Class for Api Client
	/// </summary>
	public static class ApiHelper
	{
		// Create static, 'cause We need one client per application

		/// <summary>
		/// Gets or sets the API client;
		/// Provides a base class for sending HTTP requests
		/// and receiving HTTP responses from the resource
		/// with the specified URI.
		/// </summary>
		/// <value>
		/// The API client
		/// </value>
		public static HttpClient ApiClient { get; set; }

		/// <summary>
		/// Initializes API client
		/// </summary>
		public static void Initialize()
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
			// The headers that should be sent with each request
			ApiClient.DefaultRequestHeaders.Accept.Clear();
			// give Us json, not webpage or etc.
			ApiClient.DefaultRequestHeaders.Accept.Add(new
				MediaTypeWithQualityHeaderValue("application/json"));
		}
	}
}
