using System.Collections.Generic;
using General.Common;
using General.Encoding;

namespace GameEngine.Data.Tiles {
	public class TilesetContainer : List<Tileset>, IEncodable {
		public Tileset GetTileset(int id) {
			return this[id];
		}

		public void Update(Microsoft.Xna.Framework.GameTime time) {
			this.ForEach(sheet => sheet.Update(time));
		}

		public void Encode(BinaryOutput stream) {
			stream.Write(this.Count);
			foreach (Tileset sheet in this) {
				stream.Write(sheet);
			}
		}

		public IEncodable Decode(BinaryInput stream) {
			int tilesetCount = stream.ReadInt32();
			for (int i = 0; i < tilesetCount; i++) {
				this.Add(stream.ReadObject<Tileset>());
			}
			return this;
		}
	}
}