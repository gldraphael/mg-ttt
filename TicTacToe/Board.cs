using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace TicTacToe
{
	public class Board : DrawableGameComponent
	{
		private List<List<Tile>> tiles;

		public Board(Game game) : base(game)
		{
			
		}

		public override void Initialize()
		{
			base.Initialize();
			initTiles();
			tiles.ForEach(l => l.ForEach(t => Game.Components.Add(t)));
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			if(GameState.IsGameOver && !GameState.IsFullScreenPromptBeingShown)
			{
				Game.Components.Add(GameOverPrompt.GetInstance(Game));
				GameState.IsFullScreenPromptBeingShown = true;
			}
			else // Check if any of the gameover conditions are satisfied
			{ 
				// Check the diagonals
				var gameOver = isSame(tiles[0][0], tiles[1][1], tiles[2][2])
					|| isSame(tiles[0][2], tiles[1][1], tiles[2][0]);

				// Check the columns
				for (int i = 0; i < 3; i++)
				{
					gameOver = gameOver || isSame(tiles[i].ToArray()); // Columns
				}
				// Check the rows
				for (int i = 0; i < 3; i++)
				{
					gameOver = gameOver || isSame(tiles.Select(x => x[i]).ToArray()); // Rows
				}

				if (gameOver)
				{
					GameState.Winner = GameState.Turn;
				}
			}
		}

		protected override void UnloadContent()
		{
			tiles.ForEach(l => l.ForEach(t => Game.Components.Remove(t)));
			base.UnloadContent();
		}

		private void initTiles()
		{
			tiles = new List<List<Tile>>();
			for (int i = 0; i < 3; i++)
			{
				tiles.Add(new List<Tile>());
				for (int j = 0; j < 3; j++)
				{
					tiles[i].Add(new Tile(this.Game)
					{
						Position = new Vector2(i * Tile.Width, j * Tile.Width)
					});
				}
			}
		}

		private static bool isSame(params TileValue[] values)
		{
			if (values == null)
				return false;

			if (values.Length == 0)
				return true;
			
			var first = values[0] == TileValue.EMPTY ? TileValue.X : values[0]; // Condition because we don't want it to quit for all EMPTY values
			for (int i = 1; i < values.Length; i++)
			{
				if (values[i] != first)
					return false;
			}
			return true;
		}

		private static bool isSame(params Tile[] values)
		{
			return isSame(values.Select(x => x.Value).ToArray());
		}
	}
}
