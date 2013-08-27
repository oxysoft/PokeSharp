using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Data.Common;
using General.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameEngine.Data.Input {
	public class InputHandler {
		public static InputHandler Instance {
			get { return Static<InputHandler>.Value; }
		}

		public KeyboardState State { get; private set; }
		public KeyboardState LastState { get; private set; }

		public void Poll(GameTime gameTime) {
			LastState = State;

			State = Keyboard.GetState();
		}
	}
}