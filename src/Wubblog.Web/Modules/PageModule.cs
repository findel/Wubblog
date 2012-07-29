using System;
using System.Linq;
using Nancy;
using Wubblog.Library;
using Wubblog.Web.Models;

namespace Wubblog.Web.Modules
{
	public class PageModule : NancyModule
	{
		public PageModule()
		{
			Get["/"] = parameters =>
			{
				var entries = Entry.Latest();
				var model = new IndexViewModel { Entries = entries };
				return View["Index", model];
			};
			
			Get["/contact/"] = parameters =>
			{
				return View["Contact"];
			};
			
			Get["/about/"] = parameters =>
			{
				return View["About"];
			};
		}
	}
}
