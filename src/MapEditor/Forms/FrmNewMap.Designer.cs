namespace MapEditor.Forms.Form_Regions {
	partial class FrmNewMap {
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
			this.lbName = new System.Windows.Forms.Label();
			this.gbSettings = new System.Windows.Forms.GroupBox();
			this.clTilesets = new System.Windows.Forms.CheckedListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.udHeight = new System.Windows.Forms.NumericUpDown();
			this.udWidth = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbName = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.gbSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.udHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udWidth)).BeginInit();
			this.SuspendLayout();
			// 
			// lbName
			// 
			this.lbName.AutoSize = true;
			this.lbName.Location = new System.Drawing.Point(13, 17);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(38, 13);
			this.lbName.TabIndex = 0;
			this.lbName.Text = "Name:";
			this.toolTip1.SetToolTip(this.lbName, "Your map\'s Name");
			// 
			// gbSettings
			// 
			this.gbSettings.Controls.Add(this.clTilesets);
			this.gbSettings.Controls.Add(this.label3);
			this.gbSettings.Controls.Add(this.udHeight);
			this.gbSettings.Controls.Add(this.udWidth);
			this.gbSettings.Controls.Add(this.label2);
			this.gbSettings.Controls.Add(this.label1);
			this.gbSettings.Controls.Add(this.tbName);
			this.gbSettings.Controls.Add(this.lbName);
			this.gbSettings.Location = new System.Drawing.Point(12, 12);
			this.gbSettings.Name = "gbSettings";
			this.gbSettings.Size = new System.Drawing.Size(209, 275);
			this.gbSettings.TabIndex = 1;
			this.gbSettings.TabStop = false;
			this.gbSettings.Text = "Settings";
			// 
			// clTilesets
			// 
			this.clTilesets.FormattingEnabled = true;
			this.clTilesets.Location = new System.Drawing.Point(16, 128);
			this.clTilesets.Name = "clTilesets";
			this.clTilesets.Size = new System.Drawing.Size(186, 139);
			this.clTilesets.TabIndex = 8;
			this.clTilesets.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clTilesets_ItemCheck);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Tilesets";
			this.toolTip1.SetToolTip(this.label3, "Tilesets to use in this map. They cannot be changed later on. Use as many as you " +
        "wish.");
			// 
			// udHeight
			// 
			this.udHeight.Location = new System.Drawing.Point(112, 72);
			this.udHeight.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
			this.udHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udHeight.Name = "udHeight";
			this.udHeight.Size = new System.Drawing.Size(90, 20);
			this.udHeight.TabIndex = 5;
			this.udHeight.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
			// 
			// udWidth
			// 
			this.udWidth.Location = new System.Drawing.Point(16, 72);
			this.udWidth.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
			this.udWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udWidth.Name = "udWidth";
			this.udWidth.Size = new System.Drawing.Size(90, 20);
			this.udWidth.TabIndex = 4;
			this.udWidth.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(109, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Height";
			this.toolTip1.SetToolTip(this.label2, "The height of this map (in Tiles)");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Width";
			this.toolTip1.SetToolTip(this.label1, "The width of this map (in Tiles)");
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(16, 33);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(186, 20);
			this.tbName.TabIndex = 1;
			// 
			// btnOK
			// 
			this.btnOK.Enabled = false;
			this.btnOK.Location = new System.Drawing.Point(42, 293);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.toolTip1.SetToolTip(this.btnOK, "Remember there can\'t be no tilesets for a map");
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(125, 293);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// FrmNewMap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(233, 324);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.gbSettings);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmNewMap";
			this.Text = "New map";
			this.Load += new System.EventHandler(this.FrmNewMap_Load);
			this.gbSettings.ResumeLayout(false);
			this.gbSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.udHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udWidth)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lbName;
		private System.Windows.Forms.GroupBox gbSettings;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.NumericUpDown udHeight;
		private System.Windows.Forms.NumericUpDown udWidth;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckedListBox clTilesets;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ToolTip toolTip1;


	}
}