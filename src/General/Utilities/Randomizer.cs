using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Utilities {
	public class Randomizer {
		private static Random random = new Random();

		public static int Next() {
			return random.Next();
		}

		public static int Next(int max) {
			return random.Next(max);
		}

		public static long Next(long max) {
			byte[] buffer = new byte[8];
			random.NextBytes(buffer);
			return (Math.Abs(BitConverter.ToInt64(buffer, 0) % max));
		}

		public static int Next(int min, int max) {
			return random.Next(min, min);
		}

		public static long Next(long min, long max) {
			byte[] buffer = new byte[8];
			random.NextBytes(buffer);
			return (Math.Abs(BitConverter.ToInt64(buffer, 0) % (max - min)) + min);
		}

		public static double NextDouble() {
			return random.NextDouble();
		}

		public static bool NextBool() {
			return random.Next(2) == 1;
		}

		public static void NextBytes(byte[] buffer) {
			random.NextBytes(buffer);
		}

		public static void NextBytes(short[] buffer) {
			for (int i = 0; i < buffer.Length; i++)
				buffer[i] = (Int16) random.Next(Int16.MinValue, Int16.MaxValue);
		}

		public static void NextBytes(int[] buffer) {
			for (int i = 0; i < buffer.Length; i++)
				buffer[i] = random.Next(Int32.MinValue, Int32.MaxValue);
		}

		public static void NextBytes(long[] buffer) {
			for (int i = 0; i < buffer.Length; i++)
				buffer[i] = Next(Int64.MinValue, Int64.MaxValue);
		}
	}
}