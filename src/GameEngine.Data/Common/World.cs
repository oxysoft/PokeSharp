using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GameEngine.Data.Common.View;
using GameEngine.Data.Debugging;
using GameEngine.Data.Entities;
using GameEngine.Data.Entities.Core;
using GameEngine.Data.Entities.Types;
using GameEngine.Data.Entities.World;
using GameEngine.Data.Scenes;
using GameEngine.Data.Scripting.UserInterface;
using GameEngine.Data.Tiles;
using General.Common;
using General.Encoding;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Data.Common {
	public class World : IResourceContainer, IEncodable {
		public string Name, Author;
		public GameConsole GameConsole;
		public GameScene GameScene;
		public WorldView ViewData;
		public List<Map> Maps;
		public Map CurrentMap;
		public PlayerEntity Player;

		/*DEBUG*/
		public int updatedMaps, renderedMaps;
		public int renderedEntities;
		public float updateTime;

		public Camera Camera;

		public WorldEntityFactory EntityFactory { get; set; }
		public TilesetFactory TilesetFactory { get; set; }
		public EntityTemplateFactory EntityTemplateFactory { get; set; }

		public TilesetContainer TilesetContainer { get; set; }
		public EntityContainer EntityContainer { get; set; }
		public UIContainer UIContainer { get; set; }
		public SpriteLibrary.SpriteLibrary SpriteLibrary { get; set; }

		private World(string name) {
			this.Name = name;
			this.TilesetContainer = new TilesetContainer();
			this.EntityContainer = new EntityContainer();
			this.UIContainer = new UIContainer();
			this.SpriteLibrary = new SpriteLibrary.SpriteLibrary();
			this.TilesetFactory = new TilesetFactory();
			this.EntityTemplateFactory = new EntityTemplateFactory();
			this.EntityFactory = new WorldEntityFactory(this);
			this.Maps = new List<Map>();
			this.Camera = new Camera();
			this.GameConsole = new GameConsole();
		}

		public World(string name, GraphicsDevice graphicsDevice)
			: this(name) {
			this.ViewData = new WorldView(graphicsDevice);
		}

		public World(string name, GraphicsDevice graphicsDevice, GameScene gameScene) : this(name, graphicsDevice) {
			this.GameScene = gameScene;
		}

		public void LoadTilesheetContainer(string filename) {
			if (ViewData != null) TilesetContainer = EncoderUtil.Decode<TilesetContainer>(filename, ViewData.GraphicsDevice);
			else TilesetContainer = EncoderUtil.Decode<TilesetContainer>(filename);
		}

		public void LoadObjectContainer(string filename) {
			if (ViewData != null) EntityContainer = EncoderUtil.Decode<EntityContainer>(filename, ViewData.GraphicsDevice);
			else EntityContainer = EncoderUtil.Decode<EntityContainer>(filename);
		}

		public void Update(GameTime gameTime) {
			Stopwatch watch = Stopwatch.StartNew();

			TilesetContainer.Update(gameTime);
			GameConsole.Update(gameTime);

			foreach (Map m in Maps) {
				m.Update(gameTime);
			}

			watch.Stop();

			updateTime = (float) watch.Elapsed.TotalSeconds;
		}

		public void Draw(GameTime gameTime) {
			Stopwatch watch = Stopwatch.StartNew();

			GameConsole.Draw(gameTime);
			if (CurrentMap != null) CurrentMap.Draw(gameTime);
			else {
				if (Player.Map != null) Player.Map.Draw(gameTime);
				else {
					GameConsole.WriteLine("Could not render map[World.Draw]");
				}
			}

			watch.Stop();
		}

		public void Encode(General.Encoding.BinaryOutput stream) {
		}

		public IEncodable Decode(General.Encoding.BinaryInput stream) {
			return this;
		}
	}
}