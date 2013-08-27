using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Data.Entities;
using Microsoft.Xna.Framework;

namespace GameEngine.Data.Common.View {
	public class Camera {
		private MapEntity focusEntity;

		public Camera() {
		}

		//public Matrix Matrix {
		//	get {
		//		return Matrix.CreateTranslation(Location.X, Location.Y, 0) *
		//			   Matrix.CreateScale(Scale.X, Scale.Y, 0) *
		//			   Matrix.CreateRotationX(Rotation);
		//	}
		//}

		public Vector2 Location { get; set; }
		public float Scale { get; set; }
		public float Rotation { get; set; }
		public MapEntity FocusEntity { get; set; }

		public void Reset() {
			this.Location = Vector2.Zero;
			this.Scale = 1f;
			this.Rotation = 0f;
			FocusEntity = null;
		}
	}
}