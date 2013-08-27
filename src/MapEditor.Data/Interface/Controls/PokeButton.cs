using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Interface.Controls {
	public class PokeButton : PokeControl {
		public bool FadeEffect;
		public Texture2D tUnactive, tHover, tActive;

		public PokeButton(ScreenInterface screen, int x, int y, int w, int h) : base(screen, x, y, w, h) {
			screen.Controls.Add(this);
		}

		public bool Hover;
		public bool Clicked;

		public override void MouseDown(System.Windows.Forms.MouseEventArgs e) {
			Clicked = true;
			base.MouseDown(e);
		}

		public override void MouseUp(System.Windows.Forms.MouseEventArgs e) {
			Clicked = false;
			base.MouseUp(e);
		}

		public override void MouseEnter(System.Windows.Forms.MouseEventArgs e) {
			Hover = true;
			base.MouseEnter(e);
		}

		public override void MouseLeave(System.Windows.Forms.MouseEventArgs e) {
			Hover = false;
			base.MouseLeave(e);
		}

		public override void Update(GameTime time) {
		}

		public override void Draw(GameTime time) {
			if (!Hover) DrawUnactive();
			else if (Hover && !Clicked) DrawHover();
			else if (Clicked) DrawActive();
		}

		public virtual void DrawUnactive() {
			SpriteBatch.Draw(tUnactive, Bounds, Color.White);
		}

		public virtual void DrawHover() {
			if (tHover != null) SpriteBatch.Draw(tHover, Bounds, Color.White);
		}

		public virtual void DrawActive() {
			if (tActive != null) SpriteBatch.Draw(tActive, Bounds, Color.White);
		}
	}
}