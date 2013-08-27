using GameEngine.Data.Entities.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Data.Entities.Types {
	public class BuildingEntity : MapEntity {
		public BuildingEntity(IRegionEntityFactory factory, bool cameraAffected)
			: base(factory, cameraAffected) {
			Initialize();
		}

		public override void Draw(GameTime gameTime) {
			SpriteBatch batch = World.ViewData.SpriteBatch;
			Vector3 c = Color.ToVector3();

			base.DrawShadow(gameTime);
			base.Draw(gameTime);

			float camScale = 1f;
			Vector2 scroll = Vector2.Zero;

			if (CameraAffected) {
				camScale = this.World.Camera.Scale;
				scroll = this.World.Camera.Location;
			}

			Rectangle source = Template.Texture.GetSource(0);
			Rectangle destination = new Rectangle(
				(int) (((Position.X + Origin.X) * camScale) + scroll.X),
				(int) (((Position.Y + Origin.Y) * camScale) + scroll.Y),
				(int) (Template.Texture.FrameWidth * Scale * camScale),
				(int) (Template.Texture.FrameHeight * Scale * camScale));

			batch.Draw(
				Template.Texture.Texture,
				destination, source, new Color(c.X, c.Y, c.Z, Opacity),
				Rotation, Origin, SpriteEffects.None, 0f);
		}
	}
}