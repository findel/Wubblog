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
			
			Get["/{reference}/"] = parameters =>
			{
				var entry = Entry.FindByReference(parameters.reference);
				return View["Entry", entry];
			};
			
			Post["/{reference}/"] = parameters =>
			{
				var entry = Entry.FindByReference(parameters.reference);
				var comment = new Comment(entry);
				
				comment.Name = Request.Form.Name;
				comment.Markdown = Request.Form.Markdown;
				comment.Email = Request.Form.Email;
				comment.Twitter = Request.Form.Twitter;
				comment.Website = Request.Form.Website;
				comment.Save();
				
				return View["Entry", entry];
				
			};
		}
	}
}
