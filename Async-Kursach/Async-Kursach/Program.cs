using System;
using System.Collections.Generic;

namespace Async_Kursach.Fundamentals
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
				ApiMethods.LoadNameInfo().ConfigureAwait(false); };
			operations["2"] = async () => { await
				ApiMethods.LoadActivities().ConfigureAwait(false); };
			operations["3"] = async () => { await
				ApiMethods.LoadJokes().ConfigureAwait(false); };
			operations["4"] = async () => { await
				ApiMethods.CallAllAPI().ConfigureAwait(false); };
		}
	}
}
