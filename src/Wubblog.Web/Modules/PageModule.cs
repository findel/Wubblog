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
			
			Get["/{reference}/"] = parameters =>
			{
				var entry = Entry.GetByReference(parameters.reference);
				return View["Entry", entry];
			};
			
			Get["/entry/{id}"] = parameters =>
			{
				var entry = Entry.GetById(parameters.id);
				var entryFormat = "{{ id: {0}, title: {1}, description: {2}, markdown: {3}, html: {4}, keywords: {5}}}";
				var entryData = string.Format(entryFormat, entry.EntryId, entry.Title, entry.Description, entry.Markdown, entry.Html, entry.Keywords);
				return entryData;
			};
		}
	}
}
