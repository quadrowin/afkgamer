using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using ScreenshotInterface;

namespace l2gamer
{
	public partial class UcWincExtended : UserControl
	{

		public MdlProgressBindings ProgressBindings;

		private GameWindow window;

		public void Init(GameWindow window, TabPage tab)
		{
			this.window = window;
			ProgressBindings = window.ProgressBindings;

			Visible = false;
			Anchor = (
				(System.Windows.Forms.AnchorStyles)
				(
					(
						(
							System.Windows.Forms.AnchorStyles.Top |
							System.Windows.Forms.AnchorStyles.Bottom
						) |
						System.Windows.Forms.AnchorStyles.Left
					) |
					System.Windows.Forms.AnchorStyles.Right
				)
			);
			Parent = tab;
			SetBounds(0, 0, Parent.Width, Parent.Height);

			InitializeComponent();

			ProgressBindings.Progresses[(int)L2ObjectStateType.SelfCp].StateLabel = lbSelfCp;
			ProgressBindings.Progresses[(int)L2ObjectStateType.SelfHp].StateLabel = lbSelfHp;
			ProgressBindings.Progresses[(int)L2ObjectStateType.SelfMp].StateLabel = lbSelfMp;
			ProgressBindings.Progresses[(int)L2ObjectStateType.TargetHp].StateLabel = lbTargetHp;

			// SELF

			// Хил, когда свои ЦП < 80
			ProgressBindings.Progresses[(int)L2ObjectStateType.SelfCp].Bindings.Add(
				new L2ProgressBinding(window, cbSelfCp1, tbCp1Key1, tbCp1Key2)
			);

			// Хил, когда свои ЦП < 30
			ProgressBindings.Progresses[(int)L2ObjectStateType.SelfCp].Bindings.Add(
				new L2ProgressBinding(window, cbSelfCp2, tbCp2Key1, tbCp2Key2)
			);

			// Хил, когда свои ХП < 80
			ProgressBindings.Progresses[(int)L2ObjectStateType.SelfHp].Bindings.Add(
				new L2ProgressBinding(window, cbSelfHp1, tbHp1Key1, tbHp1Key2)
			);

			// Хил, когда свои ХП < 30
			ProgressBindings.Progresses[(int)L2ObjectStateType.SelfHp].Bindings.Add(
				new L2ProgressBinding(window, cbSelfHp2, tbHp2Key1, tbHp2Key2)
			);

			// Хил, когда свои МП < 80
			ProgressBindings.Progresses[(int)L2ObjectStateType.SelfMp].Bindings.Add(
				new L2ProgressBinding(window, cbSelfMp1, tbMp1Key1, tbMp1Key2)
			);

			// Хил, когда свои МП < 30
			ProgressBindings.Progresses[(int)L2ObjectStateType.SelfMp].Bindings.Add(
				new L2ProgressBinding(window, cbSelfMp2, tbMp2Key1, tbMp2Key2)
			);

			// TARGET

			// Атака, когда хп врага от 1 до 100
			ProgressBindings.Progresses[(int)L2ObjectStateType.TargetHp].Bindings.Add(
				new L2ProgressBinding(window, cbAttack, tbAttack).SetBorder(1, 100)
			);

			// after kill
			ProgressBindings.Progresses[(int)L2ObjectStateType.TargetHp].Bindings.Add(
				new L2ProgressBindingAfterKill(window, cbAfterKillActive, tbAfterKillKey1, tbAfterKillKey2, tbAfterKillKey3)
			);

			// empty target
			ProgressBindings.Progresses[(int)L2ObjectStateType.TargetHp].Bindings.Add(
				new L2ProgressBindingEmptyTarget(window, cbEmptyTargetActive, tbEmptyTargetKey1, tbEmptyTargetKey2, tbEmptyTargetKey3)
			);

			for (int i = 0; i <= 8; ++i)
			{
				ProgressBindings.Progresses[(int)L2ObjectStateType.Party1Hp + i].Bindings.Add(
					new L2ProgressBindingHeal(window, cbHealHp1Active, tbHealHp1Key).SetBorder(0, nudGroupHeal1)
				);
				ProgressBindings.Progresses[(int)L2ObjectStateType.Party1Hp + i].Bindings.Add(
					new L2ProgressBindingHeal(window, cbHealHp2Active, tbHealHp2Key).SetBorder(0, nudGroupHeal2)
				);
				ProgressBindings.Progresses[(int)L2ObjectStateType.Party1Mp + i].Bindings.Add(
					new L2ProgressBindingHeal(window, cbRegenMp1Active, tbRegenMp1).SetBorder(0, nudRegenMp1)
				);
			}

		}

		private void button3_Click(object sender, EventArgs e)
		{
			L2KeyEmulating ke = ProgressBindings.Progresses[(int)L2ObjectStateType.TargetHp].Bindings[0].Keys[0];
			ke.Emulate();
		}

		public GameWindow Window
		{
			get { return window; }
			set
			{
				window = value;
				L2KeyEmulating ke = new L2KeyEmulating(value, tbAttack);
			}
		}

