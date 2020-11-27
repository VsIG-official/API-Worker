using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Async_Kursach
{
	class Program
	{
		
		static void Main()
		{
			Console.WriteLine("Hi, My name is Async Kursach and " +
				"I will help You to have some fun!");
			Console.WriteLine("Which one do You want to do?");
			Console.WriteLine("1 - to predict some data, depending on Your name");

			string userChoice = Console.ReadLine();

			if (userChoice == "1")
			{
				//Console.WriteLine("Which one do You want to do?");
				Console.WriteLine("Enter Your name:");
				string userName = Console.ReadLine();

				string url = $"https://api.agify.io/?name={ userName }";

				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

				string response;

				using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
				{
					response = streamReader.ReadToEnd();
				}

				AgeByNameResponse ageResponse = JsonConvert.DeserializeObject<AgeByNameResponse>(response);

				Console.WriteLine("Your name is {0} and Your predicted age is {1}",ageResponse.Name,ageResponse.Age);
			}
			else
			{
				Console.WriteLine("That's the wrong number");
			}
			Console.ReadLine();
		}
	}
}
