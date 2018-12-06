using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Extension.Methods
{
	public static partial class UtilsExtension
	{
		/// <summary>
		/// 将时间转换成时间戳
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static long ToTimeStamp(this DateTime value)
		{
			return (long)(TimeZoneInfo.ConvertTimeToUtc(value) - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
		}

		/// <summary>
		/// 讲时间戳转换成UTC时间
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static DateTime ToUtcDateTime(this long value)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(value);
		}

		/// <summary>
		/// 讲时间戳转换成本地时间
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static DateTime ToLocalDateTime(this long value)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(value).Add(TimeZoneInfo.Local.BaseUtcOffset);
		}
	}
}
