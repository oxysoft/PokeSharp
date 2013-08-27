using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Editor.Selections;
using GameEngine.Data.Entities;
using GameEngine.Data.Entities.Collision;
using GameEngine.Data.Entities.Core;
using GameEngine.Data.Entities.Living;
using GameEngine.Data.Entities.Types;
using GameEngine.Data.Entities.World;
using GameEngine.Data.Tiles;
using GameEngine.Data.Tiles.Behaviors;
using General.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using General.Extensions;

namespace GameEngine.Data.Common {
	public class Map : IEncodable, ICollisionHandler {
		public const int LayerCount = 16;
		public int Width, Height;
		public string Name, Author;
		public MockupTile[][][] Tiles;
		public MockupTileBehavior[,] Behaviors;
		public List<MapEntity> Entities;
		public List<MockupTileset> Tilesets;
		public World World;

		public Rectangle Bounds {
			get {
				return new Rectangle(
					0, 0, Width << 4, Height << 4);
			}
		}

		public WorldEntityFactory Factory {
			get { return World.EntityFactory; }
		}

		public Map() {
			Tilesets = new List<MockupTileset>();
			Entities = new List<MapEntity>();

			//this.Behaviors = new MockupTileBehavior[Width,Height];
			//for (int i = 0; i < Width; i++) {
			//	for (int j = 0; j < Height; j++) {
			//		Behaviors[i, j] = new MockupTileBehavior(TileBehavior.Height2.Id);
			//	}
			//}

			Name = "";
			Author = "";
		}

		public Map(IRegionEntityFactory factory)
			: this() {
			this.World = factory.World;
		}

		public Map(IRegionEntityFactory factory, string name, string author, int width, int height)
			: this(factory) {
			this.Width = width;
			this.Height = height;

			Initialize(name, author, factory);
		}

		private void Initialize(string name, string author, IRegionEntityFactory factory) {
			this.Name = name ?? "MAP_NO_NAME";
			this.Author = author ?? "Anonymous";

			this.Behaviors = new MockupTileBehavior[Width,Height];
			for (int i = 0; i < Width; i++) {
				for (int j = 0; j < Height; j++) {
					Behaviors[i, j] = new MockupTileBehavior(TileBehavior.Height2.Id);
				}
			}

			Fill(-1, 0);
		}

		public void Fill(int spriteindex, int spritesheetindex) {
			for (int z = 0; z < LayerCount; z++) {
				Fill(spriteindex, spritesheetindex, z);
			}
		}

		public void Fill(int spriteindex, int spritesheetindex, int z) {
			for (int y = 0; y < Height; y++) {
				for (int x = 0; x < Width; x++) {
					Tiles[x][y][z] = new MockupTile(this, spriteindex, spritesheetindex);
				}
			}
		}

		public void AddEntity(MapEntity e) {
			e.Map = this;
			Entities.Add(e);
		}

		public void Update(Microsoft.Xna.Framework.GameTime time) {
			for (int i = 0; i < Entities.Count; i++) {
				MapEntity e = Entities[i];
				e.Update(time);
			}
		}

		public void Draw(GameTime time) {
			if (World != null) {
				SpriteBatch sbatch = World.ViewData.SpriteBatch;

				Vector2 origin = Vector2.Zero;
				if (World.Player != null) origin = (World.Player.Position / 16);
				const int radius = 9;

				int xs = World.Player != null ? ((int) origin.X - radius) : Int32.MinValue;
				int ys = World.Player != null ? ((int) origin.Y - radius) : Int32.MinValue;
				int tpx = World.Player != null ? ((int) origin.X + radius) : Int32.MaxValue;
				int tpy = World.Player != null ? ((int) origin.Y + radius) : Int32.MaxValue;

				if (xs < 0) xs = 0;
				if (ys < 0) ys = 0;
				if (tpx > this.Width) tpx = Width;
				if (tpy > this.Height) tpy = Width;

				for (int x = xs; x < tpx; x++) {
					for (int y = ys; y < tpy; y++) {
						for (int z = 0; z < LayerCount; z++) {
							MockupTile mt = GetTile(x, y, z);
							if (mt != null) {
								if (mt.Tile != null) {
									Tileset t = GetTile(x, y, z).Tileset;
									Vector2 pos = new Vector2(x, y);

									Rectangle srcRect = t.Texture.GetSource(mt.Tile.spriteindex);
									Rectangle target = new Rectangle((int) (x * 16 * World.Camera.Scale), (int) (y * 16 * World.Camera.Scale), (int) (16 * World.Camera.Scale), (int) (16 * World.Camera.Scale)).Add(World.Camera.Location);

									sbatch.Draw(t.Texture.Texture, target, srcRect, Color.White);
								}
							}
						}
					}
				}

				List<MapEntity> entitiesToRender = new List<MapEntity>();
				entitiesToRender.AddRange(Entities);

				int renderedEntities = entitiesToRender.Count;
				entitiesToRender.Sort(delegate(MapEntity a, MapEntity b) {
					float positionA = a.Position.Y + a.Template.Texture.FrameHeight;
					float positionB = b.Position.Y + b.Template.Texture.FrameHeight;

					if (a.TopMost && !b.TopMost) return 1;
					if (!a.TopMost && b.TopMost) return -1;

					if (positionA > positionB) return 1;
					if (positionA < positionB) return -1;

					if (positionA == positionB) {
						if (a.Position.X > b.Position.X) return -1;
						if (a.Position.X < b.Position.X) return 1;
					}

					return 0;
				});

				sbatch.End();

				foreach (MapEntity entity in entitiesToRender) {
					entity.BeginDraw(time);
					entity.Draw(time);
					entity.EndDraw(time);
				}

				sbatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise);
			}
		}

