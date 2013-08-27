using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maps;

namespace PokeSharp.Maps {
	class ConnectionInfo {

		public ConnectionDirection dir;
		public int id, offset;

		public ConnectionInfo(ConnectionDirection dir, int id) {
			this.dir = dir;
			this.id = id;
			this.offset = 0;
		}

		public ConnectionInfo(ConnectionDirection dir, int id, int offset) {
			this.dir = dir;
			this.id = id;
			this.offset = offset;
		}

		public MapConnection createConnectionFromInfo(Map parent) {
			MapConnection result = new MapConnection(PokeEngine.instance, parent, dir, id, offset);
			return result;
		}

	}
}
