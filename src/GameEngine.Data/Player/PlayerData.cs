using System;
using GameEngine.Data.Data.Pokemons.Data;
using General.Common;

namespace GameEngine.Data.Player {
	public class PlayerData : IEncodable {
		public string Name;
		public Gender Gender;
		public Pokemon[] Party = new Pokemon[6];
		public bool[] Flags = new bool[1024];

		public void Encode(General.Encoding.BinaryOutput stream) {
			stream.Write(Name);
			stream.Write((Int32) Gender);
			
			for (int i = 0; i < Party.Length; i++) {
				if (Party[i] != null) continue;
				stream.Write(i);
				return;
			}
			foreach (Pokemon pokemon in Party) {
				pokemon.Encode(stream);
			}

			stream.Write(Flags.Length);
			for (int i = 0; i < Flags.Length; i++) {
				stream.Write(Flags[i]);
			}
		}

		public IEncodable Decode(General.Encoding.BinaryInput stream) {
			this.Name = stream.ReadString();
			this.Gender = (Gender) stream.ReadInt32();
			
			int c = stream.ReadInt32();
			for (int i = 0; i < c; i++) {
				this.Party[i] = new Pokemon();
				this.Party[i].Decode(stream);
			}

			int cc = stream.ReadInt32();
			for (int i = 0; i < cc; i++) {
				Flags[i] = stream.ReadBoolean();
			}
			return this;
		}
	}
}