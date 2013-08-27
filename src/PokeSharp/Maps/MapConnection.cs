using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maps;
using Microsoft.Xna.Framework.Graphics;
using PokeSharp.Maps.Tiles;
using PokeSharp.PokeUtil;
using PokeSharp.Entity;
using PokeSharp.Entity.Mob;

namespace PokeSharp.Maps {
	class MapConnection : Map {

		public ConnectionDirection direction;
		public Map parent;
		public int offset = 0;

		public MapConnection(PokeEngine engine, Map Parent, ConnectionDirection direction, int id)
			: base(engine, id) {

		}

		public MapConnection(PokeEngine engine, Map parent, ConnectionDirection direction, int id, int offset)
			: base(engine, id) {
			this.direction = direction;
			this.parent = parent;
			this.offset = offset;
		}

		public override void render() {
			SpriteBatch batch = engine.sbatch;

			int spy = Math.Abs(BatchUtil.getYScroll()) >> 4;
			int spx = Math.Abs(BatchUtil.getXScroll()) >> 4;
			int tpy = (Math.Abs(BatchUtil.getYScroll()) >> 4) + (PokeEngine.HEIGHT >> 4) + 1;
			int tpx = (Math.Abs(BatchUtil.getXScroll()) >> 4) + (PokeEngine.WIDTH >> 4) + 1;

			if (spy < 0) spy = 0;
			if (spx < 0) spx = 0;
			if (tpy >= w) tpy = h - 1;
			if (tpx >= h) tpx = w - 1;
			if (BatchUtil.getYScroll() >> 4 > 0) spy = 0;
			if (BatchUtil.getXScroll() >> 4 > 0) spx = 0;

			int vx, vy, sx, sy, tx, ty;
			vx = vy = sx = sy = tx = ty = 0;

			//not the best idea i had here, but it'll do!

			if (direction == ConnectionDirection.LEFT) {
				vx -= w << 4;
				vy += offset << 4;

				ty = h;
				sx = w - 16;
				tx = w;
			} else if (direction == ConnectionDirection.UP) {
				vx += offset << 4;
				vy -= h << 4;

				sy = h - 16;
				ty = h;
				tx = w;
			} else if (direction == ConnectionDirection.RIGHT) {
				vx += parent.w << 4;
				vy += offset << 4;

				ty = h;
				tx = 16;
			} else if (direction == ConnectionDirection.DOWN) {
				vx += offset << 4;
				vy += parent.h << 4;

				ty = 16;
				tx = w;
			}

			for (int y = sy; y <= ty; y++) {
				for (int x = sx; x <= tx; x++) {
					if (getTile(x, y) != null) { //just in case ...
						tilerendered++;
						getTile(x, y).render(engine, vx, vy);
					}
				}
			}
		}

		public override Tile getTile(int x, int y) {
			if (x >= w) if (direction == ConnectionDirection.LEFT) return parent.getTile((w - x) - 1, y + offset);
			if (y >= h) if (direction == ConnectionDirection.UP) return parent.getTile(x + offset, (h - y) - 1);
			if (x < 0) if (direction == ConnectionDirection.RIGHT) return parent.getTile(parent.w - Math.Abs(x), y + offset);
			if (y < 0) if (direction == ConnectionDirection.DOWN) return parent.getTile(x + offset, parent.h - Math.Abs(y));

			if (x < 0 || y < 0 || x >= w || y >= h) return null;
			return tiles[x + y * w];
		}
	
	}
}
