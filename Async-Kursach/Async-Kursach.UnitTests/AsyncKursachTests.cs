using Microsoft.VisualStudio.TestTools.UnitTesting;
using Async_Kursach.Fundamentals;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Async_Kursach.UnitTests
{
	[TestClass]
	public class AsyncKursachTests
	{
		[TestMethod]
		public async Task LoadNameAge_Maks_ReturnTrue()
		{
			// Arrange
			string name = "Maks";
			int expected = 30;

			ApiHelper.Initialize();

			// Act
			int actual = await ApiMethods.LoadNameAge(name).
				ConfigureAwait(false);

			// Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public async Task LoadNameAge_Maks_ReturnFalse()
		{
			// Arrange
			string name = "Maks";
			int expected = 20;

			ApiHelper.Initialize();

			// Act
			int actual = await ApiMethods.LoadNameAge(name).
				ConfigureAwait(false);

			// Assert
			Assert.AreNotEqual(expected, actual);
		}

		[TestMethod]
		public async Task LoadNameGender_MaksGender_ReturnTrue()
		{
			// Arrange
			string name = "Maks";
			string expected = "male";

			ApiHelper.Initialize();

			// Act
			string[] actual = await ApiMethods.LoadNameGender(name).
				ConfigureAwait(false);

			// Assert
			Assert.AreEqual(expected, actual[0]);
		}

		[TestMethod]
		public async Task LoadNameGender_MaksGender_ReturnFalse()
		{
			// Arrange
			string name = "Maks";
			string expected = "female";

			ApiHelper.Initialize();

			// Act
			string[] actual = await ApiMethods.LoadNameGender(name).
				ConfigureAwait(false);

			// Assert
			Assert.AreNotEqual(expected, actual[0]);
		}

		[TestMethod]
		public async Task LoadNameGender_MaksProbability_ReturnTrue()
		{
			// Arrange
			string name = "Maks";
			string expected = "0,99";

			ApiHelper.Initialize();

			// Act
			string[] actual = await ApiMethods.LoadNameGender(name).
				ConfigureAwait(false);

			// Assert
			Assert.AreEqual(expected, actual[1]);
		}

		[TestMethod]
		public async Task LoadNameGender_MaksProbability_ReturnFalse()
		{
			// Arrange
			string name = "Maks";
			string expected = "0,99";

			ApiHelper.Initialize();

			// Act
			string[] actual = await ApiMethods.LoadNameGender(name).
				ConfigureAwait(false);

			// Assert
			Assert.AreNotEqual(expected, actual[1]);
		}

		[TestMethod]
		public async Task LoadNameInfo_Maks_ReturnTrue()
		{
			// Arrange
			string name = "Maks";
			int expectedAge = 30;
			string[] expectedGender = { "male", "0,99" };

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

		[TestMethod]
		public async Task LoadNameInfo_Maks_ReturnFalse()
		{
			// Arrange
			string name = "Maks";
			int expectedAge = 20;
			string[] expectedGender = { "female", "0,88" };

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
	}
}
