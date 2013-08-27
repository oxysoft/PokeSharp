using System;
using System.Windows.Forms;
using Editor.Selections;
using GameEngine.Data.Tiles;
using General.Extensions;
using MapEditor.Data.TileLogicNew;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Controls.EditorView {
	public class ControlLogicSelector : GameControl {
		public int xt, yt;
		public int mx, my;
		public int s_0, s_1; //tilesheet, tileIndex
		public int yMax;
		public FluentScrolling scrolling;
		public ScrollBar scrollbar;
		public event EventHandler SelectedLogic;
		private SpriteBatch spriteBatch;

		public ControlLogicSelector() {
			this.Dock = System.Windows.Forms.DockStyle.Fill;
		}

		public int SelectedLogicIndex {
			get { return yt * (this.Width >> 4) + xt; }
		}

		public void Initialize(ScrollBar scrollbar) {
			this.scrollbar = scrollbar;
			this.scrolling = new FluentScrolling(scrollbar);
		}

		public override void LoadContent() {
			this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
			base.LoadContent();
		}

		protected override void OnClick(System.EventArgs e) {
			this.Focus();
			base.OnClick(e);
		}

		private void refreshScrollbar() {
			scrollbar.Maximum = Math.Max(0, yMax - Height);
		}

		protected override void OnMouseWheel(MouseEventArgs args) {
			int delta = scrollbar.Value - args.Delta;

			delta = Math.Min((int) scrollbar.Maximum, delta);
			delta = Math.Max((int) scrollbar.Minimum, delta);

			scrollbar.Value = delta;

			base.OnMouseWheel(args);
		}

		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e) {
			mx = e.X;
			my = e.Y + scrolling.Value;

			xt = mx >> 4;
			yt = my >> 4;

			s_1 = EditorEngine.Instance.World.TilesetContainer[s_0].Texture.GetIndex(xt, yt);
			SelectedLogic.SafeInvoke(this, EventArgs.Empty);

			base.OnMouseDown(e);
		}

		protected override void OnMouseMove(MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				mx = e.X;
				my = e.Y + scrolling.Value;

				xt = mx >> 4;
				yt = my >> 4;
			}
			base.OnMouseMove(e);
		}

		private bool initializedYMax = false;

		public override void Draw(Microsoft.Xna.Framework.GameTime time) {
			spriteBatch.Begin();

			int x = 0;
			int y = 0;
			try {
				foreach (TileLogicScript logic in TileLogicManager.Instance.logics) {
					Tileset _s_0 = EditorEngine.Instance.GetTilesetByName(logic.s_0);
					int _s_1 = logic.s_1;

					if ((x << 4) + 16 > this.Width) {
						y++;
						x = 0;
					}

					Rectangle srcRect = _s_0.Texture.GetSource(_s_1);
					Rectangle targetRect = new Rectangle(x << 4, (y << 4) - scrollbar.Value, 16, 16);

					spriteBatch.Draw(_s_0.Texture.Texture, targetRect, srcRect, Color.White);
					x += 1;
				}

				this.yMax = y << 4;

				if (!initializedYMax) {
					initializedYMax = true;
					refreshScrollbar();
				}
			} catch (Exception e) {
				Console.WriteLine("Bullshit occured: " + e);
			}

			Selection selection = new Selection();
			selection.Start(new Vector2(xt << 4, yt << 4));
			selection.End(new Vector2(xt << 4, yt << 4));

			SelectionUtil.DrawRectangle(
				spriteBatch,
				Color.Black,
				new Rectangle(
					selection.Region.X * 16 + 1,
					selection.Region.Y * 16 + 1 - this.scrollbar.Value,
					selection.Region.Width * 16,
					selection.Region.Height * 16));

			SelectionUtil.DrawRectangle(
				spriteBatch,
				Color.White,
				new Rectangle(
					selection.Region.X * 16,
					selection.Region.Y * 16 - this.scrollbar.Value,
					selection.Region.Width * 16,
					selection.Region.Height * 16));
			spriteBatch.End();
		}
	}
}