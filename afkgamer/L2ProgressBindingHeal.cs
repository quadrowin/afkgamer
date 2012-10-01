using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace l2gamer
{
	public class L2ProgressBindingHeal : L2ProgressBinding
	{

		public L2ProgressBindingHeal (GameWindow window, CheckBox activeCheckBox,
			TextBox key1, TextBox key2 = null, TextBox key3 = null) 
		: base (window, activeCheckBox, key1, key2, key3)
		{
			
		}

	}
}
