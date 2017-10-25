using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace TicTacToe
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;

		private List<List<Tile>> tiles;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferHeight = Tile.Width * 3;
			graphics.PreferredBackBufferWidth = Tile.Width * 3;
		}

		protected override void Initialize()
		{
			tiles = new List<List<Tile>>();
			for (int i = 0; i < 3; i++)
			{
				tiles.Add(new List<Tile>());
				for (int j = 0; j < 3; j++)
				{
					tiles[i].Add(new Tile(this)
					{
						Position = new Vector2(i * Tile.Width, j * Tile.Width)
					});
				}
			}

			foreach (var i in tiles)
			{
				foreach (var j in i)
				{
					Components.Add(j);
				}
			}

			base.Initialize();
			Window.Title = "Tic Tac Toe";
			IsMouseVisible = true;
		}

		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			Services.AddService(typeof(SpriteBatch), spriteBatch);
			var Font1 = Content.Load<SpriteFont>("fonts/ttt");
			// base.LoadContent();
		}

		protected override void Update(GameTime gameTime)
		{
			if(Mouse.GetState().LeftButton == ButtonState.Pressed)
			{
				GameState.ToggleTurn();
			}

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			base.Draw(gameTime);
		}
	}
}
