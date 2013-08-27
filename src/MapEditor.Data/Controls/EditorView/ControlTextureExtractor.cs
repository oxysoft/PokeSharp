using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Editor.Selections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using General.Extensions;

namespace MapEditor.Data.Controls.EditorView {
	public class ControlTextureExtractor : GameControl {
		public Texture2D Texture;
		public SpriteBatch SpriteBatch;
		public ScrollBar VerticalSB, HorizontalSB;
		public Selection[] Buffer;
		private float scale = 1f;
		private int bufferIndex;

		//Configuration
		public const int BUFFER_SIZE = 1024;
		public bool ProcessBlankPixels = true;
		public bool AutoAdvance = false;
		public bool IntelligentFillSelection = false;

		public int CurrentBufferIndex {
			get { return bufferIndex; }
			set {
				bufferIndex = value;
				BufferIndexChanged.SafeInvoke(this, EventArgs.Empty);
			}
		}

		public new float Scale {
			get { return scale; }
			set {
				scale = value;
				RefreshBars();
				ScaleChanged.SafeInvoke(this, EventArgs.Empty);
			}
		}

		public event EventHandler ScaleChanged;
		public event EventHandler BufferIndexChanged;

		public ControlTextureExtractor() {
			this.GameLoopEnabled = true;
		}

		public void Initialize(ScrollBar v, ScrollBar h) {
			this.VerticalSB = v;
			this.HorizontalSB = h;
			this.Texture = null;

			Buffer = new Selection[BUFFER_SIZE];

			for (int i = 0; i < BUFFER_SIZE; i++) {
				Buffer[i] = new Selection {
					                          GridWidth = 1, GridHeight = 1
				                          };
			}
		}

		public void LoadTexture(string loc) {
			LoadTexture(Texture2D.FromStream(this.GraphicsDevice, File.OpenRead(loc)));
		}

		public void LoadTexture(Texture2D texture) {
			this.Texture = texture;
		}

		public void RefreshBars() {
			if (Texture == null) return;
			VerticalSB.Maximum = Math.Max(0, (int) (Texture.Height * Scale - Height));
			HorizontalSB.Maximum = Math.Max(0, (int) (Texture.Width * Scale - Width));
		}

		public void DumpAll(string dumploc) {
			for (int i = 0; i < BUFFER_SIZE; i++) {
				Selection selection = Buffer[i];
				Rectangle selrect = selection.Region;
				if (selrect != Rectangle.Empty) {
					RenderTarget2D target = new RenderTarget2D(GraphicsDevice, selrect.Width, selrect.Height);
					GraphicsDevice.SetRenderTarget(target);
					GraphicsDevice.Clear(Color.Transparent);
					SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);
					spriteBatch.Begin();
					spriteBatch.Draw(Texture, new Rectangle(0, 0, selrect.Width, selrect.Height), new Rectangle(selrect.X, selrect.Y, selrect.Width, selrect.Height), Color.White);
					spriteBatch.End();
					GraphicsDevice.SetRenderTarget(null);
					using (FileStream stream = File.OpenWrite(dumploc + "\\" + i + ".png")) {
						target.SaveAsPng(stream, target.Width, target.Height);
						stream.Flush();
						stream.Close();
					}
				}
			}
		}

		public override void Initialize() {
			base.Initialize();
		}

		public override void Update(GameTime gameTime) {
			base.Update(gameTime);
		}

		protected override void OnMouseDown(MouseEventArgs e) {
			int x = e.X + (Int32) (HorizontalSB.Value * Scale);
			int y = e.Y + (Int32) (VerticalSB.Value * Scale);

			x = (int) Math.Round(x / Scale);
			y = (int) Math.Round(y / Scale);

			Buffer[CurrentBufferIndex].Start(new Vector2(x, y));
			base.OnMouseDown(e);
		}

		protected override void OnMouseMove(MouseEventArgs e) {
			int x = e.X + (Int32) (HorizontalSB.Value * Scale);
			int y = e.Y + (Int32) (VerticalSB.Value * Scale);

			x = (int) (x / Scale);
			y = (int) (y / Scale);

			if (e.Button == MouseButtons.Left) {
				Buffer[CurrentBufferIndex].End(new Vector2(x, y));
			}
			base.OnMouseMove(e);
		}

