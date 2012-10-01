using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace l2gamer
{

	public class WindowImageCapture
	{
		/// <summary>
		/// Получение снимка окна
		/// </summary>
		/// <param name="WindowHandle">HWND окна</param>
		/// <returns>Скриншот</returns>
		public static Image CaptureWindow (IntPtr WindowHandle)
		{
			User32.RECT windowRect = new User32.RECT ();
			User32.GetWindowRect (WindowHandle, ref windowRect);
			int width = windowRect.right - windowRect.left + 1;
			int height = windowRect.bottom - windowRect.top + 1;

			User32.SetWindowPos (WindowHandle,
								(System.IntPtr) User32.HWND_TOPMOST,
								0, 0, 0, 0,
								User32.SWP_NOMOVE |
								User32.SWP_NOSIZE |
								User32.SWP_FRAMECHANGED);

			IntPtr hdcSrc = User32.GetWindowDC (WindowHandle);
			IntPtr hdcDest = GDI32.CreateCompatibleDC (hdcSrc);

			IntPtr hBitmap = GDI32.CreateCompatibleBitmap (hdcSrc,
															width,
															height);

			IntPtr hOld = GDI32.SelectObject (hdcDest, hBitmap);

			GDI32.BitBlt (hdcDest, 0, 0,
							width, height,
							hdcSrc, 0, 0,
							GDI32.SRCCOPY);

			User32.SetWindowPos (WindowHandle,
								(System.IntPtr) User32.HWND_NOTOPMOST,
								0, 0, 0, 0,
								User32.SWP_NOMOVE |
								User32.SWP_NOSIZE |
								User32.SWP_FRAMECHANGED);

			GDI32.SelectObject (hdcDest, hOld);
			GDI32.DeleteDC (hdcDest);
			User32.ReleaseDC (WindowHandle, hdcSrc);
			Image img = Image.FromHbitmap (hBitmap);
			GDI32.DeleteObject (hBitmap);
			return img;
		}

		private class User32
		{

			public const int SWP_FRAMECHANGED = 0x0020;
			public const int SWP_NOMOVE = 0x0002;
			public const int SWP_NOSIZE = 0x0001;
			public const int SWP_NOZORDER = 0x0004;
			public const int HWND_TOPMOST = -1;
			public const int HWND_NOTOPMOST = -2;

			[StructLayout (LayoutKind.Sequential)]
			public struct RECT
			{
				public int left;
				public int top;
				public int right;
				public int bottom;
			}

			[DllImport ("user32.dll")]
			public static extern IntPtr GetWindowDC (IntPtr hWnd);

			[DllImport ("user32.dll")]
			public static extern IntPtr ReleaseDC (IntPtr hWnd, IntPtr hDC);

			[DllImport ("user32.dll")]
			public static extern IntPtr GetWindowRect (IntPtr hWnd,
													  ref RECT rect);

			[DllImport ("user32.dll", SetLastError = true)]
			[return: MarshalAs (UnmanagedType.Bool)]
			public static extern bool SetWindowPos (IntPtr hWnd,
												   IntPtr hWndInsertAfter,
												   int x, int y,
												   int cx, int cy,
												   uint uFlags);
		}

		private class GDI32
		{

			public const int SRCCOPY = 0x00CC0020;

			[DllImport ("gdi32.dll")]
			public static extern bool BitBlt (IntPtr hObject,
				int nXDest, int nYDest,
				int nWidth, int nHeight, IntPtr hObjectSource,
				int nXSrc, int nYSrc, int dwRop);

			[DllImport ("gdi32.dll")]
			public static extern IntPtr CreateCompatibleBitmap (IntPtr hDC,
															   int nWidth,
															   int nHeight);

			[DllImport ("gdi32.dll")]
			public static extern IntPtr CreateCompatibleDC (IntPtr hDC);

			[DllImport ("gdi32.dll")]
			public static extern bool DeleteDC (IntPtr hDC);

			[DllImport ("gdi32.dll")]
			public static extern bool DeleteObject (IntPtr hObject);

			[DllImport ("gdi32.dll")]
			public static extern IntPtr SelectObject (IntPtr hDC,
													 IntPtr hObject);
		}
	}
}