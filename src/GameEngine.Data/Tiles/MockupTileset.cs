using GameEngine.Data.Common;
using General.Common;

namespace GameEngine.Data.Tiles {
	public class MockupTileset : IEncodable {

		public World world;
		public int tilesheetindex;

		public MockupTileset() {
		}

		public MockupTileset(World world, int tilesheetindex) {
			this.world = world;
			this.tilesheetindex = tilesheetindex;
		}

		public Tileset Tileset {
			get {
				return world.TilesetContainer[tilesheetindex];
			}
		}

		public int GetLength() {
			return sizeof(int);
		}

		public void Encode(General.Encoding.BinaryOutput stream) {
			stream.Write(tilesheetindex);
		}

		public IEncodable Decode(General.Encoding.BinaryInput stream) {
			tilesheetindex = stream.ReadInt32();
			return this;
		}
	}
}
