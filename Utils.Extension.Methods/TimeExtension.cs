using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Extension.Methods
{
	public static partial class UtilsExtension
	{
		public static long ToUnixTimeStamp(this DateTime value)
		{
			return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
		}
	}
}
