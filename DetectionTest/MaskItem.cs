using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DetectionTest
{
	class MaskItem
	{

		public int Height
		{
			get { return Image.Height; }
		}

		/// <summary>
		/// Искомое изображение
		/// </summary>
		public Bitmap Image;

		public int Width
		{
			get { return Image.Width; }
		}

	}
}
