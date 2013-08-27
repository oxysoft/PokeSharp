using System.Drawing;

namespace MapEditor.UI.Old.Core.Bar.Item.Menu {
	public class MenuBarItem {
		public MenuBarItem(string text) {
			this.Text = text;
		}

		public string Text { get; set; }
		public Point Location;

		public virtual int Width {
			get { return 0; }
		}

		public virtual int Height {
			get { return 0; }
		}

		public Rectangle Bound {
			get { return new Rectangle(Location, new Size(Width, Height)); }
		}
	}
}