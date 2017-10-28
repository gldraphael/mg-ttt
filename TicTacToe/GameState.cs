﻿using System.Diagnostics;
using Microsoft.Xna.Framework.Input;

namespace TicTacToe
{
	public static class GameState
	{
		public static TileValue Turn { get; set; } = TileValue.X;
		public static TileValue Winner { get; set; } = TileValue.EMPTY;

		public static bool ShouldQuit { get; set; } = false;
		public static bool IsGameOver { get { return Winner != TileValue.EMPTY; }}
		public static bool IsFullScreenPromptBeingShown { get; set; } = false;

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
			IsFullScreenPromptBeingShown = false;
		}
	}
}
