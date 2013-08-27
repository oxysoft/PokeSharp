using System;
using System.Collections.Generic;
using GameEngine.Data.Common;
using General.Common;

namespace GameEngine.Data.Data.Pokemons.Wild {
	public class WildPokemonManager : IEncodable {

		public List<Tuple<Map, List<WildPokemonInfo>>> infos;

		public WildPokemonManager() {
			this.infos = new List<Tuple<Map, List<WildPokemonInfo>>>();
		}

		public static WildPokemonManager Instance {
			get {
				return Static<WildPokemonManager>.Value;
			}
		}

		public void addData(Map map, WildPokemonInfo info) {
			getDataInfo(map).Add(info);
		}

		public List<WildPokemonInfo> getDataInfo(Map map) {
			bool ok = false;
			List<WildPokemonInfo> result = null;
			
			foreach (Tuple<Map, List<WildPokemonInfo>> t in infos) {
				if (map == t.Item1) {
					result = t.Item2;
					ok = true;
				}
			}

			//information does not exist for this map ... yet!
			if (!ok) {
				result = new List<WildPokemonInfo>();
				infos.Add(new Tuple<Map, List<WildPokemonInfo>>(map, result));
			}

			return result;
		}

		public void Encode(General.Encoding.BinaryOutput stream) {
		}

		public IEncodable Decode(General.Encoding.BinaryInput stream) {
			return this;
		}
	}
}
