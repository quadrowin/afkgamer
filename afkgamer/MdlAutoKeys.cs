using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace l2gamer
{
	public class MdlAutoKeys : MdlControlOwner
	{

		public List<KeyTimer> KeyTimers;

		public Dictionary<int, L2KeyEmulating> KeyEmulatings;

		public UcAutoKeys Panel;

		public Queue<L2KeyEmulating> KeysQueue = new Queue<L2KeyEmulating>();

		private DateTime lastKeyPressTime = DateTime.Now;

		public MdlAutoKeys(GameWindow window, TabPage tab) :
			base(window, tab)
		{
			KeyEmulatings = new Dictionary<int, L2KeyEmulating>();
			Panel = new UcAutoKeys(this);
			Uc = Panel;
			Panel.Parent = tab;
			Panel.Visible = true;
			InitKeyTimers();
		}

		/// <summary>
		/// Create new KeyTimer
		/// </summary>
		/// <returns></returns>
		public KeyTimer Add()
		{
			KeyTimer kt = new KeyTimer(Panel, KeyTimers.Count);
			KeyTimers.Add(kt);
			return kt;
		}

		public void InitKeyTimers()
		{
			KeyTimers = new List<KeyTimer>();
			for (int i = 0; i < 12; ++i)
			{
				KeyTimer kt = new KeyTimer(Panel, i);
				kt.HWnd = window.HWnd;
				KeyTimers.Add(kt);
				kt.Key = (int) Keys.F1 + i;
			}
		}

		public override void LoadFromXml(XPathNavigator xml, string prefix)
		{
			XPathNodeIterator iterator = xml.Select(
				prefix + GetType().FullName + "/" + GetType().Namespace + ".KeyTimer"
			);
			int i = 0;
			while (iterator.MoveNext())
			{
				if (i >= KeyTimers.Count)
				{
					Add();
				}
				KeyTimer kt = KeyTimers[i];
				kt.Active = iterator.Current.GetAttribute("Active", "").ToLower() == "true";
				kt.Interval = Convert.ToInt32(iterator.Current.GetAttribute("Interval", ""));
				kt.Key = Convert.ToInt32(iterator.Current.GetAttribute("Key", ""));
				string startTime = iterator.Current.GetAttribute("StartTime", "");
				if (startTime != "")
				{
					DateTime minTime = Convert.ToDateTime("2012-01-01");
					kt.StartTime = Convert.ToDateTime(startTime);
					if (kt.StartTime < minTime)
					{
						kt.StartTime = DateTime.Now;
					}
				}
				++i;
			}
		}

		public void ProcessKeys()
		{
			if (KeysQueue.Count == 0)
			{
				return;
			}
			TimeSpan dt = DateTime.Now - lastKeyPressTime;
			if (dt.TotalMilliseconds < 300)
			{
				return;
			}

			L2KeyEmulating key = KeysQueue.Dequeue();
			key.Emulate();
			lastKeyPressTime = DateTime.Now;
		}

		/// <summary>
		/// Save to a XML
		/// </summary>
		/// <param name="xml">XML document</param>
		public override void SaveToXml(XmlTextWriter xml)
		{
			xml.WriteStartElement(GetType().FullName);
			foreach (KeyTimer kt in KeyTimers)
			{
				xml.WriteStartElement(kt.GetType().FullName);
				xml.WriteAttributeString("Index", kt.Index.ToString());
				xml.WriteAttributeString("Active", kt.Active.ToString());
				xml.WriteAttributeString("Interval", kt.Interval.ToString());
				xml.WriteAttributeString("Key", kt.Key.ToString());
				xml.WriteAttributeString("StartTime", kt.StartTime.ToString());
				xml.WriteEndElement();
			}
			xml.WriteEndElement();
		}

		/// <summary>
		/// Deactivate all timers
		/// </summary>
		public void StopAll()
		{
			foreach (KeyTimer kt in KeyTimers)
			{
				kt.Active = false;
			}
		}

		/// <summary>
		/// Update all timers state
		/// </summary>
		public override void Tick()
		{
			Panel.SetBounds(
				0,
				0,
				Panel.Parent.ClientRectangle.Width,
				Panel.Parent.ClientRectangle.Height
			);

			foreach (KeyTimer kt in KeyTimers)
			{
				if (kt.Active)
				{
					kt.CheckTime();
				}
			}
			ProcessKeys();
		}

	}

}
