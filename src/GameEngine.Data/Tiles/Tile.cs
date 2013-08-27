using GameEngine.Data.Tiles.Behaviors;
using General.Common;
using General.Encoding;

namespace GameEngine.Data.Tiles {
	public class Tile : IEncodable {

		public bool collidable, animated, reflecting;
		public int spriteindex, frames;
		public float timeperframe;
		public MockupTileBehavior DefaultBehavior;

		public Tile() {
			collidable = false;
		}

		double elapsed;
		int currentIndex;

		public void Update(Microsoft.Xna.Framework.GameTime time) {
			if (this.animated) {
				elapsed += time.ElapsedGameTime.TotalSeconds;

				while (elapsed >= timeperframe) {
					currentIndex++;
					elapsed -= timeperframe;

					if (currentIndex >= frames) {
						currentIndex = 0;
					}
				}
			}
		}

		public void Encode(BinaryOutput stream) {
			stream.Write(spriteindex);
			stream.Write(collidable);
			stream.Write(reflecting);
			stream.Write(animated);
			stream.Write(frames);
			stream.Write(timeperframe);
			stream.Write(DefaultBehavior);
		}

		public IEncodable Decode(BinaryInput stream) {
			this.spriteindex = stream.ReadInt32();
			this.collidable = stream.ReadBoolean();
			this.reflecting = stream.ReadBoolean();
			this.animated = stream.ReadBoolean();
			this.frames = stream.ReadInt32();
			this.timeperframe = stream.ReadSingle();
			this.DefaultBehavior = stream.ReadObject<MockupTileBehavior>();

			return this;
		}
	}
}
