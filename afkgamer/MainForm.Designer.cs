namespace l2gamer
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.lvWindows = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tbWindowFilter = new System.Windows.Forms.TextBox();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.tmrUpdateState = new System.Windows.Forms.Timer(this.components);
			this.tcWindow = new System.Windows.Forms.TabControl();
			this.tpAutoKeys = new System.Windows.Forms.TabPage();
			this.tpScreenshot = new System.Windows.Forms.TabPage();
			this.tpProgressBinding = new System.Windows.Forms.TabPage();
			this.tpMouseMacros = new System.Windows.Forms.TabPage();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();
			this.tmrMouseMacrosWrite = new System.Windows.Forms.Timer(this.components);
			this.tmrMouseMacrosExecute = new System.Windows.Forms.Timer(this.components);
			this.cbCharacter = new System.Windows.Forms.ComboBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.tcWindow.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.panel1.Controls.Add(this.lvWindows);
			this.panel1.Controls.Add(this.tbWindowFilter);
			this.panel1.Controls.Add(this.btnRefresh);
			this.panel1.Location = new System.Drawing.Point(0, 40);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(224, 554);
			this.panel1.TabIndex = 0;
			// 
			// lvWindows
			// 
			this.lvWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvWindows.CheckBoxes = true;
			this.lvWindows.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.lvWindows.FullRowSelect = true;
			this.lvWindows.GridLines = true;
			this.lvWindows.HideSelection = false;
			this.lvWindows.Location = new System.Drawing.Point(8, 40);
			this.lvWindows.MultiSelect = false;
			this.lvWindows.Name = "lvWindows";
			this.lvWindows.OwnerDraw = true;
			this.lvWindows.Size = new System.Drawing.Size(208, 506);
			this.lvWindows.TabIndex = 3;
			this.lvWindows.UseCompatibleStateImageBehavior = false;
			this.lvWindows.View = System.Windows.Forms.View.Details;
			this.lvWindows.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvWindows_DrawColumnHeader);
			this.lvWindows.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvWindows_DrawItem);
			this.lvWindows.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvWindows_DrawSubItem);
			this.lvWindows.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvWindows_ItemCheck);
			this.lvWindows.SelectedIndexChanged += new System.EventHandler(this.lvWindows_SelectedIndexChanged);
			this.lvWindows.DoubleClick += new System.EventHandler(this.lvWindows_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "title";
			this.columnHeader1.Width = 90;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "char";
			this.columnHeader2.Width = 90;
			// 
			// tbWindowFilter
			// 
			this.tbWindowFilter.Location = new System.Drawing.Point(8, 8);
			this.tbWindowFilter.Name = "tbWindowFilter";
			this.tbWindowFilter.Size = new System.Drawing.Size(127, 20);
			this.tbWindowFilter.TabIndex = 2;
			this.tbWindowFilter.Text = "PotPlayer";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(141, 6);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(75, 23);
			this.btnRefresh.TabIndex = 1;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// tmrUpdateState
			// 
			this.tmrUpdateState.Tick += new System.EventHandler(this.tmrUpdateState_Tick);
			// 
			// tcWindow
			// 
			this.tcWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tcWindow.Controls.Add(this.tpAutoKeys);
			this.tcWindow.Controls.Add(this.tpScreenshot);
			this.tcWindow.Controls.Add(this.tpProgressBinding);
			this.tcWindow.Controls.Add(this.tpMouseMacros);
			this.tcWindow.Location = new System.Drawing.Point(224, 40);
			this.tcWindow.Name = "tcWindow";
			this.tcWindow.SelectedIndex = 0;
			this.tcWindow.Size = new System.Drawing.Size(488, 556);
			this.tcWindow.TabIndex = 1;
			this.tcWindow.SizeChanged += new System.EventHandler(this.tcWindow_SizeChanged);
			// 
			// tpAutoKeys
			// 
			this.tpAutoKeys.Location = new System.Drawing.Point(4, 22);
			this.tpAutoKeys.Name = "tpAutoKeys";
			this.tpAutoKeys.Padding = new System.Windows.Forms.Padding(3);
			this.tpAutoKeys.Size = new System.Drawing.Size(480, 530);
			this.tpAutoKeys.TabIndex = 0;
			this.tpAutoKeys.Text = "clicker";
			// 
			// tpScreenshot
			// 
			this.tpScreenshot.Location = new System.Drawing.Point(4, 22);
			this.tpScreenshot.Name = "tpScreenshot";
			this.tpScreenshot.Padding = new System.Windows.Forms.Padding(3);
			this.tpScreenshot.Size = new System.Drawing.Size(480, 530);
			this.tpScreenshot.TabIndex = 2;
			this.tpScreenshot.Text = "Screenshot";
			this.tpScreenshot.UseVisualStyleBackColor = true;
			// 
			// tpProgressBinding
			// 
			this.tpProgressBinding.Location = new System.Drawing.Point(4, 22);
			this.tpProgressBinding.Name = "tpProgressBinding";
			this.tpProgressBinding.Padding = new System.Windows.Forms.Padding(3);
			this.tpProgressBinding.Size = new System.Drawing.Size(480, 530);
			this.tpProgressBinding.TabIndex = 1;
			this.tpProgressBinding.Text = "extended";
			this.tpProgressBinding.UseVisualStyleBackColor = true;
			// 
			// tpMouseMacros
			// 
			this.tpMouseMacros.Location = new System.Drawing.Point(4, 22);
			this.tpMouseMacros.Name = "tpMouseMacros";
			this.tpMouseMacros.Padding = new System.Windows.Forms.Padding(3);
			this.tpMouseMacros.Size = new System.Drawing.Size(480, 530);
			this.tpMouseMacros.TabIndex = 3;
			this.tpMouseMacros.Text = "mouse macros";
			this.tpMouseMacros.UseVisualStyleBackColor = true;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "xml";
			this.openFileDialog1.Filter = "XML Documents (*.xml)|*.xml";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "xml";
			this.saveFileDialog1.Filter = "XML Documents (*.xml)|*.xml";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(494, 6);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(575, 6);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(75, 23);
			this.btnLoad.TabIndex = 4;
			this.btnLoad.Text = "Load";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// tmrMouseMacrosWrite
			// 
			this.tmrMouseMacrosWrite.Interval = 1;
			// 
			// tmrMouseMacrosExecute
			// 
			this.tmrMouseMacrosExecute.Interval = 1;
			// 
			// cbCharacter
			// 
			this.cbCharacter.FormattingEnabled = true;
			this.cbCharacter.Location = new System.Drawing.Point(230, 8);
			this.cbCharacter.Name = "cbCharacter";
			this.cbCharacter.Size = new System.Drawing.Size(245, 21);
			this.cbCharacter.TabIndex = 5;
			this.cbCharacter.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(714, 24);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked_1);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(89, 20);
			this.toolStripMenuItem1.Text = "Click settings";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Checked = true;
			this.toolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(250, 22);
			this.toolStripMenuItem2.Text = "simple (fast, but detectable)";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(250, 22);
			this.toolStripMenuItem3.Text = "extended (very slow, but security)";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(714, 598);
			this.Controls.Add(this.cbCharacter);
			this.Controls.Add(this.btnLoad);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.tcWindow);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "MainForm";
			this.Text = "afkgamer";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tcWindow.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbWindowFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListView lvWindows;
        private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Timer tmrUpdateState;
		private System.Windows.Forms.TabControl tcWindow;
		private System.Windows.Forms.TabPage tpAutoKeys;
		private System.Windows.Forms.TabPage tpProgressBinding;
		private System.Windows.Forms.TabPage tpScreenshot;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.TabPage tpMouseMacros;
		private System.Windows.Forms.Timer tmrMouseMacrosWrite;
		private System.Windows.Forms.Timer tmrMouseMacrosExecute;
		private System.Windows.Forms.ComboBox cbCharacter;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}

