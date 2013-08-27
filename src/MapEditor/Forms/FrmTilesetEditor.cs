using System;
using System.Windows.Forms;
using GameEngine.Data.Tiles;
using General.Graphics;
using MapEditor.Data;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Forms {
	public partial class FrmTilesetEditor : Form {

		public Tileset Tileset {
			get {
				Tileset result = new Tileset(tbName.Text, EditorEngine.Instance.World.TilesetFactory);
				result.Texture = (TileableTexture) editor.Tileset.Texture.Clone();
				result.Tiles = editor.Tileset.Tiles;
				return result;
			}
			set {
				tbName.Text = value.Name;
				editor.Tileset = value;
			}
		}

		public FrmTilesetEditor() {
			InitializeComponent();
		}

		private void FrmTilesetEditor_Load(object sender, EventArgs e) {
			editor.vscrollbar = this.vScrollBar;
			editor.hscrollbar = this.hScrollBar;
		}

		private void b_texture_Click(object sender, EventArgs e) {
			using (OpenFileDialog dialog = new OpenFileDialog()) {
				dialog.Filter = ".png (*.png)|*.png";
				if (dialog.ShowDialog() == DialogResult.OK) {
					Texture2D texture = EditorEngine.Instance.LoadTexture(dialog.FileName);
					editor.LoadTileset("niggertonguemyanus!!", texture);
				}
			}
		}

		private void btnOK_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}

	}
}
