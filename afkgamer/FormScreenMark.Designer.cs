namespace l2gamer
{
    partial class FormScreenMark
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScreenMark));
			this.panel1 = new System.Windows.Forms.Panel();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.btnAccept = new System.Windows.Forms.Button();
			this.btnUpdateScreen = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.clbWho = new System.Windows.Forms.CheckedListBox();
			this.pnlScreen = new System.Windows.Forms.Panel();
			this.pnlHp = new System.Windows.Forms.Panel();
			this.labelHp = new System.Windows.Forms.Label();
			this.picbScreen = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			this.pnlScreen.SuspendLayout();
			this.pnlHp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picbScreen)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.listBox1);
			this.panel1.Controls.Add(this.btnAccept);
			this.panel1.Controls.Add(this.btnUpdateScreen);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.clbWho);
			this.panel1.Location = new System.Drawing.Point(8, 450);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1080, 114);
			this.panel1.TabIndex = 0;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(848, 8);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(224, 95);
			this.listBox1.TabIndex = 5;
			// 
			// btnAccept
			// 
			this.btnAccept.Location = new System.Drawing.Point(8, 80);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(96, 23);
			this.btnAccept.TabIndex = 4;
			this.btnAccept.Text = "Accept";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// btnUpdateScreen
			// 
			this.btnUpdateScreen.Location = new System.Drawing.Point(8, 8);
			this.btnUpdateScreen.Name = "btnUpdateScreen";
			this.btnUpdateScreen.Size = new System.Drawing.Size(96, 23);
			this.btnUpdateScreen.TabIndex = 3;
			this.btnUpdateScreen.Text = "Update screen";
			this.btnUpdateScreen.UseVisualStyleBackColor = true;
			this.btnUpdateScreen.Click += new System.EventHandler(this.btnUpdateScreen_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(744, 80);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Clear all";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(744, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Clear this";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// clbWho
			// 
			this.clbWho.FormattingEnabled = true;
			this.clbWho.Items.AddRange(new object[] {
            "Self Cp",
            "Self Hp",
            "Self Mp",
            "Target Cp",
            "Target Hp",
            "Target Mp",
            "Party 1 Cp",
            "Party 1 Hp",
            "Party 1 Mp",
            "Party 2 Cp",
            "Party 2 Hp",
            "Party 2 Mp",
            "Party 3 Cp",
            "Party 3 Hp",
            "Party 3 Mp",
            "Party 4 Cp",
            "Party 4 Hp",
            "Party 4 Mp",
            "Party 5 Cp",
            "Party 5 Hp",
            "Party 5 Mp",
            "Party 6 Cp",
            "Party 6 Hp",
            "Party 6 Mp",
            "Party 7 Cp",
            "Party 7 Hp",
            "Party 7 Mp",
            "Party 8 Cp",
            "Party 8 Hp",
            "Party 8 Mp"});
			this.clbWho.Location = new System.Drawing.Point(112, 8);
			this.clbWho.MultiColumn = true;
			this.clbWho.Name = "clbWho";
			this.clbWho.Size = new System.Drawing.Size(624, 94);
			this.clbWho.TabIndex = 0;
			this.clbWho.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbWho_ItemCheck);
			this.clbWho.SelectedIndexChanged += new System.EventHandler(this.clbWho_SelectedIndexChanged);
			this.clbWho.SelectedValueChanged += new System.EventHandler(this.clbWho_SelectedValueChanged);
			this.clbWho.Validated += new System.EventHandler(this.clbWho_Validated);
			// 
			// pnlScreen
			// 
			this.pnlScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlScreen.AutoScroll = true;
			this.pnlScreen.Controls.Add(this.pnlHp);
			this.pnlScreen.Controls.Add(this.picbScreen);
			this.pnlScreen.Location = new System.Drawing.Point(8, 8);
			this.pnlScreen.Name = "pnlScreen";
			this.pnlScreen.Padding = new System.Windows.Forms.Padding(8);
			this.pnlScreen.Size = new System.Drawing.Size(1080, 434);
			this.pnlScreen.TabIndex = 2;
			// 
			// pnlHp
			// 
			this.pnlHp.BackColor = System.Drawing.Color.Blue;
			this.pnlHp.Controls.Add(this.labelHp);
			this.pnlHp.ForeColor = System.Drawing.Color.Yellow;
			this.pnlHp.Location = new System.Drawing.Point(560, 96);
			this.pnlHp.Name = "pnlHp";
			this.pnlHp.Size = new System.Drawing.Size(200, 80);
			this.pnlHp.TabIndex = 3;
			this.pnlHp.Visible = false;
			// 
			// labelHp
			// 
			this.labelHp.Location = new System.Drawing.Point(80, 32);
			this.labelHp.Name = "labelHp";
			this.labelHp.Size = new System.Drawing.Size(703, 3);
			this.labelHp.TabIndex = 1;
			this.labelHp.Text = resources.GetString("labelHp.Text");
			// 
			// picbScreen
			// 
			this.picbScreen.Cursor = System.Windows.Forms.Cursors.Hand;
			this.picbScreen.Image = global::l2gamer.Properties.Resources.just_screen;
			this.picbScreen.InitialImage = null;
			this.picbScreen.Location = new System.Drawing.Point(8, 8);
			this.picbScreen.Name = "picbScreen";
			this.picbScreen.Size = new System.Drawing.Size(1109, 779);
			this.picbScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picbScreen.TabIndex = 2;
			this.picbScreen.TabStop = false;
			this.picbScreen.Click += new System.EventHandler(this.pictureBox1_Click);
			this.picbScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			// 
			// FormScreenMark
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1095, 568);
			this.Controls.Add(this.pnlScreen);
			this.Controls.Add(this.panel1);
			this.Name = "FormScreenMark";
			this.Text = "Screen mark";
			this.Load += new System.EventHandler(this.Form2_Load);
			this.panel1.ResumeLayout(false);
			this.pnlScreen.ResumeLayout(false);
			this.pnlScreen.PerformLayout();
			this.pnlHp.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picbScreen)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlScreen;
        private System.Windows.Forms.PictureBox picbScreen;
        private System.Windows.Forms.CheckedListBox clbWho;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlHp;
        private System.Windows.Forms.Label labelHp;
		private System.Windows.Forms.Button btnUpdateScreen;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.ListBox listBox1;
    }
}