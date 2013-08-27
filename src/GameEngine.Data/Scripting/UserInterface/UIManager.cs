using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Common;
using General.Encoding;
using Microsoft.Xna.Framework;

namespace GameEngine.Data.Scripting.UserInterface {
	public class UIManager {
		private List<UI> uis;

		public UIManager() {
			this.uis = new List<UI>();
		}

		public void Add(UI ui) {
			if (uis.Any(u => ui.Template == u.Template)) return;

			ui.Load();
			this.uis.Add(ui);
		}

		public void Update(GameTime gameTime) {
		}

		public void Draw(GameTime gameTime) {
			uis.ForEach(e => e.Draw(gameTime));
		}
	}
}