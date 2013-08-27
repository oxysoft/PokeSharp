using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditor.UI.Old.Common {
	[DefaultEvent("Click")]
	public class ColoredButton : UserControl {
		public ColoredButton() {
			this.BackColor = Color.Transparent;
			this.DoubleBuffered = true;

			this.Width = 85;
			this.Height = 28;

			this.Caption = "Button";
		}

		public Image Image {
			get;
			set;
		}
		public bool Hover;
		public bool Pressed;
		public string Caption {
			get;
			set;
		}

		protected override void OnMouseEnter(EventArgs e) {
			Hover = true;
			Invalidate();
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e) {
			Hover = false;
			Invalidate();
			base.OnMouseLeave(e);
		}

		protected override void OnMouseDown(MouseEventArgs e) {
			Pressed = true;
			Invalidate();
			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e) {
			Pressed = false;
			Invalidate();
			base.OnMouseUp(e);
		}


		protected override void OnPaint(PaintEventArgs e) {
			GraphicsHelper helper = new GraphicsHelper(e.Graphics);

			const int r = 7;
			const int shadowHeight = 4;

			Rectangle bounds = new Rectangle(0, 0, this.Width - 1, this.Height - 1 - shadowHeight);
			Rectangle rectShadow = new Rectangle(0, 0, Width - 1, Height - 1);
			Rectangle rectText = bounds;
			Rectangle rectTextShadow = new Rectangle(1, 1, rectText.Width - 2, rectText.Height - 1);
			if (Image != null) rectText = new Rectangle(bounds.X, bounds.Y, bounds.Width + Image.Width, bounds.Height);

			helper.RoundedFill(UColor.White, bounds, r);

			if (!Hover) {
				if (Enabled) {
					//32C437: Main color
					//2AA92E: Shadow
					//0A890D: Outline
					const uint color = 0x32c437;
					const uint color_shadow = 0x2aa92e;
					const uint color_outline = 0x0a890d;
					helper.RoundedFill(UColor.Blend(255, color_shadow), rectShadow, r);
					helper.RoundedGradient(UColor.Blend(200, color), UColor.Blend(255, color), bounds, 90, r);
					helper.RoundedOutline(UColor.Blend(255, color_outline), rectShadow, r);

					helper.Text(Caption, this.Font, UColor.White, rectTextShadow);
					helper.Text(Caption, this.Font, UColor.Blend(0xdd, UColor.White), rectText);
				} else {
				}
			} else {
				if (!Pressed) {
				} else {
				}
			}

			if (Image != null) {
				e.Graphics.DrawImage(this.Image, new Point(this.Width / 4 - this.Image.Width / 2, this.Height / 2 - this.Image.Height / 2));
			}
		}
	}
}
