using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor.UI.Core.Common.Controls {
	public class NFTreeView : System.Windows.Forms.TreeView {
		public NFTreeView() {
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		}
	}
}
