using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace key
{

	class Program
	{

		const int WM_KEYDOWN = 0x0100;
		const int WM_CHAR = 0x0102;
		const int WM_KEYUP = 0x0101;

		const byte VK_ALT = 18;

		const int KEY_A = 'A';
		const int KEY_Z = 'Z';

		const int KEY_0 = '0';
		const int KEY_9 = '9';

		[DllImport("user32.dll")]
		static extern short GetAsyncKeyState(uint vKey); 

		[DllImport("user32.dll")]
		extern static int PostMessage(IntPtr hWnd, UInt32 msg, Int32 wParam, Int32 lParam);

		[DllImport("user32.dll")]
		static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

		[DllImport("user32.dll")]
		static extern byte MapVirtualKey(byte wCode, int wMap); 

		/// <summary>
		/// Emulating key press
		/// </summary>
		/// <param name="hWnd">Хендл окна</param>
		/// <param name="key">Код клавиши</param>
		public static void Emulate(IntPtr hWnd, int key)
		{
			if (GetAsyncKeyState(VK_ALT) < 0)
			{
				return;
			}

			PostMessage(hWnd, WM_KEYDOWN, key, 0);
			PostMessage(hWnd, WM_KEYUP, key, 0);
		}

		static void Main(string[] args)
		{
			// emulate
			IntPtr hwnd = new IntPtr(Convert.ToInt32(args[0]));
			int key = Convert.ToInt32(args[1]);
			Emulate(hwnd, key);
		}

		/// <summary>
		/// Должно отжимать ALT перед нажатием клавиши.
		/// Не работает.
		/// </summary>
		/// <param name="hWnd"></param>
		public static void UnpressAlt(IntPtr hWnd)
		{
			if (GetAsyncKeyState(VK_ALT) < 0)
			{
				const int KEYEVENTF_EXTENDEDKEY = 0x1;
				const int KEYEVENTF_KEYUP = 0x2;
				byte vk = MapVirtualKey(18, 0);
				keybd_event(VK_ALT, vk, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
				keybd_event(VK_ALT, vk, KEYEVENTF_KEYUP, 0);
				//PostMessage(hWnd, WM_KEYUP, 0x20000033, 0);
			}
		}

	}

}
