using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Utils.Extension.Methods
{
	public static partial class UtilsExtension
	{
		/// <summary>
		/// 根据key获取字典的值
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="dict"></param>
		/// <param name="key"></param>
		/// <param name="defaultVal"></param>
		/// <returns></returns>
		public static T DictionaryValue<T>(this IDictionary dict, object key, T defaultVal = default)
		{
			return !dict.Contains(key) ? defaultVal : dict[key].ConvertTo(defaultVal);
		}
	}
}
