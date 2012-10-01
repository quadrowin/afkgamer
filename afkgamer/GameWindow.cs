using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;

namespace l2gamer
{

    public class GameWindow
    {

		/// <summary>
		/// Активно
		/// </summary>
		protected bool active = false;

		/// <summary>
		/// Активно
		/// </summary>
		public bool Active
		{
			get { return active; }
			set { active = value; }
		}

		/// <summary>
		/// Периодическое нажатие
		/// </summary>
		public MdlAutoKeys AutoKeys
		{
			get { return (MdlAutoKeys)Controls[0]; }
		}

		/// <summary>
		/// Подгон размеров контролов
		/// </summary>
		public void ChangeSize()
		{
			foreach (MdlControlOwner control in controls)
			{
				if (control != null)
				{
					control.ChangeSize();
				}
			}
		}

		/// <summary>
		/// Имя чара
		/// </summary>
		public string characterName;

		/// <summary>
		/// Имя чара
		/// </summary>
		public string CharacterName
		{
			get { return characterName; }
			set
			{
				characterName = value;
				ListItem.SubItems[1].Text = characterName;
			}
		}

		protected List<MdlControlOwner> controls;

		public List<MdlControlOwner> Controls
		{
			get { return controls; }
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="hWnd">Хэндл окна</param>
		/// <param name="parentControl">Контрол со страницами</param>
		public GameWindow(IntPtr hWnd, TabControl parentControl)
		{
			this.hWnd = hWnd;
			this.parentControl = parentControl;
			controls = new List<MdlControlOwner>();
			controls.Add(new MdlAutoKeys(this, parentControl.TabPages[0]));
			controls.Add(new MdlControlOwner(this, null));
			//controls.Add(new MdlProgressBindings(this, parentControl.TabPages[1]));
			foreach (MdlControlOwner control in controls)
			{
				control.Init();
			}
		}

		/// <summary>
		/// Скрыть контролы
		/// </summary>
		public void Hide()
		{
			foreach (MdlControlOwner control in controls)
			{
				control.Hide();
			}
		}

		protected IntPtr hWnd;

		/// <summary>
		/// Хэндл окна
		/// </summary>
		public IntPtr HWnd
		{
			get { return hWnd; }
		}

		/// <summary>
		/// Элемент списка в списке окон
		/// </summary>
		public ListViewItem ListItem;

		public void LoadFile(string filename)
		{
			XPathDocument xml = new XPathDocument(filename);
			XPathNavigator n = xml.CreateNavigator();
			foreach (MdlControlOwner control in controls)
			{
				control.LoadFromXml(n, "/Character/");
			}
		}

		protected TabControl parentControl;


		/// <summary>
		/// Контрол со страницами
		/// </summary>
		public TabControl ParentControl
		{
			get { return parentControl; }
			set { parentControl = value; }
		}

		/// <summary>
		/// Ивенты по скринам
		/// </summary>
		public MdlProgressBindings ProgressBindings
		{
			get { return (MdlProgressBindings)Controls[1]; }
		}

		/// <summary>
		/// Показать контролы
		/// </summary>
		public void Show()
		{
			foreach (MdlControlOwner control in controls)
			{
				control.Show();
			}
		}

		/// <summary>
		/// Обработка 
		/// </summary>
		public void Tick()
		{
			foreach (MdlControlOwner control in controls)
			{ 
				control.Tick();
			}
		}

		/// <summary>
		/// Сохранение в файл
		/// </summary>
		/// <param name="filename">Путь до файла</param>
		public void SaveFile(string filename)
		{
			XmlTextWriter xml = new XmlTextWriter(filename, null);
			xml.WriteStartDocument();
			xml.WriteStartElement("Character");
				foreach (MdlControlOwner control in controls)
				{ 
					control.SaveToXml(xml);
				}
			xml.WriteEndElement();
			xml.WriteEndDocument();
			xml.Close();
		}

    }

}