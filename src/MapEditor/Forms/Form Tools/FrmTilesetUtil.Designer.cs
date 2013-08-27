using MapEditor.Data.Controls.EditorView;

namespace MapEditor.Forms {
	partial class FrmTilesetUtil {
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
			this.b_path = new System.Windows.Forms.Button();
			this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
			this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
			this.s_selectedEntity = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.b_export = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.c_colorbuffer = new System.Windows.Forms.CheckBox();
			this.c_checkerboard = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.control = new ControlTilesetSplitterUtil();
			this.c_ignoretransparent = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.s_selectedEntity)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// b_path
			// 
			this.b_path.Location = new System.Drawing.Point(17, 19);
			this.b_path.Name = "b_path";
			this.b_path.Size = new System.Drawing.Size(141, 23);
			this.b_path.TabIndex = 1;
			this.b_path.Text = "Import tileset";
			this.b_path.UseVisualStyleBackColor = true;
			this.b_path.Click += new System.EventHandler(this.b_path_Click);
			// 
			// vScrollBar1
			// 
			this.vScrollBar1.Location = new System.Drawing.Point(618, 9);
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new System.Drawing.Size(17, 414);
			this.vScrollBar1.TabIndex = 2;
			// 
			// hScrollBar1
			// 
			this.hScrollBar1.Location = new System.Drawing.Point(194, 426);
			this.hScrollBar1.Name = "hScrollBar1";
			this.hScrollBar1.Size = new System.Drawing.Size(421, 17);
			this.hScrollBar1.TabIndex = 4;
			// 
			// s_selectedEntity
			// 
			this.s_selectedEntity.Location = new System.Drawing.Point(89, 48);
			this.s_selectedEntity.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
			this.s_selectedEntity.Name = "s_selectedEntity";
			this.s_selectedEntity.Size = new System.Drawing.Size(69, 20);
			this.s_selectedEntity.TabIndex = 6;
			this.s_selectedEntity.ValueChanged += new System.EventHandler(this.s_selectedEntity_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Current entity";
			// 
			// b_export
			// 
			this.b_export.Location = new System.Drawing.Point(57, 192);
			this.b_export.Name = "b_export";
			this.b_export.Size = new System.Drawing.Size(75, 23);
			this.b_export.TabIndex = 8;
			this.b_export.Text = "Export";
			this.b_export.UseVisualStyleBackColor = true;
			this.b_export.Click += new System.EventHandler(this.b_export_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.c_ignoretransparent);
			this.groupBox1.Controls.Add(this.c_colorbuffer);
			this.groupBox1.Controls.Add(this.c_checkerboard);
			this.groupBox1.Location = new System.Drawing.Point(12, 98);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(167, 88);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Options";
			// 
			// c_colorbuffer
			// 
			this.c_colorbuffer.AutoSize = true;
			this.c_colorbuffer.Location = new System.Drawing.Point(17, 42);
			this.c_colorbuffer.Name = "c_colorbuffer";
			this.c_colorbuffer.Size = new System.Drawing.Size(138, 17);
			this.c_colorbuffer.TabIndex = 1;
			this.c_colorbuffer.Text = "Use custom color buffer";
			this.c_colorbuffer.UseVisualStyleBackColor = true;
			this.c_colorbuffer.CheckedChanged += new System.EventHandler(this.c_colorbuffer_CheckedChanged);
			// 
			// c_checkerboard
			// 
			this.c_checkerboard.AutoSize = true;
			this.c_checkerboard.Location = new System.Drawing.Point(17, 19);
			this.c_checkerboard.Name = "c_checkerboard";
			this.c_checkerboard.Size = new System.Drawing.Size(120, 17);
			this.c_checkerboard.TabIndex = 0;
			this.c_checkerboard.Text = "Draw checkerboard";
			this.c_checkerboard.UseVisualStyleBackColor = true;
			this.c_checkerboard.CheckedChanged += new System.EventHandler(this.c_checkerboard_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.b_path);
			this.groupBox2.Controls.Add(this.s_selectedEntity);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(164, 80);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Settings";
			// 
			// Control
			// 
			this.control.GameLoopEnabled = true;
			this.control.Location = new System.Drawing.Point(194, 12);
			this.control.Name = "control";
			this.control.Size = new System.Drawing.Size(421, 411);
			this.control.TabIndex = 3;
			this.control.Text = "tilesetSplitterUtilControl1";
			this.control.TimeStep = 16.66666F;
			// 
			// c_ignoretransparent
			// 
			this.c_ignoretransparent.AutoSize = true;
			this.c_ignoretransparent.Location = new System.Drawing.Point(17, 65);
			this.c_ignoretransparent.Name = "c_ignoretransparent";
			this.c_ignoretransparent.Size = new System.Drawing.Size(133, 17);
			this.c_ignoretransparent.TabIndex = 2;
			this.c_ignoretransparent.Text = "Ignore transparent Tiles";
			this.c_ignoretransparent.UseVisualStyleBackColor = true;
			this.c_ignoretransparent.CheckedChanged += new System.EventHandler(this.c_ignoretransparent_CheckedChanged);
			// 
			// FrmTilesetUtil
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(645, 459);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.b_export);
			this.Controls.Add(this.hScrollBar1);
			this.Controls.Add(this.control);
			this.Controls.Add(this.vScrollBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmTilesetUtil";
			this.Text = "Tileset Entity Utility";
			this.Load += new System.EventHandler(this.FrmTilesetUtil_Load);
			((System.ComponentModel.ISupportInitialize)(this.s_selectedEntity)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button b_path;
		private System.Windows.Forms.VScrollBar vScrollBar1;
		private ControlTilesetSplitterUtil control;
		private System.Windows.Forms.HScrollBar hScrollBar1;
		private System.Windows.Forms.NumericUpDown s_selectedEntity;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button b_export;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox c_colorbuffer;
		private System.Windows.Forms.CheckBox c_checkerboard;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox c_ignoretransparent;
	}
}