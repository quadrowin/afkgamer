using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace l2gamer
{
	public class L2KeyEmulating
	{

		private GameWindow window;

		private int code = 0;

		private TextBox textBox;

		public Dictionary<String, L2KeyEmulating> TextBoxKeys;

		public GameWindow Window { get { return window; } }

		private void textBox_KeyDown(object sender, KeyEventArgs e)
		{
			textBox.Text = L2Key.CodeToKeyName((uint)e.KeyCode);
			code = (int)e.KeyCode;
		}

		public L2KeyEmulating(GameWindow window, TextBox textBox)
		{
			TextBoxKeys = new Dictionary<String, L2KeyEmulating>();
			this.window = window;
			this.textBox = textBox;
			textBox.KeyDown += textBox_KeyDown;

			TextBoxKeys.Add(textBox.Name, this);
		}

		/// <summary>
		/// Помещает клавиши в очередь для окна
		/// </summary>
		public void Push()
		{
			window.AutoKeys.KeysQueue.Enqueue(this);
		}

		/// <summary>
		/// Помещает клавишу в очередь только в случае, если ее еще там нет.
		/// </summary>
		public void PushSingle()
		{
			foreach (L2KeyEmulating key in window.AutoKeys.KeysQueue)
			{
				if (key.code == code)
				{
					return;
				}
			}
			Push();
		}

		public void Emulate()
		{
			L2Key.getInstance().Emulate(window.HWnd, code);
		}

	}
}
