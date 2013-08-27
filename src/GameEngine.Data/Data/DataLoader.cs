using GameEngine.Data.Data.Pokemons.Data;

namespace GameEngine.Data.Data {
	public class DataLoader {
		public static void Initialize() {
			PokemonInfoManager.Instance.LoadFromIni();
		}

	}
}
