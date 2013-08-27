using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AeonEditor.Forms;
using GameEngine.Data.Common;
using GameEngine.Data.GameLoader;
using GameEngine.Data.Tiles;
using MapEditor.CopyPaste;
using MapEditor.Data;
using MapEditor.Data.Actions;
using MapEditor.Forms.Form_Regions;
using MapEditor.Forms.Form_Tools;
using MapEditor.States;
using MapEditor.States.BehaviorEditor;
using MapEditor.States.EntityEditor;
using MapEditor.States.EventEditor;
using MapEditor.States.General;
using MapEditor.States.PermissionEditor;
using MapEditor.States.TileEditor;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor.Forms {
	public partial class FrmMainEditor : Form {
		public string GameLocation;
		public const string WindowTitle = "PokeSharp Game Editor";

		public FrmMainEditor() {
			InitializeComponent();

			editorcontrol.MouseMove += onMouseMoveEngine;
			editorcontrol.MouseEnter += onMouseEnterEngine;
			editorcontrol.MouseLeave += onMouseLeaveEngine;

			imageList1.ColorDepth = ColorDepth.Depth32Bit;

			Options.Instance.Load();
		}

		private void FrmMainEditor_Load(object sender, EventArgs e) {
			lMaps.Nodes[0].ImageKey = "box.png";
			tbcMap.Visible = false;
		}

		public void onMouseMoveEngine(object sender, EventArgs e) {
			if (EditorEngine.Instance.World != null) {
				//GameConsole.WriteLine("x: {0}, y: {1}", c.pos.X, c.pos.Y);
			}
		}

		private void onMouseEnterEngine(object sender, EventArgs e) {
			EditorEngine.Instance.MouseEnter(e);
		}

		private void onMouseLeaveEngine(object sender, EventArgs e) {
			EditorEngine.Instance.MouseLeave(e);
		}

		protected override void OnShown(EventArgs e) {
			GraphicsDevice graphicsdevice = this.editorcontrol.GraphicsDevice;
			IServiceProvider services = this.editorcontrol.Services;

			EditorEngine.Instance.Initialize(editorcontrol, graphicsdevice, services);

			/*if (MapEditor.Config.Default.firstTimeRunning) {
				using (FrmAnnoyingPrompt form = new FrmAnnoyingPrompt()) {
					form.ShowDialog();
				}
				MapEditor.Config.Default.firstTimeRunning = false;
				Config.Default.Save();
			}*/

			CopyPasteManager.Instance.Initialize(this);

			StartupState.Instance.Initialize(this);
			TileEditorState.Instance.Initialize(this);
			EntityEditorState.Instance.Initialize(this);
			EventEditorState.Instance.Initialize(this);
			PermissionEditorState.Instance.Initialize(this);
			BehaviorEditorState.Instance.Initialize(this);

			EditorEngine.Instance.StateMachine.ChangeState(StartupState.Instance);

			spinLayer.Value = (decimal) 0;

			base.OnShown(e);
		}

		public void LoadProject(string loc, Project proj) {
			GameLocation = loc;
			EnableRegionControls(true);
			lMaps.Nodes[0].Text = EditorEngine.Instance.World.Name;
			this.Text = EditorEngine.Instance.World.Name + " - " + WindowTitle;
			foreach (TreeNode node in proj.RootNode.Nodes) {
				lMaps.Nodes[0].Nodes.Add(node);
				if (node.Tag is Map) {
					EditorEngine.Instance.World.Maps.Add(node.Tag as Map);
				}
			}
		}

		public void UnloadProject() {
			EnableRegionControls(false);
			EnableMapControls(false);
			this.Text = WindowTitle;

			lMaps.Nodes[0].Nodes.Clear();
		}

		public void EnableRegionControls(bool enable) {
			bSave.Enabled = enable;
			bSaveAs.Enabled = enable;
			bDumpGame.Enabled = enable;

			bSpriteIndexFinder.Enabled = enable;
			bTilesetChopper.Enabled = enable;
			bPictureChopper.Enabled = enable;

			bResources.Enabled = enable;
			bDatabase.Enabled = enable;
			bPlayWorld.Enabled = enable;

			bNewMap.Enabled = enable;
			bNewMapFolder.Enabled = enable;

			lMaps.Visible = enable;
			splitContainer1.Visible = enable;
		}

		public void EnableMapControls(bool enable) {
			bUndo.Enabled = enable;
			bRedo.Enabled = enable;
			bUndoRedoList.Enabled = enable;
			bUndo2.Enabled = enable;
			bRedo2.Enabled = enable;
			bUndoRedoList2.Enabled = enable;
			bZoomfit.Enabled = enable;
			bZoomOut.Enabled = enable;
			bZoomIn.Enabled = enable;

			bTiles.Enabled = enable;
			bEntities.Enabled = enable;

			tbcMap.Visible = enable;
		}

		private void FrmMainEditor_FormClosing(object sender, FormClosingEventArgs e) {
			if (EditorEngine.Instance.HasEdit) {
				DialogResult result = MessageBox.Show("You have made some edits to this project that have not been saved. Would you like to save them now?", "Unsaved modifications", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				if (result == DialogResult.Cancel) {
					e.Cancel = true;
					return;
				}
				if (result == DialogResult.Yes) {
					string loc = GameLocation;
					if (String.IsNullOrWhiteSpace(loc)) {
						using (SaveFileDialog dialog = new SaveFileDialog()) {
							dialog.Filter = "PokeSharp Project (*.psproj)|*.psproj";
							if (dialog.ShowDialog() == DialogResult.OK) {
								loc = dialog.FileName;
							}
						}
					}
					if (!String.IsNullOrWhiteSpace(loc)) {
						Project.CurrentProject.Save(loc, lMaps);
					} else return;
				}
			}
			GameLocation = null;
			EnableMapControls(false);
			EnableRegionControls(false);
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
			switch (keyData) {
				case Keys.F1:
					bTiles.PerformClick();
					break;
				case Keys.F2:
					bEntities.PerformClick();
					break;
				case Keys.S:
					if (bEntities.Checked) {
						//b_entityselect.Click();
					}
					break;
				case Keys.M:
					if (bEntities.Checked) {
						//eMove.PerformClick();
					}
					break;
				case Keys.Delete:
					if (bEntities.Checked) {
						//eDelete.PerformClick();
					}
					break;
				case Keys.Control | Keys.C:
					if (bEntities.Checked) {
						CopyPasteManager.Instance.Copy();
					}
					break;
				case Keys.Control | Keys.V:
					if (bEntities.Checked) {
						CopyPasteManager.Instance.Paste();
						//eMove.PerformClick();
					}
					break;
				case Keys.Control | Keys.X:
					if (bEntities.Checked) {
						CopyPasteManager.Instance.Copy();
						//eDelete.PerformClick();
					}
					break;
				case Keys.Control | Keys.Z:
					bUndo.PerformClick();
					break;
				case Keys.Control | Keys.Y:
					bRedo.PerformClick();
					break;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		private void b_hand_MouseClick(object sender, EventArgs e) {
			if (bTiles.Checked)
				TileEditorState.Instance.ToolStates.ChangeState(MoveTool.Instance);
			else if (bEntities.Checked)
				EntityEditorState.Instance.ToolStates.ChangeState(MoveTool.Instance);
		}

		private void b_pencil_MouseClick(object sender, EventArgs e) {
			TileEditorState.Instance.ToolStates.ChangeState(PencilTool.Instance);
		}

		private void b_eraser_MouseClick(object sender, EventArgs e) {
			TileEditorState.Instance.ToolStates.ChangeState(EraserTool.Instance);
		}

		private void b_rectangle_MouseClick(object sender, EventArgs e) {
			TileEditorState.Instance.ToolStates.ChangeState(RectangleTool.Instance);
		}

		private void b_bucket_MouseClick(object sender, EventArgs e) {
			TileEditorState.Instance.ToolStates.ChangeState(BucketTool.Instance);
		}

		private void b_logic_MouseClick(object sender, EventArgs e) {
			TileEditorState.Instance.ToolStates.ChangeState(LogicBrushTool.Instance);
		}

		private void b_entityadd_MouseClick(object sender, EventArgs e) {
			EntityEditorState.Instance.ToolStates.ChangeState(EntityAddTool.Instance);
		}

		private void b_entityselect_MouseClick(object sender, EventArgs e) {
			EntityEditorState.Instance.ToolStates.ChangeState(EntitySelectionTool.Instance);
		}

		private void b_entityrectangle_Click(object sender, EventArgs e) {
			EntityEditorState.Instance.ToolStates.ChangeState(EntityRectangleTool.Instance);
		}

		private void b_entityselectall_MouseClick(object sender, EventArgs e) {
			EntityEditorState.Instance.ToolStates.ChangeState(EntitySelectAllTool.Instance);
		}

		private void b_entitymove_MouseClick(object sender, EventArgs e) {
			EntityEditorState.Instance.ToolStates.ChangeState(EntityMoveTool.Instance);
		}

		private void b_entityremove_MouseClick(object sender, EventArgs e) {
			EntityEditorState.Instance.ToolStates.ChangeState(EntityRemoveTool.Instance);
		}

		private void bOpenRegion_Click(object sender, EventArgs e) {
			if (EditorEngine.Instance.HasEdit) {
				DialogResult result = MessageBox.Show("You have made some edits to this project that have not been saved. Would you like to save them now?", "Unsaved modifications", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				if (result == DialogResult.Cancel) return;
				if (result == DialogResult.Yes) {
					string loc = GameLocation;
					if (String.IsNullOrWhiteSpace(loc)) {
						using (SaveFileDialog savedialog = new SaveFileDialog()) {
							savedialog.Filter = "PokeSharp Project (*.psproj)|*.psproj";
							if (savedialog.ShowDialog() == DialogResult.OK) {
								loc = savedialog.FileName;
							}
						}
					}
					if (!String.IsNullOrWhiteSpace(loc)) {
						Project.CurrentProject.Save(loc, lMaps);
					} else return;
				}
			}
			GameLocation = null;
			UnloadProject();

			using (OpenFileDialog opendialog = new OpenFileDialog()) {
				opendialog.Filter = "PokeSharp Project (*.psproj)|*.psproj";
				DialogResult openresult = opendialog.ShowDialog();
				if (openresult == DialogResult.OK) {
					LoadProject(opendialog.FileName, Project.Load(opendialog.FileName));
				}
			}
		}

		private void bDefaultRegion_Click(object sender, EventArgs e) {
			if (EditorEngine.Instance.HasEdit) {
				DialogResult result = MessageBox.Show("You have made some edits to this project that have not been saved. Would you like to save them now?", "Unsaved modifications", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				if (result == DialogResult.Cancel) return;
				if (result == DialogResult.Yes) {
					string loc = GameLocation;
					if (String.IsNullOrWhiteSpace(loc)) {
						using (SaveFileDialog savedialog = new SaveFileDialog()) {
							savedialog.Filter = "PokeSharp Project (*.psproj)|*.psproj";
							if (savedialog.ShowDialog() == DialogResult.OK) {
								loc = savedialog.FileName;
							}
						}
					}
					if (!String.IsNullOrWhiteSpace(loc)) {
						Project.CurrentProject.Save(loc, lMaps);
					} else return;
				}
			}
			GameLocation = null;
			UnloadProject();

			if (!String.IsNullOrEmpty(Options.Instance.DefaultProject)) {
				LoadProject(Options.Instance.DefaultProject, Project.Load(Options.Instance.DefaultProject));
			} else MessageBox.Show("You do not have any default project set. Go in the settings to set one.");
		}

		private void bSave_Click(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(GameLocation)) {
				using (SaveFileDialog dialog = new SaveFileDialog()) {
					dialog.Filter = "PokeSharp Project (*.psproj)|*.psproj";
					if (dialog.ShowDialog() == DialogResult.OK)
						GameLocation = dialog.FileName;
					else return;
				}
			}
			try {
				Project.CurrentProject.Save(GameLocation, lMaps);
				EditorEngine.Instance.HasEdit = false;
			} catch (Exception exc) {
				MessageBox.Show("There was an error trying to save the game");
			}
		}

		private void bSaveAs_Click(object sender, EventArgs e) {
			using (SaveFileDialog dialog = new SaveFileDialog()) {
				dialog.Filter = "PokeSharp Project (*.psproj)|*.psproj";
				if (dialog.ShowDialog() == DialogResult.OK) {
					GameLocation = dialog.FileName;
					Project.CurrentProject.Save(dialog.FileName, lMaps);
				}
			}
		}

		private void bCloseProject_Click(object sender, EventArgs e) {
			if (EditorEngine.Instance.HasEdit) {
				DialogResult result = MessageBox.Show("You have made some edits to this project that have not been saved. Would you like to save them now?", "Unsaved modifications", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				if (result == DialogResult.Cancel) return;
				if (result == DialogResult.Yes) {
					string loc = GameLocation;
					if (String.IsNullOrWhiteSpace(loc)) {
						using (SaveFileDialog dialog = new SaveFileDialog()) {
							dialog.Filter = "PokeSharp Project (*.psproj)|*.psproj";
							if (dialog.ShowDialog() == DialogResult.OK) {
								loc = dialog.FileName;
							}
						}
					}
					if (!String.IsNullOrWhiteSpace(loc)) {
						Project.CurrentProject.Save(loc, lMaps);
					} else return;
				}
			}
			GameLocation = null;
			EnableMapControls(false);
			EnableRegionControls(false);
		}

		private void bMapSnapshot_Click(object sender, EventArgs e) {
			using (SaveFileDialog dialog = new SaveFileDialog()) {
				dialog.Filter = "Image (*.png)|*.png";
				if (dialog.ShowDialog() == DialogResult.OK) {
					EditorEngine.Instance.SavePictureOfMap(dialog.FileName);
				}
			}
		}

		private void bDumpGame_Click(object sender, EventArgs e) {
			using (SaveFileDialog dialog = new SaveFileDialog()) {
				dialog.Filter = "PokeSharp Game (*.psg)|*.psg"; //poke/sharp/game
				if (dialog.ShowDialog() == DialogResult.OK) {
					EditorEngine.Instance.World.Maps.Clear();
					Stack<TreeNode> stack = new Stack<TreeNode>();

					foreach (TreeNode node in lMaps.Nodes.Cast<TreeNode>().Reverse<TreeNode>())
						stack.Push(node);

					while (stack.Count > 0) {
						TreeNode node = stack.Pop();
						foreach (TreeNode n in node.Nodes.Cast<TreeNode>().Reverse<TreeNode>())
							stack.Push(n);
						if (node.Tag is Map)
							EditorEngine.Instance.World.Maps.Add(node.Tag as Map);
					}

					GameData.DumpGame(EditorEngine.Instance.World, dialog.FileName);

					EditorEngine.Instance.World.Maps.Clear();
				}
			}
		}

		private void bExit_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void bUndo_Click(object sender, EventArgs e) {
			EditorEngine.Instance.GetActionManager().Undo();
		}

		private void bRedo_Click(object sender, EventArgs e) {
			EditorEngine.Instance.GetActionManager().Redo();
		}

		private void bUndoRedoList_Click(object sender, EventArgs e) {
			FrmUndoRedoList.Instance.Show();
		}

		private void bOptions_Click(object sender, EventArgs e) {
			using (FrmSettings frm = new FrmSettings()) {
				if (frm.ShowDialog() == DialogResult.OK) {
					Options.Instance.DefaultProject = frm.DefProjLoc;
				}
			}
		}

		private void bGrid_Click(object sender, EventArgs e) {
		}

		private void bSpriteIndexFinder_Click(object sender, EventArgs e) {
			using (FrmTileIndexHelper frm = new FrmTileIndexHelper()) {
				frm.Owner = this;
				frm.ShowDialog();
			}
		}

		private void bTilesetChopper_Click(object sender, EventArgs e) {
			using (FrmTilesetUtil frm = new FrmTilesetUtil()) {
				frm.ShowDialog();
			}
		}

		private void bPictureChopper_Click(object sender, EventArgs e) {
			using (FrmPictureChopper frm = new FrmPictureChopper()) {
				frm.ShowDialog();
			}
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
		}

		private void creditsToolStripMenuItem_Click(object sender, EventArgs e) {
			FrmAbout frm = new FrmAbout();
			frm.ShowDialog();
		}

		private void bNewMap_Click(object sender, EventArgs e) {
			using (FrmNewMap form = new FrmNewMap()) {
				DialogResult result = form.ShowDialog();

				if (result == DialogResult.OK) {
					string name = form.MapName;
					int w = form.MapWidth;
					int h = form.MapHeight;
					List<string> tilesets = form.MapTilesetContainers;

					Map newmap = EditorEngine.Instance.CreateMap(name, w, h, tilesets);

					TreeNode node = new TreeNode(newmap.Name);
					node.Tag = newmap;
					node.ImageKey = "document.png";
					node.SelectedImageKey = "document.png";
					lMaps.SelectedNode.Nodes.Add(node);
					lMaps.SelectedNode = node;

					FrmTilesetSelector.Instance.RefreshTilesets();
					EditorEngine.Instance.StateMachine.ChangeState(TileEditorState.Instance);

					EditorEngine.Instance.HasEdit = true;
					FrmUndoRedoList.Instance.MapSwapped();
					EnableMapControls(true);
				}
			}
		}

		private void bNewMapFolder_Click(object sender, EventArgs e) {
			if (lMaps.SelectedNode == null) lMaps.SelectedNode = lMaps.Nodes[0];
			if (lMaps.SelectedNode.Tag is Map) lMaps.SelectedNode = lMaps.SelectedNode.Parent;

			TreeNode node = new TreeNode("New folder");
			lMaps.SelectedNode.Nodes.Add(node);
			if (!lMaps.SelectedNode.IsExpanded) lMaps.SelectedNode.Expand();
			node.ImageKey = "folder.png"; //closed folder
			node.SelectedImageKey = "folder.png"; //closed
			EditorEngine.Instance.HasEdit = true;
		}

		private void lMaps_MouseUp(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				// Select the clicked node
				lMaps.SelectedNode = lMaps.GetNodeAt(e.X, e.Y);

				if (lMaps.SelectedNode != null) {
					cMenulMaps.Show(lMaps, e.Location);
				}
			}
		}

		private void lMaps_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
			if (e.Node.Parent != null && e.Node.Tag as Map == null) {
				e.Node.ImageKey = "folder-closed.png"; //open folder
				e.Node.SelectedImageKey = "folder-closed.png"; //open folder
			}
		}

		private void lMaps_BeforeCollapse(object sender, TreeViewCancelEventArgs e) {
			if (e.Node.Parent != null && e.Node.Tag as Map == null) {
				e.Node.ImageKey = "folder-closed.png"; //open folder
				e.Node.SelectedImageKey = "folder-closed.png"; //open folder
			}
		}

		private void lMaps_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
		}

		private void lMaps_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
			if (lMaps.SelectedNode != null) {
				Map res = lMaps.SelectedNode.Tag as Map;
				if (res != null) {
					EnableMapControls(true);
					EditorEngine.Instance.CurrentMap = res;
					FrmTilesetSelector.Instance.RefreshTilesets();
					FrmUndoRedoList.Instance.MapSwapped();
					EditorEngine.Instance.StateMachine.ChangeState(EntityEditorState.Instance);
					EditorEngine.Instance.StateMachine.ChangeState(TileEditorState.Instance);
				}
			}
		}

		private void bNewRegion_Click(object sender, EventArgs e) {
			using (FrmNewRegion form = new FrmNewRegion()) {
				DialogResult result = form.ShowDialog();

				if (result == DialogResult.OK) {
					World world = EditorEngine.Instance.CreateRegion(form.RegionName);
					lMaps.Nodes[0].Text = world.Name;
					EditorEngine.Instance.HasEdit = true;
					EnableRegionControls(true);
				}
			}
		}

		private void lMaps_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e) {
			if (lMaps.SelectedNode.Parent == null) {
				e.CancelEdit = true;
			}
		}

		private void lMaps_AfterLabelEdit(object sender, NodeLabelEditEventArgs e) {
			if (e.Node.Tag as Map != null) {
				(e.Node.Tag as Map).Name = e.Label ?? (e.Node.Tag as Map).Name;
				EditorEngine.Instance.HasEdit = true;
			}
		}

		private void bTiles_Click(object sender, EventArgs e) {
			EditorEngine.Instance.StateMachine.ChangeState(TileEditorState.Instance);
		}

		private void bEntities_Click(object sender, EventArgs e) {
			EditorEngine.Instance.StateMachine.ChangeState(EntityEditorState.Instance);
		}

		private void bEvents_Click(object sender, EventArgs e) {
			EditorEngine.Instance.StateMachine.ChangeState(EventEditorState.Instance);
		}

		private void bResources_Click(object sender, EventArgs e) {
			using (FrmResourceManager form = new FrmResourceManager()) {
				form.ShowDialog();
			}
		}

		private void bDatabase_Click(object sender, EventArgs e) {
			using (FrmDatabase frm = new FrmDatabase()) {
				frm.ShowDialog();
			}
		}

		private void bPlayWorld_Click(object sender, EventArgs e) {
			Thread t = new Thread(delegate() {
				using (FrmGameTest frm = new FrmGameTest(EditorEngine.Instance.World)) {
					frm.ShowDialog();
				}
			});
			t.Start();
			t.Join();
		}

		private void editorcontrol_MouseUp(object sender, MouseEventArgs e) {
			/*if (e.Button == MouseButtons.Right) {
				if (EditorEngine.Instance.StateMachine.State == EntityEditorState.Instance) {
					int x = e.X - EditorEngine.Instance.xCam;
					int y = e.Y - EditorEngine.Instance.yCam;
					if (EditorEngine.Instance.CurrentMap.HasEntity(x, y)) {
						EntitySelectionTool.Instance.SelectedEntities.Add(EditorEngine.Instance.CurrentMap.GetEntity(x, y));
						EntityEditorState.Instance.ToolStates.ChangeState(EntitySelectionTool.Instance);
						rMenuEntity.Show(editorcontrol.PointToScreen(e.Location));
					}
				}
			}*/
		}

		private void spinLayer_ValueChanged(object sender, EventArgs e) {
			EditorEngine.Instance.SelectedLayer = (int) spinLayer.Value;
		}

		private void bZoomOut_Click(object sender, EventArgs e) {
			EditorEngine.Instance.ZoomOut();
		}

		private void bZoomfit_Click(object sender, EventArgs e) {
			EditorEngine.Instance.World.Camera.Scale = 1f;
			EditorEngine.Instance.CenterView();
		}

		private void bZoomIn_Click(object sender, EventArgs e) {
			EditorEngine.Instance.ZoomIn();
		}

		private void tbcMap_SelectedIndexChanged(object sender, EventArgs e) {
			switch (tbcMap.SelectedIndex) {
				case 0:
					this.panel1.Controls.Clear();
					this.panel1.Controls.Add(this.editorcontrol);
					EditorEngine.Instance.StateMachine.ChangeState(TileEditorState.Instance);
					break;
				case 1:
					this.panel1.Controls.Clear();
					this.panel1.Controls.Add(this.editorcontrol);
					EditorEngine.Instance.StateMachine.ChangeState(PermissionEditorState.Instance);
					break;
				case 2:
					tbcMap.TabPages[1].Controls.Clear();
					tbcMap.TabPages[1].Controls.Add(this.editorcontrol);
					EditorEngine.Instance.StateMachine.ChangeState(BehaviorEditorState.Instance);
					break;
				case 3:
					tbcMap.TabPages[2].Controls.Clear();
					tbcMap.TabPages[2].Controls.Add(this.editorcontrol);
					EditorEngine.Instance.StateMachine.ChangeState(EventEditorState.Instance);
					break;
				case 4:
					break;
				case 5:
					break;
			}
		}
	}
}