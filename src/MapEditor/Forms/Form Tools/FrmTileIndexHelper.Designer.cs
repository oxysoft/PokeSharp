using MapEditor.Data.Controls.EditorView;

namespace MapEditor.Forms {
	partial class FrmTileIndexHelper {
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
			this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
			this.tilesetViewerSpriteindexGetterControl1 = new MapEditor.Data.Controls.EditorView.ControlTilesetSpriteIndexHelper();
			this.cbTilesets = new System.Windows.Forms.ComboBox();
			this.tsData = new System.Windows.Forms.ToolStrip();
			this.tslData = new System.Windows.Forms.ToolStripLabel();
			this.tsData.SuspendLayout();
			this.SuspendLayout();
			// 
			// vScrollBar1
			// 
			this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
			this.vScrollBar1.Location = new System.Drawing.Point(209, 21);
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new System.Drawing.Size(17, 370);
			this.vScrollBar1.TabIndex = 7;
			// 
			// tilesetViewerSpriteindexGetterControl1
			// 
			this.tilesetViewerSpriteindexGetterControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tilesetViewerSpriteindexGetterControl1.GameLoopEnabled = true;
			this.tilesetViewerSpriteindexGetterControl1.Location = new System.Drawing.Point(0, 21);
			this.tilesetViewerSpriteindexGetterControl1.Name = "tilesetViewerSpriteindexGetterControl1";
			this.tilesetViewerSpriteindexGetterControl1.Sheet = null;
			this.tilesetViewerSpriteindexGetterControl1.Size = new System.Drawing.Size(209, 370);
			this.tilesetViewerSpriteindexGetterControl1.TabIndex = 12;
			this.tilesetViewerSpriteindexGetterControl1.Text = "tilesetViewerSpriteindexGetterControl1";
			this.tilesetViewerSpriteindexGetterControl1.TimeStep = 16.66666F;
			// 
			// cbTilesets
			// 
			this.cbTilesets.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTilesets.FormattingEnabled = true;
			this.cbTilesets.Location = new System.Drawing.Point(0, 0);
			this.cbTilesets.Name = "cbTilesets";
			this.cbTilesets.Size = new System.Drawing.Size(226, 21);
			this.cbTilesets.TabIndex = 17;
			// 
			// tsData
			// 
			this.tsData.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tsData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslData});
			this.tsData.Location = new System.Drawing.Point(0, 391);
			this.tsData.Name = "tsData";
			this.tsData.Size = new System.Drawing.Size(226, 25);
			this.tsData.TabIndex = 18;
			this.tsData.Text = "toolStrip1";
			// 
			// tslData
			// 
			this.tslData.Name = "tslData";
			this.tslData.Size = new System.Drawing.Size(105, 22);
			this.tslData.Text = "Please, Select a tile";
			// 
			// FrmTileIndexHelper
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(226, 416);
			this.Controls.Add(this.tilesetViewerSpriteindexGetterControl1);
			this.Controls.Add(this.vScrollBar1);
			this.Controls.Add(this.cbTilesets);
			this.Controls.Add(this.tsData);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FrmTileIndexHelper";
			this.ShowIcon = false;
			this.Text = "Tile Indexer";
			this.Load += new System.EventHandler(this.FrmTileIndexHelper_Load);
			this.tsData.ResumeLayout(false);
			this.tsData.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.VScrollBar vScrollBar1;
		private ControlTilesetSpriteIndexHelper tilesetViewerSpriteindexGetterControl1;
		private System.Windows.Forms.ComboBox cbTilesets;
		private System.Windows.Forms.ToolStrip tsData;
		private System.Windows.Forms.ToolStripLabel tslData;
	}
}