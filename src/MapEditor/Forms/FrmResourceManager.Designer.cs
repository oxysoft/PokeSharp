using MapEditor.Data.Controls.EditorView;

namespace MapEditor.Forms {
	partial class FrmResourceManager {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
		private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.tabs = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.lItems = new System.Windows.Forms.ListBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.textureViewerControl = new MapEditor.Data.Controls.EditorView.ControlTextureViewer();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.bNew = new System.Windows.Forms.ToolStripMenuItem();
			this.bRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.bExport = new System.Windows.Forms.ToolStripMenuItem();
			this.bImport = new System.Windows.Forms.ToolStripMenuItem();
			this.bExportContainer = new System.Windows.Forms.ToolStripMenuItem();
			this.bImportContainer = new System.Windows.Forms.ToolStripMenuItem();
			this.tabs.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(291, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 25;
			this.label1.Text = "Preview";
			// 
			// tabs
			// 
			this.tabs.Controls.Add(this.tabPage1);
			this.tabs.Controls.Add(this.tabPage2);
			this.tabs.Controls.Add(this.tabPage3);
			this.tabs.Controls.Add(this.tabPage4);
			this.tabs.Controls.Add(this.tabPage5);
			this.tabs.Location = new System.Drawing.Point(6, 27);
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(279, 291);
			this.tabs.TabIndex = 26;
			this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.lItems);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(271, 265);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Tilesests";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// lItems
			// 
			this.lItems.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lItems.FormattingEnabled = true;
			this.lItems.Location = new System.Drawing.Point(3, 3);
			this.lItems.Name = "lItems";
			this.lItems.Size = new System.Drawing.Size(265, 259);
			this.lItems.TabIndex = 0;
			this.lItems.SelectedIndexChanged += new System.EventHandler(this.lItems_SelectedIndexChanged);
			this.lItems.DoubleClick += new System.EventHandler(this.lItems_DoubleClick);
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(271, 265);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Entities";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(271, 265);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Animations";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// tabPage4
			// 
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(271, 265);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Music";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// tabPage5
			// 
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(271, 265);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Sfx";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// textureViewerControl
			// 
			this.textureViewerControl.GameLoopEnabled = false;
			this.textureViewerControl.Location = new System.Drawing.Point(293, 49);
			this.textureViewerControl.Name = "textureViewerControl";
			this.textureViewerControl.Size = new System.Drawing.Size(214, 269);
			this.textureViewerControl.TabIndex = 31;
			this.textureViewerControl.Text = "textureViewerControl1";
			this.textureViewerControl.Texture = null;
			this.textureViewerControl.TimeStep = 16.66666F;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bNew,
            this.bRemove,
            this.bExport,
            this.bImport,
            this.bExportContainer,
            this.bImportContainer});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(519, 24);
			this.menuStrip1.TabIndex = 36;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// bNew
			// 
			this.bNew.Image = global::MapEditor.Properties.Resources.map__plus;
			this.bNew.Name = "bNew";
			this.bNew.Size = new System.Drawing.Size(28, 20);
			this.bNew.Click += new System.EventHandler(this.bNew_Click);
			// 
			// bRemove
			// 
			this.bRemove.Image = global::MapEditor.Properties.Resources.cross;
			this.bRemove.Name = "bRemove";
			this.bRemove.RightToLeftAutoMirrorImage = true;
			this.bRemove.Size = new System.Drawing.Size(28, 20);
			this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
			// 
			// bExport
			// 
			this.bExport.Image = global::MapEditor.Properties.Resources.folder_export;
			this.bExport.Name = "bExport";
			this.bExport.Size = new System.Drawing.Size(68, 20);
			this.bExport.Text = "Export";
			this.bExport.Click += new System.EventHandler(this.bExport_Click);
			// 
			// bImport
			// 
			this.bImport.Image = global::MapEditor.Properties.Resources.folder_import;
			this.bImport.Name = "bImport";
			this.bImport.Size = new System.Drawing.Size(71, 20);
			this.bImport.Text = "Import";
			this.bImport.Click += new System.EventHandler(this.bImport_Click);
			// 
			// bExportContainer
			// 
			this.bExportContainer.Image = global::MapEditor.Properties.Resources.disk_black;
			this.bExportContainer.Name = "bExportContainer";
			this.bExportContainer.Size = new System.Drawing.Size(123, 20);
			this.bExportContainer.Text = "Export Container";
			this.bExportContainer.Click += new System.EventHandler(this.bExportContainer_Click2);
			// 
			// bImportContainer
			// 
			this.bImportContainer.Image = global::MapEditor.Properties.Resources.folder_open;
			this.bImportContainer.Name = "bImportContainer";
			this.bImportContainer.Size = new System.Drawing.Size(116, 20);
			this.bImportContainer.Text = "Load Container";
			this.bImportContainer.Click += new System.EventHandler(this.bImportContainer_Click);
			// 
			// FrmResourceManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(519, 325);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.textureViewerControl);
			this.Controls.Add(this.tabs);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmResourceManager";
			this.ShowIcon = false;
			this.Text = "Resource Manager";
			this.Load += new System.EventHandler(this.FrmResourceManager_Load);
			this.tabs.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.Label label1;
		private ControlTextureViewer textureViewerControl;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem bNew;
		private System.Windows.Forms.ToolStripMenuItem bRemove;
		private System.Windows.Forms.ToolStripMenuItem bImport;
		private System.Windows.Forms.ToolStripMenuItem bExport;
		private System.Windows.Forms.ToolStripMenuItem bExportContainer;
		private System.Windows.Forms.ToolStripMenuItem bImportContainer;
		private System.Windows.Forms.ListBox lItems;

	}
}