using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Graphics.Common;
using General.Utilities;

namespace MapEditor.UI.Core.Common.Noise {
	public class WhiteNoise : INoise {
		public Bitmap NoiseMap { get; set; }

		public int Width, Height;
		public bool R { get; private set; }
		public bool G { get; private set; }
		public bool B { get; private set; }
		public byte StartRange;
		public byte EndRange;

		public WhiteNoise SetRange(byte range) {
			this.StartRange = 0;
			this.EndRange = range;
			return this;
		}

		public WhiteNoise SetRange(byte start, byte end) {
			this.StartRange = start;
			this.EndRange = end;
			return this;
		}

		public WhiteNoise(int width, int height) {
			this.Width = width;
			this.Height = height;
		}

		public INoise Generate() {
			LockBitmap lockNoise = new LockBitmap(new Bitmap(Width, Height));
			lockNoise.Lock();

			Random r = new Random();

			for (int y = 0; y < lockNoise.Height; y++) {
				for (int x = 0; x < lockNoise.Width; x++) {
					int rStart = StartRange;
					int rEnd = EndRange;

					if (rStart > rEnd) {
						rStart = rEnd;
						rEnd = rStart;
					}

					Color col = Color.Black;
					int c1 = r.Next(rStart, rEnd);
					int c2 = r.Next(rStart, rEnd);
					int c3 = r.Next(rStart, rEnd);

					if (!R && !G && !B) col = Color.FromArgb(c1, c1, c1);
					if (R && !G && !B) col = Color.FromArgb(c2, c1, c1);
					if (!R && G && !B) col = Color.FromArgb(c1, c2, c1);
					if (!R && !G && B) col = Color.FromArgb(c1, c1, c2);
					if (R && G && !B) col = Color.FromArgb(c1, c2, c3);
					if (!R && G && B) col = Color.FromArgb(c1, c2, c3);
					if (R && !G && B) col = Color.FromArgb(c1, c2, c3);
					if (R && G && B) col = Color.FromArgb(c1, c2, c3);

					lockNoise.SetPixel(x, y, col);
				}
			}
			this.NoiseMap = lockNoise.Unlock();
			return this;
		}
	}
}