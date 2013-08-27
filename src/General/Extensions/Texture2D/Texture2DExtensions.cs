using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace General.Extensions {
	public static class Texture2DExtensions {
		#region Methods
		public static int GetLength(this Texture2D texture) {
			return texture.Width * texture.Height * 4;
		}
		public static Texture2D Clone(this Texture2D texture) {
			Texture2D clonedTexture = new Texture2D(texture.GraphicsDevice, texture.Width, texture.Height);

			byte[] textureData = new byte[texture.Width * texture.Height * 4];
			texture.GetData<byte>(textureData);

			clonedTexture.SetData<byte>(textureData);

			return clonedTexture;
		}
		#endregion
	}
}
