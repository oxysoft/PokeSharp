using System.Windows.Forms;
using MapEditor.Data.Controls.EditorView;
using Menu = MapEditor.UI.Old.Menu.Menu;
using ToolBar = MapEditor.UI.Old.Menu.ToolBar;

namespace MapEditor.Forms {
	partial class FrmMainEditor {

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param Name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		public void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainEditor));
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Maps");
			this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
			this.Edit = new System.Windows.Forms.MenuItem();
			this.Option = new System.Windows.Forms.MenuItem();
			this.Scale = new System.Windows.Forms.MenuItem();
			this.Tools = new System.Windows.Forms.MenuItem();
			this.Help = new System.Windows.Forms.MenuItem();
			this.menuStrip1 = new MapEditor.UI.Old.Menu.Menu();
			this.iFile = new System.Windows.Forms.ToolStripMenuItem();
			this.bNewProject = new System.Windows.Forms.ToolStripMenuItem();
			this.bOpenProject = new System.Windows.Forms.ToolStripMenuItem();
			this.bDefaultProject = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.bSave = new System.Windows.Forms.ToolStripMenuItem();
			this.bSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.bMapSnapshot = new System.Windows.Forms.ToolStripMenuItem();
			this.bDumpGame = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.bCloseProject = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.bExit = new System.Windows.Forms.ToolStripMenuItem();
			this.iEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.bUndo = new System.Windows.Forms.ToolStripMenuItem();
			this.bRedo = new System.Windows.Forms.ToolStripMenuItem();
			this.bUndoRedoList = new System.Windows.Forms.ToolStripMenuItem();
			this.iOption = new System.Windows.Forms.ToolStripMenuItem();
			this.bSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.bGrid = new System.Windows.Forms.ToolStripMenuItem();
			this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iTools = new System.Windows.Forms.ToolStripMenuItem();
			this.bSpriteIndexFinder = new System.Windows.Forms.ToolStripMenuItem();
			this.bTilesetChopper = new System.Windows.Forms.ToolStripMenuItem();
			this.bPictureChopper = new System.Windows.Forms.ToolStripMenuItem();
			this.iAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new MapEditor.UI.Old.Menu.ToolBar();
			this.bNewMap = new System.Windows.Forms.ToolStripButton();
			this.bNewMapFolder = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.bUndo2 = new System.Windows.Forms.ToolStripButton();
			this.bRedo2 = new System.Windows.Forms.ToolStripButton();
			this.bUndoRedoList2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.bTiles = new System.Windows.Forms.ToolStripButton();
			this.bEntities = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.bZoomfit = new System.Windows.Forms.ToolStripButton();
			this.bZoomOut = new System.Windows.Forms.ToolStripButton();
			this.bZoomIn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.bResources = new System.Windows.Forms.ToolStripButton();
			this.bDatabase = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.bPlayWorld = new System.Windows.Forms.ToolStripButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.lMaps = new MapEditor.UI.Core.Common.Controls.NFTreeView();
			this.cMenulMaps = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.editorcontrol = new MapEditor.Data.Controls.EditorView.ControlEditorView();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.lbLayer = new System.Windows.Forms.Label();
			this.spinLayer = new System.Windows.Forms.NumericUpDown();
			this.b_hand = new System.Windows.Forms.CheckBox();
			this.b_pencil = new System.Windows.Forms.CheckBox();
			this.b_eraser = new System.Windows.Forms.CheckBox();
			this.b_rectangle = new System.Windows.Forms.CheckBox();
			this.b_bucket = new System.Windows.Forms.CheckBox();
			this.b_logic = new System.Windows.Forms.CheckBox();
			this.b_entityadd = new System.Windows.Forms.CheckBox();
			this.b_entityselect = new System.Windows.Forms.CheckBox();
			this.b_entityrectangle = new System.Windows.Forms.CheckBox();
			this.b_entityselectall = new System.Windows.Forms.CheckBox();
			this.b_entitymove = new System.Windows.Forms.CheckBox();
			this.b_entityremove = new System.Windows.Forms.CheckBox();
			this.tbcMap = new System.Windows.Forms.TabControl();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.rMenuEntity = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.cMenulMaps.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spinLayer)).BeginInit();
			this.tbcMap.SuspendLayout();
			this.rMenuEntity.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Edit
			// 
			this.Edit.Index = -1;
			this.Edit.Text = "";
			// 
			// Option
			// 
			this.Option.Index = -1;
			this.Option.Text = "";
			// 
			// Scale
			// 
			this.Scale.Index = -1;
			this.Scale.Text = "";
			// 
			// Tools
			// 
			this.Tools.Index = -1;
			this.Tools.Text = "";
			// 
			// Help
			// 
			this.Help.Index = -1;
			this.Help.Text = "";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iFile,
            this.iEdit,
            this.iOption,
            this.scaleToolStripMenuItem,
            this.iTools,
            this.iAbout});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(5);
			this.menuStrip1.RenderBackground = true;
			this.menuStrip1.Size = new System.Drawing.Size(1287, 29);
			this.menuStrip1.TabIndex = 19;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// iFile
			// 
			this.iFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bNewProject,
            this.bOpenProject,
            this.bDefaultProject,
            this.toolStripSeparator2,
            this.bSave,
            this.bSaveAs,
            this.bMapSnapshot,
            this.bDumpGame,
            this.toolStripSeparator1,
            this.bCloseProject,
            this.toolStripSeparator6,
            this.bExit});
			this.iFile.Name = "iFile";
			this.iFile.Size = new System.Drawing.Size(37, 19);
			this.iFile.Text = "File";
			// 
			// bNewProject
			// 
			this.bNewProject.Image = global::MapEditor.Properties.Resources.document;
			this.bNewProject.Name = "bNewProject";
			this.bNewProject.Size = new System.Drawing.Size(183, 22);
			this.bNewProject.Text = "New project";
			this.bNewProject.Click += new System.EventHandler(this.bNewRegion_Click);
			// 
			// bOpenProject
			// 
			this.bOpenProject.Image = global::MapEditor.Properties.Resources.folder_open;
			this.bOpenProject.Name = "bOpenProject";
			this.bOpenProject.Size = new System.Drawing.Size(183, 22);
			this.bOpenProject.Text = "Open project";
			this.bOpenProject.Click += new System.EventHandler(this.bOpenRegion_Click);
			// 
			// bDefaultProject
			// 
			this.bDefaultProject.Image = global::MapEditor.Properties.Resources.cookie;
			this.bDefaultProject.Name = "bDefaultProject";
			this.bDefaultProject.Size = new System.Drawing.Size(183, 22);
			this.bDefaultProject.Text = "Open default project";
			this.bDefaultProject.Click += new System.EventHandler(this.bDefaultRegion_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
			// 
			// bSave
			// 
			this.bSave.Enabled = false;
			this.bSave.Image = global::MapEditor.Properties.Resources.disk;
			this.bSave.Name = "bSave";
			this.bSave.Size = new System.Drawing.Size(183, 22);
			this.bSave.Text = "Save";
			this.bSave.ToolTipText = "Ctrl + S";
			this.bSave.Click += new System.EventHandler(this.bSave_Click);
			// 
			// bSaveAs
			// 
			this.bSaveAs.Enabled = false;
			this.bSaveAs.Image = global::MapEditor.Properties.Resources.disk__arrow;
			this.bSaveAs.Name = "bSaveAs";
			this.bSaveAs.Size = new System.Drawing.Size(183, 22);
			this.bSaveAs.Text = "Save as";
			this.bSaveAs.ToolTipText = "Ctrl + Shift + S";
			this.bSaveAs.Click += new System.EventHandler(this.bSaveAs_Click);
			// 
			// bMapSnapshot
			// 
			this.bMapSnapshot.Enabled = false;
			this.bMapSnapshot.Image = global::MapEditor.Properties.Resources.camera;
			this.bMapSnapshot.Name = "bMapSnapshot";
			this.bMapSnapshot.Size = new System.Drawing.Size(183, 22);
			this.bMapSnapshot.Text = "Take map snapshot";
			this.bMapSnapshot.Click += new System.EventHandler(this.bMapSnapshot_Click);
			// 
			// bDumpGame
			// 
			this.bDumpGame.Enabled = false;
			this.bDumpGame.Image = global::MapEditor.Properties.Resources.hammer;
			this.bDumpGame.Name = "bDumpGame";
			this.bDumpGame.Size = new System.Drawing.Size(183, 22);
			this.bDumpGame.Text = "Build game";
			this.bDumpGame.Click += new System.EventHandler(this.bDumpGame_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
			// 
			// bCloseProject
			// 
			this.bCloseProject.Image = global::MapEditor.Properties.Resources.cross;
			this.bCloseProject.Name = "bCloseProject";
			this.bCloseProject.Size = new System.Drawing.Size(183, 22);
			this.bCloseProject.Text = "Close project";
			this.bCloseProject.Click += new System.EventHandler(this.bCloseProject_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(180, 6);
			// 
			// bExit
			// 
			this.bExit.Name = "bExit";
			this.bExit.Size = new System.Drawing.Size(183, 22);
			this.bExit.Text = "Exit";
			this.bExit.Click += new System.EventHandler(this.bExit_Click);
			// 
			// iEdit
			// 
			this.iEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bUndo,
            this.bRedo,
            this.bUndoRedoList});
			this.iEdit.Name = "iEdit";
			this.iEdit.Size = new System.Drawing.Size(39, 19);
			this.iEdit.Text = "Edit";
			// 
			// bUndo
			// 
			this.bUndo.Enabled = false;
			this.bUndo.Image = global::MapEditor.Properties.Resources.arrow_turn_180_left;
			this.bUndo.Name = "bUndo";
			this.bUndo.Size = new System.Drawing.Size(156, 22);
			this.bUndo.Text = "Undo";
			this.bUndo.Click += new System.EventHandler(this.bUndo_Click);
			// 
			// bRedo
			// 
			this.bRedo.Enabled = false;
			this.bRedo.Image = global::MapEditor.Properties.Resources.arrow_turn_000_left;
			this.bRedo.Name = "bRedo";
			this.bRedo.Size = new System.Drawing.Size(156, 22);
			this.bRedo.Text = "Redo";
			this.bRedo.Click += new System.EventHandler(this.bRedo_Click);
			// 
			// bUndoRedoList
			// 
			this.bUndoRedoList.Enabled = false;
			this.bUndoRedoList.Image = global::MapEditor.Properties.Resources.clipboard_list;
			this.bUndoRedoList.Name = "bUndoRedoList";
			this.bUndoRedoList.Size = new System.Drawing.Size(156, 22);
			this.bUndoRedoList.Text = "Undo/Redo List";
			this.bUndoRedoList.Click += new System.EventHandler(this.bUndoRedoList_Click);
			// 
			// iOption
			// 
			this.iOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bSettings,
            this.bGrid});
			this.iOption.Name = "iOption";
			this.iOption.Size = new System.Drawing.Size(56, 19);
			this.iOption.Text = "Option";
			// 
			// bSettings
			// 
			this.bSettings.Image = global::MapEditor.Properties.Resources.wrench_screwdriver;
			this.bSettings.Name = "bSettings";
			this.bSettings.Size = new System.Drawing.Size(116, 22);
			this.bSettings.Text = "Settings";
			this.bSettings.Click += new System.EventHandler(this.bOptions_Click);
			// 
			// bGrid
			// 
			this.bGrid.Enabled = false;
			this.bGrid.Name = "bGrid";
			this.bGrid.Size = new System.Drawing.Size(116, 22);
			this.bGrid.Text = "Grid";
			this.bGrid.Click += new System.EventHandler(this.bGrid_Click);
			// 
			// scaleToolStripMenuItem
			// 
			this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
			this.scaleToolStripMenuItem.Size = new System.Drawing.Size(46, 19);
			this.scaleToolStripMenuItem.Text = "Scale";
			// 
			// iTools
			// 
			this.iTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bSpriteIndexFinder,
            this.bTilesetChopper,
            this.bPictureChopper});
			this.iTools.Name = "iTools";
			this.iTools.Size = new System.Drawing.Size(48, 19);
			this.iTools.Text = "Tools";
			// 
			// bSpriteIndexFinder
			// 
			this.bSpriteIndexFinder.Enabled = false;
			this.bSpriteIndexFinder.Name = "bSpriteIndexFinder";
			this.bSpriteIndexFinder.Size = new System.Drawing.Size(204, 22);
			this.bSpriteIndexFinder.Text = "Tile SelectionStart Finder";
			this.bSpriteIndexFinder.Click += new System.EventHandler(this.bSpriteIndexFinder_Click);
			// 
			// bTilesetChopper
			// 
			this.bTilesetChopper.Enabled = false;
			this.bTilesetChopper.Name = "bTilesetChopper";
			this.bTilesetChopper.Size = new System.Drawing.Size(204, 22);
			this.bTilesetChopper.Text = "Tileset Chopper";
			this.bTilesetChopper.Click += new System.EventHandler(this.bTilesetChopper_Click);
			// 
			// bPictureChopper
			// 
			this.bPictureChopper.Enabled = false;
			this.bPictureChopper.Name = "bPictureChopper";
			this.bPictureChopper.Size = new System.Drawing.Size(204, 22);
			this.bPictureChopper.Text = "Picture Chopper";
			this.bPictureChopper.Click += new System.EventHandler(this.bPictureChopper_Click);
			// 
			// iAbout
			// 
			this.iAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.creditsToolStripMenuItem});
			this.iAbout.Name = "iAbout";
			this.iAbout.Size = new System.Drawing.Size(44, 19);
			this.iAbout.Text = "Help";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Image = global::MapEditor.Properties.Resources.question;
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.helpToolStripMenuItem.Text = "Help";
			this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
			// 
			// creditsToolStripMenuItem
			// 
			this.creditsToolStripMenuItem.Image = global::MapEditor.Properties.Resources.information_italic;
			this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
			this.creditsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.creditsToolStripMenuItem.Text = "Credits";
			this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bNewMap,
            this.bNewMapFolder,
            this.toolStripSeparator3,
            this.bUndo2,
            this.bRedo2,
            this.bUndoRedoList2,
            this.toolStripSeparator4,
            this.bTiles,
            this.bEntities,
            this.toolStripSeparator10,
            this.bZoomfit,
            this.bZoomOut,
            this.bZoomIn,
            this.toolStripSeparator5,
            this.bResources,
            this.bDatabase,
            this.toolStripSeparator7,
            this.bPlayWorld});
			this.toolStrip1.Location = new System.Drawing.Point(0, 29);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(5);
			this.toolStrip1.RenderBackground = true;
			this.toolStrip1.Size = new System.Drawing.Size(1287, 33);
			this.toolStrip1.TabIndex = 20;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// bNewMap
			// 
			this.bNewMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bNewMap.Enabled = false;
			this.bNewMap.Image = global::MapEditor.Properties.Resources.document__plus;
			this.bNewMap.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bNewMap.Name = "bNewMap";
			this.bNewMap.Size = new System.Drawing.Size(23, 20);
			this.bNewMap.Text = "toolStripButton1";
			this.bNewMap.Click += new System.EventHandler(this.bNewMap_Click);
			// 
			// bNewMapFolder
			// 
			this.bNewMapFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bNewMapFolder.Enabled = false;
			this.bNewMapFolder.Image = global::MapEditor.Properties.Resources.folder__plus;
			this.bNewMapFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bNewMapFolder.Name = "bNewMapFolder";
			this.bNewMapFolder.Size = new System.Drawing.Size(23, 20);
			this.bNewMapFolder.Text = "toolStripButton1";
			this.bNewMapFolder.Click += new System.EventHandler(this.bNewMapFolder_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
			// 
			// bUndo2
			// 
			this.bUndo2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bUndo2.Enabled = false;
			this.bUndo2.Image = global::MapEditor.Properties.Resources.arrow_turn_180_left;
			this.bUndo2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bUndo2.Name = "bUndo2";
			this.bUndo2.Size = new System.Drawing.Size(23, 20);
			this.bUndo2.Text = "toolStripButton2";
			this.bUndo2.Click += new System.EventHandler(this.bUndo_Click);
			// 
			// bRedo2
			// 
			this.bRedo2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bRedo2.Enabled = false;
			this.bRedo2.Image = global::MapEditor.Properties.Resources.arrow_turn_000_left;
			this.bRedo2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bRedo2.Name = "bRedo2";
			this.bRedo2.Size = new System.Drawing.Size(23, 20);
			this.bRedo2.Text = "toolStripButton3";
			this.bRedo2.Click += new System.EventHandler(this.bRedo_Click);
			// 
			// bUndoRedoList2
			// 
			this.bUndoRedoList2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bUndoRedoList2.Enabled = false;
			this.bUndoRedoList2.Image = global::MapEditor.Properties.Resources.clipboard_list;
			this.bUndoRedoList2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bUndoRedoList2.Name = "bUndoRedoList2";
			this.bUndoRedoList2.Size = new System.Drawing.Size(23, 20);
			this.bUndoRedoList2.Text = "toolStripButton4";
			this.bUndoRedoList2.Click += new System.EventHandler(this.bUndoRedoList_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
			// 
			// bTiles
			// 
			this.bTiles.Enabled = false;
			this.bTiles.Image = global::MapEditor.Properties.Resources.Tiles_large;
			this.bTiles.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bTiles.Name = "bTiles";
			this.bTiles.Size = new System.Drawing.Size(51, 20);
			this.bTiles.Text = "Tiles";
			this.bTiles.Click += new System.EventHandler(this.bTiles_Click);
			// 
			// bEntities
			// 
			this.bEntities.Enabled = false;
			this.bEntities.Image = global::MapEditor.Properties.Resources.sofa;
			this.bEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bEntities.Name = "bEntities";
			this.bEntities.Size = new System.Drawing.Size(65, 20);
			this.bEntities.Text = "Entities";
			this.bEntities.Click += new System.EventHandler(this.bEntities_Click);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 23);
			// 
			// bZoomfit
			// 
			this.bZoomfit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bZoomfit.Enabled = false;
			this.bZoomfit.Image = global::MapEditor.Properties.Resources.magnifier_zoom_fit;
			this.bZoomfit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bZoomfit.Name = "bZoomfit";
			this.bZoomfit.Size = new System.Drawing.Size(23, 20);
			this.bZoomfit.Text = "toolStripButton1";
			this.bZoomfit.Click += new System.EventHandler(this.bZoomfit_Click);
			// 
			// bZoomOut
			// 
			this.bZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bZoomOut.Enabled = false;
			this.bZoomOut.Image = global::MapEditor.Properties.Resources.magnifier_zoom_out;
			this.bZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bZoomOut.Name = "bZoomOut";
			this.bZoomOut.Size = new System.Drawing.Size(23, 20);
			this.bZoomOut.Text = "toolStripButton1";
			this.bZoomOut.Click += new System.EventHandler(this.bZoomOut_Click);
			// 
			// bZoomIn
			// 
			this.bZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bZoomIn.Enabled = false;
			this.bZoomIn.Image = global::MapEditor.Properties.Resources.magnifier_zoom_in;
			this.bZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bZoomIn.Name = "bZoomIn";
			this.bZoomIn.Size = new System.Drawing.Size(23, 20);
			this.bZoomIn.Text = "toolStripButton2";
			this.bZoomIn.Click += new System.EventHandler(this.bZoomIn_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
			// 
			// bResources
			// 
			this.bResources.Enabled = false;
			this.bResources.Image = global::MapEditor.Properties.Resources.resource;
			this.bResources.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bResources.Name = "bResources";
			this.bResources.Size = new System.Drawing.Size(80, 20);
			this.bResources.Text = "Resources";
			this.bResources.Click += new System.EventHandler(this.bResources_Click);
			// 
			// bDatabase
			// 
			this.bDatabase.Enabled = false;
			this.bDatabase.Image = global::MapEditor.Properties.Resources.database;
			this.bDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bDatabase.Name = "bDatabase";
			this.bDatabase.Size = new System.Drawing.Size(75, 20);
			this.bDatabase.Text = "Database";
			this.bDatabase.Click += new System.EventHandler(this.bDatabase_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
			// 
			// bPlayWorld
			// 
			this.bPlayWorld.Enabled = false;
			this.bPlayWorld.Image = global::MapEditor.Properties.Resources.control;
			this.bPlayWorld.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.bPlayWorld.Name = "bPlayWorld";
			this.bPlayWorld.Size = new System.Drawing.Size(62, 20);
			this.bPlayWorld.Text = "Debug";
			this.bPlayWorld.Click += new System.EventHandler(this.bPlayWorld_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "arrow-move.png");
			this.imageList1.Images.SetKeyName(1, "arrow-return-000-left.png");
			this.imageList1.Images.SetKeyName(2, "arrow-return-180-left.png");
			this.imageList1.Images.SetKeyName(3, "arrow-skip.png");
			this.imageList1.Images.SetKeyName(4, "arrow-turn-000-left.png");
			this.imageList1.Images.SetKeyName(5, "arrow-turn-180-left.png");
			this.imageList1.Images.SetKeyName(6, "balloon-ellipsis.png");
			this.imageList1.Images.SetKeyName(7, "block.png");
			this.imageList1.Images.SetKeyName(8, "board-game.png");
			this.imageList1.Images.SetKeyName(9, "book_open2.png");
			this.imageList1.Images.SetKeyName(10, "box.png");
			this.imageList1.Images.SetKeyName(11, "brain2.png");
			this.imageList1.Images.SetKeyName(12, "bucket.png");
			this.imageList1.Images.SetKeyName(13, "building.png");
			this.imageList1.Images.SetKeyName(14, "camera.png");
			this.imageList1.Images.SetKeyName(15, "check.png");
			this.imageList1.Images.SetKeyName(16, "clipboard-list.png");
			this.imageList1.Images.SetKeyName(17, "clipboard-paste.png");
			this.imageList1.Images.SetKeyName(18, "comment_white.png");
			this.imageList1.Images.SetKeyName(19, "control.png");
			this.imageList1.Images.SetKeyName(20, "cookie.png");
			this.imageList1.Images.SetKeyName(21, "cross.png");
			this.imageList1.Images.SetKeyName(22, "cursor.png");
			this.imageList1.Images.SetKeyName(23, "cursor1.png");
			this.imageList1.Images.SetKeyName(24, "database.png");
			this.imageList1.Images.SetKeyName(25, "database1.png");
			this.imageList1.Images.SetKeyName(26, "disk.png");
			this.imageList1.Images.SetKeyName(27, "disk--arrow.png");
			this.imageList1.Images.SetKeyName(28, "disk-black.png");
			this.imageList1.Images.SetKeyName(29, "document.png");
			this.imageList1.Images.SetKeyName(30, "document--pencil.png");
			this.imageList1.Images.SetKeyName(31, "document--pencil1.png");
			this.imageList1.Images.SetKeyName(32, "document--plus.png");
			this.imageList1.Images.SetKeyName(33, "documents.png");
			this.imageList1.Images.SetKeyName(34, "door-open.png");
			this.imageList1.Images.SetKeyName(35, "edit.png");
			this.imageList1.Images.SetKeyName(36, "edit-list.png");
			this.imageList1.Images.SetKeyName(37, "eraser.png");
			this.imageList1.Images.SetKeyName(38, "film.png");
			this.imageList1.Images.SetKeyName(39, "film--plus.png");
			this.imageList1.Images.SetKeyName(40, "flask.png");
			this.imageList1.Images.SetKeyName(41, "folder-export.png");
			this.imageList1.Images.SetKeyName(42, "folder-import.png");
			this.imageList1.Images.SetKeyName(43, "folder-open.png");
			this.imageList1.Images.SetKeyName(44, "folder--plus.png");
			this.imageList1.Images.SetKeyName(45, "fruit-grape.png");
			this.imageList1.Images.SetKeyName(46, "gear.png");
			this.imageList1.Images.SetKeyName(47, "globe-network.png");
			this.imageList1.Images.SetKeyName(48, "grass.png");
			this.imageList1.Images.SetKeyName(49, "grid.png");
			this.imageList1.Images.SetKeyName(50, "hammer.png");
			this.imageList1.Images.SetKeyName(51, "hand_move.png");
			this.imageList1.Images.SetKeyName(52, "images.png");
			this.imageList1.Images.SetKeyName(53, "information.png");
			this.imageList1.Images.SetKeyName(54, "information1.png");
			this.imageList1.Images.SetKeyName(55, "information-button.png");
			this.imageList1.Images.SetKeyName(56, "information-italic.png");
			this.imageList1.Images.SetKeyName(57, "layer.png");
			this.imageList1.Images.SetKeyName(58, "layer-select.png");
			this.imageList1.Images.SetKeyName(59, "layer-shape.png");
			this.imageList1.Images.SetKeyName(60, "leaf.png");
			this.imageList1.Images.SetKeyName(61, "lighthouse.png");
			this.imageList1.Images.SetKeyName(62, "lightning.png");
			this.imageList1.Images.SetKeyName(63, "m_minus.png");
			this.imageList1.Images.SetKeyName(64, "m_plus.png");
			this.imageList1.Images.SetKeyName(65, "map.png");
			this.imageList1.Images.SetKeyName(66, "map1.png");
			this.imageList1.Images.SetKeyName(67, "map--minus.png");
			this.imageList1.Images.SetKeyName(68, "map--pencil.png");
			this.imageList1.Images.SetKeyName(69, "map--plus.png");
			this.imageList1.Images.SetKeyName(70, "minus.png");
			this.imageList1.Images.SetKeyName(71, "minus-button.png");
			this.imageList1.Images.SetKeyName(72, "music--plus.png");
			this.imageList1.Images.SetKeyName(73, "paint-can.png");
			this.imageList1.Images.SetKeyName(74, "pencil.png");
			this.imageList1.Images.SetKeyName(75, "pictures.png");
			this.imageList1.Images.SetKeyName(76, "plus.png");
			this.imageList1.Images.SetKeyName(77, "plus-button.png");
			this.imageList1.Images.SetKeyName(78, "puzzle.png");
			this.imageList1.Images.SetKeyName(79, "question.png");
			this.imageList1.Images.SetKeyName(80, "question1.png");
			this.imageList1.Images.SetKeyName(81, "question2.png");
			this.imageList1.Images.SetKeyName(82, "reload.png");
			this.imageList1.Images.SetKeyName(83, "resource.png");
			this.imageList1.Images.SetKeyName(84, "scissors-blue.png");
			this.imageList1.Images.SetKeyName(85, "script.png");
			this.imageList1.Images.SetKeyName(86, "script1.png");
			this.imageList1.Images.SetKeyName(87, "scripts-text.png");
			this.imageList1.Images.SetKeyName(88, "selection.png");
			this.imageList1.Images.SetKeyName(89, "selection-select.png");
			this.imageList1.Images.SetKeyName(90, "sofa.png");
			this.imageList1.Images.SetKeyName(91, "sofa--minus.png");
			this.imageList1.Images.SetKeyName(92, "sofa--pencil.png");
			this.imageList1.Images.SetKeyName(93, "sofa--plus.png");
			this.imageList1.Images.SetKeyName(94, "speaker--plus.png");
			this.imageList1.Images.SetKeyName(95, "table-split.png");
			this.imageList1.Images.SetKeyName(96, "Tiles.png");
			this.imageList1.Images.SetKeyName(97, "tiles_large.png");
			this.imageList1.Images.SetKeyName(98, "tree.png");
			this.imageList1.Images.SetKeyName(99, "tree--arrow.png");
			this.imageList1.Images.SetKeyName(100, "tree--exclamation.png");
			this.imageList1.Images.SetKeyName(101, "tree--minus.png");
			this.imageList1.Images.SetKeyName(102, "tree--pencil.png");
			this.imageList1.Images.SetKeyName(103, "tree--plus.png");
			this.imageList1.Images.SetKeyName(104, "tree-red.png");
			this.imageList1.Images.SetKeyName(105, "tree-yellow.png");
			this.imageList1.Images.SetKeyName(106, "user.png");
			this.imageList1.Images.SetKeyName(107, "world.png");
			this.imageList1.Images.SetKeyName(108, "world1.png");
			this.imageList1.Images.SetKeyName(109, "wrench-screwdriver.png");
			this.imageList1.Images.SetKeyName(110, "folder.png");
			this.imageList1.Images.SetKeyName(111, "shoe.png");
			// 
			// lMaps
			// 
			this.lMaps.BackColor = System.Drawing.SystemColors.Window;
			this.lMaps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lMaps.ImageKey = "box.png";
			this.lMaps.ImageList = this.imageList1;
			this.lMaps.LabelEdit = true;
			this.lMaps.Location = new System.Drawing.Point(0, 0);
			this.lMaps.Name = "lMaps";
			treeNode1.Name = "Node0";
			treeNode1.Text = "Maps";
			this.lMaps.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
			this.lMaps.SelectedImageKey = "box.png";
			this.lMaps.Size = new System.Drawing.Size(232, 331);
			this.lMaps.TabIndex = 6;
			this.lMaps.Visible = false;
			this.lMaps.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.lMaps_BeforeLabelEdit);
			this.lMaps.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.lMaps_AfterLabelEdit);
			this.lMaps.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.lMaps_BeforeCollapse);
			this.lMaps.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.lMaps_BeforeExpand);
			this.lMaps.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.lMaps_NodeMouseClick);
			this.lMaps.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.lMaps_NodeMouseDoubleClick);
			this.lMaps.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lMaps_MouseUp);
			// 
			// cMenulMaps
			// 
			this.cMenulMaps.AutoClose = false;
			this.cMenulMaps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.cMenulMaps.Name = "cMenulMaps";
			this.cMenulMaps.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.cMenulMaps.Size = new System.Drawing.Size(118, 48);
			this.cMenulMaps.UseWaitCursor = true;
			// 
			// renameToolStripMenuItem
			// 
			this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
			this.renameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.renameToolStripMenuItem.Text = "Rename";
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			// 
			// tabPage4
			// 
			this.tabPage4.ImageKey = "leaf.png";
			this.tabPage4.Location = new System.Drawing.Point(4, 23);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(1047, 569);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Wild Pokemon";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.ImageKey = "wrench-screwdriver.png";
			this.tabPage3.Location = new System.Drawing.Point(4, 23);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(1047, 569);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Settings";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.ImageKey = "block.png";
			this.tabPage2.Location = new System.Drawing.Point(4, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1047, 569);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Events";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.tableLayoutPanel1);
			this.tabPage1.ImageKey = "map.png";
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1047, 569);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Map";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1041, 563);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.editorcontrol);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(11, 38);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1027, 512);
			this.panel1.TabIndex = 0;
			// 
			// editorcontrol
			// 
			this.editorcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editorcontrol.GameLoopEnabled = true;
			this.editorcontrol.Location = new System.Drawing.Point(0, 0);
			this.editorcontrol.Name = "editorcontrol";
			this.editorcontrol.Size = new System.Drawing.Size(1023, 508);
			this.editorcontrol.TabIndex = 4;
			this.editorcontrol.Text = "editorViewControl1";
			this.editorcontrol.TimeStep = 16.66666F;
			this.editorcontrol.MouseUp += new System.Windows.Forms.MouseEventHandler(this.editorcontrol_MouseUp);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.lbLayer);
			this.flowLayoutPanel1.Controls.Add(this.spinLayer);
			this.flowLayoutPanel1.Controls.Add(this.b_hand);
			this.flowLayoutPanel1.Controls.Add(this.b_pencil);
			this.flowLayoutPanel1.Controls.Add(this.b_eraser);
			this.flowLayoutPanel1.Controls.Add(this.b_rectangle);
			this.flowLayoutPanel1.Controls.Add(this.b_bucket);
			this.flowLayoutPanel1.Controls.Add(this.b_logic);
			this.flowLayoutPanel1.Controls.Add(this.b_entityadd);
			this.flowLayoutPanel1.Controls.Add(this.b_entityselect);
			this.flowLayoutPanel1.Controls.Add(this.b_entityrectangle);
			this.flowLayoutPanel1.Controls.Add(this.b_entityselectall);
			this.flowLayoutPanel1.Controls.Add(this.b_entitymove);
			this.flowLayoutPanel1.Controls.Add(this.b_entityremove);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(1027, 29);
			this.flowLayoutPanel1.TabIndex = 5;
			// 
			// lbLayer
			// 
			this.lbLayer.AutoSize = true;
			this.lbLayer.Location = new System.Drawing.Point(3, 7);
			this.lbLayer.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
			this.lbLayer.Name = "lbLayer";
			this.lbLayer.Size = new System.Drawing.Size(33, 13);
			this.lbLayer.TabIndex = 25;
			this.lbLayer.Text = "Layer";
			// 
			// spinLayer
			// 
			this.spinLayer.Location = new System.Drawing.Point(42, 3);
			this.spinLayer.Name = "spinLayer";
			this.spinLayer.Size = new System.Drawing.Size(120, 20);
			this.spinLayer.TabIndex = 26;
			this.spinLayer.ValueChanged += new System.EventHandler(this.spinLayer_ValueChanged);
			// 
			// b_hand
			// 
			this.b_hand.Appearance = System.Windows.Forms.Appearance.Button;
			this.b_hand.AutoCheck = false;
			this.b_hand.AutoSize = true;
			this.b_hand.Image = global::MapEditor.Properties.Resources.cursor;
			this.b_hand.Location = new System.Drawing.Point(168, 3);
			this.b_hand.Name = "b_hand";
			this.b_hand.Size = new System.Drawing.Size(22, 22);
			this.b_hand.TabIndex = 14;
			this.b_hand.UseVisualStyleBackColor = true;
			this.b_hand.Click += new System.EventHandler(this.b_hand_MouseClick);
			// 
			// b_pencil
			// 
			this.b_pencil.Appearance = System.Windows.Forms.Appearance.Button;
			this.b_pencil.AutoCheck = false;
			this.b_pencil.AutoSize = true;
			this.b_pencil.Image = global::MapEditor.Properties.Resources.pencil;
			this.b_pencil.Location = new System.Drawing.Point(196, 3);
			this.b_pencil.Name = "b_pencil";
			this.b_pencil.Size = new System.Drawing.Size(22, 22);
			this.b_pencil.TabIndex = 13;
			this.b_pencil.UseVisualStyleBackColor = true;
			this.b_pencil.Click += new System.EventHandler(this.b_pencil_MouseClick);
			// 
			// b_eraser
			// 
			this.b_eraser.Appearance = System.Windows.Forms.Appearance.Button;
			this.b_eraser.AutoCheck = false;
			this.b_eraser.AutoSize = true;
			this.b_eraser.Image = global::MapEditor.Properties.Resources.eraser;
			this.b_eraser.Location = new System.Drawing.Point(224, 3);
			this.b_eraser.Name = "b_eraser";
			this.b_eraser.Size = new System.Drawing.Size(22, 22);
			this.b_eraser.TabIndex = 15;
			this.b_eraser.UseVisualStyleBackColor = true;
			this.b_eraser.Click += new System.EventHandler(this.b_eraser_MouseClick);
			// 
			// b_rectangle
			// 
			this.b_rectangle.Appearance = System.Windows.Forms.Appearance.Button;
			this.b_rectangle.AutoCheck = false;
			this.b_rectangle.AutoSize = true;
			this.b_rectangle.Image = global::MapEditor.Properties.Resources.layer_select;
			this.b_rectangle.Location = new System.Drawing.Point(252, 3);
			this.b_rectangle.Name = "b_rectangle";
			this.b_rectangle.Size = new System.Drawing.Size(22, 22);
			this.b_rectangle.TabIndex = 16;
			this.b_rectangle.UseVisualStyleBackColor = true;
			this.b_rectangle.Click += new System.EventHandler(this.b_rectangle_MouseClick);
			// 
			// b_bucket
			// 
			this.b_bucket.Appearance = System.Windows.Forms.Appearance.Button;
			this.b_bucket.AutoCheck = false;
			this.b_bucket.AutoSize = true;
			this.b_bucket.Image = global::MapEditor.Properties.Resources.paint_can;
			this.b_bucket.Location = new System.Drawing.Point(280, 3);
			this.b_bucket.Name = "b_bucket";
			this.b_bucket.Size = new System.Drawing.Size(22, 22);
			this.b_bucket.TabIndex = 17;
			this.b_bucket.UseVisualStyleBackColor = true;
			this.b_bucket.Click += new System.EventHandler(this.b_bucket_MouseClick);
			// 
			// b_logic
			// 
			this.b_logic.Appearance = System.Windows.Forms.Appearance.Button;
			this.b_logic.AutoCheck = false;
			this.b_logic.AutoSize = true;
			this.b_logic.Image = global::MapEditor.Properties.Resources.puzzle;
			this.b_logic.Location = new System.Drawing.Point(308, 3);
			this.b_logic.Name = "b_logic";
			this.b_logic.Size = new System.Drawing.Size(22, 22);
			this.b_logic.TabIndex = 18;
			this.b_logic.UseVisualStyleBackColor = true;
			this.b_logic.Click += new System.EventHandler(this.b_logic_MouseClick);
			// 
			// b_entityadd
			// 
			this.b_entityadd.Appearance = System.Windows.Forms.Appearance.Button;
			this.b_entityadd.AutoCheck = false;
			this.b_entityadd.AutoSize = true;
			this.b_entityadd.Image = global::MapEditor.Properties.Resources.sofa__plus;
			this.b_entityadd.Location = new System.Drawing.Point(336, 3);
			this.b_entityadd.Name = "b_entityadd";
			this.b_entityadd.Size = new System.Drawing.Size(22, 22);
			this.b_entityadd.TabIndex = 19;
			this.b_entityadd.UseVisualStyleBackColor = true;
			this.b_entityadd.Visible = false;
			this.b_entityadd.Click += new System.EventHandler(this.b_entityadd_MouseClick);
			// 
			// b_entityselect
			// 
			this.b_entityselect.Appearance = System.Windows.Forms.Appearance.Button;
			this.b_entityselect.AutoCheck = false;
			this.b_entityselect.AutoSize = true;
			this.b_entityselect.Image = global::MapEditor.Properties.Resources.selection;
			this.b_entityselect.Location = new System.Drawing.Point(364, 3);
			this.b_entityselect.Name = "b_entityselect";
			this.b_entityselect.Size = new System.Drawing.Size(22, 22);
			this.b_entityselect.TabIndex = 20;
			this.b_entityselect.UseVisualStyleBackColor = true;
			this.b_entityselect.Visible = false;
			this.b_entityselect.Click += new System.EventHandler(this.b_entityselect_MouseClick);
			// 
			// b_entityrectangle
			// 
			this.b_entityrectangle.Appearance = System.Windows.Forms.Appearance.Button;
			this.b_entityrectangle.AutoCheck = false;
			this.b_entityrectangle.AutoSize = true;
			this.b_entityrectangle.Image = global::MapEditor.Properties.Resources.layer_select;
			this.b_entityrectangle.Location = new System.Drawing.Point(392, 3);
			this.b_entityrectangle.Name = "b_entityrectangle";
			this.b_entityrectangle.Size = new System.Drawing.Size(22, 22);
			this.b_entityrectangle.TabIndex = 24;
			this.b_entityrectangle.UseVisualStyleBackColor = true;
			this.b_entityrectangle.Visible = false;
			this.b_entityrectangle.Click += new System.EventHandler(this.b_entityrectangle_Click);
			// 
			// b_entityselectall
			// 
			this.b_entityselectall.Appearance = System.Windows.Forms.Appearance.Button;
			this.b_entityselectall.AutoCheck = false;
			this.b_entityselectall.AutoSize = true;
			this.b_entityselectall.Image = global::MapEditor.Properties.Resources.selection_select;
			this.b_entityselectall.Location = new System.Drawing.Point(420, 3);
			this.b_entityselectall.Name = "b_entityselectall";
			this.b_entityselectall.Size = new System.Drawing.Size(22, 22);
			this.b_entityselectall.TabIndex = 21;
			this.b_entityselectall.UseVisualStyleBackColor = true;
			this.b_entityselectall.Visible = false;
			this.b_entityselectall.Click += new System.EventHandler(this.b_entityselectall_MouseClick);
			// 
			// b_entitymove
			// 
			this.b_entitymove.Appearance = System.Windows.Forms.Appearance.Button;
			this.b_entitymove.AutoCheck = false;
			this.b_entitymove.AutoSize = true;
			this.b_entitymove.Image = global::MapEditor.Properties.Resources.hand_move;
			this.b_entitymove.Location = new System.Drawing.Point(448, 3);
			this.b_entitymove.Name = "b_entitymove";
			this.b_entitymove.Size = new System.Drawing.Size(22, 22);
			this.b_entitymove.TabIndex = 22;
			this.b_entitymove.UseVisualStyleBackColor = true;
			this.b_entitymove.Visible = false;
			this.b_entitymove.Click += new System.EventHandler(this.b_entitymove_MouseClick);
			// 
			// b_entityremove
			// 
			this.b_entityremove.Appearance = System.Windows.Forms.Appearance.Button;
			this.b_entityremove.AutoCheck = false;
			this.b_entityremove.AutoSize = true;
			this.b_entityremove.Image = global::MapEditor.Properties.Resources.sofa__minus;
			this.b_entityremove.Location = new System.Drawing.Point(476, 3);
			this.b_entityremove.Name = "b_entityremove";
			this.b_entityremove.Size = new System.Drawing.Size(22, 22);
			this.b_entityremove.TabIndex = 23;
			this.b_entityremove.UseVisualStyleBackColor = true;
			this.b_entityremove.Visible = false;
			this.b_entityremove.Click += new System.EventHandler(this.b_entityremove_MouseClick);
			// 
			// tbcMap
			// 
			this.tbcMap.Controls.Add(this.tabPage1);
			this.tbcMap.Controls.Add(this.tabPage5);
			this.tbcMap.Controls.Add(this.tabPage6);
			this.tbcMap.Controls.Add(this.tabPage2);
			this.tbcMap.Controls.Add(this.tabPage3);
			this.tbcMap.Controls.Add(this.tabPage4);
			this.tbcMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbcMap.ImageList = this.imageList1;
			this.tbcMap.Location = new System.Drawing.Point(232, 62);
			this.tbcMap.Name = "tbcMap";
			this.tbcMap.SelectedIndex = 0;
			this.tbcMap.Size = new System.Drawing.Size(1055, 596);
			this.tbcMap.TabIndex = 25;
			this.tbcMap.SelectedIndexChanged += new System.EventHandler(this.tbcMap_SelectedIndexChanged);
			// 
			// tabPage5
			// 
			this.tabPage5.ImageKey = "shoe.png";
			this.tabPage5.Location = new System.Drawing.Point(4, 23);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(1047, 569);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Behavior Layer";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// rMenuEntity
			// 
			this.rMenuEntity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator8,
            this.deleteToolStripMenuItem1,
            this.toolStripSeparator9,
            this.propertiesToolStripMenuItem});
			this.rMenuEntity.Name = "rMenuEntity";
			this.rMenuEntity.Size = new System.Drawing.Size(128, 126);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
			this.toolStripMenuItem1.Text = "Cut";
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(124, 6);
			// 
			// deleteToolStripMenuItem1
			// 
			this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
			this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
			this.deleteToolStripMenuItem1.Text = "Delete";
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(124, 6);
			// 
			// propertiesToolStripMenuItem
			// 
			this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
			this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.propertiesToolStripMenuItem.Text = "Properties";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Left;
			this.splitContainer1.Location = new System.Drawing.Point(0, 62);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.lMaps);
			this.splitContainer1.Size = new System.Drawing.Size(232, 596);
			this.splitContainer1.SplitterDistance = 261;
			this.splitContainer1.TabIndex = 26;
			this.splitContainer1.Visible = false;
			// 
			// tabPage6
			// 
			this.tabPage6.Location = new System.Drawing.Point(4, 23);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(1047, 569);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "Passability layer";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// FrmMainEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1287, 658);
			this.Controls.Add(this.tbcMap);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Menu = this.mainMenu;
			this.Name = "FrmMainEditor";
			this.Text = "PokeSharp Game Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMainEditor_FormClosing);
			this.Load += new System.EventHandler(this.FrmMainEditor_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.cMenulMaps.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.spinLayer)).EndInit();
			this.tbcMap.ResumeLayout(false);
			this.rMenuEntity.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.MainMenu mainMenu;
		public System.Windows.Forms.ToolStripMenuItem iFile;
		public System.Windows.Forms.ToolStripMenuItem iEdit;
		public System.Windows.Forms.ToolStripMenuItem iOption;
		public System.Windows.Forms.ToolStripMenuItem iTools;
		public System.Windows.Forms.ToolStripMenuItem iAbout;
		public System.Windows.Forms.ToolStripButton bNewMap;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		public System.Windows.Forms.ToolStripButton bUndo2;
		public System.Windows.Forms.ToolStripButton bRedo2;
		public System.Windows.Forms.ToolStripButton bUndoRedoList2;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		public System.Windows.Forms.ToolStripButton bTiles;
		public System.Windows.Forms.ToolStripButton bEntities;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		public System.Windows.Forms.ToolStripButton bResources;
		public System.Windows.Forms.ToolStripMenuItem bNewProject;
		public System.Windows.Forms.ToolStripMenuItem bOpenProject;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		public System.Windows.Forms.ToolStripMenuItem bSave;
		public System.Windows.Forms.ToolStripMenuItem bMapSnapshot;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		public System.Windows.Forms.ToolStripMenuItem bExit;
		public System.Windows.Forms.ToolStripMenuItem bUndo;
		public System.Windows.Forms.ToolStripMenuItem bRedo;
		public System.Windows.Forms.ToolStripMenuItem bUndoRedoList;
		public System.Windows.Forms.ToolStripMenuItem bSettings;
		public System.Windows.Forms.ToolStripMenuItem bGrid;
		public System.Windows.Forms.ToolStripMenuItem bSpriteIndexFinder;
		public System.Windows.Forms.ToolStripMenuItem bTilesetChopper;
		public System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
		public System.Windows.Forms.ImageList imageList1;
		public System.Windows.Forms.ToolStripMenuItem bPictureChopper;
		public System.Windows.Forms.ToolStripMenuItem bDumpGame;
		public System.Windows.Forms.ToolStripMenuItem bDefaultProject;
		public MapEditor.UI.Core.Common.Controls.NFTreeView lMaps;
		public System.Windows.Forms.ToolStripButton bNewMapFolder;
		public System.Windows.Forms.ContextMenuStrip cMenulMaps;
		public System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem bSaveAs;
		public System.Windows.Forms.ToolStripMenuItem bCloseProject;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		public System.Windows.Forms.ToolStripButton bDatabase;
		public System.Windows.Forms.TabPage tabPage4;
		public System.Windows.Forms.TabPage tabPage3;
		public System.Windows.Forms.TabPage tabPage2;
		public System.Windows.Forms.TabPage tabPage1;
		public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		public System.Windows.Forms.TabControl tbcMap;
		public System.Windows.Forms.ToolStripButton bPlayWorld;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		public System.Windows.Forms.ContextMenuStrip rMenuEntity;
		public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		public System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		public System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		public System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
		public System.Windows.Forms.ToolStripButton bZoomOut;
		public System.Windows.Forms.ToolStripButton bZoomIn;
		public System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
		public System.Windows.Forms.ToolStripButton bZoomfit;
		public System.Windows.Forms.SplitContainer splitContainer1;
		public System.Windows.Forms.Panel panel1;
		public ControlEditorView editorcontrol;
		public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		public System.Windows.Forms.Label lbLayer;
		public System.Windows.Forms.NumericUpDown spinLayer;
		public System.Windows.Forms.CheckBox b_hand;
		public System.Windows.Forms.CheckBox b_pencil;
		public System.Windows.Forms.CheckBox b_eraser;
		public System.Windows.Forms.CheckBox b_rectangle;
		public System.Windows.Forms.CheckBox b_bucket;
		public System.Windows.Forms.CheckBox b_logic;
		public System.Windows.Forms.CheckBox b_entityadd;
		public System.Windows.Forms.CheckBox b_entityselect;
		public System.Windows.Forms.CheckBox b_entityrectangle;
		public System.Windows.Forms.CheckBox b_entityselectall;
		public System.Windows.Forms.CheckBox b_entitymove;
		public System.Windows.Forms.CheckBox b_entityremove;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private MenuItem Edit;
		private MenuItem Option;
		private MenuItem Scale;
		private MenuItem Tools;
		private MenuItem Help;
		private TabPage tabPage6;
		public Menu menuStrip1;
		public ToolBar toolStrip1;

	}
}

