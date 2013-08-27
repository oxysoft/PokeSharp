using GameEngine.Data.Common;
using GameEngine.Data.Entities.Core;
using GameEngine.Data.Entities.Living;
using GameEngine.Data.Entities.Types;
using GameEngine.Data.GameLoader;
using GameEngine.Data.Scripting.UserInterface;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Data.Scenes {
	public class GameScene : IScene {
		public SpriteBatch SpriteBatch { get; set; }
		public SceneState SceneState { get; set; }
		public GameData Data;
		public World World;
		public PlayerEntity Player;
		public UIManager UIManager;

		public GameScene(GameData data, SpriteBatch SpriteBatch) {
			this.SpriteBatch = SpriteBatch;
			this.UIManager = new UIManager();
			this.Data = data;
			World = Data.RegionData.CreateWorld(this, SpriteBatch.GraphicsDevice);
			World.Maps.Add(Data.MapDatas[0].CreateMap(World));

			EntityTemplate templatePlayer = World.EntityContainer.GetPlayers()[0];

			Player = templatePlayer.CreateEntity(World.EntityFactory, true) as PlayerEntity;
			World.Player = Player;
			World.Maps[0].AddEntity(Player);
			new LivingController(Player);
			World.CurrentMap = Player.Map;
			this.SceneState = SceneState.Alive;
		}

		public void Update(Microsoft.Xna.Framework.GameTime gameTime) {
			World.Update(gameTime);
			UIManager.Update(gameTime);
		}

		public void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
			World.Draw(gameTime);
			UIManager.Draw(gameTime);
		}
	}
}