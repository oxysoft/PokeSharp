using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Data.Scenes {
	public interface IScene {
		SpriteBatch SpriteBatch { get; set; }
		SceneState SceneState { get; set; }
		void Update(GameTime GameTime);
		void Draw(GameTime GameTime);
	}
}