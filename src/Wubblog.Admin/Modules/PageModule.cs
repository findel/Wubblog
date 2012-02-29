using System;
using System.Linq;
using Nancy;
using Wubblog.Library;

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
		}
	}
}
