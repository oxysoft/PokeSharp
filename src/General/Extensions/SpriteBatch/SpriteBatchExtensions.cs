using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace General.Extensions {
	public static class SpriteBatchExtensions {
		#region Fields
		private static Texture2D pixel;
		#endregion

		#region Methods
		private static void lazyInitialize(GraphicsDevice graphicsDevice) {
			if (pixel == null) {
				pixel = new Texture2D(graphicsDevice, 1, 1);
				pixel.SetData<Color>(new Color[] { Color.White });
			}
		}
		public static void Begin(this SpriteBatch spriteBatch, Matrix matrix) {
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, null, null, null, matrix);
		}
		public static void DrawShadowedText(this SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Color color, Color outlineColor) {
			spriteBatch.DrawShadowedText(font, text, position, Vector2.One, color, outlineColor);
		}
		public static void DrawShadowedText(this SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Vector2 scale, Color color, Color outlineColor) {
			spriteBatch.DrawShadowedText(font, text, position, scale, color, outlineColor, 2);
		}
		public static void DrawShadowedText(this SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Vector2 scale, Color color, Color outlineColor, int width) {
			for (int x = 0; x <= width; x++) {
				for (int y = 0; y <= width; y++) {
					Color shadowColor = outlineColor;
					shadowColor.A = (byte)(outlineColor.A * (1f / (width * 2)));

					spriteBatch.DrawString(
						font, text, position + new Vector2(x, y),
						shadowColor, 0f,
						Vector2.Zero, scale, SpriteEffects.None, 0);
				}
			}
			spriteBatch.DrawString(
				font, text, position, color,
				0f,
				Vector2.Zero, scale, SpriteEffects.None, 0);
		}
		public static void DrawOutlinedText(this SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Color color, Color outlineColor) {
			spriteBatch.DrawShadowedText(font, text, position, Vector2.One, color, outlineColor);
		}
		public static void DrawOutlinedText(this SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Vector2 scale, Color color, Color outlineColor) {
			spriteBatch.DrawShadowedText(font, text, position, scale, color, outlineColor, 2);
		}
		public static void DrawOutlinedText(this SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Vector2 scale, Color color, Color outlineColor, int width) {
			for (int x = -width; x <= width; x++) {
				for (int y = -width; y <= width; y++) {
					spriteBatch.DrawString(
						font, text, position + new Vector2(x, y),
						Color.Lerp(outlineColor, color, 0.05f), 0f,
						Vector2.Zero, scale, SpriteEffects.None, 0);
				}
			}
			spriteBatch.DrawString(
				font, text, position, color,
				0f,
				Vector2.Zero, scale, SpriteEffects.None, 0);
		}
		public static void DrawRectangle(this SpriteBatch spriteBatch, Color color, Rectangle rectangle) {
			lazyInitialize(spriteBatch.GraphicsDevice);

			spriteBatch.Draw(pixel, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 1), color);
			spriteBatch.Draw(pixel, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, 1, rectangle.Height), color);
			spriteBatch.Draw(pixel, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + 1, 1), color);
			spriteBatch.Draw(pixel, new Rectangle(rectangle.X, rectangle.Y, 1, rectangle.Height), color);
		}
		public static void FillRectangle(this SpriteBatch spriteBatch, Color color, Rectangle rectangle) {
			lazyInitialize(spriteBatch.GraphicsDevice);

			spriteBatch.Draw(pixel, rectangle, color);
		}
		#endregion
	}
}
