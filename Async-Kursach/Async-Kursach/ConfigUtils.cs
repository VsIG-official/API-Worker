namespace Async_Kursach
{
	/// <summary>
	/// Static class for storing data
	/// OR
	/// Mechanism for accessing the data
	/// </summary>
	static class ConfigUtils
	{
		#region Fields

		static ConfigData configData;

		#endregion

		#region Properties

		/// <summary>
		/// Gets the string for greeting for start application
		/// </summary>
		public static string Greeting
		{
			get { return configData.Greeting; }
		}

		/// <summary>
		/// Gets the string for entering name
		/// </summary>
		public static string EnterName
		{
			get { return configData.EnterName; }
		}

		/// <summary>
		/// Gets the string for entering wrong number
		/// </summary>
		public static string WrongNumber
		{
			get { return configData.WrongNumber; }
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Initializes the configuration data by creating the ConfigData object 
		/// </summary>
		public static void Initialize()
		{
			configData = new ConfigData();
		}

		#endregion
	}
}
