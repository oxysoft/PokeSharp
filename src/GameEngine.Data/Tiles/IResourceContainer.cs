using GameEngine.Data.Entities.Core;
using GameEngine.Data.Scripting.UserInterface;

namespace GameEngine.Data.Tiles {
	public interface IResourceContainer {
		TilesetContainer TilesetContainer { get; }
		EntityContainer EntityContainer { get; }
		UIContainer UIContainer { get; }
		SpriteLibrary.SpriteLibrary SpriteLibrary { get; }
	}
}