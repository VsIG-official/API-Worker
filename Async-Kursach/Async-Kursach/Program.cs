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
			string[] genderData = await LoadNameGender(name);
			string[] nationData = await LoadNameNation(name);

			Console.WriteLine($"Here some data for {name} name: \n" +
				$"Your predicted age is {age} \n" +
				$"Your predicted gender is {genderData[0]} with " +
				$"probability of {genderData[1]}\n" +
				$"Your predicted nations are:\n" +
				$"	{nationData[0]} with {nationData[1]}\n" +
				$"	{nationData[2]} with {nationData[3]}\n" +
				$"	{nationData[4]} with {nationData[5]}\n");
			Console.ReadLine();
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

		private static async Task<string[]> LoadNameNation(string name)
		{
			string[] nationData = new string[6];
			NationByNameModel nation = await NationByName.LoadValue(name);

			nationData[0] = nation.Country[0];
			nationData[1] = nation.Country[1].ToString();
			nationData[2] = nation.Country[2];
			nationData[3] = nation.Country[3].ToString();
			nationData[4] = nation.Country[4];
			nationData[5] = nation.Country[5].ToString();

			return nationData;
		}
	}
}
