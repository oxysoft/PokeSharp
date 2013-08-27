using System;

namespace GameEngine.Data.Custom.Cheats {
	public class CheatMoreExp : Cheat {
		private float Multiplier { get; set; }

		public CheatMoreExp(float multiplier) {
			this.Multiplier = multiplier;
		}
		
		public override void OnEnable() {
			throw new NotImplementedException();
		}

		public override void OnDisable() {
			throw new NotImplementedException();
		}

		/// <summary>
		/// Return a new EXP Multiplier cheat instance
		/// </summary>
		/// <param name="multiplier">The multiplying factor</param>
		public static CheatMoreExp Create(float multiplier) {
			return new CheatMoreExp(multiplier);
		}
	}
}
