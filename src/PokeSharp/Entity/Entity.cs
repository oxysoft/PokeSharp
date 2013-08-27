using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maps;

namespace PokeSharp.Entity {
	class Entity {

		public enum Direction {
			UP, //0
			DOWN, //1
			LEFT, //2
			RIGHT //3
		}

		protected Map map;
		public int x, y;
		public int xa, ya;

		public Entity(Map map, int x, int y) {
			this.map = map;
			this.x = x;
			this.y = y;
		}

		public virtual void update() {
		}

		public virtual void render() {
		}

	}
}
