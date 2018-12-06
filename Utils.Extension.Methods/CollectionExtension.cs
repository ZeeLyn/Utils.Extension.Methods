using System.Collections;

namespace Utils.Extension.Methods
{
	public static partial class UtilsExtension
	{
		public static bool NotEmpty(this ICollection list)
		{
			return list != null && list.Count > 0;
		}

		public static bool IsEmpty(this ICollection list)
		{
			return list == null || list.Count == 0;
		}
	}
}
