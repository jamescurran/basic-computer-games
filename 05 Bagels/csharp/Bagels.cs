using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Games.Common;
using static Games.Common.BasicUtil;

namespace BasicComputerGames.Bagels
{
	public class Bagels
	{
		public void GameLoop()
		{
			DisplayIntroText();
			int points = 0;
			do
			{
				var result =PlayRound();
				if (result)
					++points;
			} while (TryAgain());

			Print();
			Print($"A {points} point Bagels buff!!");
			Print("Hope you had fun. Bye.");
		}

		private const int Length = 3;
		private const int MaxGuesses = 20;

		private bool  PlayRound()
		{
			var secret = BagelNumber.CreateSecretNumber(Length);
			Print("O.K. I have a number in mind.");
			for (int guessNo = 1; guessNo <= MaxGuesses; ++guessNo)
			{
				string strGuess;
				BagelValidation isValid;
				do
				{
					Print($"Guess #{guessNo}");
					strGuess = Console.ReadLine();
					isValid = BagelNumber.IsValid(strGuess, Length);
					PrintError(isValid);
				} while (isValid != BagelValidation.Valid);

				var guess = new BagelNumber(strGuess);
				var fermi = 0;
				var pico = 0;
				(pico, fermi) = secret.CompareTo(guess);
				if(pico + fermi == 0)
					PrintNoLF("BAGELS!");
				else if (fermi == Length)
				{
					Print("You got it!");
					return true;
				}
				else
				{
					PrintList("Pico ", pico);
					PrintList("Fermi ", fermi);
				}
				Print();
			}

			Print("Oh, well.");
			Print($"That's {MaxGuesses} guesses.  My Number was {secret}");

			return false;

		}

		private void PrintError(BagelValidation isValid)
		{
			switch (isValid)
			{
				case BagelValidation.NonDigit:
					Print("What?");
					break;

				case BagelValidation.NotUnique:
					Print("Oh, I forgot to tell you that the number I have in mind has no two digits the same.");
					break;

				case BagelValidation.WrongLength:
					Print($"Try guessing a {Length}-digit number.");
					break;

				case BagelValidation.Valid:
					break;
			}
		}

		private void PrintList(string msg, int repeat)
		{
			for(int i=0; i<repeat; ++i)
				PrintNoLF(msg);
		}

		private void DisplayIntroText()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			PrintTab(33,"Bagels");
			PrintTab(15, "Creating Computing, Morristown, New Jersey.");
			Print();

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Print("Original code author unknow but suspected to be from Lawrence Hall of Science, U.C. Berkley");
			Print("Originally published in 1978 in the book 'Basic Computer Games' by David Ahl.");
			Print("Modernized and converted to C# in 2021 by James Curran (noveltheory.com).");
			Print();

			Console.ForegroundColor = ConsoleColor.Gray;
			Print("I am thinking of a three-digit number.  Try to guess");
			Print("my number and I will give you clues as follows:");
			Print("   pico   - One digit correct but in the wrong position");
			Print("   fermi  - One digit correct and in the right position");
			Print("   bagels - No digits correct");
			Print();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Print("Press any key start the game.");
			Console.ReadKey(true);
		}
	}
}