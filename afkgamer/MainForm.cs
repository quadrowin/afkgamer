using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ScreenshotInterface;
using System.Drawing.Drawing2D;
using System.Web;

namespace l2gamer
{

	public partial class MainForm : Form
	{

		/// <summary>
		/// Путь до настроек чаров
		/// </summary>
		const string CHARACTERS_PATH = "/characters/";

		[DllImport("user32.dll")]
		static extern bool LockWindowUpdate(IntPtr hWndLock);

		private Bitmap TempBmp;

		/// <summary>
		/// Найденные окна
		/// </summary>
		public static List<GameWindow> Windows;

		/// <summary>
		/// Выбранное окно
		/// </summary>
		private GameWindow activeWindow;

		/// <summary>
		/// Хендл активного окна
		/// </summary>
		private IntPtr lastForegroundWindow;

		/// <summary>
		/// Активное окно
		/// </summary>
		public GameWindow ActiveWindow
		{
			get { return activeWindow; }

			set
			{
				LockWindowUpdate(this.Handle);

				if (activeWindow != null)
				{
					activeWindow.Hide();
				}

				activeWindow = value;

				if (activeWindow != null)
				{
					activeWindow.Show();
					cbCharacter.Text = activeWindow.CharacterName;
					activeWindow.ChangeSize();
				}

				// redraw the window
				LockWindowUpdate(IntPtr.Zero);
			}
		}

		public MainForm()
		{
			TempBmp = new Bitmap(1024, 5);
			Windows = new List<GameWindow>();
			InitializeComponent();
			//	pictureBox1.Image = TempBmp;
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			ActiveWindow = null;
			// В temp останутя только окна, которые больше не существуют
			List<GameWindow> temp = new List<GameWindow>(Windows);
			Windows.Clear();
			lvWindows.Items.Clear();

			NativeMethods.EnumWindows(
				(hWnd, lParam) =>
				{
					if (NativeMethods.IsWindowVisible(hWnd))
					{
						string title = GetWindowText(hWnd);
						if (title.IndexOf(tbWindowFilter.Text) >= 0)
						{
							GameWindow window = null;

							foreach (GameWindow w in temp)
							{
								if (w.HWnd == hWnd)
								{
									window = w;
									temp.Remove(w);
									break;
								}
							}

							ListViewItem lvi = lvWindows.Items.Add(title);
							lvi.SubItems.Add(
								(window != null && window.CharacterName != "")
								? window.CharacterName
								: String.Concat(hWnd)
							);
							if (window == null) 
							{
								window = new GameWindow(hWnd, tcWindow);
							}
							Windows.Add(window);
							window.ListItem = lvi;
							lvi.Checked = window.Active;
							window.Hide();
						}
					}
					return true;
				},
				IntPtr.Zero
			);

			foreach (GameWindow window in temp)
			{
				window.Active = false;
				window.ListItem.Remove();
			}
		}

		/// <summary>
		/// Возвращает заголовок окна
		/// </summary>
		/// <param name="hWnd">Хэндл окна</param>
		/// <returns>Заголовок строка</returns>
		private string GetWindowText(IntPtr hWnd)
		{
			int len = NativeMethods.GetWindowTextLength(hWnd) + 1;
			StringBuilder sb = new StringBuilder(len);
			len = NativeMethods.GetWindowText(hWnd, sb, len);
			return sb.ToString(0, len);
		}

