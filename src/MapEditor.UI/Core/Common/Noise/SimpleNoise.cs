using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Graphics.Common;
using General.Utilities;

namespace MapEditor.UI.Core.Common.Noise {
	public class SimpleNoise : INoise {
		public Bitmap NoiseMap { get; set; }
		private double[] values;
		private int w, h;

		public SimpleNoise(int width, int height) {
			this.w = width;
			this.h = height;
			Generate();
		}

		public INoise Generate() {
			LockBitmap bitmap = new LockBitmap(new Bitmap(w, h));
			const int featureSize = 16;

			values = new double[w * h];

			for (int y = 0; y < h; y += featureSize) {
				for (int x = 0; x < h; x += featureSize) {
					SetSample(x, y, Randomizer.NextDouble() * 2 - 1);
				}
			}

			int stepSize = featureSize;
			double scale = 1.0f / w;
			double scaleMod = 1f;

			do {
				int halfStep = stepSize / 2;
				for (int y = 0; y < w; y += stepSize) {
					for (int x = 0; x < w; x += stepSize) {
						double a = Sample(x, y);
						double b = Sample(x + stepSize, y);
						double c = Sample(x, y + stepSize);
						double d = Sample(x + stepSize, y + stepSize);

						double e = (a + b + c + d) / 4.0 + (Randomizer.NextDouble() * 2 - 1) * stepSize * scale;
						SetSample(x + halfStep, y + halfStep, e);
					}
				}
				for (int y = 0; y < w; y += stepSize) {
					for (int x = 0; x < w; x += stepSize) {
						double a = Sample(x, y);
						double b = Sample(x + stepSize, y);
						double c = Sample(x, y + stepSize);
						double d = Sample(x + halfStep, y + halfStep);
						double e = Sample(x + halfStep, y - halfStep);
						double f = Sample(x - halfStep, y + halfStep);

						double H = (a + b + d + e) / 4.0 + (Randomizer.NextDouble() * 2 - 1) * stepSize * scale * 0.5;
						double g = (a + c + d + f) / 4.0 + (Randomizer.NextDouble() * 2 - 1) * stepSize * scale * 0.5;
						SetSample(x + halfStep, y, H);
						SetSample(x, y + halfStep, g);
					}
				}
				stepSize /= 2;
				scale *= (scaleMod + 0.8);
				scaleMod *= 0.3;
			} while (stepSize > 1);
			bitmap.Lock();
			for (int i = 0; i < values.Length; i++) {
				double val = values[i];
				int x = i % w;
				int y = i / w;
				byte c = (byte) Math.Abs(255 * val);
				Color col = Color.FromArgb(c, c, c);
				bitmap.SetPixel(x, y, col);
			}
			this.NoiseMap = bitmap.Unlock();
			return this;
		}

		private double Sample(int x, int y) {
			return values[(x & (w - 1)) + (y & (h - 1)) * w];
		}

		private void SetSample(int x, int y, double value) {
			values[(x & (w - 1)) + (y & (h - 1)) * w] = value;
		}
	}
}