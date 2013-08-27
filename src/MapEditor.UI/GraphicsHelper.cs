using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace MapEditor.UI {
	public class GraphicsHelper {
		#region Constructors

		public GraphicsHelper(Graphics graphics) {
			this.graphics = graphics;

			this.graphics.SmoothingMode = SmoothingMode.AntiAlias;
			this.graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		}

		#endregion

		#region Fields

		private Graphics graphics;

		#endregion

		#region Methods

		public void Gradient(uint argb0, uint argb1, Rectangle rect, float angle) {
			Color from = argb0.ToColor();
			Color to = argb1.ToColor();

			this.graphics.FillRectangle(
				new LinearGradientBrush(
					new Rectangle(rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2),
					from, to, angle),
				rect);
		}

		public void Clear(uint argb) {
			this.graphics.Clear(argb.ToColor());
		}

		public void Line(uint argb, int x0, int y0, int x1, int y1) {
			this.graphics.DrawLine(new Pen(argb.ToColor()), x0, y0, x1, y1);
		}

		public void Line(uint argb, int x0, int x1, int y) {
			this.Line(argb, x0, y, x1, y);
		}

		public void Outline(uint argb0, Rectangle rect) {
			this.graphics.DrawRectangle(new Pen(argb0.ToColor()), rect);
		}

		public void RoundedGradient(uint argb0, uint argb1, Rectangle rect, float angle, int radius) {
			GraphicsPath roundedPath = this.CreateRoundedPath(rect, radius);

			Color from = argb0.ToColor();
			Color to = argb1.ToColor();

			this.graphics.FillPath(new LinearGradientBrush(rect, from, to, angle), roundedPath);
		}

		public void RoundedFill(uint argb, Rectangle rect, int radius) {
			GraphicsPath roundedPath = this.CreateRoundedPath(rect, radius);
			this.graphics.FillPath(new SolidBrush(argb.ToColor()), roundedPath);
		}

		public void RoundedOutline(uint argb, Rectangle rect, int radius) {
			GraphicsPath roundedPath = this.CreateRoundedPath(rect, radius);
			this.graphics.DrawPath(new Pen(argb.ToColor()), roundedPath);
		}

		public void Text(string text, Font font, uint argb, Rectangle rect) {
			StringFormat format = new StringFormat() {
				                                         Alignment = StringAlignment.Center,
				                                         LineAlignment = StringAlignment.Center
			                                         };
			this.Text(text, font, argb, rect, format);
		}

		public void Text(string text, Font font, uint argb, Rectangle rect, StringFormat format) {
			this.graphics.DrawString(
				text, font,
				new SolidBrush(argb.ToColor()),
				rect, format);
		}

		public GraphicsPath CreateRound(int x, int y, int width, int height, int slope) {
			Rectangle CreateRoundRectangle = new Rectangle(x, y, width, height);
			return CreateRound(CreateRoundRectangle, slope);
		}

		public GraphicsPath CreateRound(Rectangle r, int slope) {
			GraphicsPath CreateRoundPath = new GraphicsPath(FillMode.Winding);
			CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
			CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
			CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
			CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
			CreateRoundPath.CloseFigure();
			return CreateRoundPath;
		}

		public GraphicsPath CreateRoundedPath(Rectangle rect, int radius) {
			GraphicsPath result = new GraphicsPath();
			result.AddLine(rect.X + radius, rect.Y, rect.X + rect.Width - radius, rect.Y);
			result.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);

			result.AddLine(rect.X + rect.Width, rect.Y + radius, rect.X + rect.Width, rect.Y + rect.Height - radius);
			result.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);

			result.AddLine(rect.X + rect.Width - radius, rect.Y + rect.Height, rect.X + radius, rect.Y + rect.Height);
			result.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);

			result.AddLine(rect.X, rect.Y + rect.Height - radius, rect.X, rect.Y + radius);
			result.AddArc(rect.X, rect.Y, radius, radius, 180, 90);

			result.CloseFigure();
			return result;
		}

		#endregion
	}

	public static class RectangleExtensions {
		public static Rectangle Inflated(this Rectangle rect, int radius) {
			rect.Inflate(-radius, -radius);
			return rect;
		}

		public static Rectangle Shrinked(this Rectangle rect, int amount) {
			rect.Width -= amount;
			rect.Height -= amount;

			return rect;
		}

		public static Rectangle ShrinkedX(this Rectangle rect, int amount) {
			rect.Width -= amount;
			return rect;
		}

		public static Rectangle ShrinkedY(this Rectangle rect, int amount) {
			rect.Height -= amount;
			return rect;
		}

		public static Rectangle Offseted(this Rectangle rect, int x, int y) {
			rect.X += x;
			rect.Y += y;

			return rect;
		}
	}

	public static class UColor {
		public static uint Transparent = Color.Transparent.ToUInt();
		public static uint White = Color.White.ToUInt();
		public static uint Black = Color.Black.ToUInt();
		public static uint Blue = Color.Blue.ToUInt();
		public static uint LightBlue = Color.LightBlue.ToUInt();
		public static uint CornflowerBlue = Color.CornflowerBlue.ToUInt();
		public static uint Lime = Color.Lime.ToUInt();
		public static uint Green = Color.Green.ToUInt();
		public static uint GreenYellow = Color.GreenYellow.ToUInt();
		public static uint Yellow = Color.Yellow.ToUInt();
		public static uint Red = Color.Red.ToUInt();
		public static uint Orange = Color.Orange.ToUInt();
		public static uint Purple = Color.Purple.ToUInt();
		public static uint Cyan = Color.Cyan.ToUInt();

		public static uint Blend(byte alpha, uint baseColor) {
			return (uint) (alpha << 24) + baseColor;
		}

		public static uint Argb(byte a, byte r, byte g, byte b) {
			return (uint) ((a << 24) | (r << 16) | (g << 8) | (b << 0));
		}

		public static uint Rgb(byte r, byte g, byte b) {
			return UColor.Argb(0xFF, r, g, b);
		}

		#region Extensions

		public static Color ToColor(this uint color) {
			byte a = (byte) (color >> 24);
			byte r = (byte) (color >> 16);
			byte g = (byte) (color >> 8);
			byte b = (byte) (color >> 0);

			return Color.FromArgb(a, r, g, b);
		}

		public static uint ToUInt(this Color color) {
			return (uint) ((color.A << 24) | (color.R << 16) | (color.G << 8) | (color.B << 0));
		}

		#endregion
	}
}