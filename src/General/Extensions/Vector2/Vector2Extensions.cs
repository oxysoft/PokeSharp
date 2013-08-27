using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace General.Extensions
{
	public static class Vector2Extensions
	{
		#region Methods
		public static Vector2 ToClipSpace(this Vector2 vector, Viewport viewport)
		{
			float clipX = (vector.X / viewport.Width) * 2f - 1;
			float clipY = (vector.Y / viewport.Height) * 2f - 1;

			return new Vector2(clipX, -clipY);
		}
		#endregion
	}
}
