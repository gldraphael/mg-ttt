﻿using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TicTacToe
{
	public class FullScreenPrompt : DrawableGameComponent
	{
		protected Color Background = Color.CornflowerBlue;
		protected string Text { get; set; } = "";

		private SpriteBatch _sb;
		private SpriteBatch spriteBatch
		{
			get
			{
				return _sb = _sb ?? Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
			}
		}

		public bool IsVisible { get; set; } = false;
		public int Width => GraphicsDevice.Viewport.Width;
		public int Height => GraphicsDevice.Viewport.Width;

		public FullScreenPrompt(Game game) : base(game)
		{
		}

		public override void Draw(GameTime gameTime)
		{
			spriteBatch.Begin();
			GraphicsDevice.Clear(Color.FloralWhite);

			// Decide on the text and position
			var textPosition = (new Vector2(Width, Height) - GlobalAssets.Font.MeasureString(Text)) / 2;
			spriteBatch.DrawString(GlobalAssets.Font, Text, textPosition, Color.Black);

			spriteBatch.End();
			base.Draw(gameTime);
		}

		public void Show()
		{
			Game.Components.Add(this);
			IsVisible = true;
		}

		public void Hide()
		{
			Game.Components.Remove(this);
			IsVisible = false;
		}
	}
}
