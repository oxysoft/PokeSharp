using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Utilities;

namespace GameEngine.Data.Entities.Living.Npcs {
	public enum MovementFrequency {
		Always, //0
		Often, //
		Frequently,
		Normally,
		Occasionally,
		Hardly,
		Rarely,
		Never,
		Custom
	}

	public static class MovementFrequencyExtensions {
		public static float NextMovement(this MovementFrequency freq) {
			switch (freq) {
				case MovementFrequency.Always:
					return 0;
				case MovementFrequency.Often:
					return Randomizer.Next(100, 250);
				case MovementFrequency.Frequently:
					return Randomizer.Next(250, 500);
				case MovementFrequency.Normally: //More realistic (sometime faster, sometime slower)
					return Randomizer.Next(300, 650) - (Randomizer.NextBool() ? Randomizer.Next(75, 125) : 0);
				case MovementFrequency.Occasionally:
					return Randomizer.Next(400, 800);
				case MovementFrequency.Hardly:
					return Randomizer.Next(600, 1000);
				case MovementFrequency.Rarely:
					return Randomizer.Next(1000, 1400);
				case MovementFrequency.Never:
					return Single.MaxValue;
			}

			return 0f;
		}
	}
}