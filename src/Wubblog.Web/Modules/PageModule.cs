using System;
using System.Linq;
using Nancy;
using Wubblog.Library;
using Wubblog.Web.Models;

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
				var entries = Entry.All();
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
			
			Get["/entry/{id}"] = parameters =>
			{
				Entry entry = Entry.FindById(parameters.id);
				return Response.AsJson(entry);
			};
			
			Get["/{reference}/"] = parameters =>
			{
				var entry = Entry.FindByReference(parameters.reference);
				return View["Entry", entry];
			};
		}
	}
}
