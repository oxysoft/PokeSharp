using System;
using System.Windows.Forms;
using Editor.Selections;
using GameEngine.Data.Tiles;
using General.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Controls.EditorView {
	public class ControlTilesetSelector : GameControl {
		public ControlTilesetSelector() {
			this.scrollBar = new VScrollBar {Dock = DockStyle.Right, Maximum = 0};
			this.selection = new Selection();
		}

		private Selection selection;
		private ScrollBar scrollBar;
		private FluentScrolling scrolling;
		private SpriteBatch spriteBatch;
		private Tileset tileset;

		public Tileset Tileset {
			get { return this.tileset; }
			set {
				this.tileset = value;
				refreshScrollbar();
			}
		}

		public int SelectedIndex { get; set; }

		public Rectangle SelectedRegion {
			get { return this.selection.Region; }
			set { this.selection.Region = value; }
		}

		public event EventHandler SelectedRegionChanged;

		public void initialize(ScrollBar bar) {
			this.scrolling = new FluentScrolling(bar);
			this.scrollBar = bar;
			refreshScrollbar();
		}

		private void refreshScrollbar() {
			if (tileset != null) {
				scrollBar.Maximum = Math.Max(0, tileset.Texture.Texture.Height - Height);
			}
		}

		protected override void OnMouseWheel(MouseEventArgs args) {
			int delta = scrollBar.Value - args.Delta;

			delta = Math.Min((int) scrollBar.Maximum, delta);
			delta = Math.Max((int) scrollBar.Minimum, delta);

			scrollBar.Value = delta;

			base.OnMouseWheel(args);
		}

		protected override void OnCreateControl() {
			this.GameLoopEnabled = true;
			base.OnCreateControl();
		}

		protected override void OnClick(EventArgs e) {
			this.Focus();
		}

		protected override void OnMouseDown(MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				if (this.Tileset != null && this.Tileset.Texture != null) {
					this.selection.MaxPosition = new Vector2(
						this.Tileset.Texture.Texture.Width / 16,
						this.Tileset.Texture.Texture.Height / 16);
				}

				this.selection.Start(new Vector2(e.X, e.Y + this.scrollBar.Value));
				this.selection.End(new Vector2(e.X, e.Y + this.scrollBar.Value));

				this.OnMouseMove(e);
			}
		}

		protected override void OnMouseMove(MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				this.selection.End(new Vector2(e.X, e.Y + this.scrollBar.Value));
			}
		}

		protected override void OnMouseUp(MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				this.SelectedRegionChanged.SafeInvoke(this, EventArgs.Empty);
			}
		}

		public override void LoadContent() {
			this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
		}

		public override void Update(GameTime time) {
			scrolling.Update(time);
			base.Update(time);
		}

		public override void Draw(GameTime gameTime) {
			//this.GraphicsDevice.Clear(Color.CornflowerBlue);

			this.spriteBatch.Begin();
			if (this.Tileset != null) {
				this.spriteBatch.Draw(
					this.Tileset.Texture.Texture,
					new Vector2(0, -this.scrollBar.Value),
					Color.White);
			}
			Vector2 position = new Vector2(this.selection.Region.X, this.selection.Region.Y) * new Vector2(16, 16);
			position -= new Vector2(0, scrolling.Value);

			SelectionUtil.DrawRectangle(
				this.spriteBatch,
				Color.Black,
				new Rectangle(
					this.selection.Region.X * 16 + 1,
					this.selection.Region.Y * 16 + 1 - this.scrollBar.Value,
					this.selection.Region.Width * 16,
					this.selection.Region.Height * 16));

			SelectionUtil.DrawRectangle(
				this.spriteBatch,
				Color.White,
				new Rectangle(
					this.selection.Region.X * 16,
					this.selection.Region.Y * 16 - this.scrollBar.Value,
					this.selection.Region.Width * 16,
					this.selection.Region.Height * 16));
			this.spriteBatch.End();
		}
	}
}