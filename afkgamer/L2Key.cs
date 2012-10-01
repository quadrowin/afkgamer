using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

namespace l2gamer
{
	class L2Key
	{

		const int SW_HIDE = 0;
		const int SW_SHOW = 5;

		const int WM_KEYDOWN = 0x0100;
		const int WM_KEYUP = 0x0101;
		const int WM_CHAR = 0x0102;

		const byte VK_ALT = 18;

		/// <summary>
		/// Self instance
		/// </summary>
		protected static L2Key instance;

		[DllImport("user32.dll")]
		static extern short GetAsyncKeyState(uint vKey); 

		[DllImport ("User32.dll")]
		extern static int PostMessage (IntPtr hWnd, UInt32 msg, Int32 wParam, Int32 lParam);

		[DllImport("User32.dll")]
		extern static int SendMessage(IntPtr hWnd, UInt32 msg, Int32 wParam, Int32 lParam);

		[DllImport("shell32.dll")]
		private static extern int ShellExecute(int hWnd, string Operation, string File,
			string Parameters, string Directory, int nShowCmd);

		[DllImport("user32", SetLastError = true, CharSet = CharSet.Unicode)]
		static extern int GetKeyNameTextW(uint lParam, StringBuilder lpString,
		int nSize);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		static extern uint MapVirtualKeyW(uint uCode, uint uMapType);

		private static Random randomTimer = new Random();

		private static Dictionary<String, Thread> threads = new Dictionary<string, Thread>();
		private static Dictionary<String, EventWaitHandle> waites = new Dictionary<string, EventWaitHandle>();

		public static Dictionary<string, uint> KeyNameCodes;

		public static string CodeToKeyName(uint scancode)
		{
			scancode = MapVirtualKeyW((uint)scancode, 0) << 16;
			StringBuilder sb = new StringBuilder(260);
			GetKeyNameTextW(scancode, sb, 20);
			return sb.ToString();
		}

		public void emulatePostMessage(IntPtr hWnd, int key)
		{
			if (GetAsyncKeyState(VK_ALT) < 0)
			{
				return;
			}

			PostMessage(hWnd, WM_KEYDOWN, key, 0);
			PostMessage(hWnd, WM_KEYUP, key, 0);
		}

		public void emulateShellExecute(IntPtr hWnd, int key)
		{
			String keyString = hWnd.ToString() + " " + Convert.ToString(key);

			if (!waites.ContainsKey(keyString))
			{
				EventWaitHandle wh = new AutoResetEvent(false);

				System.Threading.Thread thread = new System.Threading.Thread(delegate()
				{
					ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("key.exe");
					myProcessStartInfo.UseShellExecute = false;
					myProcessStartInfo.Arguments = keyString;
					myProcessStartInfo.CreateNoWindow = true;

					Process myProcess = new Process();
					myProcess.StartInfo = myProcessStartInfo;

					bool finish = false;

					while (!finish)
					{
						// start key.exe
						myProcess.Start();
						myProcess.WaitForExit();
						myProcess.Close();
						// wait for next signal
						if (!waites[keyString].WaitOne(1000 * 60 * 30))
						{
							// remove thread after 30 minutes of anactivity
							lock (waites)
							{
								threads.Remove(keyString);
								waites.Remove(keyString);
								finish =  true;
							}
						}
					}

					//ShellExecute(0, "open", "key.exe", keyString, "", SW_HIDE);
					//threads.Remove(keyString);
				});

				EventWaitHandle wait = new AutoResetEvent(false);
				threads.Add(keyString, thread);
				waites.Add(keyString, wait);

				thread.IsBackground = true;
				thread.Start();
			}
			else
			{
				waites[keyString].Set();
			}
		}

		public void Emulate(IntPtr hWnd, int key)
		{
			string methodName = "emulate" + L2gConfig.getInstance().ClickType;

			MethodInfo mi = this.GetType().GetMethod(methodName);

			object[] parametersArray = new object[] { hWnd, key };
			mi.Invoke(this, parametersArray);
			//emulateShellExecute(hWnd, key);
		}

		public static L2Key getInstance()
		{
			if (null == instance)
			{
				instance = new L2Key();
			}
			return instance;
		}

		public static uint KeyNameToCode(string code)
		{
			if (KeyNameCodes == null)
			{
				KeyNameCodes = new Dictionary<string, uint>();
				for (uint i = 1; i < 255; ++i)
				{
					KeyNameCodes[CodeToKeyName(i)] = i;
				}
			}

			return KeyNameCodes[code];
		}

	}
}

