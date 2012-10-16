using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace DetectionTest
{
	public partial class MainForm : Form
	{

		private Bitmap sourceImage;

		public MainForm()
		{
			InitializeComponent();
			sourceImage = (Bitmap) pbScreen.Image.Clone();
		}

		private void btnScan_Click(object sender, EventArgs e)
		{
			// reset image
			pbScreen.Image = sourceImage;

			MaskItem[] masks = new MaskItem[1];
			masks[0] = new MaskItem();
			masks[0].Image = new Bitmap(imageList1.Images[0]);

			ArrayList detected = new ArrayList();

			DetectionService ds = new DetectionService();
			ds.Detect(new Bitmap(pbScreen.Image), masks, detected);

			Graphics gr = Graphics.FromImage(pbScreen.Image);
			Pen borderPen = new Pen(Color.Red, 1);

			foreach (DetectedItem item in detected)
			{
				gr.DrawImage(
					item.Mask.Image, 
					new Point(item.X, item.Y)
				);
				gr.DrawRectangle(borderPen, item.Rect);
			}

			gr.Dispose();
		}
	}
}
