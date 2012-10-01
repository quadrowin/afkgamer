using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace l2gamer
{
	public partial class KeyTimerPanel : UserControl
	{

		private KeyTimer keyTimer;

		public static KeyTimerPanel CreatePanel(KeyTimer Item)
		{
			KeyTimerPanel panel = new KeyTimerPanel();
			panel.Parent = Item.ParentPanel.Controls.Find("pnlAutoKeys", false)[0];
			panel.keyTimer = Item;
			return panel;
		}

		public KeyTimerPanel()
		{
			InitializeComponent();
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			keyTimer.Interval = (int)nudInterval.Value;
		}

		public void SetKey(uint scancode)
		{
			tbKey.Text = L2Key.CodeToKeyName(scancode);
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			keyTimer.Key = (int)e.KeyCode;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		public Label TimeDisplay
		{
			get { 
				return null;
				//return this.lbTimeDisplay; 
			}
		}

		public void TimeDisplayUpdate(int milisecs, int interval)
		{
			float part = (float)(milisecs % interval) / interval;
			progressBar1.Value = (int)(100 * part);
			//ProgressBar.Value = (int)(100 * part);
			
			//lbTimeDisplay.Text =
			//	(milisecs / 1000) + "/" + (interval / 1000) + " s";
		}

		private void cbActive_CheckedChanged(object sender, EventArgs e)
		{
			keyTimer.Active = cbActive.Checked;
		}

		private void cbActive_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				L2Key.getInstance().Emulate(keyTimer.HWnd, keyTimer.Key);
			}
		}

	}
}
