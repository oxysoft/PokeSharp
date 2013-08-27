namespace MapEditor.Forms {
	partial class FrmAnimationEditor {
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
			General.Graphics.Animations.Animation animation1 = new General.Graphics.Animations.Animation();
			this.control = new MapEditor.Data.Controls.EditorView.ControlAnimationEditor();
			this.cbAnimations = new System.Windows.Forms.ComboBox();
			this.bNew = new System.Windows.Forms.Button();
			this.bDelete = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cResettable = new System.Windows.Forms.CheckBox();
			this.bStop = new System.Windows.Forms.Button();
			this.tbCurrentFrame = new System.Windows.Forms.NumericUpDown();
			this.bPlay = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.cLoopable = new System.Windows.Forms.CheckBox();
			this.tbDuration = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.tbFrames = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.tbName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bOK = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.cbTemplates = new System.Windows.Forms.ComboBox();
			this.bFromTemplate = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbCurrentFrame)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbDuration)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbFrames)).BeginInit();
			this.SuspendLayout();
			// 
			// control
			// 
			animation1.Flags = General.Graphics.Animations.AnimationFlags.None;
			animation1.Name = null;
			animation1.TimePerFrame = 0.01F;
			this.control.Animation = animation1;
			this.control.GameLoopEnabled = true;
			this.control.Location = new System.Drawing.Point(12, 66);
			this.control.Name = "control";
			this.control.PlayAnimation = false;
			this.control.SelectedFrame = 0;
			this.control.Size = new System.Drawing.Size(309, 294);
			this.control.TabIndex = 0;
			this.control.Text = "animationEditorControl1";
			this.control.TileableTexture = null;
			this.control.TimeStep = 16.66666F;
			// 
			// cbAnimations
			// 
			this.cbAnimations.FormattingEnabled = true;
			this.cbAnimations.Location = new System.Drawing.Point(12, 12);
			this.cbAnimations.Name = "cbAnimations";
			this.cbAnimations.Size = new System.Drawing.Size(159, 21);
			this.cbAnimations.TabIndex = 1;
			this.cbAnimations.SelectedIndexChanged += new System.EventHandler(this.cbAnimations_SelectedIndexChanged);
			// 
			// bNew
			// 
			this.bNew.Location = new System.Drawing.Point(177, 12);
			this.bNew.Name = "bNew";
			this.bNew.Size = new System.Drawing.Size(87, 22);
			this.bNew.TabIndex = 2;
			this.bNew.Text = "New animation";
			this.bNew.UseVisualStyleBackColor = true;
			this.bNew.Click += new System.EventHandler(this.bNew_Click);
			// 
			// bDelete
			// 
			this.bDelete.Enabled = false;
			this.bDelete.Location = new System.Drawing.Point(270, 12);
			this.bDelete.Name = "bDelete";
			this.bDelete.Size = new System.Drawing.Size(51, 22);
			this.bDelete.TabIndex = 3;
			this.bDelete.Text = "Delete";
			this.bDelete.UseVisualStyleBackColor = true;
			this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cResettable);
			this.groupBox1.Controls.Add(this.bStop);
			this.groupBox1.Controls.Add(this.tbCurrentFrame);
			this.groupBox1.Controls.Add(this.bPlay);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.cLoopable);
			this.groupBox1.Controls.Add(this.tbDuration);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tbFrames);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(327, 66);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(221, 254);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Animation";
			// 
			// cResettable
			// 
			this.cResettable.AutoSize = true;
			this.cResettable.Location = new System.Drawing.Point(13, 159);
			this.cResettable.Name = "cResettable";
			this.cResettable.Size = new System.Drawing.Size(77, 17);
			this.cResettable.TabIndex = 9;
			this.cResettable.Text = "Resettable";
			this.cResettable.UseVisualStyleBackColor = true;
			this.cResettable.CheckedChanged += new System.EventHandler(this.cResettable_CheckedChanged);
			// 
			// bStop
			// 
			this.bStop.Location = new System.Drawing.Point(166, 221);
			this.bStop.Name = "bStop";
			this.bStop.Size = new System.Drawing.Size(49, 23);
			this.bStop.TabIndex = 6;
			this.bStop.Text = "Stop";
			this.bStop.UseVisualStyleBackColor = true;
			this.bStop.Click += new System.EventHandler(this.bStop_Click);
			// 
			// tbCurrentFrame
			// 
			this.tbCurrentFrame.Location = new System.Drawing.Point(13, 195);
			this.tbCurrentFrame.Name = "tbCurrentFrame";
			this.tbCurrentFrame.Size = new System.Drawing.Size(202, 20);
			this.tbCurrentFrame.TabIndex = 8;
			this.tbCurrentFrame.ValueChanged += new System.EventHandler(this.tbCurrentFrame_ValueChanged);
			// 
			// bPlay
			// 
			this.bPlay.Location = new System.Drawing.Point(13, 221);
			this.bPlay.Name = "bPlay";
			this.bPlay.Size = new System.Drawing.Size(147, 23);
			this.bPlay.TabIndex = 5;
			this.bPlay.Text = "Play";
			this.bPlay.UseVisualStyleBackColor = true;
			this.bPlay.Click += new System.EventHandler(this.bPlay_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 179);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Current frame";
			// 
			// cLoopable
			// 
			this.cLoopable.AutoSize = true;
			this.cLoopable.Location = new System.Drawing.Point(13, 136);
			this.cLoopable.Name = "cLoopable";
			this.cLoopable.Size = new System.Drawing.Size(70, 17);
			this.cLoopable.TabIndex = 6;
			this.cLoopable.Text = "Loopable";
			this.cLoopable.UseVisualStyleBackColor = true;
			this.cLoopable.CheckedChanged += new System.EventHandler(this.cLoopable_CheckedChanged);
			// 
			// tbDuration
			// 
			this.tbDuration.DecimalPlaces = 2;
			this.tbDuration.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.tbDuration.Location = new System.Drawing.Point(13, 110);
			this.tbDuration.Name = "tbDuration";
			this.tbDuration.Size = new System.Drawing.Size(202, 20);
			this.tbDuration.TabIndex = 5;
			this.tbDuration.ValueChanged += new System.EventHandler(this.tbDuration_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Duration per frame";
			// 
			// tbFrames
			// 
			this.tbFrames.Location = new System.Drawing.Point(13, 71);
			this.tbFrames.Name = "tbFrames";
			this.tbFrames.Size = new System.Drawing.Size(202, 20);
			this.tbFrames.TabIndex = 3;
			this.tbFrames.ValueChanged += new System.EventHandler(this.tbFrames_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Frames:";
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(13, 32);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(202, 20);
			this.tbName.TabIndex = 1;
			this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name:";
			// 
			// bOK
			// 
			this.bOK.Location = new System.Drawing.Point(356, 326);
			this.bOK.Name = "bOK";
			this.bOK.Size = new System.Drawing.Size(75, 23);
			this.bOK.TabIndex = 9;
			this.bOK.Text = "OK";
			this.bOK.UseVisualStyleBackColor = true;
			this.bOK.Click += new System.EventHandler(this.bOK_Click);
			// 
			// bCancel
			// 
			this.bCancel.Location = new System.Drawing.Point(437, 326);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(75, 23);
			this.bCancel.TabIndex = 10;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = true;
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			// 
			// cbTemplates
			// 
			this.cbTemplates.FormattingEnabled = true;
			this.cbTemplates.Items.AddRange(new object[] {
            "None",
            "Human"});
			this.cbTemplates.Location = new System.Drawing.Point(12, 39);
			this.cbTemplates.Name = "cbTemplates";
			this.cbTemplates.Size = new System.Drawing.Size(159, 21);
			this.cbTemplates.TabIndex = 11;
			// 
			// bFromTemplate
			// 
			this.bFromTemplate.Location = new System.Drawing.Point(177, 39);
			this.bFromTemplate.Name = "bFromTemplate";
			this.bFromTemplate.Size = new System.Drawing.Size(144, 22);
			this.bFromTemplate.TabIndex = 12;
			this.bFromTemplate.Text = "From animation template";
			this.bFromTemplate.UseVisualStyleBackColor = true;
			this.bFromTemplate.Click += new System.EventHandler(this.bFromTemplate_Click);
			// 
			// FrmAnimationEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(560, 368);
			this.Controls.Add(this.bFromTemplate);
			this.Controls.Add(this.cbTemplates);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOK);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.bDelete);
			this.Controls.Add(this.bNew);
			this.Controls.Add(this.cbAnimations);
			this.Controls.Add(this.control);
			this.Name = "FrmAnimationEditor";
			this.Text = "Animation Editor";
			this.Load += new System.EventHandler(this.FrmAnimationEditor_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbCurrentFrame)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbDuration)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbFrames)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Data.Controls.EditorView.ControlAnimationEditor control;
		private System.Windows.Forms.ComboBox cbAnimations;
		private System.Windows.Forms.Button bNew;
		private System.Windows.Forms.Button bDelete;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button bStop;
		private System.Windows.Forms.NumericUpDown tbCurrentFrame;
		private System.Windows.Forms.Button bPlay;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox cLoopable;
		private System.Windows.Forms.NumericUpDown tbDuration;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown tbFrames;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bOK;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.CheckBox cResettable;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ComboBox cbTemplates;
		private System.Windows.Forms.Button bFromTemplate;
	}
}