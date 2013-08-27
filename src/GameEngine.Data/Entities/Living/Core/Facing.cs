using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GameEngine.Data.Entities.Living.Core {
	public enum Facing {
		Left,
		Right,
		Up,
		Down,
		Any
	}

	public static class FacingExtensions {
		private static Random random = new Random();

		public static Vector2 ToVector2(this Facing facing) {
			switch (facing) {
				case Facing.Up:
					return new Vector2(0, -1);
				case Facing.Down:
					return new Vector2(0, 1);
				case Facing.Left:
					return new Vector2(-1, 0);
				case Facing.Right:
					return new Vector2(1, 0);
			}
			return Vector2.Zero;
		}

		public static Facing Opposite(this Facing facing) {
			switch (facing) {
				case Facing.Up:
					return Facing.Down;
				case Facing.Down:
					return Facing.Up;
				case Facing.Left:
					return Facing.Right;
				case Facing.Right:
					return Facing.Left;
			}
			return Facing.Down;
		}

		public static Facing RotateRight(this Facing facing) {
			switch (facing) {
				case Facing.Up:
					return Facing.Right;
				case Facing.Down:
					return Facing.Left;
				case Facing.Left:
					return Facing.Up;
				case Facing.Right:
					return Facing.Down;
			}
			return Facing.Down;
		}

		public static Facing Randomize(this Facing facing) {
			return facing.Randomize(random);
		}

		public static Facing Randomize(this Facing facing, Random random) {
			return (Facing) random.Next(0, 4);
		}
	}
}