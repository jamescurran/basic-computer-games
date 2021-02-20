namespace BasicComputerGames.Dice
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// Create an instance of our main Dice class
			var game = new Dice();

			// Call its GameLoop function. This will play the game endlessly in a loop until the player chooses to quit.
			game.GameLoop();
		}
	}
}
