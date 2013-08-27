using System.Drawing;
using MapEditor.UI.Old.Core.Bar.Item.Menu;

namespace MapEditor.UI.Old.Core {
	public interface IMenuBar {
		Point GetNextItemLocation(MenuBarItem item);
		void Invalidate();
	}
}
