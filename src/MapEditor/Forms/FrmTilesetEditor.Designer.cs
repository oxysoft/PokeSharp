using System;
using MapEditor.Data.Controls.EditorView;

namespace MapEditor.Forms {
	partial class FrmTilesetEditor : IDisposable {
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

		private System.Windows.Forms.Button b_texture;
		private System.Windows.Forms.TextBox tbName;

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			GameEngine.Data.Tiles.Tileset tileset3 = new GameEngine.Data.Tiles.Tileset();
			this.lbName = new System.Windows.Forms.Label();
			this.gbTile = new System.Windows.Forms.GroupBox();
			this.vScrollBar = new System.Windows.Forms.VScrollBar();
			this.hScrollBar = new System.Windows.Forms.HScrollBar();
			this.editor = new MapEditor.Data.Controls.EditorView.ControlTilesetEditor();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.b_texture = new System.Windows.Forms.Button();
			this.tbName = new System.Windows.Forms.TextBox();
			this.gbTile.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbName
			// 
			this.lbName.AutoSize = true;
			this.lbName.Location = new System.Drawing.Point(12, 9);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(35, 13);
			this.lbName.TabIndex = 0;
			this.lbName.Text = "Name";
			// 
			// gbTile
			// 
			this.gbTile.Enabled = false;
			this.gbTile.Location = new System.Drawing.Point(15, 80);
			this.gbTile.Name = "gbTile";
			this.gbTile.Size = new System.Drawing.Size(188, 72);
			this.gbTile.TabIndex = 9;
			this.gbTile.TabStop = false;
			this.gbTile.Text = "Selected Tile";
			// 
			// vScrollBar
			// 
			this.vScrollBar.Location = new System.Drawing.Point(397, 11);
			this.vScrollBar.Name = "vScrollBar";
			this.vScrollBar.Size = new System.Drawing.Size(17, 147);
			this.vScrollBar.TabIndex = 10;
			// 
			// hScrollBar
			// 
			this.hScrollBar.Location = new System.Drawing.Point(218, 164);
			this.hScrollBar.Name = "hScrollBar";
			this.hScrollBar.Size = new System.Drawing.Size(173, 17);
			this.hScrollBar.TabIndex = 11;
			// 
			// editor
			// 
			this.editor.GameLoopEnabled = true;
			this.editor.Location = new System.Drawing.Point(218, 11);
			this.editor.Name = "editor";
			this.editor.Size = new System.Drawing.Size(173, 147);
			this.editor.TabIndex = 8;
			this.editor.Text = "tilesetEditorControl1";
			this.editor.Tileset = tileset3;
			this.editor.TimeStep = 16.66666F;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(30, 164);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 13;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(111, 164);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// b_texture
			// 
			this.b_texture.Location = new System.Drawing.Point(15, 51);
			this.b_texture.Name = "b_texture";
			this.b_texture.Size = new System.Drawing.Size(191, 23);
			this.b_texture.TabIndex = 15;
			this.b_texture.Text = "Import texture";
			this.b_texture.UseVisualStyleBackColor = true;
			this.b_texture.Click += new System.EventHandler(this.b_texture_Click);
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(15, 25);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(191, 20);
			this.tbName.TabIndex = 16;
			// 
			// FrmTilesetEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 192);
			this.Controls.Add(this.tbName);
			this.Controls.Add(this.b_texture);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.hScrollBar);
			this.Controls.Add(this.vScrollBar);
			this.Controls.Add(this.gbTile);
			this.Controls.Add(this.editor);
			this.Controls.Add(this.lbName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmTilesetEditor";
			this.ShowIcon = false;
			this.Text = "Tileset Editor";
			this.Load += new System.EventHandler(this.FrmTilesetEditor_Load);
			this.gbTile.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbName;
		private ControlTilesetEditor editor;
		private System.Windows.Forms.GroupBox gbTile;
		private System.Windows.Forms.VScrollBar vScrollBar;
		private System.Windows.Forms.HScrollBar hScrollBar;
	}
}