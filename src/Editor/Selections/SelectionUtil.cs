using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Editor.Selections {
	public class SelectionUtil {
		private static Texture2D pixel;

		private static void lazyInitialize(GraphicsDevice graphicsDevice) {
			if (pixel == null) {
				pixel = new Texture2D(graphicsDevice, 1, 1);
				pixel.SetData<Color>(new Color[] {Color.White});
			}
		}

		public static void DrawRectangle(SpriteBatch spriteBatch, Color color, Rectangle rectangle) {
			DrawRectangle(spriteBatch, color, 1f, rectangle);
		}

		public static void DrawRectangle(SpriteBatch spriteBatch, Color color, float opacity, Rectangle rectangle) {
			SelectionUtil.lazyInitialize(spriteBatch.GraphicsDevice);

			spriteBatch.Draw(pixel, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 1), color * opacity);
			spriteBatch.Draw(pixel, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, 1, rectangle.Height), color * opacity);
			spriteBatch.Draw(pixel, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + 1, 1), color * opacity);
			spriteBatch.Draw(pixel, new Rectangle(rectangle.X, rectangle.Y, 1, rectangle.Height), color * opacity);
		}

		public static void DrawStraightLine(SpriteBatch spriteBatch, Color color, float opacity, int x1, int y1, int dir, int length) {
			SelectionUtil.lazyInitialize(spriteBatch.GraphicsDevice);

			Rectangle rect = new Rectangle(-1, -1, -1, -1);

			if (dir == 0) rect = new Rectangle(x1, y1, 1, -length);
			if (dir == 1) rect = new Rectangle(x1, y1, length, 1);
			if (dir == 2) rect = new Rectangle(x1, y1, 1, length);
			if (dir == 3) rect = new Rectangle(x1, y1, -length, 1);
			
			if (rect.X != -1 && rect.Y != -1 && rect.Width != -1 && rect.Height != -1) spriteBatch.Draw(pixel, rect, color * opacity);
		}

		public static void DrawStraightLine(SpriteBatch spriteBatch, Color color, int x1, int y1, int dir, int length) {
			DrawStraightLine(spriteBatch, color, 1f, x1, y1, dir, length);
		}

		public static void FillRectangle(SpriteBatch spriteBatch, Color color, Rectangle rectangle) {
			SelectionUtil.lazyInitialize(spriteBatch.GraphicsDevice);

			spriteBatch.Draw(pixel, rectangle, color);
		}
	}
}