using System;
using System.Collections.Generic;
using System.IO;

namespace Async_Kursach
{
	/// <summary>
	///	Class for storing information from
	/// a csv or json file for using in other classes
	/// OR
	/// Container for data
	/// </summary>
	class ConfigData
	{
		#region Fields

		const string ConfigDataFileName = "ConfigData.csv";
		private Dictionary<ConfigDataValueName, string> values =
			new Dictionary<ConfigDataValueName, string>();

		// delete these strings and SetDefaultValues method, if 
		// You want the user always be connected to the internet
		const string greeting = "Hi, My name is Async Kursach and I will " +
			"help You to have some fun!/n Which one do You want to do?\n " +
			"1 - to predict some data, depending on Your name\n " +
			"2 - find something to do by getting suggestions for random activities\n " +
			"3 - get a joke";
		const string enterName = "Enter Your name:";
		const string wrongNumber = "That's the wrong number";

		#endregion

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
		public string WrongNumber
		{
			get { return values[ConfigDataValueName.WrongNumber]; }
		}

		#endregion

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
					string[] tokens = currentLine.Split(',');
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

		#endregion

		/// <summary>
		/// Sets the configuration data fields to default values
		/// csv string
		/// </summary>
		void SetDefaultValues()
		{
			values.Clear();
			values.Add(ConfigDataValueName.Greeting, greeting);
			values.Add(ConfigDataValueName.EnterName, enterName);
			values.Add(ConfigDataValueName.WrongNumber, wrongNumber);
		}
	}
}
