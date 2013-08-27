using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Editor.Selections;
using GameEngine.Data.Entities;
using GameEngine.Data.Entities.Core;
using General.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Controls.EditorView {
	public class ControlEntityEditor : GameControl {
		public bool[] Collisions;
		public SpriteBatch SpriteBatch;
		public EntityTemplate Template;

		public ControlEntityEditor() {
			selection = new Selection();
			Template = new EntityTemplate();
		}

		public int Mode { get; set; }

		private Selection selection;

		protected override void OnMouseDown(MouseEventArgs e) {
			int xt = e.X;
			int yt = e.Y;
			if (Mode == 1) {
				if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) {
					selection.Start(new Vector2(xt, yt));
				}
			} else if (Mode == 2) {
				if (e.Button == MouseButtons.Left) {
					Template.ShadowOffset = e.Y;
				}
			}
			base.OnMouseDown(e);
		}

		protected override void OnMouseMove(MouseEventArgs e) {
			if (Mode == 1) {
				if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) {
					int xt = e.X;
					int yt = e.Y;

					if (xt > 3 || yt > 3) {
						selection.End(new Vector2(xt, yt));
					}
				}
			} else if (Mode == 2) {
				if (e.Button == MouseButtons.Left) {
					Template.ShadowOffset = e.Y;
				}
			}
			base.OnMouseMove(e);
		}

		protected override void OnMouseUp(MouseEventArgs e) {
			if (Mode == 1) {
				if (e.Button == MouseButtons.Left) {
					if (selection.Region.Width > 0 && selection.Region.Height > 0) {
						Template.CollisionMap.Add(selection.Region);
					}
				} else if (e.Button == MouseButtons.Right) {
					Rectangle sel = selection.Region;
					List<Rectangle> toRemove = Template.CollisionMap.Where(rect => rect.X >= sel.X &&
					                                                               rect.Y >= sel.Y &&
					                                                               rect.X + rect.Width <= sel.X + sel.Width &&
					                                                               rect.Y + rect.Height <= sel.Y + sel.Height).ToList();
					foreach (Rectangle r in toRemove) {
						Template.CollisionMap.Remove(r);
					}
				}
				selection.Region = Rectangle.Empty;
			}
			base.OnMouseUp(e);
		}

		public override void Update(GameTime gameTime) {
		}

		public override void Draw(GameTime gameTime) {
			if (SpriteBatch == null) {
				SpriteBatch = new SpriteBatch(GraphicsDevice);
			}

			if (Template != null && Template.Texture != null) {
				Rectangle dest = Template.Texture.GetSource(0);
				SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise);
				if (Mode == 0) { /*Viewer*/
					SpriteBatch.Draw(Template.Texture.Texture, dest, Template.Texture.GetSource(0), Color.White);
				} else if (Mode == 1) { /*Collisions*/
					SpriteBatch.Draw(Template.Texture.Texture, dest, Color.White);

					Color col = new Color(255, 75, 0, 255);
					Color col2 = new Color(250, 35, 0, 255);
					foreach (Rectangle rect in Template.CollisionMap) {
						Rectangle w1 = new Rectangle(rect.X * 16, rect.Y * 16, rect.Width * 16, rect.Height * 16);
						Rectangle w2 = new Rectangle(rect.X * 16 + 1, rect.Y * 16 + 1, rect.Width * 16 - 1, rect.Height * 16 - 1);

						SelectionUtil.DrawRectangle(SpriteBatch, col * .7f, w1);
						SelectionUtil.FillRectangle(SpriteBatch, col2 * .3f, w2);
					}

					Rectangle ww = new Rectangle(selection.Region.X * 16, selection.Region.Y * 16, selection.Region.Width * 16, selection.Region.Height * 16);
					SelectionUtil.DrawRectangle(SpriteBatch, Color.White, ww);
				} else if (Mode == 2) {
					Vector2 pos = new Vector2(0, Template.ShadowOffset);
					Rectangle src = Template.Texture.GetSource(0);
					Rectangle target = new Rectangle((int) pos.X, (int) pos.Y, Template.Texture.FrameWidth, (int) (Template.Texture.FrameHeight * 0.6f));
					if (Template.ShadowType == ShadowType.Perspective) {
						SpriteBatch.Draw(Template.Texture.Texture, target, src, new Color(0f, 0f, 0f, 0.3f), 0.0f, Vector2.Zero, SpriteEffects.FlipVertically, 0f);
					}
					SpriteBatch.Draw(Template.Texture.Texture, dest, Color.White);

					SelectionUtil.DrawStraightLine(SpriteBatch, Color.White, 0, Template.ShadowOffset, 1, Width);
				}
				SpriteBatch.End();
			}
		}

		public object List { get; set; }
	}
}