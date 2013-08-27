using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEngine.Data.Tiles;
using General.Common;
using MapEditor.Data;

namespace MapEditor.Forms {
	public partial class FrmTilesetSelector : Form {

		public FrmTilesetSelector() {
			InitializeComponent();
			RefreshTilesets();
		}

		public static FrmTilesetSelector Instance {
			get {
				return Static<FrmTilesetSelector>.Value;
			}
		}

		public void RefreshTilesets() {
			comboBoxEdit1.Items.Clear();
			if (EditorEngine.Instance.CurrentMap != null) {
				foreach (MockupTileset _ref in EditorEngine.Instance.CurrentMap.Tilesets) {
					comboBoxEdit1.Items.Add(_ref.Tileset.Name);
				}
				if (comboBoxEdit1.Items.Count < 1) {
					MessageBox.Show("Some fucked up shit happened.\nError code 42");
				}
			} else {
				return;
			}
			comboBoxEdit1.SelectedIndex = 0;
		}

		private void FrmTilesetSelector_Shown(object sender, EventArgs e) {
			control.initialize(vScrollBar1);
		}

		private void FrmTilesetSelector_VisibleChanged(object sender, EventArgs e) {
			if (FrmEntitySelector.Instance.Location.X > Point.Empty.X &&
				FrmEntitySelector.Instance.Location.Y > Point.Empty.Y) {
				this.Location = FrmEntitySelector.Instance.Location;
			}
		}

		private void FrmTilesetSelector_FormClosing(object sender, FormClosingEventArgs e) {
			this.Hide();
			e.Cancel = true;
		}

		private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e) {
			int i = comboBoxEdit1.SelectedIndex;
			List<MockupTileset> l = EditorEngine.Instance.CurrentMap.Tilesets;
			MockupTileset m = l[i];
			control.Tileset = m.Tileset;
		}

	}
}
