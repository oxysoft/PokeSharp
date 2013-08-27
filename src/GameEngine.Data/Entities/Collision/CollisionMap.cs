using System.Collections.Generic;
using System.Linq;
using General.Common;
using Microsoft.Xna.Framework;

namespace GameEngine.Data.Entities.Collision {
	public class CollisionMap : List<Rectangle>, IEncodable {

		public Rectangle Bounds {
			get {
				int x0 = int.MaxValue;
				int y0 = int.MaxValue;
				int x1 = int.MinValue;
				int y1 = int.MinValue;

				foreach (Rectangle rectangle in this) {
					if (rectangle.X < x0) x0 = rectangle.X;
					if (rectangle.Y < y0) y0 = rectangle.Y;

					if (rectangle.X + rectangle.Width > x1) x1 = rectangle.X + rectangle.Width;
					if (rectangle.Y + rectangle.Height > y1) y1 = rectangle.Y + rectangle.Height;
				}

				return new Rectangle(x0, y0, x1 - x0, y1 - y0);
			}
		}

		public Rectangle GetAt(Vector2 p) {
			return GetAt((int) p.X, (int) p.Y);
		}

		public Rectangle GetAt(int x, int y) {
			foreach (Rectangle r in this.Where(r => r.Contains(x, y))) {
				return r;
			}
			return Rectangle.Empty;
		}

		public bool Contains(Vector2 p) {
			return Contains((int)p.X, (int)p.Y);
		}

		public bool Contains(int x, int y) {
			return this.Any(rect => rect.Contains(x, y));
		}

		public bool Intersects(Rectangle rect) {
			return this.Any(r => r.Intersects(rect));
		}

		public void Encode(General.Encoding.BinaryOutput stream) {
			stream.Write(Count);
			ForEach(stream.Write);
		}

		public IEncodable Decode(General.Encoding.BinaryInput stream) {
			int c = stream.ReadInt32();
			for (int i = 0; i < c; i++) Add(stream.ReadRectangle());
			return this;
		}
	}
}
