using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels.Ipc;
using System.Windows.Forms;
using ScreenshotInterface;
using System.Drawing;
using EasyHook;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Imaging;

namespace l2gamer
{

	/// <summary>
	/// Страница со скриншотом окна
	/// </summary>
	public class MdlScreenshot : MdlControlOwner
	{

		[DllImport("user32.dll")]
		static extern UInt32
		GetWindowThreadProcessId(int hwnd, out UInt32 processId);

		public String ChannelName = null;

		protected bool active = false;

		public bool Active
		{
			get { return active; }
			set { active = value; }
		}

		/// <summary>
		/// В процессе обновления.
		/// Будет сброшено после инициализации.
		/// </summary>
		protected bool inRefresh = false;

		/// <summary>
		/// В процессе обновления
		/// </summary>
		public bool InRefresh
		{
			get { return inRefresh; }
		}

		/// <summary>
		/// Возвращает true, когда скриншот обновляется
		/// </summary>
		public bool IsLocked
		{
			get { return locks > 0; }
		}

		protected static bool inited = false;

		public UcDebugScreenshot Panel;

		private IpcServerChannel ScreenshotServer;

		public Bitmap Screenshot = new Bitmap(2, 2, PixelFormat.Format24bppRgb);

		/// <summary>
		/// Сохранение скриншота из буффера библиотеки в локальный битмап
		/// </summary>
		/// <param name="bitmap"></param>
		public void AssignBitmapFromBytes(byte[] bitmap)
		{
			using (MemoryStream s = new MemoryStream(bitmap))
			{
				using (BinaryReader br = new BinaryReader(s))
				{
					tagBITMAPFILEHEADER bmpFileHeader = new tagBITMAPFILEHEADER();
					bmpFileHeader.bfType = br.ReadUInt16();
					bmpFileHeader.bfSize = br.ReadUInt32();
					bmpFileHeader.bfReserved1 = br.ReadUInt16();
					bmpFileHeader.bfReserved2 = br.ReadUInt16();
					bmpFileHeader.bfOffBits = br.ReadUInt32();

					tagBITMAPINFOHEADER bmpInfoHeader = new tagBITMAPINFOHEADER();
					bmpInfoHeader.bV5Size = br.ReadUInt32();
					bmpInfoHeader.bV5Width = br.ReadInt32();
					bmpInfoHeader.bV5Height = br.ReadInt32();
					bmpInfoHeader.bV5Planes = br.ReadUInt16();
					bmpInfoHeader.bV5BitCount = br.ReadUInt16();
					bmpInfoHeader.bV5Compression = br.ReadUInt32();
					bmpInfoHeader.bV5SizeImage = br.ReadUInt32();
					bmpInfoHeader.bV5XPelsPerMeter = br.ReadInt32();
					bmpInfoHeader.bV5YPelsPerMeter = br.ReadInt32();
					bmpInfoHeader.bV5ClrUsed = br.ReadUInt32();
					bmpInfoHeader.bV5ClrImportant = br.ReadUInt32();

					if (
						Screenshot.Width != bmpInfoHeader.bV5Width ||
						Screenshot.Height != bmpInfoHeader.bV5Height
					)
					{
						Screenshot = new Bitmap(bmpInfoHeader.bV5Width, bmpInfoHeader.bV5Height, PixelFormat.Format24bppRgb);
					}

					int px_size =
					(int)(bmpFileHeader.bfSize - bmpFileHeader.bfOffBits) /
							(bmpInfoHeader.bV5Width * bmpInfoHeader.bV5Height);

					Color pc;
					UInt16 pcs16;
					UInt32 pcs32;
					byte a, r, g, b;

					using (BitmapDecorator bd = new BitmapDecorator(Screenshot))
					{
						for (int y = 0; y < bmpInfoHeader.bV5Height; ++y)
						{
							for (int x = 0; x < bmpInfoHeader.bV5Width; ++x)
							{
								switch (px_size)
								{
									case 2:
										// 16 bit
										pcs16 = br.ReadUInt16();

										//byte r = (byte) (c << 10);
										//byte g = (byte) (c << 5);
										//byte b = (byte) c;

										r = (byte)((pcs16 & 0xf800) >> 11);
										g = (byte)((pcs16 & 0x07e0) >> 5);
										b = (byte)(pcs16 & 0x001f);
										r = (byte)(r << 3);
										g = (byte)(g << 2);
										b = (byte)(b << 3);

										pc = Color.FromArgb(r, g, b);
										break;
									case 4:
										// 32 bit
										pcs32 = br.ReadUInt32();

										//byte r = (byte) (c << 10);
										//byte g = (byte) (c << 5);
										//byte b = (byte) c;

										a = (byte)(pcs32 >> 24);
										r = (byte)(pcs32 >> 16);
										g = (byte)(pcs32 >> 8);
										b = (byte)pcs32;

										pc = Color.FromArgb(a, r, g, b);
										break;
									default:
										pc = Color.Black;
										break;
								}

								bd.SetPixel(
									x,
									bmpInfoHeader.bV5Height - y - 1,
									pc
								);
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Bring the target window to the front and wait for it to be visible
		/// </summary>
		/// <remarks>If the window does not come to the front within approx. 30 seconds an exception is raised</remarks>
		private void BringProcessWindowToFront(IntPtr handle)
		{
			int i = 0;

			while (!NativeMethods.IsWindowInForeground(handle))
			{
				if (i == 0)
				{
					// Initial sleep if target window is not in foreground - just to let things settle
					Thread.Sleep(250);
				}

				if (NativeMethods.IsIconic(handle))
				{
					// Minimized so send restore
					NativeMethods.ShowWindow(handle, NativeMethods.WindowShowStyle.Restore);
				}
				else
				{
					// Already Maximized or Restored so just bring to front
					NativeMethods.SetForegroundWindow(handle);
				}
				Thread.Sleep(250);

				// Check if the target process main window is now in the foreground
				if (NativeMethods.IsWindowInForeground(handle))
				{
					// Leave enough time for screen to redraw
					Thread.Sleep(1000);
					return;
				}

				// Prevent an infinite loop
				if (i > 120) // about 30secs
				{
					throw new Exception("Could not set process window to the foreground");
				}
				i++;
			}
		}

		public void GetScreenshot(SimpleCallback callback)
		{
			RefreshScreenshot();
		}

		/// <summary>
		/// Инициализация
		/// </summary>
		public override void Init()
		{
			InitSlim();
		}

		/// <summary>
		/// Инициализации библиотеки внедрения
		/// </summary>
		public void InitSlim()
		{
			ChannelName = null;
			// Initialise the IPC server
			ScreenshotServer = RemoteHooking.IpcCreateServer<ScreenshotInterface.ScreenshotInterface>(
				ref ChannelName,
				WellKnownObjectMode.Singleton
			);

			Thread.Sleep(250);

			if (!inited)
			{
				inited = true;
				// NOTE: On some 64-bit setups this doesn't work so well.
				//       Sometimes if using a 32-bit target, it will not find the GAC assembly
				//       without a machine restart, so requires manual insertion into the GAC
				// Alternatively if the required assemblies are in the target applications
				// search path they will load correctly.

				// Must be running as Administrator to allow dynamic registration in GAC
				Config.Register("ScreenshotInjector", "ScreenshotInject.dll");
			}
			Thread.Sleep(250);

			UInt32 processId;
			UInt32 tid = GetWindowThreadProcessId((int)window.HWnd, out processId);
			this.pid = (int)processId;

			// Keep track of hooked processes in case more than one need to be hooked
			HookManager.AddHookedProcess(this.pid);

			// Inject DLL into target process
			RemoteHooking.Inject(
				this.pid,
				InjectionOptions.Default,
				// 32-bit version (the same because AnyCPU) could use different assembly that links to 32-bit C++ helper dll
				"ScreenshotInject.dll",
				// 64-bit version (the same because AnyCPU) could use different assembly that links to 64-bit C++ helper dll
				"ScreenshotInject.dll",
				// the optional parameter list...
				ChannelName, // The name of the IPC channel for the injected assembly to connect to
				Direct3D.CurrentVersion // The direct3DVersion used in the target application
			);

			// Ensure the target process is in the foreground,
			// this prevents an issue where the target app appears to be in 
			// the foreground but does not receive any user inputs.
			// Note: the first Alt+Tab out of the target application after injection
			//       may still be an issue - switching between windowed and 
			//       fullscreen fixes the issue however (see ScreenshotInjection.cs for another option)
			NativeMethods.SetForegroundWindow(window.HWnd);
		}

		/// <summary>
		/// Локи на чтение
		/// Будет установлено в 0 после инициализации.
		/// </summary>
		protected int locks = 0;

		/// <summary>
		/// Идентификатор процесса
		/// </summary>
		private int pid;

		/// <summary>
		/// Убирает лок
		/// </summary>
		/// <returns>Уровень лока</returns>
		public int popLock()
		{
			return --locks;
		}

		/// <summary>
		/// Наблюдения
		/// </summary>
		public L2ProgressInfo[] Progresses = { };

		/// <summary>
		/// Добавляет лок
		/// </summary>
		/// <returns>Уровень лока</returns>
		public int pushLock()
		{
			return ++locks;
		}

		public MdlScreenshot(GameWindow window, TabPage tab)
			: base(window, tab)
		{
			Panel = new UcDebugScreenshot(this);
			Uc = Panel;
			Panel.Parent = tab;
			Panel.Visible = true;
		}

		/// <summary>
		/// Запрос на обновление скриншота
		/// </summary>
		public void RefreshScreenshot()
		{
			if (InRefresh || IsLocked)
			{
				return;
			}

			inRefresh = true;

			ScreenshotManager.AddScreenshotRequest(
				pid,
				new ScreenshotRequest(new Rectangle(0, 0, 0, 0)),
				ScreenshotManagerCallback
			);
		}

		/// <summary>
		/// Колбэк, когда получен во внедряемой библиотеке получен скриншот
		/// </summary>
		/// <param name="clientPID">Идентификатор процесса</param>
		/// <param name="status">Статус ответа</param>
		/// <param name="screenshotResponse">Данные с ответом</param>
		public void ScreenshotManagerCallback(Int32 clientPID, ResponseStatus status, ScreenshotResponse screenshotResponse)
		{
			if (IsLocked)
			{
				inRefresh = false;
				return;
			}

			try
			{
				if (screenshotResponse != null && screenshotResponse.CapturedBitmap != null)
				{
					// Сохраняем битмап в собственный буфер
					AssignBitmapFromBytes(screenshotResponse.CapturedBitmap);
					// Отсылает сообщение об успешном обновлении
					Panel.UpdateScreenshot();
				}
			}
			finally
			{
				inRefresh = false;
			}
		}

		public override void Tick()
		{
			if (active)
			{
				RefreshScreenshot();
			}
		}

	}

}