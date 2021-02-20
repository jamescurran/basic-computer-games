using System;
using System.Linq;
using System.Text;
using static System.Math;
using static Games.Common.BasicUtil;


namespace BasicComputerGames.Bounce
{
	public class Bounce
	{
		private readonly BounceParams _parms;
		public Bounce(BounceParams parms)
		{
			_parms = parms;
		}

		public override string ToString()
		{
			var s1 = (int) (70 / (_parms.Velocity / (16 * _parms.TimeIncrement)));
			var T = Enumerable.Range(0, s1)
				.Select(i => _parms.Velocity * Pow(_parms.Coeffecient, i) / 16)
				.ToArray();
			int width = (int) (T.Sum() / _parms.TimeIncrement) +10;
			var graph = new StringBuilder(2048);
			var v32 = _parms.Velocity / 32;
			bool yLabel = true;
			var elapsedTime = 0.0d;

			for (double height = Floor(-16 * v32 * v32 + _parms.Velocity * _parms.Velocity / 32 + .5);
				height >= 0.0;
				height -= .5)
			{
				elapsedTime = 0.0d;

				var line = new StringBuilder(width);
				line.Append(' ', width);
				for (int i = 0; i < s1; ++i)
				{
					var coeffToI = Pow(_parms.Coeffecient, i);

					for (double t = 0; t < T[i]; t += _parms.TimeIncrement)
					{
						elapsedTime += _parms.TimeIncrement;
						if (Abs(height - (.5 * (-32.0) * t * t + _parms.Velocity * coeffToI * t)) <= .25)
							line[(int) (elapsedTime / _parms.TimeIncrement)] = 'O';
					}
					var tt = T[i] / 2;
					if (-16 * tt * tt + _parms.Velocity * coeffToI * tt < height)
						break;
				}

				graph.Append(yLabel ? $"{height,-2}" : "  ");
				yLabel = !yLabel;
				graph.Append(line);
				graph.AppendLine();


			}
			graph.Append(' ');
			graph.Append('.', (int)((elapsedTime + 1) / _parms.TimeIncrement + 1));
			graph.AppendLine();

			var fmt = $"{{0,{(1 / _parms.TimeIncrement)} }}";
			graph.Append(" 0");
			for (int i = 1; i < elapsedTime + .9995; ++i)
			{
				graph.AppendFormat(fmt, i);
			}

			graph.AppendLine();

			graph.Append(' ', width / 2 - 2);
			graph.AppendLine("Seconds");
			graph.Append(' ');

			return graph.ToString();
		}

		public static  void DisplayIntroText()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			PrintTab(34, "Bounce");
			PrintTab(15, "Creating Computing, Morristown, New Jersey.");
			Print();

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Print("Original code by Val Skalabrin");
			Print("Originally published in 1978 in the book 'Basic Computer Games' by David Ahl.");
			Print("Modernized and converted to C# in 2021 by James Curran (noveltheory.com).");
			Print();

			Console.ForegroundColor = ConsoleColor.Gray;
			Print("This simulation lets you specify the initial velocity");
			Print("of a ball thrown straight up, and the coefficient of");
			Print("elasticity of the ball.  Please use a decimal fraction");
			Print("coefficiency (less than 1).");
			Print();


			Print("You also specify the time increment to be used in");
			Print("'strobing' the ball's flight (Try .1 initially).");

			Console.ForegroundColor = ConsoleColor.Yellow;
			Print("Press any key start the game.");
			Console.ReadKey(true);
		}
	}
}
