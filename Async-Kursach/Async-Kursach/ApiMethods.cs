using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Async_Kursach.Fundamentals
{
	/// <summary>
	/// Class, which have all methods for API's
	/// </summary>
	public static class ApiMethods
	{
		/// <summary>
		/// Calls all API.
		/// </summary>
		public static async Task CallAllAPI()
		{
			await LoadNameInfo().ConfigureAwait(false);
			Console.WriteLine();
			await LoadActivities().ConfigureAwait(false);
			Console.WriteLine();
			await LoadJokes().ConfigureAwait(false);
		}

		/// <summary>
		/// Loads the name information from API
		/// </summary>
		public static async Task LoadNameInfo()
		{
			Console.WriteLine(ConfigUtils.EnterName);
			string userName = Console.ReadLine();

			int age = await LoadNameAge(userName).
				ConfigureAwait(false);
			string[] genderData = await LoadNameGender
				(userName).ConfigureAwait(false);

			Console.WriteLine();

			string output = string.Format(Regex.Unescape(ConfigUtils.NameInfoString), userName, age,
				genderData[0], genderData[1]);

			Console.WriteLine(output);
		}

		/// <summary>
		/// Loads the name age from API
		/// </summary>
		/// <param name="name">Name of person</param>
		/// <returns> age </returns>
		public static async Task<int> LoadNameAge(string name)
		{
			AgeByNameModel age = await AgeByName.
				LoadValue(name).ConfigureAwait(false);

			return age.Age;
		}

		/// <summary>
		/// Loads the name gender from API
		/// </summary>
		/// <param name="name">Name of person</param>
		/// <returns> array with data </returns>
		public static async Task<string[]> LoadNameGender(string name)
		{
			string[] genderData = new string[2];
			GenderByNameModel gender = await GenderByName.
				LoadValue(name).ConfigureAwait(false);

			genderData[0] = gender.Gender;
			genderData[1] = gender.Probability.ToString();

			return genderData;
		}

		/// <summary>
		/// Loads the activities from API
		/// </summary>
		/// <returns> array with data </returns>
		public static async Task<string[]> LoadActivities()
		{
			string[] activitiesData = new string[4];
			ActivitiesModel activities = await Activities.
				LoadValue().ConfigureAwait(false);

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
		public static async Task<string[]> LoadJokes()
		{
			string[] jokesData = new string[2];
			JokesModel jokes = await Jokes.LoadValue()
				.ConfigureAwait(false);

			jokesData[0] = jokes.Setup;
			jokesData[1] = jokes.Punchline;

			Console.WriteLine($"Here comes the joke: \n" +
				$"{jokesData[0]}\n" +
				$"...\n" +
				$"...\n" +
				$"...\n" +
				$"{jokesData[1]}");

			return jokesData;
		}
	}
}
