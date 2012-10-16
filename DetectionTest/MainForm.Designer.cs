namespace DetectionTest
{
	partial class MainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Gold", 0);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpScreen = new System.Windows.Forms.TabPage();
			this.tpMasks = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pbScreen = new System.Windows.Forms.PictureBox();
			this.tpBw = new System.Windows.Forms.TabPage();
			this.listView1 = new System.Windows.Forms.ListView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btnScan = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tpScreen.SuspendLayout();
			this.tpMasks.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbScreen)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tpScreen);
			this.tabControl1.Controls.Add(this.tpBw);
			this.tabControl1.Controls.Add(this.tpMasks);
			this.tabControl1.Location = new System.Drawing.Point(2, 2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(922, 547);
			this.tabControl1.TabIndex = 0;
			// 
			// tpScreen
			// 
			this.tpScreen.Controls.Add(this.btnScan);
			this.tpScreen.Controls.Add(this.panel1);
			this.tpScreen.Location = new System.Drawing.Point(4, 22);
			this.tpScreen.Name = "tpScreen";
			this.tpScreen.Padding = new System.Windows.Forms.Padding(3);
			this.tpScreen.Size = new System.Drawing.Size(914, 521);
			this.tpScreen.TabIndex = 0;
			this.tpScreen.Text = "Screenshot";
			this.tpScreen.UseVisualStyleBackColor = true;
			// 
			// tpMasks
			// 
			this.tpMasks.Controls.Add(this.listView1);
			this.tpMasks.Location = new System.Drawing.Point(4, 22);
			this.tpMasks.Name = "tpMasks";
			this.tpMasks.Padding = new System.Windows.Forms.Padding(3);
			this.tpMasks.Size = new System.Drawing.Size(914, 521);
			this.tpMasks.TabIndex = 1;
			this.tpMasks.Text = "Masks";
			this.tpMasks.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.pbScreen);
			this.panel1.Location = new System.Drawing.Point(6, 35);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(902, 479);
			this.panel1.TabIndex = 0;
			// 
			// pbScreen
			// 
			this.pbScreen.Image = global::DetectionTest.Properties.Resources.Screenshot003;
			this.pbScreen.Location = new System.Drawing.Point(3, 3);
			this.pbScreen.Name = "pbScreen";
			this.pbScreen.Size = new System.Drawing.Size(1680, 1056);
			this.pbScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbScreen.TabIndex = 0;
			this.pbScreen.TabStop = false;
			// 
			// tpBw
			// 
			this.tpBw.Location = new System.Drawing.Point(4, 22);
			this.tpBw.Name = "tpBw";
			this.tpBw.Padding = new System.Windows.Forms.Padding(3);
			this.tpBw.Size = new System.Drawing.Size(914, 521);
			this.tpBw.TabIndex = 2;
			this.tpBw.Text = "BW";
			this.tpBw.UseVisualStyleBackColor = true;
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
			this.listView1.LargeImageList = this.imageList1;
			this.listView1.Location = new System.Drawing.Point(6, 6);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(183, 508);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "diablo_gold_mask.png");
			// 
			// btnScan
			// 
			this.btnScan.Location = new System.Drawing.Point(6, 6);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size(75, 23);
			this.btnScan.TabIndex = 1;
			this.btnScan.Text = "Scan";
			this.btnScan.UseVisualStyleBackColor = true;
			this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(925, 550);
			this.Controls.Add(this.tabControl1);
			this.Name = "MainForm";
			this.Text = "DetectionTest";
			this.tabControl1.ResumeLayout(false);
			this.tpScreen.ResumeLayout(false);
			this.tpMasks.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbScreen)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpScreen;
		private System.Windows.Forms.TabPage tpMasks;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pbScreen;
		private System.Windows.Forms.TabPage tpBw;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button btnScan;
	}
}

