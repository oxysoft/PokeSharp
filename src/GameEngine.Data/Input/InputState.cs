using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Data.Common;
using Microsoft.Xna.Framework.Input;

namespace GameEngine.Data.Input {
	public class InputState {
		public KeyboardState State;

		public InputState(KeyboardState state) {
			this.State = state;
			Populate();
		}

		public void Populate() {
		}
	}
}