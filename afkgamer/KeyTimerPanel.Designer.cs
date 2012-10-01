namespace l2gamer
{
	partial class KeyTimerPanel
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.nudInterval = new System.Windows.Forms.NumericUpDown();
			this.tbKey = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbActive = new System.Windows.Forms.CheckBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
			this.SuspendLayout();
			// 
			// nudInterval
			// 
			this.nudInterval.Location = new System.Drawing.Point(153, 0);
			this.nudInterval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudInterval.Name = "nudInterval";
			this.nudInterval.Size = new System.Drawing.Size(64, 20);
			this.nudInterval.TabIndex = 10;
			this.nudInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudInterval.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// tbKey
			// 
			this.tbKey.Location = new System.Drawing.Point(55, 0);
			this.tbKey.Name = "tbKey";
			this.tbKey.ReadOnly = true;
			this.tbKey.Size = new System.Drawing.Size(56, 20);
			this.tbKey.TabIndex = 9;
			this.tbKey.Text = "F1";
			this.tbKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(117, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Time";
			// 
			// cbActive
			// 
			this.cbActive.Location = new System.Drawing.Point(5, 1);
			this.cbActive.Name = "cbActive";
			this.cbActive.Size = new System.Drawing.Size(44, 17);
			this.cbActive.TabIndex = 7;
			this.cbActive.Text = "Key";
			this.cbActive.UseVisualStyleBackColor = true;
			this.cbActive.CheckedChanged += new System.EventHandler(this.cbActive_CheckedChanged);
			this.cbActive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbActive_MouseDown);
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(223, 0);
			this.progressBar1.MarqueeAnimationSpeed = 10;
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(116, 20);
			this.progressBar1.Step = 1;
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar1.TabIndex = 11;
			// 
			// KeyTimerPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.nudInterval);
			this.Controls.Add(this.tbKey);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbActive);
			this.DoubleBuffered = true;
			this.Name = "KeyTimerPanel";
			this.Size = new System.Drawing.Size(342, 29);
			((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown nudInterval;
		private System.Windows.Forms.TextBox tbKey;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox cbActive;
		private System.Windows.Forms.ProgressBar progressBar1;


	}
}
