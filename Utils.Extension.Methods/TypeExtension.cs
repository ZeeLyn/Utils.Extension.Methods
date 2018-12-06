using System;

namespace Utils.Extension.Methods
{
	public static partial class UtilsExtension
	{
		/// <summary>
		/// 转换成指定类型
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static T ConvertTo<T>(this object value, T defaultValue = default)
		{
			if (value == null)
				return defaultValue;
			try
			{
				return (T)Convert.ChangeType(value, typeof(T));
			}
			catch
			{
				return defaultValue;
			}
		}
	}
}
