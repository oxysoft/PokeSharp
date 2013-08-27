namespace MapEditor.Forms.Form_Tools {
	partial class FrmPictureChopper {
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
			this.bImportTexture = new System.Windows.Forms.Button();
			this.bDumpAll = new System.Windows.Forms.Button();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.lCurrentBuffer = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
			this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.lScale = new System.Windows.Forms.Label();
			this.control = new MapEditor.Data.Controls.EditorView.ControlTextureExtractor();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkProcessTrans = new System.Windows.Forms.CheckBox();
			this.checkAutoBuffer = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// bImportTexture
			// 
			this.bImportTexture.Location = new System.Drawing.Point(12, 12);
			this.bImportTexture.Name = "bImportTexture";
			this.bImportTexture.Size = new System.Drawing.Size(151, 23);
			this.bImportTexture.TabIndex = 1;
			this.bImportTexture.Text = "Import Texture";
			this.bImportTexture.UseVisualStyleBackColor = true;
			this.bImportTexture.Click += new System.EventHandler(this.bImportTexture_Click);
			// 
			// bDumpAll
			// 
			this.bDumpAll.Location = new System.Drawing.Point(12, 41);
			this.bDumpAll.Name = "bDumpAll";
			this.bDumpAll.Size = new System.Drawing.Size(151, 23);
			this.bDumpAll.TabIndex = 2;
			this.bDumpAll.Text = "Dump all textures";
			this.bDumpAll.UseVisualStyleBackColor = true;
			this.bDumpAll.Click += new System.EventHandler(this.bDumpAll_Click);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(15, 45);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(130, 20);
			this.numericUpDown1.TabIndex = 3;
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// lCurrentBuffer
			// 
			this.lCurrentBuffer.AutoSize = true;
			this.lCurrentBuffer.Location = new System.Drawing.Point(12, 29);
			this.lCurrentBuffer.Name = "lCurrentBuffer";
			this.lCurrentBuffer.Size = new System.Drawing.Size(99, 13);
			this.lCurrentBuffer.TabIndex = 4;
			this.lCurrentBuffer.Text = "Current buffer index";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(48, 476);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// vScrollBar1
			// 
			this.vScrollBar1.Location = new System.Drawing.Point(758, 12);
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new System.Drawing.Size(17, 464);
			this.vScrollBar1.TabIndex = 6;
			// 
			// hScrollBar1
			// 
			this.hScrollBar1.Location = new System.Drawing.Point(169, 479);
			this.hScrollBar1.Name = "hScrollBar1";
			this.hScrollBar1.Size = new System.Drawing.Size(586, 20);
			this.hScrollBar1.TabIndex = 7;
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.DecimalPlaces = 1;
			this.numericUpDown2.Location = new System.Drawing.Point(15, 94);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(130, 20);
			this.numericUpDown2.TabIndex = 8;
			this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
			// 
			// lScale
			// 
			this.lScale.AutoSize = true;
			this.lScale.Location = new System.Drawing.Point(12, 78);
			this.lScale.Name = "lScale";
			this.lScale.Size = new System.Drawing.Size(34, 13);
			this.lScale.TabIndex = 9;
			this.lScale.Text = "Scale";
			// 
			// control
			// 
			this.control.CurrentBufferIndex = 0;
			this.control.GameLoopEnabled = true;
			this.control.Location = new System.Drawing.Point(169, 12);
			this.control.Name = "control";
			this.control.Scale = 1F;
			this.control.Size = new System.Drawing.Size(586, 464);
			this.control.TabIndex = 0;
			this.control.Text = "textureExtractor1";
			this.control.TimeStep = 16.66666F;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkAutoBuffer);
			this.groupBox1.Controls.Add(this.checkProcessTrans);
			this.groupBox1.Controls.Add(this.numericUpDown1);
			this.groupBox1.Controls.Add(this.lScale);
			this.groupBox1.Controls.Add(this.lCurrentBuffer);
			this.groupBox1.Controls.Add(this.numericUpDown2);
			this.groupBox1.Location = new System.Drawing.Point(12, 70);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(151, 183);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Properties";
			// 
			// checkProcessTrans
			// 
			this.checkProcessTrans.AutoSize = true;
			this.checkProcessTrans.Checked = true;
			this.checkProcessTrans.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkProcessTrans.Location = new System.Drawing.Point(15, 135);
			this.checkProcessTrans.Name = "checkProcessTrans";
			this.checkProcessTrans.Size = new System.Drawing.Size(120, 17);
			this.checkProcessTrans.TabIndex = 10;
			this.checkProcessTrans.Text = "Process transparent";
			this.checkProcessTrans.UseVisualStyleBackColor = true;
			this.checkProcessTrans.CheckedChanged += new System.EventHandler(this.checkProcessTrans_CheckedChanged);
			// 
			// checkAutoBuffer
			// 
			this.checkAutoBuffer.AutoSize = true;
			this.checkAutoBuffer.Location = new System.Drawing.Point(15, 158);
			this.checkAutoBuffer.Name = "checkAutoBuffer";
			this.checkAutoBuffer.Size = new System.Drawing.Size(123, 17);
			this.checkAutoBuffer.TabIndex = 11;
			this.checkAutoBuffer.Text = "Auto advance buffer";
			this.checkAutoBuffer.UseVisualStyleBackColor = true;
			this.checkAutoBuffer.CheckedChanged += new System.EventHandler(this.checkAutoBuffer_CheckedChanged);
			// 
			// FrmPictureChopper
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(778, 502);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.hScrollBar1);
			this.Controls.Add(this.vScrollBar1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.bDumpAll);
			this.Controls.Add(this.bImportTexture);
			this.Controls.Add(this.control);
			this.Name = "FrmPictureChopper";
			this.Text = "TextureExtractorTool";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private MapEditor.Data.Controls.EditorView.ControlTextureExtractor control;
		private System.Windows.Forms.Button bImportTexture;
		private System.Windows.Forms.Button bDumpAll;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label lCurrentBuffer;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.VScrollBar vScrollBar1;
		private System.Windows.Forms.HScrollBar hScrollBar1;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.Label lScale;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkProcessTrans;
		private System.Windows.Forms.CheckBox checkAutoBuffer;
	}
}