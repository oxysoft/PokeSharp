using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Controls.EditorView {
	public class ControlTextureViewer : GameControl {
		public ControlTextureViewer() {
			this.GameLoopEnabled = false;
		}

		private SpriteBatch spriteBatch;
		public Texture2D texture;

		public bool CenteredTexture { get; set; }

		public Texture2D Texture {
			get { return this.texture; }
			set {
				this.texture = value;
				this.Invalidate();
			}
		}

		public override void LoadContent() {
			this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
		}

		public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
			GraphicsDevice.Clear(Color.White);
			if (Texture != null) {
				float scale = 1.0f;

				if (texture.Width > Width) {
					scale = Width / (float) texture.Width;
				}
				if (texture.Height > Height) {
					scale = Height / (float) texture.Height;
				}

				Vector2 pos = Vector2.Zero;
				if (CenteredTexture) pos = new Vector2(Width / 2f, Height / 2f);

				Vector2 orig = Vector2.Zero;
				if (CenteredTexture) orig = new Vector2(texture.Width / 2f, texture.Width / 2f);

				spriteBatch.Begin();
				spriteBatch.Draw(
					texture,
					pos,
					null, Color.White, 0.0f,
					orig,
					scale, SpriteEffects.None, 0f);
				spriteBatch.End();
			}

			base.Draw(gameTime);
		}
	}
}