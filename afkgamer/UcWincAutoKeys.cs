using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace l2gamer
{
	public partial class UcAutoKeys : UserControl
	{

		private MdlAutoKeys aks;

		public MdlAutoKeys Aks
		{
			get { return aks; }
		}

		public UcAutoKeys(MdlAutoKeys aks)
		{
			InitializeComponent();
			this.aks = aks;
			Left = 0;
			Top = 0;
			Width = 400;
			Height = 600;
		}

		private void btnAddKey_Click(object sender, EventArgs e)
		{
			aks.Add();
		}
	}
}
