using System;
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
			
			Get["/contact/"] = parameters =>
			{
				return View["Contact"];
			};
			
			Get["/about/"] = parameters =>
			{
				return View["About"];
			};
			
			Get["/entry/{id}"] = parameters =>
			{
				Entry entry = Entry.GetById(parameters.id);
				return Response.AsJson(entry);
			};
			
			Get["/{reference}/"] = parameters =>
			{
				var entry = Entry.GetByReference(parameters.reference);
				return View["Entry", entry];
			};
		}
	}
}
