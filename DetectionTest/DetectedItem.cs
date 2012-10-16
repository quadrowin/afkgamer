using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DetectionTest
{
	class DetectedItem
	{

		/// <summary>
		/// Обнаруженная маска
		/// </summary>
		public MaskItem Mask;

		public Rectangle Rect
		{
			get { return new Rectangle(X, Y, Mask.Width, Mask.Height); }
		}

		/// <summary>
		/// Позиция Х
		/// </summary>
		public int X;

		/// <summary>
		/// Позиция Y
		/// </summary>
		public int Y;

	}
}
