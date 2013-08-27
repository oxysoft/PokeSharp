using System;
namespace PokeSharp {
	partial class Form1 {
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
			this.pctSurface = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pctSurface)).BeginInit();
			this.SuspendLayout();
			// 
			// pctSurface
			// 
			this.pctSurface.Location = new System.Drawing.Point(-1, -1);
			this.pctSurface.Name = "pctSurface";
			this.pctSurface.Size = new System.Drawing.Size(PokeEngine.WIDTH * PokeEngine.SCALE, PokeEngine.HEIGHT * PokeEngine.SCALE);
			this.pctSurface.TabIndex = 0;
			this.pctSurface.TabStop = false;
			this.pctSurface.Click += new System.EventHandler(this.pctSurface_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(PokeEngine.WIDTH * PokeEngine.SCALE, PokeEngine.HEIGHT * PokeEngine.SCALE);
			this.Controls.Add(this.pctSurface);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pctSurface)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pctSurface;
	
		public IntPtr getDrawSurface() {
			return pctSurface.Handle;
		}
	}
}