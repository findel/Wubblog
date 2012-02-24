using System;
using Nancy;

namespace Wubblog.Web.Modules
{
	/// <summary>
	/// Description of PagesModule.
	/// </summary>
	public class PageModule : NancyModule
	{
		public PageModule()
		{
			Get["/"] = parameters =>
			{
				return View["Index"];
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
