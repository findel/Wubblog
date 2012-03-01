using System;
using System.Linq;
using Nancy;
using Wubblog.Library;

namespace Wubblog.Web.Modules
{
	public class PageModule : NancyModule
	{
		public PageModule()
		{
			Get["/"] = parameters =>
			{
				return View["Index"];
			};
		}
	}
}
