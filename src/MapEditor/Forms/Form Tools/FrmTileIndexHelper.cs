using System;
using System.Windows.Forms;
using GameEngine.Data.Tiles;
using MapEditor.Data;

namespace MapEditor.Forms {
	public partial class FrmTileIndexHelper : Form {
		public FrmTileIndexHelper() {
			InitializeComponent();
			tilesetViewerSpriteindexGetterControl1.indexChanged += new EventHandler(onIndexChanged);
		}

		private void FrmTileIndexHelper_Load(object sender, EventArgs e) {
			if (EditorEngine.Instance.World != null) {
				tilesetViewerSpriteindexGetterControl1.Initialize(vScrollBar1);

				foreach (Tileset t in EditorEngine.Instance.World.TilesetContainer) {
					cbTilesets.Items.Add(t.Name);
				}

				cbTilesets.SelectedIndex = 0;
			} else {
				MessageBox.Show("No World loaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void onIndexChanged(object sender, EventArgs e) {
			int xt = tilesetViewerSpriteindexGetterControl1.xt;
			int yt = tilesetViewerSpriteindexGetterControl1.yt;
			tslData.Text = "TileIndex: " + cbTilesets.SelectedIndex + ", SpriteIndex: " + tilesetViewerSpriteindexGetterControl1.TileIndex + " | x: " + xt + ", y: " + yt;
		}

		private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e) {
			int i = cbTilesets.SelectedIndex;
			Tileset sheet = EditorEngine.Instance.World.TilesetContainer[i];
			tilesetViewerSpriteindexGetterControl1.Sheet = sheet;
		}
	}
}