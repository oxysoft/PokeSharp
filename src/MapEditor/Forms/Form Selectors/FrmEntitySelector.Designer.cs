
using MapEditor.Data.Controls.EditorView;

namespace MapEditor.Forms {
	partial class FrmEntitySelector {
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
			this.entityViewerSelectorControl1 = new ControlEntitySelector();
			this.SuspendLayout();
			// 
			// vScrollBar1
			// 
			this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
			this.vScrollBar1.Location = new System.Drawing.Point(198, 0);
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new System.Drawing.Size(17, 392);
			this.vScrollBar1.TabIndex = 2;
			// 
			// entityViewerSelectorControl1
			// 
			this.entityViewerSelectorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.entityViewerSelectorControl1.GameLoopEnabled = true;
			this.entityViewerSelectorControl1.Location = new System.Drawing.Point(0, 0);
			this.entityViewerSelectorControl1.Name = "entityViewerSelectorControl1";
			this.entityViewerSelectorControl1.Size = new System.Drawing.Size(215, 392);
			this.entityViewerSelectorControl1.TabIndex = 1;
			this.entityViewerSelectorControl1.Text = "entityViewerSelectorControl1";
			this.entityViewerSelectorControl1.TimeStep = 16.66666F;
			// 
			// FrmEntitySelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(215, 392);
			this.Controls.Add(this.vScrollBar1);
			this.Controls.Add(this.entityViewerSelectorControl1);
			this.Name = "FrmEntitySelector";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Entity selector";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEntitySelector_FormClosing);
			this.VisibleChanged += new System.EventHandler(this.FrmEntitySelector_VisibleChanged);
			this.ResumeLayout(false);

		}

		#endregion

		private ControlEntitySelector entityViewerSelectorControl1;
		private System.Windows.Forms.VScrollBar vScrollBar1;
	}
}