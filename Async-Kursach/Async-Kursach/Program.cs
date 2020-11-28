using System;
using System.Threading.Tasks;

namespace Async_Kursach
{
	class Program
	{
		static async Task Main()
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
				string userName = Console.ReadLine();
				await LoadNameInfoAsync(userName);
			}
			else
			{
				Console.WriteLine("That's the wrong number");
			}
		}
		private static async Task LoadNameInfoAsync(string name)
		{
			int age = await LoadNameAge(name);

			Console.WriteLine($"Your name is {name} and Your predicted age is {age}");
			Console.ReadLine();
		}

		private static async Task<int> LoadNameAge(string name)
		{
			AgeByNameModel age = await AgeByName.LoadValue(name);

			return age.Age;
		}
	}
}
