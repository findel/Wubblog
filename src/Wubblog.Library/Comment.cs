using System;
using System.Collections.Generic;
using Simple.Data;

namespace Wubblog.Library
{
	public class Comment
	{
		#region Constructors
		
		public Comment() {}
		
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
		
		public Entry Entry { get; set; }
		
		#endregion
		
		#region Methods
		
		public void Save()
		{
			throw new NotImplementedException();
		}
		
		public void Delete()
		{
			throw new NotImplementedException();
		}
		
		#endregion
		
		#region Static
		
		private static string connectionString = "server=localhost;port=3307;database=wubbleyew;uid=root;pwd=";
		
		public static IEnumerable<Comment> FindAllByEntry(Entry entry)
		{
			var db = Database.OpenConnection(connectionString);
			return db.Comments.FindAllByEntryId(entry.EntryId).Cast<Comment>();
		}
		
		#endregion
	}
}
