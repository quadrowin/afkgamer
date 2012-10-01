using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace l2gamer
{
	public class KeyTimer
	{

		private DateTime startTime;

		private bool active = false;

		public bool Active
		{
			get { return active; }
			set
			{
				if (cbActive.Checked != value)
				{
					cbActive.Checked = value;
				}
				else
				{
					active = value;
					if (value)
					{
						startTime = DateTime.Now;
						iteration = 0;
					}
				}
			}
		}


		private int index;

		private int interval = 1;

		private int iteration;

		private KeyTimerPanel panel;

		private Control parentPanel;

		private TextBox tbKey;

		private NumericUpDown nudInterval;

		private CheckBox cbActive;

		private int key = 0;

		public IntPtr HWnd { 
			get; 
			set; 
		}

		public int Index
		{
			get { return index; }
		}

		public int Interval
		{
			get { return interval; }
			set
			{
				if (nudInterval.Value != value)
				{
					nudInterval.Value = value;
				}
				else
				{
					interval = value;
					panel.TimeDisplayUpdate(0, interval);
				}
			}
		}

		public KeyTimer(Control parent, int index)
		{
			parentPanel = parent;
			panel = KeyTimerPanel.CreatePanel(this);
			panel.Top = index * (panel.Height + 2);
			panel.Width = parent.Width - 20;
			this.index = index;
			// находим элементы
			tbKey = panel.Controls.Find("tbKey", true).First() as TextBox;
			nudInterval = panel.Controls.Find("nudInterval", true).First() as NumericUpDown;
			cbActive = panel.Controls.Find("cbActive", true).First() as CheckBox;

			Key = (int)L2Key.KeyNameToCode(tbKey.Text);
			Interval = int.Parse(nudInterval.Value.ToString());
		}

		public void CheckTime()
		{
			TimeSpan span = DateTime.Now - startTime;
			int miliSeconds = (int)span.TotalMilliseconds;

			while (miliSeconds < 0)
			{
				// Выход за границы диапазона
				startTime = startTime.AddDays(7);
				span = DateTime.Now - startTime;
				miliSeconds = (int)span.TotalMilliseconds;
			}

			int miliInterval = interval * 1000;
			int cnt = miliSeconds / miliInterval + 1;
			panel.TimeDisplayUpdate(miliSeconds, miliInterval);
			if (cnt > iteration)
			{
				iteration = cnt;
				L2Key.getInstance().Emulate(HWnd, key);
			}
		}

		public KeyTimerPanel Panel
		{
			get { return panel; }
		}

		public Control ParentPanel
		{
			get { return parentPanel; }
		}

		public int Key
		{
			get { return key; }

			set
			{
				key = value;
				panel.SetKey((uint)key);
			}
		}

		public DateTime StartTime
		{
			get { return startTime; }
			set { startTime = value; }
		}

	}
}
