using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace l2gamer
{
	[System.Security.SuppressUnmanagedCodeSecurity ()]
	internal sealed class NativeMethods
	{
		private NativeMethods () { }

		internal static bool IsWindowInForeground (IntPtr hWnd)
		{
			return hWnd == GetForegroundWindow ();
		}

		#region user32

		#region ShowWindow
		/// <summary>Shows a Window</summary>
		/// <remarks>
		/// <para>To perform certain special effects when showing or hiding a
		/// window, use AnimateWindow.</para>
		///<para>The first time an application calls ShowWindow, it should use
		///the WinMain function's nCmdShow parameter as its nCmdShow parameter.
		///Subsequent calls to ShowWindow must use one of the values in the
		///given list, instead of the one specified by the WinMain function's
		///nCmdShow parameter.</para>
		///<para>As noted in the discussion of the nCmdShow parameter, the
		///nCmdShow value is ignored in the first call to ShowWindow if the
		///program that launched the application specifies startup information
		///in the structure. In this case, ShowWindow uses the information
		///specified in the STARTUPINFO structure to show the window. On
		///subsequent calls, the application must call ShowWindow with nCmdShow
		///set to SW_SHOWDEFAULT to use the startup information provided by the
		///program that launched the application. This behavior is designed for
		///the following situations: </para>
		///<list type="">
		///    <item>Applications create their main window by calling CreateWindow
		///    with the WS_VISIBLE flag set. </item>
		///    <item>Applications create their main window by calling CreateWindow
		///    with the WS_VISIBLE flag cleared, and later call ShowWindow with the
		///    SW_SHOW flag set to make it visible.</item>
		///</list></remarks>
		/// <param name="hWnd">Handle to the window.</param>
		/// <param name="nCmdShow">Specifies how the window is to be shown.
		/// This parameter is ignored the first time an application calls
		/// ShowWindow, if the program that launched the application provides a
		/// STARTUPINFO structure. Otherwise, the first time ShowWindow is called,
		/// the value should be the value obtained by the WinMain function in its
		/// nCmdShow parameter. In subsequent calls, this parameter can be one of
		/// the WindowShowStyle members.</param>
		/// <returns>
		/// If the window was previously visible, the return value is nonzero.
		/// If the window was previously hidden, the return value is zero.
		/// </returns>
		[DllImport ("user32.dll")]
		internal static extern bool ShowWindow (IntPtr hWnd, WindowShowStyle nCmdShow);

		/// <summary>Enumeration of the different ways of showing a window using
		/// ShowWindow</summary>
		internal enum WindowShowStyle : uint
		{
			/// <summary>Hides the window and activates another window.</summary>
			/// <remarks>See SW_HIDE</remarks>
			Hide = 0,
			/// <summary>Activates and displays a window. If the window is minimized
			/// or maximized, the system restores it to its original size and
			/// position. An application should specify this flag when displaying
			/// the window for the first time.</summary>
			/// <remarks>See SW_SHOWNORMAL</remarks>
			ShowNormal = 1,
			/// <summary>Activates the window and displays it as a minimized window.</summary>
			/// <remarks>See SW_SHOWMINIMIZED</remarks>
			ShowMinimized = 2,
			/// <summary>Activates the window and displays it as a maximized window.</summary>
			/// <remarks>See SW_SHOWMAXIMIZED</remarks>
			ShowMaximized = 3,
			/// <summary>Maximizes the specified window.</summary>
			/// <remarks>See SW_MAXIMIZE</remarks>
			Maximize = 3,
			/// <summary>Displays a window in its most recent size and position.
			/// This value is similar to "ShowNormal", except the window is not
			/// actived.</summary>
			/// <remarks>See SW_SHOWNOACTIVATE</remarks>
			ShowNormalNoActivate = 4,
			/// <summary>Activates the window and displays it in its current size
			/// and position.</summary>
			/// <remarks>See SW_SHOW</remarks>
			Show = 5,
			/// <summary>Minimizes the specified window and activates the next
			/// top-level window in the Z order.</summary>
			/// <remarks>See SW_MINIMIZE</remarks>
			Minimize = 6,
			/// <summary>Displays the window as a minimized window. This value is
			/// similar to "ShowMinimized", except the window is not activated.</summary>
			/// <remarks>See SW_SHOWMINNOACTIVE</remarks>
			ShowMinNoActivate = 7,
			/// <summary>Displays the window in its current size and position. This
			/// value is similar to "Show", except the window is not activated.</summary>
			/// <remarks>See SW_SHOWNA</remarks>
			ShowNoActivate = 8,
			/// <summary>Activates and displays the window. If the window is
			/// minimized or maximized, the system restores it to its original size
			/// and position. An application should specify this flag when restoring
			/// a minimized window.</summary>
			/// <remarks>See SW_RESTORE</remarks>
			Restore = 9,
			/// <summary>Sets the show state based on the SW_ value specified in the
			/// STARTUPINFO structure passed to the CreateProcess function by the
			/// program that started the application.</summary>
			/// <remarks>See SW_SHOWDEFAULT</remarks>
			ShowDefault = 10,
			/// <summary>Windows 2000/XP: Minimizes a window, even if the thread
			/// that owns the window is hung. This flag should only be used when
			/// minimizing windows from a different thread.</summary>
			/// <remarks>See SW_FORCEMINIMIZE</remarks>
			ForceMinimized = 11
		}
		#endregion

		/// <summary>
		/// The GetForegroundWindow function returns a handle to the foreground window.
		/// </summary>
		[DllImport ("user32.dll")]
		internal static extern IntPtr GetForegroundWindow ();

		[DllImport ("user32.dll")]
		[return: MarshalAs (UnmanagedType.Bool)]
		internal static extern bool SetForegroundWindow (IntPtr hWnd);

		[DllImport ("user32.dll")]
		[return: MarshalAs (UnmanagedType.Bool)]
		internal static extern bool IsIconic (IntPtr hWnd);

		#endregion

		[DllImport ("user32.dll")]
		internal static extern bool GetClientRect (IntPtr hWnd, out RECT lpRect);

		[DllImport ("user32.dll")]
		[return: MarshalAs (UnmanagedType.Bool)]
		internal static extern bool GetWindowRect (IntPtr hWnd, out RECT lpRect);

		/// <summary>
		/// Get a windows client rectangle in a .NET structure
		/// </summary>
		/// <param name="hwnd">The window handle to look up</param>
		/// <returns>The rectangle</returns>
		internal static Rectangle GetClientRect (IntPtr hwnd)
		{
			RECT rect = new RECT ();
			GetClientRect (hwnd, out rect);
			return rect.AsRectangle;
		}

		/// <summary>
		/// Get a windows rectangle in a .NET structure
		/// </summary>
		/// <param name="hwnd">The window handle to look up</param>
		/// <returns>The rectangle</returns>
		internal static Rectangle GetWindowRect (IntPtr hwnd)
		{
			RECT rect = new RECT ();
			GetWindowRect (hwnd, out rect);
			return rect.AsRectangle;
		}

		internal static Rectangle GetAbsoluteClientRect (IntPtr hWnd)
		{
			Rectangle windowRect = NativeMethods.GetWindowRect (hWnd);
			Rectangle clientRect = NativeMethods.GetClientRect (hWnd);

			// This gives us the width of the left, right and bottom chrome - we can then determine the top height
			int chromeWidth = (int) ((windowRect.Width - clientRect.Width) / 2);

			return new Rectangle (new Point (windowRect.X + chromeWidth, windowRect.Y + (windowRect.Height - clientRect.Height - chromeWidth)), clientRect.Size);
		}

		public delegate bool EnumWindowsProc (IntPtr hWnd, IntPtr lParam);

		[DllImport ("user32.dll", SetLastError = true)]
		[return: MarshalAs (UnmanagedType.Bool)]
		public static extern bool EnumWindows (EnumWindowsProc lpEnumFunc, IntPtr lParam);

		[DllImport ("user32.dll", SetLastError = true)]
		public static extern int GetWindowText (IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		[DllImport ("user32.dll", SetLastError = true)]
		public static extern int GetWindowTextLength (IntPtr hWnd);

		[DllImport ("user32.dll", SetLastError = true)]
		[return: MarshalAs (UnmanagedType.Bool)]
		public static extern bool IsWindowVisible (IntPtr hWnd);

		//  DWORD GetWindowThreadProcessId(
		//      __in   HWND hWnd,
		//      __out  LPDWORD lpdwProcessId
		//  );
		[DllImport ("user32.dll")]
		private static extern uint GetWindowThreadProcessId (IntPtr hWnd, out uint lpdwProcessId);

		//HANDLE WINAPI OpenProcess(
		//  __in  DWORD dwDesiredAccess,
		//  __in  BOOL bInheritHandle,
		//  __in  DWORD dwProcessId
		//);
		[DllImport ("kernel32.dll")]
		private static extern IntPtr OpenProcess (uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

		//  DWORD WINAPI GetModuleFileNameEx(
		//      __in      HANDLE hProcess,
		//      __in_opt  HMODULE hModule,
		//      __out     LPTSTR lpFilename,
		//      __in      DWORD nSize
		//  );
		[DllImport ("psapi.dll")]
		private static extern uint GetModuleFileNameEx (IntPtr hWnd, IntPtr hModule, StringBuilder lpFileName, int nSize);


		[DllImport ("kernel32.dll")]
		private static extern bool CloseHandle (IntPtr handle);


		public static string GetWindowProcessName (IntPtr hWnd)
		{
			uint lpdwProcessId;
			GetWindowThreadProcessId (hWnd, out lpdwProcessId);

			IntPtr hProcess = OpenProcess (0x0410, false, lpdwProcessId);

			StringBuilder text = new StringBuilder (1000);
			//GetModuleBaseName(hProcess, IntPtr.Zero, text, text.Capacity);
			GetModuleFileNameEx (hProcess, IntPtr.Zero, text, text.Capacity);

			CloseHandle (hProcess);

			return text.ToString ();
		}

		[DllImport ("User32.dll")]
		public extern static int SendMessage (IntPtr hWnd, UInt32 msg, Int32 wParam, Int32 lParam);

		[DllImport ("user32", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern int GetKeyNameTextW (uint lParam, StringBuilder lpString,
		int nSize);

		[DllImport ("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		public static extern uint MapVirtualKeyW (uint uCode, uint uMapType);

		[DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
		public static extern IntPtr SetCapture(IntPtr hwnd);

		[DllImport ("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		public static extern bool ReleaseCapture ();

	}
}
