using System;
using Nancy;
using Wubblog.Library;

namespace Wubblog.Web.Modules
{
	public class EntryModule : NancyModule
	{
		public EntryModule() : base("/entries")
		{
			
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
