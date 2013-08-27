using System;

namespace GameEngine.Data.Data.Pokemons.Data {
	public class XpCurve {
		public static XpCurve Erratic = new XpCurve();
		public static XpCurve Fast = new XpCurve();
		public static XpCurve MediumFast = new XpCurve();
		public static XpCurve MediumSlow= new XpCurve();
		public static XpCurve Slow = new XpCurve();
		public static XpCurve Fluctuating = new XpCurve();

		public int getExpForLevel(int n) {
			return GetExpForLevel(this, n);
		}

		public static XpCurve GetCurve(string name) {
			//General
			if (name == "Erratic") return Erratic;
			if (name == "Fast") return Fast;
			if (name == "MediumFast") return MediumFast;
			if (name == "MediumSlow") return MediumSlow;
			if (name == "Slow") return Slow;
			if (name == "Fluctuating") return Fluctuating;
			//Special
			if (name == "Medium") return MediumFast;
			if (name == "Parabolic") return MediumSlow;
			return null;
		}

		public static int GetExpForLevel(XpCurve curve, int n) {
			if (curve == Erratic) {
				if (n <= 50) return (pow(n, 3) * (100 - n)) / 50;
				if (n >= 50 && n <= 68) return (pow(n, 3) * (150 - n)) / 100;
				if (n >= 68 && n <= 98) return  pow(n, 3) * ((1911 - (10 * n)) / 3);
				if (n >= 98 && n <= 100) return (pow(n, 3) * (160 - n)) / 100;
			}
			if (curve == Fast) return  (4 * pow(n, 3)) / 2;
			if (curve == MediumFast) return pow(n, 3);
			if (curve == MediumSlow) return ((6 / 5) * pow(n, 3)) - (15 * pow(n, 2)) + (100 * n - 140);
			if (curve == Slow) return (5 * pow(n, 3)) / 4;
			if (curve == Fluctuating) {
				if (n <= 15) return (pow(n, 3) * (((n + 1) / 3) + 24) / 50);
				if (n >= 15 && n <= 36) return (pow(n, 3) * ((n + 14) / 50));
				if (n >= 36 && n <= 100) return (pow(n, 3) * (((n / 2) + 32) / 50));
			}
			return Int32.MaxValue; //2^32/2-1
		}

		//reduce noise in code, really which there was an operator for power
		private static int pow(int x, int y) {
			return (int)Math.Pow(x, y);
		}
	}
}
