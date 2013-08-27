namespace MapEditor.UI.Old.Core.Bar.Item.Menu {
	public class MenuBarButton : MenuBarItem {
		public override int Width {
			get { return 90; }
		}

		public override int Height {
			get { return 32; }
		}

		public MenuBarButton(string text)
			: base(text) {
		}
	}
}