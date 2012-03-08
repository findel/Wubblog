using System;
using System.Collections.Generic;
using Nancy;
using Wubblog.Admin.Models;
using Wubblog.Library;

namespace Wubblog.Admin.Modules
{
	public class EntriesModule : NancyModule
	{
		public EntriesModule()
		{
			
			Get["/entries/"] = p =>
			{
				var model = new EntriesViewModel { Entries = Entry.All() };
				return View["List", model];
			};
			
			Get["/entries/{id}/"] = p => 
			{
				var entry = Entry.FindById(p.id);
				return View["Edit", entry];
			};
			
			Post["/entries/{id}/"] = p =>
			{
				var entry = Entry.FindById(p.id);
				
				entry.Reference = Request.Form.Reference;
				entry.Title = Request.Form.Title;
				entry.Description = Request.Form.Description;
				entry.Markdown = Request.Form.Markdown;
				entry.Keywords = Request.Form.Keywords;
				entry.Save();
				
				return View["Edit", entry];
			};
			
		}
	}
}
