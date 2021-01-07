namespace Async_Kursach.Fundamentals
{
	/// <summary>
	/// Model for getting values from json
	/// </summary>
	public class ActivitiesModel
	{
		/// <summary>
		/// Gets or sets the activity
		/// </summary>
		/// <value>
		/// Activity
		/// </value>
		public string Activity { get; set; }

		/// <summary>
		/// Gets or sets the type of activity
		/// </summary>
		/// <value>
		/// Type of activity
		/// </value>
		public string Type { get; set; }

		/// <summary>
		/// Gets or sets the participants of activity
		/// </summary>
		/// <value>
		/// The participants of activity
		/// </value>
		public string Participants { get; set; }

		/// <summary>
		/// Gets or sets the price of activity
		/// </summary>
		/// <value>
		/// The price of activity
		/// </value>
		public string Price { get; set; }
	}
}
