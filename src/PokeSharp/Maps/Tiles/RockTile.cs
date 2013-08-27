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

	class RockTile : Tile {

		public int x, y;
		public int[] texArr = new int[2];
		public int tex = 0;

		public RockTile(Map map, int x, int y)
			: base(map, x, y) {
			this.x = x;
			this.y = y;
			texArr[0] = -1;
			texArr[1] = -1;
			//refreshTexture();
		}

		public override void update() {
		}

		public void refreshTexture() {
			bool u = false, d = false, l = false, r = false;
			bool ul = false, dl = false, ur = false, dr = false;
			int layerU = 0, layerD = 0, layerL = 0, layerR = 0;
			int layerUL = 0, layerUR = 0, layerDL = 0, layerDR = 0;

			if (map.getTile(x, y - 1) is RockTile) {
				RockTile rock = (RockTile)map.getTile(x, y - 1);
				if (rock.layer == layer) u = true;
				else layerU = rock.layer;
			}
			if (map.getTile(x, y + 1) is RockTile) {
				RockTile rock = (RockTile)map.getTile(x, y + 1);
				if (rock.layer == layer) d = true;
				else layerD = rock.layer;
			}
			if (map.getTile(x - 1, y) is RockTile) {
				RockTile rock = (RockTile)map.getTile(x - 1, y);
				if (rock.layer == layer) l = true;
				else layerL = rock.layer;
			}
			if (map.getTile(x + 1, y) is RockTile) {
				RockTile rock = (RockTile)map.getTile(x + 1, y);
				if (rock.layer == layer) r = true;
				else layerR = rock.layer;
			}

			ul = map.getTile(x - 1, y - 1) is RockTile; //|| map.getTile(x, y - 1) is StairTile;
			dl = map.getTile(x - 1, y + 1) is RockTile; //|| map.getTile(x, y - 1) is StairTile;
			ur = map.getTile(x + 1, y - 1) is RockTile; //|| map.getTile(x, y - 1) is StairTile;
			dr = map.getTile(x + 1, y + 1) is RockTile; //|| map.getTile(x, y - 1) is StairTile;

			if (x == 7 && y == 5 && !(map is MapConnection)) {
				//Tile t = map.getTile(x + 1, y);
				//Console.WriteLine(map.getTile(x + 1, y));
			}

			if (ul) {
				RockTile rock = (RockTile)map.getTile(x - 1, y - 1);
				if (rock.layer != layer) {
					ul = false;
					layerUL = rock.layer;
				}
			}
			if (ur) {
				RockTile rock = (RockTile)map.getTile(x + 1, y - 1);
				if (rock.layer != layer) {
					ur = false;
					layerUR = rock.layer;
				}
			}
			if (dl) {
				RockTile rock = (RockTile)map.getTile(x - 1, y + 1);
				if (rock.layer != layer) {
					dl = false;
					layerDL = rock.layer;
				}
			}
			if (dr) {
				RockTile rock = (RockTile)map.getTile(x + 1, y + 1);
				if (rock.layer != layer) {
					dr = false;
					layerDR = rock.layer;
				}
			}

			/*byte stair = 0;

			if (map.getTile(x - 1, y) is StairTile) {
				stair = 1;
			}
			if (map.getTile(x + 1, y) is StairTile) {
				stair = 1;
			}
			if (map.getTile(x, y + 1) is StairTile || map.getTile(x - 1, y + 1) is StairTile || map.getTile(x + 1, y + 1) is StairTile) {
				stair = 2;
			}

			if (stair > 0) {
				if (stair == 1) {
				if (map.getTile(x + 1, y + 1) is GrassTile && map.getTile(x + 1, y) is StairTile && map.getTile(x, y + 1) is RockTile) BatchUtil.Draw(map.engine,Art.blocks[9, tex], rx, ry);
				else BatchUtil.Draw(map.engine,Art.blocks[7, tex], rx, ry);
				}
				if (stair == 2) BatchUtil.Draw(map.engine,Art.blocks[7, tex], rx, ry);
				return;
			}*/

			if (layer < 1) setTex(0,0);
			else setTex(0, 0);
			if (!u && !d && !l && !r) {
				setTex(31, 31);
			} else if (u && !d && !l && !r) {
				setTex(31, 31);
			} else if (!u && d && !l && !r) {
				setTex(9, 0);
			} else if (u && d && !l && !r) {
				if (layerR > layer) setTex(5, tex);
				else if (layerL > layer) setTex(6, tex);
				else {
					if (map.getTile(x + 1, y) is GrassTile) setTex(5, tex);
					else if (map.getTile(x - 1, y) is GrassTile || map.getTile(x - 1, y) is GrassTile) setTex(6, tex);
				}
			} else if (u && !d && l && !r) {
				if (layerR > layer) setTex(0, tex);
				else setTex(4, tex);
			} else if (u && !d && !l && r) {
				if (layerDL > layer) setTex(0, tex);
				else setTex(3, tex);
			} else if (!u && d && l && !r) {
				if (layerR > layer) setTex(0, tex);
				else setTex(2, tex);
			} else if (!u && d && !l && r) {
				if (layerL > layer) setTex(0, tex);
				else setTex(1, tex);
			} else if (!u && !d && l && r) {
				if (layerL > 0) setTex(7, tex);
				else if (layerD > 0) setTex(8, tex);
				else {
					if (map.getTile(x, y + 1) is GrassTile && layer != 0) setTex(8, 1);
					else if (map.getTile(x, y - 1) is GrassTile) setTex(7, 0);
					else setTex(7, 0);
				}
			} else if (u && d && l && !r) {
				if (layerR > layer) setTex(0, 0);
				else setTex(6, tex);
			} else if (u && d && !l && r) {
				if (layerL > layer) setTex(dr ? 0 : 9, tex);
				else setTex(5, tex);
			} else if (!u && d && l && r) {
				if (layerU > layer) setTex(dr ? 0 : 9, tex);
				else {
					if (!dr) setTex(10, tex);
					else setTex(8, 0);
				}
			} else if (u && !d && l && r) {
				if (layerD > layer) setTex(0, tex);
				else setTex(7, 0);
			} else if (u && d && l && r) {
				if (layerDL > layer) setTex(0, tex);
				else if (layerDR > layer) setTex(0, tex);
				else if (!dl) setTex(10, tex);
				else if (!dr) setTex(9, tex);
				else setTex(0, tex);
			} else if (!u && !d && !l && r) {
				setTex(7, tex);
			} else if (!u && !d && l && !r) {
				setTex(7, tex);
			}
		}

		public void setTex(int xtex, int ytex) {
			texArr[0] = xtex;
			texArr[1] = ytex;
		}

		public override void render(PokeEngine engine, int xs, int ys) {
			if (texArr[0] == -1 && texArr[1] == -1) refreshTexture();

			int rx = x * WIDTH + xs;
			int ry = y * WIDTH + ys;

			BatchUtil.Draw(engine, Art.tiles[0, 0], rx, ry);
			BatchUtil.Draw(engine, Art.blocks[texArr[0], texArr[1]], rx, ry);
		}


	}
}
