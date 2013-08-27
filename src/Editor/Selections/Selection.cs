using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Editor.Selections {
	public class Selection {
		public Selection() {
			this.GridWidth = 16;
			this.GridHeight = 16;

			this.anti_negative = true;

			this.MaxPosition = new Vector2(-1, -1);
		}

		public int GridWidth;
		public int GridHeight;
		public bool anti_negative;
		private Vector2 startPosition;
		private Vector2 endPosition;
		private Rectangle region;

		public Vector2 MaxPosition {
			get;
			set;
		}

		public Vector2 Position {
			get {
				return new Vector2(this.region.X, this.region.Y);
			}
		}


		public Rectangle Region {
			get {
				return this.region;
			}
			set {
				this.region = value;
			}
		}

		public Rectangle CreateRectangle(Vector2 a, Vector2 b) {
			float startX = Math.Min(a.X, b.X);
			float startY = Math.Min(a.Y, b.Y);

			float endX = Math.Max(a.X, b.X);
			float endY = Math.Max(a.Y, b.Y);

			return new Rectangle((int)startX, (int)startY, (int)(endX - startX) + 1, (int)(endY - startY) + 1);
		}

		/*public BaseShape CreateShape(Graphics2D graphics) {
			if (this.region.Width > 0 && this.region.Height > 0) {
				return graphics.CreateRectangle(
					this.region.Width * this.GridWidth,
					this.region.Height * this.GridHeight);
			}
			return null;
		}*/

		public void Start(Vector2 position) {
			this.startPosition = Vector2.Zero;
			this.endPosition = Vector2.Zero;

			this.region = Rectangle.Empty;

			int x = (int)position.X / (int)this.GridWidth;
			int y = (int)position.Y / (int)this.GridHeight;

			this.startPosition = new Vector2(x, y);

			if (this.MaxPosition.X >= 0 && this.MaxPosition.Y >= 0) {
				this.startPosition = Vector2.Min(this.startPosition, this.MaxPosition - Vector2.One);
			}

			if (anti_negative) this.startPosition = Vector2.Max(this.startPosition, Vector2.Zero);
		}

		public void End(Vector2 position) {
			this.endPosition = new Vector2((int)position.X / (int)this.GridWidth, (int)position.Y / (int)this.GridHeight);

			if (this.MaxPosition.X >= 0 && this.MaxPosition.Y >= 0) {
				this.endPosition = Vector2.Min(this.endPosition, this.MaxPosition - Vector2.One);
			}
			if (anti_negative) this.endPosition = Vector2.Max(this.endPosition, Vector2.Zero);
			this.region = this.CreateRectangle(this.startPosition, this.endPosition);
		}

	}
}
