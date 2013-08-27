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

	class ErrorTile : Tile {

		public int x, y;

		public ErrorTile(Map map, int x, int y)
			: base(map, x, y) {
			this.x = x;
			this.y = y;
		}

		public override void update() {
		}

		public override void render(PokeEngine engine, int xs, int ys) {
			BatchUtil.Draw(engine, Art.tiles[31 - 1, 31 - 1], (x << 4) + xs, (y << 4) + ys);
		}


	}
}
