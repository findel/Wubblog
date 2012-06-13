using System;
using System.Collections.Generic;
using Simple.Data;

namespace Wubblog.Library
{
	public class Comment
	{
		#region Constructors
		
		public Comment(){}
		
		public Comment(Entry entry)
		{
			this.PostedDate = DateTime.Now;
			this.Entry = entry;
		}
		
		#endregion
		
		#region Properties
		
		public int CommentId { get; set; }
		
		public string Name { get; set; }
		
		public string Email { get; set; } // For Gravatar.
		
		public string Website { get; set; } // Link to this.
		
		public string Twitter { get; set; } // Link to this.
		
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
		
		public bool Authorised { get; set; }
		
		public DateTime PostedDate { get; set; }
		
		private Entry _Entry;
		public Entry Entry 
		{ 
			get
			{
				return _Entry ?? (_Entry = Entry.FindById(this.EntryId));
			}
			set
			{
				_Entry = value;
				this.EntryId = value != null ? value.EntryId : 0;
			}
		}
		
		public int EntryId { get; set; }
		
		#endregion
		
		#region Methods
		
		public void Save()
		{
			if(this.CommentId == 0)
				DbFactory.Db.Comments.Insert(this);
			else
				DbFactory.Db.Comments.Update(this);
		}
		
		public void Delete()
		{
			DbFactory.Db.Comments.Delete(this);
		}
		
		#endregion
		
		#region Static
		
		public static IList<Comment> FindAllByEntry(Entry entry)
		{
			return DbFactory.Db.Comments.FindAllByEntryId(entry.EntryId).ToList<Comment>();
		}
		
		#endregion
	}
}
