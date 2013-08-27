namespace MapEditor.Forms {
	partial class FrmResourceImport {
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
			this.rbOption1 = new System.Windows.Forms.RadioButton();
			this.rbOption2 = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.bOk = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// rbOption1
			// 
			this.rbOption1.AutoSize = true;
			this.rbOption1.Location = new System.Drawing.Point(13, 19);
			this.rbOption1.Name = "rbOption1";
			this.rbOption1.Size = new System.Drawing.Size(179, 17);
			this.rbOption1.TabIndex = 0;
			this.rbOption1.TabStop = true;
			this.rbOption1.Text = "Open as new resource container";
			this.rbOption1.UseVisualStyleBackColor = true;
			this.rbOption1.CheckedChanged += new System.EventHandler(this.optionSelected);
			// 
			// rbOption2
			// 
			this.rbOption2.AutoSize = true;
			this.rbOption2.Location = new System.Drawing.Point(13, 42);
			this.rbOption2.Name = "rbOption2";
			this.rbOption2.Size = new System.Drawing.Size(193, 17);
			this.rbOption2.TabIndex = 1;
			this.rbOption2.TabStop = true;
			this.rbOption2.Text = "Add into existing resource container";
			this.rbOption2.UseVisualStyleBackColor = true;
			this.rbOption2.CheckedChanged += new System.EventHandler(this.optionSelected);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(214, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Choose a resource container import strategy";
			// 
			// bOk
			// 
			this.bOk.Enabled = false;
			this.bOk.Location = new System.Drawing.Point(15, 120);
			this.bOk.Name = "bOk";
			this.bOk.Size = new System.Drawing.Size(75, 23);
			this.bOk.TabIndex = 3;
			this.bOk.Text = "OK";
			this.bOk.UseVisualStyleBackColor = true;
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// bCancel
			// 
			this.bCancel.Location = new System.Drawing.Point(96, 120);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(75, 23);
			this.bCancel.TabIndex = 4;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = true;
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbOption2);
			this.groupBox1.Controls.Add(this.rbOption1);
			this.groupBox1.Location = new System.Drawing.Point(15, 36);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
			this.groupBox1.Size = new System.Drawing.Size(211, 69);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Stategies";
			// 
			// FrmResourceImport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(249, 151);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.label1);
			this.Name = "FrmResourceImport";
			this.Text = "Import";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton rbOption1;
		private System.Windows.Forms.RadioButton rbOption2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bOk;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}