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
		
		public Entry() {}
		
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
			var db = Database.OpenConnection(connectionString);
			db.Entries.Update(this);
		}
		
		public void Delete()
		{
			throw new NotImplementedException();
		}
		
		#endregion
		
		#region Static
		
		private static string connectionString = "server=localhost;port=3307;database=wubbleyew;uid=root;pwd=";
		
		public static Entry FindById(int id)
		{
			var db = Database.OpenConnection(connectionString);
			return db.Entries.FindByEntryId(id);
		}
		
		public static Entry FindByReference(string reference)
		{
			var db = Database.OpenConnection(connectionString);
			return db.Entries.FindByReference(reference);
		}
		
		public static IList<Entry> All()
		{
			var db = Database.OpenConnection(connectionString);
			return db.Entries
				.FindAllByActive(true)
				.OrderByPublishDateDescending()
				.ToList<Entry>();
		}
		
		#endregion
		
	}
}
