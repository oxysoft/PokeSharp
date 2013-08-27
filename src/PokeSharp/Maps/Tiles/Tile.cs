using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maps;
using Microsoft.Xna.Framework.Graphics;

namespace PokeSharp.Maps.Tiles {

	class Tile {

		public const int WIDTH = 16; //Must be 2^x (2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 ...)

		public Map map;
		public int x, y;
		public int layer = 0;

		public Tile(Map map, int x, int y) {
			this.map = map;
			this.x = x;
			this.y = y;
		}

		public virtual void update() {
			Console.WriteLine("Attempting to TICK a defaulf Tile object... Please, fix this");
		}

		public virtual void render(PokeEngine engine, int xs, int ys) {
			Console.WriteLine("Attempting to RENDER a default Tile object... Please, fix this");
		}

	}
}
