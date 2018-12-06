using System.Text;

namespace Utils.Extension.Methods
{
	public static partial class UtilsExtension
	{
		public static string AsString(this byte[] bytes)
		{
			if (bytes == null || bytes.Length == 0)
				return string.Empty;
			return Encoding.UTF8.GetString(bytes);
		}
	}
}
