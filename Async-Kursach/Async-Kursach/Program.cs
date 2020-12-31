﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Kursach
{
	/// <summary>
	/// Start point of program
	/// </summary>
	internal class Program
	{
		static readonly Dictionary<string, Action> operations
			= new Dictionary<string, Action>();

		/// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		private static void Main()
		{
			Initialize();

			LoadGreeting();
		}

		/// <summary>
		/// Load greeting and begin choices method
		/// </summary>
		static void LoadGreeting()
		{
			Console.WriteLine(ConfigUtils.Greeting);

			LoadChoices();
		}

		/// <summary>
		/// Load and operate with choices
		/// </summary>
		static void LoadChoices()
		{
			Console.WriteLine(ConfigUtils.NextChoice);

			string userChoice = Console.ReadLine();

			try
			{
				operations[userChoice].Invoke();
			}
			catch (Exception)
			{
				Console.WriteLine(ConfigUtils.WrongData);
			}

			Console.ReadLine();
		}

		/// <summary>
		/// Initialization of things
		/// </summary>
		private static void Initialize()
		{
			ApiHelper.Initialize();
			ConfigUtils.Initialize();
			CreateOperations();
		}

		/// <summary>
		/// Replacement of if-else
		/// </summary>
		private static void CreateOperations()
		{
			operations["1"] = async () => { await
				LoadNameInfo().ConfigureAwait(false); };
			operations["2"] = async () => { await
				LoadActivities().ConfigureAwait(false); };
			operations["3"] = async () => { await
				LoadJokes().ConfigureAwait(false); };
			operations["4"] = async () => { await
				CallAllAPI().ConfigureAwait(false); };
		}

		/// <summary>
		/// Calls all API.
		/// </summary>
		private static async Task CallAllAPI()
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
		/// <param name="name">Name of person</param>
		private static async Task LoadNameInfo()
		{
			Console.WriteLine(ConfigUtils.EnterName);
			string userName = Console.ReadLine();

			int age = await LoadNameAge(userName).
				ConfigureAwait(false);
			string[] genderData = await LoadNameGender
				(userName).ConfigureAwait(false);

			Console.WriteLine($"Here some data for {userName} name: \n" +
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
			AgeByNameModel age = await AgeByName.
				LoadValue(name).ConfigureAwait(false);

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
		private static async Task<string[]> LoadActivities()
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
		private static async Task<string[]> LoadJokes()
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
