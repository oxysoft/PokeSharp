using GameEngine.Data.Common;

namespace GameEngine.Data.Entities.World {
	public interface IRegionEntityFactory : IEntityFactory {
		Common.World World {
			get;
		}
	}
}
