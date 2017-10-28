using System.Diagnostics;
using Microsoft.Xna.Framework.Input;

namespace TicTacToe
{
	public static class GameState
	{
		public static TileValue Turn { get; set; } = TileValue.X;
		public static TileValue Winner { get; set; } = TileValue.EMPTY;

		/// <summary>
		/// Set this to true to quit the application in the next loop
		/// </summary>
		/// <value><c>true</c> if should quit; otherwise, <c>false</c>.</value>
		public static bool ShouldQuit { get; set; } = false;

		/// <value><c>true</c> if is game over; otherwise, <c>false</c>.</value>
		public static bool IsGameOver { get { return Winner != TileValue.EMPTY; }}

		public static void ToggleTurn()
		{
			if (Turn == TileValue.X)
				Turn = TileValue.ZERO;
			else
				Turn = TileValue.X;
		}

		public static void Reset()
		{
			Turn = TileValue.X;
			Winner = TileValue.EMPTY;
			ShouldQuit = false;
		}
	}
}
