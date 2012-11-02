using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
namespace DetectionTest
{
	public class BitmapDecorator : IDisposable
	{
		private readonly Bitmap _bitmap;
		private readonly bool _isAlpha;
		private readonly int _width;
		private readonly int _height;
		private BitmapData _bmpData;
		private IntPtr _bmpPtr;
		private byte[] _rgbValues;
		private int index;
		private int b;
		private int r;
		private int g;
		private int a;
		private int r1;
		private int g1;
		private int b1;
		private int a1;

		public BitmapDecorator (Bitmap bitmap)
		{
			if (bitmap == null)
				throw new ArgumentNullException ();
			_bitmap = bitmap;
			if (_bitmap.PixelFormat == (PixelFormat.Indexed | _bitmap.PixelFormat))
				throw new ArgumentException ("Can't work with indexed pixel format");
			_isAlpha = (Bitmap.PixelFormat == (Bitmap.PixelFormat | PixelFormat.Alpha));
			_width = bitmap.Width;
			_height = bitmap.Height;
			Lock ();
		}
		#region properties
		public Bitmap Bitmap
		{
			get { return _bitmap; }
		}
		#endregion
		#region methods
		private void Lock ()
		{
			Rectangle rect = new Rectangle (0, 0, _width, _height);
			_bmpData = Bitmap.LockBits (rect, ImageLockMode.ReadWrite, Bitmap.PixelFormat);
			_bmpPtr = _bmpData.Scan0;
			int bytes = _width * _height * (_isAlpha ? 4 : 3);
			_rgbValues = new byte [bytes];
			Marshal.Copy (_bmpPtr, _rgbValues, 0, _rgbValues.Length);
		}
		private void UnLock ()
		{
			// Copy the RGB values back to the bitmap
			Marshal.Copy (_rgbValues, 0, _bmpPtr, _rgbValues.Length);
			// Unlock the bits.
			Bitmap.UnlockBits (_bmpData);
		}
		public void SetPixel (int x, int y, int r, int g, int b)
		{
			if (_isAlpha)
			{
				index = ((y * _width + x) * 4);
				_rgbValues [index] = (byte) b;
				_rgbValues [index + 1] = (byte) g;
				_rgbValues [index + 2] = (byte) g;
				_rgbValues [index + 3] = 255;
			}
			else
			{
				index = ((y * _width + x) * 3);
				_rgbValues [index] = (byte) b;
				_rgbValues [index + 1] = (byte) g;
				_rgbValues [index + 2] = (byte) r;
			}
		}
		public void SetPixel (int x, int y, Color color)
		{
			if (_isAlpha)
			{
				index = ((y * _width + x) * 4);
				_rgbValues [index] = color.B;
				_rgbValues [index + 1] = color.G;
				_rgbValues [index + 2] = color.R;
				_rgbValues [index + 3] = color.A;
			}
			else
			{
				index = ((y * _width + x) * 3);
				_rgbValues [index] = color.B;
				_rgbValues [index + 1] = color.G;
				_rgbValues [index + 2] = color.R;
			}
		}
		public void SetPixel (Point point, Color color)
		{
			if (_isAlpha)
			{
				index = ((point.Y * _width + point.X) * 4);
				_rgbValues [index] = color.B;
				_rgbValues [index + 1] = color.G;
				_rgbValues [index + 2] = color.R;
				_rgbValues [index + 3] = color.A;
			}
			else
			{
				index = ((point.Y * _width + point.X) * 3);
				_rgbValues [index] = color.B;
				_rgbValues [index + 1] = color.G;
				_rgbValues [index + 2] = color.R;
			}
		}
		public Color GetPixel (int x, int y)
		{
			if (x > _width - 1 || y > _height - 1)
				return Color.Green;
			if (_isAlpha)
			{
				index = ((y * _width + x) * 4);
				b = _rgbValues [index];
				g = _rgbValues [index + 1];
				r = _rgbValues [index + 2];
				a = _rgbValues [index + 3];
				return Color.FromArgb (a, r, g, b);
			}
			else
			{
				index = ((y * _width + x) * 3);
				b = _rgbValues [index];
				g = _rgbValues [index + 1];
				r = _rgbValues [index + 2];
				return Color.FromArgb (r, g, b);
			}
		}
		public int ColorDiff (int x1, int y1, int x2, int y2)
		{
			if (_isAlpha)
			{
				index = ((y1 * _width + x1) * 4);
				b = _rgbValues [index];
				g = _rgbValues [index + 1];
				r = _rgbValues [index + 2];
				a = _rgbValues [index + 3];
			}
			else
			{
				index = ((y1 * _width + x1) * 3);
				b = _rgbValues [index];
				g = _rgbValues [index + 1];
				r = _rgbValues [index + 2];
			}
			if (_isAlpha)
			{
				index = ((y2 * _width + x2) * 4);
				b1 = _rgbValues [index];
				g1 = _rgbValues [index + 1];
				r1 = _rgbValues [index + 2];
				a1 = _rgbValues [index + 3];
			}
			else
			{
				index = ((y2 * _width + x2) * 3);
				b1 = _rgbValues [index];
				g1 = _rgbValues [index + 1];
				r1 = _rgbValues [index + 2];
			}
			r = r1 - r;
			g = g1 - g;
			b = b1 - b;
			if (r < 0)
				r = -r;
			if (g < 0)
				g = -g;
			if (b < 0)
				b = -b;
			return r + g + b;
		}
		public int ColorDiff (int i1, int i2)
		{
			if (_isAlpha)
			{
				index = ((i1) * 4);
				b = _rgbValues [index];
				g = _rgbValues [index + 1];
				r = _rgbValues [index + 2];
				a = _rgbValues [index + 3];
			}
			else
			{
				index = ((i1) * 3);
				b = _rgbValues [index];
				g = _rgbValues [index + 1];
				r = _rgbValues [index + 2];
			}
			if (_isAlpha)
			{
				index = ((i2) * 4);
				b1 = _rgbValues [index];
				g1 = _rgbValues [index + 1];
				r1 = _rgbValues [index + 2];
				a1 = _rgbValues [index + 3];
			}
			else
			{
				index = ((i2) * 3);
				b1 = _rgbValues [index];
				g1 = _rgbValues [index + 1];
				r1 = _rgbValues [index + 2];
			}
			r = r1 - r;
			g = g1 - g;
			b = b1 - b;
			if (r < 0)
				r = -r;
			if (g < 0)
				g = -g;
			if (b < 0)
				b = -b;
			return r + g + b;
		}
		public int ColorDiff (Point point1, Point point2)
		{
			return ColorDiff (point1.X, point1.Y, point2.X, point2.Y);
		}
		public Color GetPixel (Point point)
		{
			return GetPixel (point.X, point.Y);
		}
		#region IDisposable Members
		public void Dispose ()
		{
			UnLock ();
		}
		#endregion
		#endregion
	}
}
