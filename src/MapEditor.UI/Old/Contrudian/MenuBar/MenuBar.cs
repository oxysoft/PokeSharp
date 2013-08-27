using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MapEditor.UI.Old.Core;
using MapEditor.UI.Old.Core.Bar.Item.Menu;

namespace MapEditor.UI.Old.Contrudian.MenuBar {
	public class MenuBar : UserControl, IMenuBar {
		[Browsable(false)] public new int Height = 51;

		[Browsable(false)]
		public override Rectangle DisplayRectangle {
			get { return new Rectangle(0, 0, this.Width, this.Height); }
		}

		private Point FirstLocation, IncrementLocation;

		public MenuBarItemCollection Items;

		public MenuBar() {
			this.Dock = DockStyle.Top;
			this.BringToFront();
			this.DoubleBuffered = true;

			this.Items = new MenuBarItemCollection(this);
			FirstLocation = new Point(DisplayRectangle.X + 10, DisplayRectangle.Y + 10);
		}

		protected override void OnPaint(PaintEventArgs e) {
			OnPaintBarBackground(e);
			Items.ForEach(item => OnPaintItem(e, item));
			Items.ForEach(item => OnPaintItemText(e, item));
			base.OnPaint(e);
		}

		public void OnPaintBarBackground(PaintEventArgs e) {
			GraphicsHelper graphics = new GraphicsHelper(e.Graphics);
			const int radius = 7;
			const int blend = 245;
			Rectangle bound = new Rectangle(DisplayRectangle.X + 1, DisplayRectangle.Y, Width - 3, Height - 2);
			graphics.RoundedFill(UColor.White, bound, radius);
			graphics.RoundedGradient(UColor.Blend(blend, UColor.Rgb(60, 60, 60)), UColor.Blend(blend, UColor.Rgb(38, 38, 38)), bound, 90, radius);
			graphics.RoundedOutline(UColor.Black, new Rectangle(bound.X + 1, bound.Y + 1, bound.Width - 1, bound.Height - 1), radius);
			graphics.Line(UColor.Blend(50, UColor.White), radius, 0, Width - radius, 0);
		}

		public void OnPaintItem(PaintEventArgs e, MenuBarItem item) {
			GraphicsHelper helper = new GraphicsHelper(e.Graphics);
			const int radius = 3;
			Rectangle bound = item.Bound;
			helper.RoundedGradient(UColor.Rgb(0x4d, 0x9f, 0xcf), UColor.Rgb(0x15, 0x69, 0x97), item.Bound, 90, radius);
			helper.Gradient(UColor.Blend(130, UColor.White), UColor.Blend(70, UColor.White), new Rectangle(item.Bound.X, item.Bound.Y + 1, 1, item.Bound.Height - radius), 90);
			helper.Gradient(UColor.Blend(130, UColor.White), UColor.Blend(70, UColor.White), new Rectangle(item.Bound.X + item.Bound.Width - radius + 2, item.Bound.Y + 1, 1, item.Bound.Height - radius), 90);
			helper.RoundedOutline(UColor.Rgb(0x18, 0x18, 0x18), item.Bound, radius);
			helper.Line(UColor.White, bound.X + radius, bound.Y + bound.Height - 1, bound.Width - radius, bound.Y + bound.Height-1);
		}

		public void OnPaintItemText(PaintEventArgs e, MenuBarItem item) {
		}

		public Point GetNextItemLocation(MenuBarItem item) {
			int width = Items.Sum(it => it.Width);

			return new Point(FirstLocation.X + width, FirstLocation.Y);
		}

		public new void Invalidate() {
			base.Invalidate();
		}
	}
}