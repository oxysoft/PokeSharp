using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Editor.Selections;
using GameEngine.Data.Tiles;
using GameEngine.Data.Tiles.Behaviors;
using General.Extensions;
using General.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Controls.EditorView {
	public class ControlTilesetEditor : GameControl {
		private SpriteBatch batch;
		public VScrollBar vscrollbar;
		public HScrollBar hscrollbar;
		public event EventHandler selectedIndexChanged;
		public int xt, yt, selectedIndex;
		public int Mode;
		public byte Behavior;

		public TileableTexture ox;

		public ControlTilesetEditor() {
			this.GameLoopEnabled = true;
			this.MouseDown += this.OnMouseMove;
			this.MouseMove += this.OnMouseMove;
		}

		public Tileset Tileset { get; set; }

		public override void LoadContent() {
			batch = new SpriteBatch(GraphicsDevice);
			base.LoadContent();
			Tileset = null;
			using (MemoryStream stream = new MemoryStream()) {
				MapEditor.Data.Resources.ox.Save(stream, ImageFormat.Png);
				ox = new TileableTexture(Texture2D.FromStream(EditorEngine.Instance.GraphicsDevice, stream), 2, 1);
			}
		}

		public void LoadTileset(string name, Texture2D texture) {
			Tileset.Texture = new TileableTexture(texture);

			int xt = texture.Width >> 4;
			int yt = texture.Height >> 4;

			hscrollbar.Maximum = xt << 4;
			vscrollbar.Maximum = yt << 4;

			Tileset.Texture.Columns = texture.Width >> 4;
			Tileset.Texture.Rows = texture.Height >> 4;

			Tileset.GenerateTiles();
		}

		private bool switchOff = false;

		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e) {
			int xt = (e.X + hscrollbar.Value) / 16;
			int yt = (e.Y + vscrollbar.Value) / 16;

			if (xt < 0 || yt < 0) return;


			if (Tileset != null) {
				if (Mode == 1) {
					if (e.Button == MouseButtons.Left) {
						int col = Tileset.Texture.Texture.Width >> 4;
						int index = yt * col + xt;
						MockupTileBehavior tileBehavior = Tileset.Tiles[index].DefaultBehavior;
						if (tileBehavior.BehaviorId == this.Behavior) {
							Tileset.Tiles[index].DefaultBehavior.BehaviorId = TileBehavior.Height2.Id;
							switchOff = true;
						} else {
							Tileset.Tiles[index].DefaultBehavior.BehaviorId = this.Behavior;
							switchOff = false;
						}
					}
				}
			}

			base.OnMouseDown(e);
		}

		public void OnMouseMove(object sender, MouseEventArgs e) {
			int xt = (e.X + hscrollbar.Value) / 16;
			int yt = (e.Y + vscrollbar.Value) / 16;

			if (xt < 0 || yt < 0) return;

			if (Tileset != null) {
				if (Mode == 1) {
					if (e.Button == MouseButtons.Left) {
						int col = Tileset.Texture.Texture.Width >> 4;
						int index = yt * col + xt;
						MockupTileBehavior tileBehavior = Tileset.Tiles[index].DefaultBehavior;
						if (switchOff) {
							Tileset.Tiles[index].DefaultBehavior.BehaviorId = TileBehavior.Height2.Id;
						} else {
							Tileset.Tiles[index].DefaultBehavior.BehaviorId = this.Behavior;
						}
					}
				}
			}
		}

		public override void Update(Microsoft.Xna.Framework.GameTime gameTime) {
			base.Update(gameTime);
		}

		public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
			int ypos = vscrollbar.Value;
			int xpos = hscrollbar.Value;

			if (Tileset != null) {
				if (Tileset.Texture != null && Tileset.Texture.Texture != null) {
					batch.Begin();
					batch.Draw(Tileset.Texture.Texture, -new Vector2(xpos, ypos), Color.White);

					int x = Tileset.Texture.Texture.Width - xpos;
					int y = Tileset.Texture.Texture.Height - ypos;

					SelectionUtil.DrawStraightLine(batch, new Color(.9f, .4f, .4f, 1f), 1f, x, -ypos, 2, Tileset.Texture.Texture.Height); //vertical
					SelectionUtil.DrawStraightLine(batch, new Color(.9f, .4f, .4f, 1f), 1f, -xpos, y, 1, Tileset.Texture.Texture.Width); //horizontal

					SelectionUtil.DrawRectangle(batch, new Color(.7f, .1f, 0f, .6f), new Rectangle((xt << 4) - xpos, (yt << 4) - ypos, 16, 16));
					SelectionUtil.FillRectangle(batch, new Color(.4f, .1f, 0f, .6f), new Rectangle((xt << 4) + 1 - xpos, (yt << 4) + 1 - ypos, 16, 16));

					int ry = 0;
					int rx = 0;
					foreach (Tile t in Tileset.Tiles) {
						if (rx + 1 > Tileset.Texture.Texture.Width / 16) {
							rx = 0;
							ry++;
						}
						batch.Draw(ox.Texture, new Rectangle((rx << 4) - xpos, (ry << 4) - ypos, 16, 16), ox.GetSource(t.DefaultBehavior.BehaviorId == this.Behavior ? 0 : 1), Color.White * 0.8f);
						rx++;
					}
					batch.End();
				}
			}

			base.Draw(gameTime);
		}
	}
}