using System;
using System.Linq;
using Games.Common;
using static Games.Common.BasicUtil;

namespace BasicComputerGames.Dice
{
	public class Dice
	{
		private readonly RollGenerator _roller = new RollGenerator();

		public void GameLoop()
		{
			DisplayIntroText();

			// RollGenerator.ReseedRNG(1234);		// hard-code seed for repeatabilty during testing

			do
			{
				int numRolls = GetInput();
				var counter = CountRolls(numRolls);
				DisplayCounts(counter);
			} while (TryAgain());
		}

		private void DisplayIntroText()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			PrintTab(34,"Dice");
			PrintTab(15,"Creating Computing, Morristown, New Jersey.");
			Print();

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Print("Original code by Danny Freidus.");
			Print("Originally published in 1978 in the book 'Basic Computer Games' by David Ahl.");
			Print("Modernized and converted to C# in 2021 by James Curran (noveltheory.com).");
			Print();

			Console.ForegroundColor = ConsoleColor.Gray;
			Print("This program simulates the rolling of a pair of dice.");
			Print("You enter the number of times you want the computer to");
			Print("'roll' the dice. Watch out, very large numbers take");
			Print("a long time. In particular, numbers over 10 million.");
			Print();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Print("Press any key start the game.");
			Console.ReadKey(true);
		}

		private int GetInput()
		{
			int num;
			Print();
			do
			{
				Print();
				PrintNoLF("How many rolls? ");
			} while (!Int32.TryParse(Console.ReadLine(), out num));

			return num;
		}

		private  void DisplayCounts(int[] counter)
		{
			Print();
			Print($"\tTotal\tTotal Number");
			Print($"\tSpots\tof Times");
			Print($"\t===\t=========");
			for (var n = 1; n < counter.Length; ++n)
			{
				Print($"\t{n + 1,2}\t{counter[n],9:#,0}");
			}
			Print();
		}

		private  int[] CountRolls(int x)
		{
			var counter = _roller.Rolls().Take(x).Aggregate(new int[12], (cntr, r) =>
			{
				cntr[r.die1 + r.die2 - 1]++;
				return cntr;
			});
			return counter;
		}
	}
}