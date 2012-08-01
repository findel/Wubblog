using System;
using System.Collections.Generic;
using Simple.Data;
using Simple.Data.Mysql;
using System.Linq;

namespace Wubblog.Library
{
	/// <summary>
	/// Description of Entry.
	/// </summary>
	public class Entry
	{
		
		#region Constructors
		
		public Entry()
		{
			this.CreatedDate = DateTime.Now;
		}
		
		#endregion
		
		#region Fields
		
		private IList<Comment> _Comments;
		
		#endregion
		
		#region Properties
		
		public int EntryId { get; set; }
		
		public string Reference { get; set; }
		
		public string Title { get; set; }
		
		public string Description { get; set; }
		
		public string Markdown { get; set; }
		
		public string Html
		{
			get
			{
				var md = new MarkdownSharp.Markdown();
				var html = md.Transform(this.Markdown);
				return html;
			}
		}
		
		public string Keywords { get; set; }
		
		public DateTime CreatedDate { get; set; }
		
		public DateTime PublishDate { get; set; }
		
		public bool Active { get; set; }
		
		private Author _Author;
		public Author Author
		{
			get
			{
				return _Author ?? (_Author = Author.FindById(this.AuthorId));
			}
			set
			{
				_Author = value;
				this.AuthorId = value != null ? value.AuthorId : 0;
			}
		}
		
		public int AuthorId { get; set; }
		
		
		
		public IList<Comment> Comments
		{
			get
			{
				return _Comments ?? (_Comments = Comment.FindAllByEntry(this));
			}
		}
		
		#endregion
		
		#region Methods
		
		public void Save()
		{
			if(this.EntryId == 0)
				DbFactory.Db.Entries.Insert(this);
			else
				DbFactory.Db.Entries.Update(this);
		}
		
		public void Delete()
		{
			throw new NotImplementedException();
		}
		
		#endregion
		
		#region Static
		
		public static Entry FindById(int id)
		{
			return DbFactory.Db.Entries.FindByEntryId(id);
		}
		
		public static Entry FindByReference(string reference)
		{
			return DbFactory.Db.Entries.FindByReference(reference);
		}
		
		public static IList<Entry> All()
		{
			return DbFactory.Db.Entries
				.FindAllByActive(true)
				.OrderByPublishDateDescending()
				.ToList<Entry>();
		}
		
		public static IList<Entry> Latest()
		{
			return DbFactory.Db.Entries
				.FindAllByActive(true)
				.OrderByPublishDateDescending()
				.Take(5)
				.ToList<Entry>();
		}
		
		#endregion
		
	}
}
