using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Games.Common.BasicUtil;

namespace BasicComputerGames.Bounce
{
	public class BounceParams
	{
		public double TimeIncrement { get; set; }
		public double Velocity { get; set; }
		public double Coeffecient { get; set; }

		public static BounceParams Read()
		{
			var p = new BounceParams
			{
				TimeIncrement = InputDouble("Time Increment (secs)"),
				Velocity = InputDouble("Velocity (FPS)"),
				Coeffecient = InputDouble("Coefficient")
			};

			return p;
		}

	}
}
