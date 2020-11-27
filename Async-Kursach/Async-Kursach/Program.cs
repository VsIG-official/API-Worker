using System;

namespace Async_Kursach
{
	class Program
	{
		static void Main()
		{
			ApiHelper.InitializeClient();

			Console.WriteLine("Hi, My name is Async Kursach and " +
				"I will help You to have some fun!");
			Console.WriteLine("Which one do You want to do?");
			Console.WriteLine("1 - to predict some data, depending on Your name");

			string userChoice = Console.ReadLine();

			if (userChoice == "1")
			{
				//Console.WriteLine("Which one do You want to do?");
				Console.WriteLine("Enter Your name:");
				string userSentence = Console.ReadLine();
				AgeByName ageApi = new AgeByName();
				
			}
			else
			{
				Console.WriteLine("That's the wrong number");
			}
		}
	}
}
