using System;
using General.Extensions;
using Microsoft.Xna.Framework;

namespace General.Graphics.Animations {
	public class AnimationController {
		public AnimationController(Animation animation) {
			this.Animation = animation;
		}

		private double elapsed;
		private int currentIndex;
		public bool RoundUp = true;

		public Animation Animation { get; private set; }

		public int AnimationIndex {
			get { return this.Animation.Indices[this.currentIndex]; }
		}

		public double PercentageDone {
			get { return this.elapsed / this.Animation.TimePerFrame * 100f; }
		}

		public event EventHandler LoopPassed;

		public void Reset() {
			this.elapsed = 0;
			this.currentIndex = 0;
		}

		public void FocusLost() {
			if (RoundUp) {
				currentIndex += (currentIndex % 2);
				if (this.currentIndex >= this.Animation.Indices.Count - 1) {
					this.LoopPassed.SafeInvoke(this, EventArgs.Empty);
				}
				if (this.currentIndex >= this.Animation.Indices.Count) {
					Reset();
				}
			}
		}

		public void Update(GameTime gameTime) {
			this.elapsed += gameTime.ElapsedGameTime.TotalSeconds;

			while (this.elapsed >= this.Animation.TimePerFrame) {				
				elapsed = 0;
				if (this.currentIndex >= this.Animation.Indices.Count - 1) {
					this.LoopPassed.SafeInvoke(this, EventArgs.Empty);
				}
				if (this.Animation.Loopable || this.currentIndex < this.Animation.Indices.Count - 1) {
					this.currentIndex++;
				}
				if (this.currentIndex >= this.Animation.Indices.Count) {
					Reset();
				}
				if (this.Animation.TimePerFrame <= 0) {
					break;
				}
			}
		}
	}
}