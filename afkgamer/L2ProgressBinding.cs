using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace l2gamer
{
	public class L2ProgressBinding
	{

		private CheckBox checkBox;

		private NumericUpDown nudTop;

		private GameWindow window;

		private bool active = false;

		public bool Active
		{
			get { return active; }
			set {
				active = value;
				if (checkBox != null && checkBox.Checked != value)
				{
					checkBox.Checked = value;
				}
			}
		}

		public float [] Border = {50, 80};

		public DateTime LastUsedTime = DateTime.Now;

		public L2KeyEmulating [] Keys = new L2KeyEmulating [3];

		public L2ProgressBinding (GameWindow window, CheckBox activeCheckBox, TextBox key1, TextBox key2 = null, TextBox key3 = null)
		{
			this.window = window;
			this.BindActiveCheckBox (activeCheckBox);
			this.SetKey (0, key1);
			if (key2 != null)
			{
				this.SetKey (1, key2);
			}
			if (key3 != null)
			{
				this.SetKey (2, key3);
			}
		}

		public void checkBox_CheckedChanged (object sender, EventArgs e)
		{
			active = checkBox.Checked;
		}

		public void nudTop_ValueChanged (object sender, EventArgs e)
		{
			Border [1] = (int) nudTop.Value;
		}

		public void PushKeys ()
		{
			foreach (L2KeyEmulating key in Keys)
			{
				if (key != null)
				{
					key.PushSingle ();
				}
			}
		}

		public void BindActiveCheckBox (CheckBox checkBox)
		{
			this.checkBox = checkBox;
			checkBox.CheckedChanged += this.checkBox_CheckedChanged;
			this.active = checkBox.Checked;
		}

		public L2ProgressBinding SetBorder (int min, int max)
		{
			Border [0] = min;
			Border [1] = max;
			return this;
		}

		public L2ProgressBinding SetBorder (int min, NumericUpDown nud)
		{
			Border [0] = min;
			Border [1] = (int) nud.Value;
			nudTop = nud;
			nud.ValueChanged += this.nudTop_ValueChanged;
			return this;
		}

		public void SetKey (int index, TextBox textBox)
		{
			if (Keys [index] == null)
			{
				Keys [index] = new L2KeyEmulating (window, textBox);
			}
		}

		public virtual void UpdateState (float state)
		{
			if (Border [0] < Border [1])
			{
				if (Border [0] < state && state < Border [1])
				{
					PushKeys ();
				}
			}
			else
			{
				if (state < Border [1] || Border [0] < state)
				{
					PushKeys ();
				}
			}
		}

	}
}
