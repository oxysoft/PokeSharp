/*
 * This code is derived from Universal Tween Engine (http://code.google.com/p/java-universal-tween-engine/)
 * 
 * @author Aurelien Ribon | http://www.aurelienribon.com/
 */

using General.Tweening.Paths;

namespace General.Tweening
{
	/// <summary>Collection of built-in paths.</summary>
	/// <remarks>Collection of built-in paths.</remarks>
	/// <author>Aurelien Ribon | http://www.aurelienribon.com/</author>
	public abstract class TweenPaths
	{
		public static readonly Linear linear = new Linear();

		public static readonly CatmullRom catmullRom = new CatmullRom();
	}
}
