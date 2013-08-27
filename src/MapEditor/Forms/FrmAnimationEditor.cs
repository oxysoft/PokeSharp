using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using General.Graphics;
using General.Graphics.Animations;

namespace MapEditor.Forms {
	public partial class FrmAnimationEditor : Form {
		public List<Animation> Animations;
		public TileableTexture TileableTexture;

		public FrmAnimationEditor() {
			this.Animations = new List<Animation>();
			InitializeComponent();
		}

		private void FrmAnimationEditor_Load(object sender, EventArgs e) {
			control.TileableTexture = this.TileableTexture;

			foreach (Animation animation in this.Animations) {
				cbAnimations.Items.Add(animation.Name);
			}
			if (this.Animations.Count > 0) {
				cbAnimations.SelectedIndex = 0;
				SetState(true);
			}
		}

		public void Reload() {
			this.cbAnimations.Items.Clear();
			foreach (Animation animation in this.Animations) {
				cbAnimations.Items.Add(animation.Name);
			}
			if (this.Animations.Count > 0) {
				cbAnimations.SelectedIndex = 0;
				SetState(true);
			}
		}

		public void SetState(bool state) {
			bDelete.Enabled = state;
		}

		private void bNew_Click(object sender, EventArgs e) {
			Animation animation = new Animation(0.2f);
			animation.Name = "Unnamed";

			for (int i = 0; i < 4; i++) {
				animation.Indices.Add(0);
			}

			this.Animations.Add(animation);

			cbAnimations.Items.Add(animation.Name);
			cbAnimations.SelectedIndex = cbAnimations.Items.Count - 1;
			tbCurrentFrame.Maximum = 4 - 1;

			this.SetState(true);
		}

		private void bDelete_Click(object sender, EventArgs e) {
			if (cbAnimations.Items.Count > 0) {
				if (this.cbAnimations.SelectedItem == null) return;
				this.Animations.RemoveAt(cbAnimations.SelectedIndex);
				cbAnimations.Items.RemoveAt(cbAnimations.SelectedIndex);

				tbName.Text = string.Empty;
				tbFrames.Value = tbFrames.Minimum;
				tbDuration.Value = tbDuration.Minimum;
				cLoopable.Checked = false;
				cResettable.Checked = false;

				if (cbAnimations.Items.Count == 0) {
					this.SetState(false);
				}

				control.Animation = null;
			}
		}

		private void bOK_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
		}

		private void bCancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}

		private void bPlay_Click(object sender, EventArgs e) {
			control.Play();
		}

		private void bStop_Click(object sender, EventArgs e) {
			control.Stop();
		}

		private void tbName_TextChanged(object sender, EventArgs e) {
			control.Animation.Name = tbName.Text;

			if (cbAnimations.SelectedIndex >= 0) {
				cbAnimations.Items[cbAnimations.SelectedIndex] = tbName.Text;
			}
		}

		private void tbFrames_ValueChanged(object sender, EventArgs e) {
			tbCurrentFrame.Maximum = (int) tbFrames.Value - 1;
			if (control.Animation != null) {
				while (tbFrames.Value >= control.Animation.Indices.Count) {
					control.Animation.Indices.Add(0);
				}
				while (tbFrames.Value < control.Animation.Indices.Count) {
					control.Animation.Indices.RemoveAt(control.Animation.Indices.Count - 1);
				}
			}
			control.SelectedFrame = 0;
			tbCurrentFrame.Value = tbCurrentFrame.Minimum;
		}

		private void tbDuration_ValueChanged(object sender, EventArgs e) {
			control.Animation.TimePerFrame = (float) tbDuration.Value;
		}

		private void cLoopable_CheckedChanged(object sender, EventArgs e) {
			if (cLoopable.Checked) {
				control.Animation.Flags |= AnimationFlags.Loopable;
			} else {
				control.Animation.Flags &= ~AnimationFlags.Loopable;
			}
		}

		private void cResettable_CheckedChanged(object sender, EventArgs e) {
			if (cResettable.Checked) {
				control.Animation.Flags |= AnimationFlags.Resettable;
			} else {
				control.Animation.Flags &= ~AnimationFlags.Resettable;
			}
		}

		private void tbCurrentFrame_ValueChanged(object sender, EventArgs e) {
			control.SelectedFrame = (int) tbCurrentFrame.Value;
		}

		private void cbAnimations_SelectedIndexChanged(object sender, EventArgs e) {
			control.Animation = this.Animations[cbAnimations.SelectedIndex];

			tbName.Text = control.Animation.Name;
			tbFrames.Value = control.Animation.Indices.Count;
			tbDuration.Value = (decimal) control.Animation.TimePerFrame;
			cLoopable.Checked = control.Animation.Loopable;
			cResettable.Checked = control.Animation.Resettable;
		}

		private void bFromTemplate_Click(object sender, EventArgs e) {
			switch (cbTemplates.SelectedIndex) {
				case 0:
					return;
				case 1:
					Animations.Add(new Animation(0f, new[] {4}, AnimationFlags.None) {Name = "face-left"});
					Animations.Add(new Animation(0f, new[] {8}, AnimationFlags.None) {Name = "face-right"});
					Animations.Add(new Animation(0f, new[] {12}, AnimationFlags.None) {Name = "face-up"});
					Animations.Add(new Animation(0f, new[] {0}, AnimationFlags.None) {Name = "face-down"});
					Animations.Add(new Animation(0.16f, new[] {4, 5, 6, 7}, AnimationFlags.Loopable) {Name = "walking-left"});
					Animations.Add(new Animation(0.16f, new[] {8, 9, 10, 11}, AnimationFlags.Loopable) {Name = "walking-right"});
					Animations.Add(new Animation(0.16f, new[] {12, 13, 14, 15}, AnimationFlags.Loopable) {Name = "walking-up"});
					Animations.Add(new Animation(0.16f, new[] {0, 1, 2, 3}, AnimationFlags.Loopable) {Name = "walking-down"});
					break;
			}
			Reload();
		}
	}
}