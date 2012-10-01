using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace l2gamer
{
	class L2ProgressBindingAfterKill : L2ProgressBinding
	{

		private float lastHp;

		public L2ProgressBindingAfterKill (GameWindow window, CheckBox activeCheckBox,
			TextBox key1, TextBox key2 = null, TextBox key3 = null) 
		: base (window, activeCheckBox, key1, key2, key3)
		{
			
		}

		public override void UpdateState (float state)
		{
			if (lastHp > 0 && state == 0)
			{
				PushKeys ();
			}
			lastHp = state;
		}

	}
}
