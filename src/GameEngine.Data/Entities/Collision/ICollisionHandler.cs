using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GameEngine.Data.Entities.Collision {
	public interface ICollisionHandler {
		bool Walkable(int x, int y, Entity requestingEntity);

		IEnumerable<Entity> GetCollidingEntities(int x, int y, Entity requestingEntity);
	}
}
