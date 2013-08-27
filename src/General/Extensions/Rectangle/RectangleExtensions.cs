using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace General.Extensions {
	public static class RectangleExtensions {
		public static void AddTo(this Rectangle r1, Vector2 v) {
			r1.X += (int) v.X;
			r1.Y += (int) v.Y;
		}

		public static Rectangle Add(this Rectangle r1, Vector2 v) {
			return new Rectangle(r1.X + (int) v.X, r1.Y + (int) v.Y, r1.Width, r1.Height);
		}

		public static void AddTo(this Rectangle r1, Rectangle r2) {
			r1.X += (int) r2.X;
			r1.Y += (int) r2.Y;
		}

		public static Rectangle Add(this Rectangle r1, Rectangle r2) {
			return new Rectangle(r1.X + (int) r2.X, r1.Y + (int) r2.Y, r1.Width + r2.Width, r1.Height + r2.Height);
		}
	}
}