using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Utils.Extension.Methods.MVC
{
	public class MvcPager
	{
		public string ActionName { get; set; }
		public string ControllerName { get; set; }
		public int PageSize { get; set; } = 20;
		public int Count { get; set; }

		public int ShowMaxCount { get; set; } = 10;
		public Dictionary<string, object> KeepParameters { get; set; }

		public FormMethod FormMethod { get; set; } = FormMethod.Get;
	}
}
