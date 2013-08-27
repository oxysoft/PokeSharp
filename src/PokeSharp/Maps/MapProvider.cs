using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maps;

namespace PokeSharp.Maps {
	class MapProvider {

		private static Dictionary<Int32, Map> maps = new Dictionary<Int32, Map>();
		private static Dictionary<Int32, List<ConnectionInfo>> connectioninfos = new Dictionary<Int32, List<ConnectionInfo>>();
		static MapProvider instance;

		private MapProvider() {
		}

		public Map getMap(int mapid) {
			if (maps.ContainsKey(mapid)) {
				return maps[mapid];
			} else { //map not loaded
				Map result = new Map(PokeEngine.instance, mapid);
				maps.Add(mapid, result);
				return result;
			}
		}

		public List<ConnectionInfo> getConnections(int mapid) {
			if (connectioninfos.ContainsKey(mapid)) {
				return connectioninfos[mapid];
			}
			return null;
		}

		public void loadConnections() {
			ConnectionInfo cinfo0 = new ConnectionInfo(ConnectionDirection.LEFT, 1, 12);
			ConnectionInfo cinfo1 = new ConnectionInfo(ConnectionDirection.UP, 2, 12);
			ConnectionInfo cinfo2 = new ConnectionInfo(ConnectionDirection.RIGHT, 3, 12);
			ConnectionInfo cinfo3 = new ConnectionInfo(ConnectionDirection.DOWN, 4, 12);
			connectioninfos.Add(0, new List<ConnectionInfo>());
			connectioninfos[0].Add(cinfo0);
			connectioninfos[0].Add(cinfo1);
			connectioninfos[0].Add(cinfo2);
			connectioninfos[0].Add(cinfo3);

			cinfo0 = new ConnectionInfo(ConnectionDirection.RIGHT, 0, -12);
			connectioninfos.Add(1, new List<ConnectionInfo>());
			connectioninfos[1].Add(cinfo0);

			cinfo0 = new ConnectionInfo(ConnectionDirection.DOWN, 0, -12);
			connectioninfos.Add(2, new List<ConnectionInfo>());
			connectioninfos[2].Add(cinfo0);

			cinfo0 = new ConnectionInfo(ConnectionDirection.LEFT, 0, -12);
			connectioninfos.Add(3, new List<ConnectionInfo>());
			connectioninfos[3].Add(cinfo0);

			cinfo0 = new ConnectionInfo(ConnectionDirection.UP, 0, -12);
			connectioninfos.Add(4, new List<ConnectionInfo>());
			connectioninfos[4].Add(cinfo0);

		}

		public void purgeMaps() {
			maps.Clear();
			connectioninfos.Clear();
		}

		public static MapProvider getInstance() {
			if (instance == null) {
				instance = new MapProvider();
			}
			return instance;
		}

	}
}
