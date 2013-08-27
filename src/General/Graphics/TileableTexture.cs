using System;
using General.Common;
using General.Encoding;
using General.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace General.Graphics {
	public class TileableTexture : IEncodable, ICloneable {
		public TileableTexture() {
			this.Columns = 1;
			this.Rows = 1;
		}
		public TileableTexture(Texture2D texture)
			: this() {
			this.Texture = texture;
		}
		public TileableTexture(Texture2D texture, int columns, int rows)
			: this(texture) {
			this.Columns = columns;
			this.Rows = rows;
		}

		public int Columns {
			get;
			set;
		}
		public int Rows {
			get;
			set;
		}

		public int FrameWidth {
			get {
				if (this.Columns > 0) {
					return this.Texture.Width / this.Columns;
				} else {
					return this.Texture.Width;
				}
			}
		}
		public int FrameHeight {
			get {
				if (this.Rows > 0) {
					return this.Texture.Height / this.Rows;
				} else {
					return this.Texture.Height;
				}
			}
		}

		public int MaxIndex {
			get {
				return this.GetIndex(this.Columns - 1, this.Rows - 1);
			}
		}

		public Texture2D Texture {
			get;
			private set;
		}

		public static Texture2D EmptyTexture(GraphicsDevice graphicsDevice) {
			return new Texture2D(graphicsDevice, 1, 1);
		}

		public Rectangle GetSource(int tileIndex) {
			if (this.Rows == 0 || this.Columns == 0) {
				return new Rectangle(0, 0, this.Texture.Width, this.Texture.Height);
			}
			if (tileIndex == 0) {
				return new Rectangle(0, 0, this.FrameWidth, this.FrameHeight);
			}

			int x = tileIndex % this.Columns;
			int y = tileIndex / this.Columns;

			return new Rectangle(x * this.FrameWidth, y * this.FrameHeight, this.FrameWidth, this.FrameHeight);
		}

		public Rectangle GetSource(int tileX, int tileY) {
			return GetSource(GetIndex(tileX, tileY));
		}

		public int GetIndex(int tileX, int tileY) {
			return tileY * this.Columns + tileX;
		}

		public void Encode(BinaryOutput stream) {
			stream.Write(this.Rows);
			stream.Write(this.Columns);
			stream.Write(this.Texture);
		}
		public IEncodable Decode(BinaryInput stream) {
			this.Rows = stream.ReadInt32();
			this.Columns = stream.ReadInt32();
			this.Texture = stream.ReadTexture();

			return this;
		}
		public int GetLength() {
			int length = 0;

			length += sizeof(int); //Rows
			length += sizeof(int); //Columns
			length += Texture2DExtensions.GetLength(Texture); //Texture

			return length;
		}

		public object Clone() {
			return new TileableTexture(this.Texture.Clone(), this.Columns, this.Rows);
		}

	}
}
