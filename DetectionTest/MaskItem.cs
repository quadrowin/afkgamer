using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DetectionTest
{
	class MaskItem
	{

		public Dictionary<Color, int> Colors
		{
			get;
			set;
		}

		public void CalculateColors()
		{
			var calculates = new Dictionary<Color, int>();
            map = new int[image.Width, image.Height];

			for (var x = 0; x < Image.Width; ++x)
			{
				for (var y = 0; y < Image.Height; ++y)
				{
					Color c = Image.GetPixel(x, y);
                    map[x, y] = c.ToArgb();
					if (calculates.ContainsKey(c))
					{
                        calculates[c]++;
					}
					else
					{
                        calculates.Add(c, 1);
					}
				}
			}

			var items = from pair in calculates
					 orderby pair.Value descending
					 select pair;

			foreach (var pair in items)
			{
				Colors.Add(pair.Key, pair.Value);
			}

			maxColor = Colors.First().Key;
            maxColorValue = maxColor.ToArgb();
		}

		public int Height
		{
			get { return Image.Height; }
		}

        protected Bitmap image;

		/// <summary>
		/// Искомое изображение
		/// </summary>
		public Bitmap Image
        {
            get { return image; }
            set {
                image = value;
            }
        }

        protected int[,] map;

        public int[,] Map
        {
            get { return map; }
        }

		public MaskItem()
		{
			Colors = new Dictionary<Color, int>();
		}

		protected Color maxColor;

		public Color MaxColor
		{
			get { return maxColor; }
		}

        protected int maxColorValue;

        public int MaxColorValue
        {
            get { return maxColorValue; }
        }

        public int MaxColorCount
        {
            get { return Colors[maxColor]; }
        }

		public String Name
		{
			get;
			set;
		}

		public int Width
		{
			get { return Image.Width; }
		}

	}
}
