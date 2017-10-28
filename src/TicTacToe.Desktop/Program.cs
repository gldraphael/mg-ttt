#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace TicTacToe
{
	public static class Program
	{
		static void Main (string [] args)
		{
			using (var game = new TicTacToe ()) {
				game.Run ();
			}
		}
	}
}
