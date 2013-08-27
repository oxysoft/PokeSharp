using System;
using System.Collections.Generic;
using GameEngine.Data.Data.Battles.Abilities;

namespace GameEngine.Data.Data.Pokemons.Data {
	public class PokemonInfo {
		public string name, internalname;
		public string color, habitat, kind, pokedexentry;
		public int hp, attack, spattack, defence, spdefence, speed;
		public int evhp, evattack, evspattack, evdefence, evspdefence, evspeed;
		public int nationaldevnum, basexp, rareness, happiness, hatch_steps;
		public float height, weight;
		public PokeType type1, type2;
		public GenderRate genderrate;
		public XpCurve xpcurve;
		public List<Ability> abilities, abilities_secret;
		public List<Tuple<int, string>> learnablemoves;
		public List<EvolutionData> evolutions;
		public List<string> eggmoves;
		public Tuple<int, int> sex_compatibility; //for lack of a more verbose Name!
		//????
		public int battler_player_y, battle_enemy_y;

		public PokemonInfo(int num) {
			this.nationaldevnum = num;
			this.abilities = new List<Ability>();
			this.abilities_secret = new List<Ability>();
			this.learnablemoves = new List<Tuple<int, string>>();
			this.evolutions = new List<EvolutionData>();
			this.eggmoves = new List<string>();
		}


	}
}
