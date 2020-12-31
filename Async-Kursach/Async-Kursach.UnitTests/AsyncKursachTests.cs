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
		public async Task LoadNameAge_ShouldReturnAgeAsync()
		{
			// Arrange
			string name = "Maks";
			int expected = 29;
			ApiHelper.Initialize();

			// Act
			int actual = await ApiMethods.LoadNameAge(name).ConfigureAwait(false);

			// Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
