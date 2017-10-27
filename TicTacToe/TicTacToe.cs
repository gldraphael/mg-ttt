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
	public class TicTacToe : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private MouseState previousState;

		private Board board;

		public TicTacToe()
		{
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferHeight = Tile.Width * 3;
			graphics.PreferredBackBufferWidth = Tile.Width * 3;
		}

		protected override void Initialize()
		{
			base.Initialize();

			board = new Board(this);
			board.Initialize();
			Components.Add(board);

			Window.Title = "Tic Tac Toe";
			IsMouseVisible = true;
		}

		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			Services.AddService(typeof(SpriteBatch), spriteBatch);
			GlobalAssets.Font = Content.Load<SpriteFont>("fonts/ttt");
			// base.LoadContent();
		}

		protected override void Update(GameTime gameTime)
		{
			if(GameState.ShouldQuit)
			{
				Exit();
			}

			if(previousState.LeftButton == ButtonState.Pressed && Mouse.GetState().LeftButton == ButtonState.Released)
			{
				if(!GameState.IsGameOver)
				{
					GameState.ToggleTurn();
				}
			}
			previousState = Mouse.GetState();

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			base.Draw(gameTime);
		}
	}
}
