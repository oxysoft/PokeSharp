using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEngine.Data.Common;
using GameEngine.Data.Entities;
using GameEngine.Data.Entities.Core;
using GameEngine.Data.Scripting.UserInterface;
using GameEngine.Data.SpriteLibrary;
using GameEngine.Data.Tiles;
using GameEngine.Data.Tiles.Behaviors;
using General.Encoding;
using General.Graphics;
using MapEditor.Data;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Forms {
	public partial class FrmDatabase : Form {
		public FrmDatabase() {
			InitializeComponent();
		}

		private void FrmDatabase_Load(object sender, EventArgs e) {
			ReloadTilesetList();
			tilesetControl.vscrollbar = this.tilesetVScrollBar;
			tilesetControl.hscrollbar = this.tilesetHScrollBar;
			foreach (TileBehavior b in TileBehavior.Values) {
				cbTilesetTileBehavior.Items.Add(b.Name);
			}
			cbTilesetMode.SelectedIndex = 0;
			cbTilesetTileBehavior.SelectedIndex = 0;

			cbEntityMode.SelectedIndex = 0;

			spriteTree.Nodes[0].Tag = EditorEngine.Instance.World.SpriteLibrary;
			spriteTree.SelectedNode = spriteTree.Nodes[0];
			spriteControl.CenteredTexture = false;
		}

		#region General

		private bool forceProperLabel = false;

		private void tabControl_SelectedIndexChanged(object sender, EventArgs e) {
			switch (tabControl.SelectedIndex) {
				case 0:
					listTilesets.Items.Clear();
					foreach (Tileset tileset in EditorEngine.Instance.World.TilesetContainer) {
						ListViewItem item = new ListViewItem(tileset.Name);
						item.Tag = tileset;
						listTilesets.Items.Add(item);
					}
					break;

				case 1:
					listEntities.Items.Clear();
					foreach (EntityTemplate template in EditorEngine.Instance.World.EntityContainer.All()) {
						listEntities.Items.Add(template.Name);
					}
					break;

				case 2:
					spriteTree.Nodes[0].Nodes.Clear();

					//depth-first search algorithm
					Stack<TreeNode> stack = new Stack<TreeNode>();
					TreeNode lastRootNode = spriteTree.Nodes[0];

					stack.Push(spriteTree.Nodes[0]);

					while (stack.Count > 0) {
						TreeNode currentNode = stack.Pop();
						SpriteLibraryDirectory spritenode = (SpriteLibraryDirectory) currentNode.Tag;

						foreach (SpriteLibraryDirectory directory in spritenode.Directories) {
							TreeNode childNode = new TreeNode(directory.Name) {Tag = directory};
							currentNode.Nodes.Add(childNode);
							stack.Push(childNode);
						}

						foreach (SpriteLibrarySprite sprite in spritenode.Sprites)
							currentNode.Nodes.Add(new TreeNode(sprite.Name) {Tag = sprite, ImageKey = "image.png", SelectedImageKey = "image.png"});

						SortSpriteNode(currentNode);
					}
					break;

				case 12:
					listUis.Clear();
					foreach (UITemplate temp in EditorEngine.Instance.World.UIContainer) {
						listUis.Items.Add(new ListViewItem(temp.Name) {Tag = temp});
					}
					break;
			}
		}

		#endregion

		#region Entity tab

		public void ReloadEntityList() {
			listEntities.Items.Clear();
			foreach (EntityTemplate template in EditorEngine.Instance.World.EntityContainer.All()) {
				listEntities.Items.Add(template.Name);
			}
		}

		private void EnableEntityControls(bool enable) {
			tbEntityName.Enabled = enable;
			bEntityTextureImport.Enabled = enable;
			tbEntityColumns.Enabled = enable;
			tbEntityRows.Enabled = enable;
			cbEntityType.Enabled = enable;
			cbEntityShadowType.Enabled = enable;
			bEntityAnimation.Enabled = enable;
		}

		private void listEntities_SelectedIndexChanged(object sender, EventArgs e) {
			if (listEntities.SelectedIndices.Count > 0) {
				bRemoveEntity.Enabled = true;
				EntityTemplate sel = EditorEngine.Instance.World.EntityContainer.GetAt(listEntities.SelectedIndices[0]);
				this.entityControl.Template = sel;

				EnableEntityControls(true);

				tbEntityName.Text = sel.Name;
				tbEntityColumns.Value = sel.Texture.Columns;
				tbEntityRows.Value = sel.Texture.Rows;
				cbEntityType.SelectedIndex = (int) sel.EntityType;
				cbEntityShadowType.SelectedIndex = (int) sel.ShadowType;
			}
		}

		private void listEntities_MouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				if (listEntities.GetItemAt(e.X, e.Y) != null) {
					cMenuEntity.Show(Cursor.Position);
				} else {
				}
			}
		}

		private void cMenuEntity_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
			switch (e.ClickedItem.Text) {
				case "New":
					EntityTemplate tem = new EntityTemplate("Unnamed entity", EditorEngine.Instance.World.EntityTemplateFactory);
					tem.Texture = new TileableTexture(TileableTexture.EmptyTexture(EditorEngine.Instance.GraphicsDevice));
					EditorEngine.Instance.World.EntityContainer.Add(tem);
					listEntities.SelectedIndices.Clear();
					listEntities.Items.Add(new ListViewItem(tem.Name));
					listEntities.SelectedIndices.Add(listEntities.Items.Count - 1);
					break;
				case "Copy":
					break;
				case "Paste":
					break;
				case "Duplicate":
					break;
				case "Delete":
					EditorEngine.Instance.World.EntityContainer.RemoveAt(listEntities.SelectedIndices[0]);
					listEntities.Items.RemoveAt(listEntities.SelectedIndices[0]);
					break;
			}
		}

		private void bAddEntity_Click(object sender, EventArgs e) {
			EntityTemplate tem = new EntityTemplate("Unnamed entity", EditorEngine.Instance.World.EntityTemplateFactory);
			tem.Texture = new TileableTexture(TileableTexture.EmptyTexture(EditorEngine.Instance.GraphicsDevice));
			EditorEngine.Instance.World.EntityContainer.Add(tem);
			listEntities.SelectedIndices.Clear();
			listEntities.Items.Add(new ListViewItem(tem.Name));
			listEntities.SelectedIndices.Add(listEntities.Items.Count - 1);
		}

		private void bRemoveEntity_Click(object sender, EventArgs e) {
			int index = listEntities.SelectedIndices[0];
			foreach (Map map in EditorEngine.Instance.World.Maps) {
				for (int i = 0; i < map.Entities.Count; i++) {
					if (map.Entities[i].TemplateID == EditorEngine.Instance.World.EntityContainer.GetAt(index).ID) map.Entities.RemoveAt(i--);
				}
			}
			EditorEngine.Instance.World.EntityContainer.RemoveAt(index);
			ReloadEntityList();
			if (listEntities.Items.Count <= index)
				index -= 1;
			listEntities.SelectedIndices.Add(index);
		}

		private void tbEntityName_TextChanged(object sender, EventArgs e) {
			this.entityControl.Template.Name = tbEntityName.Text;
			this.listEntities.Items[listEntities.SelectedIndices[0]].Text = tbEntityName.Text;
		}

		private void bEntityTextureImport_Click(object sender, EventArgs e) {
			using (OpenFileDialog dialog = new OpenFileDialog()) {
				dialog.Filter = "Portable Network Graphics (*.png)|*.png";
				if (dialog.ShowDialog() == DialogResult.OK) {
					int cols = (int) tbEntityColumns.Value;
					int rows = (int) tbEntityRows.Value;
					Texture2D texture = Texture2D.FromStream(EditorEngine.Instance.GraphicsDevice, File.OpenRead(dialog.FileName));
					this.entityControl.Template.Texture = new TileableTexture(texture, cols, rows);
				}
			}
		}

		private void bEntityAnimation_Click(object sender, EventArgs e) {
			using (FrmAnimationEditor frm = new FrmAnimationEditor()) {
				frm.Animations = this.entityControl.Template.Animations;
				frm.TileableTexture = this.entityControl.Template.Texture;
				if (frm.ShowDialog() == DialogResult.OK) {
					this.entityControl.Template.Animations = frm.Animations;
				}
			}
		}

		private void cbEntityType_SelectedIndexChanged(object sender, EventArgs e) {
			entityControl.Template.EntityType = (EntityType) cbEntityType.SelectedIndex;
		}

		private void cbEntityShadowType_SelectedIndexChanged(object sender, EventArgs e) {
			entityControl.Template.ShadowType = (ShadowType) cbEntityShadowType.SelectedIndex;
		}

		private void tbEntityColumns_ValueChanged(object sender, EventArgs e) {
			entityControl.Template.Texture.Columns = (int) tbEntityColumns.Value;
		}

		private void tbEntityRows_ValueChanged(object sender, EventArgs e) {
			entityControl.Template.Texture.Rows = (int) tbEntityRows.Value;
		}

		private void cbEntityMode_SelectedIndexChanged(object sender, EventArgs e) {
			entityControl.Mode = cbEntityMode.SelectedIndex;
		}

		private void bEntitiesImport_Click(object sender, EventArgs e) {
			using (OpenFileDialog dialog = new OpenFileDialog()) {
				dialog.Filter = "Entity container (*.pcon)|*.pcon";
				if (dialog.ShowDialog() == DialogResult.OK) {
					using (FrmResourceImport dialog2 = new FrmResourceImport()) {
						if (dialog2.ShowDialog() == DialogResult.OK) {
							EntityContainer container = EncoderUtil.Decode<EntityContainer>(dialog.FileName, EditorEngine.Instance.GraphicsDevice);
							foreach (EntityTemplate template in container.All()) {
								template.ID = EditorEngine.Instance.World.EntityTemplateFactory.AllocateID();
							}
							if (dialog2.Mode == 0) {
								EditorEngine.Instance.World.EntityContainer.Clear();
							}
							foreach (EntityTemplate template in container.All()) {
								EditorEngine.Instance.World.EntityContainer.Add(template);
							}
							ReloadEntityList();
						}
					}
				}
			}
		}

		private void bEntitiesExport_Click(object sender, EventArgs e) {
			using (FrmResourceExport dialogs = new FrmResourceExport(EditorEngine.Instance.World.EntityContainer, 1)) {
				if (dialogs.ShowDialog() == DialogResult.OK) {
					using (SaveFileDialog dialog = new SaveFileDialog()) {
						dialog.Filter = "Entity Container (*.pcon)|*.pcon";
						if (dialog.ShowDialog() != DialogResult.OK) return;
						EncoderUtil.Encode(dialog.FileName, dialogs.EntityContainer);
					}
				}
			}
		}

		#endregion

		#region Sprite Library tab

		private bool _spTypeSel = false;
		private bool _spSortSel = false;

		private delegate void sortSprite(TreeNode node);

		private void SortSpriteNode(TreeNode node) {
			ISpriteLibraryNode item = node.Tag as ISpriteLibraryNode;

			if (item.Root) {
				node.ImageKey = "box.png";
				node.SelectedImageKey = "box.png";
			} else if (item is SpriteLibrarySprite) {
				node.ImageKey = "image.png";
				node.SelectedImageKey = "image.png";
			} else if (item is SpriteLibraryDirectory) {
				node.ImageKey = "folder.png";
				node.SelectedImageKey = "folder.png";
			}

			if (!_spSortSel) {
				_spSortSel = true;
				List<TreeNode> sorted = node.Nodes.Cast<TreeNode>().ToList();
				sorted.Sort(new SpriteTreeSorter());
				node.Nodes.Clear();
				node.Nodes.AddRange(sorted.ToArray());
				_spSortSel = false;
			}
		}

		private void btnNewSprite_Click(object sender, EventArgs e) {
			if (spriteTree.SelectedNode == null)
				spriteTree.SelectedNode = spriteTree.Nodes[0];

			if (spriteTree.SelectedNode.Tag is SpriteLibrarySprite)
				spriteTree.SelectedNode = spriteTree.SelectedNode.Parent;

			SpriteLibrarySprite sprite = new SpriteLibrarySprite();
			sprite.Parent = spriteTree.SelectedNode.Tag as SpriteLibraryDirectory;
			sprite.Deletable = true;

			TreeNode node = new TreeNode(sprite.Name);
			node.Tag = sprite;
			node.ImageKey = "image.png";
			node.SelectedImageKey = "image.png";

			spriteTree.SelectedNode.Nodes.Add(node);
			(spriteTree.SelectedNode.Tag as SpriteLibraryDirectory).Add(sprite);

			SortSpriteNode(node.Parent);

			spriteTree.SelectedNode = node;
			spriteTree.SelectedNode.Expand();

			forceProperLabel = true;
			node.BeginEdit();
		}

		private void btnRemoveSprite_Click(object sender, EventArgs e) {
			ISpriteLibraryNode tag = spriteTree.SelectedNode.Tag as ISpriteLibraryNode;

			tag.Parent.Remove(tag);
			spriteTree.SelectedNode.Parent.Nodes.Remove(spriteTree.SelectedNode);
		}

		private void tSpriteLibrary_AfterSelect(object sender, TreeViewEventArgs e) {
			ISpriteLibraryNode node = (e.Node.Tag as ISpriteLibraryNode);
			bool changeable = !node.Unchangeable;
			bool deletable = node.Deletable;
			bool root = node.Root;

			//tbSpriteName.Enabled = changeable && !root;
			tbSpriteName.Enabled = false;
			tbSpriteType.Enabled = changeable && !root;
			btnImportSprite.Enabled = true && !root;
			btnRemoveSprite.Enabled = deletable && !root;
			_spTypeSel = true;
			if (root) {
				tbSpriteName.Text = "Root";
				tbSpriteType.SelectedIndex = 1;
				spriteControl.Texture = null;
			} else {
				tbSpriteName.Text = node.Name;

				if (node is SpriteLibrarySprite) tbSpriteType.SelectedIndex = 0;
				else if (node is SpriteLibraryDirectory) tbSpriteType.SelectedIndex = 1;

				if (node is SpriteLibrarySprite) spriteControl.Texture = (node as SpriteLibrarySprite).Texture;
				else spriteControl.Texture = null;
			}
			_spTypeSel = false;
		}

		private void tSpriteLibrary_AfterExpand(object sender, TreeViewEventArgs e) {
			if (e.Node.Parent == null) return;
			e.Node.ImageKey = "folder-open.png";
			e.Node.SelectedImageKey = "folder-open.png";
		}

		private void tSpriteLibrary_AfterCollapse(object sender, TreeViewEventArgs e) {
			if (e.Node.Parent == null) return;
			e.Node.ImageKey = "folder.png";
			e.Node.SelectedImageKey = "folder.png";
		}

		private void tSpriteLibrary_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e) {
			if (e.Node.Parent == null) e.CancelEdit = true;
		}

		private void tSpriteLibrary_AfterLabelEdit(object sender, NodeLabelEditEventArgs e) {
			if (!_spSortSel) {
				bool bad = false;
				// || e.Label.All(c => c == ' ')
				if (e.Label == null) Console.WriteLine("null");
				else Console.WriteLine("'" + e.Label + "'");

				if (e.Label == null) {
					//No changes
					return;
				}
				if (string.IsNullOrWhiteSpace(e.Label)) {
					MessageBox.Show("Are you racist or something?", "Easter Egg", MessageBoxButtons.OK, MessageBoxIcon.Question);
					bad = true;
					goto cancel;
				}
				if (!(e.Node.Parent.Tag as SpriteLibraryDirectory).TokenValid(e.Label)) {
					MessageBox.Show("You can only use alphanumeric characters and numbers \r1\n(Exceptions: ':', '/', '%', '(', ')', '<', '>', '$', '#' and '_')", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					bad = true;
					goto cancel;
				}
				if (!(e.Node.Parent.Tag as SpriteLibraryDirectory).TokenFree(e.Label)) {
					MessageBox.Show("Another member already has this Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					bad = true;
				}
				cancel:
				if (bad) {
					e.CancelEdit = true;
					if (forceProperLabel) {
						spriteTree.BeginInvoke(new Action(e.Node.BeginEdit));
					}
					return;
				}
				_spTypeSel = true;
				(spriteTree.SelectedNode.Tag as ISpriteLibraryNode).Name = e.Label;
				tbSpriteName.Text = e.Label;
				spriteTree.BeginInvoke(new sortSprite(SortSpriteNode), e.Node.Parent);
				forceProperLabel = false;
			}
		}

		private int currentSpriteType = 0;

		private void tbSpriteType_Enter(object sender, EventArgs e) {
			currentSpriteType = tbSpriteType.SelectedIndex;
		}

		private void tbSpriteType_SelectedIndexChanged(object sender, EventArgs e) {
			if (!_spTypeSel) {
				if (tbSpriteType.SelectedIndex != currentSpriteType) {
					currentSpriteType = tbSpriteType.SelectedIndex;
					switch (tbSpriteType.SelectedIndex) {
						case 0: //Directory --> Sprite
							SpriteLibraryDirectory old = spriteTree.SelectedNode.Tag as SpriteLibraryDirectory;
							SpriteLibrarySprite res = new SpriteLibrarySprite(old);

							spriteTree.SelectedNode.Tag = res;

							spriteControl.Texture = null;
							spriteTree.SelectedNode.ImageKey = "image.png";
							spriteTree.SelectedNode.SelectedImageKey = "image.png";
							btnImportSprite.Enabled = true;

							SortSpriteNode(spriteTree.SelectedNode.Parent);
							break;
						case 1: //Sprite --> Directory
							SpriteLibrarySprite _old = spriteTree.SelectedNode.Tag as SpriteLibrarySprite;
							SpriteLibraryDirectory _res = new SpriteLibraryDirectory(_old);

							_old.Parent.Remove(_old);
							_old.Parent.Add(_res);

							spriteTree.SelectedNode.Tag = _res;
							spriteTree.SelectedNode.ImageKey = "folder.png";
							spriteTree.SelectedNode.SelectedImageKey = "folder.png";
							spriteControl.Texture = null;
							btnImportSprite.Enabled = false;

							SortSpriteNode(spriteTree.SelectedNode.Parent);
							break;
					}
				}
				spriteControl.Texture = null;
			}
		}

		private void btnImportSprite_Click(object sender, EventArgs e) {
			using (OpenFileDialog dialog = new OpenFileDialog()) {
				dialog.Filter = "Portable Image Graphics (*.png)|*.png";
				if (dialog.ShowDialog() == DialogResult.OK) {
					Texture2D texture = Texture2D.FromStream(EditorEngine.Instance.GraphicsDevice, File.OpenRead(dialog.FileName));
					(spriteTree.SelectedNode.Tag as SpriteLibrarySprite).Texture = texture;
					spriteControl.Texture = texture;
				}
			}
		}

		#endregion

		#region User Interface tab

		private void bAddUI_Click(object sender, EventArgs e) {
			UITemplate template = new UITemplate();
			template.Name = "Rename me";
			template.Code = template.DefaultCode();
			EditorEngine.Instance.World.UIContainer.Add(template);

			ListViewItem item = new ListViewItem {Text = template.Name, Tag = template};
			listUis.Items.Add(item);
		}

		private void bRemoveUI_Click(object sender, EventArgs e) {
			if (listUis.SelectedItems.Count <= 0) return;

			foreach (ListViewItem item in listUis.Items) {
				UITemplate template = item.Tag as UITemplate;
				EditorEngine.Instance.World.UIContainer.Remove(template);
				listUis.Items.Remove(item);

				UITemplate current = uiScriptBox.Tag as UITemplate;
				if (current != template) continue;

				uiScriptBox.Text = "";
				uiScriptBox.Tag = null;
				uiScriptBox.ReadOnly = true;
				uiScriptBox.Enabled = false;
			}
		}

		private void listUis_BeforeLabelEdit(object sender, LabelEditEventArgs e) {
		}

		private void listUis_AfterLabelEdit(object sender, LabelEditEventArgs e) {
			if (EditorEngine.Instance.World.UIContainer.NameTaken(e.Label)) {
				MessageBox.Show("This Name has already been assigned to another script", "Error");
				e.CancelEdit = true;
				return;
			}
			EditorEngine.Instance.World.UIContainer.Get(listUis.Items[e.Item].Tag as UITemplate).Name = e.Label;
		}

		private void listUis_MouseClick(object sender, MouseEventArgs e) {
			ListViewItem item = listUis.GetItemAt(e.X, e.Y);
			if (item == null) return;
			uiScriptBox.Enabled = true;
			uiScriptBox.ReadOnly = false;
			uiScriptBox.Tag = item.Tag;
			uiScriptBox.Text = (item.Tag as UITemplate).Code;
		}

		private void uiScriptBox_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e) {
			if ((uiScriptBox.Tag as UITemplate) == null) return;
			(uiScriptBox.Tag as UITemplate).Code = uiScriptBox.Text;
			EditorEngine.Instance.HasEdit = true;
		}

		#endregion

		#region Tileset tab

		public void ReloadTilesetList() {
			listTilesets.Items.Clear();
			foreach (Tileset tileset in EditorEngine.Instance.World.TilesetContainer) {
				ListViewItem item = new ListViewItem(tileset.Name);
				item.Tag = tileset;
				listTilesets.Items.Add(item);
			}
		}

		public void EnableTilesetControls(bool enable) {
			bRemoveTileset.Enabled = enable;
			cbTilesetTileBehavior.Enabled = enable;
			tbTilesetName.Enabled = enable;
			bTilesetImport.Enabled = enable;
		}

		private void bTilesetImport_Click(object sender, EventArgs e) {
			using (OpenFileDialog dialog = new OpenFileDialog()) {
				retry:
				dialog.Filter = "portable network graphics (*.png)|*.png";
				if (dialog.ShowDialog() == DialogResult.OK) {
					Image bit = Image.FromFile(dialog.FileName);
					if (bit.Width > 192) {
						MessageBox.Show("The maximum width for a tileset is 192 (or 12 Tiles per row)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						goto retry;
					}
					Texture2D texture = Texture2D.FromStream(EditorEngine.Instance.GraphicsDevice, File.OpenRead(dialog.FileName));
					tilesetControl.LoadTileset("sand nigger", texture);
				}
			}
		}

		private void listTilesets_SelectedIndexChanged(object sender, EventArgs e) {
			EnableTilesetControls(true);
			if (listTilesets.SelectedItems.Count == 0) {
				EnableTilesetControls(false);
				tbTilesetName.Text = "";
				tilesetControl.Tileset = null;
				return;
			}

			Tileset t = listTilesets.SelectedItems[0].Tag as Tileset;
			tbTilesetName.Text = t.Name;
			tilesetControl.Tileset = t;
		}

		private void bAddTileset_Click(object sender, EventArgs e) {
			string name = "New tileset";
			Tileset tileset = new Tileset(name, EditorEngine.Instance.World.TilesetFactory);
			ListViewItem item = new ListViewItem(name);
			item.Tag = tileset;
			EditorEngine.Instance.World.TilesetContainer.Add(tileset);
			listTilesets.Items.Add(item);
			listTilesets.SelectedItems.Clear();
			listTilesets.SelectedIndices.Add(listTilesets.Items.Count - 1);
		}

		private void bRemoveTileset_Click(object sender, EventArgs e) {
			Tileset t = listTilesets.SelectedItems[0].Tag as Tileset;
			EditorEngine.Instance.World.TilesetContainer.Remove(t);
			listTilesets.Items.Remove(listTilesets.SelectedItems[0]);
		}

		private void tbTilesetName_TextChanged(object sender, EventArgs e) {
			if (listTilesets.SelectedItems.Count == 0) {
				return;
			}
			(listTilesets.SelectedItems[0].Tag as Tileset).Name = tbTilesetName.Text;
			listTilesets.SelectedItems[0].Text = tbTilesetName.Text;
		}

		private void cbTilesetTileBehavior_SelectedIndexChanged(object sender, EventArgs e) {
			this.tilesetControl.Behavior = (byte) cbTilesetTileBehavior.SelectedIndex;
		}

		private void cbTilesetMode_SelectedIndexChanged(object sender, EventArgs e) {
			this.tilesetControl.Mode = cbTilesetMode.SelectedIndex;
		}

		#endregion
	}

	public class SpriteTreeSorter : IComparer<TreeNode> {
		public int Compare(TreeNode x, TreeNode y) {
			string n1 = (x.Tag as ISpriteLibraryNode).Name;
			string n2 = (y.Tag as ISpriteLibraryNode).Name;

			if (x.Tag is SpriteLibrarySprite && y.Tag is SpriteLibrarySprite) {
				return string.Compare(n1, n2);
			} else if (x.Tag is SpriteLibraryDirectory && y.Tag is SpriteLibraryDirectory) {
				return string.Compare(n1, n2);
			} else if (x.Tag is SpriteLibraryDirectory && y.Tag is SpriteLibrarySprite) {
				return -1;
			} else if (x.Tag is SpriteLibrarySprite && y.Tag is SpriteLibraryDirectory) {
				return 1;
			}

			return 0;
		}
	}
}