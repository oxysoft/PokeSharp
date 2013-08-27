using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.UI.Core.Transitions {
	public class ManagedType_Byte :IManagedType {
		#region IManagedType Members

		/// <summary>
		/// Returns the type we are managing.
		/// </summary>
		public Type getManagedType() {
			return typeof (byte);
		}

		/// <summary>
		/// Returns a copy of the byte passed in.
		/// </summary>
		public object copy(object o) {
			byte value = (byte) o;
			return value;
		}

		/// <summary>
		/// Returns the value between the start and end for the percentage passed in.
		/// </summary>
		public object getIntermediateValue(object start, object end, double dPercentage) {
			byte iStart = (byte) start;
			byte iEnd = (byte) end;
			return Utility.interpolate(iStart, iEnd, dPercentage);
		}

		#endregion
	}
}