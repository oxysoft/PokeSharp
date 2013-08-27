using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEngine.Data.Entities.Core;
using GameEngine.Data.Tiles;
using General.Encoding;
using MapEditor.Data;

namespace MapEditor.Forms {
	public partial class FrmResourceExport : Form {
		private int mode;

		public FrmResourceExport(object baseContainer, int type) {
			InitializeComponent();

			if (baseContainer is TilesetContainer) BaseTilesets = baseContainer as TilesetContainer;
			else if (baseContainer is EntityContainer) BaseEntities = baseContainer as EntityContainer;
			else throw new InvalidOperationException();

			this.Mode = type;
		}

		public int Mode {
			get { return mode; }
			set {
				this.mode = value;
				if (Mode == 0) {
					listResource.Items.Clear();
					foreach (Tileset tileset in BaseTilesets)
						listResource.Items.Add(tileset.Name);
				} else if (Mode == 1) {
					listResource.Items.Clear();
					foreach (EntityTemplate temp in BaseEntities.All())
						listResource.Items.Add(temp.Name);
				}
			}
		}

		public TilesetContainer BaseTilesets;
		public EntityContainer BaseEntities;

		public TilesetContainer TilesetContainer {
			get {
				TilesetContainer container = new TilesetContainer();
				foreach (int chk in listResource.SelectedIndices)
					container.Add(BaseTilesets[chk]);
				return container;
			}
		}

		public EntityContainer EntityContainer {
			get {
				EntityContainer container = new EntityContainer();
				foreach (int chk in listResource.CheckedIndices)
					container.Add(BaseEntities.GetAt(chk));
				return container;
			}
		}

		private void bExport_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
		}

		private void bCancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}

		private void listResource_ItemCheck(object sender, ItemCheckEventArgs e) {
			bExport.Enabled = listResource.CheckedIndices.Count > 0;
		}
	}
}