using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Editor.Selections;
using GameEngine.Data.Entities.Collision;
using GameEngine.Data.Text.Fonts;
using GameEngine.Data.Tiles.Behaviors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Controls.EditorView {
	public class ControlTileBehaviorSelector : GameControl {
		private bool initialized = false;
		private SpriteBatch spriteBatch;
		private Texture2D pixel;
		private CollisionMap collisions;
		public byte SelectedId;

		public TileBehavior Selected {
			get { return TileBehavior.GetBehavior(SelectedId); }
		}

		public ControlTileBehaviorSelector() {
		}

		public override void Initialize() {
			base.Initialize();
			this.spriteBatch = new SpriteBatch(GraphicsDevice);

			this.pixel = new Texture2D(this.GraphicsDevice, 1, 1);
			pixel.SetData<Color>(new Color[] {Color.White});

			initialized = true;

			this.collisions = new CollisionMap();
			int x = 0;
			int y = 0;
			foreach (TileBehavior b in TileBehavior.Values) {
				collisions.Add(new Rectangle(x, y, 16, 16));

				if (x + 32 >= this.Width) {
					y += 16;
					x = 0;
				} else {
					x += 16;
				}
			}
		}

		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e) {
			Rectangle r = collisions.GetAt(e.X, e.Y);

			if (r != Rectangle.Empty) {
				this.SelectedId = (byte) collisions.IndexOf(r);
			}

			base.OnMouseDown(e);
		}

		protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e) {
			base.OnMouseMove(e);
		}

		public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
			base.Draw(gameTime);
			if (this.initialized) {
				spriteBatch.Begin();

				for (byte i = 0; i < collisions.Count; i++) {
					Rectangle rect = collisions[i];
					TileBehavior b = TileBehavior.GetBehavior(i);

					spriteBatch.Draw(pixel, rect, b.Color);
					const int font = 2;
					FontRenderer.Instance.Draw(spriteBatch, b.Identifier, font, (int) (rect.X + 16 / 2 - Math.Floor(FontRenderer.Instance.Width(b.Identifier, font) / 2f)), rect.Y + 14);
					if (i == this.SelectedId) SelectionUtil.DrawRectangle(spriteBatch, Color.Red, new Rectangle(rect.X, rect.Y, rect.Width - 1, rect.Height - 1));
				}

				spriteBatch.End();
			}
		}
	}
}