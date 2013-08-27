using System;
using System.Collections.Generic;
using GameEngine.Data.Common;
using GameEngine.Data.Entities;
using GameEngine.Data.Tiles;
using General.Common;
using General.Encoding;
using Microsoft.Xna.Framework;

namespace GameEngine.Data.GameLoader {
	public class MapData : IEncodable {
		public string Name, Author;
		public int Width;
		public int Height;

		public MockupTile[][][] Tiles;
		public List<Tuple<int, Vector2>> Entities;
		public List<MockupTileset> Tilesets;
		public MapData[] Connections; //0 = up, 1 = right, 2 = down, 3 = right;

		public MapData() {
			Connections = new MapData[4];
			Entities = new List<Tuple<Int32, Vector2>>();
		}

		public Map CreateMap(World world) {
			Map result = new Map(world.EntityFactory, Name, Author, Width, Height);
			result.Tilesets = this.Tilesets;
			foreach (MockupTileset tileset in result.Tilesets) {
				tileset.world = world;
			}
			result.Tiles = Tiles;

			for (int i = 0; i < result.Width; i++)
				for (int j = 0; j < result.Height; j++)
					for (int k = 0; k < Map.LayerCount; k++)
						Tiles[i][j][k].map = result;

			foreach (Tuple<Int32, Vector2> token in Entities) {
				MapEntity e = world.EntityContainer.Get(token.Item1).CreateEntity(world.EntityFactory);
				e.Position = token.Item2;
				result.Entities.Add(e);
			}
			return result;
		}

		public void Encode(BinaryOutput stream, Map map) {
			stream.Write(map.Name);
			stream.Write(map.Author);

			stream.Write(map.Width);
			stream.Write(map.Height);

			stream.Write(map.Tilesets);

			for (int i = 0; i < map.Width; i++) {
				for (int j = 0; j < map.Height; j++) {
					for (int k = 0; k < Map.LayerCount; k++) {
						map.Tiles[i][j][k].Encode(stream);
					}
				}
			}

			stream.Write(map.Entities.Count);
			foreach (MapEntity e in map.Entities) {
				stream.Write(e.TemplateID);
				stream.Write(e.Position);
			}
		}

		public void Encode(BinaryOutput stream) {
			//nothing, we need map!
		}

		public IEncodable Decode(BinaryInput stream) {
			this.Name = stream.ReadString();
			this.Author = stream.ReadString();

			this.Width = stream.ReadInt32();
			this.Height = stream.ReadInt32();

			this.Tiles = new MockupTile[Width][][];
			for (int i = 0; i < Width; i++) {
				Tiles[i] = new MockupTile[Height][];
				for (int j = 0; j < Height; j++) {
					Tiles[i][j] = new MockupTile[Map.LayerCount];
				}
			}

			int w = Width;
			int h = Height;

			this.Tilesets = stream.ReadList<MockupTileset>();

			for (int i = 0; i < w; i++) {
				for (int j = 0; j < h; j++) {
					for (int k = 0; k < Map.LayerCount; k++) {
						Tiles[i][j][k] = stream.ReadObject<MockupTile>();
					}
				}
			}

			int c = stream.ReadInt32();
			for (int i = 0; i < c; i++) {
				Tuple<Int32, Vector2> t = new Tuple<Int32, Vector2>(stream.ReadInt32(), stream.ReadVector2());
				Entities.Add(t);
			}
			return this;
		}
	}
}