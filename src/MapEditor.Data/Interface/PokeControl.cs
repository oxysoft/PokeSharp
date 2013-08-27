using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using General.Extensions;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Interface {
	public class PokeControl {
		public ScreenInterface Screen;
		public SpriteBatch SpriteBatch;
		private int x, y;
		public int Width, Height;

		public Rectangle Bounds {
			get { return new Rectangle(X, Y, Width, Height); }
		}

		public PokeControl(ScreenInterface Screen, int x, int y, int w, int h) {
			this.Screen = Screen;

			this.x = x;
			this.y = y;
			this.Width = w;
			this.Height = h;

			this.SpriteBatch = Screen.SpriteBatch;
			this.Visible = true;
		}

		public int X {
			get { return x + Screen.xCam; }
			set { x = value; }
		}

		public int Y {
			get { return y + Screen.yCam; }
			set { y = value; }
		}

		public bool Visible { get; set; }

		public event MouseEventHandler OnMouseDown;
		public event MouseEventHandler OnMouseUp;
		public event MouseEventHandler OnDoubleClick;
		public event MouseEventHandler OnMouseEnter;
		public event MouseEventHandler OnMouseLeave;

		private long m_tick;

		public MouseEventArgs TranslateMouseEventArgs(MouseEventArgs e) {
			return new MouseEventArgs(e.Button, e.Clicks, e.X - x, e.Y - y, e.Delta);
		}

		public virtual void Invalidate() {
		}

		public virtual void MouseDown(MouseEventArgs e) {
			OnMouseDown.SafeInvoke(this, TranslateMouseEventArgs(e));

			long diff = Environment.TickCount - m_tick;

			//250 millis
			if (diff < 250) {
				DoubleClick(e);
				m_tick = Environment.TickCount;
			}
		}

		public virtual void MouseUp(MouseEventArgs e) {
			OnMouseUp.SafeInvoke(this, TranslateMouseEventArgs(e));
		}

		public virtual void DoubleClick(MouseEventArgs e) {
			OnDoubleClick.SafeInvoke(this, TranslateMouseEventArgs(e));
		}

		public virtual void MouseEnter(MouseEventArgs e) {
			OnMouseEnter.SafeInvoke(this, TranslateMouseEventArgs(e));
		}

		public virtual void MouseLeave(MouseEventArgs e) {
			OnMouseLeave.SafeInvoke(this, TranslateMouseEventArgs(e));
		}

		public virtual void Update(GameTime time) {
		}

		public virtual void Draw(GameTime time) {
		}
	}
}