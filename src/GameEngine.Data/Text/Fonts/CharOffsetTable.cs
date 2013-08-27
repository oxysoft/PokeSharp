using System;
using System.Collections.Generic;

namespace GameEngine.Data.Text.Fonts {
	public class CharOffsetTable {
		public static List<List<Tuple<char, int, int>>> Offsets = new List<List<Tuple<Char, Int32, Int32>>>();

		public static void Initialize() {
			List<Tuple<Char, Int32, Int32>> Font0 = new List<Tuple<Char, Int32, Int32>>();
			Font0.Add(new Tuple<Char, Int32, Int32>('p', 0, 2));
			Font0.Add(new Tuple<Char, Int32, Int32>('g', 0, 2));
			Font0.Add(new Tuple<Char, Int32, Int32>('y', 0, 2));
			Font0.Add(new Tuple<Char, Int32, Int32>('Q', 0, 1));
			Font0.Add(new Tuple<Char, Int32, Int32>('q', 0, 2));
			Font0.Add(new Tuple<Char, Int32, Int32>('Ç', 0, 2));
			Font0.Add(new Tuple<Char, Int32, Int32>('ç', 0, 2));
			Font0.Add(new Tuple<Char, Int32, Int32>('\'', 0, -4));
			Font0.Add(new Tuple<Char, Int32, Int32>('*', 0, -3));
			Font0.Add(new Tuple<Char, Int32, Int32>('~', 0, -2));
			Font0.Add(new Tuple<Char, Int32, Int32>('=', 0, -2));
			Font0.Add(new Tuple<Char, Int32, Int32>('-', 0, -2));
			Font0.Add(new Tuple<Char, Int32, Int32>('×', 0, -2));
			Font0.Add(new Tuple<Char, Int32, Int32>('ß', 0, -1));
			Font0.Add(new Tuple<Char, Int32, Int32>('“', 0, -5));
			Font0.Add(new Tuple<Char, Int32, Int32>('”', 0, -6));

			List<Tuple<Char, Int32, Int32>> Font2 = new List<Tuple<Char, Int32, Int32>>();
			Font2.Add(new Tuple<Char, Int32, Int32>('g', 0, 2));
			Font2.Add(new Tuple<Char, Int32, Int32>('Q', 0, 1));
			Font2.Add(new Tuple<Char, Int32, Int32>('j', 0, 1));
			Font2.Add(new Tuple<Char, Int32, Int32>('p', 0, 2));
			Font2.Add(new Tuple<Char, Int32, Int32>('q', 0, 2));
			Font2.Add(new Tuple<Char, Int32, Int32>('y', 0, 2));
			Font2.Add(new Tuple<Char, Int32, Int32>('Ç', 0, 2));
			Font2.Add(new Tuple<Char, Int32, Int32>('ç', 0, 2));
			Font2.Add(new Tuple<Char, Int32, Int32>('-', 0, -2));
			Font2.Add(new Tuple<Char, Int32, Int32>('×', 0, -2));
			Font2.Add(new Tuple<Char, Int32, Int32>('ß', 0, 1));
			Font2.Add(new Tuple<Char, Int32, Int32>('*', 0, -3));
			Font2.Add(new Tuple<Char, Int32, Int32>('~', 0, -2));
			Font2.Add(new Tuple<Char, Int32, Int32>('=', 0, -2));

			Offsets.Add(Font0);
			Offsets.Add(Font0); //use same table as it's the same font except the colors are modified
			Offsets.Add(Font2);
		}
	}
}