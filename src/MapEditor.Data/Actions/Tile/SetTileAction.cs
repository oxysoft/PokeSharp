using System;
using GameEngine.Data.Common;
using GameEngine.Data.Tiles;
using GameEngine.Data.Tiles.Behaviors;
using General.Common;

namespace MapEditor.Data.Actions.Tile {
	public class SetTileAction : IAction, IEncodable {
		public int X, Y, Z;
		public int TilesetIndex, TileIndex;
		private int oldtilesetIndex, oldtileIndex, oldTileBehavior;
		private Map map;

		public SetTileAction() {
			this.map = EditorEngine.Instance.CurrentMap;
		}

		public SetTileAction(int x, int y, int z, int tilesetIndex, int tileIndex) {
			this.map = EditorEngine.Instance.CurrentMap;
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.TileIndex = tileIndex;
			this.TilesetIndex = tilesetIndex;
		}

		public string Name {
			get { return "Tile Set"; }
		}

		public DateTime Time { get; set; }

		public void Execute() {
			MockupTile t = map.GetTile(X, Y, Z);

			if (t != null) {
				oldtilesetIndex = t.tilesetIndex;
				oldtileIndex = t.tileIndex;

				t.tilesetIndex = TilesetIndex;
				t.tileIndex = TileIndex;
			}
		}

		public void UnExecute() {
			if (X > 0 && X < map.Width && Y > 0 && Y < map.Height) {
				map.GetTile(X, Y, EditorEngine.Instance.SelectedLayer).tilesetIndex = oldtilesetIndex;
				map.GetTile(X, Y, EditorEngine.Instance.SelectedLayer).tileIndex = oldtileIndex;
			}
		}

		public void Encode(General.Encoding.BinaryOutput stream) {
			stream.Write(X);
			stream.Write(Y);
			stream.Write(Z);

			stream.Write(TilesetIndex);
			stream.Write(TileIndex);

			stream.Write(oldtilesetIndex);
			stream.Write(oldtileIndex);
		}

		public IEncodable Decode(General.Encoding.BinaryInput stream) {
			this.X = stream.ReadInt32();
			this.Y = stream.ReadInt32();
			this.Z = stream.ReadInt32();

			this.TilesetIndex = stream.ReadInt32();
			this.TileIndex = stream.ReadInt32();

			this.oldtilesetIndex = stream.ReadInt32();
			this.oldtileIndex = stream.ReadInt32();

			return this;
		}
	}
}