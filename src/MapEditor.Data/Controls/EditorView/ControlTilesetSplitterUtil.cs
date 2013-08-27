using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Editor.Selections;
using GameEngine.Data.Tiles;
using General.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Controls.EditorView {
	public class ControlTilesetSplitterUtil : GameControl {

		public const int MaxAmount = 1024;
		public int currentEntity;
		public bool checkerboard, colorbuffer, ignoretransparent;
		public Tileset Tileset;
		public VScrollBar vscrollbar;
		public HScrollBar hscrollbar;
		public SpriteBatch spriteBatch;
		public List<Vector2>[] points;
		public Tuple<int, int, int>[] colors;

		public ControlTilesetSplitterUtil() {
			points = new List<Vector2>[MaxAmount]; //create a 1024 buffer
			colors = new Tuple<int, int, int>[MaxAmount]; //create a 1024 color buffer

			for (int i = 0; i < points.Length; i++) {
				points[i] = new List<Vector2>();
			}

			ScrambleColors();
		}

		public void LoadTileset(Texture2D texture) {
			Tileset = new Tileset("splittertileset", EditorEngine.Instance.World.TilesetFactory);
			Tileset.Texture = new TileableTexture(texture);

			int xt = texture.Width >> 4;
			int yt = texture.Height >> 4;

			hscrollbar.Maximum = xt << 4;
			vscrollbar.Maximum = yt << 4;

			Tileset.Texture.Columns = texture.Width >> 4;
			Tileset.Texture.Rows = texture.Height >> 4;

			Tileset.GenerateTiles();

			Random rand = new Random();

			//Reset points
			for (int i = 0; i < points.Length; i++) {
				points[i].Clear();
			}

			//Scramble colors
			ScrambleColors();
		}

		public void ScrambleColors() {
			Random rand = new Random();

			for (int i = 0; i < colors.Length; i++) {
				int[] col = new int[3];

				int inf = rand.Next(0, 2);
				int sec = rand.Next(0, 2);

				for (int c = 0; c < col.Length; c++) {
					col[c] = rand.Next(15, 31);
				}

				col[inf] += Math.Min(col[inf] + rand.Next(200, 230), 255);
				col[sec] += Math.Min(col[sec] + rand.Next(100, 250), 255);

				colors[i] = new Tuple<int, int, int>(col[0], col[1], col[2]);
			}
		}


		public void SaveResults(string loc) {
			List<Texture2D> result = new List<Texture2D>();
			for (int i = 0; i < points.Length; i++) {
				List<Vector2> _points = points[i];
				if (_points.Count > 0) {
					int xmin = Int32.MaxValue;
					int xmax = -1;
					int ymin = Int32.MaxValue;
					int ymax = -1;
					foreach (Vector2 point in _points) {
						if (point.X < xmin)
							xmin = (int)point.X;
						if (point.Y < ymin)
							ymin = (int)point.Y;
						if (point.X > xmax)
							xmax = (int)point.X;
						if (point.Y > ymax)
							ymax = (int)point.Y;
					}

					int w = xmax * 16 - xmin * 16;
					int h = ymax * 16 - ymin * 16;
					w += 16;
					h += 16;

					RenderTarget2D target = new RenderTarget2D(GraphicsDevice, w, h);
					GraphicsDevice.SetRenderTarget(target);
					GraphicsDevice.Clear(Color.Transparent);
					SpriteBatch batch = new SpriteBatch(GraphicsDevice);
					batch.Begin();
					foreach (Vector2 point in _points) {
						Rectangle rect = new Rectangle((int)point.X << 4, (int)point.Y << 4, 16, 16);
						batch.Draw(Tileset.Texture.Texture, new Vector2(((int)point.X << 4) - xmin * 16, ((int)point.Y << 4) - ymin * 16), rect, Color.White);
					}
					batch.End();
					GraphicsDevice.SetRenderTarget(null);
					using (FileStream stream = File.OpenWrite(loc + "\\" + i + ".png")) {
						target.SaveAsPng(stream, target.Width, target.Height);
						stream.Flush();
						stream.Close();
					}
				}
			}
		}

		bool add = false;

		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				int xt = (e.X + hscrollbar.Value) >> 4;
				int yt = (e.Y + vscrollbar.Value) >> 4;

				if (!points[currentEntity].Contains(new Vector2(xt, yt))) {
					add = true;
				} else add = false;

				if (add) {
					if (!points[currentEntity].Contains(new Vector2(xt, yt))) {

						if (ignoretransparent) {
							//THERE IS NO EASY WAY OUT OF THIS
							RenderTarget2D target = new RenderTarget2D(GraphicsDevice, 16, 16);
							GraphicsDevice.SetRenderTarget(target);
							GraphicsDevice.Clear(Color.Transparent);
							SpriteBatch _spriteBatch = new SpriteBatch(GraphicsDevice);
							_spriteBatch.Begin();
							Rectangle srcRect = new Rectangle(xt << 4, yt << 4, 16, 16);
							_spriteBatch.Draw(Tileset.Texture.Texture, new Vector2(16, 16), srcRect, Color.White);
							_spriteBatch.End();

							GraphicsDevice.SetRenderTarget(null);

							Color[] pixels = new Color[16 * 16];
							target.GetData<Color>(pixels);

							bool yes = false;

							for (int i = 0; i < pixels.Length; i++) {
								if (pixels[i] != Color.Transparent) {
									yes = true;
									break;
								}
							}

							if (yes) {
								/*
								using (FileStream stream = File.OpenWrite("C:\\Users\\Oxysoft\\Desktop\\_splitter_tool\\" + "wtf.png")) {
									target.SaveAsPng(stream, target.Width, target.Height);
									stream.Flush();
									stream.Close();
								}*/

								points[currentEntity].Add(new Vector2(xt, yt));
							}

						} else points[currentEntity].Add(new Vector2(xt, yt));
					}
				} else {
					if (points[currentEntity].Contains(new Vector2(xt, yt))) {
						points[currentEntity].Remove(new Vector2(xt, yt));
					}
				}
			}

			base.OnMouseDown(e);
		}

		protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				int xt = (e.X + hscrollbar.Value) >> 4;
				int yt = (e.Y + vscrollbar.Value) >> 4;

				if (xt > -1 && yt > -1 && xt < Tileset.Texture.Columns && yt < Tileset.Texture.Rows) {
					if (add) {
						if (!points[currentEntity].Contains(new Vector2(xt, yt))) {
							if (ignoretransparent) {
								//THERE IS NO EASY WAY OUT OF THIS
								RenderTarget2D target = new RenderTarget2D(GraphicsDevice, 16, 16);
								GraphicsDevice.SetRenderTarget(target);
								GraphicsDevice.Clear(Color.Transparent);
								SpriteBatch _spriteBatch = new SpriteBatch(GraphicsDevice);
								_spriteBatch.Begin();
								Rectangle srcRect = new Rectangle(xt << 4, yt << 4, 16, 16);
								Rectangle trgRect = new Rectangle(0, 0, 16, 16);
								_spriteBatch.Draw(Tileset.Texture.Texture, trgRect, srcRect, Color.White);
								_spriteBatch.End();

								GraphicsDevice.SetRenderTarget(null);

								Color[] pixels = new Color[16 * 16];
								target.GetData<Color>(pixels);

								bool yes = false;

								for (int i = 0; i < pixels.Length; i++) {
									Color col = pixels[i];
									if (col != Color.Transparent) {
										yes = true;
										break;
									}
								}

								if (yes) {
									points[currentEntity].Add(new Vector2(xt, yt));
								}
							} else points[currentEntity].Add(new Vector2(xt, yt));
						}
					} else {
						if (points[currentEntity].Contains(new Vector2(xt, yt))) {
							points[currentEntity].Remove(new Vector2(xt, yt));
						}
					}
				}
			}

			base.OnMouseMove(e);
		}

		protected override void OnMouseUp(MouseEventArgs e) {
			base.OnMouseUp(e);
		}

		public override void Update(Microsoft.Xna.Framework.GameTime gameTime) {
			base.Update(gameTime);
		}

		public override void Draw(Microsoft.Xna.Framework.GameTime gameTime) {
			int xpos = hscrollbar.Value;
			int ypos = vscrollbar.Value;

			if (spriteBatch == null) spriteBatch = new SpriteBatch(GraphicsDevice);

			if (Tileset != null) {
				if (checkerboard) {
					int i = 0;
					for (int cy = 0; cy < Tileset.Texture.Rows; cy++) {
						for (int cx = 0; cx < Tileset.Texture.Columns; cx++) {
							bool odd = i % 2 != 0;
							//0xD8DEFF
							//0xBFC8FF
							Color col_dark = new Color(0xd8, 0xde, 0xff);
							Color col_light = new Color(0xbf, 0xc8, 0xff);
							SelectionUtil.FillRectangle(spriteBatch, odd ? col_light : col_dark, new Rectangle(cx * 16 - xpos, cy * 16 - ypos, 16, 16));
							i++;
						}
						i++;
					}
				}
				spriteBatch.Begin();
				spriteBatch.Draw(Tileset.Texture.Texture, -new Vector2(xpos, ypos), Color.White);
				spriteBatch.End();

				int x = Tileset.Texture.Texture.Width - xpos;
				int y = Tileset.Texture.Texture.Height - ypos;

				SelectionUtil.DrawStraightLine(spriteBatch, new Color(.9f, .4f, .4f, 1f), 1f, x, -ypos, 2, Tileset.Texture.Texture.Height); //vertical
				SelectionUtil.DrawStraightLine(spriteBatch, new Color(.9f, .4f, .4f, 1f), 1f, -xpos, y, 1, Tileset.Texture.Texture.Width); //horizontal


				List<Vector2> _points = points[currentEntity];
				foreach (Vector2 vec2 in _points) {
					Tuple<int, int, int> bcol = colors[currentEntity];
					Color col = new Color(bcol.Item1, bcol.Item2, bcol.Item3);
					SelectionUtil.FillRectangle(spriteBatch, colorbuffer ? (col * 0.6f) : (Color.Red * 0.6f), new Rectangle((int)vec2.X * 16 - xpos, (int)vec2.Y * 16 - ypos, 16, 16));
				}

				for (int i = 0; i < points.Length; i++) {
					if (i != currentEntity) {
						foreach (Vector2 vec2 in points[i]) {
							SelectionUtil.FillRectangle(spriteBatch, Color.Black * 0.4f, new Rectangle((int)vec2.X * 16 - xpos, (int)vec2.Y * 16 - ypos, 16, 16));
						}
					}
				}
			}

			base.Draw(gameTime);
		}
	}
}
