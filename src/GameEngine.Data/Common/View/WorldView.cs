using System;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Data.Common.View {
	public class WorldView {
		public WorldView(GraphicsDevice graphicsDevice) {
			this.GraphicsDevice = graphicsDevice;
			this.GraphicsDevice.DeviceLost += onLostDevice;

			this.SpriteBatch = new SpriteBatch(graphicsDevice);
		}

		public GraphicsDevice GraphicsDevice {
			get;
			private set;
		}
		public SpriteBatch SpriteBatch {
			get;
			private set;
		}

		private void onLostDevice(object sender, EventArgs e) {
			this.SpriteBatch = new SpriteBatch(this.GraphicsDevice);
		}

	}
}
