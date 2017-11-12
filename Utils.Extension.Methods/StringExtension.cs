using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Utils.Extension.Methods
{
	public static partial class UtilsExtension
	{
		/// <summary>
		/// 检查字符串是否是空
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsNullOrWhiteSpace(this string value)
		{
			return string.IsNullOrWhiteSpace(value);
		}

		/// <summary>
		/// 检查字符串是否不是空
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool NotNullOrWhiteSpace(this string value)
		{
			return !string.IsNullOrWhiteSpace(value);
		}

		/// <summary>
		/// 检查字符串是否是Email地址
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsEmail(this string value)
		{
			return value.NotNullOrWhiteSpace() && new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").IsMatch(value);
		}

		/// <summary>
		/// 检查是否是日期格式
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsDateTime(this string value)
		{
			return value.NotNullOrWhiteSpace() && DateTime.TryParse(value, out var _);
		}

		/// <summary>
		/// 检查字符串是否是手机号
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsMobileNumber(this string value)
		{
			return value.NotNullOrWhiteSpace() && value.Length == 11 && new Regex(@"^[1]+[3,4,5,7,8]+\d{9}").IsMatch(value);
		}

		/// <summary>
		/// Json字符串反序列化
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		public static T JsonToObject<T>(this string value)
		{
			return value.IsNullOrWhiteSpace() ? default : JsonConvert.DeserializeObject<T>(value);
		}
	}
}
