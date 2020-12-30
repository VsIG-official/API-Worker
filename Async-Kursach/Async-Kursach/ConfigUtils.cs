namespace Async_Kursach
{
	// static class for storing data
	// mechanism for accessing the data
	class ConfigUtils
	{
		#region Fields

		static ConfigData configData;

		#endregion

		#region Properties

		/// <summary>
		/// Gets the number of seconds in a game
		/// </summary>
		public static string Greeting
		{
			get { return configData.Greeting; }
		}

		/// <summary>
		/// Gets the number of seconds in a game
		/// </summary>
		public static string EnterName
		{
			get { return configData.EnterName; }
		}

		/// <summary>
		/// Gets the number of seconds in a game
		/// </summary>
		public static string WrongNumber
		{
			get { return configData.WrongNumber; }
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Initializes the configuration data by creating the ConfigurationData object 
		/// </summary>
		public static void Initialize()
		{
			configData = new ConfigData();
		}

		#endregion
	}
}
