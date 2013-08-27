using System;
using System.Windows.Forms;
using Editor.Selections;
using GameEngine.Data.Tiles;
using General.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Controls.EditorView {
	public class ControlTilesetSpriteIndexHelper : GameControl {

		public event EventHandler indexChanged;
		private Tileset sheet;
		public Tileset Sheet {
			get {
				return sheet;
			}
			set {
				sheet = value;
				refreshScrollbar();
			}
		}
		public FluentScrolling scrolling;
		public ScrollBar scrollBar;
		public SpriteBatch spriteBatch;
		public bool initialized = false;
		public int setindex, spriteindex;
		public int mx, my;
		public int xt, yt;
		public int TileIndex {
			get {
				if (sheet != null) {
					return sheet.Texture.GetIndex(xt, yt);
				}
				return -1;
			}
		}

		public ControlTilesetSpriteIndexHelper() {
			this.mx = 0;
			this.my = 0;
			this.xt = 0;
			this.yt = 0;
			this.setindex = 0;
			this.spriteindex = 0;
			this.initialized = false;
		}

		public void Initialize(ScrollBar bar) {
			this.scrolling = new FluentScrolling(bar);
			this.scrollBar = bar;
			initialized = true;
			refreshScrollbar();
		}

		public override void LoadContent() {
			this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
		}

		private void refreshScrollbar() {
			if (initialized && sheet != null) {
				scrollBar.Maximum = Math.Max(0, sheet.Texture.Texture.Height - Height);
			}
		}

		protected override void OnMouseWheel(MouseEventArgs args) {
			int delta = scrollBar.Value - args.Delta;

			delta = Math.Min((int) scrollBar.Maximum, delta);
			delta = Math.Max((int) scrollBar.Minimum, delta);

			scrollBar.Value = delta;

			base.OnMouseWheel(args);
		}

		protected override void OnClick(EventArgs e) {
			this.Focus();
		}

		protected override void OnMouseDown(MouseEventArgs e) {
			if (initialized) {
				if (e.Button == MouseButtons.Left) {
					int x = e.X;
					int y = e.Y + scrolling.Value;

					this.mx = x;
					this.my = y;

					this.xt = mx >> 4;
					this.yt = my >> 4;

					indexChanged.SafeInvoke(this, EventArgs.Empty);
				}
			}
			base.OnMouseDown(e);
		}

		public override void Update(Microsoft.Xna.Framework.GameTime gameTime) {
			if (initialized) {
				scrolling.Update(gameTime);
			}
			base.Update(gameTime);
		}

		public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
			if (initialized) {
				this.spriteBatch.Begin();
				if (this.sheet != null) {
					this.spriteBatch.Draw(
						this.sheet.Texture.Texture,
						new Vector2(0, -scrollBar.Value),
						Color.White);
				}
				this.spriteBatch.End();

				Selection selection = new Selection();
				selection.Start(new Vector2(xt << 4, yt << 4));
				selection.End(new Vector2(xt << 4, yt << 4));
				SelectionUtil.DrawRectangle(
				this.spriteBatch,
				Color.Black,
				new Rectangle(
					selection.Region.X * 16 + 1,
					selection.Region.Y * 16 + 1 - this.scrollBar.Value,
					selection.Region.Width * 16,
					selection.Region.Height * 16));

				SelectionUtil.DrawRectangle(
					this.spriteBatch,
					Color.White,
					new Rectangle(
						selection.Region.X * 16,
						selection.Region.Y * 16 - this.scrollBar.Value,
						selection.Region.Width * 16,
						selection.Region.Height * 16));
			}
			base.Draw(gameTime);
		}

	}
}
