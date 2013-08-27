using System;
using System.Collections.Generic;
using System.Globalization;
using General.Common;
using General.IniParser;
using General.IniParser.Model;

namespace GameEngine.Data.Data.Pokemons.Data {
	public class PokemonInfoManager {

		List<PokemonInfo> infos;

		public static PokemonInfoManager Instance {
			get {
				return Static<PokemonInfoManager>.Value;
			}
		}

		public PokemonInfoManager() {
			infos = new List<PokemonInfo>();
		}

		public PokemonInfo getInfo(int num) {
			foreach (PokemonInfo info in infos) {
				if (info.nationaldevnum == num) return info;
			}
			return null;
		}

		public void LoadFromIni() {
			string loc = Environment.CurrentDirectory + "\\Datas\\pokemons.ini";

			FileIniDataParser parser = new FileIniDataParser();
			IniData ini = parser.LoadFile(loc);

			for (int i = 1; i <= 649; i++) {
				KeyDataCollection section = ini.Sections["" + i];
				PokemonInfo info = new PokemonInfo(i);
				info.name = iniValue(section, "Name");
				info.internalname = iniValue(section, "InternalName");
				info.type1 = PokeType.getTypeFromString(iniValue(section, "Type1"));
				info.type2 = PokeType.getTypeFromString(iniValue(section, "Type2"));

				//base stat parse
				string basestats = iniValue(section, "BaseStats");
				string[] bsspl = basestats.Split(',');
				int _i = 0;
				foreach (string _thres in bsspl) {
					int val = Int32.Parse(_thres);
					if (_i == 0) info.hp = val;
					else if (_i == 1) info.attack = val;
					else if (_i == 2) info.spattack = val;
					else if (_i == 3) info.defence = val;
					else if (_i == 4) info.spdefence = val;
					else if (_i == 5) info.speed = val;
					else {
						Console.WriteLine("what kind of fucked up shit is this");
					}
					_i++;
				}

				info.genderrate = new GenderRate(); //todo
				info.xpcurve = XpCurve.GetCurve(iniValue(section, "GrowthRate"));
				info.basexp = Int32.Parse(iniValue(section, "BaseEXP"));

				//EV stat parse
				string evyeld = iniValue(section, "BaseStats");
				string[] evspl = evyeld.Split(',');
				int j = 0;
				foreach (string _thres in evspl) {
					int val = Int32.Parse(_thres);
					if (j == 0) info.evhp = val;
					else if (j == 1) info.evattack = val;
					else if (j == 2) info.evspattack = val;
					else if (j == 3) info.evdefence = val;
					else if (j == 4) info.evspdefence = val;
					else if (j == 5) info.evspeed = val;
					else {
						Console.WriteLine("what kind of fucked up shit is this");
					}
					j++;
				}

				info.rareness = Int32.Parse(iniValue(section, "Rareness"));
				info.happiness = Int32.Parse(iniValue(section, "Happiness"));

				// --> ability here

				// --> hidden ability here

				string learnset = iniValue(section, "Moves");
				string[] learnsetspl = learnset.Split(',');
				int k = 0;
				int cint = -1;
				string cstr = "null";
				foreach (string _thres in learnsetspl) {
					int w = k % 2;
					if (w == 0) {
						cint = Int32.Parse(_thres);
					} else if (w == 1) {
						cstr = _thres;
						info.learnablemoves.Add(new Tuple<int, string>(cint, cstr));
					}

					k++;
				}

				string eggmoves = iniValue(section, "EggMoves");
				string[] eggmovesspl = eggmoves.Split(',');
				info.eggmoves.AddRange(eggmovesspl);

				// --> compatibility

				info.hatch_steps = Int32.Parse(iniValue(section, "StepsToHatch"));
				info.height = float.Parse(iniValue(section, "Height"), CultureInfo.InvariantCulture);
				info.weight = float.Parse(iniValue(section, "Weight"), CultureInfo.InvariantCulture);
				info.color = iniValue(section, "Color");
				info.habitat = iniValue(section, "Habitat");
				//regional number
				info.kind = iniValue(section, "Kind");
				info.pokedexentry = iniValue(section, "Pokedex");
				info.battler_player_y = Int32.Parse(iniValue(section, "BattlerPlayerY"));
				info.battle_enemy_y = Int32.Parse(iniValue(section, "BattlerEnemyY"));
				// --> altitude
				infos.Add(info);
			}
		}

		private static string iniValue(KeyDataCollection sec, string key) {
			return sec[key];
		}
	}
}
