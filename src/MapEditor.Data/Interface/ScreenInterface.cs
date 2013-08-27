using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapEditor.Data.Controls.EditorView;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Data.Interface {
	public class ScreenInterface {
		public List<PokeControl> Controls;
		public GameControl Control;
		public SpriteBatch SpriteBatch;
		public int mx, my;
		public int xCam, yCam;

		public ScreenInterface() {
			this.Controls = new List<PokeControl>();
		}

		public ScreenInterface(GameControl control) : this() {
			this.Control = control;
			this.SpriteBatch = new SpriteBatch(control.GraphicsDevice);

			control.MouseDown += PerformDown;
			control.MouseUp += PerformUp;
			control.MouseDoubleClick += PerformDoubleClick;
			control.MouseMove += PerformMouseMove;
			control.MouseEnter += PerformMouseEnter;
	
			control.MouseLeave += PerformMouseLeave;
		}

		public virtual void Initialize() {
		}

		public void Update(GameTime time) {
		}

		public void Draw(GameTime time) {
			foreach (PokeControl control in Controls.Where(control => control.Visible)) {
				control.Draw(time);
			}
		}

		public void PerformMouseMove(object sender, MouseEventArgs e) {
			PokeControl before = GetControlAt(new Point(mx, my));
			PokeControl now = GetControlAt(new Point(e.X, e.Y));

			if (before == null && now != null) {
				now.MouseEnter(e);
			} else {
				if (now != before && before != null) {
					before.MouseLeave(e);
				}
			}

			mx = e.X;
			my = e.Y;
		}

		public void PerformUp(object sender, MouseEventArgs e) {
			PokeControl control = GetControlAt(new Point(e.X, e.Y));

			if (control != null) control.MouseUp(e);
		}

		public void PerformDown(object sender, MouseEventArgs e) {
			PokeControl control = GetControlAt(new Point(e.X, e.Y));

			if (control != null) control.MouseDown(e);
		}

		public void PerformDoubleClick(object sender, MouseEventArgs e) {
			PokeControl control = GetControlAt(new Point(e.X, e.Y));

			if (control != null) control.DoubleClick(e);
		}

		public void PerformMouseEnter(object sender, EventArgs eventArgs) {
		}

		public void PerformMouseLeave(object sender, EventArgs e) {
		}

		public PokeControl GetControlAt(Point p) {
			return Controls.FirstOrDefault(control => control.Bounds.Contains(p) && control.Visible);
		}
	}
}