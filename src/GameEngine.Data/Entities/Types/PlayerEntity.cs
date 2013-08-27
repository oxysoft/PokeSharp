using GameEngine.Data.Entities.Living;
using GameEngine.Data.Entities.World;
using GameEngine.Data.Player;
using General.Common;

namespace GameEngine.Data.Entities.Types {
	public class PlayerEntity : LivingEntity {
		public PlayerData Data;

		public override bool CanRun {
			//get { return Datas.Flags[1000]; }
			get { return true; }
		}

		public PlayerEntity(IRegionEntityFactory factory, bool cameraAffected) : base(factory, cameraAffected) {
		}

		public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
			base.Draw(gameTime);
			World.ViewData.SpriteBatch.End();
			//FontRenderer.Instance.Draw(this.World.ViewData.SpriteBatch, "x: " + Position.X / 16 + ", y: " + Position.Y / 16, 2, 4, 12);
			World.ViewData.SpriteBatch.Begin();
		}

		public override void Encode(General.Encoding.BinaryOutput stream) {
			base.Encode(stream);

			Data.Encode(stream);
		}

		public override IEncodable Decode(General.Encoding.BinaryInput stream) {
			base.Decode(stream);

			Data.Decode(stream);

			return this;
		}
	}
}