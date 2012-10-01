namespace l2gamer
{
	partial class UcAutoKeys
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnAddKey = new System.Windows.Forms.Button();
			this.pnlAutoKeys = new System.Windows.Forms.Panel();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.panel2.Controls.Add(this.btnAddKey);
			this.panel2.Location = new System.Drawing.Point(3, 401);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(413, 44);
			this.panel2.TabIndex = 16;
			// 
			// btnAddKey
			// 
			this.btnAddKey.Location = new System.Drawing.Point(8, 8);
			this.btnAddKey.Name = "btnAddKey";
			this.btnAddKey.Size = new System.Drawing.Size(75, 23);
			this.btnAddKey.TabIndex = 0;
			this.btnAddKey.Text = "add key";
			this.btnAddKey.UseVisualStyleBackColor = true;
			this.btnAddKey.Click += new System.EventHandler(this.btnAddKey_Click);
			// 
			// pnlAutoKeys
			// 
			this.pnlAutoKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlAutoKeys.AutoScroll = true;
			this.pnlAutoKeys.BackColor = System.Drawing.SystemColors.Control;
			this.pnlAutoKeys.Location = new System.Drawing.Point(3, 3);
			this.pnlAutoKeys.Name = "pnlAutoKeys";
			this.pnlAutoKeys.Size = new System.Drawing.Size(413, 391);
			this.pnlAutoKeys.TabIndex = 15;
			// 
			// UcAutoKeys
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.pnlAutoKeys);
			this.DoubleBuffered = true;
			this.Name = "UcAutoKeys";
			this.Size = new System.Drawing.Size(423, 447);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnAddKey;
		private System.Windows.Forms.Panel pnlAutoKeys;
	}
}
