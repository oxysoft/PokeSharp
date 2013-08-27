using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeSharp.PokeUtil {
	class Pair<L, R> {

		public L left {
			get;
			set;
		}

		public R right {
			get;
			set;
		}

		public Pair(L left, R right) {
			this.left = left;
			this.right = right;
		}

	}
}
