using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_Kursach
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hi, My name is Async Kursach and " +
				"I will help You to have some fun!");
			Console.WriteLine("Which one do You want to do?");
			Console.WriteLine("1 for Translation and 2 for " +
				"{insert Your functionality}");

			string userChoice = Console.ReadLine();

			if (userChoice=="1")
			{
				//Console.WriteLine("Which one do You want to do?");
				Console.WriteLine("Enter Your sentence:");
				string userSentence = Console.ReadLine();
			}
			else
			{
			Console.WriteLine("That's the wrong number");
			}
		}
	}
}
