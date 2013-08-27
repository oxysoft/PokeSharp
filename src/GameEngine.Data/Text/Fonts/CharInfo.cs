using System;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Data.Text.Fonts {
	public class CharInfo {
		public int Font;
		public int OffX, OffY;
		public char Character;
		public Texture2D Texture;

		public int Width {
			get { return Texture.Width; }
		}

		public int Height {
			get { return Texture.Height; }
		}

		public CharInfo(int font, char c, Texture2D Texture) {
			this.Character = c;
			this.Texture = Texture;
			this.Font = font;
			foreach (Tuple<char, int, int> token in CharOffsetTable.Offsets[font].Where(token => token.Item1 == c)) {
				OffX = token.Item2;
				OffY = token.Item3;
			}
		}

		public int Length {
			get { return Width; }
		}

	}
}