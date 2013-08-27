using System;
using General.Extensions;
using Microsoft.Xna.Framework;

namespace MapEditor.Data.Controls.EditorView {
	public class ControlEditorView : GameControl {

		public ControlEditorView() {
		}

		private double elapsed;

		public event EventHandler Updating;
		public event EventHandler Drawing;

		public int mx, my;

		protected override void OnCreateControl() {
			base.OnCreateControl();
		}

		protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e) {
			mx = e.X;
			my = e.Y;
			base.OnMouseMove(e);
		}

		public override void Update(GameTime gameTime) {
			elapsed += gameTime.ElapsedGameTime.TotalSeconds;
			if (elapsed >= 1) {
				elapsed = 0;
				if (EditorEngine.Instance.CurrentMap != null) {
					//Debug.WriteLine("Entities: {0}", EditorEngine.Instance.CurrentMap.Entities.Count);
				}
			}
			this.Updating.SafeInvoke(this, EventArgs.Empty);
			EditorEngine.Instance.Update(gameTime);
			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime) {
			this.Drawing.SafeInvoke(this, EventArgs.Empty);
			EditorEngine.Instance.Draw(gameTime);
		}
	}
}
