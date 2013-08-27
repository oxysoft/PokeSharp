namespace MapEditor.Forms {
	partial class FrmDatabase {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Library");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDatabase));
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabTilesets = new System.Windows.Forms.TabPage();
			this.tilesetControl = new MapEditor.Data.Controls.EditorView.ControlTilesetEditor();
			this.tilesetHScrollBar = new System.Windows.Forms.HScrollBar();
			this.label18 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.bImportTileset = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cbTilesetTileBehavior = new System.Windows.Forms.ComboBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.bTilesetImport = new System.Windows.Forms.Button();
			this.tbTilesetName = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.tilesetVScrollBar = new System.Windows.Forms.VScrollBar();
			this.cbTilesetMode = new System.Windows.Forms.ComboBox();
			this.bRemoveTileset = new System.Windows.Forms.Button();
			this.bAddTileset = new System.Windows.Forms.Button();
			this.listTilesets = new System.Windows.Forms.ListView();
			this.label14 = new System.Windows.Forms.Label();
			this.tabEntities = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.bEntitiesImport = new System.Windows.Forms.Button();
			this.bEntitiesExport = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.bEntityAnimation = new System.Windows.Forms.Button();
			this.cbEntityShadowType = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cbEntityType = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tbEntityRows = new System.Windows.Forms.NumericUpDown();
			this.tbEntityColumns = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.bEntityTextureImport = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.tbEntityName = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.cbEntityMode = new System.Windows.Forms.ComboBox();
			this.bRemoveEntity = new System.Windows.Forms.Button();
			this.bAddEntity = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.entityControl = new MapEditor.Data.Controls.EditorView.ControlEntityEditor();
			this.listEntities = new System.Windows.Forms.ListView();
			this.tabSprites = new System.Windows.Forms.TabPage();
			this.spriteControl = new MapEditor.Data.Controls.EditorView.ControlTextureViewer();
			this.gbSpriteLibraryProperties = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnImportSprite = new System.Windows.Forms.Button();
			this.tbSpriteName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbSpriteType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnRemoveSprite = new System.Windows.Forms.Button();
			this.btnNewSprite = new System.Windows.Forms.Button();
			this.spriteTree = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.tabAnimations = new System.Windows.Forms.TabPage();
			this.tabMusics = new System.Windows.Forms.TabPage();
			this.tabSounds = new System.Windows.Forms.TabPage();
			this.tabPokemon = new System.Windows.Forms.TabPage();
			this.tabAbilities = new System.Windows.Forms.TabPage();
			this.tabMoves = new System.Windows.Forms.TabPage();
			this.tabTrainerBattles = new System.Windows.Forms.TabPage();
			this.tabItems = new System.Windows.Forms.TabPage();
			this.tabRuntimeScripts = new System.Windows.Forms.TabPage();
			this.tabUserInterfaces = new System.Windows.Forms.TabPage();
			this.listUis = new System.Windows.Forms.ListView();
			this.uiScriptBox = new FastColoredTextBoxNS.FastColoredTextBox();
			this.bAddUI = new System.Windows.Forms.Button();
			this.bRemoveUI = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cMenuEntities = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cMenuEntity = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl.SuspendLayout();
			this.tabTilesets.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabEntities.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbEntityRows)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbEntityColumns)).BeginInit();
			this.tabSprites.SuspendLayout();
			this.gbSpriteLibraryProperties.SuspendLayout();
			this.tabUserInterfaces.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uiScriptBox)).BeginInit();
			this.cMenuEntity.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabTilesets);
			this.tabControl.Controls.Add(this.tabEntities);
			this.tabControl.Controls.Add(this.tabSprites);
			this.tabControl.Controls.Add(this.tabAnimations);
			this.tabControl.Controls.Add(this.tabMusics);
			this.tabControl.Controls.Add(this.tabSounds);
			this.tabControl.Controls.Add(this.tabPokemon);
			this.tabControl.Controls.Add(this.tabAbilities);
			this.tabControl.Controls.Add(this.tabMoves);
			this.tabControl.Controls.Add(this.tabTrainerBattles);
			this.tabControl.Controls.Add(this.tabItems);
			this.tabControl.Controls.Add(this.tabRuntimeScripts);
			this.tabControl.Controls.Add(this.tabUserInterfaces);
			this.tabControl.Location = new System.Drawing.Point(12, 12);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(757, 578);
			this.tabControl.TabIndex = 0;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
			// 
			// tabTilesets
			// 
			this.tabTilesets.Controls.Add(this.tilesetControl);
			this.tabTilesets.Controls.Add(this.tilesetHScrollBar);
			this.tabTilesets.Controls.Add(this.label18);
			this.tabTilesets.Controls.Add(this.groupBox4);
			this.tabTilesets.Controls.Add(this.tilesetVScrollBar);
			this.tabTilesets.Controls.Add(this.cbTilesetMode);
			this.tabTilesets.Controls.Add(this.bRemoveTileset);
			this.tabTilesets.Controls.Add(this.bAddTileset);
			this.tabTilesets.Controls.Add(this.listTilesets);
			this.tabTilesets.Controls.Add(this.label14);
			this.tabTilesets.Location = new System.Drawing.Point(4, 22);
			this.tabTilesets.Name = "tabTilesets";
			this.tabTilesets.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
			this.tabTilesets.Size = new System.Drawing.Size(749, 552);
			this.tabTilesets.TabIndex = 0;
			this.tabTilesets.Text = "Tilesets";
			this.tabTilesets.UseVisualStyleBackColor = true;
			// 
			// tilesetControl
			// 
			this.tilesetControl.GameLoopEnabled = true;
			this.tilesetControl.Location = new System.Drawing.Point(451, 65);
			this.tilesetControl.Name = "tilesetControl";
			this.tilesetControl.Size = new System.Drawing.Size(272, 452);
			this.tilesetControl.TabIndex = 15;
			this.tilesetControl.Text = "tilesetEditorControl1";
			this.tilesetControl.Tileset = null;
			this.tilesetControl.TimeStep = 16.66666F;
			// 
			// tilesetHScrollBar
			// 
			this.tilesetHScrollBar.Location = new System.Drawing.Point(451, 520);
			this.tilesetHScrollBar.Name = "tilesetHScrollBar";
			this.tilesetHScrollBar.Size = new System.Drawing.Size(273, 17);
			this.tilesetHScrollBar.TabIndex = 14;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(448, 41);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(37, 13);
			this.label18.TabIndex = 13;
			this.label18.Text = "Mode:";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.bImportTileset);
			this.groupBox4.Controls.Add(this.button2);
			this.groupBox4.Controls.Add(this.groupBox3);
			this.groupBox4.Location = new System.Drawing.Point(186, 32);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(10, 6, 6, 6);
			this.groupBox4.Size = new System.Drawing.Size(258, 215);
			this.groupBox4.TabIndex = 12;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Tileset container";
			// 
			// bImportTileset
			// 
			this.bImportTileset.Location = new System.Drawing.Point(13, 23);
			this.bImportTileset.Name = "bImportTileset";
			this.bImportTileset.Size = new System.Drawing.Size(75, 23);
			this.bImportTileset.TabIndex = 10;
			this.bImportTileset.Text = "Import";
			this.bImportTileset.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(94, 23);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 9;
			this.button2.Text = "Export";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cbTilesetTileBehavior);
			this.groupBox3.Controls.Add(this.label17);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.bTilesetImport);
			this.groupBox3.Controls.Add(this.tbTilesetName);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Location = new System.Drawing.Point(13, 60);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(10, 3, 6, 3);
			this.groupBox3.Size = new System.Drawing.Size(236, 146);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Tileset";
			// 
			// cbTilesetTileBehavior
			// 
			this.cbTilesetTileBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTilesetTileBehavior.Enabled = false;
			this.cbTilesetTileBehavior.FormattingEnabled = true;
			this.cbTilesetTileBehavior.Location = new System.Drawing.Point(16, 113);
			this.cbTilesetTileBehavior.Name = "cbTilesetTileBehavior";
			this.cbTilesetTileBehavior.Size = new System.Drawing.Size(211, 21);
			this.cbTilesetTileBehavior.TabIndex = 12;
			this.cbTilesetTileBehavior.SelectedIndexChanged += new System.EventHandler(this.cbTilesetTileBehavior_SelectedIndexChanged);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(13, 97);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(112, 13);
			this.label17.TabIndex = 4;
			this.label17.Text = "Selected tile behavior:";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(13, 55);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(46, 13);
			this.label16.TabIndex = 3;
			this.label16.Text = "Texture:";
			// 
			// bTilesetImport
			// 
			this.bTilesetImport.Enabled = false;
			this.bTilesetImport.Location = new System.Drawing.Point(16, 71);
			this.bTilesetImport.Name = "bTilesetImport";
			this.bTilesetImport.Size = new System.Drawing.Size(211, 23);
			this.bTilesetImport.TabIndex = 2;
			this.bTilesetImport.Text = "Import";
			this.bTilesetImport.UseVisualStyleBackColor = true;
			this.bTilesetImport.Click += new System.EventHandler(this.bTilesetImport_Click);
			// 
			// tbTilesetName
			// 
			this.tbTilesetName.Enabled = false;
			this.tbTilesetName.Location = new System.Drawing.Point(16, 32);
			this.tbTilesetName.Name = "tbTilesetName";
			this.tbTilesetName.Size = new System.Drawing.Size(211, 20);
			this.tbTilesetName.TabIndex = 1;
			this.tbTilesetName.TextChanged += new System.EventHandler(this.tbTilesetName_TextChanged);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(13, 16);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(38, 13);
			this.label15.TabIndex = 0;
			this.label15.Text = "Name:";
			// 
			// tilesetVScrollBar
			// 
			this.tilesetVScrollBar.Location = new System.Drawing.Point(727, 65);
			this.tilesetVScrollBar.Name = "tilesetVScrollBar";
			this.tilesetVScrollBar.Size = new System.Drawing.Size(17, 452);
			this.tilesetVScrollBar.TabIndex = 11;
			// 
			// cbTilesetMode
			// 
			this.cbTilesetMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTilesetMode.FormattingEnabled = true;
			this.cbTilesetMode.Items.AddRange(new object[] {
            "View",
            "Default tile behavior"});
			this.cbTilesetMode.Location = new System.Drawing.Point(491, 38);
			this.cbTilesetMode.Name = "cbTilesetMode";
			this.cbTilesetMode.Size = new System.Drawing.Size(232, 21);
			this.cbTilesetMode.TabIndex = 9;
			this.cbTilesetMode.SelectedIndexChanged += new System.EventHandler(this.cbTilesetMode_SelectedIndexChanged);
			// 
			// bRemoveTileset
			// 
			this.bRemoveTileset.Enabled = false;
			this.bRemoveTileset.Location = new System.Drawing.Point(102, 523);
			this.bRemoveTileset.Name = "bRemoveTileset";
			this.bRemoveTileset.Size = new System.Drawing.Size(78, 23);
			this.bRemoveTileset.TabIndex = 7;
			this.bRemoveTileset.Text = "Delete";
			this.bRemoveTileset.UseVisualStyleBackColor = true;
			this.bRemoveTileset.Click += new System.EventHandler(this.bRemoveTileset_Click);
			// 
			// bAddTileset
			// 
			this.bAddTileset.Location = new System.Drawing.Point(8, 523);
			this.bAddTileset.Name = "bAddTileset";
			this.bAddTileset.Size = new System.Drawing.Size(78, 23);
			this.bAddTileset.TabIndex = 6;
			this.bAddTileset.Text = "Add";
			this.bAddTileset.UseVisualStyleBackColor = true;
			this.bAddTileset.Click += new System.EventHandler(this.bAddTileset_Click);
			// 
			// listTilesets
			// 
			this.listTilesets.Location = new System.Drawing.Point(8, 32);
			this.listTilesets.MultiSelect = false;
			this.listTilesets.Name = "listTilesets";
			this.listTilesets.Size = new System.Drawing.Size(172, 485);
			this.listTilesets.TabIndex = 3;
			this.listTilesets.UseCompatibleStateImageBehavior = false;
			this.listTilesets.View = System.Windows.Forms.View.List;
			this.listTilesets.SelectedIndexChanged += new System.EventHandler(this.listTilesets_SelectedIndexChanged);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(45, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(99, 29);
			this.label14.TabIndex = 2;
			this.label14.Text = "Tilesets";
			// 
			// tabEntities
			// 
			this.tabEntities.Controls.Add(this.groupBox2);
			this.tabEntities.Controls.Add(this.label13);
			this.tabEntities.Controls.Add(this.cbEntityMode);
			this.tabEntities.Controls.Add(this.bRemoveEntity);
			this.tabEntities.Controls.Add(this.bAddEntity);
			this.tabEntities.Controls.Add(this.label6);
			this.tabEntities.Controls.Add(this.entityControl);
			this.tabEntities.Controls.Add(this.listEntities);
			this.tabEntities.Location = new System.Drawing.Point(4, 22);
			this.tabEntities.Name = "tabEntities";
			this.tabEntities.Size = new System.Drawing.Size(749, 552);
			this.tabEntities.TabIndex = 1;
			this.tabEntities.Text = "Entities";
			this.tabEntities.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.bEntitiesImport);
			this.groupBox2.Controls.Add(this.bEntitiesExport);
			this.groupBox2.Controls.Add(this.groupBox1);
			this.groupBox2.Location = new System.Drawing.Point(186, 32);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(10, 6, 6, 6);
			this.groupBox2.Size = new System.Drawing.Size(234, 407);
			this.groupBox2.TabIndex = 16;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Entity Container";
			// 
			// bEntitiesImport
			// 
			this.bEntitiesImport.Location = new System.Drawing.Point(13, 23);
			this.bEntitiesImport.Name = "bEntitiesImport";
			this.bEntitiesImport.Size = new System.Drawing.Size(75, 23);
			this.bEntitiesImport.TabIndex = 8;
			this.bEntitiesImport.Text = "Import";
			this.bEntitiesImport.UseVisualStyleBackColor = true;
			this.bEntitiesImport.Click += new System.EventHandler(this.bEntitiesImport_Click);
			// 
			// bEntitiesExport
			// 
			this.bEntitiesExport.Location = new System.Drawing.Point(94, 23);
			this.bEntitiesExport.Name = "bEntitiesExport";
			this.bEntitiesExport.Size = new System.Drawing.Size(75, 23);
			this.bEntitiesExport.TabIndex = 7;
			this.bEntitiesExport.Text = "Export";
			this.bEntitiesExport.UseVisualStyleBackColor = true;
			this.bEntitiesExport.Click += new System.EventHandler(this.bEntitiesExport_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.bEntityAnimation);
			this.groupBox1.Controls.Add(this.cbEntityShadowType);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.cbEntityType);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.tbEntityRows);
			this.groupBox1.Controls.Add(this.tbEntityColumns);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.bEntityTextureImport);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.tbEntityName);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Location = new System.Drawing.Point(13, 60);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
			this.groupBox1.Size = new System.Drawing.Size(212, 338);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Selected Entity";
			// 
			// bEntityAnimation
			// 
			this.bEntityAnimation.Enabled = false;
			this.bEntityAnimation.Location = new System.Drawing.Point(16, 293);
			this.bEntityAnimation.Name = "bEntityAnimation";
			this.bEntityAnimation.Size = new System.Drawing.Size(190, 23);
			this.bEntityAnimation.TabIndex = 13;
			this.bEntityAnimation.Text = "Edit animation";
			this.bEntityAnimation.UseVisualStyleBackColor = true;
			this.bEntityAnimation.Click += new System.EventHandler(this.bEntityAnimation_Click);
			// 
			// cbEntityShadowType
			// 
			this.cbEntityShadowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEntityShadowType.Enabled = false;
			this.cbEntityShadowType.FormattingEnabled = true;
			this.cbEntityShadowType.Items.AddRange(new object[] {
            "None",
            "Perspective"});
			this.cbEntityShadowType.Location = new System.Drawing.Point(16, 251);
			this.cbEntityShadowType.Name = "cbEntityShadowType";
			this.cbEntityShadowType.Size = new System.Drawing.Size(190, 21);
			this.cbEntityShadowType.TabIndex = 11;
			this.cbEntityShadowType.SelectedIndexChanged += new System.EventHandler(this.cbEntityShadowType_SelectedIndexChanged);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(13, 235);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(76, 13);
			this.label12.TabIndex = 10;
			this.label12.Text = "Shadow Type:";
			// 
			// cbEntityType
			// 
			this.cbEntityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEntityType.Enabled = false;
			this.cbEntityType.FormattingEnabled = true;
			this.cbEntityType.Items.AddRange(new object[] {
            "None",
            "Building",
            "Warpfield",
            "Door",
            "Player",
            "Npc"});
			this.cbEntityType.Location = new System.Drawing.Point(16, 207);
			this.cbEntityType.Name = "cbEntityType";
			this.cbEntityType.Size = new System.Drawing.Size(190, 21);
			this.cbEntityType.TabIndex = 9;
			this.cbEntityType.SelectedIndexChanged += new System.EventHandler(this.cbEntityType_SelectedIndexChanged);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(13, 191);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(63, 13);
			this.label11.TabIndex = 8;
			this.label11.Text = "Entity Type:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(13, 149);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(37, 13);
			this.label10.TabIndex = 7;
			this.label10.Text = "Rows:";
			// 
			// tbEntityRows
			// 
			this.tbEntityRows.Enabled = false;
			this.tbEntityRows.Location = new System.Drawing.Point(16, 165);
			this.tbEntityRows.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.tbEntityRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tbEntityRows.Name = "tbEntityRows";
			this.tbEntityRows.Size = new System.Drawing.Size(190, 20);
			this.tbEntityRows.TabIndex = 6;
			this.tbEntityRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tbEntityRows.ValueChanged += new System.EventHandler(this.tbEntityRows_ValueChanged);
			// 
			// tbEntityColumns
			// 
			this.tbEntityColumns.Enabled = false;
			this.tbEntityColumns.Location = new System.Drawing.Point(16, 126);
			this.tbEntityColumns.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.tbEntityColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tbEntityColumns.Name = "tbEntityColumns";
			this.tbEntityColumns.Size = new System.Drawing.Size(190, 20);
			this.tbEntityColumns.TabIndex = 5;
			this.tbEntityColumns.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tbEntityColumns.ValueChanged += new System.EventHandler(this.tbEntityColumns_ValueChanged);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(13, 110);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(50, 13);
			this.label9.TabIndex = 4;
			this.label9.Text = "Columns:";
			// 
			// bEntityTextureImport
			// 
			this.bEntityTextureImport.Enabled = false;
			this.bEntityTextureImport.Location = new System.Drawing.Point(16, 77);
			this.bEntityTextureImport.Name = "bEntityTextureImport";
			this.bEntityTextureImport.Size = new System.Drawing.Size(190, 23);
			this.bEntityTextureImport.TabIndex = 3;
			this.bEntityTextureImport.Text = "Import texture";
			this.bEntityTextureImport.UseVisualStyleBackColor = true;
			this.bEntityTextureImport.Click += new System.EventHandler(this.bEntityTextureImport_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(13, 61);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(46, 13);
			this.label8.TabIndex = 2;
			this.label8.Text = "Texture:";
			// 
			// tbEntityName
			// 
			this.tbEntityName.Enabled = false;
			this.tbEntityName.Location = new System.Drawing.Point(16, 32);
			this.tbEntityName.Name = "tbEntityName";
			this.tbEntityName.Size = new System.Drawing.Size(190, 20);
			this.tbEntityName.TabIndex = 1;
			this.tbEntityName.TextChanged += new System.EventHandler(this.tbEntityName_TextChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(13, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(38, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "Name:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(423, 526);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(37, 13);
			this.label13.TabIndex = 14;
			this.label13.Text = "Mode:";
			// 
			// cbEntityMode
			// 
			this.cbEntityMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEntityMode.FormattingEnabled = true;
			this.cbEntityMode.Items.AddRange(new object[] {
            "Texture Viewer",
            "Collision Mapping",
            "Shadow Offset"});
			this.cbEntityMode.Location = new System.Drawing.Point(466, 523);
			this.cbEntityMode.Name = "cbEntityMode";
			this.cbEntityMode.Size = new System.Drawing.Size(280, 21);
			this.cbEntityMode.TabIndex = 14;
			this.cbEntityMode.SelectedIndexChanged += new System.EventHandler(this.cbEntityMode_SelectedIndexChanged);
			// 
			// bRemoveEntity
			// 
			this.bRemoveEntity.Location = new System.Drawing.Point(102, 523);
			this.bRemoveEntity.Name = "bRemoveEntity";
			this.bRemoveEntity.Size = new System.Drawing.Size(78, 23);
			this.bRemoveEntity.TabIndex = 5;
			this.bRemoveEntity.Text = "Delete";
			this.bRemoveEntity.UseVisualStyleBackColor = true;
			this.bRemoveEntity.Click += new System.EventHandler(this.bRemoveEntity_Click);
			// 
			// bAddEntity
			// 
			this.bAddEntity.Location = new System.Drawing.Point(8, 523);
			this.bAddEntity.Name = "bAddEntity";
			this.bAddEntity.Size = new System.Drawing.Size(78, 23);
			this.bAddEntity.TabIndex = 4;
			this.bAddEntity.Text = "Add";
			this.bAddEntity.UseVisualStyleBackColor = true;
			this.bAddEntity.Click += new System.EventHandler(this.bAddEntity_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(48, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(92, 29);
			this.label6.TabIndex = 1;
			this.label6.Text = "Entities";
			// 
			// entityControl
			// 
			this.entityControl.GameLoopEnabled = true;
			this.entityControl.List = null;
			this.entityControl.Location = new System.Drawing.Point(426, 32);
			this.entityControl.Mode = 0;
			this.entityControl.Name = "entityControl";
			this.entityControl.Size = new System.Drawing.Size(320, 485);
			this.entityControl.TabIndex = 15;
			this.entityControl.Text = "entityEditorControl1";
			this.entityControl.TimeStep = 16.66666F;
			// 
			// listEntities
			// 
			this.listEntities.Location = new System.Drawing.Point(8, 32);
			this.listEntities.MultiSelect = false;
			this.listEntities.Name = "listEntities";
			this.listEntities.Size = new System.Drawing.Size(172, 485);
			this.listEntities.TabIndex = 0;
			this.listEntities.UseCompatibleStateImageBehavior = false;
			this.listEntities.View = System.Windows.Forms.View.List;
			this.listEntities.SelectedIndexChanged += new System.EventHandler(this.listEntities_SelectedIndexChanged);
			this.listEntities.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listEntities_MouseUp);
			// 
			// tabSprites
			// 
			this.tabSprites.Controls.Add(this.spriteControl);
			this.tabSprites.Controls.Add(this.gbSpriteLibraryProperties);
			this.tabSprites.Controls.Add(this.btnRemoveSprite);
			this.tabSprites.Controls.Add(this.btnNewSprite);
			this.tabSprites.Controls.Add(this.spriteTree);
			this.tabSprites.Controls.Add(this.label2);
			this.tabSprites.Location = new System.Drawing.Point(4, 22);
			this.tabSprites.Name = "tabSprites";
			this.tabSprites.Size = new System.Drawing.Size(749, 552);
			this.tabSprites.TabIndex = 2;
			this.tabSprites.Text = "Sprites";
			this.tabSprites.UseVisualStyleBackColor = true;
			// 
			// spriteControl
			// 
			this.spriteControl.BackColor = System.Drawing.Color.DarkSlateBlue;
			this.spriteControl.CenteredTexture = false;
			this.spriteControl.GameLoopEnabled = false;
			this.spriteControl.Location = new System.Drawing.Point(392, 34);
			this.spriteControl.Name = "spriteControl";
			this.spriteControl.Size = new System.Drawing.Size(352, 512);
			this.spriteControl.TabIndex = 6;
			this.spriteControl.Text = "textureViewerControl1";
			this.spriteControl.Texture = null;
			this.spriteControl.TimeStep = 16.66666F;
			// 
			// gbSpriteLibraryProperties
			// 
			this.gbSpriteLibraryProperties.Controls.Add(this.label5);
			this.gbSpriteLibraryProperties.Controls.Add(this.btnImportSprite);
			this.gbSpriteLibraryProperties.Controls.Add(this.tbSpriteName);
			this.gbSpriteLibraryProperties.Controls.Add(this.label4);
			this.gbSpriteLibraryProperties.Controls.Add(this.tbSpriteType);
			this.gbSpriteLibraryProperties.Controls.Add(this.label3);
			this.gbSpriteLibraryProperties.Location = new System.Drawing.Point(165, 27);
			this.gbSpriteLibraryProperties.Name = "gbSpriteLibraryProperties";
			this.gbSpriteLibraryProperties.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
			this.gbSpriteLibraryProperties.Size = new System.Drawing.Size(221, 519);
			this.gbSpriteLibraryProperties.TabIndex = 5;
			this.gbSpriteLibraryProperties.TabStop = false;
			this.gbSpriteLibraryProperties.Text = "Properties";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 95);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(37, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Sprite:";
			// 
			// btnImportSprite
			// 
			this.btnImportSprite.Enabled = false;
			this.btnImportSprite.Location = new System.Drawing.Point(16, 111);
			this.btnImportSprite.Name = "btnImportSprite";
			this.btnImportSprite.Size = new System.Drawing.Size(199, 21);
			this.btnImportSprite.TabIndex = 10;
			this.btnImportSprite.Text = "Import sprite ...";
			this.btnImportSprite.UseVisualStyleBackColor = true;
			this.btnImportSprite.Click += new System.EventHandler(this.btnImportSprite_Click);
			// 
			// tbSpriteName
			// 
			this.tbSpriteName.Enabled = false;
			this.tbSpriteName.Location = new System.Drawing.Point(16, 32);
			this.tbSpriteName.Name = "tbSpriteName";
			this.tbSpriteName.Size = new System.Drawing.Size(199, 20);
			this.tbSpriteName.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Name:";
			// 
			// tbSpriteType
			// 
			this.tbSpriteType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tbSpriteType.Enabled = false;
			this.tbSpriteType.FormattingEnabled = true;
			this.tbSpriteType.Items.AddRange(new object[] {
            "Sprite",
            "Folder"});
			this.tbSpriteType.Location = new System.Drawing.Point(16, 71);
			this.tbSpriteType.Name = "tbSpriteType";
			this.tbSpriteType.Size = new System.Drawing.Size(199, 21);
			this.tbSpriteType.TabIndex = 1;
			this.tbSpriteType.SelectedIndexChanged += new System.EventHandler(this.tbSpriteType_SelectedIndexChanged);
			this.tbSpriteType.Enter += new System.EventHandler(this.tbSpriteType_Enter);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 55);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Type:";
			// 
			// btnRemoveSprite
			// 
			this.btnRemoveSprite.Location = new System.Drawing.Point(86, 523);
			this.btnRemoveSprite.Name = "btnRemoveSprite";
			this.btnRemoveSprite.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveSprite.TabIndex = 4;
			this.btnRemoveSprite.Text = "Remove";
			this.btnRemoveSprite.UseVisualStyleBackColor = true;
			this.btnRemoveSprite.Click += new System.EventHandler(this.btnRemoveSprite_Click);
			// 
			// btnNewSprite
			// 
			this.btnNewSprite.Location = new System.Drawing.Point(8, 523);
			this.btnNewSprite.Name = "btnNewSprite";
			this.btnNewSprite.Size = new System.Drawing.Size(75, 23);
			this.btnNewSprite.TabIndex = 3;
			this.btnNewSprite.Text = "Add";
			this.btnNewSprite.UseVisualStyleBackColor = true;
			this.btnNewSprite.Click += new System.EventHandler(this.btnNewSprite_Click);
			// 
			// spriteTree
			// 
			this.spriteTree.ImageKey = "box.png";
			this.spriteTree.ImageList = this.imageList1;
			this.spriteTree.LabelEdit = true;
			this.spriteTree.Location = new System.Drawing.Point(8, 32);
			this.spriteTree.Name = "spriteTree";
			treeNode1.Name = "Node0";
			treeNode1.Text = "Library";
			this.spriteTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
			this.spriteTree.SelectedImageKey = "box.png";
			this.spriteTree.Size = new System.Drawing.Size(151, 485);
			this.spriteTree.TabIndex = 2;
			this.spriteTree.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tSpriteLibrary_BeforeLabelEdit);
			this.spriteTree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tSpriteLibrary_AfterLabelEdit);
			this.spriteTree.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tSpriteLibrary_AfterCollapse);
			this.spriteTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tSpriteLibrary_AfterExpand);
			this.spriteTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tSpriteLibrary_AfterSelect);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "box.png");
			this.imageList1.Images.SetKeyName(1, "image.png");
			this.imageList1.Images.SetKeyName(2, "folder.png");
			this.imageList1.Images.SetKeyName(3, "folder-open.png");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(6, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(156, 29);
			this.label2.TabIndex = 1;
			this.label2.Text = "Sprite Library";
			// 
			// tabAnimations
			// 
			this.tabAnimations.Location = new System.Drawing.Point(4, 22);
			this.tabAnimations.Name = "tabAnimations";
			this.tabAnimations.Size = new System.Drawing.Size(749, 552);
			this.tabAnimations.TabIndex = 12;
			this.tabAnimations.Text = "Animations";
			this.tabAnimations.UseVisualStyleBackColor = true;
			// 
			// tabMusics
			// 
			this.tabMusics.Location = new System.Drawing.Point(4, 22);
			this.tabMusics.Name = "tabMusics";
			this.tabMusics.Size = new System.Drawing.Size(749, 552);
			this.tabMusics.TabIndex = 3;
			this.tabMusics.Text = "Musics";
			this.tabMusics.UseVisualStyleBackColor = true;
			// 
			// tabSounds
			// 
			this.tabSounds.Location = new System.Drawing.Point(4, 22);
			this.tabSounds.Name = "tabSounds";
			this.tabSounds.Size = new System.Drawing.Size(749, 552);
			this.tabSounds.TabIndex = 4;
			this.tabSounds.Text = "Sounds";
			this.tabSounds.UseVisualStyleBackColor = true;
			// 
			// tabPokemon
			// 
			this.tabPokemon.Location = new System.Drawing.Point(4, 22);
			this.tabPokemon.Name = "tabPokemon";
			this.tabPokemon.Size = new System.Drawing.Size(749, 552);
			this.tabPokemon.TabIndex = 11;
			this.tabPokemon.Text = "Pokemon";
			this.tabPokemon.UseVisualStyleBackColor = true;
			// 
			// tabAbilities
			// 
			this.tabAbilities.Location = new System.Drawing.Point(4, 22);
			this.tabAbilities.Name = "tabAbilities";
			this.tabAbilities.Size = new System.Drawing.Size(749, 552);
			this.tabAbilities.TabIndex = 5;
			this.tabAbilities.Text = "Abilities";
			this.tabAbilities.UseVisualStyleBackColor = true;
			// 
			// tabMoves
			// 
			this.tabMoves.Location = new System.Drawing.Point(4, 22);
			this.tabMoves.Name = "tabMoves";
			this.tabMoves.Size = new System.Drawing.Size(749, 552);
			this.tabMoves.TabIndex = 6;
			this.tabMoves.Text = "Moves";
			this.tabMoves.UseVisualStyleBackColor = true;
			// 
			// tabTrainerBattles
			// 
			this.tabTrainerBattles.Location = new System.Drawing.Point(4, 22);
			this.tabTrainerBattles.Name = "tabTrainerBattles";
			this.tabTrainerBattles.Size = new System.Drawing.Size(749, 552);
			this.tabTrainerBattles.TabIndex = 10;
			this.tabTrainerBattles.Text = "Trainer Battles";
			this.tabTrainerBattles.UseVisualStyleBackColor = true;
			// 
			// tabItems
			// 
			this.tabItems.Location = new System.Drawing.Point(4, 22);
			this.tabItems.Name = "tabItems";
			this.tabItems.Size = new System.Drawing.Size(749, 552);
			this.tabItems.TabIndex = 7;
			this.tabItems.Text = "Items";
			this.tabItems.UseVisualStyleBackColor = true;
			// 
			// tabRuntimeScripts
			// 
			this.tabRuntimeScripts.Location = new System.Drawing.Point(4, 22);
			this.tabRuntimeScripts.Name = "tabRuntimeScripts";
			this.tabRuntimeScripts.Size = new System.Drawing.Size(749, 552);
			this.tabRuntimeScripts.TabIndex = 8;
			this.tabRuntimeScripts.Text = "Runtime Scripts";
			this.tabRuntimeScripts.UseVisualStyleBackColor = true;
			// 
			// tabUserInterfaces
			// 
			this.tabUserInterfaces.Controls.Add(this.listUis);
			this.tabUserInterfaces.Controls.Add(this.uiScriptBox);
			this.tabUserInterfaces.Controls.Add(this.bAddUI);
			this.tabUserInterfaces.Controls.Add(this.bRemoveUI);
			this.tabUserInterfaces.Controls.Add(this.label1);
			this.tabUserInterfaces.Location = new System.Drawing.Point(4, 22);
			this.tabUserInterfaces.Name = "tabUserInterfaces";
			this.tabUserInterfaces.Size = new System.Drawing.Size(749, 552);
			this.tabUserInterfaces.TabIndex = 9;
			this.tabUserInterfaces.Text = "User interfaces";
			this.tabUserInterfaces.UseVisualStyleBackColor = true;
			// 
			// listUis
			// 
			this.listUis.LabelEdit = true;
			this.listUis.Location = new System.Drawing.Point(8, 32);
			this.listUis.Name = "listUis";
			this.listUis.Size = new System.Drawing.Size(172, 485);
			this.listUis.TabIndex = 5;
			this.listUis.UseCompatibleStateImageBehavior = false;
			this.listUis.View = System.Windows.Forms.View.List;
			this.listUis.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listUis_AfterLabelEdit);
			this.listUis.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listUis_BeforeLabelEdit);
			this.listUis.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listUis_MouseClick);
			// 
			// uiScriptBox
			// 
			this.uiScriptBox.AutoScrollMinSize = new System.Drawing.Size(2, 14);
			this.uiScriptBox.BackBrush = null;
			this.uiScriptBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.uiScriptBox.CurrentLineColor = System.Drawing.Color.LightGray;
			this.uiScriptBox.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.uiScriptBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.uiScriptBox.IsReplaceMode = false;
			this.uiScriptBox.Language = FastColoredTextBoxNS.Language.CSharp;
			this.uiScriptBox.LeftBracket = '(';
			this.uiScriptBox.LineNumberColor = System.Drawing.Color.BlueViolet;
			this.uiScriptBox.Location = new System.Drawing.Point(186, 32);
			this.uiScriptBox.Name = "uiScriptBox";
			this.uiScriptBox.Paddings = new System.Windows.Forms.Padding(0);
			this.uiScriptBox.RightBracket = ')';
			this.uiScriptBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.uiScriptBox.Size = new System.Drawing.Size(547, 514);
			this.uiScriptBox.TabIndex = 4;
			this.uiScriptBox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.uiScriptBox_TextChanged);
			// 
			// bAddUI
			// 
			this.bAddUI.Location = new System.Drawing.Point(8, 523);
			this.bAddUI.Name = "bAddUI";
			this.bAddUI.Size = new System.Drawing.Size(78, 23);
			this.bAddUI.TabIndex = 3;
			this.bAddUI.Text = "Add";
			this.bAddUI.UseVisualStyleBackColor = true;
			this.bAddUI.Click += new System.EventHandler(this.bAddUI_Click);
			// 
			// bRemoveUI
			// 
			this.bRemoveUI.Location = new System.Drawing.Point(102, 523);
			this.bRemoveUI.Name = "bRemoveUI";
			this.bRemoveUI.Size = new System.Drawing.Size(78, 23);
			this.bRemoveUI.TabIndex = 2;
			this.bRemoveUI.Text = "Remove";
			this.bRemoveUI.UseVisualStyleBackColor = true;
			this.bRemoveUI.Click += new System.EventHandler(this.bRemoveUI_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(6, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(174, 29);
			this.label1.TabIndex = 0;
			this.label1.Text = "User Interfaces";
			// 
			// cMenuEntities
			// 
			this.cMenuEntities.Name = "cMenuEntities";
			this.cMenuEntities.Size = new System.Drawing.Size(61, 4);
			// 
			// cMenuEntity
			// 
			this.cMenuEntity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator2,
            this.duplicateToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem});
			this.cMenuEntity.Name = "cMenuEntity";
			this.cMenuEntity.Size = new System.Drawing.Size(125, 126);
			this.cMenuEntity.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cMenuEntity_ItemClicked);
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.newToolStripMenuItem.Text = "New";
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(121, 6);
			// 
			// duplicateToolStripMenuItem
			// 
			this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
			this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.duplicateToolStripMenuItem.Text = "Duplicate";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			// 
			// FrmDatabase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(781, 602);
			this.Controls.Add(this.tabControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmDatabase";
			this.Text = "Database";
			this.Load += new System.EventHandler(this.FrmDatabase_Load);
			this.tabControl.ResumeLayout(false);
			this.tabTilesets.ResumeLayout(false);
			this.tabTilesets.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabEntities.ResumeLayout(false);
			this.tabEntities.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbEntityRows)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbEntityColumns)).EndInit();
			this.tabSprites.ResumeLayout(false);
			this.tabSprites.PerformLayout();
			this.gbSpriteLibraryProperties.ResumeLayout(false);
			this.gbSpriteLibraryProperties.PerformLayout();
			this.tabUserInterfaces.ResumeLayout(false);
			this.tabUserInterfaces.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.uiScriptBox)).EndInit();
			this.cMenuEntity.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabTilesets;
		private System.Windows.Forms.TabPage tabEntities;
		private System.Windows.Forms.TabPage tabSprites;
		private System.Windows.Forms.TabPage tabAnimations;
		private System.Windows.Forms.TabPage tabMusics;
		private System.Windows.Forms.TabPage tabSounds;
		private System.Windows.Forms.TabPage tabPokemon;
		private System.Windows.Forms.TabPage tabAbilities;
		private System.Windows.Forms.TabPage tabMoves;
		private System.Windows.Forms.TabPage tabTrainerBattles;
		private System.Windows.Forms.TabPage tabItems;
		private System.Windows.Forms.TabPage tabRuntimeScripts;
		private System.Windows.Forms.TabPage tabUserInterfaces;
		private System.Windows.Forms.Button bAddUI;
		private System.Windows.Forms.Button bRemoveUI;
		private System.Windows.Forms.Label label1;
		private FastColoredTextBoxNS.FastColoredTextBox uiScriptBox;
		private System.Windows.Forms.ListView listUis;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TreeView spriteTree;
		private Data.Controls.EditorView.ControlTextureViewer spriteControl;
		private System.Windows.Forms.GroupBox gbSpriteLibraryProperties;
		private System.Windows.Forms.Button btnRemoveSprite;
		private System.Windows.Forms.Button btnNewSprite;
		private System.Windows.Forms.TextBox tbSpriteName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox tbSpriteType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnImportSprite;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ListView listEntities;
		private System.Windows.Forms.Button bRemoveEntity;
		private System.Windows.Forms.Button bAddEntity;
		private System.Windows.Forms.ContextMenuStrip cMenuEntities;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cbEntityShadowType;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox cbEntityType;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown tbEntityRows;
		private System.Windows.Forms.NumericUpDown tbEntityColumns;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button bEntityTextureImport;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbEntityName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button bEntityAnimation;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox cbEntityMode;
		private Data.Controls.EditorView.ControlEntityEditor entityControl;
		private System.Windows.Forms.ContextMenuStrip cMenuEntity;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button bEntitiesImport;
		private System.Windows.Forms.Button bEntitiesExport;
		private System.Windows.Forms.ListView listTilesets;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button bRemoveTileset;
		private System.Windows.Forms.Button bAddTileset;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox tbTilesetName;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button bTilesetImport;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.ComboBox cbTilesetMode;
		private System.Windows.Forms.VScrollBar tilesetVScrollBar;
		private System.Windows.Forms.ComboBox cbTilesetTileBehavior;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button bImportTileset;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.HScrollBar tilesetHScrollBar;
		private Data.Controls.EditorView.ControlTilesetEditor tilesetControl;
	}
}