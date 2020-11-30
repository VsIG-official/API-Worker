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
			Console.WriteLine("1 - to predict some data, depending on Your name\n" +
				"2 - find something to do by getting suggestions for random activities");

			string userChoice = Console.ReadLine();

			if (userChoice == "1")
			{
				Console.WriteLine("Enter Your name:");
				string userName = Console.ReadLine();

				await LoadNameInfo(userName);
			}
			else if(userChoice == "2")
			{
				await LoadActivities();
			}
			else 
			{
				Console.WriteLine("That's the wrong number");
			}

			Console.ReadLine();
		}
		private static async Task LoadNameInfo(string name)
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

		private static async Task<string[]> LoadActivities()
		{
			string[] activitiesData = new string[4];
			ActivitiesModel activities = await Activities.LoadValue();

			activitiesData[0] = activities.Activity;
			activitiesData[1] = activities.Type;
			activitiesData[2] = activities.Participants.ToString();
			activitiesData[3] = activities.Price.ToString();

			Console.WriteLine($"There is some interesting activity: \n" +
				$"Activity - {activitiesData[0]} \n" +
				$"Type - {activitiesData[1]} with \n" +
				$"Participants - {activitiesData[2]} \n" +
				$"Price - {activitiesData[3]}");

			return activitiesData;
		}
	}
}
