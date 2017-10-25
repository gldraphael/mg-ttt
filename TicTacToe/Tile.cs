using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TicTacToe
{
	public class Tile : DrawableGameComponent
	{
		public const int Width = 200;
		public const int BorderWidth = 2;
		public readonly Color BackgroundColor = Color.CornflowerBlue;
		public readonly Color BorderColor = Color.Black;

		public Vector2 Position { get; set; }
		public Rectangle Bounds { get { return new Rectangle((int)Position.X, (int)Position.Y, Width, Width); } }
		public TileValue Value { get; set; } = TileValue.EMPTY;

		private SpriteBatch _sb;
		private SpriteBatch spriteBatch { get { 
				return _sb = _sb ?? Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch; 
			} 
		}
		private static Texture2D background, yellowBackground;
		private Texture2D toDraw;

		public Tile(Game game) : base(game)
		{
			if (background == null)
			{
				var colorData = new Color[Width * Width];
				var data2 = new Color[Width * Width];
				for (int i = 0; i < Width * Width; i++)
				{
					var iModWidth = i % Width;
					if(iModWidth < BorderWidth || iModWidth > Width - BorderWidth // Vertical lines
					   || i < Width * BorderWidth) // Horizontal lines (needs to be twice thicker)
					{
						colorData[i] = BorderColor;
						data2[i] = BorderColor;
					}
					else 
					{
						colorData[i] = BackgroundColor;
						data2[i] = Color.GreenYellow;
					}
				}
				background = new Texture2D(GraphicsDevice, Width, Width);
				background.SetData(colorData);

				yellowBackground = new Texture2D(GraphicsDevice, Width, Width);
				yellowBackground.SetData(data2);
			}

			toDraw = background;
		}

		protected override void LoadContent()
		{
			base.LoadContent();
		}

		public override void Update(GameTime gameTime)
		{
			// Mouse button clicked
			if (Mouse.GetState().LeftButton == ButtonState.Pressed)
			{
				// Check if it's the current tile
				if (Value == TileValue.EMPTY && Bounds.Contains(Mouse.GetState().Position))
				{
					// Update the state
					Value = GameState.Turn;
					toDraw = yellowBackground;
				}
			}

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			spriteBatch.Begin();

			// Draw the tile
			spriteBatch.Draw(toDraw, Position, Color.White);

			// Decide on the text and position
			var text = Value == TileValue.X ? "X" : Value == TileValue.ZERO ? "0" : "";
			var textPosition = Position + (new Vector2(Width) - GlobalAssets.Font.MeasureString(text)) / 2;

			// Draw the string
			spriteBatch.DrawString(GlobalAssets.Font, text, textPosition, Color.Black);
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
