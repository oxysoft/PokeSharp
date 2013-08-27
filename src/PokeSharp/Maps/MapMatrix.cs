using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maps;
using Microsoft.Xna.Framework.Graphics;

namespace PokeSharp.Maps {
	class MapMatrix {

		public int w, h;
		public Map[] _matrix;

		public MapMatrix(Map initializer_) {
			/*
			 * There is no corner, the offset allows to give the illusion of a corner
			 *    U
			 * L  M  R
			 *    D
			 */
			w = 3;
			h = 3;
			_matrix = new Map[w * h];
			_matrix[1 + 1 * w] = initializer_;
		}

		public Map[] getCopy() {
			Map[] copy_ = new Map[w * h];

			for (int y = 0; y < h; y++) {
				for (int x = 0; x < w; x++) {
					copy_[x + y * w] = _matrix[x + y * w];
				}
			}

			return copy_;
		}

		public void shiftLeft() {
			Map[] copy_ = getCopy();

			_matrix[0] = copy_[1];
			_matrix[1] = copy_[2];
			_matrix[2] = null;
			_matrix[3] = copy_[4];
			_matrix[4] = copy_[5];
			_matrix[5] = null;
			_matrix[6] = copy_[7];
			_matrix[7] = copy_[8];
			_matrix[8] = null;
		}

		public void shiftRight() {
			Map[] copy_ = getCopy();

			_matrix[4] = copy_[3];
		}

		/*public void shiftMap(int tx, int ty) {
			if (tx != 0 && ty != 0) {
				Console.WriteLine("- Error: Corners are non-existant in the map matrix -");
				return;
			}

			Map[] copy_ = new Map[w * w];

			for (int y = 0; y < h; y++) {
				for (int x = 0; x < w; x++) {
					copy_[x + y * w] = _matrix[x + y * w];
				}
			}

			for (int y = 0; y < h; y++) {
				for (int x = 0; x < w; x++) {

					int sp = (x + y * w) + tx;
					int tp = x + y * w;


					if ()
					if (x == (w - 1)) {
						_matrix[tp] = null;
					}

				}
			}


		}*/

		public void render(SpriteBatch batch) {
		}

	}
}
