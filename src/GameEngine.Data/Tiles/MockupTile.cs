using GameEngine.Data.Common;
using General.Common;

namespace GameEngine.Data.Tiles {
	public class MockupTile : IEncodable {

		public Map map;
		public int tileIndex;
		public int tilesetIndex;

		public const int width = 16; //x^2 only

		public MockupTile() {
		}

		public MockupTile(Map map, int tileIndex, int tilesetIndex) {
			this.map = map;
			this.tileIndex = tileIndex;
			this.tilesetIndex = tilesetIndex;
		}

		public Tileset Tileset {
			get {
				return map.Tilesets[tilesetIndex].Tileset;
			}
		}

		public Tile Tile {
			get {
				if (this.tileIndex > -1 && this.tileIndex <= Tileset.Tiles.Count) {
					return Tileset.Tiles[tileIndex];
				}
				return null;
			}
		}

		public void Update(Microsoft.Xna.Framework.GameTime time) {
		}



		public void Encode(General.Encoding.BinaryOutput stream) {
			stream.Write(tileIndex);
			stream.Write(tilesetIndex);
		}

		public IEncodable Decode(General.Encoding.BinaryInput stream) {
			this.tileIndex = stream.ReadInt32();
			this.tilesetIndex = stream.ReadInt32();
			return this;
		}
	}
}
