using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maps;

namespace PokeSharp.Entity.Mob {
	class Mob : Entity {

		public bool isMoving;

		public Mob(Map map, int x, int y)
			: base(map, x, y) {
				isMoving = false;
		}

	}
}
