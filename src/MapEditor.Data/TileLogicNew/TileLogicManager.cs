using System;
using System.Collections.Generic;
using System.IO;
using General.Common;

namespace MapEditor.Data.TileLogicNew {
	public class TileLogicManager {

		public List<TileLogicScript> logics = new List<TileLogicScript>();

		public TileLogicManager() {
			LoadAllLogics();
		}

		public static TileLogicManager Instance {
			get {
				return Static<TileLogicManager>.Value;
			}
		}

		public void ReloadAllLogics() {
			logics.Clear();
			LoadAllLogics();
		}

		public void LoadAllLogics() {
			string dirloc = Environment.CurrentDirectory + "\\Scripts\\Logic\\";
			DirectoryInfo info = new DirectoryInfo(dirloc);

			int index = 0;
			foreach (FileInfo f in info.GetFiles()) {
				TileLogicScript logic = new TileLogicScript(index);
				logic.Load(f.Name);
				logics.Add(logic);
				index++;
			}
		}

		public TileLogicScript getLogic(string name) {
			foreach (TileLogicScript sx in logics) {
				if (sx.name == name) return sx;
			}
			return null;
		}

		//beware, will not work correctly if a tile is used twice in two scripts!
		public TileLogicScript getLogicFromSameType(string s0, int s1) {
			foreach (TileLogicScript s in logics) {
				if (s.sameTypes.Contains(new Tuple<string, int>(s0, s1))) {
					return s;
				}
			}
			return null;
		}
	}
}
