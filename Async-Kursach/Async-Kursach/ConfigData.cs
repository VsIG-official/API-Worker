using System;
using System.Collections.Generic;
using System.IO;

namespace Async_Kursach.Fundamentals
{
	/// <summary>
	///	Class for storing information from
	/// a csv or json file for using in other classes
	/// OR
	/// Container for data
	/// </summary>
	internal class ConfigData
	{
		#region Fields

		private const string ConfigDataFileName = "ConfigData.csv";

		private readonly Dictionary<ConfigDataValueName, string> values =
			new Dictionary<ConfigDataValueName, string>();

		#region StringsForValues

		// Delete these strings and SetDefaultValues method, if
		// You want the user always be connected to the internet
		private const string greeting = "Hi, My name is Async Kursach and I will " +
			"help You to have some fun!\n";
		private  string nextChoice = " Which one do You want to do?\n" +
			"1 - to predict some data, depending on Your name\n" +
			"2 - find something to do by getting suggestions for random activities\n" +
			"3 - get a joke \n4 - do everything";
		private const string enterName = "Enter Your name:";
		private const string wrongData = "Something wrong with data. Try something else";
		private const string one = "1";
		private const string two = "2";
		private const string three = "3";
		private const string four = "4";

		#endregion StringsForValues

		#endregion Fields

		#region Properties

		/// <summary>
		/// Gets the string for greeting for start application
		/// </summary>
		public string Greeting
		{
			get { return values[ConfigDataValueName.Greeting]; }
		}

		/// <summary>
		/// Gets the string for entering name
		/// </summary>
		public string EnterName
		{
			get { return values[ConfigDataValueName.EnterName]; }
		}

		/// <summary>
		/// Gets the string for entering wrong number
		/// </summary>
		public string WrongData
		{
			get { return values[ConfigDataValueName.WrongData]; }
		}

		/// <summary>
		/// Gets the string for entering next choice taxt
		/// </summary>
		public string NextChoice
		{
			get { return values[ConfigDataValueName.NextChoice]; }
		}

		/// <summary>
		/// Gets the string for first choice
		/// </summary>
		public string One
		{
			get { return values[ConfigDataValueName.One]; }
		}

		/// <summary>
		/// Gets the string for second choice
		/// </summary>
		public string Two
		{
			get { return values[ConfigDataValueName.Two]; }
		}

		/// <summary>
		/// Gets the string for third choice
		/// </summary>
		public string Three
		{
			get { return values[ConfigDataValueName.Three]; }
		}

		/// <summary>
		/// Gets the string for fourth choice
		/// </summary>
		public string Four
		{
			get { return values[ConfigDataValueName.Four]; }
		}

		#endregion Properties

		#region Constructor

		/// <summary>
		/// Constructor
		/// Reads configuration data from a file. If the file
		/// read fails, the object contains default values for
		/// the configuration data
		/// </summary>
		public ConfigData()
		{
			// read and save configuration data from file
			StreamReader input = null;
			try
			{
				// create stream reader object
				input = File.OpenText(Path.Combine(
					Directory.GetCurrentDirectory(), ConfigDataFileName));

				// populate values
				string currentLine = input.ReadLine();
				while (currentLine != null)
				{
					string[] tokens = currentLine.Split(';');
					ConfigDataValueName valueName =
						(ConfigDataValueName)Enum.Parse(
							typeof(ConfigDataValueName), tokens[0]);
					values.Add(valueName, tokens[1]);
					currentLine = input.ReadLine();
				}
			}
			catch (Exception e)
			{
				// set default values if something went wrong
				SetDefaultValues();
			}
			finally
			{
				// always close input file
				if (input != null)
				{
					input.Close();
				}
			}
		}

		#endregion Constructor

		#region Methods

		/// <summary>
		/// Sets the configuration data fields to default values
		/// csv string
		/// </summary>
		private void SetDefaultValues()
		{
			values.Clear();
			values.Add(ConfigDataValueName.Greeting, greeting);
			values.Add(ConfigDataValueName.EnterName, enterName);
			values.Add(ConfigDataValueName.WrongData, wrongData);
			values.Add(ConfigDataValueName.NextChoice, nextChoice);
			values.Add(ConfigDataValueName.One, one);
			values.Add(ConfigDataValueName.Two, two);
			values.Add(ConfigDataValueName.Three, three);
			values.Add(ConfigDataValueName.Four, four);
		}

		#endregion Methods
	}
}
