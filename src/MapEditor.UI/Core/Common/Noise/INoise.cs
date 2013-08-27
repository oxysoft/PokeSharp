using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.UI.Core.Common.Noise {
	public interface INoise {
		Bitmap NoiseMap { get; set; }

		INoise Generate();
	}
}
