using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace l2gamer
{

	public partial class FormScreenMark : Form
	{

		private GameWindow window;

		public GameWindow Window
		{
			get { return window; }
			set { window = value; }
		}

		private Boolean isNearColor(Color c1, Color c2)
		{
			return
				Math.Abs(c1.R - c2.R) < 10 &&
				Math.Abs(c1.G - c2.G) < 10 &&
				Math.Abs(c1.B - c2.B) < 10;
		}

		private Boolean isLineContinue(Color c1, Color c2, Color c3)
		{
			return
				(
					(c2.R - c1.R) > 30 &&
					(c2.G - c1.G) > 30 &&
					(c2.B - c1.B) > 30
				) ||
				(
					Math.Abs(c1.R - c2.R) < 10 &&
					Math.Abs(c1.G - c2.G) < 10 &&
					Math.Abs(c1.B - c2.B) < 10
				) ||
				(
					(c3.R - c1.R) > 30 &&
					(c3.G - c1.G) > 30 &&
					(c3.B - c1.B) > 30
				) ||
				(
					Math.Abs(c1.R - c3.R) < 10 &&
					Math.Abs(c1.G - c3.G) < 10 &&
					Math.Abs(c1.B - c3.B) < 10
				);
		}

		public FormScreenMark()
		{
			InitializeComponent();
		}

		public void L2Window_ScreenshotUpdate(GameWindow window)
		{
			if (!picbScreen.InvokeRequired)
			{
				return;
			}

			picbScreen.Invoke(new MethodInvoker(delegate()
			{
				window.ProgressBindings.pushLock();
				picbScreen.Image = window.ProgressBindings.Screenshot;
				window.ProgressBindings.popLock();
			}));
		}

		public static void ShowIt(GameWindow window)
		{
			FormScreenMark form = new FormScreenMark();
			form.Window = window;
			form.btnUpdateScreen_Click(form, null);
			SimpleCallback sc = new SimpleCallback(form.L2Window_ScreenshotUpdate);
			form.Window.ProgressBindings.ScreenshotUpdate += sc;
			form.Window.ProgressBindings.RefreshScreenshot();
			form.updateWhoList();
			form.ShowDialog();
			window.ProgressBindings.ScreenshotUpdate -= sc;
		}

		private void displayMark(int type)
		{
			if (window.ProgressBindings.Progresses[type].IsEmpty())
			{
				pnlHp.Visible = false;
				clbWho.SetItemCheckState(type, CheckState.Unchecked);
				return;
			}

			int offset_x = pnlScreen.Padding.Left - pnlScreen.HorizontalScroll.Value;
			int offset_y = pnlScreen.Padding.Top - pnlScreen.VerticalScroll.Value;

			pnlHp.SetBounds(
				offset_x + window.ProgressBindings.Progresses[type].X1,
				offset_y + window.ProgressBindings.Progresses[type].Y1,
				window.ProgressBindings.Progresses[type].X2 - window.ProgressBindings.Progresses[type].X1,
				window.ProgressBindings.Progresses[type].Y2 - window.ProgressBindings.Progresses[type].Y1
			);
			labelHp.SetBounds(
				-1,
				0,
				window.ProgressBindings.Progresses[type].X2 - window.ProgressBindings.Progresses[type].X1 + 10,
				1
			);
			pnlHp.Visible = true;
			clbWho.SetItemCheckState(type, CheckState.Checked);
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			clbWho.SetSelected(1, true);
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			Color c;
			int x1 = e.X - 1;
			int x2 = e.X + 1;

			using (BitmapDecorator deco = new BitmapDecorator(window.ProgressBindings.Screenshot))
			{
				c = deco.GetPixel(e.X, e.Y);

				int x_next = x1 - 1;
				Color x_color = deco.GetPixel(x1, e.Y);
				Color x_next_color = deco.GetPixel(x_next, e.Y);
				while (isLineContinue(c, x_color, x_next_color) && x_next > 0)
				{
					x_color = x_next_color;
					x1 = x_next--;
					x_next_color = deco.GetPixel(x_next, e.Y);
				}

				x_next = x2 + 1;
				x_color = deco.GetPixel(x2, e.Y);
				x_next_color = deco.GetPixel(x_next, e.Y);
				while (isLineContinue(c, x_color, x_next_color) && x_next < window.ProgressBindings.Screenshot.Width)
				{
					x_color = x_next_color;
					x2 = x_next++;
					x_next_color = deco.GetPixel(x_next, e.Y);
				}
			}

			int selected = clbWho.SelectedIndex;
			window.ProgressBindings.Progresses[selected].Extend(x1, x2, e.Y);
			c = window.ProgressBindings.Screenshot.GetPixel(e.X, window.ProgressBindings.Progresses[selected].Y1);
			window.ProgressBindings.Progresses[selected].HpColor = c;
			listBox1.Items.Add(c);
			displayMark(selected);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int type = clbWho.SelectedIndex;
			window.ProgressBindings.Progresses[type].Clear();
			displayMark(type);
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void clbWho_SelectedValueChanged(object sender, EventArgs e)
		{

		}

		private void clbWho_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			e.NewValue =
				window.ProgressBindings.Progresses[e.Index].IsEmpty()
				? CheckState.Unchecked
				: CheckState.Checked;
		}

		private void clbWho_Validated(object sender, EventArgs e)
		{

		}

		private void clbWho_SelectedIndexChanged(object sender, EventArgs e)
		{
			int type = clbWho.SelectedIndex;
			displayMark(type);
		}

		private void btnUpdateScreen_Click(object sender, EventArgs e)
		{
			window.ProgressBindings.RefreshScreenshot();
			//FWindow.GetScreenshot (new SimpleCallback (form.L2Window_ScreenshotUpdate));
			//TempScreen = new Bitmap (WindowImageCapture.CaptureWindow (new IntPtr (FWindow.HWnd)));
			//picbScreen.Image = TempScreen;
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			foreach (L2ProgressInfo progress in window.ProgressBindings.Progresses)
			{
				progress.Clear();
			}
			updateWhoList();
		}

		private void updateWhoList()
		{
			foreach (L2ProgressInfo progress in window.ProgressBindings.Progresses)
			{
				if (progress.IsEmpty())
				{
					clbWho.SetItemCheckState(progress.Type, CheckState.Unchecked);
				}
				else
				{
					clbWho.SetItemCheckState(progress.Type, CheckState.Checked);
				}
			}
		}
	}
}