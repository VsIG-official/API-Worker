using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
			Console.WriteLine(Regex.Unescape(ConfigUtils.Greeting));

			LoadChoices();
		}

		/// <summary>
		/// Loads the choices.
		/// </summary>
		static void LoadChoices()
		{
			Console.WriteLine(Regex.Unescape(ConfigUtils.NextChoice));

			string userChoice = Console.ReadLine();

			try
			{
				// accepts the delegate and executes it in the thread
				// in which the control called Invoke was created
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
		/// Replacement of if-else with lambdas
		/// </summary>
		private static void CreateOperations()
		{
			operations[ConfigUtils.One] = async () =>
			{
				await ApiMethods.LoadNameInfo().
				ConfigureAwait(false);
			};
			operations[ConfigUtils.Two] = async () =>
			{
				await ApiMethods.LoadActivities().
				ConfigureAwait(false);
			};
			operations[ConfigUtils.Three] = async () =>
			{
				await ApiMethods.LoadJokes().
				ConfigureAwait(false);
			};
			operations[ConfigUtils.Four] = async () =>
			{
				await ApiMethods.CallAllAPI().
				ConfigureAwait(false);
			};
		}
	}
}
