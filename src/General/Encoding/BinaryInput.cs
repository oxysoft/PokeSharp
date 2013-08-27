using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace General.Encoding {
	public class BinaryInput : BinaryReader, IBinaryIO {
		#region Constructors
		public BinaryInput(Stream stream)
			: base(stream) {
		}
		public BinaryInput(Stream stream, GraphicsDevice graphicsDevice)
			: base(stream) {
			this.GraphicsDevice = graphicsDevice;
		}
		#endregion

		#region Properties
		public GraphicsDevice GraphicsDevice {
			get;
			set;
		}
		#endregion

		#region Methods
		public T ReadObject<T>() where T : IEncodable, new() {
			IEncodable value = new T();
			value.Decode(this);

			return (T)value;
		}

		public Vector2 ReadVector2() {
			float x = this.ReadSingle();
			float y = this.ReadSingle();

			return new Vector2(x, y);
		}

		public Vector3 ReadVector3() {
			float x = this.ReadSingle();
			float y = this.ReadSingle();
			float z = this.ReadSingle();

			return new Vector3(x, y, z);
		}

		public Vector4 ReadVector4() {
			float w = this.ReadSingle();
			float x = this.ReadSingle();
			float y = this.ReadSingle();
			float z = this.ReadSingle();

			return new Vector4(w, x, y, z);
		}

		public Texture2D ReadTexture() {
			int width = this.ReadInt32();
			int height = this.ReadInt32();

			byte[] data = new byte[width * height * 4];
			data = this.ReadBytes(data.Length);

			if (this.GraphicsDevice != null) {
				Texture2D texture = new Texture2D(this.GraphicsDevice, width, height);
				texture.SetData<byte>(data);

				return texture;
			}

			return null;
		}

		public Rectangle ReadRectangle() {
			int x = this.ReadInt32();
			int y = this.ReadInt32();
			int width = this.ReadInt32();
			int height = this.ReadInt32();

			return new Rectangle(x, y, width, height);
		}

		public Version ReadVersion() {
			int major = this.ReadInt32();
			int minor = this.ReadInt32();
			int revision = this.ReadInt32();
			int build = this.ReadInt32();

			return new Version(major, minor, build, revision);
		}

		public List<T> ReadList<T>() where T : IEncodable, new() {
			int count = this.ReadInt32();
			List<T> result = new List<T>(count);

			for (int i = 0; i < count; i++) {
				result.Add(this.ReadObject<T>());
			}

			return result;
		}
		#endregion
	}
}
