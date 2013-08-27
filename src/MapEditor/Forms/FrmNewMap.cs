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
using MapEditor.Data;

namespace MapEditor.Forms.Form_Regions {
	public partial class FrmNewMap : Form {
		public string MapName {
			get { return tbName.Text; }
		}

		public string Author {
			get { return "Anonymous"; }
		}

		public int MapWidth {
			get { return (int) udWidth.Value; }
		}

		public int MapHeight {
			get { return (int) udHeight.Value; }
		}

		public List<string> MapTilesetContainers {
			get { return (from object item in clTilesets.CheckedItems select item as string).ToList(); }
		}

		public FrmNewMap() {
			InitializeComponent();
		}

		private void FrmNewMap_Load(object sender, EventArgs e) {
			foreach (Tileset t in EditorEngine.Instance.World.TilesetContainer) {
				clTilesets.Items.Add(t.Name);
			}
		}

		private void btnOK_Click(object sender, EventArgs e) {
			if (String.IsNullOrEmpty(MapName)) {
				MessageBox.Show(this, "You cannot leave the Name field empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}

		private void clTilesets_ItemCheck(object sender, ItemCheckEventArgs e) {
			btnOK.Enabled = !(clTilesets.CheckedItems.Count > 0);
		}
	}
}