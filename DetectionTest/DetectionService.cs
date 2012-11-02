using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;

namespace DetectionTest
{
	class DetectionService
	{

        /// <summary>
        /// Подсчет количества цветов по горизонтали и вертикали.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="horizontal"></param>
        /// <param name="vertical"></param>
        public void CalculateArrayAxes(int[,] map, Dictionary<int, Dictionary<int, int>> horizontal, Dictionary<int, Dictionary<int, int>> vertical)
        {
            for (var x = 0; x < map.GetLength(0); ++x)
            {
                horizontal.Add(x, new Dictionary<int, int>());
                for (var y = 0; y < map.GetLength(1); ++y)
                {
                    if (x == 0)
                    {
                        vertical.Add(y, new Dictionary<int, int>());
                    }

                    var c = map[x, y];

                    if (horizontal[x].ContainsKey(c))
                    {
                        horizontal[x][c]++;
                    }
                    else
                    {
                        horizontal[x].Add(c, 1);
                    }

                    if (vertical[y].ContainsKey(c))
                    {
                        vertical[y][c]++;
                    }
                    else
                    {
                        vertical[y].Add(c, 1);
                    }
                }
            }
        }

        /// <summary>
        /// Подсчет количества цветов по горизонтали и вертикали.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="horizontal"></param>
        /// <param name="vertical"></param>
        public void CalculateImageAxes(BitmapDecorator map, Dictionary<int, Dictionary<Color, int>> horizontal, Dictionary<int, Dictionary<Color, int>> vertical)
        {
            for (var y = 0; y < map.Bitmap.Height; ++y)
            {
                vertical.Add(y, new Dictionary<Color, int>());
                for (var x = 0; x < map.Bitmap.Width; ++x)
                {
                    if (y == 0)
                    {
                        horizontal.Add(x, new Dictionary<Color, int>());
                    }

                    var c = map.GetPixel(x, y);

                    if (horizontal[x].ContainsKey(c))
                    {
                        horizontal[x][c]++;
                    }
                    else
                    {
                        horizontal[x].Add(c, 1);
                    }

                    if (vertical[y].ContainsKey(c))
                    {
                        vertical[y][c]++;
                    }
                    else
                    {
                        vertical[y].Add(c, 1);
                    }
                }
            }
        }

		/// <summary>
		/// Поиск изображений на карте
		/// </summary>
		/// <param name="map">Карта</param>
		/// <param name="masks">Искомые изображения</param>
		/// <param name="detected">Результат поиска</param>
		public void Detect(int[,] map, ArrayList masks, ArrayList detected)
		{
			var horizontalColors = new Dictionary<int, Dictionary<int, int>>();
			var verticalColors = new Dictionary<int, Dictionary<int, int>>();

            CalculateArrayAxes(map, horizontalColors, verticalColors);

            // Теперь сравниваем с каждой маской
            foreach (MaskItem mask in masks)
            {
                int ySimilarity = 0;
			    for (int y = 30; y < map.GetLength(1) - 100; ++y)
			    {
                    if (
                        verticalColors[y].ContainsKey(mask.MaxColorValue) 
                        && verticalColors[y][mask.MaxColorValue] >= 2
                    )
                    {
                        ySimilarity++;
                        Console.WriteLine(String.Format("Y {0,4} {1,4} {2}", y, ySimilarity, mask.Name));
                        if (ySimilarity >= mask.Height)
                        {
                            int xSimilarity = 0;
                            for (int x = 100; x < map.GetLength(0) - 100; ++x)
                            {
                                Console.WriteLine(String.Format("{0,4} {1,4} {2}", x, y, mask.Name));
                                if (
                                    horizontalColors[x].ContainsKey(mask.MaxColorValue)
                                    && horizontalColors[x][mask.MaxColorValue] >= 2
                                ) {
                                    xSimilarity++;

                                    if (xSimilarity >= mask.Width)
                                    {
                                        if (TestBlock(map, mask, detected, x - mask.Width, y - mask.Height))
                                        {
                                            DetectedItem detectedItem = new DetectedItem();
                                            detectedItem.Mask = mask;
                                            detectedItem.X = x - mask.Width;
                                            detectedItem.Y = y - mask.Height;
                                            detected.Add(detectedItem);
                                            Console.WriteLine("Detected: " + mask.Name);

                                            if (detected.Count > 10)
                                            {
                                                Console.WriteLine("Max detected mask reached.");
                                                return;
                                            }

                                            x += mask.Width;
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    xSimilarity = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        ySimilarity = 0;
                    }
				}
			}

            //DetectedItem sample = new DetectedItem();
            //sample.Mask = (MaskItem)masks[0];
            //sample.X = 100;
            //sample.Y = 150;

            //detected.Add(sample);
		}

        /// <summary>
        /// Поиск изображений на карте
        /// </summary>
        /// <param name="map">Карта</param>
        /// <param name="masks">Искомые изображения</param>
        /// <param name="detected">Результат поиска</param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        public bool TestBlock(int[,] map, MaskItem mask, ArrayList detected, int startX, int startY)
        {
            var similarity = 0;

            // similarity / (size.X * size.Y) >= 0.8
            // similarity >= 0.8 * size.X * size.Y

            var minSimilarityX = 0.4 * mask.Width;

            for (int y = 0; y < mask.Height; ++y)
            {
                // Первый блок строки
                for (int x = 0; x < mask.Width; ++x)
                {
                    if (map[startX + x, startY + y] == mask.Map[x, y])
                    {
                        similarity++;
                    }
                }

                if (similarity < Math.Max(2, minSimilarityX * y))
                {
                    return false;
                }
            }

            return similarity >= minSimilarityX * mask.Height;
        }

	}
}
