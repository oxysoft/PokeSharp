using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.Common {
	public static class ThreadInvoker {
		#region Constructors
		static ThreadInvoker() {
			ThreadInvoker.lazyInitalize();
		}
		#endregion

		#region Fields
		private static Control invokerControl;
		#endregion

		#region Methods
		private static void lazyInitalize() {
			if (invokerControl == null) {
				invokerControl = new Control();
				invokerControl.CreateControl();
			}
		}
		public static void Invoke(Action action) {
			invokerControl.Invoke(action);
		}
		#endregion
	}
}
