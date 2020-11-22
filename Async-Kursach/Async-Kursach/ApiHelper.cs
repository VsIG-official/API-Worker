using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace Async_Kursach
{
	class ApiHelper
	{
		public static HttpClient ApiClient { get; set; } = new HttpClient();

		public static void InitializeClient()
		{

		}
	}
}
