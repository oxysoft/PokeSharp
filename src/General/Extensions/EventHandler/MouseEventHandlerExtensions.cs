using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using General.Common;

namespace General.Extensions {
	public static class MouseEventHandlerExtensions {
		public static void SafeInvoke(this MouseEventHandler handler, object sender, MouseEventArgs args) {
			if (handler != null) {
				ThreadInvoker.Invoke(() => handler.Invoke(sender, args));
			}
		}
	}
}
