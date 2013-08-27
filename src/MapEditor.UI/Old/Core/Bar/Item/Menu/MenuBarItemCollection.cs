using System.Collections.Generic;

namespace MapEditor.UI.Old.Core.Bar.Item.Menu {
	public class MenuBarItemCollection : List<MenuBarItem> {
		private IMenuBar bar;

		public MenuBarItemCollection(IMenuBar bar) {
			this.bar = bar;
		}

		public new void Add(MenuBarItem item) {
			item.Location = bar.GetNextItemLocation(item);
			base.Add(item);
			bar.Invalidate();
		} 

	}
}
