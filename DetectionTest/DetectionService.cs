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
		/// Поиск изображений на карте
		/// </summary>
		/// <param name="map">Карта</param>
		/// <param name="masks">Искомые изображения</param>
		/// <param name="detected">Результат поиска</param>
		public void Detect(Bitmap map, MaskItem[] masks, ArrayList detected)
		{
			for (int y = 0; y < map.Height; ++y)
			{
				for (int x = 0; x < map.Width; ++x)
				{
					foreach (MaskItem mask in masks)
					{

					}
				}
			}

			DetectedItem sample = new DetectedItem();
			sample.Mask = masks[0];
			sample.X = 100;
			sample.Y = 150;

			detected.Add(sample);
		}

	}
}
