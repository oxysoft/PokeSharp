using System.Drawing;
using System.Windows.Forms;

namespace MapEditor.UI.Old.Menu {
	public class ToolBar : ToolStrip {
		public ToolBar() {
			this.DoubleBuffered = true;
			this.Padding = new Padding(5);
			this.Renderer = new MenuRenderer();
		}

		public bool RenderBackground {
			get { return (Renderer as MenuRenderer).RenderBackground; }
			set { (Renderer as MenuRenderer).RenderBackground = value; }
		}

		private class MenuRenderer : ToolStripRenderer {
			public MenuRenderer() {
				this.RenderBackground = true;
			}

			public bool RenderBackground { get; set; }
			public Image BackgroundImage { get; set; }

			protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e) {
				GraphicsHelper helper = new GraphicsHelper(e.Graphics);
				Rectangle bounds = new Rectangle(-1, -1, e.AffectedBounds.Width + 1, e.AffectedBounds.Height + 1);

				//helper.Clear(UColor.Argb(255, 0, 0, 0));
				helper.Gradient(UColor.Rgb(0x30, 0x30, 0x30), UColor.Rgb(0x1D, 0x1D, 0x1D), bounds, 90);
			}

			protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) {
				GraphicsHelper helper = new GraphicsHelper(e.Graphics);
				Rectangle bounds = e.AffectedBounds;

				helper.Line(UColor.Blend(155 / 2, UColor.Rgb(0x06, 0x88, 0xD8)), 0, bounds.Width, bounds.Height - 3);
				helper.Line(UColor.Blend(155, UColor.Rgb(0x06, 0x88, 0xD8)), 0, bounds.Width, bounds.Height - 2);
				helper.Line(UColor.Rgb(0x06, 0x88, 0xD8), 0, bounds.Width, bounds.Height - 1);
				//				helper.Line(UColor.Rgb(25, 25, 25), 0, bounds.Width, bounds.Height - 1);

				base.OnRenderToolStripBorder(e);
			}

			protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e) {
				GraphicsHelper helper = new GraphicsHelper(e.Graphics);
				ToolStripButton button = e.Item as ToolStripButton;
				Rectangle bounds = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);

				if (e.Item.Selected) {
					helper.RoundedGradient(UColor.Rgb(0x06, 0x88, 0xB8), UColor.Rgb(0x06, 0x88, 0xB8), bounds, 90, 2);
				}
				base.OnRenderButtonBackground(e);
			}

			protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e) {
				GraphicsHelper helper = new GraphicsHelper(e.Graphics);
				ToolStripButton button = e.Item as ToolStripButton;
				Rectangle bounds = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);

				if (e.Item.Selected) {
					helper.RoundedGradient(UColor.Rgb(0x06, 0x88, 0xB8), UColor.Rgb(0x06, 0x88, 0xB8), bounds, 90, 2);
				}
			}

			protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) {
				GraphicsHelper helper = new GraphicsHelper(e.Graphics);
				ToolStripButton button = e.Item as ToolStripButton;
				Rectangle bounds = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);

				if (e.Item.Selected) {
					helper.RoundedGradient(UColor.Rgb(0x06, 0x88, 0xB8), UColor.Rgb(0x06, 0x88, 0xB8), bounds, 90, 2);
				}
			}

			protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e) {
				GraphicsHelper helper = new GraphicsHelper(e.Graphics);

				Rectangle shadow = new Rectangle(
					e.TextRectangle.X + 1,
					e.TextRectangle.Y + 1,
					e.TextRectangle.Width,
					e.TextRectangle.Height);

				uint shadowColor = UColor.Blend(0x10, UColor.White);
				uint textColor = UColor.Argb(255, 0xBB, 0xBB, 0xBB);

				if (e.Item.Selected || e.Item.Pressed) {
					shadowColor = UColor.Blend(0x7a, UColor.White);
					textColor = UColor.White;
				}

				StringFormat format = new StringFormat();
				format.LineAlignment = StringAlignment.Center;
				format.Alignment = StringAlignment.Near;

				if (!e.Item.Selected) helper.Text(e.Text, e.TextFont, shadowColor, shadow, format);
				helper.Text(e.Text, e.TextFont, textColor, e.TextRectangle, format);
			}
		}
	}
}