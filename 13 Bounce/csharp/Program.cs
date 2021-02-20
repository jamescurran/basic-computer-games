using static Games.Common.BasicUtil;

namespace BasicComputerGames.Bounce
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Bounce.DisplayIntroText();
			var parms = BounceParams.Read();
			var game = new Bounce(parms);

			Print(game.ToString());
		}
	}
}
