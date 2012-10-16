using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace l2gamer
{

	/// <summary>
	/// 
	/// </summary>
	public class MdlControlOwner
	{

		/// <summary>
		/// Подгон размеров контролов
		/// </summary>
		public void ChangeSize()
		{
			if (Uc != null)
			{
				if (Uc.Width != tab.ClientRectangle.Width
					|| Uc.Height != tab.ClientRectangle.Height
				) {
					Uc.SetBounds(0, 0, tab.ClientRectangle.Width, tab.ClientRectangle.Height);
				}
			}
		}

		/// <summary>
		/// Скрыть контрол
		/// </summary>
		public void Hide()
		{
			if (Uc != null)
			{
				Uc.Visible = false;
			}
		}

		/// <summary>
		/// Инициализация
		/// </summary>
		public virtual void Init()
		{

		}

		public virtual void LoadFromXml(XPathNavigator xml, string prefix) { }

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="window"></param>
		/// <param name="tab"></param>
		public MdlControlOwner(GameWindow window, TabPage tab)
		{
			this.window = window;
			this.tab = tab;
		}

		/// <summary>
		/// Показать контрол
		/// </summary>
		public void Show()
		{
			if (Uc != null)
			{
				Uc.Visible = true;
			}
		}

		protected TabPage tab;

		public virtual void SaveToXml(XmlTextWriter xml) { }

		public virtual void Tick()
		{

		}

		public UserControl Uc;

		protected GameWindow window;

	}
}
