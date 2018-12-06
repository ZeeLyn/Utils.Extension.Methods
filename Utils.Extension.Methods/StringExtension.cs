using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
			return value.NotNullOrWhiteSpace() && DateTime.TryParse(value, out _);
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
		/// 将字符串按字符进行分割，返回集合
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <param name="separator"></param>
		/// <returns></returns>
		public static List<T> Split<T>(this string value, params char[] separator)
		{
			if (string.IsNullOrWhiteSpace(value))
				return null;
			var query = value.Split(separator);
			return query.Select(p => p.ConvertTo<T>()).ToList();
		}

		/// <summary>
		/// 将字符串按字符进行分割，返回集合
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <param name="separator"></param>
		/// <returns></returns>
		public static List<T> Split<T>(this string value, params string[] separator)
		{
			if (string.IsNullOrWhiteSpace(value))
				return null;
			var query = value.Split(separator, StringSplitOptions.None);
			return query.Select(p => p.ConvertTo<T>()).ToList();
		}

		public static byte[] AsBytes(this string value)
		{
			return value.IsNullOrWhiteSpace() ? null : Encoding.UTF8.GetBytes(value);
		}
	}
}
