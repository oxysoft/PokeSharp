using System;
using System.IO;
using System.Windows.Forms;
using GameEngine.Data.Entities;
using GameEngine.Data.Entities.Core;
using General.Graphics;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Forms {
	public partial class FrmEntityTemplateEditor : Form {
		public EntityTemplate Template {
			get {
				control.Template.Name = tbName.Text;
				control.Template.EntityType = (EntityType) cbType.SelectedIndex;
				return control.Template;
			}
			set {
				tbName.Text = value.Name;
				control.Template = value;
				if (control.Template.Texture != null) bOK.Enabled = true;
				cbType.SelectedIndex = (Int32) value.EntityType;
			}
		}

		private void FrmEntityTemplateEditor_Load(object sender, EventArgs e) {
			//cbType.SelectedIndex = 1; //Default on Building Entity Type
			//cbMode.SelectedIndex = 1; //Default on Collision Map Editor
			//cbShadow.SelectedIndex = 1; //Default on Perspective Shadow
		}

		public FrmEntityTemplateEditor() {
			InitializeComponent();
		}

		private void b_importtexture_Click(object sender, EventArgs e) {
			using (OpenFileDialog dialog = new OpenFileDialog()) {
				dialog.Filter = "(*.png)|*.png";
				if (dialog.ShowDialog() == DialogResult.OK) {
					string loc = dialog.FileName;
					using (FileStream stream = File.OpenRead(loc)) {
						Texture2D fs = Texture2D.FromStream(control.GraphicsDevice, stream);
						Template.Texture = new TileableTexture(fs, (int) tbColumn.Value, (int) tbRows.Value);
						stream.Flush();
						stream.Close();
						stream.Dispose();
					}
					if (tbName.Text == string.Empty) {
						string name = loc.Split('\\')[loc.Split('\\').Length - 1].Split('.')[0];
						tbName.Text = name;
					}
				}
			}
			bOK.Enabled = true;
		}

		private void button1_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
		}

		private void button2_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
			control.Mode = cbMode.SelectedIndex;
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
		}

		private void label5_Click(object sender, EventArgs e) {
		}

		private void bEditAnimation_Click(object sender, EventArgs e) {
			using (FrmAnimationEditor form = new FrmAnimationEditor()) {
				form.TileableTexture = this.Template.Texture;
				form.Animations.AddRange(this.Template.Animations);

				if (form.ShowDialog() == DialogResult.OK) {
					Template.Animations.Clear();
					Template.Animations.AddRange(form.Animations);
				}
			}
		}

		private void tbColumn_ValueChanged(object sender, EventArgs e) {
			Template.Texture.Columns = (int) tbColumn.Value;
		}

		private void tbRow_ValueChanged(object sender, EventArgs e) {
			Template.Texture.Rows = (int) tbRows.Value;
		}

		private void bImporttexture_DragDrop(object sender, DragEventArgs e) {
			string loc = ((string[]) e.Data.GetData(DataFormats.FileDrop))[0];
			using (FileStream stream = File.OpenRead(loc)) {
				Texture2D fs = Texture2D.FromStream(control.GraphicsDevice, stream);
				Template.Texture = new TileableTexture(fs, (int) tbColumn.Value, (int) tbRows.Value);
			}
			if (tbName.Text == string.Empty) {
				string name = loc.Split('\\')[loc.Split('\\').Length - 1].Split('.')[0];
				tbName.Text = name;
			}
		}
	}
}