		public void L2Window_ScreenshotUpdate(GameWindow window)
		{
			//TempScreen = Direct3DCapture.CaptureWindow (new IntPtr (window.HWnd));
			//TempScreen = new Bitmap (WindowImageCapture.CaptureWindow (new IntPtr (window.HWnd)));


			//using (BitmapDecorator deco = new BitmapDecorator(window.ProgressBindings.Screenshot))
			//{
			//    foreach (L2ProgressInfo progress in window.ProgressBindings.Progresses)
			//    {
			//        if (!progress.IsEmpty())
			//        {
			//            int x = progress.X2;
			//            Color pixel = deco.GetPixel(x, progress.Y1);

			//            while (x > progress.X1 && !progress.IsHpColor(pixel))
			//            {
			//                if (cbDebugScreen.Checked && !inDebugScreenUpdate)
			//                {
			//                    TempBmp.SetPixel(x, 0, deco.GetPixel(x, progress.Y1 - 2));
			//                    TempBmp.SetPixel(x, 1, deco.GetPixel(x, progress.Y1 - 1));
			//                    TempBmp.SetPixel(x, 2, pixel);
			//                    TempBmp.SetPixel(x, 3, deco.GetPixel(x, progress.Y1 + 1));
			//                    TempBmp.SetPixel(x, 4, deco.GetPixel(x, progress.Y1 + 2));
			//                }
			//                x--;
			//                pixel = deco.GetPixel(x, progress.Y1);
			//            }

			//            if (cbDebugScreen.Checked && !inDebugScreenUpdate)
			//            {
			//                inDebugScreenUpdate = true;
			//                TempBmp.SetPixel(x - 1, 0, Color.White);
			//                TempBmp.SetPixel(x - 1, 1, Color.White);
			//                TempBmp.SetPixel(x - 1, 2, Color.White);
			//                TempBmp.SetPixel(x - 1, 3, Color.White);
			//                TempBmp.SetPixel(x - 1, 4, Color.White);

			//                pbDebugScreen.Invoke(new MethodInvoker(
			//                    delegate()
			//                    {
			//                        if (pbDebugScreen.Image != TempBmp)
			//                        {
			//                            pbDebugScreen.Image = TempBmp;
			//                        }
			//                        else
			//                        {
			//                            pbDebugScreen.Invalidate();
			//                        }
			//                    }
			//                ));
			//            }

			//            progress.Hp =
			//                progress.X2 > progress.X1 ?
			//                (100 * (x - progress.X1) / (progress.X2 - progress.X1)) :
			//                0;
			//        }
			//    }
			//}
		}

		private void tmrUpdateState_Tick(object sender, EventArgs e)
		{
			IntPtr foregroundWindow = NativeMethods.GetForegroundWindow();

			foreach (GameWindow window in Windows)
			{
				if (window.HWnd == foregroundWindow)
				{
					if (lastForegroundWindow != foregroundWindow)
					{
						lastForegroundWindow = foregroundWindow;
						lvWindows.Invalidate();
					}
				}
				if (window.Active)
				{
					window.Tick();
				}
			}

			// убираем выделение, ниодно из окон линейки неактивно
			if (lastForegroundWindow != foregroundWindow)
			{
				lastForegroundWindow = foregroundWindow;
				lvWindows.Invalidate();
			}
			//pictureBox1.Image = TempBmp;
		}

		private void lvWindows_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (
				lvWindows.SelectedItems.Count > 0 &&
				lvWindows.SelectedItems[0].Index < Windows.Count
			)
			{
				ActiveWindow = Windows[lvWindows.SelectedItems[0].Index];
			}
		}

