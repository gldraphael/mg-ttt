using System;
using TicTacToe;

namespace TicTacToe
{
	public static class GameState
	{
		public static TileValue Turn { get; set; } = TileValue.X;

		public static void ToggleTurn()
		{
			if (Turn == TileValue.X)
				Turn = TileValue.ZERO;
			else
				Turn = TileValue.X;
		}
	}
}
