using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace l2gamer
{
	class L2gConfig
	{

		public const string CLICKTYPE_SHELL_EXECUTE = "ShellExecute";

		public const string CLICKTYPE_POST_MESSAGE = "PostMessage";

		protected static L2gConfig instance;

		protected string clickType = "PostMessage";

		/// <summary>
		/// Тип эмуляции клика
		/// </summary>
		public string ClickType
		{
			set { clickType = value; }
			get { return clickType; }
		}

		/// <summary>
		/// Сохраняет конфиг в файл
		/// </summary>
		/// <param name="filename"></param>
		public void save(string filename)
		{
		}

		/// <summary>
		/// Загружает конфиг из файла
		/// </summary>
		/// <param name="filename"></param>
		public void load(string filename)
		{
		}

		/// <summary>
		/// Возвращает экземпляр конфигов
		/// </summary>
		/// <returns></returns>
		public static L2gConfig getInstance()
		{
			if (instance == null)
			{
				instance = new L2gConfig();
			}
			return instance;
		}

	}
}
