using Async_Kursach.Fundamentals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Async_Kursach.UnitTests
{
	/// <summary>
	/// Class, which have all tests
	/// </summary>
	[TestClass]
	public class AsyncKursachTests
	{
		/// <summary>
		/// Loads Maks age and is equal
		/// </summary>
		[TestMethod]
		public async Task LoadNameAge_Maks_Equal()
		{
			// Arrange
			string name = "Maks";
			int expected = 30;

			ConfigUtils.Initialize();
			ApiHelper.Initialize();

			// Act
			int actual = await ApiMethods.LoadNameAge(name).
				ConfigureAwait(false);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Loads Maks age and is not equal
		/// </summary>
		[TestMethod]
		public async Task LoadNameAge_Maks_NotEqual()
		{
			// Arrange
			string name = "Maks";
			int expected = 20;

			ConfigUtils.Initialize();
			ApiHelper.Initialize();

			// Act
			int actual = await ApiMethods.LoadNameAge(name).
				ConfigureAwait(false);

			// Assert
			Assert.AreNotEqual(expected, actual);
		}

		/// <summary>
		/// Loads Maks gender and is equal
		/// </summary>
		[TestMethod]
		public async Task LoadNameGender_MaksGender_Equal()
		{
			// Arrange
			string name = "Maks";
			string expected = "male";

			ConfigUtils.Initialize();
			ApiHelper.Initialize();

			// Act
			string[] actual = await ApiMethods.LoadNameGender(name).
				ConfigureAwait(false);

			// Assert
			Assert.AreEqual(expected, actual[0]);
		}

		/// <summary>
		/// Loads Maks gender and is not equal
		/// </summary>
		[TestMethod]
		public async Task LoadNameGender_MaksGender_NotEqual()
		{
			// Arrange
			string name = "Maks";
			string expected = "female";

			ConfigUtils.Initialize();
			ApiHelper.Initialize();

			// Act
			string[] actual = await ApiMethods.LoadNameGender(name).
				ConfigureAwait(false);

			// Assert
			Assert.AreNotEqual(expected, actual[0]);
		}

		/// <summary>
		/// Loads Maks gender probability and is equal
		/// </summary>
		[TestMethod]
		public async Task LoadNameGender_MaksProbability_Equal()
		{
			// Arrange
			string name = "Maks";
			string expected = "0,99";

			ConfigUtils.Initialize();
			ApiHelper.Initialize();

			// Act
			string[] actual = await ApiMethods.LoadNameGender(name).
				ConfigureAwait(false);

			// Assert
			Assert.AreEqual(expected, actual[1]);
		}

		/// <summary>
		/// Loads Maks gender probability and is equal
		/// </summary>
		[TestMethod]
		public async Task LoadNameGender_MaksProbability_NotEqual()
		{
			// Arrange
			string name = "Maks";
			string expected = "0,88";

			ConfigUtils.Initialize();
			ApiHelper.Initialize();

			// Act
			string[] actual = await ApiMethods.LoadNameGender(name).
				ConfigureAwait(false);

			// Assert
			Assert.AreNotEqual(expected, actual[1]);
		}

		/// <summary>
		/// Loads Maks age, gender, its probability and is equal
		/// </summary>
		[TestMethod]
		public async Task LoadNameInfo_Maks_Equal()
		{
			// Arrange
			string name = "Maks";
			int expectedAge = 30;
			string[] expectedGender = { "male", "0,99" };

			ConfigUtils.Initialize();
			ApiHelper.Initialize();

			// Act
			int actualAge = await ApiMethods.LoadNameAge(name).
				ConfigureAwait(false);

			string[] actualGender = await ApiMethods.LoadNameGender(name).
				ConfigureAwait(false);

			// Assert
			Assert.AreEqual(expectedAge, actualAge);
			Assert.AreEqual(expectedGender[0], actualGender[0]);
			Assert.AreEqual(expectedGender[1], actualGender[1]);
		}

		/// <summary>
		/// Loads Maks age, gender, its probability and is not equal
		/// </summary>
		[TestMethod]
		public async Task LoadNameInfo_Maks_NotEqual()
		{
			// Arrange
			string name = "Maks";
			int expectedAge = 20;
			string[] expectedGender = { "female", "0,88" };

			ConfigUtils.Initialize();
			ApiHelper.Initialize();

			// Act
			int actualAge = await ApiMethods.LoadNameAge(name).
				ConfigureAwait(false);

			string[] actualGender = await ApiMethods.LoadNameGender(name).
				ConfigureAwait(false);

			// Assert
			Assert.AreNotEqual(expectedAge, actualAge);
			Assert.AreNotEqual(expectedGender[0], actualGender[0]);
			Assert.AreNotEqual(expectedGender[1], actualGender[1]);
		}

		/// <summary>
		/// Loads Activity and is not null
		/// </summary>
		[TestMethod]
		public async Task LoadActivity_NotNull()
		{
			// Arrange
			ConfigUtils.Initialize();
			ApiHelper.Initialize();

			// Act
			string[] actual = await ApiMethods.LoadActivities().
				ConfigureAwait(false);

			// Assert
			for (int i = 0; i < actual.Length; i++)
			{
				Assert.IsNotNull(actual[i]);
			}
		}
	}
}
