using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PokeSharp.Entity.Mob;
using PokeSharp.Maps.Tiles;

namespace PokeSharp.PokeUtil {
	class BatchUtil {

		public static void BeginNoAA(SpriteBatch batch, PokeEngine engine) {
			Matrix m = Matrix.CreateScale((int) PokeEngine.SCALE, (int) PokeEngine.SCALE, 0);
			SamplerState sampler = SamplerState.PointClamp;
			batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, sampler, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, m);
		}

		private static int xScroll, yScroll;

		public static void setScroll(int xs, int ys) {
			xScroll = xs;
			yScroll = ys;
		}

		public static int getXScroll() {
			return xScroll;
		}
		
		public static int getYScroll() {
			return yScroll;
		}

		public static void Draw(PokeEngine engine, Texture2D t2d, double x, double y) {
			Vector2 v2 = new Vector2((float)x + xScroll, (float)y + yScroll);
			Rectangle rect = new Rectangle((int)x + xScroll, (int)y + yScroll, t2d.Width, t2d.Height);
			engine.sbatch.Draw(t2d, rect, Color.White);

		}
	}
}
