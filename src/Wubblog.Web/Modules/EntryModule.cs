using System;
using Nancy;
using Wubblog.Library;
using Wubblog.Web.Models;

namespace Wubblog.Web.Modules
{
	public class EntryModule : NancyModule
	{
		public EntryModule() : base("/entries")
		{
			Get["/"] = parameters => 
			{
				var viewModel = new EntriesViewModel();
				viewModel.Entries = Entry.All();
				return View["Entries", viewModel];
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
