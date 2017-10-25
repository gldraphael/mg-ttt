using System;
using System.Collections.Generic;
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
	}
}
