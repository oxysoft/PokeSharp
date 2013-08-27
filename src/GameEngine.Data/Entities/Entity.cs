using System;
using GameEngine.Data.Entities.World;
using General.Common;
using Microsoft.Xna.Framework;

namespace GameEngine.Data.Entities {
	[Serializable]
	public class Entity : IEncodable {
		public int id;

		public Entity(IEntityFactory efactory) {
			id = efactory.AllocateOID();
		}

		public Vector2 Position { get; set; }

		public Vector2 TilePosition {
			get { return Position / new Vector2(16, 16); }
		}

		public virtual int Width { get; set; }
		public virtual int Height { get; set; }

		public Rectangle Bounds {
			get {
				return new Rectangle(
					(int) Position.X,
					(int) Position.Y,
					this.Width,
					this.Height);
			}
		}

		public virtual void Update(GameTime gameTime) {
		}

		public virtual void Draw(GameTime gameTime) {
		}

		public virtual void Encode(General.Encoding.BinaryOutput stream) {
			stream.Write(id);
			stream.Write(Position);
			stream.Write(Width);
			stream.Write(Height);
		}

		public virtual IEncodable Decode(General.Encoding.BinaryInput stream) {
			this.id = stream.ReadInt32();
			this.Position = stream.ReadVector2();
			this.Width = stream.ReadInt32();
			this.Height = stream.ReadInt32();

			return this;
		}
	}
}