		private void lvWindows_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			IntPtr hwnd = Windows[e.Index].HWnd;
			foreach (GameWindow window in Windows)
			{
				if (window.HWnd == hwnd)
				{
					window.Active = e.NewValue == CheckState.Checked;
				}
			}
		}

		private void tbHp1Key1_KeyDown(object sender, KeyEventArgs e)
		{
			((TextBox)sender).Text = L2Key.CodeToKeyName((uint)e.KeyCode);
		}

		private void tbAttack_KeyDown(object sender, KeyEventArgs e)
		{
			((TextBox)sender).Text = L2Key.CodeToKeyName((uint)e.KeyCode);
		}

		public int MakeLParam(int LoWord, int HiWord)
		{
			return ((HiWord << 16) | (LoWord & 0xffff));
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			RefreshCharactersList();
			lvWindows.Items.Clear();
			while (tcWindow.TabCount > 2)
			{
				tcWindow.TabPages.RemoveAt(2);
			}
			btnRefresh_Click(sender, e);
			tmrUpdateState.Enabled = true;
		}

		private void lvWindows_DoubleClick(object sender, EventArgs e)
		{

		}

		private void tbCharacter_TextChanged(object sender, EventArgs e)
		{

		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (activeWindow != null)
			{
				string filename = GetCharactersPath() + 
					HttpUtility.UrlEncode(ActiveWindow.CharacterName) + 
					".xml";
				saveCharacter(filename);
			}
			RefreshCharactersList();
		}

		private void saveCharacter(string filename)
		{
			ActiveWindow.SaveFile(filename);
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			if (activeWindow != null)
			{
				string filename = Path.GetDirectoryName(Application.ExecutablePath);
				filename += CHARACTERS_PATH + 
					HttpUtility.UrlEncode(ActiveWindow.CharacterName) + 
					".xml";

				if (!File.Exists(filename))
				{
					return;
					//throw new Exception("Not exists: " + filename);
				}
				activeWindow.LoadFile(filename);
			}
			RefreshCharactersList();
		}

		private void tcWindow_SizeChanged(object sender, EventArgs e)
		{
			if (ActiveWindow != null)
			{
				ActiveWindow.ChangeSize();
			}
		}

		private void lvWindows_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			//e.DrawDefault = true;
		}

		private void lvWindows_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
		{
			GameWindow window = Windows[e.ItemIndex];
			if (lastForegroundWindow == window.HWnd)
			{
				// Draw the background and focus rectangle for a selected item.
				e.Graphics.FillRectangle(Brushes.Maroon, e.Bounds);
			}
			else if (ActiveWindow == window)
			{
				// Draw the background and focus rectangle for a selected item.
				e.Graphics.FillRectangle(
					new SolidBrush(System.Drawing.SystemColors.Highlight),
					e.Bounds
				);
			}

			if (e.ColumnIndex == 0)
			{
				if (e.Item.Checked)
				{
					ControlPaint.DrawCheckBox(e.Graphics, e.Bounds.X + 1, e.Bounds.Top + 1, 14, 14, ButtonState.Normal | ButtonState.Checked);
				}
				else
				{
					ControlPaint.DrawCheckBox(e.Graphics, e.Bounds.X + 1, e.Bounds.Top + 1, 14, 14, ButtonState.Normal);
				}

				e.Graphics.DrawString(
					e.Item.Text,
					lvWindows.Font,
					Brushes.Black,
					new PointF(e.Bounds.X + 16, e.Bounds.Top + 1)
				);
			}
			else
			{
				e.DrawText(TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
			}
		}

		private void lvWindows_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
		{
			e.DrawDefault = true;
		}

		private void comboBox1_TextChanged(object sender, EventArgs e)
		{
			if (ActiveWindow != null)
			{
				ActiveWindow.CharacterName = ((ComboBox)sender).Text;
			}
		}

		/// <summary>
		/// Возвращает путь до директории с настройками чаров
		/// </summary>
		/// <returns>string</returns>
		public string GetCharactersPath()
		{
			return Path.GetDirectoryName(Application.ExecutablePath) + CHARACTERS_PATH;
		}

		public void RefreshCharactersList()
		{
			string path = GetCharactersPath();

			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}

			string []files = Directory.GetFiles(path, "*.xml");
			cbCharacter.Items.Clear();
			foreach (string file in files)
			{
				string character = file.Substring(
					path.Length, 
					file.Length - path.Length - 4
				);
				character = HttpUtility.UrlDecode(character);
				cbCharacter.Items.Add(character);
			}
		}

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			L2gConfig.getInstance().ClickType = L2gConfig.CLICKTYPE_SHELL_EXECUTE;
			toolStripMenuItem2.Checked = false;
			toolStripMenuItem3.Checked = true;
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			L2gConfig.getInstance().ClickType = L2gConfig.CLICKTYPE_POST_MESSAGE;
			toolStripMenuItem2.Checked = true;
			toolStripMenuItem3.Checked = false;
		}

		private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
		{

		}

	}

}
