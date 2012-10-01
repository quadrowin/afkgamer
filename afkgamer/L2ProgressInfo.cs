using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace l2gamer
{
    public class L2ProgressInfo
    {

        public int Type;
        public int X1 = 999999;
        public int X2 = 0;
        public int Y1 = 999999;
        public int Y2 = 0;

		public Color HpColor = Color.DarkRed;

		private float hp = 0;

		public float Hp
		{
			get { return hp; }
			set
			{
				hp = value;
				if (StateLabel != null)
				{
					if (StateLabel.InvokeRequired)
					{
						StateLabel.Invoke (new MethodInvoker (
							delegate ()
							{
								StateLabel.Text = hp.ToString ();
							}
						));
					}
					else
					{
						StateLabel.Text = hp.ToString ();
					}
				}
				foreach (L2ProgressBinding binding in Bindings)
				{
					if (binding.Active)
					{
						binding.UpdateState (value);
					}
				}
			}
		}

		public Control StateLabel;

		public GameWindow Window;

		public List<L2ProgressBinding> Bindings = new List<L2ProgressBinding> ();

        public L2ProgressInfo (int type, GameWindow window)
        {
			this.Window = window;
            this.Type = type;
        }
        
        public bool IsEmpty ()
        {
            return (X1 >= X2);
        }

		public bool IsHpColor (Color AColor)
		{
			return
			  (
				  Math.Abs (AColor.R - HpColor.R) < 20 &&
				  Math.Abs (AColor.G - HpColor.G) < 20 &&
				  Math.Abs (AColor.B - HpColor.B) < 20
			  );
		}

        public void Extend(int x1, int x2, int y)
        {
            this.X1 = Math.Min(this.X1, Math.Min(x1, x2));
            this.X2 = Math.Max(this.X2, Math.Max(x1, x2));

            this.Y1 = Math.Min(this.Y1, y);
            this.Y2 = Math.Max(this.Y2, y);

            if (this.Y2 - this.Y1 < 3)
            {
                this.Y1--;
                this.Y2++;
            }
        }

        public void Clear()
        {
            X1 = 999999;
            X2 = 0;
            Y1 = 999999;
            Y2 = 0;
        }

    }
}
