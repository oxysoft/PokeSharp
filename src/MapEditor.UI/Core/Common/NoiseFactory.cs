using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Common;
using General.Graphics.Common;
using General.Utilities;
using MapEditor.UI.Core.Common.Brushes;
using MapEditor.UI.Core.Common.Noise;

namespace MapEditor.UI.Core.Common {
	public class NoiseFactory {
		public static Bitmap CreateNoise(NoiseType noise) {
			return CreateNoise(noise, 600, 600);
		}

		public static Bitmap CreateNoise(NoiseType noise, int width, int height) {
			return CreateNoise(noise, width, height, 1f);
		}

		public static Bitmap CreateNoise(NoiseType noise, int width, int height, float frequency) {
			switch (noise) {
				case NoiseType.White:
					return new WhiteNoise(width, height).NoiseMap;
				case NoiseType.Perlin:
					return new PerlinNoise(width, height).NoiseMap;
				case NoiseType.Simple:
					return new SimpleNoise(width, height).NoiseMap;
			}
			return null;
		}
	}
}