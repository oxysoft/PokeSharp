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
	public class BinaryOutput : BinaryWriter, IBinaryIO {
		#region Constructors
		public BinaryOutput(Stream stream)
			: base(stream) {
		}
		#endregion

		#region Methods
		public void Write(IEncodable value) {
			value.Encode(this);
		}

		public void Write(Vector2 vector) {
			this.Write(vector.X);
			this.Write(vector.Y);
		}

		public void Write(Vector3 vector) {
			this.Write(vector.X);
			this.Write(vector.Y);
			this.Write(vector.Z);
		}

		public void Write(Vector4 vector) {
			this.Write(vector.W);
			this.Write(vector.X);
			this.Write(vector.Y);
			this.Write(vector.Z);
		}

		public void Write(Texture2D texture) {
			byte[] textureData = new byte[texture.Width * texture.Height * 4];
			texture.GetData<byte>(textureData);

			this.Write(texture.Width);
			this.Write(texture.Height);
			this.Write(textureData);
		}
		public void Write(Rectangle rectangle) {
			this.Write(rectangle.X);
			this.Write(rectangle.Y);
			this.Write(rectangle.Width);
			this.Write(rectangle.Height);
		}

		public void Write(Version version) {
			this.Write(version.Major);
			this.Write(version.Minor);
			this.Write(version.Revision);
			this.Write(version.Build);
		}

		public void Write<T>(List<T> list) where T : IEncodable {
			this.Write(list.Count);
			for (int i = 0; i < list.Count; i++) {
				list[i].Encode(this);
			}
		}

		#endregion
	}
}
