using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using PokeSharp;
using PokeSharp.Entity;
using PokeSharp.Entity.Mob;
using PokeSharp.Maps;
using PokeSharp.Maps.Tiles;
using PokeSharp.PokeUtil;

namespace Maps {
	class Map {

		public Tile[] tiles;
		public List<Entity> entities;
		public PokeEngine engine;
		public PlayerEntity player;
		public int w, h;
		public int mapid;

		public MapConnection connectionUp = null;
		public MapConnection connectionDown = null;
		public MapConnection connectionLeft = null;
		public MapConnection connectionRight = null;

		public Map(PokeEngine engine, int id) {
			this.engine = engine;
			this.mapid = id;
			entities = new List<Entity>();
			initialize(id);

			if (!(this is MapConnection)) {
				if (MapProvider.getInstance().getConnections(id) != null) {
					foreach (ConnectionInfo info in MapProvider.getInstance().getConnections(id)) {
						if (info.dir == ConnectionDirection.LEFT) {
							connectionLeft = info.createConnectionFromInfo(this);
						} else if (info.dir == ConnectionDirection.UP) {
							connectionUp = info.createConnectionFromInfo(this);
						} else if (info.dir == ConnectionDirection.RIGHT) {
							connectionRight = info.createConnectionFromInfo(this);
						} else if (info.dir == ConnectionDirection.DOWN) {
							connectionDown = info.createConnectionFromInfo(this);
						}
					}
				}

				/*connectionLeft = new MapConnection(engine, this, ConnectionDirection.LEFT, 2, 0);
				connectionUp = new MapConnection(engine, this, ConnectionDirection.UP, 2, 0);
				connectionRight = new MapConnection(engine, this, ConnectionDirection.RIGHT, 2, 1);
				connectionDown = new MapConnection(engine, this, ConnectionDirection.DOWN, 2, 0);*/
			}
		}

		private void initialize(int id) {
			try {
				Texture2D t2d = Texture2D.FromStream(engine.GraphicsDevice, File.OpenRead("Content/maps/" + id + ".png"));

				this.w = t2d.Width;
				this.h = t2d.Height;

				tiles = new Tile[w * h];

				uint[] colors = new uint[w * h];
				t2d.GetData<uint>(colors);

				for (int y = 0; y < h; y++) {
					for (int x = 0; x < w; x++) {
						uint col = colors[x + y * w] & 0xffffff;
						Tile t = new GrassTile(this, x, y);
						if (col == 0xffffff) t = new GrassTile(this, x, y);
						else if (col == 0x00ffff) {
							t = new ErrorTile(this, x, y);
							this.player = new PlayerEntity(this, x << 4, y << 4);
						} else if (col == 0x000000) t = new RockTile(this, x, y);
						else t = new ErrorTile(this, x, y);
						tiles[x + y * w] = t;
					}
				}

				GrassTile.GrassRandom = new Random(0xffffff);
			} catch (Exception e) {
				Console.WriteLine("OH SHIT: " + e);
			}
		}

		public virtual Tile getTile(int x, int y) {
			if (x < 0) {
				if (connectionLeft != null) return connectionLeft.getTile(connectionLeft.w - Math.Abs(x), y - connectionLeft.offset);
			}

			if (y < 0) {
				if (connectionUp != null) return connectionUp.getTile(x - connectionUp.offset, connectionUp.h - (Math.Abs(y)));
			}

			if (x >= w) {
				if (connectionRight != null) return connectionRight.getTile((w - x), y - connectionRight.offset);
			}

			if (y >= h) {
				if (connectionDown != null) return connectionDown.getTile(x - connectionDown.offset, (h - y));
			}

			if (x < 0 || y < 0 || x >= w || y >= h) return null;
			return tiles[x + y * w];
		}



		public void update() {
			player.update();
			foreach (Entity e in entities) {
				if (e != null) e.update();
			}
		}

		public int tilerendered = 0;

		public virtual void render() {
			SpriteBatch batch = engine.sbatch;

			{ //START OF SCROLL OFFSET VALUES
				int xs = 0, ys = 0;
				if (player != null) {
					int xx = (int)player.x;
					int yy = (int)player.y;

					xs = (int)-(xx - (PokeEngine.WIDTH >> 1));
					ys = (int)-(yy - (PokeEngine.HEIGHT >> 1));

					int xMax = (Tile.WIDTH * w) - PokeEngine.WIDTH;
					int yMax = (Tile.WIDTH * h) - PokeEngine.HEIGHT;

					/*if (xs > 0 && connectionLeft == null) xs = 0;
					if (ys > 0 && connectionUp == null) ys = 0;
					if (-xs > xMax && connectionRight == null) xs = -xMax;
					if (-ys > yMax && connectionDown == null) ys = -yMax;*/
				}
				BatchUtil.setScroll(xs, ys);
			} //END OF SCROLL OFFSET VALUES

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

			//Console.WriteLine("tpx:" + tpx + ", " + (w << 4));

			if (connectionLeft != null && spx < 1) connectionLeft.render();
			if (connectionUp != null && spy < 1) connectionUp.render();
			if (connectionRight != null && tpx <= w << 4) connectionRight.render();
			if (connectionDown != null && tpy <= h << 4) connectionDown.render();



			for (int y = spy; y <= tpy; y++) {
				for (int x = spx; x <= tpx; x++) {
					//Console.WriteLine(x + " + " + y + " * " + w + " = " + index + " (length: " + tiles.Length));

					if (getTile(x, y) != null) { //just in case ...
						tilerendered++;
						getTile(x, y).render(engine, 0, 0);
					}
				}
			}

			//Console.WriteLine("rendered: " + tilerendered);
			tilerendered = 0;

			player.render();
			foreach (Entity e in entities) {
				if (e != null) e.render();
			}
		}

		public bool isMapConnection(int x, int y) {
			if (x < 0 || y < 0 || x >= w || y >= h) return true;
			else return false;
		}

		public MapConnection getConnection(int x, int y) {
			if (x < 0) return connectionLeft;
			if (y < 0) return connectionUp;
			if (x >= w) return connectionRight;
			if (y >= h) return connectionDown;
			return null;
		}
	}
}
