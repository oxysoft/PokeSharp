namespace MapEditor.Forms {
	partial class FrmUndoRedoList {
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
			this.listActions = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.replayAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listActions
			// 
			this.listActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.listActions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listActions.Location = new System.Drawing.Point(0, 24);
			this.listActions.Name = "listActions";
			this.listActions.Size = new System.Drawing.Size(278, 456);
			this.listActions.TabIndex = 4;
			this.listActions.UseCompatibleStateImageBehavior = false;
			this.listActions.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Action";
			this.columnHeader1.Width = 73;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Date";
			this.columnHeader2.Width = 73;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Datas";
			this.columnHeader3.Width = 119;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(0, 24);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(8, 456);
			this.splitter1.TabIndex = 9;
			this.splitter1.TabStop = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.replayAllToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(278, 24);
			this.menuStrip1.TabIndex = 10;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Image = global::MapEditor.Properties.Resources.arrow_turn_180_left;
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
			this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Image = global::MapEditor.Properties.Resources.arrow_turn_000_left;
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
			this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
			// 
			// replayAllToolStripMenuItem
			// 
			this.replayAllToolStripMenuItem.Image = global::MapEditor.Properties.Resources.film;
			this.replayAllToolStripMenuItem.Name = "replayAllToolStripMenuItem";
			this.replayAllToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
			this.replayAllToolStripMenuItem.Text = "Playback";
			this.replayAllToolStripMenuItem.Click += new System.EventHandler(this.replayAllToolStripMenuItem_Click);
			// 
			// FrmUndoRedoList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(278, 480);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.listActions);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmUndoRedoList";
			this.Text = "Undo/Redo List";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUndoRedoList_FormClosing);
			this.Shown += new System.EventHandler(this.FrmUndoRedoList_Shown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listActions;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem replayAllToolStripMenuItem;
	}
}