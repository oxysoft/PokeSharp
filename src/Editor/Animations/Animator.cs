using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Extensions;
using Microsoft.Xna.Framework;

namespace General.Graphics.Animations {
	public class Animator {
		public Animator() {
			this.cachedAnimations = new Dictionary<Animation, AnimationController>();
		}

		public Animator(IAnimationContainer container)
			: this() {
			this.container = container;
		}

		private bool forcePlay = false;
		private AnimationController controller;
		private IAnimationContainer container;
		private Dictionary<Animation, AnimationController> cachedAnimations;
		private Action callback;

		public int AnimationIndex {
			get {
				if (this.controller == null) {
					return 0;
				}
				return this.controller.AnimationIndex;
			}
		}

		public bool Animating {
			get { return this.controller != null; }
		}

		public event EventHandler FinishedAnimation;

		public void Play(string name) {
			Play(name, false);
		}

		public void Play(string name, bool forcePlayOnce) {
			Play(name, forcePlayOnce, null);
		}

		public void Play(string name, bool forcePlayOnce, Action callback) {
			this.Play(this.container.GetAnimation(name), forcePlayOnce, callback);
		}

		public void Play(Animation animation, bool forcePlayOnce, Action callback) {
			if (!forcePlay) {
				this.Reset();
				this.forcePlay = forcePlayOnce;
				this.callback = callback;
				if (animation != null && (this.controller == null || this.controller.Animation != animation)) {
					if (controller != null) controller.FocusLost();
					this.controller = new AnimationController(animation);

					if (!this.cachedAnimations.ContainsKey(animation) || animation.Resettable) {
					} else {
						this.controller = this.cachedAnimations[animation];
					}

					if (!this.cachedAnimations.ContainsKey(animation)) {
						this.cachedAnimations.Add(animation, this.controller);
					}
					this.controller.LoopPassed += new EventHandler(onLoopPassed);
				}
			}
		}

		public void Reset() {
			if (this.controller != null) {
				this.controller.LoopPassed -= onLoopPassed;

				if (this.controller.Animation.Resettable) {
					this.controller.Reset();
				}
			}
		}

		public void Stop() {
			this.Reset();
			this.controller = null;
		}

		private void onLoopPassed(object sender, EventArgs e) {
			this.controller.LoopPassed -= onLoopPassed;
			forcePlay = false;
			if (callback != null) {
				callback();
				callback = null;
			}
			this.FinishedAnimation.SafeInvoke(this, e);
		}

		public void Update(GameTime gameTime) {
			if (this.controller != null) this.controller.Update(gameTime);
		}
	}
}