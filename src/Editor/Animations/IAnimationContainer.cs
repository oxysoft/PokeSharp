using System;
using General.Extensions;
using Microsoft.Xna.Framework;

namespace General.Graphics.Animations {
	public interface IAnimationContainer {
		Animation GetAnimation(string name);
	}
}
