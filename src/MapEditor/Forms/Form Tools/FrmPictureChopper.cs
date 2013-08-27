using System;
using System.Windows.Forms;
using MapEditor.Data.Controls.EditorView;

namespace MapEditor.Forms.Form_Tools {
	public partial class FrmPictureChopper : Form {
		public FrmPictureChopper() {
			InitializeComponent();
			numericUpDown1.Minimum = 0;
			numericUpDown1.Maximum = ControlTextureExtractor.BUFFER_SIZE - 1;
			numericUpDown2.Minimum = 1;
			numericUpDown2.Maximum = 8;
			numericUpDown2.Increment = 0.1m;

			control.Initialize(vScrollBar1, hScrollBar1);
			control.ScaleChanged += OnScaleChanged;
			control.BufferIndexChanged += OnBufferIndexChanged;

		}

		public void OnScaleChanged(object sender, EventArgs e) {
			this.numericUpDown2.Value = (decimal) control.Scale;
		}

		public void OnBufferIndexChanged(object sender, EventArgs e) {
			this.numericUpDown1.Value = (decimal) control.CurrentBufferIndex;
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
			switch (keyData) {
				case Keys.Space:
					numericUpDown1.Value++;
					break;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void bImportTexture_Click(object sender, EventArgs e) {
			using (OpenFileDialog dialog = new OpenFileDialog()) {
				dialog.Filter = ".png (*.png)|*.png";
				if (dialog.ShowDialog() == DialogResult.OK) {
					control.LoadTexture(dialog.FileName);
				}
			}
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
			control.CurrentBufferIndex = (Int32) numericUpDown1.Value;
		}

		private void numericUpDown2_ValueChanged(object sender, EventArgs e) {
			control.Scale = (Single) numericUpDown2.Value;
		}

		private void bDumpAll_Click(object sender, EventArgs e) {
			using (FolderBrowserDialog dialog = new FolderBrowserDialog()) {
				if (dialog.ShowDialog() == DialogResult.OK) {
					control.DumpAll(dialog.SelectedPath);
				}
			}
		}

		private void checkProcessTrans_CheckedChanged(object sender, EventArgs e) {
			control.ProcessBlankPixels = checkProcessTrans.Checked;
		}

		private void checkAutoBuffer_CheckedChanged(object sender, EventArgs e) {
			control.AutoAdvance = checkAutoBuffer.Checked;
		}
	}
}