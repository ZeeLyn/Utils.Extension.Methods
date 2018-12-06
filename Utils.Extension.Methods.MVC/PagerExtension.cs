using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Utils.Extension.Methods.MVC
{
	public static partial class MvcExtension
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="html"></param>
		/// <param name="redirectUrl"></param>
		/// <param name="pageindex"></param>
		/// <param name="pagesize"></param>
		/// <param name="count"></param>
		/// <param name="showMaxCount"></param>
		/// <param name="keepParameters"></param>
		/// <param name="formMethod"></param>
		/// <returns></returns>
		public static IHtmlContent Pager(this IHtmlHelper html, string redirectUrl, int pageindex = 1, int pagesize = 20, int count = 0, int showMaxCount = 10, Dictionary<string, object> keepParameters = null, FormMethod formMethod = FormMethod.Get)
		{


			if (pageindex <= 0)
				pageindex = 1;
			var pages = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
			if (pageindex > pages)
				pageindex = pages;
			var mid = showMaxCount / 2 + 1;
			var start = (long)(pageindex - mid + 1 < 1 ? 1 : pageindex - mid + 1);
			var end = pageindex + (showMaxCount - (pageindex - start + 1));
			if (end > pages)
			{
				end = pages;
				start = pages - showMaxCount + 1;
				if (start < 1)
				{
					start = 1;
				}
			}
			keepParameters = keepParameters ?? new Dictionary<string, object>();

			var content = new StringBuilder();
			content.Append("<div class=\"pager\"><ul>");
			keepParameters.Add("page", pageindex - 1 < 1 ? 1 : pageindex - 1);
			content.AppendFormat("<li class=\"pager_button pre{0}\"><a href=\"{1}\">上一页</a></li>", pageindex <= 1 ? " disabled" : "", pageindex <= 1 || formMethod == FormMethod.Post ? "javascript:;" : GetUrl(redirectUrl, keepParameters));
			for (var i = start; i <= end; i++)
			{
				keepParameters["page"] = i;
				var curre = i == pageindex;
				content.AppendFormat("<li class=\"pager_button{0}\"><a href=\"{1}\">{2}</a></li>", curre ? " active" : "", curre || formMethod == FormMethod.Post ? "javascript:;" : GetUrl(redirectUrl, keepParameters), i);
			}
			keepParameters["page"] = pageindex + 1 > pages ? pages : pageindex + 1;
			content.AppendFormat("<li class=\"pager_button next{0}\"><a href=\"{1}\">下一页</a></li>", pageindex >= pages ? " disabled" : "", pageindex >= pages || formMethod == FormMethod.Post ? "javascript:;" : GetUrl(redirectUrl, keepParameters));
			content.AppendFormat("</ul></div>{0}/{1}", pageindex, pages);

			return new HtmlString(content.ToString());

			//return html.Partial("Pager", new MvcPager
			//{
			//	ActionName = actionName,
			//	ControllerName = controllerName,
			//	PageSize = pagesize,
			//	Count = count,
			//	KeepParameters = keepParameters,
			//	FormMethod = formMethod,
			//	ShowMaxCount = showMaxCount
			//});
		}

		public static string GetUrl(string redirectUrl, IEnumerable<KeyValuePair<string, object>> parameters = null)
		{
			var para = parameters?.Aggregate("", (current, key) => current + ("&" + key.Key + "=" + key.Value))?.TrimStart('&');
			return $"{redirectUrl}" + (string.IsNullOrWhiteSpace(para) ? "" : "?" + para);
		}
	}
}
