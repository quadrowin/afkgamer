using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DetectionTest
{
    class BitmapConvertor
    {

        protected int rate = 50;

        /// <summary>
        /// Округляет цвет
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public Color RoundColor(Color color)
        {
            return Color.FromArgb(
                Math.Min(255, rate * (int)Math.Round((double)color.R / rate)),
                Math.Min(255, rate * (int)Math.Round((double)color.G / rate)),
                Math.Min(255, rate * (int)Math.Round((double)color.B / rate))
            );
        }

        /// <summary>
        /// Округляет изображение
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public Bitmap RoundImage(Bitmap bmp)
        {
            Bitmap result = new Bitmap(bmp.Width, bmp.Height);

            for (var x = 0; x < bmp.Width; x++)
            {
                for (var y = 0; y < bmp.Height; y++)
                {
                    result.SetPixel(x, y, RoundColor(bmp.GetPixel(x, y)));
                }
            }

            return result;
        }

        /// <summary>
        /// Округляет изображение и переносит в матрицу
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public int[,] ImageToMatrix(Bitmap bmp)
        {
            int[,] result = new int[bmp.Width, bmp.Height];

            for (var x = 0; x < bmp.Width; x++)
            {
                for (var y = 0; y < bmp.Height; y++)
                {
                    result[x, y] = RoundColor(bmp.GetPixel(x, y)).ToArgb();
                }
            }

            return result;
        }

    }
}
