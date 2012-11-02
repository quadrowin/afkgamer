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
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "#000",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "#000",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "#000",
            "0"}, -1);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpScreen = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLoadScreen = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tpBw = new System.Windows.Forms.TabPage();
            this.tpMasks = new System.Windows.Forms.TabPage();
            this.lvColors = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tcMasks = new System.Windows.Forms.TabControl();
            this.tpGold = new System.Windows.Forms.TabPage();
            this.tpRare = new System.Windows.Forms.TabPage();
            this.tpMagic = new System.Windows.Forms.TabPage();
            this.lvHorizontalColors = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvVerticalColors = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbScreen = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lbHorizontalCount = new System.Windows.Forms.Label();
            this.lbVerticalCount = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbBw = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tpScreen.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tpBw.SuspendLayout();
            this.tpMasks.SuspendLayout();
            this.tcMasks.SuspendLayout();
            this.tpGold.SuspendLayout();
            this.tpRare.SuspendLayout();
            this.tpMagic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBw)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(970, 590);
            this.tabControl1.TabIndex = 0;
            // 
            // tpScreen
            // 
            this.tpScreen.Controls.Add(this.panel2);
            this.tpScreen.Controls.Add(this.panel1);
            this.tpScreen.Location = new System.Drawing.Point(4, 22);
            this.tpScreen.Name = "tpScreen";
            this.tpScreen.Padding = new System.Windows.Forms.Padding(3);
            this.tpScreen.Size = new System.Drawing.Size(962, 564);
            this.tpScreen.TabIndex = 0;
            this.tpScreen.Text = "Screenshot";
            this.tpScreen.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lbVerticalCount);
            this.panel2.Controls.Add(this.lbHorizontalCount);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lvVerticalColors);
            this.panel2.Controls.Add(this.lvHorizontalColors);
            this.panel2.Controls.Add(this.btnLoadScreen);
            this.panel2.Controls.Add(this.btnScan);
            this.panel2.Location = new System.Drawing.Point(714, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(247, 560);
            this.panel2.TabIndex = 2;
            // 
            // btnLoadScreen
            // 
            this.btnLoadScreen.Location = new System.Drawing.Point(6, 3);
            this.btnLoadScreen.Name = "btnLoadScreen";
            this.btnLoadScreen.Size = new System.Drawing.Size(75, 23);
            this.btnLoadScreen.TabIndex = 3;
            this.btnLoadScreen.Text = "Load...";
            this.btnLoadScreen.UseVisualStyleBackColor = true;
            this.btnLoadScreen.Click += new System.EventHandler(this.btnLoadScreen_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(166, 3);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 2;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pbScreen);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(705, 558);
            this.panel1.TabIndex = 0;
            // 
            // tpBw
            // 
            this.tpBw.Controls.Add(this.panel3);
            this.tpBw.Location = new System.Drawing.Point(4, 22);
            this.tpBw.Name = "tpBw";
            this.tpBw.Padding = new System.Windows.Forms.Padding(3);
            this.tpBw.Size = new System.Drawing.Size(962, 564);
            this.tpBw.TabIndex = 2;
            this.tpBw.Text = "BW";
            this.tpBw.UseVisualStyleBackColor = true;
            this.tpBw.Enter += new System.EventHandler(this.tpBw_Enter);
            // 
            // tpMasks
            // 
            this.tpMasks.Controls.Add(this.tcMasks);
            this.tpMasks.Controls.Add(this.lvColors);
            this.tpMasks.Location = new System.Drawing.Point(4, 22);
            this.tpMasks.Name = "tpMasks";
            this.tpMasks.Padding = new System.Windows.Forms.Padding(3);
            this.tpMasks.Size = new System.Drawing.Size(962, 564);
            this.tpMasks.TabIndex = 1;
            this.tpMasks.Text = "Masks";
            this.tpMasks.UseVisualStyleBackColor = true;
            // 
            // lvColors
            // 
            this.lvColors.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvColors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvColors.GridLines = true;
            this.lvColors.HotTracking = true;
            this.lvColors.HoverSelection = true;
            this.lvColors.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4});
            this.lvColors.Location = new System.Drawing.Point(720, 6);
            this.lvColors.Name = "lvColors";
            this.lvColors.Size = new System.Drawing.Size(235, 286);
            this.lvColors.TabIndex = 1;
            this.lvColors.UseCompatibleStateImageBehavior = false;
            this.lvColors.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Color";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Count";
            this.columnHeader2.Width = 40;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tcMasks
            // 
            this.tcMasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tcMasks.Controls.Add(this.tpGold);
            this.tcMasks.Controls.Add(this.tpRare);
            this.tcMasks.Controls.Add(this.tpMagic);
            this.tcMasks.Location = new System.Drawing.Point(6, 6);
            this.tcMasks.Name = "tcMasks";
            this.tcMasks.SelectedIndex = 0;
            this.tcMasks.Size = new System.Drawing.Size(340, 551);
            this.tcMasks.TabIndex = 2;
            this.tcMasks.SelectedIndexChanged += new System.EventHandler(this.tcMasks_SelectedIndexChanged);
            // 
            // tpGold
            // 
            this.tpGold.Controls.Add(this.pictureBox1);
            this.tpGold.Location = new System.Drawing.Point(4, 22);
            this.tpGold.Name = "tpGold";
            this.tpGold.Padding = new System.Windows.Forms.Padding(3);
            this.tpGold.Size = new System.Drawing.Size(332, 525);
            this.tpGold.TabIndex = 0;
            this.tpGold.Text = "Gold";
            this.tpGold.UseVisualStyleBackColor = true;
            // 
            // tpRare
            // 
            this.tpRare.Controls.Add(this.pictureBox2);
            this.tpRare.Location = new System.Drawing.Point(4, 22);
            this.tpRare.Name = "tpRare";
            this.tpRare.Padding = new System.Windows.Forms.Padding(3);
            this.tpRare.Size = new System.Drawing.Size(332, 525);
            this.tpRare.TabIndex = 1;
            this.tpRare.Text = "Rare";
            this.tpRare.UseVisualStyleBackColor = true;
            // 
            // tpMagic
            // 
            this.tpMagic.Controls.Add(this.pictureBox3);
            this.tpMagic.Location = new System.Drawing.Point(4, 22);
            this.tpMagic.Name = "tpMagic";
            this.tpMagic.Size = new System.Drawing.Size(332, 525);
            this.tpMagic.TabIndex = 2;
            this.tpMagic.Text = "Magic";
            this.tpMagic.UseVisualStyleBackColor = true;
            // 
            // lvHorizontalColors
            // 
            this.lvHorizontalColors.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvHorizontalColors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvHorizontalColors.GridLines = true;
            this.lvHorizontalColors.HotTracking = true;
            this.lvHorizontalColors.HoverSelection = true;
            this.lvHorizontalColors.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem5});
            this.lvHorizontalColors.Location = new System.Drawing.Point(6, 58);
            this.lvHorizontalColors.Name = "lvHorizontalColors";
            this.lvHorizontalColors.Size = new System.Drawing.Size(235, 156);
            this.lvHorizontalColors.TabIndex = 4;
            this.lvHorizontalColors.UseCompatibleStateImageBehavior = false;
            this.lvHorizontalColors.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Color";
            this.columnHeader3.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Count";
            this.columnHeader4.Width = 40;
            // 
            // lvVerticalColors
            // 
            this.lvVerticalColors.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvVerticalColors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lvVerticalColors.GridLines = true;
            this.lvVerticalColors.HotTracking = true;
            this.lvVerticalColors.HoverSelection = true;
            this.lvVerticalColors.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6});
            this.lvVerticalColors.Location = new System.Drawing.Point(6, 243);
            this.lvVerticalColors.Name = "lvVerticalColors";
            this.lvVerticalColors.Size = new System.Drawing.Size(235, 156);
            this.lvVerticalColors.TabIndex = 5;
            this.lvVerticalColors.UseCompatibleStateImageBehavior = false;
            this.lvVerticalColors.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Color";
            this.columnHeader5.Width = 160;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Count";
            this.columnHeader6.Width = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "horizontal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "vertical:";
            // 
            // pbScreen
            // 
            this.pbScreen.Image = global::DetectionTest.Properties.Resources.diablo_drop_mask3;
            this.pbScreen.Location = new System.Drawing.Point(3, 3);
            this.pbScreen.Name = "pbScreen";
            this.pbScreen.Size = new System.Drawing.Size(1680, 1050);
            this.pbScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbScreen.TabIndex = 0;
            this.pbScreen.TabStop = false;
            this.pbScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbScreen_MouseDown);
            this.pbScreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbScreen_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DetectionTest.Properties.Resources.diablo_gold_mask;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DetectionTest.Properties.Resources.diablo_drop_mask2;
            this.pictureBox2.Location = new System.Drawing.Point(6, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(103, 50);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DetectionTest.Properties.Resources.diablo_drop_mask1;
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(103, 50);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // lbHorizontalCount
            // 
            this.lbHorizontalCount.AutoSize = true;
            this.lbHorizontalCount.Location = new System.Drawing.Point(65, 42);
            this.lbHorizontalCount.Name = "lbHorizontalCount";
            this.lbHorizontalCount.Size = new System.Drawing.Size(13, 13);
            this.lbHorizontalCount.TabIndex = 8;
            this.lbHorizontalCount.Text = "0";
            // 
            // lbVerticalCount
            // 
            this.lbVerticalCount.AutoSize = true;
            this.lbVerticalCount.Location = new System.Drawing.Point(54, 227);
            this.lbVerticalCount.Name = "lbVerticalCount";
            this.lbVerticalCount.Size = new System.Drawing.Size(13, 13);
            this.lbVerticalCount.TabIndex = 9;
            this.lbVerticalCount.Text = "0";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.pbBw);
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(782, 551);
            this.panel3.TabIndex = 1;
            // 
            // pbBw
            // 
            this.pbBw.Location = new System.Drawing.Point(3, 3);
            this.pbBw.Name = "pbBw";
            this.pbBw.Size = new System.Drawing.Size(100, 100);
            this.pbBw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbBw.TabIndex = 0;
            this.pbBw.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 593);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "DetectionTest";
            this.tabControl1.ResumeLayout(false);
            this.tpScreen.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tpBw.ResumeLayout(false);
            this.tpMasks.ResumeLayout(false);
            this.tcMasks.ResumeLayout(false);
            this.tpGold.ResumeLayout(false);
            this.tpRare.ResumeLayout(false);
            this.tpMagic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBw)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpScreen;
		private System.Windows.Forms.TabPage tpMasks;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pbScreen;
        private System.Windows.Forms.TabPage tpBw;
		private System.Windows.Forms.ListView lvColors;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnLoadScreen;
		private System.Windows.Forms.Button btnScan;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tcMasks;
        private System.Windows.Forms.TabPage tpGold;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tpRare;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabPage tpMagic;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvVerticalColors;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView lvHorizontalColors;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lbVerticalCount;
        private System.Windows.Forms.Label lbHorizontalCount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pbBw;
	}
}

