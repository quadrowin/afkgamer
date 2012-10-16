using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScreenshotInterface;

namespace l2gamer
{
	public partial class UcDebugScreenshot : UserControl
	{

		/// <summary>
		/// Связанная модель
		/// </summary>
		private MdlScreenshot mdlScreenshot;

		/// <summary>
		/// Создание формы
		/// </summary>
		/// <param name="mdlScreenshot">Связанная модель</param>
		public UcDebugScreenshot(MdlScreenshot mdlScreenshot)
		{
			InitializeComponent();
			this.mdlScreenshot = mdlScreenshot;
			comboSizeMode.SelectedIndex = (Int32)pbScreenshot.SizeMode;
		}

		/// <summary>
		/// Нажатие на флаг активности
		/// </summary>
		private void cbActive_CheckedChanged(object sender, EventArgs e)
		{
			mdlScreenshot.Active = cbActive.Checked;
		}

		private void rbDirect9_CheckedChanged(object sender, EventArgs e)
		{
			Dictionary<string, Direct3DVersion> versions = new Dictionary<string, Direct3DVersion>()
			{
				{"9", Direct3DVersion.Direct3D9},
				{"10", Direct3DVersion.Direct3D10},
				{"11", Direct3DVersion.Direct3D11}
			};
			if (sender is RadioButton && ((RadioButton) sender).Checked)
			{
				Direct3D.CurrentVersion = versions[((RadioButton) sender).Text];
			}
		}

		private void btnInit_Click(object sender, EventArgs e)
		{
			mdlScreenshot.InitSlim();
		}

		/// <summary>
		/// Время обновлить скриншот
		/// </summary>
		public void UpdateScreenshot()
		{
			pbScreenshot.Invoke((MethodInvoker)delegate()
			{
				pbScreenshot.Image = (Bitmap)mdlScreenshot.Screenshot.Clone();
			});
		}

		private void comboSizeMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			pbScreenshot.SizeMode = (PictureBoxSizeMode)Enum.Parse(
				typeof(PictureBoxSizeMode),
				comboSizeMode.Text,
				true
			);
		}

		private void UcDebugScreenshot_Load(object sender, EventArgs e)
		{

		}

	}
}
