using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets;
using Maps;
using Microsoft.Xna.Framework.Graphics;
using PokeSharp.PokeUtil;

namespace PokeSharp.Maps.Tiles {

	class GrassTile : Tile {

		public static Random GrassRandom = new Random(0xffffff);

		public int tex = 0;
		public int x, y;

		public GrassTile(Map map, int x, int y)
			: base(map, x, y) {
			this.x = x;
			this.y = y;
			tex = GrassRandom.Next(0, 2);
		}

		public override void update() {
		}

		public override void render(PokeEngine engine, int xs, int ys) {
			BatchUtil.Draw(engine, Art.tiles[tex, 0], (x << 4) + xs, (y << 4) + ys);
		}


	}
}
