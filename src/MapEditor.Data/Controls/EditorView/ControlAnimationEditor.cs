using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using General.Graphics;
using General.Graphics.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Controls.EditorView {
	public class ControlAnimationEditor : GameControl {
		public ControlAnimationEditor() {
			this.Animation = new Animation();
		}

		private SpriteBatch spriteBatch;

		private Animation animation;
		private AnimationController controller;

		public int SelectedFrame { get; set; }
		public bool PlayAnimation { get; set; }

		public TileableTexture TileableTexture { get; set; }

		public Animation Animation {
			get { return this.animation; }
			set {
				this.animation = value;
				this.controller = new AnimationController(value);
			}
		}

		public void Play() {
			this.PlayAnimation = true;
		}

		public void Stop() {
			this.PlayAnimation = false;
		}

		public override void LoadContent() {
			this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
			base.LoadContent();
		}

		public override void Update(GameTime gameTime) {
			if (this.Animation != null && this.Animation.Indices.Count > 0 && this.PlayAnimation) {
				this.controller.Update(gameTime);
			}
		}

		public override void Draw(GameTime gameTime) {
			if (this.Animation != null && this.Animation.Indices.Count > 0 && this.TileableTexture != null) {
				if (this.PlayAnimation) {
					Rectangle source = this.TileableTexture.GetSource(this.controller.AnimationIndex);
					Rectangle destination = new Rectangle(0, 0, this.TileableTexture.FrameWidth, this.TileableTexture.FrameHeight);

					spriteBatch.Begin();
					spriteBatch.Draw(this.TileableTexture.Texture, destination, source, Color.White);
					spriteBatch.End();
				} else {
					spriteBatch.Begin();
					spriteBatch.Draw(this.TileableTexture.Texture, Vector2.Zero, Color.White);

					Rectangle source = this.TileableTexture.GetSource(this.Animation.Indices[this.SelectedFrame]);
					spriteBatch.Draw(this.TileableTexture.Texture, source, source, new Color(1f, 1f, 1f, 0.3f));

					spriteBatch.End();
				}
			}
		}

		protected override void OnMouseDown(MouseEventArgs e) {
			if (e.Button == MouseButtons.Left && !this.PlayAnimation) {
				int tileX = e.X / this.TileableTexture.FrameWidth;
				int tileY = e.Y / this.TileableTexture.FrameHeight;

				this.Animation.Indices[this.SelectedFrame] = this.TileableTexture.GetIndex(tileX, tileY);
			}

			base.OnMouseDown(e);
		}

	}
}