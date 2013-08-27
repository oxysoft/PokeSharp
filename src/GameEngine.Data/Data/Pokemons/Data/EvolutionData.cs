using System;
using System.Collections.Generic;
using GameEngine.Data.Player;

namespace GameEngine.Data.Data.Pokemons.Data {
	public class EvolutionData {

		List<IEvolutionCondition> conditions;
		string evolveinto;

		public static List<EvolutionData> generateData(string s) {
			List<EvolutionData> result = new List<EvolutionData>();
			//Evolutions=VAPOREON,Item,WATERSTONE,JOLTEON,Item,THUNDERSTONE,FLAREON,Item,FIRESTONE,LEAFEON,Location,28,GLACEON,Location,34,ESPEON,HappinessDay,,UMBREON,HappinessNight,
			string[] spl = s.Split(',');
			int evolutions = spl.Length / 3; // - 1 because of some bullshit ',' at the end
			int i = 0;
			foreach (string c in spl) {
				if (i % 3 == 0) {
					Console.WriteLine("c: " + c);
				}
				if (i % 2 == 0) {

				} else if (i % 1 == 0) {
				
				}
				i++;
			}
			return result;
		}

	}

	interface IEvolutionCondition {
		bool validate(Pokemon p);
	}

	class levelupcondition : IEvolutionCondition {
		public bool validate(Pokemon p) {
			return false;
		}
	}

	class friendshipcondition : IEvolutionCondition {
		public bool validate(Pokemon p) {
			return false;
		}
	}

	class knownsmovecondition : IEvolutionCondition {
		public bool validate(Pokemon p) {
			return false;
		}
	}

	class trainedinareacondition : IEvolutionCondition {
		public bool validate(Pokemon p) {
			return false;
		}
	}

	class holdingitemcondition : IEvolutionCondition {
		public bool validate(Pokemon p) {
			return false;
		}
	}

	class timecondition : IEvolutionCondition {
		public bool validate(Pokemon p) {
			return false;
		}
	}

	class pokemoninpartycondition : IEvolutionCondition {
		public bool validate(Pokemon p) {
			return false;
		}
	}

	class gendercondition : IEvolutionCondition {
		public bool validate(Pokemon p) {
			return false;
		}
	}

	class evolutionarystonecondition : IEvolutionCondition {
		public bool validate(Pokemon p) {
			return false;
		}
	}

	class tradecondition : IEvolutionCondition {
		public bool validate(Pokemon p) {
			return false;
		}
	}

}
