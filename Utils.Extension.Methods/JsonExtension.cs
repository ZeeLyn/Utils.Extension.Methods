using Newtonsoft.Json;

namespace Utils.Extension.Methods
{
	public static partial class UtilsExtension
	{
		/// <summary>
		/// 将对象序列化成json字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string ToJson(this object value)
		{
			return value == null ? default : JsonConvert.SerializeObject(value);
		}

		/// <summary>
		/// 将对象序列化成json字符串
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string ToJson(this object value, JsonSerializerSettings settings)
		{
			return value == null ? default : JsonConvert.SerializeObject(value, settings);
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


		/// <summary>
		/// 判断字符串是否是json格式（为效率考虑，仅做了开始和结束字符的验证）
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsJson(this string value)
		{
			value = value.Trim();
			return value.StartsWith("{") && value.EndsWith("}") || value.StartsWith("[") && value.EndsWith("]");
		}

	}
}
