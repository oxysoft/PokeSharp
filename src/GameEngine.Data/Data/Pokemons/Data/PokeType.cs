using System;
using System.Collections.Generic;

namespace GameEngine.Data.Data.Pokemons.Data {
	public class PokeType {

		int id;
		public static List<PokeType> types = new List<PokeType>();

		public static PokeType Normal = new PokeType("Normal", 0);
		public static PokeType Grass = new PokeType("Grass", 1);
		public static PokeType Fire = new PokeType("Fire", 2);
		public static PokeType Water = new PokeType("Water", 3);
		public static PokeType Flying = new PokeType("Flying", 4);
		public static PokeType Electric = new PokeType("Electric", 5);
		public static PokeType Ice = new PokeType("Ice", 6);
		public static PokeType Fighting = new PokeType("Fighting", 7);
		public static PokeType Poison = new PokeType("Poison", 8);
		public static PokeType Ground = new PokeType("Ground", 9);
		public static PokeType Steel = new PokeType("Steel", 10);
		public static PokeType Psychic = new PokeType("Psychic", 11);
		public static PokeType Bug = new PokeType("Bug", 12);
		public static PokeType Rock = new PokeType("Rock", 13);
		public static PokeType Dark = new PokeType("Dark", 14);
		public static PokeType Ghost = new PokeType("Ghost", 15);
		public static PokeType Dragon = new PokeType("Dragon", 16);

		private PokeType(string name, int id) {
			this.id = id;
		}

		static PokeType() {
			types.Add(Normal);
			types.Add(Grass);
			types.Add(Fire);
			types.Add(Water);
			types.Add(Flying);
			types.Add(Electric);
			types.Add(Ice);
			types.Add(Fighting);
			types.Add(Poison);
			types.Add(Ground);
			types.Add(Steel);
			types.Add(Psychic);
			types.Add(Bug);
			types.Add(Rock);
			types.Add(Dark);
			types.Add(Ghost);
			types.Add(Dragon);
		}

		public static PokeType getTypeFromString(String type) {
			//return valueOf(type);
			return null;
		}

		public static float getEffectivityMultiplier(PokeType from, PokemonInfo victim) {
			PokeType[] types = new PokeType[2];
			if (victim == null) Console.WriteLine("victim null");
			types[0] = victim.type1;
			types[1] = victim.type2;
			float delta = 1;
			foreach (PokeType t in types) {
				if (t != null) {
					if (t == Normal) {
						if (from == Fighting) delta++;
						if (from == Ghost) return 0;
					}
					if (t == Grass) {
						if (from == Fire || from == Poison || from == Bug || from == Flying || from == Ice) delta++;
						if (from == Ground || from == Water || from == Electric || from == Grass) delta -= 0.5f;
					}
					if (t == Fire) {
						if (from == Ground || from == Rock || from == Water) delta++;
						if (from == Fire || from == Steel || from == Grass || from == Bug || from == Ice) delta -= 0.5f;
					}
					if (t == Water) {
						if (from == Grass || from == Electric) delta++;
						if (from == Water || from == Steel || from == Fire || from == Ice) delta -= 0.5f;
					}
					if (t == Flying) {
						if (from == Ice || from == Electric || from == Rock) delta++;
						if (from == Fighting || from == Bug || from == Grass) delta -= 0.5f;
						if (from == Ground) return 0;
					}
					if (t == Electric) {
						if (from == Ground) delta++;
						if (from == Flying || from == Steel || from == Electric) delta -= 0.5f;
					}
					if (t == Ice) {
						if (from == Fighting || from == Fire || from == Steel || from == Rock) delta++;
						if (from == Ice) delta -= 0.5f;
					}
					if (t == Fighting) {
						if (from == Flying || from == Psychic) delta++;
						if (from == Rock || from == Bug || from == Dark) delta -= 0.5f;
					}
					if (t == Poison) {
						if (from == Psychic || from == Ground) delta++;
						if (from == Poison || from == Grass || from == Bug || from == Fighting) delta -= 0.5f;
					}
					if (t == Ground) {
						if (from == Grass || from == Water || from == Ice) delta++;
						if (from == Poison || from == Rock) delta -= 0.5f;
					}
					if (t == Steel) {
						if (from == Fire || from == Fighting || from == Ground) delta++;
						if (from == Steel || from == Normal || from == Flying || from == Rock || from == Bug || from == Ghost || from == Dark || from == Grass || from == Electric || from == Psychic || from == Ice || from == Dragon) delta -= 0.5f;
						if (from == Poison) return 0;
					}
					if (t == Psychic) {
						if (from == Bug) delta++;
						if (from == Psychic || from == Fighting) delta -= 0.5f;
						if (from == Ghost) return 0;
					}
					if (t == Bug) {
						if (from == Fire || from == Flying || from == Rock || from == Poison) delta++;
						if (from == Bug || from == Grass || from == Ground) delta -= 0.5f;
					}
					if (t == Rock) {
						if (from == Ground || from == Grass || from == Water || from == Fighting) delta++;
						if (from == Rock || from == Flying || from == Poison || from == Fire) delta -= 0.5f;
					}
					if (t == Dark) {
						if (from == Fighting || from == Bug) delta++;
						if (from == Ghost || from == Dark) delta -= 0.5f;
						if (from == Psychic) return 0;
					}
					if (t == Ghost) {
						if (from == Ghost || from == Dark) delta++;
						if (from == Poison || from == Bug) delta -= 0.5f;
						if (from == Normal || from == Fighting) return 0;

					} if (t == Dragon) {
						if (from == Dragon || from == Ice) delta++;
						if (from == Fire || from == Grass || from == Water || from == Electric) delta -= 0.5f;
					}
				}
			}
			return delta;

		}
	}
}