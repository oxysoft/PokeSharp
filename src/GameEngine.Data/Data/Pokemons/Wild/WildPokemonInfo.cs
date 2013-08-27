using GameEngine.Data.Data.Pokemons.Data;
using GameEngine.Data.Player;
using General.Common;

namespace GameEngine.Data.Data.Pokemons.Wild {
	public class WildPokemonInfo : IEncodable {

		PokemonInfo info;
		int minlevel, maxlevel;
		int type;
		/*
		 * 0: Grass
		 * 1: Fishing rod
		 * 2: Surfing
		 * 3: Rock Smah
		 * 4: Honey Tree
		 * 5: Tree Headbutt
		 */
		float shinymodifier = 1f;
		bool legendary;
		//bool doubleBattle;

		public WildPokemonInfo(int num, int type, int minlevel, int maxlevel) {
			this.type = type;
			this.minlevel = minlevel;
			this.maxlevel = maxlevel;
			//this.info = PokemonInfoManager.GetInfo(num);
		}

		public Pokemon GeneratePokemon() {
			return null;
		}

		public void Encode(General.Encoding.BinaryOutput stream) {
		}

		public IEncodable Decode(General.Encoding.BinaryInput stream) {
			return this;
		}
	}
}
