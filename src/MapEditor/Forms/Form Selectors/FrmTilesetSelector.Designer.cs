using MapEditor.Data.Controls.EditorView;

namespace MapEditor.Forms {
	partial class FrmTilesetSelector {
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
			this.comboBoxEdit1 = new System.Windows.Forms.ComboBox();
			this.control = new MapEditor.Data.Controls.EditorView.ControlTilesetSelector();
			this.SuspendLayout();
			// 
			// vScrollBar1
			// 
			this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
			this.vScrollBar1.Location = new System.Drawing.Point(198, 21);
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new System.Drawing.Size(17, 371);
			this.vScrollBar1.TabIndex = 3;
			// 
			// comboBoxEdit1
			// 
			this.comboBoxEdit1.Dock = System.Windows.Forms.DockStyle.Top;
			this.comboBoxEdit1.FormattingEnabled = true;
			this.comboBoxEdit1.Location = new System.Drawing.Point(0, 0);
			this.comboBoxEdit1.Name = "comboBoxEdit1";
			this.comboBoxEdit1.Size = new System.Drawing.Size(215, 21);
			this.comboBoxEdit1.TabIndex = 4;
			this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
			// 
			// control
			// 
			this.control.Dock = System.Windows.Forms.DockStyle.Fill;
			this.control.GameLoopEnabled = true;
			this.control.Location = new System.Drawing.Point(0, 21);
			this.control.Name = "control";
			this.control.SelectedIndex = 0;
			this.control.SelectedRegion = new Microsoft.Xna.Framework.Rectangle(0, 0, 0, 0);
			this.control.Size = new System.Drawing.Size(198, 371);
			this.control.TabIndex = 5;
			this.control.Text = "tilesetViewerSelectorControl1";
			this.control.Tileset = null;
			this.control.TimeStep = 16.66666F;
			// 
			// FrmTilesetSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(215, 392);
			this.Controls.Add(this.control);
			this.Controls.Add(this.vScrollBar1);
			this.Controls.Add(this.comboBoxEdit1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmTilesetSelector";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Tileset Selector";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTilesetSelector_FormClosing);
			this.Shown += new System.EventHandler(this.FrmTilesetSelector_Shown);
			this.VisibleChanged += new System.EventHandler(this.FrmTilesetSelector_VisibleChanged);
			this.ResumeLayout(false);

		}
		#endregion

		public System.Windows.Forms.VScrollBar vScrollBar1;
		public System.Windows.Forms.ComboBox comboBoxEdit1;
		public MapEditor.Data.Controls.EditorView.ControlTilesetSelector control;
	}
}