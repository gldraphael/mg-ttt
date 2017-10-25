using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TicTacToe
{
	public class Tile : DrawableGameComponent
	{
		public const int Width = 200;
		public const int BorderWidth = 2;
		public readonly Color BackgroundColor = Color.CornflowerBlue;
		public readonly Color BorderColor = Color.Black;

		public Vector2 Position { get; set; }
		public TileValue Value { get; set; } = TileValue.EMPTY;

		private SpriteBatch _sb;
		private SpriteBatch spriteBatch { get { 
				return _sb = _sb ?? Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch; 
			} 
		}
		private static Texture2D background;

		public Tile(Game game) : base(game)
		{
			if (background == null)
			{
				var colorData = new Color[Width * Width];
				for (int i = 0; i < Width * Width; i++)
				{
					var iModWidth = i % Width;
					if(iModWidth < BorderWidth || iModWidth > Width - BorderWidth // Vertical lines
					   || i < Width * BorderWidth) // Horizontal lines (needs to be twice thicker)
					{
						colorData[i] = BorderColor;
					}
					else 
					{
						colorData[i] = BackgroundColor;
					}

				}
				background = new Texture2D(GraphicsDevice, Width, Width);
				background.SetData(colorData);
			}
		}

		protected override void LoadContent()
		{
			base.LoadContent();
		}

		public override void Draw(GameTime gameTime)
		{
			spriteBatch.Begin();
			spriteBatch.Draw(background, Position, Color.White);
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
