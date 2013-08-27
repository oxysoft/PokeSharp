using MapEditor.Data.Controls.EditorView;

namespace MapEditor.Forms {
	partial class FrmEntityTemplateEditor {
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
			this.label1 = new System.Windows.Forms.Label();
			this.bImporttexture = new System.Windows.Forms.Button();
			this.tbName = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbRows = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.tbColumn = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.bEditAnimation = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cbShadow = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbType = new System.Windows.Forms.ComboBox();
			this.bOK = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.cbMode = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.control = new MapEditor.Data.Controls.EditorView.ControlEntityEditor();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbRows)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbColumn)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Name:";
			// 
			// bImporttexture
			// 
			this.bImporttexture.Location = new System.Drawing.Point(20, 64);
			this.bImporttexture.Name = "bImporttexture";
			this.bImporttexture.Size = new System.Drawing.Size(134, 21);
			this.bImporttexture.TabIndex = 2;
			this.bImporttexture.Text = "Import texture";
			this.bImporttexture.UseVisualStyleBackColor = true;
			this.bImporttexture.Click += new System.EventHandler(this.b_importtexture_Click);
			this.bImporttexture.DragDrop += new System.Windows.Forms.DragEventHandler(this.bImporttexture_DragDrop);
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(20, 38);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(134, 20);
			this.tbName.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbRows);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tbColumn);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.bEditAnimation);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.cbShadow);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cbType);
			this.groupBox1.Controls.Add(this.bImporttexture);
			this.groupBox1.Controls.Add(this.tbName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(169, 315);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Properties";
			// 
			// tbRows
			// 
			this.tbRows.Location = new System.Drawing.Point(20, 149);
			this.tbRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tbRows.Name = "tbRows";
			this.tbRows.Size = new System.Drawing.Size(134, 20);
			this.tbRows.TabIndex = 13;
			this.tbRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tbRows.ValueChanged += new System.EventHandler(this.tbRow_ValueChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(17, 133);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Rows:";
			// 
			// tbColumn
			// 
			this.tbColumn.Location = new System.Drawing.Point(20, 109);
			this.tbColumn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tbColumn.Name = "tbColumn";
			this.tbColumn.Size = new System.Drawing.Size(134, 20);
			this.tbColumn.TabIndex = 11;
			this.tbColumn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tbColumn.ValueChanged += new System.EventHandler(this.tbColumn_ValueChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(17, 93);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(50, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Columns:";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// bEditAnimation
			// 
			this.bEditAnimation.Location = new System.Drawing.Point(20, 282);
			this.bEditAnimation.Name = "bEditAnimation";
			this.bEditAnimation.Size = new System.Drawing.Size(134, 23);
			this.bEditAnimation.TabIndex = 9;
			this.bEditAnimation.Text = "Edit animation";
			this.bEditAnimation.UseVisualStyleBackColor = true;
			this.bEditAnimation.Click += new System.EventHandler(this.bEditAnimation_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(17, 226);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Shadow:";
			// 
			// cbShadow
			// 
			this.cbShadow.FormattingEnabled = true;
			this.cbShadow.Items.AddRange(new object[] {
            "[0] None",
            "[1] Perspective"});
			this.cbShadow.Location = new System.Drawing.Point(20, 242);
			this.cbShadow.Name = "cbShadow";
			this.cbShadow.Size = new System.Drawing.Size(134, 21);
			this.cbShadow.TabIndex = 6;
			this.cbShadow.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 181);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Type:";
			// 
			// cbType
			// 
			this.cbType.FormattingEnabled = true;
			this.cbType.Items.AddRange(new object[] {
            "None",
            "Building",
            "Warpfield",
            "Door",
            "Player",
            "Npc"});
			this.cbType.Location = new System.Drawing.Point(20, 197);
			this.cbType.Name = "cbType";
			this.cbType.Size = new System.Drawing.Size(134, 21);
			this.cbType.TabIndex = 4;
			// 
			// bOK
			// 
			this.bOK.Enabled = false;
			this.bOK.Location = new System.Drawing.Point(38, 333);
			this.bOK.Name = "bOK";
			this.bOK.Size = new System.Drawing.Size(61, 23);
			this.bOK.TabIndex = 6;
			this.bOK.Text = "OK";
			this.bOK.UseVisualStyleBackColor = true;
			this.bOK.Click += new System.EventHandler(this.button1_Click);
			// 
			// bCancel
			// 
			this.bCancel.Location = new System.Drawing.Point(105, 333);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(61, 23);
			this.bCancel.TabIndex = 7;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = true;
			this.bCancel.Click += new System.EventHandler(this.button2_Click);
			// 
			// cbMode
			// 
			this.cbMode.FormattingEnabled = true;
			this.cbMode.Items.AddRange(new object[] {
            "Texture Viewer",
            "Collision Mapping",
            "Shadow Offset"});
			this.cbMode.Location = new System.Drawing.Point(242, 9);
			this.cbMode.Name = "cbMode";
			this.cbMode.Size = new System.Drawing.Size(162, 21);
			this.cbMode.TabIndex = 9;
			this.cbMode.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(199, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Mode:";
			// 
			// control
			// 
			this.control.GameLoopEnabled = true;
			this.control.List = null;
			this.control.Location = new System.Drawing.Point(202, 36);
			this.control.Mode = 0;
			this.control.Name = "control";
			this.control.Size = new System.Drawing.Size(202, 320);
			this.control.TabIndex = 8;
			this.control.Text = "666";
			this.control.TimeStep = 16.66666F;
			// 
			// FrmEntityTemplateEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(416, 364);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cbMode);
			this.Controls.Add(this.control);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOK);
			this.Controls.Add(this.groupBox1);
			this.Name = "FrmEntityTemplateEditor";
			this.Text = "Template Editor";
			this.Load += new System.EventHandler(this.FrmEntityTemplateEditor_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbRows)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbColumn)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bImporttexture;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbType;
		private System.Windows.Forms.Button bOK;
		private System.Windows.Forms.Button bCancel;
		private MapEditor.Data.Controls.EditorView.ControlEntityEditor control;
		private System.Windows.Forms.ComboBox cbMode;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbShadow;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button bEditAnimation;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown tbRows;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown tbColumn;
	}
}