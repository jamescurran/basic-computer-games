namespace BasicComputerGames.Bagels
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// Create an instance of our main Bagels class
			var game = new Bagels();

			// Call its GameLoop function. This will play the game endlessly in a loop until the player chooses to quit.
			game.GameLoop();
		}
	}
}
