using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Data.Tiles;

namespace GameEngine.Data.Entities.Living.Core {
	public enum MovementSpeed {
		Zero,
		Walking,
		Running,
		Bicycle
	}

	public static class MovementSpeedExtensions {
		public static float GetFrequency(this MovementSpeed speed) {
			return (float)16 / (float)speed.GetSpeed();
		}
		public static int GetSpeed(this MovementSpeed speed) {
			switch (speed) {
				case MovementSpeed.Walking: return 60;
				case MovementSpeed.Running: return 90;
				case MovementSpeed.Bicycle: return 120;
			}
			return 0;
		}
	}
}
