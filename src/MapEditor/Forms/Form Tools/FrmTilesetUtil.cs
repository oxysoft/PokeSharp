using System;
using System.Windows.Forms;
using MapEditor.Data;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Forms {
	public partial class FrmTilesetUtil : Form {
		public FrmTilesetUtil() {
			InitializeComponent();
		}

		private void FrmTilesetUtil_Load(object sender, EventArgs e) {
			control.vscrollbar = this.vScrollBar1;
			control.hscrollbar = this.hScrollBar1;
		}

		private void b_path_Click(object sender, EventArgs e) {
			using (OpenFileDialog dialog = new OpenFileDialog()) {
				dialog.Filter = "picture (*.png)|*.png";
				if (dialog.ShowDialog() == DialogResult.OK) {
					Texture2D texture = EditorEngine.Instance.LoadTexture(dialog.FileName);
					control.LoadTileset(texture);
				}
			}
		}

		private void b_export_Click(object sender, EventArgs e) {
			using (FolderBrowserDialog  dialog = new FolderBrowserDialog()) {
				if (dialog.ShowDialog() == DialogResult.OK) {
					control.SaveResults(dialog.SelectedPath);
				}
			}
		}

		private void s_selectedEntity_ValueChanged(object sender, EventArgs e) {
			int val = (int)s_selectedEntity.Value;
			control.currentEntity = val;
		}

		private void c_checkerboard_CheckedChanged(object sender, EventArgs e) {
			control.checkerboard = c_checkerboard.Checked;
		}

		private void c_colorbuffer_CheckedChanged(object sender, EventArgs e) {
			control.colorbuffer = c_colorbuffer.Checked;
		}

		private void c_ignoretransparent_CheckedChanged(object sender, EventArgs e) {
			control.ignoretransparent = c_ignoretransparent.Checked;
		}

	}
}