		public MockupTile GetTile(int x, int y, int z) {
			if (x < 0 || y < 0 || x >= Width || y >= Height) return null;
			return Tiles[x][y][z];
		}

		public MockupTileBehavior GetBehavior(int x, int y) {
			if (x < 0 || y < 0 || x >= Width || y >= Height) return new MockupTileBehavior(TileBehavior.Height2);
			return Behaviors[x, y];
		}

		public bool HasEntity(int x, int y) {
			return GetEntity(x, y) != null;
		}

		public MapEntity GetEntity(int x, int y) {
			return (from e in this.Entities let bound = new Rectangle((int) e.Position.X, (int) e.Position.Y, e.Width, e.Height) where bound.Contains(new Point(x, y)) select e).FirstOrDefault();
		}

		public bool Walkable(int x, int y, Entity requestingEntity) {
			bool tileWalkable = false;

			if (x < 0 || y < 0 || x >= Width || y >= Height) {
				return true;
			}
			for (int i = Map.LayerCount - 1; i >= 0; i--) {
				if (Tiles[x][y][i].tileIndex >= 0) {
					//tileWalkable = this.map.Tiles[x, y, i].Tile.Walkable;
					tileWalkable = true;
					break;
				}
			}
			if (!tileWalkable) {
				return false;
			}

			IEnumerable<Entity> collidingEntities = this.GetCollidingEntities(x, y, requestingEntity);

			if (collidingEntities.FirstOrDefault() != null) {
				return false;
			}

			return true;
		}

		public IEnumerable<Entity> GetCollidingEntities(int x, int y, Entity requestingEntity) {
			MapEntity requester = requestingEntity as MapEntity;
			Vector2 pos = new Vector2(x, y);

			foreach (MapEntity e in Entities) {
				if (!e.Visible) continue;
				if (!e.Collidable && !requester.Collidable) continue;
				if (e is LivingEntity) { //Different handling
					if (pos.Equals(e.TilePosition))
						yield return e;
					else
						continue;
				}
				if (e.Template.CollisionMap.Count == 0) continue;

				Vector2 center = new Vector2(e.Template.Texture.Columns / 2,
				                             e.Template.Texture.Rows / 2);
				foreach (Rectangle rect in e.Template.CollisionMap) {
					Rectangle n = new Rectangle(((int) e.Position.X >> 4) + 1, ((int) e.Position.Y >> 4) + 1, rect.Width, rect.Height);
					if (n.Contains(x, y)) {
						yield return e;
					}
				}
			}
		}

		public void Encode(General.Encoding.BinaryOutput stream) {
			stream.Write(Name);
			stream.Write(Author);
			stream.Write(Width);
			stream.Write(Height);
			stream.Write(Tilesets.Count);
			Tilesets.ForEach(stream.Write);

			for (int x = 0; x < Width; x++) {
				for (int y = 0; y < Height; y++) {
					for (int z = 0; z < LayerCount; z++) {
						stream.Write(Tiles[x][y][z]);
					}
				}
			}
			stream.Write(Entities.Count);
			Entities.ForEach(e => stream.Write(e.Template));
		}

		public IEncodable Decode(General.Encoding.BinaryInput stream) {
			Name = stream.ReadString();
			Author = stream.ReadString();
			Width = stream.ReadInt32();
			Height = stream.ReadInt32();
			int c1 = stream.ReadInt32();
			for (int i = 0; i < c1; i++) {
				Tilesets.Add(stream.ReadObject<MockupTileset>());
			}

			/*Initialize Tiles jagged multidimensional array*/
			this.Tiles = new MockupTile[Width][][];
			for (int i = 0; i < Width; i++) {
				Tiles[i] = new MockupTile[Height][];
				for (int j = 0; j < Height; j++) {
					Tiles[i][j] = new MockupTile[Map.LayerCount];
				}
			}

			for (int x = 0; x < Width; x++) {
				for (int y = 0; y < Height; y++) {
					for (int z = 0; z < LayerCount; z++) {
						Tiles[x][y][z] = stream.ReadObject<MockupTile>();
					}
				}
			}
			int c2 = stream.ReadInt32();
			for (int i = 0; i < c2; i++) {
				EntityTemplate e = stream.ReadObject<EntityTemplate>();
				Entities.Add(e.CreateEntity(World.EntityFactory));
			}
			return this;
		}
	}
}