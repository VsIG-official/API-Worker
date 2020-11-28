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
				Console.WriteLine("Enter Your name:");
				string userName = Console.ReadLine();
				await LoadNameInfoAsync(userName);
			}
			else
			{
				Console.WriteLine("That's the wrong number");
			}

			Console.ReadLine();
		}
		private static async Task LoadNameInfoAsync(string name)
		{
			int age = await LoadNameAge(name);
			string[] genderData = await LoadNameGender(name);

			Console.WriteLine($"Here some data for {name} name: \n" +
				$"Your predicted age is {age} \n" +
				$"Your predicted gender is {genderData[0]} with " +
				$"probability of {genderData[1]}");
		}

		private static async Task<int> LoadNameAge(string name)
		{
			AgeByNameModel age = await AgeByName.LoadValue(name);

			return age.Age;
		}

		private static async Task<string[]> LoadNameGender(string name)
		{
			string[] genderData = new string[2];
			GenderByNameModel gender = await GenderByName.LoadValue(name);

			genderData[0] = gender.Gender;
			genderData[1] = gender.Probability.ToString();

			return genderData;
		}
	}
}
