namespace Async_Kursach.Fundamentals
{
	/// <summary>
	/// Model for getting values from json
	/// </summary>
	public class GenderByNameModel
	{
		/// <summary>
		/// Gets or sets the gender of person
		/// </summary>
		/// <value>
		/// The gender of person
		/// </value>
		public string Gender { get; set; }

		/// <summary>
		/// Gets or sets the probability of gender
		/// </summary>
		/// <value>
		/// The probability of gender
		/// </value>
		public float Probability { get; set; }
	}
}
