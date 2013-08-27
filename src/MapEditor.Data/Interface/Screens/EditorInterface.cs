using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Data.Common;
using MapEditor.Data.Controls.EditorView;
using MapEditor.Data.Interface.Controls;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Interface.Screens {
	public class EditorInterface : ScreenInterface {
		public EditorInterface(GameControl control) : base(control) {
		}

		public override void Initialize() {
			Map map = EditorEngine.Instance.CurrentMap;

			const int offset = 4;

			PokeButton b1 = new PokeButton(this, 25, 25, 24, 24);
			b1.X = map.Bounds.Width / 2 - b1.Width / 2;
			b1.Y = 0 - b1.Height - offset;
			b1.tUnactive = Texture2D.FromStream(Control.GraphicsDevice, Assembly.GetExecutingAssembly().GetManifestResourceStream("MapEditor.Datas.Resources.con_add.png"));

			PokeButton b2 = new PokeButton(this, 25, 25, 24, 24);
			b2.X = map.Bounds.Width + 1 + offset;
			b2.Y = map.Bounds.Height / 2 - b2.Height / 2;
			b2.tUnactive = Texture2D.FromStream(Control.GraphicsDevice, Assembly.GetExecutingAssembly().GetManifestResourceStream("MapEditor.Datas.Resources.con_add.png"));

			PokeButton b3 = new PokeButton(this, 25, 25, 24, 24);
			b3.X = map.Bounds.Width / 2 - b3.Width / 2;
			b3.Y = map.Bounds.Height + 1 + offset;
			b3.tUnactive = Texture2D.FromStream(Control.GraphicsDevice, Assembly.GetExecutingAssembly().GetManifestResourceStream("MapEditor.Datas.Resources.con_add.png"));

			PokeButton b4 = new PokeButton(this, 25, 25, 24, 24);
			b4.X = 0 - b4.Width - offset;
			b4.Y = map.Bounds.Height / 2 - b4.Height / 2;
			b4.tUnactive = Texture2D.FromStream(Control.GraphicsDevice, Assembly.GetExecutingAssembly().GetManifestResourceStream("MapEditor.Datas.Resources.con_add.png"));
		}
	}
}