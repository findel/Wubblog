using System;
using Simple.Data;
using Simple.Data.Mysql;

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
		
		#region Properties
		
		public int EntryId { get; set; }
		
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
		
		public static Entry GetById(int id)
		{
			//Server=myServerAddress;Port=1234;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
			var db = Database.OpenConnection("server=localhost;port=3307;database=wubbleyew;uid=root;pwd=");
			return db.Entries.FindByEntryId(id);
		}
		
		public static Entry GetByReference(string reference)
		{
			throw new NotImplementedException();
		}
		
		#endregion
		
	}
}
