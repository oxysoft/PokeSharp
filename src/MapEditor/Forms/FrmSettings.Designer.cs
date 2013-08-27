namespace MapEditor.Forms {
	partial class FrmSettings {
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
			this.components = new System.ComponentModel.Container();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbDefProjLoc = new System.Windows.Forms.TextBox();
			this.btnDefProjLoc = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lb1ToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbDefProjLoc);
			this.groupBox1.Controls.Add(this.btnDefProjLoc);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
			this.groupBox1.Size = new System.Drawing.Size(220, 76);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Settings";
			// 
			// tbDefProjLoc
			// 
			this.tbDefProjLoc.Enabled = false;
			this.tbDefProjLoc.Location = new System.Drawing.Point(16, 38);
			this.tbDefProjLoc.Name = "tbDefProjLoc";
			this.tbDefProjLoc.Size = new System.Drawing.Size(159, 20);
			this.tbDefProjLoc.TabIndex = 2;
			// 
			// btnDefProjLoc
			// 
			this.btnDefProjLoc.Location = new System.Drawing.Point(181, 38);
			this.btnDefProjLoc.Name = "btnDefProjLoc";
			this.btnDefProjLoc.Size = new System.Drawing.Size(25, 20);
			this.btnDefProjLoc.TabIndex = 1;
			this.btnDefProjLoc.Text = "...";
			this.btnDefProjLoc.UseVisualStyleBackColor = true;
			this.btnDefProjLoc.Click += new System.EventHandler(this.btnDefProjLoc_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 19);
			this.label1.Margin = new System.Windows.Forms.Padding(3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Default project location";
			this.lb1ToolTip.SetToolTip(this.label1, "When the game editor is loaded up, this project will automatically be opened.");
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(12, 94);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(93, 94);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lb1ToolTip
			// 
			this.lb1ToolTip.AutoPopDelay = 30000;
			this.lb1ToolTip.InitialDelay = 500;
			this.lb1ToolTip.ReshowDelay = 100;
			// 
			// FrmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(245, 126);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmSettings";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.FrmSettings_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbDefProjLoc;
		private System.Windows.Forms.Button btnDefProjLoc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ToolTip lb1ToolTip;
	}
}