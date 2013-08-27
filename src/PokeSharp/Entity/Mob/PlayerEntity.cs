using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets;
using Maps;
using Microsoft.Xna.Framework;
using PokeSharp.Maps;
using PokeSharp.Maps.Tiles;
using PokeSharp.PokeUtil;

namespace PokeSharp.Entity.Mob {
	class PlayerEntity : Mob {

		int moved = 0;
		int speed = 4;
		Direction dir = 0;

		public PlayerEntity(Map map, int x, int y)
			: base(map, x, y) {
		}

		int keyHeldTime = 0;
		int minWalkKeyHeldTime = 0;
		bool aa = false;

		public override void update() {

			if (InputHandler.shift && !aa) {
				aa = true;
				bool b = false;
				if (speed == 1) {
					speed = 4;
					b = true;
				}
				if (speed == 4 && !b) speed = 1;
			} else aa = false;

			if (!isMoving) {
				if (InputHandler.up) {
					if (keyHeldTime < 1) {
						if (dir == Direction.UP) { //already facing up, walk right the fuck now
							keyHeldTime = minWalkKeyHeldTime;
						}
					}
					keyHeldTime++;
					dir = Direction.UP;
				} else if (InputHandler.down) {
					if (keyHeldTime < 1) {
						if (dir == Direction.DOWN) { //already facing up, walk right the fuck now
							keyHeldTime = minWalkKeyHeldTime;
						}
					}
					keyHeldTime++;
					dir = Direction.DOWN;
				} else if (InputHandler.left) {
					if (keyHeldTime < 1) {
						if (dir == Direction.LEFT) { //already facing up, walk right the fuck now
							keyHeldTime = minWalkKeyHeldTime;
						}
					}
					keyHeldTime++;
					dir = Direction.LEFT;
				} else if (InputHandler.right) {
					if (keyHeldTime < 1) {
						if (dir == Direction.RIGHT) { //already facing up, walk right the fuck now
							keyHeldTime = minWalkKeyHeldTime;
						}
					}
					keyHeldTime++;
					dir = Direction.RIGHT;
				} else keyHeldTime = 0;
			}

			if (keyHeldTime > minWalkKeyHeldTime) {
				isMoving = true;
			}

			if (isMoving) {
				if (dir == Direction.UP) {
					ya = -speed;
				} else if (dir == Direction.DOWN) {
					ya = speed;
				} else if (dir == Direction.LEFT) {
					xa = -speed;
				} else if (dir == Direction.RIGHT) {
					xa = speed;
				}
			}

			walkForce(xa, ya);
		}

		public void walkForce(int xa, int ya) {
			if (xa != 0 && ya != 0) {
				return;
			}

			x += xa;
			y += ya;

			if (isMoving) {
				moved += speed;
				if (moved == 16) {
					stepOnTile(map.getTile(x >> 4, y >> 4));
					moved = 0;
				}
			}
		}

		public void stepOnTile(Tile t) {
			isMoving = false;

			/*int xr = xa;
			int yr = ya;
			if (xr < -1) xr = -1;
			if (xr > 1) xr = 1;
			if (yr < -1) yr = -1;
			if (yr > 1) yr = 1;*/

			if (map.isMapConnection((x >> 4), (y >> 4))) {
				MapConnection con = map.getConnection((x >> 4), (y >> 4));
				if (con != null) {
					changeMap(con.mapid);
					if (con.direction == ConnectionDirection.LEFT) {
						x = (map.w - 1) << 4;
						y -= con.offset << 4;
					} else if (con.direction == ConnectionDirection.UP) {
						y = (map.h - 1) << 4;
						x -= con.offset << 4;
					} else if (con.direction == ConnectionDirection.RIGHT) {
						x = 0;
						y -= con.offset << 4;
					} else if (con.direction == ConnectionDirection.DOWN) {
						y = 0;
						x -= con.offset << 4;
					}
				}
			}

			xa = 0;
			ya = 0;
		}

		public void changeMap(int id) {
			map.player = null;
			PokeEngine.instance.changeMap(MapProvider.getInstance().getMap(id));
			map = MapProvider.getInstance().getMap(id);
			map.player = this;
		}

		public override void render() {
			BatchUtil.Draw(map.engine, Art.tiles[0, 1], x, y);
		}

	}
}
