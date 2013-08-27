using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace PokeSharp {

	//Handle inputs here
	class InputHandler {

		public static bool up, down, right, left, shift;
		private static KeyboardState prevState;

		public InputHandler(PokeEngine engine) {
			prevState = Keyboard.GetState();
		}

		public static void releaseAll() {
			up = down = right = left = false;
		}

		public static void pollKeys() {
			KeyboardState state = Keyboard.GetState();

			if (state.IsKeyDown(Keys.Up)) {
				up = true;
			} else up = false;
			if (state.IsKeyDown(Keys.Down)) {
				down = true;
			} else down = false;
			if (state.IsKeyDown(Keys.Left)) {
				left = true;
			} else left = false;
			if (state.IsKeyDown(Keys.Right)) {
				right = true;
			} else right = false;
			if (state.IsKeyDown(Keys.LeftShift)) {
				shift = true;
			} else shift = false;

			prevState = state;

		}


	}
}
