using System;

namespace Utils.Extension.Methods
{
    public static partial class UtilsExtension
    {
        /// <summary>
        /// 将时间转换成时间戳
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToTimestamp(this DateTime value)
        {
            return (long)(TimeZoneInfo.ConvertTimeToUtc(value) - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        /// <summary>
        /// 讲时间戳转换成UTC时间
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime ToUtcDateTime(this long timestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
        }

        /// <summary>
        /// 讲时间戳转换成本地时间
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime ToLocalDateTime(this long timestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp).Add(TimeZoneInfo.Local.BaseUtcOffset);
        }
    }
}
