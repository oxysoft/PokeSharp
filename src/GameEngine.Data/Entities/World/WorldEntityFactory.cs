using GameEngine.Data.Common;

namespace GameEngine.Data.Entities.World {
	public class WorldEntityFactory : IRegionEntityFactory {

		Common.World world;
		int oid;

		public WorldEntityFactory(Common.World world) {
			this.oid = 0;
			this.world = world;
		}

		public int AllocateOID() {
			return oid++;
		}


		Common.World IRegionEntityFactory.World {
			get {
				return world;
			}
		}
	}
}
