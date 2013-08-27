using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapEditor.UI.Core.Common.Noise;
using MapEditor.UI.Core.Extensions;

namespace MapEditor.UI.Core.Common.Brushes {
	public class NoiseBrush : IBrush {
		private NoiseType noiseType;
		private Image image;
		public INoise Noise;
		public float Opacity;

		public NoiseBrush(INoise noise) {
			this.Noise = noise;
			this.image = Noise.NoiseMap;
		}

		public NoiseBrush(INoise noise, float opacity) : this(noise) {
			this.Opacity = opacity;
		}

		public void Fill(Graphics g, GraphicsPath path) {
			g.FillPath(image, Opacity, path);
		}
	}
}