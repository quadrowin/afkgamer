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

        /// <summary>
        /// Исходное изображение для поиска
        /// </summary>
        private Bitmap sourceImage;        

        /// <summary>
        /// Сервис преобразования изображений
        /// </summary>
        private BitmapConvertor bitmapConvertor;

        /// <summary>
        /// Сервис распознания образов
        /// </summary>
        private DetectionService detectionService;

        private Dictionary<int, Dictionary<Color, int>> verticalColors = new Dictionary<int, Dictionary<Color, int>>();

        private Dictionary<int, Dictionary<Color, int>> horizontalColors = new Dictionary<int, Dictionary<Color, int>>();

		public MainForm()
		{
			InitializeComponent();
			sourceImage = (Bitmap) pbScreen.Image.Clone();
            detectionService = new DetectionService();
            bitmapConvertor = new BitmapConvertor();
		}

		private void btnLoadScreen_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
                sourceImage = new Bitmap(Image.FromFile(openFileDialog1.FileName));
				pbScreen.Image = sourceImage;
			}
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            // reset image
            pbScreen.Image = sourceImage;

            var masks = new ArrayList();

            for (var i = 0; i < tcMasks.TabPages.Count; ++i)
            {
                PictureBox pb = (PictureBox)tcMasks.TabPages[i].Controls[0];
                var mask = new MaskItem();
                mask.Image = bitmapConvertor.RoundImage(new Bitmap(pb.Image));
                mask.CalculateColors();
                mask.Name = i.ToString();
                masks.Add(mask);
            }

            var detected = new ArrayList();

            detectionService.Detect(
                bitmapConvertor.ImageToMatrix(new Bitmap(pbScreen.Image)), 
                masks, 
                detected
            );

            using (Graphics gr = Graphics.FromImage(pbScreen.Image)) 
            {
                Pen borderPen = new Pen(Color.Red, 1);

                foreach (DetectedItem item in detected)
                {
                    gr.DrawImage(
                        item.Mask.Image,
                        new Point(item.X, item.Y)
                    );
                    gr.DrawRectangle(borderPen, item.Rect);
                }
            }
        }

        private void tcMasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvColors.Items.Clear();

            int i = tcMasks.SelectedIndex;
            var colors = new Dictionary<Color, int>();

            PictureBox pb = (PictureBox)tcMasks.SelectedTab.Controls[0];
            Bitmap bmp = new Bitmap(pb.Image);

            for (var x = 0; x < bmp.Width; ++x)
            {
                for (var y = 0; y < bmp.Height; ++y)
                {
                    Color c = bmp.GetPixel(x, y);
                    if (colors.ContainsKey(c))
                    {
                        colors[c]++;
                    }
                    else
                    {
                        colors.Add(c, 1);
                    }
                }
            }

            var items = from pair in colors
                        orderby pair.Value descending
                        select pair;

            // Display results.
            foreach (KeyValuePair<Color, int> pair in items)
            {
                ListViewItem item = lvColors.Items.Add(pair.Key.ToString().Substring(13));
                item.SubItems.Add(pair.Value.ToString(), Color.Green, pair.Key, null);
            }
        }

        private void pbScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            Color selectedColor = sourceImage.GetPixel(e.X, e.Y);

            if (verticalColors.Count() == 0)
            {
                Bitmap bmp = new Bitmap(sourceImage);

                detectionService.CalculateImageAxes(new BitmapDecorator(bmp), horizontalColors, verticalColors);
            }

            lvHorizontalColors.Items.Clear();
            var colors = from pair in horizontalColors[e.X]
                         orderby pair.Value descending
                         select pair;
            foreach (var color in colors)
            {
                ListViewItem item = lvHorizontalColors.Items.Add(color.Key.ToString().Substring(13));
                item.SubItems.Add(color.Value.ToString());
                if (color.Key.Equals(selectedColor))
                {
                    lbHorizontalCount.Text = color.Value.ToString();
                }
            }
            
            lvVerticalColors.Items.Clear();
            colors = from pair in verticalColors[e.Y]
                     orderby pair.Value descending
                     select pair;
            foreach (var color in colors)
            {
                ListViewItem item = lvVerticalColors.Items.Add(color.Key.ToString().Substring(13));
                item.SubItems.Add(color.Value.ToString());
                if (color.Key.Equals(selectedColor))
                {
                    lbVerticalCount.Text = color.Value.ToString();
                }
            }
        }

        private void tpBw_Enter(object sender, EventArgs e)
        {
            pbBw.Image = bitmapConvertor.RoundImage(sourceImage);
        }
	}
}