		protected override void OnMouseUp(MouseEventArgs e) {
			int x = e.X + (Int32) (HorizontalSB.Value * Scale);
			int y = e.Y + (Int32) (VerticalSB.Value * Scale);

			x = (int) Math.Round(x / Scale);
			y = (int) Math.Round(y / Scale);

			Buffer[CurrentBufferIndex].End(new Vector2(x, y));
			Rectangle selrect = Buffer[CurrentBufferIndex].Region;

			int xmin = Int32.MaxValue;
			int ymin = Int32.MaxValue;
			int xmax = -1;
			int ymax = -1;

			if (ProcessBlankPixels) {
				if (!IntelligentFillSelection) {
					//xmin
					for (int i = 0; i < selrect.Width; i++) {
						for (int j = 0; j < selrect.Height; j++) {
							Vector2 pos = new Vector2(selrect.X + i, selrect.Y + j);

							RenderTarget2D target = new RenderTarget2D(GraphicsDevice, 1, 1);
							GraphicsDevice.SetRenderTarget(target);
							GraphicsDevice.Clear(Color.Transparent);
							SpriteBatch _spriteBatch = new SpriteBatch(GraphicsDevice);

							_spriteBatch.Begin();
							Rectangle srcRect = new Rectangle(selrect.X + i, selrect.Y + j, 1, 1);
							_spriteBatch.Draw(Texture, new Vector2(0, 0), srcRect, Color.White);
							_spriteBatch.End();

							GraphicsDevice.SetRenderTarget(null);

							Color[] pixels = new Color[1];
							target.GetData<Color>(pixels);

							if (pixels[0] != Color.Transparent) {
								xmin = i;
								goto one;
							}
						}
					}
				//ymin
				one:
					for (int j = 0; j < selrect.Height; j++) {
						for (int i = 0; i < selrect.Width; i++) {
							Vector2 pos = new Vector2(selrect.X + i, selrect.Y + j);

							RenderTarget2D target = new RenderTarget2D(GraphicsDevice, 1, 1);
							GraphicsDevice.SetRenderTarget(target);
							GraphicsDevice.Clear(Color.Transparent);
							SpriteBatch _spriteBatch = new SpriteBatch(GraphicsDevice);

							_spriteBatch.Begin();
							Rectangle srcRect = new Rectangle(selrect.X + i, selrect.Y + j, 1, 1);
							_spriteBatch.Draw(Texture, new Vector2(0, 0), srcRect, Color.White);
							_spriteBatch.End();

							GraphicsDevice.SetRenderTarget(null);

							Color[] pixels = new Color[1];
							target.GetData<Color>(pixels);

							if (pixels[0] != Color.Transparent) {
								ymin = j;
								goto two;
							}
						}
					}
				//xmax
				two:
					for (int i = selrect.Width; i > 0; i--) {
						for (int j = selrect.Height; j > 0; j--) {
							Vector2 pos = new Vector2(selrect.X + i, selrect.Y + j);

							RenderTarget2D target = new RenderTarget2D(GraphicsDevice, 1, 1);
							GraphicsDevice.SetRenderTarget(target);
							GraphicsDevice.Clear(Color.Transparent);
							SpriteBatch _spriteBatch = new SpriteBatch(GraphicsDevice);

							_spriteBatch.Begin();
							Rectangle srcRect = new Rectangle(selrect.X + i, selrect.Y + j, 1, 1);
							_spriteBatch.Draw(Texture, new Vector2(0, 0), srcRect, Color.White);
							_spriteBatch.End();

							GraphicsDevice.SetRenderTarget(null);

							Color[] pixels = new Color[1];
							target.GetData<Color>(pixels);

							if (pixels[0] != Color.Transparent) {
								xmax = i;
								goto three;
							}
						}
					}
				//ymax
				three:
					for (int j = selrect.Height; j > 0; j--) {
						for (int i = selrect.Width; i > 0; i--) {
							Vector2 pos = new Vector2(selrect.X + i, selrect.Y + j);

							RenderTarget2D target = new RenderTarget2D(GraphicsDevice, 1, 1);
							GraphicsDevice.SetRenderTarget(target);
							GraphicsDevice.Clear(Color.Transparent);
							SpriteBatch _spriteBatch = new SpriteBatch(GraphicsDevice);

							_spriteBatch.Begin();
							Rectangle srcRect = new Rectangle(selrect.X + i, selrect.Y + j, 1, 1);
							_spriteBatch.Draw(Texture, new Vector2(0, 0), srcRect, Color.White);
							_spriteBatch.End();

							GraphicsDevice.SetRenderTarget(null);

							Color[] pixels = new Color[1];
							target.GetData<Color>(pixels);

							if (pixels[0] != Color.Transparent) {
								ymax = j;
								goto four;
							}
						}
					}
				four:

					Vector2 point1 = new Vector2(selrect.X + xmin, selrect.Y + ymin);
					Vector2 point2 = new Vector2(selrect.X + xmax, selrect.Y + ymax);

					Buffer[CurrentBufferIndex].Start(point1);
					Buffer[CurrentBufferIndex].End(point2);
				} else {
					//this may be the hardest thing i'll ever achieve
				}

				if (AutoAdvance) CurrentBufferIndex++;
			}

			base.OnMouseUp(e);
		}

		public override void Draw(GameTime gameTime) {
			if (Texture != null) {
				//Lazy initializing
				if (SpriteBatch == null) SpriteBatch = new SpriteBatch(this.GraphicsDevice);

				Matrix DrawMatrix = Matrix.CreateScale(Scale);

				SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, null, DrawMatrix);
				SpriteBatch.Draw(Texture, new Rectangle(-HorizontalSB.Value, -VerticalSB.Value, Texture.Width, Texture.Height), Color.White);

				for (int i = 0; i < BUFFER_SIZE; i++) {
					if (Buffer[i].Region != Rectangle.Empty && i != CurrentBufferIndex) {
						Selection _sel = Buffer[i];
						SelectionUtil.DrawRectangle(SpriteBatch, Color.Black * .4f, new Rectangle(_sel.Region.X - HorizontalSB.Value, _sel.Region.Y - VerticalSB.Value, _sel.Region.Width, _sel.Region.Height));
						SelectionUtil.FillRectangle(SpriteBatch, Color.White * .2f, new Rectangle(_sel.Region.X + 1 - HorizontalSB.Value, _sel.Region.Y + 1 - VerticalSB.Value, _sel.Region.Width - 1, _sel.Region.Height - 1));
					}
				}

				Selection sel = Buffer[CurrentBufferIndex];
				SelectionUtil.DrawRectangle(SpriteBatch, Color.Black * .7f, new Rectangle(sel.Region.X - HorizontalSB.Value, sel.Region.Y - VerticalSB.Value, sel.Region.Width, sel.Region.Height));
				SelectionUtil.FillRectangle(SpriteBatch, Color.White * .4f, new Rectangle(sel.Region.X + 1 - HorizontalSB.Value, sel.Region.Y + 1 - VerticalSB.Value, sel.Region.Width - 1, sel.Region.Height - 1));

				SpriteBatch.End();
			}
		}
	}
}