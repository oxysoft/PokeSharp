using System;
using GameEngine.Data.Common;
using GameEngine.Data.Entities.Core;
using GameEngine.Data.Scenes;
using GameEngine.Data.Scripting.UserInterface;
using GameEngine.Data.Tiles;
using General.Common;
using General.Encoding;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Data.GameLoader {
	public class RegionData : IResourceContainer, IEncodable {
		public string Name, Author;
		public EntityTemplateFactory EntityTemplateFactory { get; private set; }
		public EntityContainer EntityContainer { get; private set; }
		public TilesetContainer TilesetContainer { get; private set; }
		public TilesetFactory TilesetFactory { get; private set; }
		public UIContainer UIContainer { get; private set; }
		public SpriteLibrary.SpriteLibrary SpriteLibrary { get; private set; }

		public World CreateWorld(GraphicsDevice graphicsDevice) {
			return this.CreateWorld(null, graphicsDevice);
		}

		public World CreateWorld(GameScene scene, GraphicsDevice GraphicsDevice) {
			World result = new World(Name, GraphicsDevice, scene);
			result.Author = Author;
			result.TilesetFactory = this.TilesetFactory;
			result.EntityTemplateFactory = this.EntityTemplateFactory;
			result.TilesetContainer = this.TilesetContainer;
			result.EntityContainer = this.EntityContainer;
			result.UIContainer = this.UIContainer;
			result.SpriteLibrary = this.SpriteLibrary;
			return result;
		}

		public void Encode(BinaryOutput stream, World world) {
			stream.Write(world.Name);
			stream.Write(world.Author ?? "");
			
			world.TilesetFactory.Encode(stream);
			world.EntityTemplateFactory.Encode(stream);

			world.TilesetContainer.Encode(stream);
			world.EntityContainer.Encode(stream);
			world.UIContainer.Encode(stream);
			world.SpriteLibrary.Encode(stream);
		}

		public void Encode(BinaryOutput stream) {
			//don't do jackshit, we need a World!
		}

		public IEncodable Decode(BinaryInput stream) {
			this.Name = stream.ReadString();
			this.Author = stream.ReadString();

			this.TilesetFactory = stream.ReadObject<TilesetFactory>();
			this.EntityTemplateFactory = stream.ReadObject<EntityTemplateFactory>();

			this.TilesetContainer = stream.ReadObject<TilesetContainer>();
			this.EntityContainer = stream.ReadObject<EntityContainer>();
			this.UIContainer = stream.ReadObject<UIContainer>();
			this.SpriteLibrary = stream.ReadObject<SpriteLibrary.SpriteLibrary>();
			return this;
		}
	}
}