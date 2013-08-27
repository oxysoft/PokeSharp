using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace General.Extensions {
	public static class EffectExtensions {
		#region Methods
		public static void Apply(this Effect effect) {
			effect.CurrentTechnique.Passes[0].Apply();
		}
		#endregion
	}
}
