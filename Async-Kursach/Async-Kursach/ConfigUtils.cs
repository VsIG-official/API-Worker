namespace Async_Kursach.Fundamentals
{
	/// <summary>
	/// Static class for storing data
	/// OR
	/// Mechanism for accessing the data
	/// </summary>
	internal static class ConfigUtils
	{
		#region Fields

		private static ConfigData configData;

		#endregion Fields

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
		/// Gets the string for wrong data
		/// </summary>
		public static string WrongData
		{
			get { return configData.WrongData; }
		}

		/// <summary>
		/// Gets the string for wrong data
		/// </summary>
		public static string NextChoice
		{
			get { return configData.NextChoice; }
		}

		/// <summary>
		/// Gets the string for first choice
		/// </summary>
		public static string One
		{
			get { return configData.One; }
		}

		/// <summary>
		/// Gets the string for second choice
		/// </summary>
		public static string Two
		{
			get { return configData.Two; }
		}

		/// <summary>
		/// Gets the string for third choice
		/// </summary>
		public static string Three
		{
			get { return configData.Three; }
		}

		/// <summary>
		/// Gets the string for fourth choice
		/// </summary>
		public static string Four
		{
			get { return configData.Four; }
		}

		/// <summary>
		/// Gets the string for fourth choice
		/// </summary>
		public static string DefaultName
		{
			get { return configData.DefaultName; }
		}

		/// <summary>
		/// Gets the URL for Age API
		/// </summary>
		public static string AgeByNameURL
		{
			get { return configData.AgeByNameURL; }
		}

		/// <summary>
		/// Gets the URL for Gender API
		/// </summary>
		public static string GenderByNameURL
		{
			get { return configData.GenderByNameURL; }
		}

		/// <summary>
		/// Gets the URL for Activities API
		/// </summary>
		public static string ActivitiesURL
		{
			get { return configData.ActivitiesURL; }
		}

		/// <summary>
		/// Gets the URL for Jokes API
		/// </summary>
		public static string JokesURL
		{
			get { return configData.JokesURL; }
		}

		#endregion Properties

		#region PublicMethods

		/// <summary>
		/// Initializes the configuration data by creating the ConfigData object
		/// </summary>
		public static void Initialize()
		{
			configData = new ConfigData();
		}

		#endregion PublicMethods
	}
}
