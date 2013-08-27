using System.Collections.Generic;
using General.Common;

namespace GameEngine.Data.Custom.Cheats {
	public class CheatManager {
		public static CheatManager Instance {
			get { return Static<CheatManager>.Value; }
		}

		public List<Cheat> Cheats;

		public CheatManager() {
			this.Cheats = new List<Cheat>();
		}
	}
}