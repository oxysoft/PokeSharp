using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeSharp.PokeUtil {
	class Triple<L, M, R> {

		public L left {
			get;
			set;
		}

		public M mid {
			get;
			set;
		}

		public R right {
			get;
			set;
		}

		public Triple(L left, M mid, R right) {
			this.left = left;
			this.mid = mid;
			this.right = right;
		}

	}
}
