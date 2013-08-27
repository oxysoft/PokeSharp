using System;
using System.Windows.Forms;
using General.Extensions;
using Microsoft.Xna.Framework;

namespace MapEditor.Data.Controls.EditorView {
	public class FluentScrolling {

		public FluentScrolling(ScrollBar scrollBar) {
			this.scrollBar = scrollBar;
			this.scrollBar.ValueChanged += new EventHandler(onValueChanged);
		}

		public event EventHandler ValueChanged;
		private ScrollBar scrollBar;

		private int lastScrollValue;
		private float currentValueDelta;
		private float currentValue {
			get {
				return currentValueDelta;
			}
			set {
				ValueChanged.SafeInvoke(this, EventArgs.Empty);
				currentValueDelta = value;
			}
		}
		private double elapsed;

		public int Value {
			get {
				return (int)this.currentValue;
			}
			set {
				ValueChanged.SafeInvoke(this, EventArgs.Empty);
				Value = value;
			}
		}

		public void BeginScrolling() {
			this.lastScrollValue = this.Value;
			this.elapsed = 0;
		}

		public void Update(GameTime gameTime) {
			if (this.currentValue != this.scrollBar.Value) {
				this.elapsed += gameTime.ElapsedGameTime.TotalSeconds * 4;

				this.currentValue = MathHelper.SmoothStep(
					this.lastScrollValue,
					this.scrollBar.Value,
					(float)this.elapsed * 2f);


			}
			if (this.elapsed >= 1) {
				this.currentValue = this.scrollBar.Value;
				this.elapsed -= 1;
			}
		}

		private void onValueChanged(object sender, EventArgs e) {
			this.BeginScrolling();
		}
	}
}
