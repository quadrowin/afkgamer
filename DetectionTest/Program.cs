using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DetectionTest
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			NativeMethods.AllocConsole();
			Console.WriteLine("Debug Console");
			Application.Run(new MainForm());
			NativeMethods.FreeConsole();
		}
	}
}
