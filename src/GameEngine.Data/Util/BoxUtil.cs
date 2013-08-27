using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Common;
using General.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Data.Util {
	public class BoxUtil {
		public static BoxUtil Instance {
			get {
				return Static<BoxUtil>.Value;
			}
		}

		public void DrawBox(SpriteBatch spriteBatch, Texture2D Texture, int columns, int rows, int x, int y, int w, int h, float opacity = 1f) {
			DrawBox(spriteBatch, new TileableTexture(Texture, columns, rows), x, y, w, h, opacity);
		}

		public void DrawBox(SpriteBatch spriteBatch, TileableTexture Texture, int x, int y, int w, int h, float opacity = 1f) {
			spriteBatch.Begin();
			for (int i = 0; i < w; i++) {
				for (int j = 0; j < h; j++) {
					int xs = 0;
					int ys = 0;

					if (j == 0) {
						xs++;
						if (i == 0) xs--;
						else if (i == w - 1) xs++;
					} else if (i == 0) {
						ys++;
						if (j == h - 1) ys++;
					} else if (i == w - 1) {
						xs++;
						xs++;
						ys++;
						if (j == h - 1) ys++;
					} else if (j == h - 1) {
						xs++;
						ys++;
						ys++;
					} else {
						xs++;
						ys++;
					}

					Rectangle sourceRectangle = Texture.GetSource(Texture.GetIndex(xs, ys));
					spriteBatch.Draw(Texture.Texture, new Rectangle(x + i * Texture.FrameWidth, y + j * Texture.FrameHeight, Texture.FrameWidth, Texture.FrameHeight), sourceRectangle, Color.White * opacity);
				}
			}
			spriteBatch.End();
		}
	}
}