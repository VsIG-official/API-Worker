using System;
using System.Collections.Generic;
using System.IO;

namespace Async_Kursach
{
	// Class for storing information from 
	// a csv or json file for using in other classes
	// Container for data
	class ConfigData
	{
		#region Fields

		const string ConfigDataFileName = "ConfigData.csv";
		Dictionary<ConfigDataValueName, string> values =
			new Dictionary<ConfigDataValueName, string>();

		#endregion

		#region Properties

		/// <summary>
		/// Gets the number of seconds in a game
		/// </summary>
		public int TotalGameSeconds
		{
			get { return (int)values[ConfigDataValueName.]; }
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
					values.Add(valueName, string.Parse(tokens[1]));
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
			values.Add(ConfigDataValueName.TotalGameSeconds, 30);
		}
	}
}
