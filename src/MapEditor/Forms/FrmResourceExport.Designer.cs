namespace MapEditor.Forms {
	partial class FrmResourceExport {
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
			this.label1 = new System.Windows.Forms.Label();
			this.listResource = new System.Windows.Forms.CheckedListBox();
			this.bExport = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(230, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Choose the resources to export into a container";
			// 
			// listResource
			// 
			this.listResource.FormattingEnabled = true;
			this.listResource.Location = new System.Drawing.Point(21, 34);
			this.listResource.Name = "listResource";
			this.listResource.Size = new System.Drawing.Size(213, 274);
			this.listResource.TabIndex = 1;
			this.listResource.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listResource_ItemCheck);
			// 
			// bExport
			// 
			this.bExport.Location = new System.Drawing.Point(21, 317);
			this.bExport.Name = "bExport";
			this.bExport.Size = new System.Drawing.Size(104, 23);
			this.bExport.TabIndex = 2;
			this.bExport.Text = "Export";
			this.bExport.UseVisualStyleBackColor = true;
			this.bExport.Click += new System.EventHandler(this.bExport_Click);
			// 
			// bCancel
			// 
			this.bCancel.Location = new System.Drawing.Point(130, 317);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(104, 23);
			this.bCancel.TabIndex = 3;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = true;
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// FrmResourceExport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(254, 348);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bExport);
			this.Controls.Add(this.listResource);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmResourceExport";
			this.Text = "Export";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckedListBox listResource;
		private System.Windows.Forms.Button bExport;
		private System.Windows.Forms.Button bCancel;
	}
}