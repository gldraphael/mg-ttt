using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TicTacToe
{
	public sealed class GameOverPrompt : FullScreenPrompt
	{
		private static GameOverPrompt instance { get; set; }
		private GameOverPrompt(Game game) : base(game)
		{ }
		public static GameOverPrompt GetInstance(Game game)
		{
			if (instance == null)
				instance = new GameOverPrompt(game);
			return instance;
		}

		public override void Update(GameTime gameTime)
		{
			Text = GameState.Winner == TileValue.EMPTY ? "Draw"
					: GameState.Winner == TileValue.X ? "X wins"
					: "0 wins";
			base.Update(gameTime);
		}
	}
}
