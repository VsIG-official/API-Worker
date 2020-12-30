using System;
using System.Threading.Tasks;

namespace Async_Kursach
{
	/// <summary>
	/// Start point of program
	/// </summary>
	class Program
	{
		static async Task Main()
		{
			ApiHelper.InitializeClient();
			ConfigUtils.Initialize();

			Console.WriteLine(ConfigUtils.Greeting);

			string userChoice = Console.ReadLine();

			try
			{
				if (userChoice == "1")
				{
					Console.WriteLine(ConfigUtils.EnterName);
					string userName = Console.ReadLine();

					await LoadNameInfo(userName);
				}
				else if (userChoice == "2")
				{
					await LoadActivities();
				}
				else if (userChoice == "3")
				{
					await LoadJokes();
				}
				else
				{
					Console.WriteLine(ConfigUtils.WrongNumber);
				}
			}
			catch (Exception)
			{
				Console.WriteLine("Something wrong with data. Try something else");
			}

			Console.ReadLine();
		}

		/// <summary>
		/// Loads the name information from API
		/// </summary>
		/// <param name="name">Name of person</param>
		private static async Task LoadNameInfo(string name)
		{
			int age = await LoadNameAge(name);
			string[] genderData = await LoadNameGender(name);

			Console.WriteLine($"Here some data for {name} name: \n" +
				$"Your predicted age is {age} \n" +
				$"Your predicted gender is {genderData[0]} with " +
				$"probability of {genderData[1]}");
		}

		/// <summary>
		/// Loads the name age from API
		/// </summary>
		/// <param name="name">Name of person</param>
		/// <returns> age </returns>
		private static async Task<int> LoadNameAge(string name)
		{
			AgeByNameModel age = await AgeByName.LoadValue(name);

			return age.Age;
		}

		/// <summary>
		/// Loads the name gender from API
		/// </summary>
		/// <param name="name">Name of person</param>
		/// <returns> array with data </returns>
		private static async Task<string[]> LoadNameGender(string name)
		{
			string[] genderData = new string[2];
			GenderByNameModel gender = await GenderByName.LoadValue(name);

			genderData[0] = gender.Gender;
			genderData[1] = gender.Probability.ToString();

			return genderData;
		}

		/// <summary>
		/// Loads the activities from API
		/// </summary>
		/// <returns> array with data </returns>
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

		/// <summary>
		/// Loads the jokes from API
		/// </summary>
		/// <returns> array with data </returns>
		private static async Task<string[]> LoadJokes()
		{
			string[] jokesData = new string[2];
			JokesModel jokes = await Jokes.LoadValue();

			jokesData[0] = jokes.Setup;
			jokesData[1] = jokes.Punchline;

			Console.WriteLine($"There is a joke: \n" +
				$"{jokesData[0]}\n" +
				$"...\n" +
				$"...\n" +
				$"...\n" +
				$"{jokesData[1]}");

			return jokesData;
		}
	}
}
