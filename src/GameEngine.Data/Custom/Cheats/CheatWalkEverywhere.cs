using System;

namespace GameEngine.Data.Custom.Cheats {
	public class CheatWalkEverywhere : Cheat {
		public override void OnEnable() {
			throw new NotImplementedException();
		}

		public override void OnDisable() {
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates a new walk everywhere cheat.
		/// </summary>
		public static CheatWalkEverywhere Create() {
			return new CheatWalkEverywhere();
		}
	}
}
