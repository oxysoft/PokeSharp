namespace AeonEditor.Forms {
	partial class FrmNewRegion {
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
			this.lbRegionName = new System.Windows.Forms.Label();
			this.lbRegionAuthor = new System.Windows.Forms.Label();
			this.gbRegion = new System.Windows.Forms.GroupBox();
			this.tbRegionAuthor = new System.Windows.Forms.TextBox();
			this.tbRegionName = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gbRegion.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbRegionName
			// 
			this.lbRegionName.AutoSize = true;
			this.lbRegionName.Location = new System.Drawing.Point(10, 18);
			this.lbRegionName.Name = "lbRegionName";
			this.lbRegionName.Size = new System.Drawing.Size(72, 13);
			this.lbRegionName.TabIndex = 0;
			this.lbRegionName.Text = "World Name";
			// 
			// lbRegionAuthor
			// 
			this.lbRegionAuthor.AutoSize = true;
			this.lbRegionAuthor.Location = new System.Drawing.Point(10, 75);
			this.lbRegionAuthor.Name = "lbRegionAuthor";
			this.lbRegionAuthor.Size = new System.Drawing.Size(38, 13);
			this.lbRegionAuthor.TabIndex = 1;
			this.lbRegionAuthor.Text = "Author";
			// 
			// gbRegion
			// 
			this.gbRegion.Controls.Add(this.tbRegionAuthor);
			this.gbRegion.Controls.Add(this.tbRegionName);
			this.gbRegion.Controls.Add(this.lbRegionName);
			this.gbRegion.Controls.Add(this.lbRegionAuthor);
			this.gbRegion.Location = new System.Drawing.Point(12, 12);
			this.gbRegion.Name = "gbRegion";
			this.gbRegion.Padding = new System.Windows.Forms.Padding(7, 5, 3, 3);
			this.gbRegion.Size = new System.Drawing.Size(234, 127);
			this.gbRegion.TabIndex = 2;
			this.gbRegion.TabStop = false;
			this.gbRegion.Text = "Properties";
			// 
			// tbRegionAuthor
			// 
			this.tbRegionAuthor.Location = new System.Drawing.Point(13, 91);
			this.tbRegionAuthor.Name = "tbRegionAuthor";
			this.tbRegionAuthor.Size = new System.Drawing.Size(215, 20);
			this.tbRegionAuthor.TabIndex = 3;
			// 
			// tbRegionName
			// 
			this.tbRegionName.Location = new System.Drawing.Point(13, 34);
			this.tbRegionName.Name = "tbRegionName";
			this.tbRegionName.Size = new System.Drawing.Size(215, 20);
			this.tbRegionName.TabIndex = 2;
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(42, 150);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(141, 150);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// FrmNewRegion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(258, 180);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.gbRegion);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmNewRegion";
			this.Text = "New World";
			this.gbRegion.ResumeLayout(false);
			this.gbRegion.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lbRegionName;
		private System.Windows.Forms.Label lbRegionAuthor;
		private System.Windows.Forms.GroupBox gbRegion;
		private System.Windows.Forms.TextBox tbRegionAuthor;
		private System.Windows.Forms.TextBox tbRegionName;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;

	}
}