		private void cbHealParty4_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (cbCharacter.Text == "")
			{
				MessageBox.Show("Name not defined.");
				return;
			}
			String fn = "character-" + HttpUtility.UrlEncode(cbCharacter.Text) + ".xml";
			XmlTextWriter xml = new XmlTextWriter(fn, null);
			xml.WriteStartDocument();

			xml.WriteStartElement("l2window");

			xml.WriteStartElement("Progresses");
			foreach (L2ProgressInfo info in ProgressBindings.Progresses)
			{
				xml.WriteStartElement("Progress");
				xml.WriteElementString("type", info.Type.ToString());
				xml.WriteElementString("x1", info.X1.ToString());
				xml.WriteElementString("y1", info.Y1.ToString());
				xml.WriteElementString("x2", info.X2.ToString());
				xml.WriteElementString("y2", info.Y2.ToString());
				xml.WriteElementString("hpColorR", info.HpColor.R.ToString());
				xml.WriteElementString("hpColorG", info.HpColor.G.ToString());
				xml.WriteElementString("hpColorB", info.HpColor.B.ToString());
				xml.WriteEndElement();
			}
			xml.WriteEndElement();

			xml.WriteStartElement("KeyTimers");
			foreach (KeyTimer info in window.AutoKeys.KeyTimers)
			{
				xml.WriteStartElement("KeyTimer");
				xml.WriteElementString("index", info.Index.ToString());
				xml.WriteElementString("key", info.Key.ToString());
				xml.WriteElementString("interval", info.Interval.ToString());
				xml.WriteElementString("active", info.Active.ToString());
				xml.WriteEndElement();
			}
			xml.WriteEndElement();

			xml.WriteEndElement();

			xml.WriteEndDocument();
			xml.Close();

			UpdateCharactersList();
		}

		private void button2_Click(object sender, EventArgs e)
		{

			String fn = "character-" + HttpUtility.UrlEncode(cbCharacter.Text) + ".xml";

			if (!File.Exists(fn))
			{
				return;
			}

			XmlDocument xml = new XmlDocument();
			xml.Load(fn);

			XmlNode window_node = xml["l2window"];

			XmlNodeList nodes = window_node["Progresses"].ChildNodes;
			foreach (XmlNode progress_node in nodes)
			{
				int type = int.Parse(progress_node.SelectSingleNode("type").InnerText);

				L2ProgressInfo info = ProgressBindings.Progresses[type];
				info.X1 = int.Parse(progress_node.SelectSingleNode("x1").InnerText);
				info.Y1 = int.Parse(progress_node.SelectSingleNode("y1").InnerText);
				info.X2 = int.Parse(progress_node.SelectSingleNode("x2").InnerText);
				info.Y2 = int.Parse(progress_node.SelectSingleNode("y2").InnerText);

				info.HpColor = Color.FromArgb(
					int.Parse(progress_node.SelectSingleNode("hpColorR").InnerText),
					int.Parse(progress_node.SelectSingleNode("hpColorG").InnerText),
					int.Parse(progress_node.SelectSingleNode("hpColorB").InnerText)
				);
			}

			nodes = window_node["KeyTimers"].ChildNodes;
			foreach (XmlNode key_node in nodes)
			{
				int index = int.Parse(key_node.SelectSingleNode("index").InnerText);
				window.AutoKeys.KeyTimers[index].Key = int.Parse(key_node.SelectSingleNode("key").InnerText);
				window.AutoKeys.KeyTimers[index].Interval = int.Parse(key_node.SelectSingleNode("interval").InnerText);
				window.AutoKeys.KeyTimers[index].Active = Boolean.Parse(key_node.SelectSingleNode("active").InnerText);
			}
		}

		public void UpdateCharactersList()
		{
			cbCharacter.Items.Clear();
			DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);
			string prefix = "character-";
			int prefix_len = prefix.Length;
			foreach (FileInfo file in dir.GetFiles())
			{
				if (
					file.Name.Length > prefix_len &&
					file.Name.Substring(0, prefix_len) == "character-" &&
					file.Extension == ".xml"
				)
				{
					string character = file.Name.Substring(
						prefix_len,
						file.Name.Length - prefix_len - 4
					);
					cbCharacter.Items.Add(HttpUtility.UrlDecode(character));
				}
			}
		}

		private void L2WindowPanel_VisibleChanged(object sender, EventArgs e)
		{
			if (Visible)
			{
				UpdateCharactersList();
			}
		}

		private void btnInitExtended_Click(object sender, EventArgs e)
		{
			ProgressBindings.InitSlim();
		}

		private void rbDirect9_CheckedChanged(object sender, EventArgs e)
		{
			if (rbDirect9.Checked)
			{
				Direct3D.CurrentVersion = Direct3DVersion.Direct3D9;
			}
		}

		private void rbDirect10_CheckedChanged(object sender, EventArgs e)
		{
			if (rbDirect10.Checked)
			{
				Direct3D.CurrentVersion = Direct3DVersion.Direct3D10;
			}
		}

		private void rbDirect11_CheckedChanged(object sender, EventArgs e)
		{
			if (rbDirect11.Checked)
			{
				Direct3D.CurrentVersion = Direct3DVersion.Direct3D11;
			}
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			FormScreenMark.ShowIt(window);
			btnSave.PerformClick();
		}

	}

}
