using System;
using System.Windows.Forms;
using GameEngine.Data.Entities.Core;
using GameEngine.Data.Tiles;
using General.Encoding;
using General.Extensions;
using MapEditor.Data;

namespace MapEditor.Forms {
	public partial class FrmResourceManager : Form {
		public FrmResourceManager() {
			InitializeComponent();
		}

		private void FrmResourceManager_Load(object sender, EventArgs e) {
			RefreshView();
		}

		private void bNew_Click(object sender, EventArgs e) {
			switch (tabs.SelectedIndex) {
				case 0:
					using (FrmTilesetEditor form = new FrmTilesetEditor()) {
						DialogResult result = form.ShowDialog();
						if (result == DialogResult.OK) {
							EditorEngine.Instance.World.TilesetContainer.Add(form.Tileset);
						}
					}
					break;
				case 1:
					using (FrmEntityTemplateEditor frm = new FrmEntityTemplateEditor()) {
						if (frm.ShowDialog() == DialogResult.OK) {
							EntityTemplate temp = frm.Template;
							EditorEngine.Instance.World.EntityContainer.Add(temp);
						}
					}
					RefreshView();
					break;
			}

			RefreshView();
		}

		private void bRemove_Click(object sender, EventArgs e) {
			int type = tabs.SelectedIndex;
			int index = lItems.SelectedIndex;
			switch (type) {
				case 0:
					if (index > -1 && index < EditorEngine.Instance.World.TilesetContainer.Count) {
						EditorEngine.Instance.World.TilesetContainer.RemoveAt(index);
						EditorEngine.Instance.HasEdit = true;
					}
					FrmTilesetSelector.Instance.RefreshTilesets();
					break;
				case 1:
					if (index > -1 && index < EditorEngine.Instance.World.EntityContainer.All().Count) {
						EditorEngine.Instance.World.EntityContainer.RemoveAt(index);
						EditorEngine.Instance.HasEdit = true;
					}
					break;
			}
			RefreshView();
		}

		private void bImport_Click(object sender, EventArgs e) {
		}

		private void bExport_Click(object sender, EventArgs e) {
		}

		private void bExportContainer_Click2(object sender, EventArgs e) {
			using (SaveFileDialog dialog = new SaveFileDialog()) {
				dialog.Filter = "PokeSharp Resource Container (*.pcon)|*.pcon";
				if (dialog.ShowDialog() == DialogResult.OK) {
					try {
						if (tabs.SelectedIndex == 0) {
							EncoderUtil.Encode(dialog.FileName, EditorEngine.Instance.World.TilesetContainer);
						} else if (tabs.SelectedIndex == 1) {
							EncoderUtil.Encode(dialog.FileName, EditorEngine.Instance.World.EntityContainer);
						}
					} catch (Exception exc) {
						MessageBox.Show("Error. Stacktrace: \n\n{0}".WithFormat(exc.Message),
						                "Exporting Error",
						                MessageBoxButtons.OK,
						                MessageBoxIcon.Exclamation);
					}
				}
			}
			RefreshView();
		}

		private void bImportContainer_Click(object sender, EventArgs e) {
			using (OpenFileDialog fileDialog = new OpenFileDialog()) {
				fileDialog.Filter = "PokeSharp Resource Container (*.pcon)|*.pcon";
				if (fileDialog.ShowDialog() == DialogResult.OK) {
					try {
						if (tabs.SelectedIndex == 0) {
							TilesetContainer container = EncoderUtil.Decode<TilesetContainer>(fileDialog.FileName, EditorEngine.Instance.GraphicsDevice);
							EditorEngine.Instance.World.TilesetContainer = container;
						} else if (tabs.SelectedIndex == 1) {
							EntityContainer container = EncoderUtil.Decode<EntityContainer>(fileDialog.FileName, EditorEngine.Instance.GraphicsDevice);
							EditorEngine.Instance.World.EntityContainer = container;
							EditorEngine.Instance.HasEdit = true;
						}
					} catch (Exception exc) {
						MessageBox.Show("Error. Stacktrace: \n\n{0}".WithFormat(exc.Message),
						                "Importing Error",
						                MessageBoxButtons.OK,
						                MessageBoxIcon.Exclamation);
					}
				}
			}
			RefreshView();
		}

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e) {
			RefreshView();
		}

		public void RefreshView() {
			bExport.Enabled = false;

			lItems.Items.Clear();

			int tab = tabs.SelectedIndex;
			lItems.Dock = DockStyle.Fill;
			tabs.TabPages[tabs.SelectedIndex].Controls.Add(lItems);

			switch (tab) {
				case 0:
					foreach (Tileset sheet in EditorEngine.Instance.World.TilesetContainer) {
						lItems.Items.Add(sheet.Name);
					}
					break;
				case 1:
					foreach (EntityTemplate template in EditorEngine.Instance.World.EntityContainer.All()) {
						lItems.Items.Add(template.Name);
					}
					break;
			}

			bExportContainer.Enabled = lItems.Items.Count > 0;
		}

		private void lItems_SelectedIndexChanged(object sender, EventArgs e) {
			switch (tabs.SelectedIndex) {
				case 0:
					if (lItems.SelectedIndex >= 0 && lItems.SelectedIndex < EditorEngine.Instance.World.TilesetContainer.Count)
						textureViewerControl.Texture = EditorEngine.Instance.World.TilesetContainer[lItems.SelectedIndex].Texture.Texture;
					break;
				case 1:
					if (lItems.SelectedIndex >= 0 && lItems.SelectedIndex < EditorEngine.Instance.World.EntityContainer.All().Count)
						textureViewerControl.Texture = EditorEngine.Instance.World.EntityContainer.All()[lItems.SelectedIndex].Texture.Texture;
					break;
			}
		}

		private void lItems_DoubleClick(object sender, EventArgs e) {
			if (lItems.SelectedIndex < 0) return;
			switch (tabs.SelectedIndex) {
				case 0:
					Tileset tileset = EditorEngine.Instance.World.TilesetContainer[lItems.SelectedIndex];
					using (FrmTilesetEditor frm = new FrmTilesetEditor()) {
						frm.Tileset = tileset;
						if (frm.ShowDialog() == DialogResult.OK) {
							EditorEngine.Instance.World.TilesetContainer[lItems.SelectedIndex] = frm.Tileset;
							EditorEngine.Instance.HasEdit = true;
						}
					}
					break;
				case 1:
					EntityTemplate entity = EditorEngine.Instance.World.EntityContainer.All()[lItems.SelectedIndex];
					using (FrmEntityTemplateEditor frm = new FrmEntityTemplateEditor()) {
						frm.Template = entity;
						if (frm.ShowDialog() == DialogResult.OK) {
							EditorEngine.Instance.World.EntityContainer.All()[lItems.SelectedIndex] = frm.Template;
							EditorEngine.Instance.HasEdit = true;
						}
					}
					break;
			}
		}
	}
}