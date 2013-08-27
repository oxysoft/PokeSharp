using System;
using System.Collections.Generic;
using GameEngine.Data.Tiles.Behaviors;
using General.Common;
using General.Encoding;
using General.Graphics;

namespace GameEngine.Data.Tiles {
	public class Tileset : IEncodable, ICloneable {

		public string Name;
		public int ID;
		public List<Tile> Tiles;
		public TileableTexture Texture;

		public Tileset() {
			Tiles = new List<Tile>();
		}

		public Tileset(TilesetFactory factory) : this() {
			this.ID = factory.AllocateID();
		}

		public Tileset(string name, TilesetFactory factory)
			: this() {
			this.ID = factory.AllocateID();
			this.Name = name;
		}

		public void GenerateTiles() {
			int mi = Texture.MaxIndex;

			for (int i = 0; i < mi; i++) {
				Tile t = new Tile();
				t.spriteindex = i;
				Tiles.Add(t);
				t.DefaultBehavior = new MockupTileBehavior(TileBehavior.Height2);
			}
		}

		public void Update(Microsoft.Xna.Framework.GameTime time) {
			Tiles.ForEach(tile => tile.Update(time));
		}


		public object Clone() {
			Tileset tileset = new Tileset();
			Tile[] tiles = this.Tiles.ToArray();

			tileset.Tiles.AddRange(tiles);
			tileset.Name = (string)this.Name.Clone();
			tileset.Texture = (TileableTexture)this.Texture.Clone();

			return tileset;
		}

		public void Encode(BinaryOutput stream) {
			stream.Write(Name);
			stream.Write(Tiles.Count);

			foreach (Tile tile in Tiles) {
				stream.Write(tile);
			}
			stream.Write(Texture);
		}

		public IEncodable Decode(BinaryInput stream) {
			this.Name = stream.ReadString();
			int tilesCount = stream.ReadInt32();

			for (int i = 0; i < tilesCount; i++) {
				Tiles.Add(stream.ReadObject<Tile>());
			}

			this.Texture = stream.ReadObject<TileableTexture>();

			return this;
		}
	}
}
