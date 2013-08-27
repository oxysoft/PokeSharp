using MapEditor.Data.Controls.EditorView;

namespace MapEditor.Forms.Form_Selectors {
	partial class FrmLogicTileSelector {

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
			this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
			this.logicViewerSelectorControl1 = new MapEditor.Data.Controls.EditorView.ControlLogicSelector();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnTools = new System.Windows.Forms.ToolStripDropDownButton();
			this.btnPencil = new System.Windows.Forms.ToolStripMenuItem();
			this.btnRectangle = new System.Windows.Forms.ToolStripMenuItem();
			this.btnBucket = new System.Windows.Forms.ToolStripMenuItem();
			this.btnPath = new System.Windows.Forms.ToolStripMenuItem();
			this.lbSizeIndicator = new System.Windows.Forms.ToolStripLabel();
			this.btnSizeDecrease = new System.Windows.Forms.ToolStripButton();
			this.lbSize = new System.Windows.Forms.ToolStripLabel();
			this.btnSizeIncrease = new System.Windows.Forms.ToolStripButton();
			this.btnUseSameTypeLogic = new System.Windows.Forms.ToolStripButton();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnCorrectSameTypeTile = new System.Windows.Forms.ToolStripMenuItem();
			this.btnCorrectOtherTypeTile = new System.Windows.Forms.ToolStripMenuItem();
			this.btnReloadAll = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip2 = new System.Windows.Forms.MenuStrip();
			this.lbTileName = new System.Windows.Forms.ToolStripTextBox();
			this.toolStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.menuStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// vScrollBar1
			// 
			this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
			this.vScrollBar1.Location = new System.Drawing.Point(259, 49);
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new System.Drawing.Size(17, 180);
			this.vScrollBar1.TabIndex = 2;
			// 
			// logicViewerSelectorControl1
			// 
			this.logicViewerSelectorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logicViewerSelectorControl1.GameLoopEnabled = true;
			this.logicViewerSelectorControl1.Location = new System.Drawing.Point(0, 49);
			this.logicViewerSelectorControl1.Name = "logicViewerSelectorControl1";
			this.logicViewerSelectorControl1.Size = new System.Drawing.Size(259, 180);
			this.logicViewerSelectorControl1.TabIndex = 0;
			this.logicViewerSelectorControl1.Text = "logicViewerSelectorControl1";
			this.logicViewerSelectorControl1.TimeStep = 16.66666F;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTools,
            this.lbSizeIndicator,
            this.btnSizeDecrease,
            this.lbSize,
            this.btnSizeIncrease,
            this.btnUseSameTypeLogic});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(276, 25);
			this.toolStrip1.TabIndex = 7;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnTools
			// 
			this.btnTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPencil,
            this.btnRectangle,
            this.btnBucket,
            this.btnPath});
			this.btnTools.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTools.Name = "btnTools";
			this.btnTools.Size = new System.Drawing.Size(47, 22);
			this.btnTools.Text = "Tool:";
			// 
			// btnPencil
			// 
			this.btnPencil.Image = global::MapEditor.Properties.Resources.pencil;
			this.btnPencil.Name = "btnPencil";
			this.btnPencil.Size = new System.Drawing.Size(126, 22);
			this.btnPencil.Text = "Pencil";
			this.btnPencil.Click += new System.EventHandler(this.btnPencil_Click);
			// 
			// btnRectangle
			// 
			this.btnRectangle.Image = global::MapEditor.Properties.Resources.selection_select;
			this.btnRectangle.Name = "btnRectangle";
			this.btnRectangle.Size = new System.Drawing.Size(126, 22);
			this.btnRectangle.Text = "Rectangle";
			this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
			// 
			// btnBucket
			// 
			this.btnBucket.Image = global::MapEditor.Properties.Resources.bucket;
			this.btnBucket.Name = "btnBucket";
			this.btnBucket.Size = new System.Drawing.Size(126, 22);
			this.btnBucket.Text = "Bucket";
			this.btnBucket.Click += new System.EventHandler(this.btnBucket_Click);
			// 
			// btnPath
			// 
			this.btnPath.Name = "btnPath";
			this.btnPath.Size = new System.Drawing.Size(126, 22);
			this.btnPath.Text = "Path";
			this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
			// 
			// lbSizeIndicator
			// 
			this.lbSizeIndicator.Name = "lbSizeIndicator";
			this.lbSizeIndicator.Size = new System.Drawing.Size(30, 22);
			this.lbSizeIndicator.Text = "Size:";
			// 
			// btnSizeDecrease
			// 
			this.btnSizeDecrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSizeDecrease.Image = global::MapEditor.Properties.Resources.minus;
			this.btnSizeDecrease.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSizeDecrease.Name = "btnSizeDecrease";
			this.btnSizeDecrease.Size = new System.Drawing.Size(23, 22);
			this.btnSizeDecrease.Click += new System.EventHandler(this.btnSizeDecrease_Click);
			// 
			// lbSize
			// 
			this.lbSize.Name = "lbSize";
			this.lbSize.Size = new System.Drawing.Size(0, 22);
			// 
			// btnSizeIncrease
			// 
			this.btnSizeIncrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSizeIncrease.Image = global::MapEditor.Properties.Resources.plus;
			this.btnSizeIncrease.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSizeIncrease.Name = "btnSizeIncrease";
			this.btnSizeIncrease.Size = new System.Drawing.Size(23, 22);
			this.btnSizeIncrease.Text = "toolStripButton2";
			this.btnSizeIncrease.Click += new System.EventHandler(this.btnSizeIncrease_Click);
			// 
			// btnUseSameTypeLogic
			// 
			this.btnUseSameTypeLogic.CheckOnClick = true;
			this.btnUseSameTypeLogic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnUseSameTypeLogic.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnUseSameTypeLogic.Name = "btnUseSameTypeLogic";
			this.btnUseSameTypeLogic.Size = new System.Drawing.Size(123, 22);
			this.btnUseSameTypeLogic.Text = "Use Logic Same Type";
			this.btnUseSameTypeLogic.Click += new System.EventHandler(this.btnUseSameTypeLogic_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.btnReloadAll});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(276, 24);
			this.menuStrip1.TabIndex = 12;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCorrectSameTypeTile,
            this.btnCorrectOtherTypeTile});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// btnCorrectSameTypeTile
			// 
			this.btnCorrectSameTypeTile.Checked = true;
			this.btnCorrectSameTypeTile.CheckOnClick = true;
			this.btnCorrectSameTypeTile.CheckState = System.Windows.Forms.CheckState.Checked;
			this.btnCorrectSameTypeTile.Name = "btnCorrectSameTypeTile";
			this.btnCorrectSameTypeTile.Size = new System.Drawing.Size(197, 22);
			this.btnCorrectSameTypeTile.Text = "Correct same type Tiles";
			this.btnCorrectSameTypeTile.Click += new System.EventHandler(this.btnCorrectSameTypeTile_Click);
			// 
			// btnCorrectOtherTypeTile
			// 
			this.btnCorrectOtherTypeTile.CheckOnClick = true;
			this.btnCorrectOtherTypeTile.Name = "btnCorrectOtherTypeTile";
			this.btnCorrectOtherTypeTile.Size = new System.Drawing.Size(197, 22);
			this.btnCorrectOtherTypeTile.Text = "Correct other type Tiles";
			this.btnCorrectOtherTypeTile.Click += new System.EventHandler(this.btnCorrectOtherTypeTile_Click);
			// 
			// btnReloadAll
			// 
			this.btnReloadAll.Image = global::MapEditor.Properties.Resources.reload;
			this.btnReloadAll.Name = "btnReloadAll";
			this.btnReloadAll.Size = new System.Drawing.Size(120, 20);
			this.btnReloadAll.Text = "Reload all Logics";
			this.btnReloadAll.Click += new System.EventHandler(this.btnReloadAll_Click);
			// 
			// menuStrip2
			// 
			this.menuStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbTileName});
			this.menuStrip2.Location = new System.Drawing.Point(0, 229);
			this.menuStrip2.Name = "menuStrip2";
			this.menuStrip2.Size = new System.Drawing.Size(276, 27);
			this.menuStrip2.TabIndex = 13;
			this.menuStrip2.Text = "menuStrip2";
			// 
			// lbTileName
			// 
			this.lbTileName.Name = "lbTileName";
			this.lbTileName.Size = new System.Drawing.Size(100, 23);
			// 
			// FrmLogicTileSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(276, 256);
			this.Controls.Add(this.logicViewerSelectorControl1);
			this.Controls.Add(this.vScrollBar1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.menuStrip2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmLogicTileSelector";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Tile Script Tool";
			this.Load += new System.EventHandler(this.FrmLogicTileSelector_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.menuStrip2.ResumeLayout(false);
			this.menuStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public ControlLogicSelector logicViewerSelectorControl1;
		public System.Windows.Forms.VScrollBar vScrollBar1;
		public System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolStrip toolStrip1;
		public System.Windows.Forms.ToolStripDropDownButton btnTools;
		public System.Windows.Forms.ToolStripMenuItem btnPencil;
		public System.Windows.Forms.ToolStripMenuItem btnRectangle;
		public System.Windows.Forms.ToolStripMenuItem btnBucket;
		public System.Windows.Forms.ToolStripMenuItem btnPath;
		public System.Windows.Forms.ToolStripLabel lbSizeIndicator;
		public System.Windows.Forms.ToolStripButton btnSizeDecrease;
		public System.Windows.Forms.ToolStripLabel lbSize;
		public System.Windows.Forms.ToolStripButton btnSizeIncrease;
		public System.Windows.Forms.ToolStripButton btnUseSameTypeLogic;
		public System.Windows.Forms.MenuStrip menuStrip1;
		public System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem btnCorrectSameTypeTile;
		public System.Windows.Forms.ToolStripMenuItem btnCorrectOtherTypeTile;
		public System.Windows.Forms.ToolStripMenuItem btnReloadAll;
		public System.Windows.Forms.MenuStrip menuStrip2;
		public System.Windows.Forms.ToolStripTextBox lbTileName;
	}
}