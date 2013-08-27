using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Common {
	public static class Static<T> where T : class, new() {

		private static Lazy<T> ret = new Lazy<T>();

		public static T Value {
			get {
				return ret.Value;
			}
		}

	}
}
