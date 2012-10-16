namespace l2gamer
{
	partial class UcDebugScreenshot
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cbActive = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnInit = new System.Windows.Forms.Button();
			this.rbDirect11 = new System.Windows.Forms.RadioButton();
			this.rbDirect10 = new System.Windows.Forms.RadioButton();
			this.rbDirect9 = new System.Windows.Forms.RadioButton();
			this.pbScreenshot = new System.Windows.Forms.PictureBox();
			this.comboSizeMode = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbScreenshot)).BeginInit();
			this.SuspendLayout();
			// 
			// cbActive
			// 
			this.cbActive.AutoSize = true;
			this.cbActive.Location = new System.Drawing.Point(352, 19);
			this.cbActive.Name = "cbActive";
			this.cbActive.Size = new System.Drawing.Size(56, 17);
			this.cbActive.TabIndex = 0;
			this.cbActive.Text = "Active";
			this.cbActive.UseVisualStyleBackColor = true;
			this.cbActive.CheckedChanged += new System.EventHandler(this.cbActive_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnInit);
			this.groupBox1.Controls.Add(this.rbDirect11);
			this.groupBox1.Controls.Add(this.rbDirect10);
			this.groupBox1.Controls.Add(this.rbDirect9);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(333, 45);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "DirectX";
			// 
			// btnInit
			// 
			this.btnInit.Location = new System.Drawing.Point(248, 13);
			this.btnInit.Name = "btnInit";
			this.btnInit.Size = new System.Drawing.Size(75, 23);
			this.btnInit.TabIndex = 3;
			this.btnInit.Text = "init";
			this.btnInit.UseVisualStyleBackColor = true;
			this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
			// 
			// rbDirect11
			// 
			this.rbDirect11.AutoSize = true;
			this.rbDirect11.Location = new System.Drawing.Point(168, 16);
			this.rbDirect11.Name = "rbDirect11";
			this.rbDirect11.Size = new System.Drawing.Size(37, 17);
			this.rbDirect11.TabIndex = 2;
			this.rbDirect11.Text = "11";
			this.rbDirect11.UseVisualStyleBackColor = true;
			this.rbDirect11.CheckedChanged += new System.EventHandler(this.rbDirect9_CheckedChanged);
			// 
			// rbDirect10
			// 
			this.rbDirect10.AutoSize = true;
			this.rbDirect10.Location = new System.Drawing.Point(88, 16);
			this.rbDirect10.Name = "rbDirect10";
			this.rbDirect10.Size = new System.Drawing.Size(37, 17);
			this.rbDirect10.TabIndex = 1;
			this.rbDirect10.Text = "10";
			this.rbDirect10.UseVisualStyleBackColor = true;
			this.rbDirect10.CheckedChanged += new System.EventHandler(this.rbDirect9_CheckedChanged);
			// 
			// rbDirect9
			// 
			this.rbDirect9.AutoSize = true;
			this.rbDirect9.Checked = true;
			this.rbDirect9.Location = new System.Drawing.Point(8, 16);
			this.rbDirect9.Name = "rbDirect9";
			this.rbDirect9.Size = new System.Drawing.Size(31, 17);
			this.rbDirect9.TabIndex = 0;
			this.rbDirect9.TabStop = true;
			this.rbDirect9.Text = "9";
			this.rbDirect9.UseVisualStyleBackColor = true;
			this.rbDirect9.CheckedChanged += new System.EventHandler(this.rbDirect9_CheckedChanged);
			// 
			// pbScreenshot
			// 
			this.pbScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbScreenshot.Location = new System.Drawing.Point(3, 54);
			this.pbScreenshot.Name = "pbScreenshot";
			this.pbScreenshot.Size = new System.Drawing.Size(548, 323);
			this.pbScreenshot.TabIndex = 1;
			this.pbScreenshot.TabStop = false;
			// 
			// comboSizeMode
			// 
			this.comboSizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboSizeMode.FormattingEnabled = true;
			this.comboSizeMode.Items.AddRange(new object[] {
            "Normal",
            "StretchImage",
            "AutoSize",
            "CenterImage",
            "Zoom"});
			this.comboSizeMode.Location = new System.Drawing.Point(430, 18);
			this.comboSizeMode.Name = "comboSizeMode";
			this.comboSizeMode.Size = new System.Drawing.Size(121, 21);
			this.comboSizeMode.TabIndex = 15;
			this.comboSizeMode.SelectedIndexChanged += new System.EventHandler(this.comboSizeMode_SelectedIndexChanged);
			// 
			// UcDebugScreenshot
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.comboSizeMode);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.pbScreenshot);
			this.Controls.Add(this.cbActive);
			this.Name = "UcDebugScreenshot";
			this.Size = new System.Drawing.Size(554, 380);
			this.Load += new System.EventHandler(this.UcDebugScreenshot_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbScreenshot)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox cbActive;
		private System.Windows.Forms.PictureBox pbScreenshot;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnInit;
		private System.Windows.Forms.RadioButton rbDirect11;
		private System.Windows.Forms.RadioButton rbDirect10;
		private System.Windows.Forms.RadioButton rbDirect9;
		private System.Windows.Forms.ComboBox comboSizeMode;
	}
}
